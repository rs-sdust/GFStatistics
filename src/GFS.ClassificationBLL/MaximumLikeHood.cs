using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFS.Commands;
using ESRI.ArcGIS.Geometry;
using System.Xml;
using System.IO;
using ESRI.ArcGIS.Display;
using GFS.Common;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
using ESRI.ArcGIS.Geodatabase;
using System.Drawing;

namespace GFS.ClassificationBLL
{
    public class MaximumLikeHood
    {
        private string inRaster = string.Empty;
        private string inSample = string.Empty;
        private string inShp = string.Empty;
        private string outRaster = string.Empty;

        //ROI layer list
        private Dictionary<int, ROILayerClass> roiLayerDic = new Dictionary<int, ROILayerClass>();
        public Dictionary<int, ROILayerClass> RoiLayerDic
        {
            get { return this.roiLayerDic; }
        }
        //record the spatial reference of ROI file
        private ISpatialReference spatialReference = null;
        public MaximumLikeHood(string inRaster,string inShp,string outRaster)
        {
            this.inRaster = inRaster.TrimEnd();
            this.inSample = inShp.TrimEnd();
            this.outRaster = outRaster.TrimEnd();
        }

        public void Execute()
        {
            try
            {
                string msg = string.Empty;
                CheckPara();
                if (!LoadROI(out msg))
                    throw new Exception(msg);
                inShp = CreateShpByROI();
                if (string.IsNullOrEmpty(inShp))
                    throw new Exception("ROI Convert Error!");
                string cmd = ConstDef.IDL_FUN_MAXIMUM + ",'" + inRaster + "','"
                    + inShp + "','" + outRaster + "'";
                EnviVars.instance.IdlModel.Execute(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        private void CheckPara()
        {
            if (string.IsNullOrEmpty(inRaster))
                throw new Exception("输入影像为空！");
            if (string.IsNullOrEmpty(inSample))
                throw new Exception("输入样本为空！");
            if (string.IsNullOrEmpty(outRaster))
                throw new Exception("输出结果为空！");
        }

        private bool LoadROI(out string msg)
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
                        Log.WriteLog(typeof(MaximumLikeHood), ex);
                        result = false;
                    }
                    finally
                    {
                        if(featureClass!=null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(featureClass);
                    }

                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(MaximumLikeHood), ex);
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
