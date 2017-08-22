using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;

namespace GFS.Test
{
    public class GP
    {
        private Geoprocessor _gp = null;

        public GP()
        {
            this._gp = new Geoprocessor();
            this._gp.OverwriteOutput = true;
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
        public bool ExtractByMask(string inFeaClass, string clipFeaClass, string outFeaClass, out string sMsg)
        {
            sMsg = string.Empty;
            bool result;
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask MaskTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask();
                MaskTool.in_raster = inFeaClass;
                MaskTool.in_mask_data = clipFeaClass;
                MaskTool.out_raster = outFeaClass;
                //GP.Execute(MaskTool,null);
                //return true;
                IGeoProcessorResult geoProcessorResult = this._gp.Execute(MaskTool, null) as IGeoProcessorResult;
                sMsg += GetGPMessages(this._gp);
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
    }
}
