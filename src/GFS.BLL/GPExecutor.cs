// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Zhen LU
// Created          : 08-16-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
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

namespace GFS.BLL
{
    public class GPExecutor
    {
        private Geoprocessor m_gp = null;

        public GPExecutor()
        {
            this.m_gp = new Geoprocessor();
            this.m_gp.OverwriteOutput = true;
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
			try
			{
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask MaskTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask();
                MaskTool.in_raster = inRaster;
                MaskTool.in_mask_data = clipFeaClass;
                MaskTool.out_raster = outFeaClass;
                IGeoProcessorResult geoProcessorResult = this.m_gp.Execute(MaskTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(this.m_gp);
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
                IGeoProcessorResult geoProcessorResult = this.m_gp.Execute(MosaicTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(this.m_gp);
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
                result.Columns.Remove("AREA");
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
    
    }
}
