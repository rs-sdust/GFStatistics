// ***********************************************************************
// Assembly         : SDJT.System
// Author           : yxq
// Created          : 04-05-2016
//
// Last Modified By : yxq
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="MapAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.SystemUI;
//using SDJT.Log;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{

    /// <summary>
    /// Class MapAPI.
    /// </summary>
    public class MapAPI
    {
        //private static Logger _logger = new Logger();
        /// <summary>
        /// Opens the document.
        /// </summary>
        /// <param name="sMxdFilePath">The  MXD file path.</param>
        public static void OpenDocument(string sMxdFilePath)
        {          
            IMapDocument mapDocument = new MapDocumentClass();
            if (mapDocument.get_IsPresent(sMxdFilePath) && !mapDocument.get_IsPasswordProtected(sMxdFilePath))
            {
                mapDocument.Open(sMxdFilePath, "");
                try
                {
                    IMap map = mapDocument.get_Map(0);
                    mapDocument.SetActiveView((IActiveView)map);
                    //EnviVars.instance.Synchronizer.PageLayoutControl.PageLayout = mapDocument.PageLayout;
                    //EnviVars.instance.Synchronizer.ReplaceMap(map);
                    EnviVars.instance.MapControl.Map = map;
                    EnviVars.instance.MainForm.Text = sMxdFilePath;
                }
                catch (Exception ex)
                {
                    //_logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
                    Log.WriteLog(typeof(MapAPI), ex);
                }
                finally
                {
                    mapDocument.Close();
                }
            }
        }

        /// <summary>
        /// News the document.
        /// </summary>
        public static void NewDocument()
        {
            //(EnviVars.instance.PageLayoutControl.PageLayout as IGraphicsContainer).DeleteAllElements();
            EnviVars.instance.MapControl.ClearLayers();
            IMap map = new MapClass();
            map.Name = "图层";
            EnviVars.instance.MapControl.Map = map;
            //EnviVars.instance.Synchronizer.ReplaceMap(map);
        }

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="sMxdFilePath">The  MXD file path.</param>
        public static void SaveDocument(string sMxdFilePath)
        {
            if (!string.IsNullOrEmpty(sMxdFilePath) && EnviVars.instance.MapControl.CheckMxFile(sMxdFilePath))
            {
                IMapDocument mapDocument = new MapDocumentClass();
                mapDocument.Open(sMxdFilePath, "");
                mapDocument.ReplaceContents((IMxdContents)EnviVars.instance.PageLayoutControl.PageLayout);
                mapDocument.Save(mapDocument.UsesRelativePaths, true);
                mapDocument.Close();
            }
        }
        /// <summary>
        /// Determines whether [is exist element] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><c>true</c> if [is exist element] [the specified element]; otherwise, <c>false</c>.</returns>
        public static bool IsExistElement(IElement element)
        {
            bool result = false;
            IGraphicsContainer graphicsContainer = EnviVars.instance.MapControl.ActiveView.GraphicsContainer;
            graphicsContainer.Reset();
            IElement element2;
            while ((element2 = graphicsContainer.Next()) != null)
            {
                if (element2 == element)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Copies the and overwrite map.
        /// </summary>
        /// <param name="mapControl1">The map control1.</param>
        /// <param name="mapControl2">The map control2.</param>
        public static void CopyAndOverwriteMap(IMapControl4 mapControl1, IMapControl4 mapControl2)
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object focusMap = mapControl1.ActiveView.FocusMap;
            object pInObject = objectCopy.Copy(focusMap);
            object focusMap2 = mapControl2.ActiveView.FocusMap;
            objectCopy.Overwrite(pInObject, ref focusMap2);
        }

        /// <summary>
        /// Converts the pixels to map units.
        /// </summary>
        /// <param name="activeView">The active view.</param>
        /// <param name="targetSpatialRef">The target spatial reference.</param>
        /// <param name="pixelValue">The pixel value.</param>
        /// <param name="useWidth">if set to <c>true</c> [use width].</param>
        /// <returns>System.Double.</returns>
        public static double ConvertPixelsToMapUnits(IActiveView activeView, ISpatialReference targetSpatialRef, double pixelValue, bool useWidth = true)
        {
            double result;
            if (activeView == null)
            {
                result = 0.0;
            }
            else if (pixelValue == 0.0)
            {
                result = 0.0;
            }
            else if (targetSpatialRef is IUnknownCoordinateSystem)
            {
                result = 0.0;
            }
            else
            {
                IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation;
                IEnvelope visibleBounds = displayTransformation.VisibleBounds;
                visibleBounds.Project(targetSpatialRef);
                tagRECT deviceFrame = displayTransformation.get_DeviceFrame() ;
                double num;
                long num2;
                if (useWidth)
                {
                    num = visibleBounds.Width;
                    num2 = (long)(deviceFrame.right - deviceFrame.left);
                }
                else
                {
                    num = visibleBounds.Height;
                    num2 = (long)(deviceFrame.bottom - deviceFrame.top);
                }
                if (num == 0.0)
                {
                    result = 0.0;
                }
                else if (num2 == 0L)
                {
                    result = 0.0;
                }
                else
                {
                    double num3 = num / (double)num2;
                    result = pixelValue * num3;
                }
            }
            return result;
        }

        /// <summary>
        /// Saves the map document.
        /// </summary>
        /// <param name="mxdContents">The MXD contents.</param>
        /// <param name="sFilePath">The  file path.</param>
        /// <param name="bUseRelativePath">if set to <c>true</c> [b use relative path].</param>
        public static void SaveMapDocument(IMxdContents mxdContents, string sFilePath, bool bUseRelativePath = true)
        {
            IMapDocument mapDocument = new MapDocumentClass();
            try
            {
                mapDocument.New(sFilePath);
                mapDocument.ReplaceContents(mxdContents);
                mapDocument.Save(bUseRelativePath, true);
                EnviVars.instance.MapControl.DocumentFilename = sFilePath;
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
                Log.WriteLog(typeof(MapAPI), ex);
            }
            finally
            {
                EnviVars.instance.MainForm.Text = EnviVars.instance.MapControl.DocumentFilename;
                mapDocument.Close();
            }
        }

        //public static IFeatureClass CreateShpFile(string sFilePath, ISpatialReference spatialRef, esriGeometryType geoType, IFields fields = null)
        //{
        //    IWorkspace workspace = null;
        //    IFeatureClass result;
        //    try
        //    {
        //        string directoryName = System.IO.Path.GetDirectoryName(sFilePath);
        //        IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
        //        workspace = workspaceFactory.OpenFromFile(directoryName, 0);
        //        string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sFilePath);
        //        if (fields == null)
        //        {
        //            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
        //            fields = objectClassDescription.RequiredFields;
        //        }
        //        result = MapAPI.CreateFeatureClass(workspace, fileNameWithoutExtension, fields, spatialRef, geoType);
        //    }
        //    finally
        //    {
        //        if (workspace != null)
        //        {
        //            Marshal.ReleaseComObject(workspace);
        //        }
        //    }
        //    return result;
        //}

        //public static IFeatureClass CreateFeatureClass(IWorkspace workspace, string sName, IFields fields, ISpatialReference spatialRef, esriGeometryType geoType)
        //{
        //    string shapeFieldName = "";
        //    for (int i = 0; i < fields.FieldCount; i++)
        //    {
        //        IField field = fields.get_Field(i);
        //        if (field.Type == esriFieldType.esriFieldTypeGeometry)
        //        {
        //            shapeFieldName = field.Name;
        //            IGeometryDefEdit geometryDefEdit = field.GeometryDef as IGeometryDefEdit;
        //            geometryDefEdit.GeometryType_2 = geoType;
        //            geometryDefEdit.SpatialReference_2 = spatialRef;
        //            break;
        //        }
        //    }
        //    UID uID = new UIDClass();
        //    uID.Value = AEsfmperdx9c62xYL3139hcIxGve.AG5IDo6GN(vpC("ZQBzAHIAaQBHAGUAbwBEAGEAdABhAGIAYQBzAGUALgBGAGUAYQB0AHUAcgBlAA==");
        //    return (workspace as IFeatureWorkspace).CreateFeatureClass(sName, fields, uID, null, esriFeatureType.esriFTSimple, shapeFieldName, "");
        //}

        /// <summary>
        /// Converts the circular arc to polygon.
        /// </summary>
        /// <param name="circularArc">The circular arc.</param>
        /// <returns>IPolygon.</returns>
        public static IPolygon ConvertCircularArcToPolygon(ICircularArc circularArc)
        {
            ISegmentCollection segmentCollection = new RingClass();
            ISegmentCollection arg_2B_0 = segmentCollection;
            ISegment arg_2B_1 = circularArc as ISegment;
            object value = Missing.Value;
            object value2 = Missing.Value;
            arg_2B_0.AddSegment(arg_2B_1, ref value, ref value2);
            IRing ring = segmentCollection as IRing;
            ring.Close();
            IGeometryCollection geometryCollection = new PolygonClass();
            IGeometryCollection arg_5D_0 = geometryCollection;
            IGeometry arg_5D_1 = ring;
            value = Missing.Value;
            value2 = Missing.Value;
            arg_5D_0.AddGeometry(arg_5D_1, ref value, ref value2);
            return geometryCollection as IPolygon;
        }

        //private static void AA)0IeglO(jnL8A8o0(IPageLayoutControl3 pageLayoutControl, IMapControl4 mapControl)
        //{
        //    IMap map = null;
        //    if (pageLayoutControl != null)
        //    {
        //        map = pageLayoutControl.ActiveView.FocusMap;
        //        IPageLayout pageLayout = new PageLayoutClass();
        //        pageLayoutControl.PageLayout = pageLayout;
        //        pageLayoutControl.ActiveView.Refresh();
        //        IMaps maps = new Maps();
        //        maps.Add(map);
        //        pageLayoutControl.PageLayout.ReplaceMaps(maps);
        //        pageLayoutControl.ActiveView.ContentsChanged();
        //    }
        //    if (mapControl != null)
        //    {
        //        if (map == null)
        //        {
        //            map = new MapClass();
        //        }
        //        mapControl.Map = map;
        //        mapControl.ActiveView.Refresh();
        //    }
        //}

        /// <summary>
        /// Adds the style file.
        /// </summary>
        /// <param name="axSymbologyControl1">The ax symbology control1.</param>
        /// <param name="sDestPath">The s dest path.</param>
        public static void AddStyleFile(AxSymbologyControl axSymbologyControl1, string sDestPath)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.CheckPathExists = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "(style)|*.SeverStyle";
            if (openFileDialog.ShowDialog(EnviVars.instance.MainForm) == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                string text = System.IO.Path.Combine(sDestPath, fileName);
                axSymbologyControl1.Clear();
                if (File.Exists(text))
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName);
                    string[] files = Directory.GetFiles(sDestPath, fileNameWithoutExtension + "." + extension);
                    int num = 1;
                    string[] array = files;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string path = array[i];
                        string fileNameWithoutExtension2 = System.IO.Path.GetFileNameWithoutExtension(path);
                        int num2 = 0;
                        string text2 = fileNameWithoutExtension2.Substring(fileNameWithoutExtension.Length);
                        if (!string.IsNullOrEmpty(text2) && int.TryParse(text2, out num2) && num2 > num)
                        {
                            num = num2 + 1;
                        }
                    }
                    text = System.IO.Path.Combine(sDestPath, fileNameWithoutExtension + num + extension);
                }
                File.Copy(openFileDialog.FileName, text, true);
                axSymbologyControl1.LoadStyleFile(openFileDialog.FileName);
                axSymbologyControl1.Refresh();
            }
        }

        /// <summary>
        /// Initializes static members of the <see cref="MapAPI" /> class.
        /// </summary>
        static MapAPI()
        {
        }
    }
}
