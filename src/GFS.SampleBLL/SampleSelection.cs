// ***********************************************************************
// Assembly         : GFS.SampleBLL
// Author           : Ricker Yan
// Created          : 09-26-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 10-15-2017
// ***********************************************************************
// <copyright file="SampleSelection.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>样本抽选</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Runtime.InteropServices;
using System.IO;
using ESRI.ArcGIS.Geometry;
using GFS.Common;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using GFS.BLL;
using System.Data;

namespace GFS.SampleBLL
{
    public class SamplePara
    {
        public bool isNum
        { get; set; }
        public int sampleNum
        { get; set; }
        public double sampleRate
        { get; set; }
    }
    public class SampleSelection
    {
        private static string _unique = "uniqueid";
        private static string _YFBH = "YFBH";
        private static string _GDMJ = "GDMJ";

        public static bool ChkData(out string msg)
        {
            msg = string.Empty;
            //firstunit
            if (string.IsNullOrEmpty(SampleData.firstUnit))
            {
                msg = "一级抽样单元为空！";
                return false;
            }
            else 
            {
                if (string.IsNullOrEmpty(SampleData.villageField))
                {
                    msg = "村名字段为空！";
                    return false;
                }
                else if (string.IsNullOrEmpty(SampleData.layerField))
                {
                    msg = "分层字段为空！";
                    return false;
                }
            }
            //framland
            if (string.IsNullOrEmpty(SampleData.farmLand))
            {
                msg = "耕地矢量为空！";
                return false;
            }
            //ascdl
            if (string.IsNullOrEmpty(SampleData.ASCDL))
            {
                msg = "ASCDL为空！";
                return false;
            }
            else
            {
                if (SampleData.targetCrop < 0)
                {
                    msg = "目标作物为空！";
                    return false;
                }
            }

            return true;
        }
        //public static void CreateFishNet(string inTemplate, int width, int height, string outFishNet)
        //{
        //    IFeatureClass inFeatureClass = null;
        //    IFeatureClass outFeatureClass = null;
        //    ISpatialReference spatialReference = null;
        //    IEnvelope extent = null;
        //    try
        //    {
        //        inFeatureClass = EngineAPI.OpenFeatureClass(inTemplate);
        //        spatialReference = (inFeatureClass as IGeoDataset).SpatialReference;
        //        if (!CreateShpFile(outFishNet, spatialReference))
        //        {
        //            throw new Exception("创建矢量文件失败！");
        //        }
        //        outFeatureClass = EngineAPI.OpenFeatureClass(outFishNet);

        //        extent = (inFeatureClass as IGeoDataset).Extent;
        //        double extentW = extent.Width;
        //        double extentH = extent.Height;
        //        double extenXmin = extent.XMin;
        //        double extenYmin = extent.YMin;

        //        int columCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(extentW / width)));
        //        int rowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(extentH / height)));
        //        for (int j = 0; j < rowCount * columCount; j++)
        //        {
        //            int row = j / columCount;
        //            int col = j % columCount;

        //            IEnvelope rect = new EnvelopeClass();
        //            rect.SpatialReference = spatialReference;
        //            rect.XMin = extenXmin + col * width;
        //            rect.XMax = rect.XMin + width;
        //            rect.YMin = extenYmin + row * height;
        //            rect.YMax = rect.YMin + height;
        //            IElement ele = new RectangleElementClass
        //            {
        //                Geometry = rect
        //            };

        //            IFeature pFeature = outFeatureClass.CreateFeature();
        //            pFeature.Shape = ele.Geometry;
        //            pFeature.Store();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (spatialReference != null)
        //            Marshal.ReleaseComObject(spatialReference);
        //        if (extent != null)
        //            Marshal.ReleaseComObject(extent);
        //        if (inFeatureClass != null)
        //            Marshal.ReleaseComObject(inFeatureClass);
        //        if (outFeatureClass != null)
        //            Marshal.ReleaseComObject(outFeatureClass);
        //    }

        //}

        public static void Sampling(string inFirstUnit, string firstUnit_Name,string layer, string inSecondUnit, string inCultivation, SamplePara para, string outSample)
        {
            IFeatureClass inFirstF = null;
            IFeatureClass inSecondF = null;
            IFeatureClass inCultivationF = null;
            IFeatureClass outFeatureClass = null;
            ISpatialReference spatialReference = null;
            try
            {

                //耕地和一级抽样单元相交处理
                string instert = System.IO.Path.Combine(ConstDef.PATH_TEMP,DateTime.Now.ToFileTime().ToString()+".shp");
                string msg=string.Empty;
                if (!EnviVars.instance.GpExecutor.Intersect(inFirstUnit + ";" + inCultivation, instert, out msg))
                {
                    throw new Exception(msg);
                }
                //读取一级抽样单元
                inFirstF = EngineAPI.OpenFeatureClass(inFirstUnit);
                //读取二级渔网
                inSecondF = EngineAPI.OpenFeatureClass(inSecondUnit);
                spatialReference = (inFirstF as IGeoDataset).SpatialReference;
                //创建二级抽样单元矢量
                if (!CreateShpFile(outSample, spatialReference, firstUnit_Name,layer))
                {
                    throw new Exception("创建二级抽样单元矢量文件失败！");
                }
                outFeatureClass = EngineAPI.OpenFeatureClass(outSample);
                //读取一级抽样单元与耕地相交结果
                inCultivationF = EngineAPI.OpenFeatureClass(instert);
                //一级单元抽样个数
                int firstUnitCount = inFirstF.FeatureCount(null);
                int nameIndex = inFirstF.FindField(firstUnit_Name);
                int layerIndex = inFirstF.FindField(layer);
                IFeature pFFirst = null;
                IFeatureCursor pFCFirst = inFirstF.Search(null, false);
                IFeatureBuffer pFeatureBuffer = outFeatureClass.CreateFeatureBuffer();
                IFeatureCursor pInsertCursor = outFeatureClass.Insert(true); 
                while ((pFFirst = pFCFirst.NextFeature()) != null)
                {
                    string fUnitName = pFFirst.get_Value(nameIndex).ToString();
                    IQueryFilter pQFIntersect = new QueryFilterClass();
                    pQFIntersect.WhereClause = "\"" + firstUnit_Name + "\"" + " = '" + fUnitName + "'";
                    IFeatureCursor pFeatureCursor = inCultivationF.Search(pQFIntersect, false);
                    //指定一级抽样单元内耕地geometry合并
                    IFeature unionFeature = inCultivationF.CreateFeature();
                    IFeature pFeature = null;
                    while ((pFeature = pFeatureCursor.NextFeature()) != null)
                    {
                        IGeometry geometry = unionFeature.Shape;
                        ITopologicalOperator2 unionTopo = geometry as ITopologicalOperator2;
                        unionFeature.Shape = unionTopo.Union(pFeature.ShapeCopy);
                    }
                    //Marshal.ReleaseComObject(pFeatureCursor);
                    //获取与耕地合并geometry相交的二级格网
                    ISpatialFilter pSFSecond = new SpatialFilterClass();
                    pSFSecond.Geometry = unionFeature.Shape;
                    pSFSecond.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    pFeatureCursor = inSecondF.Search(pSFSecond, false);
                    List<IFeature> sUnitFList = new List<IFeature>();
                    while ((pFeature = pFeatureCursor.NextFeature()) != null)
                    {
                        sUnitFList.Add(pFeature);
                    }
                    if (pFeatureCursor != null)
                    Marshal.ReleaseComObject(pFeatureCursor);
                    int sampleNum = 0;
                    if (para.isNum)
                    {
                        sampleNum = para.sampleNum;
                    }
                    else
                    {
                        sampleNum = Convert.ToInt32(sUnitFList.Count * para.sampleRate);
                    }

                    if (sUnitFList.Count > sampleNum)
                    {
                        //从相交的二级格网中随机抽样指定个数，并存出
                        Random ran = new Random();
                        for (int j = 0; j < sampleNum; j++)
                        {
                            //System.Threading.Thread.Sleep(100);
                            int range = sUnitFList.Count - 1;
                            int selected = ran.Next(0, range);
                            pFeatureBuffer.Shape = sUnitFList[selected].ShapeCopy;
                            pFeatureBuffer.set_Value(2, j);
                            pFeatureBuffer.set_Value(3, fUnitName);
                            pFeatureBuffer.set_Value(4, pFFirst.get_Value(layerIndex));
                            pInsertCursor.InsertFeature(pFeatureBuffer);
                            sUnitFList.RemoveAt(selected);
                        }

                    }
                    else
                    {
                        //throw new Exception("选择的样本数大于样本总量！");

                        for (int j = 0; j < sUnitFList.Count; j++)
                        {
                            pFeatureBuffer.Shape = sUnitFList[j].ShapeCopy;
                            pFeatureBuffer.set_Value(2, j);
                            pFeatureBuffer.set_Value(3, fUnitName);
                            pFeatureBuffer.set_Value(4, pFFirst.get_Value(layerIndex));
                            pInsertCursor.InsertFeature(pFeatureBuffer);
                            //pFeature = outFeatureClass.CreateFeature();
                            //pFeature.Shape = sUnitFList[j].ShapeCopy;
                            ////secondUnitCount++;
                            //pFeature.set_Value(2, j);
                            //pFeature.set_Value(3, fUnitName);
                            //pFeature.set_Value(4, pFFirst.get_Value(layerIndex));
                            //pFeature.Store();
                        }
                    }
                }
                pInsertCursor.Flush();
                if (pFeatureBuffer!=null)
                Marshal.ReleaseComObject(pFeatureBuffer);
                if (pInsertCursor != null)
                Marshal.ReleaseComObject(pInsertCursor);
                if (pFCFirst != null)
                Marshal.ReleaseComObject(pFCFirst);
                //for (int i = 0; i < firstUnitCount; i++)
                //{
                //    IFeature pFeature = inFirstF.GetFeature(i);
                //    string fUnitName = pFeature.Table.GetRow(i).get_Value(nameIndex).ToString();
                //    IQueryFilter pQueryFilter = new QueryFilterClass();
                //    pQueryFilter.WhereClause = "\"" + firstUnit_Name + "\"" + " = '" +  fUnitName + "'";
                //    IFeatureCursor pFeatureCursor = inCultivationF.Search(pQueryFilter, false);
                //    //ISelectionSet pSelectionSet = inCultivationF.Select(pQueryFilter, esriSelectionType.esriSelectionTypeSnapshot, esriSelectionOption.esriSelectionOptionNormal, null);
                //    //IPolygon polygon =(pSelectionSet as IPolygon);
                //    //指定一级抽样单元内耕地geometry合并
                //    IFeature unionFeature = inCultivationF.CreateFeature();
                //    while ((pFeature = pFeatureCursor.NextFeature()) != null)
                //    {
                //        IGeometry geometry = unionFeature.Shape;
                //        ITopologicalOperator2 unionTopo = geometry as ITopologicalOperator2;
                //        unionFeature.Shape = unionTopo.Union(pFeature.ShapeCopy);
                //    }
                //    //获取与耕地合并geometry相交的二级格网
                //    ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                //    pSpatialFilter.Geometry = unionFeature.Shape;
                //    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                //    pFeatureCursor = inSecondF.Search(pSpatialFilter, false);
                //    List<IFeature> sUnitFList = new List<IFeature>();
                //    while ((pFeature = pFeatureCursor.NextFeature()) != null)
                //    {
                //        sUnitFList.Add(pFeature);
                //    }
                //    if (sUnitFList.Count < sampleNum)
                //    {
                //        throw new Exception("选择的样本数大于样本总量！");
                //    }
                //    //从相交的二级格网中随机抽样指定个数，并存出
                //    for (int j = 0; j < sampleNum; j++)
                //    {
                //        System.Threading.Thread.Sleep(100);
                //        Random ran = new Random();
                //        int range = sUnitFList.Count - 1;
                //        int selected = ran.Next(0, range);
                //        pFeature = outFeatureClass.CreateFeature();
                //        pFeature.Shape = sUnitFList[selected].ShapeCopy;
                //        secondUnitCount++;
                //        pFeature.set_Value(2,secondUnitCount);
                //        pFeature.Store();
                //        sUnitFList.RemoveAt(selected);
                //    }
                //}
               
            }
            catch (Exception ex )
            {
                throw ex;
            }
            finally
            {
                if (spatialReference != null)
                    Marshal.ReleaseComObject(spatialReference);
                if (outFeatureClass != null)
                    Marshal.ReleaseComObject(outFeatureClass);
                if (inCultivationF != null)
                    Marshal.ReleaseComObject(inCultivationF);
                if (inSecondF != null)
                    Marshal.ReleaseComObject(inSecondF);
                if (inFirstF != null)
                    Marshal.ReleaseComObject(inFirstF);
            }

        }

        public static bool CalLandArea(string unitFile, string framLand, out string msg)
        {
            IFeatureClass pUnitFeatureClass = null;
            IFeatureClass pAreaFeatureClass = null;
            ITable pUnitTable = null;
            ITable pAreaTable = null;
            try
            {
                msg = string.Empty;
                //相交处理
                string interFile = System.IO.Path.Combine(GFS.BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                //if (!GFS.BLL.EnviVars.instance.GpExecutor.Intersect(unitFile + ";" + framLand, interFile, out msg))
                //    return false;
                EnviVars.instance.GpExecutor.Intersect(unitFile + ";" + framLand, interFile, out msg);
                //重算面积
                string areaFile = System.IO.Path.Combine(GFS.BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
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
                DataColumn refColum = new DataColumn(_unique, typeof(string));
                if (!areaDT.Columns.Contains("uniqueid"))
                    areaDT.Columns.Add(refColum);

                foreach (DataRow row in areaDT.Rows)
                {
                    row[_unique] = row[SampleData.villageField].ToString() + row[_YFBH].ToString();
                }

                Summarize sum = new Summarize(areaDT);
                DataTable sumDT = sum.Sum(areaDT.Columns.IndexOf("F_AREA"), areaDT.Columns.IndexOf(_unique));

                pUnitTable = pUnitFeatureClass as ITable;
                //pAreaTable = pAreaFeatureClass as ITable;

                if (pUnitTable.FindField(_GDMJ) < 0)
                {
                    IField areaField = new FieldClass();
                    IFieldEdit fieldEdit = areaField as IFieldEdit;
                    fieldEdit.Name_2 = _GDMJ;
                    fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                    pUnitTable.AddField(areaField);
                }
                //int unitRows = pUnitTable.RowCount(null);
                //int areaRows = pAreaTable.RowCount(null);
                int unitNameIndex = pUnitTable.FindField(SampleData.villageField);
                int unitIDIndex = pUnitTable.FindField(_YFBH);
                //int areaNameIndex = pAreaTable.FindField(SampleData.villageField);
                int unitAreaIndex = pUnitTable.FindField(_GDMJ);
                //int areaIndex = pAreaTable.FindField("F_AREA");

                ICursor pUnitCursor = pUnitTable.Update(null, false);

                IRow unitRow = null;
                while ((unitRow = pUnitCursor.NextRow()) != null)
                {
                    string unitFid = unitRow.get_Value(unitNameIndex).ToString()+
                        unitRow.get_Value(unitIDIndex).ToString();
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
                if (pUnitCursor!=null)
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
        
        private static bool CreateShpFile(string shpPath, ISpatialReference spatialReference,string xzqmc,string layer)
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
                    //IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
                    //需要知道二级样本要保留的字段信息
                    //IFields requiredFields = objectClassDescription.RequiredFields;
                    IFields requiredFields = CreateFields(xzqmc,layer);
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

        //
        //create fields needed in roi shp file
        //
        private static IFields CreateFields(string xzqmc,string layer)
        {
            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
            IFields requiredFields = objectClassDescription.RequiredFields;
            IFieldsEdit fieldsEdit = requiredFields as IFieldsEdit;

            IField field1 = new FieldClass();
            IFieldEdit fieldEdit1 = field1 as IFieldEdit;
            fieldEdit1.Name_2 = _YFBH;
            fieldEdit1.Type_2 = esriFieldType.esriFieldTypeInteger;
            
            IField field2 = new FieldClass();
            IFieldEdit fieldEdit2 = field2 as IFieldEdit;
            fieldEdit2.Name_2 = xzqmc;
            fieldEdit2.Type_2 = esriFieldType.esriFieldTypeString;
            fieldEdit2.Length_2 = 50;

            IField field3 = new FieldClass();
            IFieldEdit fieldEdit3 = field3 as IFieldEdit;
            fieldEdit3.Name_2 = layer;
            fieldEdit3.Type_2 = esriFieldType.esriFieldTypeInteger;
 
            fieldsEdit.AddField(field1);
            fieldsEdit.AddField(field2);
            fieldsEdit.AddField(field3);

            return requiredFields;
        }

        private static int getUniqueRandom(int selected, List<int> sampled,int range)
        {
            if (!sampled.Contains(selected))
            {
                sampled.Add(selected);
                return selected;
            }
            else
            {
                Random r = new Random();
                int newSelected = r.Next(0, range);
                return getUniqueRandom(newSelected, sampled, range);

            }
        }
    
    }
}
