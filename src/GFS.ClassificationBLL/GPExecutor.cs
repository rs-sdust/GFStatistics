using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geometry;
using System.IO;
using GFS.Common;

namespace GFS.ClassificationBLL
{
    public class GPExecutor
    {
        private Geoprocessor m_gp = null;

        private string m_sTempPath = System.Windows.Forms.Application.StartupPath + "\\temp";

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
        /// 
        /// </summary>
        /// <param name="inFeaClass"></param>
        /// <param name="clipFeaClass"></param>
        /// <param name="outFeaClass"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public bool ExtractByMask(string inFeaClass, string clipFeaClass, string outFeaClass, out string sMsg)
        {
            sMsg = string.Empty;
			bool result;
			try
			{

            //Geoprocessor GP = new Geoprocessor();
            // GP.OverwriteOutput = true;     
            ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask MaskTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask();
            MaskTool.in_raster = inFeaClass;
            MaskTool.in_mask_data = clipFeaClass;
            MaskTool.out_raster = outFeaClass;
            //GP.Execute(MaskTool,null);
            //return true;
            IGeoProcessorResult geoProcessorResult = this.m_gp.Execute(MaskTool, null) as IGeoProcessorResult;
            sMsg += GetGPMessages(this.m_gp);
            if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
            {
                sMsg += "裁剪成功！";
                result = true;
            }
            else
            {
                sMsg += "裁剪失败！";
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
        /// 
        /// </summary>
        /// <param name="inFile"></param>
        /// <param name="outFileDialog"></param>
        /// <param name="outFile"></param>
        /// <param name="bands"></param>
        /// <param name="PixelType"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public bool Mosaic(string inFile, string outFileDialog, string outFile, int bands, string PixelType, out string sMsg)
        {
            sMsg = string.Empty;
            bool result;
            try
            {

                ESRI.ArcGIS.DataManagementTools.MosaicToNewRaster MosaicTool = new ESRI.ArcGIS.DataManagementTools.MosaicToNewRaster();
                MosaicTool.input_rasters = inFile;
                MosaicTool.output_location = outFileDialog;
                MosaicTool.raster_dataset_name_with_extension = outFile;
                // MosaicTool.coordinate_system_for_the_raster = " ";
                MosaicTool.pixel_type = PixelType;
                // MosaicTool.cellsize =30;
                MosaicTool.number_of_bands = bands;
                MosaicTool.mosaic_method = "LAST";
                MosaicTool.mosaic_colormap_mode = "FIRST";
                //GP.Execute(MaskTool,null);
                //return true;
                IGeoProcessorResult geoProcessorResult = this.m_gp.Execute(MosaicTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(this.m_gp);
                if (geoProcessorResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    sMsg += "拼接成功！";
                    result = true;
                }
                else
                {
                    sMsg += "拼接失败！";
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
       
//---------------code before this line nedds to be added to the new version----------------------------      
        
        /// <summary>
        /// create vector file by geometry
        /// </summary>
        /// <param name="geometry">based geometry</param>
        /// <param name="sShpFilePath">out vector file</param>
        /// <returns></returns>
        public bool CreateShpFile(IGeometry geometry, out string sShpFilePath)
        {
            string str = DateTime.Now.ToString().Replace(':', '-').Replace('/', '-').Replace(' ', '-');
            sShpFilePath = System.IO.Path.Combine(this.m_sTempPath, str + ".shp");
            if (!Directory.Exists(this.m_sTempPath))
            {
                Directory.CreateDirectory(this.m_sTempPath);
            }
            return EngineAPI.CreateShpFile(sShpFilePath, geometry);
        }



    }
}
