// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-21-2017
// ***********************************************************************
// <copyright file="MapAPI.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>funs access to map</summary>
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
using ESRI.ArcGIS.DataSourcesRaster;
using GFS.Common;
using DevExpress.Utils;
using ESRI.ArcGIS.DataManagementTools;
using System.Collections;
//using SDJT.Log;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{
    public class MapAPI
    {
        /// <summary>
        /// Opens mxd document.
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
        /// New mxd document.
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
        /// Saves mxd document.
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
        /// Determines whether the specified element exists
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
        /// Copy and overwrite map in eagle eye.
        /// </summary>
        /// <param name="mapControl1">main map control.</param>
        /// <param name="mapControl2">eagleEye map control2.</param>
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

        /// <summary>
        /// Creates the feature class.
        /// </summary>
        /// <param name="workspace">The workspace.</param>
        /// <param name="sName">Name of the file.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="spatialRef">The spatial reference.</param>
        /// <param name="geoType">featureclass type.</param>
        /// <returns>IFeatureClass.</returns>
        public static IFeatureClass CreateFeatureClass(IWorkspace workspace, string sName, IFields fields, ISpatialReference spatialRef, esriGeometryType geoType)
        {
            string shapeFieldName = "";
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field.Type == esriFieldType.esriFieldTypeGeometry)
                {
                    shapeFieldName = field.Name;
                    IGeometryDefEdit geometryDefEdit = field.GeometryDef as IGeometryDefEdit;
                    geometryDefEdit.GeometryType_2 = geoType;
                    geometryDefEdit.SpatialReference_2 = spatialRef;
                    break;
                }
            } 
            UID uID = new UIDClass();
            uID.Value = "esriGeoDatabase.Feature";
            return (workspace as IFeatureWorkspace).CreateFeatureClass(sName, fields, uID, null, esriFeatureType.esriFTSimple, shapeFieldName, "");
        }

        /// <summary>
        /// Converts the ICircularArc to polygon.
        /// </summary>
        /// <param name="circularArc">The circulararc.</param>
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
     
        /// <summary>
        /// Add the style file.
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
        /// Read the band and pixelType information.
        /// </summary>
        /// <param name="rasterFile">The raster file.</param>
        /// <param name="bandCount">The band count.</param>
        /// <param name="pixelType">Type of the pixel.</param>
        /// <returns><c>true</c> succeed, <c>false</c> failed.</returns>
        public static bool ReadBandAndPixelInfo(string rasterFile,out int bandCount,out string pixelType)
        {
            IRasterLayer pRasterLayer=null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(rasterFile);
                bandCount = pRasterLayer.BandCount;
                IRaster pRaster = pRasterLayer.Raster;
                IRasterProps pRasterProps = pRaster as IRasterProps;
                pixelType = MapAPI.GetPixelType(pRasterProps);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取栅格元数据失败！请检查文件是否损坏：" + rasterFile, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(MapAPI), ex);
                bandCount = -1;
                pixelType = string.Empty; 
                return false;
            }
            finally
            {
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }

        /// <summary>
        /// Ges the type of the pixel.
        /// </summary>
        /// <param name="rasterProps">The rasterprops.</param>
        /// <returns>System.String.</returns>
        private static string GetPixelType(IRasterProps rasterProps)
        {
            string result = "";
            switch (rasterProps.PixelType)
            {
                case rstPixelType.PT_U1:
                    result = "1_BIT";
                    break;
                case rstPixelType.PT_U2:
                    result = "2_BIT";
                    break;
                case rstPixelType.PT_U4:
                    result = "4_BIT";
                    break;
                case rstPixelType.PT_UCHAR:
                    result = "8_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_CHAR:
                    result = "8_BIT_SIGNED";
                    break;
                case rstPixelType.PT_USHORT:
                    result = "16_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_SHORT:
                    result = "16_BIT_SIGNED";
                    break;
                case rstPixelType.PT_ULONG:
                    result = "32_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_LONG:
                    result = "32_BIT_SIGNED";
                    break;
                case rstPixelType.PT_FLOAT:
                    result = "32_BIT_FLOAT";
                    break;
                case rstPixelType.PT_DOUBLE:
                    result = "64_BIT";
                    break;
            }
            return result;
        }

        public static string PixelType2NetType(rstPixelType pixelType)
        {
            string result = "";
            switch (pixelType)
            {
                case rstPixelType.PT_U1:
                    result = "1_BIT";
                    break;
                case rstPixelType.PT_U2:
                    result = "2_BIT";
                    break;
                case rstPixelType.PT_U4:
                    result = "4_BIT";
                    break;
                case rstPixelType.PT_UCHAR:
                    result = "8_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_CHAR:
                    result = "8_BIT_SIGNED";
                    break;
                case rstPixelType.PT_USHORT:
                    result = "16_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_SHORT:
                    result = "16_BIT_SIGNED";
                    break;
                case rstPixelType.PT_ULONG:
                    result = "32_BIT_UNSIGNED";
                    break;
                case rstPixelType.PT_LONG:
                    result = "32_BIT_SIGNED";
                    break;
                case rstPixelType.PT_FLOAT:
                    result = "32_BIT_FLOAT";
                    break;
                case rstPixelType.PT_DOUBLE:
                    result = "64_BIT";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Get all layers.
        /// </summary>
        /// <param name="cmbRaster">The CMB raster.</param>
        /// <param name="cmbFeature">The CMB feature.</param>
        public static void GetAllLayers(ComboBoxEdit cmbRaster, ComboBoxEdit cmbFeature)
        {
            try
            {
                List<ILayer> layers = EngineAPI.GetLayers(EnviVars.instance.MapControl.ActiveView.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
                int i = 0;
                while (i < layers.Count)
                {
                    ILayer lyr = layers[i];
                    if (lyr is IRasterLayer)
                    {
                        if (cmbRaster != null)
                        {
                            IRasterLayer rasterLyr = lyr as IRasterLayer;
                            cmbRaster.Properties.Items.Add(rasterLyr.FilePath);
                        }
                    }
                    if (lyr is IFeatureLayer)
                    {
                        if (cmbFeature != null)
                        {
                            IFeatureClass featureClass = (lyr as IFeatureLayer).FeatureClass;
                            if (featureClass != null)
                            {
                                string shpFile = System.IO.Path.Combine((featureClass as IDataset).Workspace.PathName, (featureClass as IDataset).Name + ".shp");
                                cmbFeature.Properties.Items.Add(shpFile);
                            }
                        }
                    }
                    i++;
                }
            }
            catch (Exception)
            { }
        }
        public static IRasterLayer GetTopVisableRaster()
        {
            IRasterLayer rasterLyr = null;
            try
            {
                List<ILayer> layers = EngineAPI.GetLayers(EnviVars.instance.MapControl.ActiveView.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
                int i = layers.Count;
                while (i > 0)
                {
                    ILayer lyr = layers[i-1];
                    if (lyr is IRasterLayer)
                    {
                        if (lyr.Visible)
                        {
                            rasterLyr = lyr as IRasterLayer;
                        }
                    }
                    i--;
                }
                return rasterLyr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 加载矢量文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        public static void AddShpFileToMap(string filePath)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(filePath);
                string path = filePath.Substring(0, filePath.Length - fileinfo.Name.Length);
                string filename = fileinfo.Name;
                EnviVars.instance.MapControl.AddShapeFile(path, filename);
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(MapAPI), ex);
                throw ex;
            }
        }

        /// <summary>
        /// 加载栅格文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        public static void AddRasterFileToMap(string rasterPath)
        {
            try
            {
                IRasterLayer rasterLayer = new RasterLayerClass();
                string directoryName = System.IO.Path.GetDirectoryName(rasterPath);
                string fileName = System.IO.Path.GetFileName(rasterPath);
                IRasterWorkspace rasterWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.raster) as IRasterWorkspace;
                IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                rasterLayer.CreateFromDataset(rasterDataset);
                IRasterPyramid3 rasterPyramid = rasterDataset as IRasterPyramid3;
                if (rasterPyramid != null && !rasterPyramid.Present)
                {
                    //new frmCreatePyramid(new List<string>
                    //{
                    //    rasterLayer.FilePath
                    //})
                    //{
                    //    Owner = EnviVars.instance.MainForm
                    //}.ShowDialog();
                    //using (GPExecutor gp = new GPExecutor())
                    {
                        EnviVars.instance.GpExecutor.CreatePyramid(new List<string>
                    {
                        rasterLayer.FilePath
                    });
                    }
                }
                EnviVars.instance.MapControl.AddLayer(rasterLayer, 0);
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("加载数据失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(MapAPI), ex);
                throw ex;
            }
        }

        public static void UniqueValueRender(IFeatureLayer pFLayer, string fieldName)
        {
            IUniqueValueRenderer uniqueValueRenderer = new UniqueValueRenderer();
            uniqueValueRenderer.FieldCount = 1;
            uniqueValueRenderer.set_Field(0, fieldName);

            List<string> uniqueValues = GetLayerUniqueFieldValue(pFLayer, fieldName);
            Random rand = new Random();
            foreach (string value in uniqueValues)
            {
                IFillSymbol fillSymbol = new SimpleFillSymbol();
                fillSymbol.Color = new RgbColor() { Red = rand.Next(0, 255), Green = rand.Next(0, 255), Blue = rand.Next(0, 255) };
                uniqueValueRenderer.AddValue(value, "", (ISymbol)fillSymbol);
            }
            
            var featureRenderer = (IFeatureRenderer)uniqueValueRenderer;
            var geoFeatureLayer = (IGeoFeatureLayer)pFLayer;
            geoFeatureLayer.Renderer = featureRenderer;
        }
        public static List<string> GetLayerUniqueFieldValue(IFeatureLayer pFeatureLayer, string fieldName)
        {
            List<string> arrValues = new List<string>();
            IQueryFilter pQueryFilter = new QueryFilterClass();
            IFeatureCursor pFeatureCursor = null;

            pQueryFilter.SubFields = fieldName;
            pFeatureCursor = pFeatureLayer.FeatureClass.Search(pQueryFilter, true);

            IDataStatistics pDataStati = new DataStatisticsClass();
            pDataStati.Field = fieldName;
            pDataStati.Cursor = (ICursor)pFeatureCursor;

            IEnumerator pEnumerator = pDataStati.UniqueValues;
            pEnumerator.Reset();
            while (pEnumerator.MoveNext())
            {
                object pObj = pEnumerator.Current;
                arrValues.Add(pObj.ToString());
            }
            if (pQueryFilter!=null)
            Marshal.ReleaseComObject(pQueryFilter);
            if (pFeatureCursor != null)
            Marshal.ReleaseComObject(pFeatureCursor);
            arrValues.Sort();
            return arrValues;
        }
        /// <summary>
        /// Initializes static members of the <see cref="MapAPI" /> class.
        /// </summary>
        static MapAPI()
        {
        }
    }
}
