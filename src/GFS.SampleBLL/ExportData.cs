﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GFS.SampleBLL
{
    public class ExportData
    {
        public static string firstUnit;
        public static string secSample;
        public static string report;

        public static string Export(string toFolder)
        {
            string msg = "";
            try
            {
                if (string.IsNullOrEmpty(firstUnit))
                {
                    msg += "未指定一级抽样单元！";
                }
                else
                {
                    string toFile = Path.Combine(toFolder, "一级抽样单元.shp");
                    Common.CommonAPI.CopyShpFile(firstUnit, toFile);

                    string toXml = Path.Combine(toFolder, "一级抽样单元.xml");
                    string fsXml = report.Substring(0, firstUnit.LastIndexOf(".")) + ".xml";
                    File.Copy(fsXml, toXml, true);

                    msg +=  (Environment.NewLine + "导出一级抽样单元成功！");
                }
                if (string.IsNullOrEmpty(secSample))
                {
                    msg +=  (Environment.NewLine+"未指定二级样方！");
                }
                else
                {
                    string toFile = Path.Combine(toFolder, "二级样方.shp");
                    Common.CommonAPI.CopyShpFile(secSample, toFile);

                    string toXml = Path.Combine(toFolder, "二级样方.xml");
                    string fsXml = report.Substring(0, secSample.LastIndexOf(".")) + ".xml";
                    File.Copy(fsXml, toXml, true);

                    msg +=  (Environment.NewLine+"导出二级样方成功！");
                }
                if (string.IsNullOrEmpty(report))
                {
                    msg +=  (Environment.NewLine+"未指定估算结果！");
                }
                else
                {
                    string toFile = Path.Combine(toFolder, "估算结果.txt");
                    File.Copy(report, toFile, true);

                    string toXml = Path.Combine(toFolder, "二级样方.xml");
                    string fsXml = report.Substring(0, report.LastIndexOf(".")) + ".xml";
                    File.Copy(fsXml, toXml, true);

                    msg +=  (Environment.NewLine+"导出估算结果成功！");
                }
                return msg;
            }
            catch(Exception ex)
            {
                return msg + Environment.NewLine + ex.Message;
            }

        }
    }
}
