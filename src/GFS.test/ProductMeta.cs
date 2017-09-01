using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using GFS.BLL;
using ESRI.ArcGIS.Geometry;
using System.Xml;

namespace ProductionMeta
{
    class StructProMeta
    {
        public string ProductID;
        public string ClassName = "高分农业统计产品";
        public string Name;
        public string Format;
        public string Unit = "农业调查子系统";
        public string SatelliteSource;
        public string Resolution;
        public string CoordinateSystem;
        public string MapProjection;
        public string UpperLeftLat;
        public string UpperLeftLon;
        public string UpperRightLat;
        public string UpperRightLon;
        public string LowerRightLat;
        public string LowerRightLon;
        public string LowerLeftLat;
        public string LowerLeftLon;
        public string Region;
        public string ProductionDate;
        public string Description;
    }
    public class ProductMeta
    {
        private string _file = string.Empty;
        private string _source = string.Empty;
        private string _region = string.Empty;
        public ProductMeta(string file,string source,string region)
        {
            this._file = file;
            this._source = source;
            this._region = region;
        }
        public bool WriteMeta()
        {
            StructProMeta meta=new StructProMeta();
            meta.ProductID = DateTime.Now.ToFileTime().ToString();
            FileInfo fInfo = new FileInfo(_file);
            meta.Name = fInfo.Name.Substring(0,fInfo.Name.LastIndexOf("."));
            meta.Format = fInfo.Extension.Substring(1,fInfo.Extension.Length-1);
            meta.SatelliteSource = _source;
            meta.Region = _region;
            meta.ProductionDate = fInfo.CreationTime.ToString("yyyyMMdd");
            this.GetRasterInfo(_file, ref meta);
            string metaFile = _file.Substring(0, _file.LastIndexOf(".")) + ".xml";
            this.Write2File(metaFile, meta);
            return true;
        }
        private void GetRasterInfo(string file, ref StructProMeta meta)
        {
            IRasterLayer pRasterLayer=null;
            ISpatialReference spatialReferenceInfo = null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(_file);
                IRaster pRaster = pRasterLayer.Raster;
                IRasterProps pRasterProps = pRaster as IRasterProps;
                meta.Resolution = pRasterProps.MeanCellSize().X.ToString("f1");
                spatialReferenceInfo = pRasterProps.SpatialReference;
                meta.CoordinateSystem = spatialReferenceInfo.Name;
                if (spatialReferenceInfo is IProjectedCoordinateSystem)
                {
                    IProjectedCoordinateSystem projectedCoordinateSystem = spatialReferenceInfo as IProjectedCoordinateSystem;
                    meta.MapProjection = projectedCoordinateSystem.Projection.Name;
                    IPoint point = pRasterProps.Extent.UpperLeft;
                    point.Project(projectedCoordinateSystem.GeographicCoordinateSystem);
                    meta.UpperLeftLat = point.Y.ToString();
                    meta.UpperLeftLon = point.X.ToString();
                    point = pRasterProps.Extent.UpperRight;
                    point.Project(projectedCoordinateSystem.GeographicCoordinateSystem);
                    meta.UpperRightLat = point.Y.ToString();
                    meta.UpperRightLon = point.X.ToString();
                    point = pRasterProps.Extent.LowerRight;
                    point.Project(projectedCoordinateSystem.GeographicCoordinateSystem);
                    meta.LowerRightLat = point.Y.ToString();
                    meta.LowerRightLon = point.X.ToString();
                    point = pRasterProps.Extent.LowerLeft;
                    point.Project(projectedCoordinateSystem.GeographicCoordinateSystem);
                    meta.LowerLeftLat = point.Y.ToString();
                    meta.LowerLeftLon = point.X.ToString();

                }

              
            }
            catch (Exception)
            { }
        }

        private void Write2File(string file, StructProMeta meta)
        {
                XmlTextWriter xmlWriter = null;
                try
                {
                    xmlWriter = new XmlTextWriter(file, Encoding.UTF8);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Production")
                        ;
                    xmlWriter.WriteStartElement("ProductID");
                    xmlWriter.WriteString(meta.ProductID);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ClassName");
                    xmlWriter.WriteString(meta.ClassName);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Name");
                    xmlWriter.WriteString(meta.Name);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Format");
                    xmlWriter.WriteString(meta.Format);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Unit");
                    xmlWriter.WriteString(meta.Unit);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("SatelliteSource");
                    xmlWriter.WriteString(meta.SatelliteSource);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Resolution");
                    xmlWriter.WriteString(meta.Resolution);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("CoordinateSystem");
                    xmlWriter.WriteString(meta.CoordinateSystem);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("MapProjection");
                    xmlWriter.WriteString(meta.MapProjection);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("UpperLeftLat");
                    xmlWriter.WriteString(meta.UpperLeftLat);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("UpperLeftLon");
                    xmlWriter.WriteString(meta.UpperLeftLon);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("UpperRightLat");
                    xmlWriter.WriteString(meta.UpperRightLat);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("UpperRightLon");
                    xmlWriter.WriteString(meta.UpperRightLon);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("LowerRightLat");
                    xmlWriter.WriteString(meta.LowerRightLat);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("LowerRightLon");
                    xmlWriter.WriteString(meta.LowerRightLon);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("LowerLeftLat");
                    xmlWriter.WriteString(meta.LowerLeftLat);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("LowerLeftLon");
                    xmlWriter.WriteString(meta.LowerLeftLon);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Region");
                    xmlWriter.WriteString(meta.Region);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ProductionDate");
                    xmlWriter.WriteString(meta.ProductionDate);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Description");
                    xmlWriter.WriteString(meta.Description);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();

                }
                catch (Exception ex)
                {
                    GFS.BLL.Log.WriteLog(typeof(TaskHistory), ex);
                }
                finally
                {
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
        }

    }
}
