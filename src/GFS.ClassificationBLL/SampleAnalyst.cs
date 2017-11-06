// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-15-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="SampleAnalyst.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>sample analyst business code</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFS.Commands;
using System.IO;
using System.Xml;
using GFS.Common;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
using ESRI.ArcGIS.Geodatabase;
using System.Data;

namespace GFS.ClassificationBLL
{
    public class SampleAnalyst
    {
        //Raster file path
        public string rasterFile = string.Empty;
        //ROI file path
        public string roiFile = string.Empty;
        //ROI layer list
        private Dictionary<int, ROILayerClass> roiLayerDic = new Dictionary<int, ROILayerClass>();
        public Dictionary<int, ROILayerClass> RoiLayerDic
        {
            get { return this.roiLayerDic; }
        }
        //record the spatial reference of ROI file
        private ISpatialReference spatialReference = null;
        //Vector file created by ROI file
        private string shpROI = string.Empty;

        public SampleAnalyst()
        {
        }

        /// <summary>
        /// run the sample analyst model
        /// </summary>
        /// <returns></returns>
        public DataTable Execute(List<string> classList)
        {
            try
            {
                shpROI = CreateShpByROI(classList);
                if (string.IsNullOrEmpty(shpROI))
                {
                    return null;
                }
                return EnviVars.instance.GpExecutor.ZonalStatisticsAsTable(shpROI, rasterFile, "CLASS_NAME");
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(SampleAnalyst), ex);
                return null;
            }
            finally
            { }
        }
        //
        //Load ROI file.read name and element only
        //
        public void LoadROI()
        {
            if (roiLayerDic.Count > 0)
                roiLayerDic.Clear();
            if (!string.IsNullOrEmpty(roiFile) && File.Exists(roiFile))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(roiFile);
                XmlNode xmlNode = xmlDocument.SelectSingleNode("RegionsOfInterest");
                if (xmlNode == null)
                {
                    return;
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
                    //int red = CommonAPI.ConvertToInt(array[0]);
                    //int green = CommonAPI.ConvertToInt(array[1]);
                    //int blue = CommonAPI.ConvertToInt(array[2]);
                    //IRgbColor color = new RgbColorClass
                    //{
                    //    Red = red,
                    //    Green = green,
                    //    Blue = blue
                    //};
                    ROILayerClass rOILayerClass = new ROILayerClass();
                    rOILayerClass.ID = ((roiLayerDic.Keys.Count == 0) ? 1 : (roiLayerDic.Keys.Max() + 1));
                    rOILayerClass.Name = value;
                    //rOILayerClass.Color = color;
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

        }
        //
        //Create vector file by ROI
        //
        public string CreateShpByROI(List<string> classList)
        {
            string empty = string.Empty;
            List<ROIGeometry> roiGeometryList = new List<ROIGeometry>();

            object missing = Type.Missing;
            foreach (KeyValuePair<int, ROILayerClass> current in roiLayerDic)
            {
                foreach(string name in classList)
                {
                    if(current.Value.Name == name)
                    {
                        IGeometryCollection geometryCollection = new PolygonClass();
                        foreach (ROIElementClass current2 in current.Value.ElementList)
                        {
                            if (current2.Checked)
                            {
                                geometryCollection.AddGeometryCollection(current2.Element.Geometry as IGeometryCollection);
                            }
                        }
                        if (geometryCollection.GeometryCount > 0)
                        {
                            IGeometry geometry = geometryCollection as IGeometry;
                            geometry.SpatialReference = spatialReference;
                            if (geometry != null)
                            {
                                roiGeometryList.Add(new ROIGeometry(name,geometry));
                                //if (!ROIManager.instance.GpExecutor.CreateShpFile(geometry, out empty))
                                //{
                                //    empty = string.Empty;
                                //}
                            }
                        }
                    }

                }
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
                                pRow.Store();
                            }
                            rowIndex++;
                            //IFieldEdit field = feature as IField;
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(typeof(SampleAnalyst),ex);
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
                Log.WriteLog(typeof(SampleAnalyst), ex);
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
            fieldsEdit.AddField(field1);

            return requiredFields;
        }
    }
}
