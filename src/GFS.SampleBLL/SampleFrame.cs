// ***********************************************************************
// Assembly         : GFS.SampleBLL
// Author           : Ricker Yan
// Created          : 09-22-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 10-12-2017
// ***********************************************************************
// <copyright file="SampleFrame.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>构建抽样框</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using GFS.BLL;
using System.Data;

/// <summary>
/// The SampleBLL namespace.
/// </summary>
namespace GFS.SampleBLL
{
    /// <summary>
    /// Class SampleData.
    /// </summary>
    public class SampleData
    {
        /// <summary>
        /// 一级抽样单元文件
        /// </summary>
        public static string firstUnit = string.Empty;
        /// <summary>
        /// 一级样本
        /// </summary>
        public static string firstSample = string.Empty;
        /// <summary>
        /// 耕地矢量文件
        /// </summary>
        public static string farmLand = string.Empty;
        /// <summary>
        /// 分类文件
        /// </summary>
        public static string ASCDL = string.Empty;
        //----------------------------------------------------------
        /// <summary>
        /// 是否包含耕地面积字段
        /// </summary>
        public static bool hasArea = false;
        /// <summary>
        /// 耕地面积字段名称
        /// </summary>
        public static string areaField = string.Empty;
        /// <summary>
        /// 村名字段
        /// </summary>
        public static string villageField = string.Empty;
        /// <summary>
        /// 分层字段
        /// </summary>
        public static string layerField = string.Empty;
        /// <summary>
        /// 读取的类别列表
        /// </summary>
        public static List<string> classNames = new List<string>();
        /// <summary>
        /// 目标作物id
        /// </summary>
        public static int targetCrop = -1;
    }
    /// <summary>
    /// Class SampleFrame.
    /// </summary>
    public class SampleFrame
    {
        //private GPExecutor _gp = new GPExecutor();
        /// <summary>
        /// Gets the class name from HDR.
        /// </summary>
        /// <param name="hdrFile">The HDR file.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="System.Exception">读取头文件失败：未检索到类名！</exception>
        public static List<string> GetClassFromHdr(string hdrFile)
        {
            List<string> classNames = null;
            StreamReader sr = new StreamReader(hdrFile, Encoding.Default);
            try
            {
                int startLine = 0;
                int endLine = 0;
                string strAll = sr.ReadToEnd();
                string[] lines = strAll.Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("class names"))
                    {
                        startLine = i+1;
                    }
                    if (lines[i].StartsWith("byte order"))
                    {
                        endLine = i ;
                    }
                }
                if (startLine == 0 || endLine == 0 || startLine > endLine)
                {
                    throw new Exception("读取头文件失败：未检索到类名！");
                }
                string strClass = string.Empty;
                for(int i = startLine;i<endLine;i++)
                {
                    strClass += lines[i];
                }
                strClass = strClass.TrimEnd('}');
                string[] arrClass = strClass.Split(',');
                classNames = new List<string>(arrClass);
                for (int i = 0; i < classNames.Count; i++)
                {
                    int index = classNames[i].IndexOf(" [");
                    if(index <0)
                        continue;
                    classNames[i] = classNames[i].Substring(0, index).Trim();
                }
                
                return classNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
        }

        /// <summary>
        /// Gets the class value from raster.
        /// </summary>
        /// <param name="inFile">The in file.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="System.Exception">文件类型不正确，请选择分类结果文件！</exception>
        public static List<string> GetClassFromRaster(string inFile)
        {
            IRasterLayer pRasterLayer = null;
            IUniqueValues pUniqueValues = null;
            IRasterCalcUniqueValues pCalcUniqueValues = null;
            List<string> classNames = null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(inFile);
                if (!(1 == pRasterLayer.BandCount))
                {
                    throw new Exception("文件类型不正确，请选择分类结果文件！");
                }
                pUniqueValues = new UniqueValuesClass();
                pCalcUniqueValues = new RasterCalcUniqueValuesClass();
                pCalcUniqueValues.AddFromRaster(pRasterLayer.Raster, 0, pUniqueValues);
                classNames = new List<string>();
                for (int i = 0; i < pUniqueValues.Count; i++)
                {
                    classNames.Add(pUniqueValues.get_UniqueValue(i).ToString());
                }
                return classNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pCalcUniqueValues != null)
                    Marshal.ReleaseComObject(pCalcUniqueValues);
                if (pUniqueValues != null)
                    Marshal.ReleaseComObject(pUniqueValues);
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }

        /// <summary>
        /// Ceck the data.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public  bool ChkData(out string msg)
        {
            msg =string.Empty;
            //firstunit
            if (string.IsNullOrEmpty(SampleData.firstUnit))
            {
                msg = "抽样单元为空！";
                return false;
            }
            //framland
            if (SampleData.hasArea == true)
            {
                if (string.IsNullOrEmpty(SampleData.areaField))
                {
                    msg = "面积字段为空！";
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(SampleData.farmLand))
                {
                    msg = "耕地矢量为空！";
                    return false;
                }
            }
            //ascdl
            if (string.IsNullOrEmpty(SampleData.ASCDL))
            {
                msg = "ASCDL为空！";
                return false;
            }
            else
            {
                if (SampleData.targetCrop<0)
                {
                    msg = "目标作物为空！";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calculate the land area.
        /// </summary>
        /// <param name="unitFile">The unit file.</param>
        /// <param name="framLand">The fram land.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public  bool CalLandArea(string unitFile,string framLand,out string msg)
        {
            IFeatureClass pUnitFeatureClass = null;
            IFeatureClass pAreaFeatureClass = null;
            ITable pUnitTable = null;
            ITable pAreaTable = null;
            try
            {
                msg = string.Empty;
                //相交处理
                string interFile = Path.Combine(GFS.BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                //if (!GFS.BLL.EnviVars.instance.GpExecutor.Intersect(unitFile + ";" + framLand, interFile, out msg))
                //    return false;
                EnviVars.instance.GpExecutor.Intersect(unitFile + ";" + framLand, interFile, out msg);
                //重算面积
                string areaFile = Path.Combine(GFS.BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                if (!EnviVars.instance.GpExecutor.CalArea(interFile, areaFile, out msg))
                    return false;
                pUnitFeatureClass = EngineAPI.OpenFeatureClass(unitFile);
                if (pUnitFeatureClass == null)
                {
                    msg = "打开抽样单元失败！";
                    return false;
                }
                pAreaFeatureClass = EngineAPI.OpenFeatureClass(areaFile);
                if (pAreaFeatureClass == null)
                {
                    msg = "打开耕地面积矢量失败！";
                    return false;
                }
                ITableConversion conver = new TableConversion();
                DataTable areaDT = conver.AETableToDataTable(pAreaFeatureClass);
                Summarize sum = new Summarize(areaDT);
                DataTable sumDT = sum.Sum(areaDT.Columns.IndexOf("F_AREA"), areaDT.Columns.IndexOf(SampleData.villageField));

                pUnitTable = pUnitFeatureClass as ITable;
                //pAreaTable = pAreaFeatureClass as ITable;
                string fName = "GDMJ";
                if (pUnitTable.FindField(fName) < 0)
                {
                    IField areaField = new FieldClass();
                    IFieldEdit fieldEdit = areaField as IFieldEdit;
                    fieldEdit.Name_2 = fName;
                    fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                    pUnitTable.AddField(areaField);
                }
                //int unitRows = pUnitTable.RowCount(null);
                //int areaRows = pAreaTable.RowCount(null);
                int unitNameIndex = pUnitTable.FindField(SampleData.villageField);
                //int areaNameIndex = pAreaTable.FindField(SampleData.villageField);
                int unitAreaIndex = pUnitTable.FindField(fName);
                //int areaIndex = pAreaTable.FindField("F_AREA");

                ICursor pUnitCursor = pUnitTable.Update(null, false);

                IRow unitRow = null;
                while ((unitRow = pUnitCursor.NextRow()) != null)
                {
                    string unitFid = unitRow.get_Value(unitNameIndex).ToString();
                    foreach (DataRow sumRow in sumDT.Rows)
                    {
                        if (unitFid == sumRow[0].ToString())
                        {
                            unitRow.set_Value(unitAreaIndex, sumRow[1]);
                            pUnitCursor.UpdateRow(unitRow);
                        }
                    }
                    //IRow areaRow = null;
                    //double unitArea = 0.0;
                    //ICursor pAreaCursor = pAreaTable.Update(null, false);
                    //while ((areaRow = pAreaCursor.NextRow()) != null)
                    //{
                    //    string areaFid = areaRow.get_Value(areaNameIndex).ToString();
                    //    if (unitFid == areaFid)
                    //    {
                    //        unitArea += (double)areaRow.get_Value(areaIndex);
                    //        unitRow.set_Value(unitAreaIndex, unitArea);
                    //        pUnitCursor.UpdateRow(unitRow);  
                    //    }
                    //}
                    //Marshal.ReleaseComObject(pAreaCursor);
                }
                if (pUnitCursor != null)
                Marshal.ReleaseComObject(pUnitCursor);
                //for循环效率较低改用ICursor遍历
                //for (int i = 0; i < unitRows; i++)
                //{
                //    IRow unitRow = pUnitTable.GetRow(i);
                //    string unitFid = unitRow.get_Value(unitNameIndex).ToString();
                //    for (int j = 0; j < areaRows; j++)
                //    {
                //        IRow areaRow = pAreaTable.GetRow(j);
                //        string areaFid = areaRow.get_Value(areaNameIndex).ToString();
                //        if (unitFid == areaFid)
                //        {
                //            object value = areaRow.get_Value(areaIndex);
                //            unitRow.set_Value(unitAreaIndex, value);
                //            unitRow.Store();
                //        }
                //    }
                //}
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pUnitFeatureClass != null)
                    Marshal.ReleaseComObject(pUnitFeatureClass);
                if (pAreaFeatureClass != null)
                    Marshal.ReleaseComObject(pAreaFeatureClass);
                if (pUnitTable != null)
                    Marshal.ReleaseComObject(pUnitTable);
                if (pAreaTable != null)
                    Marshal.ReleaseComObject(pAreaTable);
            }


        }

        /// <summary>
        /// Calculate the class area.
        /// </summary>
        /// <param name="unitFile">The unit file.</param>
        /// <param name="classFile">The class file.</param>
        /// <param name="classValue">The class value.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public  bool CalClassArea(string unitFile, string classFile, int classValue,out string msg)
        {
            IFeatureClass pUnitFeatureClass = null;
            IGeoDataset pRasterDst = null;
            ESRI.ArcGIS.SpatialAnalyst.IZonalOp pZonalOp = null;
            ITable pZonalTable = null;
            ITable pUnitTable = null;
            msg = string.Empty;
            try
            {
                int pixelValue = -1;
                if (!int.TryParse(SampleData.classNames[classValue], out pixelValue))
                {
                    pixelValue = classValue;
                }
                //未选中作物设为NODATA
                string targetClassFile = Path.Combine(GFS.BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + "SetNull.tif");

                if (!EnviVars.instance.GpExecutor.SetNoData(classFile, pixelValue, targetClassFile, out msg))
                    return false;

                //pRasterDst = EnviVars.instance.GpExecutor.SetNull(classFile, classValue);
                //区域统计
                pUnitFeatureClass = EngineAPI.OpenFeatureClass(unitFile);
                pRasterDst = EngineAPI.OpenRasterFile(targetClassFile) as IGeoDataset;
                pZonalOp = new ESRI.ArcGIS.SpatialAnalyst.RasterZonalOpClass();
                pZonalTable = pZonalOp.ZonalStatisticsAsTable((IGeoDataset)pUnitFeatureClass,pRasterDst, true);
                if (pZonalTable == null)
                {
                    msg = "计算分类面积失败：区域统计结果为空！";
                    return false;
                }
                ITableConversion conver = new TableConversion();
                DataTable zonalDT = conver.AETableToDataTable(pZonalTable);

                pUnitTable = pUnitFeatureClass as ITable;
                //添加分类面积字段
                //string fName = "YGMJ" + SampleData.classNames[classValue];
                string fName = "YGMJ";
                if (pUnitTable.FindField(fName) < 0)
                {
                    IField areaField = new FieldClass();
                    IFieldEdit fieldEdit = areaField as IFieldEdit;
                    fieldEdit.Name_2 = fName;
                    fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                    pUnitTable.AddField(areaField);
                }
                //面积字段赋值
                //int unitRows = pUnitTable.RowCount(null);
                //int areaRows = pZonalTable.RowCount(null);
                int unitId = pUnitTable.FindField("FID");
                //int areaId = pZonalTable.FindField("VALUE");
                int unitAreaIndex = pUnitTable.FindField(fName);
                //int areaIndex = pZonalTable.FindField("AREA");

                ICursor pUnitCursor = pUnitTable.Update(null, false);
                IRow unitRow = null;
                while ((unitRow = pUnitCursor.NextRow()) != null)
                {
                    string unitFid = unitRow.get_Value(unitId).ToString();
                    foreach (DataRow row in zonalDT.Rows)
                    {
                        if (unitFid == row["VALUE"].ToString())
                        {
                            unitRow.set_Value(unitAreaIndex, row["AREA"]);
                            pUnitCursor.UpdateRow(unitRow);
                        }
                    }
                    //IRow areaRow = null;
                    //ICursor pAreaCursor = pZonalTable.Update(null, false);
                    //while ((areaRow = pAreaCursor.NextRow()) != null)
                    //{
                    //    string areaFid = areaRow.get_Value(areaId).ToString();
                    //    if (unitFid == areaFid)
                    //    {
                    //        object value = areaRow.get_Value(areaIndex);
                    //        unitRow.set_Value(unitAreaIndex, value);
                    //        pUnitCursor.UpdateRow(unitRow);
                    //    }
                    //}
                    //Marshal.ReleaseComObject(pAreaCursor);
                }
                if (pUnitCursor!=null)
                    Marshal.ReleaseComObject(pUnitCursor);

                //for (int i = 0; i < unitRows; i++)
                //{
                //    IRow unitRow = pUnitTable.GetRow(i);
                //    var unitFid = unitRow.get_Value(0);
                //    for (int j = 0; j < areaRows; j++)
                //    {
                //        IRow areaRow = pZonalTable.GetRow(j);
                //        var areaFid = areaRow.get_Value(0);
                //        if (unitFid == areaFid)
                //        {
                //            unitRow.set_Value(unitAreaIndex, areaRow.get_Value(areaIndex));
                //            unitRow.Store();
                //        }
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pUnitFeatureClass != null)
                    Marshal.ReleaseComObject(pUnitFeatureClass);
                if (pRasterDst != null)
                    Marshal.ReleaseComObject(pRasterDst);
                if (pZonalOp != null)
                    Marshal.ReleaseComObject(pZonalOp);
                if (pUnitTable != null)
                    Marshal.ReleaseComObject(pUnitTable);
                if (pZonalTable != null)
                    Marshal.ReleaseComObject(pZonalTable);
            }
            
        }
    }
}
