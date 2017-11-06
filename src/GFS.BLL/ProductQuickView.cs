// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 10-19-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 10-23-2017
// ***********************************************************************
// <copyright file="ProductQuickView.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>生成产品快视图</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using GFS.Common;
//using GFS.BLL;
using System.Drawing;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;

namespace GFS.BLL
{
    public class ProductQuickView
    {

        string _SourceFile = string.Empty;
        string _OutFile = string.Empty;
        ExportManager _ExportMan = null;
        public ProductQuickView(string inFile)
        {
            _SourceFile = inFile;
            _OutFile = inFile.Substring(0,inFile.LastIndexOf("."))+".jpg";
            _ExportMan = new ExportManager();
        }

        public void  Create()
        {
            IMap pMap =null;
            IFeatureLayer pFeatureLayer = null;
            IRasterLayer pRasterLayer = null;
            try
            {
                if (_SourceFile.EndsWith(".shp"))
                {
                    pMap = new MapClass();
                    pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = EngineAPI.OpenFeatureClass(_SourceFile);
                    pMap.AddLayer(pFeatureLayer);
                    _ExportMan.ExportMapExtent(pMap as IActiveView, new Size(512, 0), _OutFile, 300);
                }
                else
                {
                    pMap = new MapClass();
                    pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromFilePath(_SourceFile);
                    pMap.AddLayer(pRasterLayer);
                    IRasterProps pRasterProps = pRasterLayer.Raster as IRasterProps;
                    int width = pRasterProps.Width/10;
                    _ExportMan.ExportMapExtent(pMap as IActiveView, new Size(width, 0), _OutFile, 300);
 
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(ProductQuickView), ex);
            }
            finally
            {
                if (pMap != null)
                    Marshal.ReleaseComObject(pMap);
                if (pFeatureLayer != null)
                    Marshal.ReleaseComObject(pFeatureLayer);
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }
    }
}
