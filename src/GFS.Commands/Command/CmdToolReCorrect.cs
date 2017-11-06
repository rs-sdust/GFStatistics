// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-14-2017
// ***********************************************************************
// <copyright file="CmdToolDrawElement.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>ITool for draw elements on map</summary>
// ***********************************************************************
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.BLL;
using System.Data;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;

namespace GFS.Commands
{
    public enum EnumDrawType
    {
        circle,
        ellipse,
        square,
        rectangle,
        polygon
    }

    [ClassInterface(ClassInterfaceType.None), Guid("53ef2f15-e450-4404-9edc-b3aad31f8ed5"), ProgId("GFS.CmdToolDrawElement")]
    public sealed class CmdToolReCorrect : BaseTool
    {
        private IHookHelper m_hookHelper;

        private INewCircleFeedback2 m_circleFeedback = null;

        private INewRectangleFeedback m_rectangleFeedback = null;

        private INewPolygonFeedback m_polygonFeedback = null;

        private IMapControl3 m_mapControl = null;

        //private Dictionary<int, ReCorrectElement> m_roiElementDic;

        public EnumDrawType DrawType
        {
            get;
            set;
        }

        public TreeList ROITreeList
        {
            get;
            set;
        }

        public TreeListNode ROINode
        {
            get;
            set;
        }

        public int ParentNodeID
        {
            get;
            set;
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdToolReCorrect.ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdToolReCorrect.ArcGISCategoryUnregistration(registerType);
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(cLSID);
        }

        public CmdToolReCorrect()
        {
            this.m_category = "";
            this.m_caption = "";
            this.m_message = "";
            this.m_toolTip = "";
            this.m_name = "CmdToolDrawElement";
            //this.m_roiElementDic = roiElementDic;
            try
            {
                //Assembly assembly = base.GetType().Assembly;
                //Stream manifestResourceStream = assembly.GetManifestResourceStream("HTES.TAS.Tools.DrawElement.ToolDrawElement.cur");
                //this.m_cursor = new System.Windows.Forms.Cursor(manifestResourceStream);
                this.m_cursor = Cursors.Cross;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        public override void OnCreate(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
            this.m_mapControl = EnviVars.instance.MapControl;
        }

        public override void OnClick()
        {
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                IPoint point = this.m_mapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                switch (this.DrawType)
                {
                    case EnumDrawType.circle:
                        if (this.m_circleFeedback == null)
                        {
                            this.m_circleFeedback = new NewCircleFeedbackClass();
                            this.m_circleFeedback.Display = this.m_mapControl.ActiveView.ScreenDisplay;
                            this.m_circleFeedback.Start(point);
                        }
                        break;
                    case EnumDrawType.ellipse:
                        this.DrawEllipse();
                        break;
                    case EnumDrawType.square:
                        if (this.m_rectangleFeedback == null)
                        {
                            this.m_rectangleFeedback = new NewRectangleFeedbackClass();
                            this.m_rectangleFeedback.Display = this.m_mapControl.ActiveView.ScreenDisplay;
                            this.m_rectangleFeedback.Start(point);
                        }
                        break;
                    case EnumDrawType.rectangle:
                        this.DrawRectangle();
                        break;
                    case EnumDrawType.polygon:
                        if (this.m_polygonFeedback == null)
                        {
                            this.m_polygonFeedback = new NewPolygonFeedbackClass();
                            this.m_polygonFeedback.Display = this.m_mapControl.ActiveView.ScreenDisplay;
                            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                            this.m_polygonFeedback.Start(point);
                        }
                        else
                        {
                            this.m_polygonFeedback.AddPoint(point);
                        }
                        break;
                }
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            IPoint point = this.m_mapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            switch (this.DrawType)
            {
                case EnumDrawType.circle:
                    if (this.m_circleFeedback != null)
                    {
                        this.m_circleFeedback.MoveTo(point);
                    }
                    break;
                case EnumDrawType.square:
                    if (this.m_rectangleFeedback != null)
                    {
                        this.m_rectangleFeedback.MoveTo(point);
                        this.m_rectangleFeedback.Constraint = esriEnvelopeConstraints.esriEnvelopeConstraintsSquare;
                        this.m_rectangleFeedback.Angle = 0.0;
                    }
                    break;
                case EnumDrawType.polygon:
                    if (this.m_polygonFeedback != null)
                    {
                        this.m_polygonFeedback.MoveTo(point);
                    }
                    break;
            }
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            IPoint point = this.m_mapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            IGeometry geometry = null;
            IElement element = null;
            switch (this.DrawType)
            {
                case EnumDrawType.circle:
                    if (this.m_circleFeedback != null)
                    {
                        ICircularArc circularArc = this.m_circleFeedback.Stop();
                        this.m_circleFeedback = null;
                        if (circularArc == null || circularArc.IsPoint)
                        {
                            return;
                        }
                        geometry = MapAPI.ConvertCircularArcToPolygon(circularArc);
                        element = new CircleElementClass();
                    }
                    break;
                case EnumDrawType.square:
                    if (this.m_rectangleFeedback != null)
                    {
                        geometry = this.m_rectangleFeedback.Stop(point);
                        if ((geometry as IPointCollection).PointCount == 2)
                        {
                            this.m_rectangleFeedback = null;
                            return;
                        }
                        this.m_rectangleFeedback = null;
                        element = new PolygonElementClass();
                    }
                    break;
            }
            if (geometry != null)
            {
                element.Geometry = geometry;
                this.AppendNodeToTreeList(element);
            }
        }

        public override void OnDblClick()
        {
            if (this.DrawType == EnumDrawType.polygon)
            {
                IPolygon polygon = this.m_polygonFeedback.Stop();
                this.m_polygonFeedback = null;
                if (polygon != null)
                {
                    (polygon as ITopologicalOperator).Simplify();
                    this.AppendNodeToTreeList(new PolygonElementClass
                    {
                        Geometry = polygon
                    });
                }
            }
        }

        public override void OnKeyDown(int keyCode, int Shift)
        {
            if (keyCode == 27)
            {
                EnumDrawType drawType = this.DrawType;
                if (drawType != EnumDrawType.circle)
                {
                    if (drawType == EnumDrawType.polygon)
                    {
                        if (this.m_polygonFeedback != null)
                        {
                            this.m_polygonFeedback.Stop();
                        }
                        this.m_polygonFeedback = null;
                    }
                }
                else
                {
                    if (this.m_circleFeedback != null)
                    {
                        this.m_circleFeedback.Stop();
                    }
                    this.m_circleFeedback = null;
                }
                this.m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private IFillSymbol GetFillSymbol()
        {
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            IColor color = new RgbColorClass();
            simpleLineSymbol.Color = new RgbColorClass
                    {
                        Red = 255,
                        Green = 255,
                        Blue = 255
                    };
            simpleLineSymbol.Width = 1.3;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            ISimpleFillSymbol fill = new SimpleFillSymbolClass
            {
                Outline = simpleLineSymbol,
                //Color = this.m_roiElementDic[this.ParentNodeID].Color
            };
            fill.Style = esriSimpleFillStyle.esriSFSHollow;
            return fill;
        }

        private void DrawEllipse()
        {
            IEnvelope envelope = this.m_mapControl.TrackRectangle();
            if (!envelope.IsEmpty)
            {
                IConstructEllipticArc constructEllipticArc = new EllipticArcClass();
                constructEllipticArc.ConstructEnvelope(envelope);
                ISegment inSegment = constructEllipticArc as ISegment;
                ISegmentCollection segmentCollection = new RingClass();
                object missing = Type.Missing;
                segmentCollection.AddSegment(inSegment, ref missing, ref missing);
                IRing ring = segmentCollection as IRing;
                ring.Close();
                IGeometryCollection geometryCollection = new PolygonClass();
                geometryCollection.AddGeometry(ring, ref missing, ref missing);
                this.AppendNodeToTreeList(new EllipseElementClass
                {
                    Geometry = (geometryCollection as IGeometry)
                });
            }
        }

        private void DrawRectangle()
        {
            IEnvelope envelope = this.m_mapControl.TrackRectangle();
            if (!envelope.IsEmpty)
            {
                this.AppendNodeToTreeList(new RectangleElementClass
                {
                    Geometry = envelope
                });
            }
        }

        private void AppendNodeToTreeList(IElement element)
        {
            try
            {
                //get element symbol
                (element as IFillShapeElement).Symbol = this.GetFillSymbol();
                //new correctelement
                ReCorrectElement reCorrectElement = new ReCorrectElement();
                reCorrectElement.ID = ROITreeList.Nodes.Count;
                reCorrectElement.Checked = true;
                reCorrectElement.Element = element;
                reCorrectElement.CorrectMap = this.NewEmptyMap();
                List<byte> uniqueValue = GetBlockUniqueValue(MapAPI.GetTopVisableRaster(), element);
                if (uniqueValue == null)
                    return;
                //add unique value to recorrect map
                foreach (byte value in uniqueValue)
                {
                    DataRow row = reCorrectElement.CorrectMap.NewRow();
                    row[0] = value;
                    reCorrectElement.CorrectMap.Rows.Add(row);
                }
                             
                //this.m_roiElementDic.Add(reCorrectElement.ID, reCorrectElement);
                TreeListNode treeListNode = this.ROITreeList.AppendNode(new object[]
            {
                reCorrectElement.ID.ToString()
            }, null, System.Windows.Forms.CheckState.Checked);
                ROITreeList.SetFocusedNode(null);
                treeListNode.Tag = reCorrectElement;
                ROITreeList.SetFocusedNode(treeListNode);
                //this.ROINode.ExpandAll();
                this.m_mapControl.ActiveView.GraphicsContainer.AddElement(element, 0);
                (this.m_mapControl.ActiveView.GraphicsContainer as IGraphicsContainerSelect).UnselectAllElements();
                (this.m_mapControl.ActiveView.GraphicsContainer as IGraphicsContainerSelect).SelectElement(element);
                this.m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, this.m_mapControl.ActiveView.Extent);
                this.UpdateNodeCheckState(treeListNode);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"错误信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Log.WriteLog(typeof(CmdToolReCorrect),ex);
            }
            
        }

        private System.Data.DataTable NewEmptyMap()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("旧值");
            dt.Columns.Add("新值");
            dt.Columns[0].DataType = dt.Columns[1].DataType = typeof(float);
            return dt;
        }

        private List<byte> GetBlockUniqueValue(IRasterLayer rasterLyr,IElement element)
        {
            //get top visable raster
            if (rasterLyr == null)
            {
                XtraMessageBox.Show("读取分类结果文件失败！");
                return null;
            }
            IRaster2 raster2 = rasterLyr.Raster as IRaster2;
            //element.Geometry.Project(rasterProps.SpatialReference);
            //if(element.Geometry.SpatialReference ==null)
            //    element.Geometry.SpatialReference = EnviVars.instance.MapControl.SpatialReference ;
            //element.Geometry.Project(rasterProps.SpatialReference);
            IRasterBandCollection rasterBandCollection = raster2.RasterDataset as IRasterBandCollection;
            IRasterBand rasterBand = rasterBandCollection.Item(0);
            IRawPixels rawPixels = rasterBand as IRawPixels;

            IPnt pixelBlockOrigin = new DblPntClass();
            IPnt pixelBlockSize = new DblPntClass();
            IPixelBlock3 pixelBlock3 = null;
            //calculate element column and row in raster
            int startColum, startRow, endColum, endRow = -1;
            IEnvelope envelope = element.Geometry.Envelope;
            //当前空间参考与栅格不一致时，重投影绘制坐标。
            IPoint upleft = new PointClass();
            IPoint lowright = new PointClass();
            ISpatialReference fromReference = EnviVars.instance.MapControl.Map.SpatialReference;
            ISpatialReference toReference = (raster2 as IGeoDataset).SpatialReference;
            upleft.X = envelope.XMin;
            upleft.Y = envelope.YMax;
            upleft.SpatialReference = fromReference;
            lowright.X = envelope.XMax;
            lowright.Y = envelope.YMin;
            lowright.SpatialReference = fromReference;
            if (!GFS.Common.EngineAPI.IsEqualSpatialReference(fromReference,toReference ))
            {
                upleft.Project(toReference);
                lowright.Project(toReference);
            }
            raster2.MapToPixel(upleft.X, upleft.Y, out startColum, out startRow);
            //raster2.MapToPixel(envelope.XMin, envelope.YMax, out startColum, out startRow);
            if (startColum < 0 && startRow < 0)
            {
                XtraMessageBox.Show("读取起始行列失败！");
                return null;
            }
            pixelBlockOrigin.SetCoords(startColum, startRow);
            raster2.MapToPixel(lowright.X, lowright.Y, out endColum, out endRow);
            //raster2.MapToPixel(envelope.XMax, envelope.YMin, out endColum, out endRow);
            if (endColum < 0 && endRow < 0)
            {
                XtraMessageBox.Show("读取起始行列失败！");
                return null;
            }
            pixelBlockSize.SetCoords(endColum - startColum + 1, endRow - startRow + 1);
            pixelBlock3 = rawPixels.CreatePixelBlock(pixelBlockSize) as IPixelBlock3;
            //read pixel
            rawPixels.Read(pixelBlockOrigin, pixelBlock3 as IPixelBlock);
            byte[,] pixelData = (byte[,])pixelBlock3.get_PixelDataByRef(0);
            //get unique value
            List<byte> uniqueValue = new List<byte>();
            foreach (byte value in pixelData)
            {
                if (!uniqueValue.Contains(value))
                    uniqueValue.Add(value);
            }
            //sort
            uniqueValue.Sort();
            return uniqueValue;
        }
        private void UpdateNodeCheckState(TreeListNode node)
        {
            //int num = 0;
            //foreach (TreeListNode treeListNode in node.ParentNode.Nodes)
            //{
            //    if (treeListNode.CheckState == System.Windows.Forms.CheckState.Checked)
            //    {
            //        num++;
            //    }
            //}
            //if (num == node.ParentNode.Nodes.Count)
            //{
            //    this.ROITreeList.SetNodeCheckState(node.ParentNode, System.Windows.Forms.CheckState.Checked, true);
            //}
            //else if (num == 0)
            //{
            //    this.ROITreeList.SetNodeCheckState(node.ParentNode, System.Windows.Forms.CheckState.Unchecked, true);
            //}
            //else
            //{
            //    this.ROITreeList.SetNodeCheckState(node.ParentNode, System.Windows.Forms.CheckState.Indeterminate);
            //}
        }
    }
}
