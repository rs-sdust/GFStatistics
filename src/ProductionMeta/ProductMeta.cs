using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProductionMeta
{
    struct StructProMeta
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
        public ProductMeta(string file,string source)
        {
            this._file = file;
            this._source = source;
        }
        public bool WriteMeta()
        {
            StructProMeta meta;
            meta.ProductID = DateTime.Now.ToFileTime().ToString();
            FileInfo fInfo = new FileInfo(_file);
            meta.Name = fInfo.Name;
            meta.Format = fInfo.Extension;
            meta.SatelliteSource = _source;

            return true;
        }
        private void GetRasterInfo(string file, ref StructProMeta meta)
        {
            IRasterLayer pRasterLayer=null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(rasterFile);
                bandCount = pRasterLayer.BandCount;
                IRaster pRaster = pRasterLayer.Raster;
                IRasterProps pRasterProps = pRaster as IRasterProps;
                pixelType = MapAPI.GetPixelType(pRasterProps);
                return true;
            }
        }

    }
}
