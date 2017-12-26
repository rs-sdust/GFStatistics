// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 12-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 12-01-2017
// ***********************************************************************
// <copyright file="HyperSpeClassification.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFS.Commands;
using ESRI.ArcGIS.Geometry;
using System.Xml;
using System.IO;
using GFS.Common;
using ESRI.ArcGIS.Display;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
using ESRI.ArcGIS.Geodatabase;
using System.Drawing;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.SpatialAnalyst;

/// <summary>
/// The ClassificationBLL namespace.
/// </summary>
namespace GFS.ClassificationBLL
{
    /// <summary>
    /// Class HyperSpeClassification.
    /// </summary>
    public class HyperSpeClassification
    {
        /// <summary>
        /// 高管谱影像
        /// </summary>
        private string _Hyper;
        /// <summary>
        /// 训练样本
        /// </summary>
        private string _ROI;
        /// <summary>
        /// 分类结果
        /// </summary>
        private string _Result;

        /// <summary>
        /// 降维结果
        /// </summary>
        private string _Hyper_BandReduce;
        /// <summary>
        /// 首次svm分类结果
        /// </summary>
        private string _Hyper_Class;
        /// <summary>
        /// 首次svm分类规则文件
        /// </summary>
        private string _Hyper_Rule;
        /// <summary>
        /// 信息熵图像
        /// </summary>
        private string _Hyper_Entropy;
        /// <summary>
        /// 信息熵阈值
        /// </summary>
        private double _Hyper_Entropy_T;
        /// <summary>
        /// 提取的纯净像元
        /// </summary>
        private string _Hyper_PurePixel;
        /// <summary>
        /// 端元矢量
        /// </summary>
        private string _Endmem;
        //ROI layer list
        /// <summary>
        /// The roi layer dic
        /// </summary>
        private Dictionary<int, ROILayerClass> roiLayerDic = new Dictionary<int, ROILayerClass>();
        /// <summary>
        /// Gets the roi layer dic.
        /// </summary>
        /// <value>The roi layer dic.</value>
        public Dictionary<int, ROILayerClass> RoiLayerDic
        {
            get { return this.roiLayerDic; }
        }
        //record the spatial reference of ROI file
        /// <summary>
        /// The spatial reference
        /// </summary>
        private ISpatialReference spatialReference = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperSpeClassification"/> class.
        /// </summary>
        /// <param name="hyper">The hyper.</param>
        /// <param name="roi">The roi.</param>
        /// <param name="result">The result.</param>
        public HyperSpeClassification(string hyper,string roi,string result)
        {
            _Hyper = hyper;
            _ROI = roi;
            _Result = result;
        }

        /// <summary>
        /// 参数检查.
        /// </summary>
        public bool ChkPara(out string msg)
        {
            if (string.IsNullOrEmpty(_Hyper))
            {
                msg = "高光谱影像为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_ROI))
            {
                msg = "训练样本为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_Result))
            {
                msg = "分类结果为空！";
                return false;
            }
            else
            {
                msg = "";
                return true;
            }
        }
        /// <summary>
        /// 降维
        /// </summary>
        public bool BandReduce(out string msg)
        {

            IRasterDataset pRasterDataset = null;
            IRaster pRaster = null;
            StreamReader sr = null;
            IWorkspaceFactory pWKSF=null;
            IWorkspace pWorkspace=null;
            try
            {
                //调用IDL代码降维，存在32位内存不足问题。
                _Hyper_BandReduce = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".tif");
                //string cmd = BLL.ConstDef.IDL_FUN_BANDREDUCE + ",'" + _Hyper + "','" + ConstDef.FILE_BANDS + "','" + _Hyper_BandReduce + "'";
                //BLL.EnviVars.instance.IdlModel.Execute(cmd);
                //BLL.EnviVars.instance.IdlModel.Distroy();
                sr = new StreamReader(ConstDef.FILE_BANDS, Encoding.Default);
                string strBands = sr.ReadLine();
                string[] bandsArr = strBands.Split(',');
                pRasterDataset = EngineAPI.OpenRasterFile(_Hyper);
                pRaster = (pRasterDataset as IRasterDataset2).CreateFullRaster();
                
                IRasterBandCollection pRasterBandCollection = pRaster as IRasterBandCollection;
                foreach (string str in bandsArr)
                {
                    int bandIndex = int.Parse(str) - 1;
                    if (-1 < bandIndex && bandIndex < pRasterBandCollection.Count)
                    {
                        pRasterBandCollection.Remove(bandIndex);
                    }
                }
                IRasterBand pBand = pRasterBandCollection.Item(0);
                IRasterDataset pOutRasterDataset = pBand.RasterDataset;
                ISaveAs pSaveAs = pOutRasterDataset as ISaveAs;
                FileInfo fInfo = new FileInfo(_Hyper_BandReduce);
                pWKSF = new RasterWorkspaceFactoryClass();
                pWorkspace = pWKSF.OpenFromFile(fInfo.DirectoryName, 0);
                if (fInfo.Extension == ".img")
                {
                    IDataset pDataset = pSaveAs.SaveAs(fInfo.Name, pWorkspace, "IMAGINE Image");
                    Marshal.ReleaseComObject(pDataset);
                }
                if (fInfo.Extension == ".tif")
                {
                    IDataset pDataset = pSaveAs.SaveAs(fInfo.Name, pWorkspace, "TIFF");
                    Marshal.ReleaseComObject(pDataset);
                }
                Marshal.ReleaseComObject(pSaveAs);
                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (pWorkspace!=null)
                    Marshal.ReleaseComObject(pWorkspace);
                if (pWKSF != null)
                    Marshal.ReleaseComObject(pWKSF);
                if (pRaster != null)
                    Marshal.ReleaseComObject(pRaster);
                sr.Close();
                sr.Dispose();
            }
        }

        /// <summary>
        /// 首次svm
        /// </summary>
        public bool  SVM( out string msg)
        {
            try
            {
                _Hyper_Rule = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "rule_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                _Hyper_Class = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "class_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                if (!LoadROI(_ROI, out msg))
                    return false;
                string segmentROI = CreateShpByROI();
                if (string.IsNullOrEmpty(segmentROI))
                {
                    msg = "create Shp by sample failed!";
                    return false;
                }

                string cmd = BLL.ConstDef.IDL_FUN_SVM + ",'" + _Hyper + "','" + _Hyper_Class + "','" +
                    segmentROI + "','" + _Hyper_Rule + "'";

                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                BLL.EnviVars.instance.IdlModel.Distroy();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 信息熵计算
        /// </summary>
        public bool Entropy(out string msg)
        {
            try
            {
                _Hyper_Entropy = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "entropy_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                string cmd = BLL.ConstDef.IDL_FUN_ENTROPY + ",'" + _Hyper_Rule + "','" + _Hyper_Entropy + "'";

                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 计算信息熵阈值
        /// </summary>
        public bool CalEntropyMean(out string msg)
        {
            IRasterDataset pRasterDataset = null;
            try
            {
                pRasterDataset = EngineAPI.OpenRasterFile(_Hyper_Entropy);
                IRasterBandCollection pRasterBandCollection = pRasterDataset as IRasterBandCollection;
                IRasterBand pRasterBand = pRasterBandCollection.Item(0);
                bool hasSta = false;
                pRasterBand.HasStatistics(out hasSta);
                if (!hasSta)
                    pRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRasterStatistics = pRasterBand.Statistics;
                _Hyper_Entropy_T = pRasterStatistics.Mean;
                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;        
            }
            finally
            {
                if (pRasterDataset != null)
                    Marshal.ReleaseComObject(pRasterDataset);
            }
        }

        /// <summary>
        /// 提取信息熵小于阈值的纯净像元.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ExtractPurePixel(out string msg)
        {
            IMapAlgebraOp pRSalgebra = null;
            IRasterDataset pRDEntropy = null;
            IRasterDataset pRDClass = null;
            try
            {
                //运算公式
                string condition = "[ENTROPY] >= " + _Hyper_Entropy_T;
                //string expression = "SETNULL(" + condition +",[CLASS])";
                string expression = "CON(" + condition + ",0,[CLASS])";
                //文件绑定
                pRSalgebra = new RasterMapAlgebraOpClass();
                pRDEntropy = EngineAPI.OpenRasterFile(_Hyper_Entropy);
                pRSalgebra.BindRaster(pRDEntropy as IGeoDataset, "ENTROPY");
                pRDClass = EngineAPI.OpenRasterFile(_Hyper_Class);
                pRSalgebra.BindRaster(pRDClass as IGeoDataset, "CLASS");
                //执行运算
                IGeoDataset resDataset = pRSalgebra.Execute(expression);
                //另存结果
                _Hyper_PurePixel = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "PurePixel_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                ISaveAs pSaveAs = resDataset as ISaveAs;
                if (File.Exists(_Hyper_PurePixel))
                {
                    File.Delete(_Hyper_PurePixel);
                }
                FileInfo fInfo = new FileInfo(_Hyper_PurePixel);
                IWorkspaceFactory pWKSF03 = new RasterWorkspaceFactoryClass();
                IWorkspace pWorkspace03 = pWKSF03.OpenFromFile(fInfo.DirectoryName, 0);
                if (fInfo.Extension == ".img")
                {
                    IDataset pDataset = pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "IMAGINE Image");
                    Marshal.ReleaseComObject(pDataset);
                }
                if (fInfo.Extension == ".tif")
                {
                    IDataset pDataset = pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "TIFF");
                    Marshal.ReleaseComObject(pDataset);
                }
                if (resDataset != null)
                    Marshal.ReleaseComObject(resDataset);
                if (pSaveAs != null)
                    Marshal.ReleaseComObject(pSaveAs);
                msg = "";
                return true;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (pRDClass != null)
                    Marshal.ReleaseComObject(pRDClass);
                if (pRDEntropy != null)
                    Marshal.ReleaseComObject(pRDEntropy);
                if (pRSalgebra != null)
                    Marshal.ReleaseComObject(pRSalgebra);
            }
        }

        public bool MergePixel(out string msg)
        {
            IMapAlgebraOp pRSalgebra = null;
            IRasterDataset pRuleDataset = null;
            IRasterDataset pPixelDataset = null;
            IWorkspaceFactory pWKSF = null;
            IWorkspace pWorkspace = null;
            string bandDirectory = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString());
            try
            {
                Directory.CreateDirectory(bandDirectory);
                List<string> uniqueVlaues = EngineAPI.GetRasterUniqueValue(_Hyper_PurePixel);
                pWKSF = new RasterWorkspaceFactoryClass();
                pWorkspace = pWKSF.OpenFromFile(bandDirectory, 0);
                for (int i = 0; i < uniqueVlaues.Count; i++)
                {
                    if (uniqueVlaues[i] == "0")
                        continue;
                    string condition = "[PURE] == " + uniqueVlaues[i];
                    string exp = "CON(" + condition + ",[PURE],[RULE])";

                    pRuleDataset = EngineAPI.OpenRasterDataset(_Hyper_Rule, i);
                    pPixelDataset = EngineAPI.OpenRasterFile(_Hyper_PurePixel);
                    pRSalgebra = new RasterMapAlgebraOpClass();

                    pRSalgebra.BindRaster(pPixelDataset as IGeoDataset, "PURE");
                    pRSalgebra.BindRaster(pRuleDataset as IGeoDataset, "RULE");

                    IGeoDataset resDataset = pRSalgebra.Execute(exp);
                    string bandFileName = "class_" + uniqueVlaues[i] + ".tif";
                    string bandFile = System.IO.Path.Combine(bandDirectory, bandFileName);

                    ISaveAs pSaveAs = resDataset as ISaveAs;

                    if (File.Exists(bandFile))
                    {
                        File.Delete(bandFile);
                    }

                    IDataset pDataset = pSaveAs.SaveAs(bandFileName, pWorkspace, "TIFF");
                    if (pDataset != null)
                        Marshal.ReleaseComObject(pDataset);
                    if (resDataset != null)
                        Marshal.ReleaseComObject(resDataset);
                    if (pSaveAs != null)
                        Marshal.ReleaseComObject(pSaveAs);
                }

                //layer stack
                string cmd = "bandcompose,'" + bandDirectory + "','" + _Result + "'";
                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                if (pRuleDataset != null)
                    Marshal.ReleaseComObject(pRuleDataset);
                if (pPixelDataset != null)
                    Marshal.ReleaseComObject(pPixelDataset);
                if (pRSalgebra != null)
                    Marshal.ReleaseComObject(pRSalgebra);
                if (pWKSF != null)
                    Marshal.ReleaseComObject(pWKSF);
                if (pWorkspace != null)
                    Marshal.ReleaseComObject(pWorkspace);
            }


        }


        public bool PurePixel2Shp(out string msg)
        {
            IFeatureClass pFeatureClass = null;
            try
            {
                string outEnd = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "PurePixel_" + DateTime.Now.ToFileTime().ToString() + ".shp");
                if (!BLL.EnviVars.instance.GpExecutor.Raster2Polygon(_Hyper_PurePixel, outEnd, false, out msg))
                {
                    return false;
                }
                //字段整理
                pFeatureClass = EngineAPI.OpenFeatureClass(outEnd);
                pFeatureClass.DeleteField(pFeatureClass.Fields.get_Field(0));
                IField field= new FieldClass();
                IFieldEdit fieldEdit2 = field as IFieldEdit;
                fieldEdit2.Name_2 = "CLASS_ID";
                fieldEdit2.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFeatureClass.AddField(field);

                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }

        }









        private bool LoadROI(string inSample, out string msg)
        {
            try
            {
                msg = "";
                if (roiLayerDic.Count > 0)
                    roiLayerDic.Clear();
                if (!string.IsNullOrEmpty(inSample) && File.Exists(inSample))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(inSample);
                    XmlNode xmlNode = xmlDocument.SelectSingleNode("RegionsOfInterest");
                    if (xmlNode == null)
                    {
                        msg = "ROI内容为空！";
                        return false;
                    }
                    for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                    {
                        XmlNode xmlNode2 = xmlNode.ChildNodes[i];
                        string value = xmlNode2.Attributes[0].Value;
                        string value2 = xmlNode2.Attributes[1].Value;
                        string[] array = value2.Split(new char[]
                    {
                        ','
                    });
                        int red = CommonAPI.ConvertToInt(array[0]);
                        int green = CommonAPI.ConvertToInt(array[1]);
                        int blue = CommonAPI.ConvertToInt(array[2]);
                        IRgbColor color = new RgbColorClass
                        {
                            Red = red,
                            Green = green,
                            Blue = blue
                        };
                        ROILayerClass rOILayerClass = new ROILayerClass();
                        rOILayerClass.ID = ((roiLayerDic.Keys.Count == 0) ? 1 : (roiLayerDic.Keys.Max() + 1));
                        rOILayerClass.Name = value;
                        rOILayerClass.Color = color;
                        rOILayerClass.ElementList = new List<ROIElementClass>();
                        roiLayerDic.Add(rOILayerClass.ID, rOILayerClass);

                        string innerText = xmlNode2.SelectSingleNode("GeometryDef/CoordSysStr").InnerText;
                        spatialReference = EngineAPI.GetSpatialRefFromPrjStr(innerText);
                        XmlNodeList xmlNodeList = xmlNode2.SelectNodes("GeometryDef/Polygon/Exterior/LinearRing/Coordinates");
                        for (int j = 0; j < xmlNodeList.Count; j++)
                        {
                            IPointCollection pointCollection = new PolygonClass();
                            string innerText2 = xmlNodeList[j].InnerText;
                            string[] array2 = innerText2.Split(new char[]
						{
							' '
						});
                            int num = array2.Length / 2;
                            for (int k = 0; k < num; k++)
                            {
                                IPoint point = new PointClass();
                                double x = CommonAPI.ConvertToDouble(array2[2 * k]);
                                double y = CommonAPI.ConvertToDouble(array2[2 * k + 1]);
                                point.PutCoords(x, y);
                                object value3 = Missing.Value;
                                object value4 = Missing.Value;
                                pointCollection.AddPoint(point, ref value3, ref value4);
                            }
                            IPolygon polygon = pointCollection as IPolygon;
                            polygon.FromPoint = pointCollection.get_Point(0);
                            polygon.ToPoint = pointCollection.get_Point(pointCollection.PointCount - 1);
                            if (spatialReference == null)
                            {
                                spatialReference = new UnknownCoordinateSystemClass();
                            }
                            polygon.SpatialReference = spatialReference;
                            polygon.Close();
                            IElement element = new PolygonElementClass();
                            element.Geometry = polygon;

                            ROIElementClass rOIElementClass = new ROIElementClass
                            {
                                Element = element,
                                Checked = true
                            };
                            rOILayerClass.ElementList.Add(rOIElementClass);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                msg = ex.Message;
                return false;
            }
        }
        private string CreateShpByROI()
        {
            string empty = string.Empty;
            List<ROIGeometry> roiGeometryList = new List<ROIGeometry>();

            object missing = Type.Missing;
            foreach (KeyValuePair<int, ROILayerClass> current in roiLayerDic)
            {
                IGeometryCollection geometryCollection = new PolygonClass();
                foreach (ROIElementClass current2 in current.Value.ElementList)
                {
                    if (current2.Checked)
                    {
                        //geometryCollection.AddGeometryCollection(current2.Element.Geometry as IGeometryCollection);
                        roiGeometryList.Add(new ROIGeometry(current.Value.ID, current.Value.Name, current.Value.Color, current2.Element.Geometry));
                    }
                }
                //if (geometryCollection.GeometryCount > 0)
                //{
                //    IGeometry geometry = geometryCollection as IGeometry;
                //    geometry.SpatialReference = spatialReference;
                //    if (geometry != null)
                //    {
                //        roiGeometryList.Add(new ROIGeometry(current.Value.ID, current.Value.Name, current.Value.ID, geometry));
                //        //if (!ROIManager.instance.GpExecutor.CreateShpFile(geometry, out empty))
                //        //{
                //        //    empty = string.Empty;
                //        //}
                //    }
                //}
            }

            if (!this.CreateShpFile(roiGeometryList, out empty))
                empty = string.Empty;
            return empty;
        }
        private bool CreateShpFile(List<ROIGeometry> geometryList, out string sShpFilePath)
        {
            bool result = false;
            string shpName = DateTime.Now.ToString("yyyyMMddhhmmss");
            sShpFilePath = System.IO.Path.Combine(ConstDef.PATH_TEMP, shpName + ".shp");
            try
            {
                if (!Directory.Exists(ConstDef.PATH_TEMP))
                {
                    Directory.CreateDirectory(ConstDef.PATH_TEMP);
                }
                IWorkspace workspace = EngineAPI.OpenWorkspace(ConstDef.PATH_TEMP, DataType.shp);
                if (workspace == null)
                {
                    result = false;
                }
                else
                {
                    IFields fields = this.CreateFields();
                    if (fields == null)
                        result = false;
                    IFeatureClass featureClass = this.CreateFeatureClass(workspace, shpName, fields, spatialReference);
                    if (featureClass == null)
                        result = false;
                    try
                    {
                        int rowIndex = 0;
                        foreach (ROIGeometry roi in geometryList)
                        {
                            IFeature pFeature = featureClass.CreateFeature();
                            pFeature.Shape = roi.geometry;
                            pFeature.Store();

                            ITable pTable = pFeature.Table;
                            if (pTable.RowCount(null) > 0)
                            {
                                IRow pRow = pTable.GetRow(rowIndex);
                                pRow.set_Value(2, roi.name);
                                pRow.set_Value(3, roi.id);
                                Color color = ColorTranslator.FromOle(roi.color.RGB);
                                pRow.set_Value(4, string.Format("{0},{1},{2}", color.R, color.G, color.B));
                                pRow.Store();
                            }
                            rowIndex++;
                            //IFieldEdit field = feature as IField;

                        }
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(typeof(HyperSpeClassification), ex);
                        result = false;
                    }
                    finally
                    {
                        if (featureClass != null)
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(featureClass);
                    }

                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(HyperSpeClassification), ex);
                result = false;
            }

            return result;
        }
        //
        //create new featureclass 
        //
        private IFeatureClass CreateFeatureClass(IWorkspace workspace, string sName, IFields fields, ISpatialReference spatialRef)
        {
            return MapAPI.CreateFeatureClass(workspace, sName, fields, spatialRef, esriGeometryType.esriGeometryPolygon);
        }
        //
        //create fields needed in roi shp file
        //
        private IFields CreateFields()
        {
            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
            IFields requiredFields = objectClassDescription.RequiredFields;
            IFieldsEdit fieldsEdit = requiredFields as IFieldsEdit;
            IField field1 = new FieldClass();
            IFieldEdit fieldEdit1 = field1 as IFieldEdit;
            fieldEdit1.Name_2 = "CLASS_NAME";
            fieldEdit1.Type_2 = esriFieldType.esriFieldTypeString;
            fieldEdit1.Length_2 = 50;
            IField field2 = new FieldClass();
            IFieldEdit fieldEdit2 = field2 as IFieldEdit;
            fieldEdit2.Name_2 = "CLASS_ID";
            fieldEdit2.Type_2 = esriFieldType.esriFieldTypeInteger;
            IField field3 = new FieldClass();
            IFieldEdit fieldEdit3 = field3 as IFieldEdit;
            fieldEdit3.Name_2 = "CLASS_CLRS";
            fieldEdit3.Type_2 = esriFieldType.esriFieldTypeString;
            fieldEdit3.Length_2 = 50;
            fieldsEdit.AddField(field1);
            fieldsEdit.AddField(field2);
            fieldsEdit.AddField(field3);
            return requiredFields;
        }

    }
}
