// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Zhen LU
// Created          : 08-16-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-30-2017
// ***********************************************************************
// <copyright file="GPExecutor.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>All geoprocess funs</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using GFS.Common;
using System.IO;
using ESRI.ArcGIS.Geoprocessing;
using System.Data;
using ESRI.ArcGIS.SpatialAnalyst;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Geometry;
using DevExpress.Utils;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesFile;

namespace GFS.BLL
{
    public class GPExecutor:IDisposable
    {
        private Geoprocessor m_gp = null;

        public void Dispose()
        {
            m_gp = null;
        }
        public GPExecutor()
        {
            this.m_gp = new Geoprocessor() { OverwriteOutput = true };
            //Geoprocessor gp = new Geoprocessor() { OverwriteOutput = true };
        }
      
        private string GetGPMessages(Geoprocessor gp)
        {
            string text = string.Empty;
            if (gp.MessageCount > 0)
            {
                for (int i = 0; i < gp.MessageCount; i++)
                {
                    text = text + gp.GetMessage(i) + "\n";
                }
            }
            return text;
        }
        public bool ClipVector(string inFeaClass, string clipFeaClass, string outFeaClass, out string sMsg)
        {
            sMsg = string.Empty;
            bool result;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.AnalysisTools.Clip clip = new ESRI.ArcGIS.AnalysisTools.Clip();
                clip.in_features = inFeaClass;
                clip.clip_features = clipFeaClass;
                clip.out_feature_class = outFeaClass;
                //geoProcessorResult = this.m_gp.Execute(clip, null) as IGeoProcessorResult;
                //sMsg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(clip, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg += "裁切成功！";
                    result = true;
                }
                else
                {
                    sMsg += "裁切失败！";
                    result = false;
                }
            }
            catch (Exception ex)
            {
                sMsg = sMsg + "裁切失败：" + ex.Message;
                result = false;
            }
            finally
            {
                //Marshal.ReleaseComObject(geoProcessorResult);
            }
            return result;
        }
        public bool ClipRster(string in_raster, string inTemplateDataset, string in_rectangle, string out_raster, string clippingGeometry, out string sMsg)
        {
            sMsg = "";
            bool result;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                string directoryName = System.IO.Path.GetDirectoryName(out_raster);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                ESRI.ArcGIS.DataManagementTools.Clip clip = new ESRI.ArcGIS.DataManagementTools.Clip();
                clip.in_raster = in_raster;
                if (!string.IsNullOrEmpty(inTemplateDataset))
                {
                    clip.in_template_dataset = inTemplateDataset;
                    clip.clipping_geometry = clippingGeometry;
                    clip.rectangle = "#";
                }
                else
                {
                    clip.rectangle = in_rectangle;
                }
                clip.nodata_value = "256";
                clip.out_raster = out_raster;
                //geoProcessorResult = this.m_gp.Execute(clip, null) as IGeoProcessorResult;
                //sMsg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(clip, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg += "裁切文件成功！";
                    result = true;
                }
                else
                {
                    sMsg += "裁切文件失败！";
                    result = false;
                }
            }
            catch (Exception ex)
            {
                sMsg = sMsg + "裁切文件失败！原因是：" + ex.Message;
                result = false;
            }
            finally
            {
                //Marshal.ReleaseComObject(geoProcessorResult);
            }
            return result;
        }
        /// <summary>
        /// 影像裁剪工具
        /// </summary>
        /// <param name="inFeaClass">输入栅格</param>
        /// <param name="clipFeaClass">裁剪范围</param>
        /// <param name="outFeaClass">裁剪结果</param>
        /// <param name="sMsg">返回的结果信息</param>
        /// <returns></returns>
        public bool ExtractByMask(string inRaster, string clipFeaClass, string outFeaClass, out string sMsg)
        {
            sMsg = string.Empty;
			bool result;
            IGeoProcessorResult geoProcessorResult = null;
			try
			{
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask MaskTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask();
                MaskTool.in_raster = inRaster;
                MaskTool.in_mask_data = clipFeaClass;
                MaskTool.out_raster = outFeaClass;
                //geoProcessorResult = this.m_gp.Execute(MaskTool, null) as IGeoProcessorResult;
                //sMsg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(MaskTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg = "裁剪成功！\r\n" + sMsg;
                    result = true;
                }
                else
                {
                    sMsg = "裁剪失败！\r\n" + sMsg;
                    result = false;
                }
            }
            catch (Exception ex)
            {
                sMsg = sMsg + "抛出异常！" + ex.Message;
                result = false;
            }
            finally
            {
                //Marshal.ReleaseComObject(geoProcessorResult);
            }
            return result;
        }
       /// <summary>
       /// 影像的拼接工具
       /// </summary>
        /// <param name="inFile">输入拼接影像数据集</param>
       /// <param name="outFileDialog">输出位置</param>
        /// <param name="outFile">输出文件名</param>
        /// <param name="sMsg">返回的结果信息</param>
       /// <returns></returns>
        public bool Mosaic(string inFiles, string outPath, string outName, string pixelType,out string sMsg,int bandCount=1,string method = "LAST",string colorMap="FIRST")
        {
            sMsg = string.Empty;
            bool result;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {               
                ESRI.ArcGIS.DataManagementTools.MosaicToNewRaster MosaicTool = new ESRI.ArcGIS.DataManagementTools.MosaicToNewRaster();
                MosaicTool.input_rasters = inFiles;
                MosaicTool.output_location = outPath;
                MosaicTool.raster_dataset_name_with_extension = outName;
                // MosaicTool.coordinate_system_for_the_raster = " ";
                MosaicTool.pixel_type = pixelType;
                // MosaicTool.cellsize =30;
                MosaicTool.number_of_bands = bandCount;
                MosaicTool.mosaic_method = method;
                MosaicTool.mosaic_colormap_mode = colorMap;
                //geoProcessorResult = this.m_gp.Execute(MosaicTool, null) as IGeoProcessorResult;
                //sMsg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(MosaicTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg = "拼接成功！\r\n" + sMsg;
                    result = true;
                }
                else
                {
                    sMsg += "拼接失败！\r\n" + sMsg;
                    result = false;
                }
            }
            catch (Exception ex)
            {
                sMsg = sMsg + "抛出异常！" + ex.Message;
                result = false;
            }
            finally
            {
                //Marshal.ReleaseComObject(geoProcessorResult);
            }
            return result;
        }
        ///<summary>
        /// 区域像元值统计ZonalStatisticsAsTable
        /// 统计某范围内像元值
        /// 返回datatable
        /// </summary>
        /// <param name="inFile">输入shp文件名</param>
        /// <param name="inValueFile">要统计的栅格文件名</param>
        /// <param name="zoneField">区域字段，区分要统计的区域</param>
        /// <param name="statistisType">统计类型(保留字段)</param>
        public DataTable ZonalStatisticsAsTable(string inFile, string inValueFile, string zoneField, string statistisType=null)
        {
            IFeatureClass pFeatureClass = null;
            IRasterDataset pRasterDst = null;
            IZonalOp pZonalOp = null;
            ITable pResTable = null;
            try
            {
                pFeatureClass = EngineAPI.OpenFeatureClass(inFile);
                pRasterDst = EngineAPI.OpenRasterFile(inValueFile);
                pZonalOp = new RasterZonalOpClass();
                pResTable = pZonalOp.ZonalStatisticsAsTable((IGeoDataset)pFeatureClass, (IGeoDataset)pRasterDst, true);
                ITable pZoneTable = (ITable)pFeatureClass;
                TableConversion conver = new TableConversion();
                DataTable result = conver.AETableToDataTable(pResTable);
                DataTable zone = conver.AETableToDataTable(pZoneTable);
                result.Columns.Remove("Rowid");
                result.Columns.Remove("VALUE");
                //result.Columns.Remove("AREA");
                //result.Columns.RemoveAt(0);
                //result.Columns.RemoveAt(0);
                //result.Columns.RemoveAt(1);
                result.Columns.Add(zoneField);
                for (int i = 0; i < zone.Rows.Count; i++)
                {
                    if (i < result.Rows.Count)
                        result.Rows[i][zoneField] = zone.Rows[i][zoneField];
                }
                result.Columns[zoneField].SetOrdinal(0);
                return result;
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(GPExecutor), ex);
                return null;
            }
            finally
            {
                if (pFeatureClass != null)
                    Marshal.ReleaseComObject(pFeatureClass);
                if (pRasterDst != null)
                    Marshal.ReleaseComObject(pRasterDst);
                if (pZonalOp != null)
                    Marshal.ReleaseComObject(pZonalOp);
                if (pResTable != null)
                    Marshal.ReleaseComObject(pResTable);
            }
        }

        public bool ZonalStatistics(string inZone, string zoneField, string inValue,string staticType,string outFile, out string msg)
        {
            msg = string.Empty;
            bool result = true;
            //IGeoDataset geoDataSet = null;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.ZonalStatistics zonal = new ESRI.ArcGIS.SpatialAnalystTools.ZonalStatistics();
                zonal.in_zone_data = inZone;
                zonal.zone_field = zoneField;
                zonal.in_value_raster = inValue;
                zonal.statistics_type = staticType;
                zonal.out_raster = outFile;
                geoProcessorResult = m_gp.Execute(zonal, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                {
                    result = false;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Marshal.ReleaseComObject(geoProcessorResult);
            }
        }
        public bool SetNoData(string inRaster, int excludeValue,string outRaster,out string msg)
        {
            msg = string.Empty;
            bool result = true;
            //IGeoDataset geoDataSet = null;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.SetNull setNull = new ESRI.ArcGIS.SpatialAnalystTools.SetNull();
                //geoDataSet = EngineAPI.OpenRasterFile(inRaster) as IGeoDataset;
                setNull.in_conditional_raster = inRaster;
                setNull.in_false_raster_or_constant = inRaster;
                setNull.where_clause = "VALUE <> " + excludeValue;
                setNull.out_raster = outRaster;
                //geoProcessorResult = this.m_gp.Execute(setNull, null) as IGeoProcessorResult;
                //msg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(setNull, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                {
                    result = false;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Marshal.ReleaseComObject(geoProcessorResult);
            }
        }

        public IGeoDataset SetNull(string inRaster, int excludeValue)
        {
            IMapAlgebraOp pRSalgebra = null;
            IGeoDataset pGeoDataset = null;
            try
            {
                pGeoDataset = EngineAPI.OpenRasterFile(inRaster) as IGeoDataset;
                string expression = "SetNull([InRaster] != "+ excludeValue +",[InRaster])";
                pRSalgebra = new RasterMapAlgebraOpClass();
                pRSalgebra.BindRaster(pGeoDataset, "InRaster");
                IGeoDataset resDataset = pRSalgebra.Execute(expression);
                return resDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pRSalgebra != null)
                    Marshal.ReleaseComObject(pRSalgebra);
                if (pGeoDataset != null)
                    Marshal.ReleaseComObject(pGeoDataset);
            }
        }
        /// <summary>
        /// Reclassifies the specified raster.
        /// </summary>
        /// <param name="inRaster">The in raster.</param>
        /// <param name="outRaster">The out raster.</param>
        /// <param name="reMap">The remap.eg "old new;old new"</param>
        /// <param name="msg">The out MSG.</param>
        /// <param name="reField">The reclass field.</param>
        /// <param name="missingValue">The missing value.</param>
        /// <returns><c>true</c> succeed <c>false</c> failed</returns>
        public bool Reclassify(string inRaster,string outRaster,string reMap,out string msg,string reField = "VALUE",string missingValue = "NODATA")
        {
            msg = "";
            bool result = false;
            ESRI.ArcGIS.SpatialAnalystTools.Reclassify reClass = null;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                reClass = new ESRI.ArcGIS.SpatialAnalystTools.Reclassify();
                reClass.in_raster = inRaster;
                reClass.missing_values = missingValue;
                reClass.out_raster = outRaster;
                reClass.reclass_field = reField;
                reClass.remap = reMap;
                //geoProcessorResult = this.m_gp.Execute(reClass, null) as IGeoProcessorResult;
                //msg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(reClass, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                msg = "error!\r\n" + ex.Message;
                return false;
            }
            finally
            {
                //if (geoProcessorResult != null)
                //    Marshal.ReleaseComObject(geoProcessorResult);
            }
        }

        public bool RasterTable(string infile, out string sMsg)
        {
            sMsg = string.Empty;
            bool result;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.DataManagementTools.BuildRasterAttributeTable BuildRasterTable = new ESRI.ArcGIS.DataManagementTools.BuildRasterAttributeTable();
                BuildRasterTable.in_raster = infile;
                BuildRasterTable.overwrite = "Overwrite";
                //geoProcessorResult = this.m_gp.Execute(BuildRasterTable, null) as IGeoProcessorResult;
                //sMsg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(BuildRasterTable, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg = "创建成功！\r\n" + sMsg;
                    result = true;
                }
                else
                {
                    sMsg = "创建失败！\r\n" + sMsg;
                    result = false;
                }
            }
            catch (Exception ex)
            {
                sMsg = sMsg + "抛出异常！" + ex.Message;
                result = false;
            }
            finally
            {
                //if (geoProcessorResult != null)
                //    Marshal.ReleaseComObject(geoProcessorResult);
            }
            return result;
        }
        /// <summary>
        /// GP intersect
        /// </summary>
        /// <param name="inFiles">输入文件列表</param>
        /// <param name="outFile">输出文件名</param>
        public bool Intersect(string inFiles, string outFile, out string msg)
        {
            IGeoProcessorResult geoProcessorResult = null;
            msg = string.Empty;
            bool result = true;
            try
            {
                ESRI.ArcGIS.AnalysisTools.Intersect pIntersect = new ESRI.ArcGIS.AnalysisTools.Intersect();
                pIntersect.in_features = inFiles;
                pIntersect.join_attributes = "ALL";
                pIntersect.output_type = "INPUT";
                pIntersect.out_feature_class = outFile;
                
                //geoProcessorResult = this.m_gp.Execute(pIntersect, null) as IGeoProcessorResult;
                //msg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };

                //m_gp.Execute(pIntersect, null);
                geoProcessorResult = m_gp.Execute(pIntersect, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                //if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                //{
                //    result = false;
                //}
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("相交处理失败：\r\n" + ex.Message);
            }
            finally
            {
                //if (geoProcessorResult!=null)
                //    Marshal.ReleaseComObject(geoProcessorResult);
            }
        }
        public bool Raster2Polygon(string inRaster, string outShp, bool simplify, out string msg)
        {
            msg = string.Empty;
            bool result = true;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.ConversionTools.RasterToPolygon pR2P = new ESRI.ArcGIS.ConversionTools.RasterToPolygon();
                pR2P.in_raster = inRaster;
                pR2P.out_polygon_features = outShp;
                if (simplify)
                    pR2P.simplify = "SIMPLIFY";
                else
                    pR2P.simplify = "NO_SIMPLIFY";
                geoProcessorResult = m_gp.Execute(pR2P, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                {
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("栅格转矢量失败：\r\n" + ex.Message);
            }
            finally
            {
                if (geoProcessorResult != null)
                    Marshal.ReleaseComObject(geoProcessorResult);
            }
        }
        /// <summary>
        /// GP cal area
        /// </summary>
        /// <param name="inFile">输入shp</param>
        /// <param name="outFile">输出shp</param>
        public bool CalArea(string inFile, string outFile,out string msg)
        {
            msg = string.Empty;
            bool result = true;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                ESRI.ArcGIS.SpatialStatisticsTools.CalculateAreas pCalArea = new ESRI.ArcGIS.SpatialStatisticsTools.CalculateAreas();
                pCalArea.Input_Feature_Class = inFile;
                pCalArea.Output_Feature_Class = outFile;
                //this.m_gp.Execute(pCalArea, null);
                ////geoProcessorResult = this.m_gp.Execute(pCalArea, null) as IGeoProcessorResult;
                //msg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(pCalArea, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                {
                    result = false;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("统计面积失败：\r\n" + ex.Message);
            }
            finally
            {
                //if (geoProcessorResult != null)
                //    Marshal.ReleaseComObject(geoProcessorResult);
            }
        }

        public bool CreateShpFile(IGeometry geometry, out string sShpFilePath)
        {
            string str = DateTime.Now.ToString().Replace(':', '-').Replace('/', '-').Replace(' ', '-');
            sShpFilePath = System.IO.Path.Combine(ConstDef.PATH_TEMP, str + ".shp");
            if (!Directory.Exists(ConstDef.PATH_TEMP))
            {
                Directory.CreateDirectory(ConstDef.PATH_TEMP);
            }
            return EngineAPI.CreateShpFile(sShpFilePath, geometry);
        }
        public void CreatePyramid(List<string> rasterFiles)
        {
            frmWaitDialog frmWait = new frmWaitDialog("正在创建金字塔" + "......", "提示信息");
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                frmWait.Owner = EnviVars.instance.MainForm;
                frmWait.TopMost = false;
                //if (this._geoProcessor == null)
                //{
                //    this._geoProcessor = new Geoprocessor();
                //    this._geoProcessor.OverwriteOutput = true;
                //}
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };

                string sMsg = string.Empty;
                if (rasterFiles.Count == 1)
                {
                    BuildPyramids buildPyramids = new BuildPyramids();
                    buildPyramids.in_raster_dataset = rasterFiles[0];
                    buildPyramids.resample_technique = "NEAREST";
                    buildPyramids.compression_type = "DEFAULT";
                    buildPyramids.compression_quality = 75;
                    //geoProcessorResult = this.m_gp.Execute(buildPyramids, null) as IGeoProcessorResult;
                    geoProcessorResult = m_gp.Execute(buildPyramids, null) as IGeoProcessorResult;

                }
                else
                {
                    BatchBuildPyramids batchBuildPyramids = new BatchBuildPyramids();
                    batchBuildPyramids.Input_Raster_Datasets = string.Join(";", rasterFiles);
                    batchBuildPyramids.Pyramid_resampling_technique = "NEAREST";
                    batchBuildPyramids.Pyramid_compression_type = "DEFAULT";
                    batchBuildPyramids.Compression_quality = 75;
                    //geoProcessorResult = this.m_gp.Execute(batchBuildPyramids, null) as IGeoProcessorResult;
                    geoProcessorResult = m_gp.Execute(batchBuildPyramids, null) as IGeoProcessorResult;
                }
                if (geoProcessorResult.Status != esriJobStatus.esriJobSucceeded)
                {
                    //sMsg += GetGPMessages(this.m_gp);
                    sMsg += GetGPMessages(m_gp);
                    BLL.Log.WriteLog(typeof(MapAPI), sMsg);
                }
                //logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
            }
            catch (Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                BLL.Log.WriteLog(typeof(MapAPI), ex);
            }
            finally
            {
                frmWait.Close();
            }
        }

        public bool CreateFishNet(string inExtent,int width,int height,string outFishnet, out string msg)
        {
            msg =string.Empty;
            bool result = true;
            ESRI.ArcGIS.DataManagementTools.CreateFishnet fishNet = null;
            IFeatureClass pfeatureClass = null;
            IGeoProcessorResult geoProcessorResult = null;
            try
            {
                pfeatureClass = EngineAPI.OpenFeatureClass(inExtent);
                IEnvelope extent = (pfeatureClass as IGeoDataset).Extent;
                fishNet = new CreateFishnet();
                fishNet.template = extent;
                fishNet.cell_width = width;
                fishNet.cell_height = height;
                fishNet.number_columns = 0;
                fishNet.number_rows = 0;
                fishNet.origin_coord = extent.XMin + " " + extent.YMin;
                fishNet.y_axis_coord = extent.XMin+ " " + extent.YMax;
                fishNet.out_feature_class = outFishnet;
                fishNet.geometry_type = "POLYGON";
                fishNet.labels = "NO_LABELS";
                //geoProcessorResult = this.m_gp.Execute(fishNet, null) as IGeoProcessorResult;
                //msg += GetGPMessages(this.m_gp);
                //Geoprocessor m_gp = new Geoprocessor() { OverwriteOutput = true };
                geoProcessorResult = m_gp.Execute(fishNet, null) as IGeoProcessorResult;
                msg += GetGPMessages(m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception ex )
            {
                throw ex;
            }
            finally
            {
                if (pfeatureClass != null)
                    Marshal.ReleaseComObject(pfeatureClass);
                //if (geoProcessorResult != null)
                //    Marshal.ReleaseComObject(geoProcessorResult);
            }
        }

        public void CreateFishNet(string inTemplate, int width, int height, string outFishNet)
        {
            IFeatureClass inFeatureClass = null;
            IFeatureClass outFeatureClass =null;
            ISpatialReference spatialReference = null;
            IEnvelope extent = null;
            try
            {
                inFeatureClass = EngineAPI.OpenFeatureClass(inTemplate);
                extent = (inFeatureClass as IGeoDataset).Extent;
                spatialReference = extent.SpatialReference;
                double extentW = extent.Width;
                double extentH = extent.Height;
                double extenXmin = extent.XMin;
                double extenYmin = extent.YMin;
                if (!CreateShpFile(outFishNet, spatialReference))
                {
                    throw new Exception("创建矢量文件失败！");
                }
                outFeatureClass = EngineAPI.OpenFeatureClass(outFishNet);
                int columCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(extentW / width)));
                int rowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(extentH / height)));
                for (int i = 0; i < rowCount * columCount; i++)
                {
                    int row = i / columCount;
                    int col = i % columCount;

                    IEnvelope rect = new EnvelopeClass();
                    rect.SpatialReference = spatialReference;
                    rect.XMin = extenXmin + col * width;
                    rect.XMax = rect.XMin + width;
                    rect.YMin = extenYmin + row * height;
                    rect.YMax = rect.YMin + height;
                    IElement ele = new RectangleElementClass
                    {
                        Geometry = rect
                    };

                    IFeature pFeature = outFeatureClass.CreateFeature();
                    pFeature.Shape = ele.Geometry;
                   
                    pFeature.Store();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (spatialReference != null)
                    Marshal.ReleaseComObject(spatialReference);
                if (extent != null)
                    Marshal.ReleaseComObject(extent);
                if (inFeatureClass != null)
                    Marshal.ReleaseComObject(inFeatureClass);
                if (outFeatureClass != null)
                    Marshal.ReleaseComObject(outFeatureClass);
            }
 
        }

        private static bool CreateShpFile(string shpPath, ISpatialReference spatialReference)
        {
            bool result = true;
            IWorkspaceFactory2 workspaceFactory = null;
            IWorkspace workspace = null;
            IFeatureClass featureClass = null;
            try
            {
                FileInfo info = new FileInfo(shpPath);
                string directory = info.DirectoryName;
                string name = info.Name.Substring(0, info.Name.Length - info.Extension.Length);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                workspaceFactory = new ShapefileWorkspaceFactoryClass();
                workspace = workspaceFactory.OpenFromFile(directory, 0);

                if (workspace == null)
                {
                    result = false;
                }
                else
                {
                    if (EngineAPI.IsNameExist(workspace, name, esriDatasetType.esriDTFeatureClass))
                    {
                        EngineAPI.DeleteDataset(workspace, name, esriDatasetType.esriDTFeatureClass);
                    }
                    IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
                    IFields requiredFields = objectClassDescription.RequiredFields;
                    if (requiredFields == null)
                        result = false;
                    featureClass = CreateFeatureClass(workspace, name, requiredFields, spatialReference);
                    if (featureClass == null)
                        result = false;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (featureClass != null)
                    Marshal.ReleaseComObject(featureClass);
                if (workspace != null)
                    Marshal.ReleaseComObject(workspace);
                if (workspaceFactory != null)
                    Marshal.ReleaseComObject(workspaceFactory);
            }

        }

        private static IFeatureClass CreateFeatureClass(IWorkspace workspace, string sName, IFields fields, ISpatialReference spatialRef)
        {
            return MapAPI.CreateFeatureClass(workspace, sName, fields, spatialRef, esriGeometryType.esriGeometryPolygon);
        }

        ///<summary>
        /// 获取shp字段列表
        /// </summary>
        /// <param name="inFile">输入shp文件名</param>
        /// <param name="fields">字段列表</param>
        public void GetFields(string inFile, List<string> fields)
        {

            IFeatureClass featureClass = null;
            try
            {
                featureClass = EngineAPI.OpenFeatureClass(inFile);
                int nFields = featureClass.Fields.FieldCount;
                for (int i = 0; i < nFields; i++)
                {
                    string name = featureClass.Fields.get_Field(i).Name;
                    fields.Add(name);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (featureClass != null)
                    Marshal.ReleaseComObject(featureClass);
            }



        }
    }
}
