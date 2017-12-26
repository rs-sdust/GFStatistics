// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 11-07-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 11-07-2017
// ***********************************************************************
// <copyright file="GF3Classification.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using GFS.Common;
using ESRI.ArcGIS.Display;
using GFS.Commands;
using ESRI.ArcGIS.Geometry;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
using ESRI.ArcGIS.Geodatabase;
using System.Drawing;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;

/// <summary>
/// The Classification namespace.
/// </summary>
namespace GFS.ClassificationBLL
{
    /// <summary>
    /// Class GF3Classification.
    /// </summary>
    public class GF3Classification
    {
        /// <summary>
        /// 像元roi
        /// </summary>
        private string _pixelROI;
        /// <summary>
        /// 图斑roi
        /// </summary>
        private string _segmentROI;
        /// <summary>
        /// gf3极化特征
        /// </summary>
        private string _GF3Polarity;
        /// <summary>
        /// gf1影像
        /// </summary>
        private string _GF1;
        /// <summary>
        /// gf1分割结果shp
        /// </summary>
        private string _GF1Segment;
        /// <summary>
        /// gf3区域均值统计
        /// </summary>
        private string _GF3Mean;
        /// <summary>
        /// 图斑分类结果
        /// </summary>
        private string _classFeature;
        /// <summary>
        /// 图斑后验概率
        /// </summary>
        private string _classRule;
        /// <summary>
        /// 图斑信息熵
        /// </summary>
        private string _entropy;
        /// <summary>
        /// 图斑信息熵阈值
        /// </summary>
        private double _entropyT = 1.2;
        /// <summary>
        /// 像元分类结果
        /// </summary>
        private string _classPixel;
        /// <summary>
        /// 修正的最终分类结果
        /// </summary>
        private string _class;

        //ROI layer list
        private Dictionary<int, ROILayerClass> roiLayerDic = new Dictionary<int, ROILayerClass>();
        public Dictionary<int, ROILayerClass> RoiLayerDic
        {
            get { return this.roiLayerDic; }
        }
        //record the spatial reference of ROI file
        private ISpatialReference spatialReference = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="GF3Classification"/> class.
        /// </summary>
        /// <param name="gf3">The GF3.</param>
        /// <param name="gf1">The GF1.</param>
        /// <param name="pixelROI">The pixel roi.</param>
        /// <param name="segmentROI">The segment roi.</param>
        public GF3Classification(string gf3,string gf1,string pixelROI,string segmentROI,string result)
        {
            _GF3Polarity = gf3;
            _GF1Segment = gf1;
            _pixelROI = pixelROI;
            _segmentROI = segmentROI;
            _class = result;
        }

        public bool ChkPara(out string msg)
        {
            if (string.IsNullOrEmpty(_GF3Polarity))
            {
                msg = "GF3极化特征影像为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_GF1Segment))
            {
                msg = "GF1分割影像为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_segmentROI))
            {
                msg = "图斑ROI为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_pixelROI))
            {
                msg = "像元ROI为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_class))
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
        /// GF1图像分割
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Segment()
        {
            try
            {
                _GF1Segment = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP,DateTime.Now.ToFileTime().ToString());
                string cmd = BLL.ConstDef.IDL_FUN_SEGMENTONLY + ",'"+ _GF1 +"',30,40,3," + "'"+ _GF1Segment +"'" ;
                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// gf3区域均值统计
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ZonalPolarity(out string msg)
        {
            try
            {
                //GF3波段拆分
                string outDir = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString())+"\\";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }
                string cmd = BLL.ConstDef.IDL_FUN_BANDDECOMPOSE + ",'" + _GF3Polarity + "','" + outDir + "'";
                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                //逐波段均值区域统计
                string[] fBands = Directory.GetFiles(outDir, "*.tif");
                string outMeanDir = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString())+"\\";
                if (!Directory.Exists(outMeanDir))
                {
                    Directory.CreateDirectory(outMeanDir);
                }
                foreach (string band in fBands)
                {
                    string bandName = new FileInfo(band).Name;
                    string bandMean = System.IO.Path.Combine(outMeanDir, bandName.Insert(bandName.LastIndexOf("."), "_Mean"));
                    BLL.EnviVars.instance.GpExecutor.ZonalStatistics(_GF1Segment, "FID", band, "MEAN", bandMean, out msg);
                }
                //波段组合
                _GF3Mean = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".tif");
                cmd = BLL.ConstDef.IDL_FUN_BANDCOMPOSE + ",'" + outMeanDir + "','" + _GF3Mean + "'";
                BLL.EnviVars.instance.IdlModel.Execute(cmd);

                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return true;
            }
        }

        private void Sample2Shp()
        {
 
        }
        /// <summary>
        /// 图斑尺度分类
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SVMFeature(out string msg)
        {
            try
            {
                _classRule = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "rule_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                _classFeature = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "feature_" + DateTime.Now.ToFileTime().ToString() + ".tif");
                if (!LoadROI(_segmentROI, out msg))
                    return false;
                string segmentROI = CreateShpByROI();
                if (string.IsNullOrEmpty(segmentROI))
                {
                    msg = "create Shp by sample failed!";
                    return false;
                }

                string cmd = BLL.ConstDef.IDL_FUN_SVM + ",'" + _GF3Mean + "','" + _classFeature + "','" +
                    segmentROI + "','" + _classRule + "'";

                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                BLL.EnviVars.instance.IdlModel.Distroy();
                return true;
            }
            catch (Exception ex )
            {
                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 像元尺度分类
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SVMPixel(out string msg)
        {
            try
            {
                string rule = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "rule_"+DateTime.Now.ToFileTime().ToString() + ".tif");
                _classPixel = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "pixel_" + DateTime.Now.ToFileTime().ToString() + ".tif");

                if (!LoadROI(_pixelROI, out msg))
                    return false;
                string pixelROI = CreateShpByROI();
                string cmd = BLL.ConstDef.IDL_FUN_SVM + ",'" + _GF3Polarity + "','" + _classPixel + "','" +
                    pixelROI + "','" + rule + "'";

                BLL.EnviVars.instance.IdlModel.Execute(cmd);

                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
        public bool Entropy()
        {
            _entropy = System.IO.Path.Combine(BLL.ConstDef.PATH_TEMP, "entropy_" + DateTime.Now.ToFileTime().ToString() + ".tif");
            string cmd = BLL.ConstDef.IDL_FUN_ENTROPY + ",'" + _classRule + "','" + _entropy + "'";

            BLL.EnviVars.instance.IdlModel.Execute(cmd);
            return true;
        }
        /// <summary>
        /// 混合图斑分类修正
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ClassMerge()
        {
            //string inFiles = _entropy+ "," + _classPixel+ "," + _classFeature;
            //string exp = "(b1 gt 1.2) * b2 + (b1 le 1.2) * b3";
            //string cmd = BLL.ConstDef.IDL_FUN_BANDMATH + ",'" + inFiles + "','" + _class + "','" + exp + "'";
            //BLL.EnviVars.instance.IdlModel.Execute(cmd);
            string expression = "Con([entropy] > " + _entropyT +",[pixel],[feature])";
            try
            {
                IMapAlgebraOp pRSalgebra = new RasterMapAlgebraOpClass();
                pRSalgebra.BindRaster(EngineAPI.OpenRasterFile(_entropy) as IGeoDataset, "entropy");
                pRSalgebra.BindRaster(EngineAPI.OpenRasterFile(_classPixel) as IGeoDataset, "pixel");
                pRSalgebra.BindRaster(EngineAPI.OpenRasterFile(_classFeature) as IGeoDataset, "feature");

                IGeoDataset resDataset = pRSalgebra.Execute(expression);
                ISaveAs pSaveAs = resDataset as ISaveAs;
                if (File.Exists(_class))
                {
                    File.Delete(_class);
                }
                FileInfo fInfo = new FileInfo(_class);
                IWorkspaceFactory pWKSF03 = new RasterWorkspaceFactoryClass();
                IWorkspace pWorkspace03 = pWKSF03.OpenFromFile(fInfo.DirectoryName, 0);
                if (fInfo.Extension == ".img")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "IMAGINE Image");
                }
                if (fInfo.Extension == ".tif")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "TIFF");
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }


        private bool LoadROI( string inSample,out string msg)
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
                        Log.WriteLog(typeof(GF3Classification), ex);
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
                Log.WriteLog(typeof(GF3Classification), ex);
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
