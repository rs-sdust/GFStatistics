// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 09-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-21-2017
// ***********************************************************************
// <copyright file="BaseMap.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>加载网络底图</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.Geometry;

/// <summary>
/// The BLL namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Enum BaseMapLayer
    /// </summary>
    public enum BaseMapLayer
    {
        /// <summary>
        /// The imagery
        /// </summary>
        Imagery,
        /// <summary>
        /// The china poi
        /// </summary>
        ChinaPoi
    }
    /// <summary>
    /// Class BaseMap.
    /// </summary>
    public class BaseMap
    {

        /// <summary>
        /// Adds the specified base map.
        /// </summary>
        /// <param name="baseMap">The base map.</param>
        public static void Add(BaseMapLayer baseMap)
        {
             string url ="";
             string name = "";
            try
            {

                switch (baseMap)
                {
                    case BaseMapLayer.Imagery:
                        url = "http://services.arcgisonline.com/arcgis/rest/services/ESRI_Imagery_World_2D/MapServer";
                        name = "影像图";
                        break;
                    default:
                        url = "http://cache1.arcgisonline.cn/arcgis/rest/services/ChinaOnlineCommunity/MapServer";
                        name = "街区图";
                        break;
                }
                if (BaseMap.IsExists(name))
                    return;
                MapServerRESTLayer restLayer = new MapServerRESTLayer();
                restLayer.Connect(url);
                //Add the layer to the map.
                ILayer layer = restLayer as ILayer;
                layer.Name = name;
                EnviVars.instance.MapControl.AddLayer(layer,EnviVars.instance.MapControl.LayerCount);
                Zom2China();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Zom2s the china.
        /// </summary>
        private static void Zom2China()
        {
            IEnvelope extent = new EnvelopeClass();
            extent.SpatialReference = EnviVars.instance.MapControl.Map.SpatialReference;
            extent.XMin = 5368146.9472567858;
            extent.XMax = 18393610.498183895;
            extent.YMin = 936675.63399303285;
            extent.YMax = 7223188.2070181808;
            EnviVars.instance.MapControl.Extent = extent;
        }
        /// <summary>
        /// Determines whether the specified layer name is exists.
        /// </summary>
        /// <param name="layerName">Name of the layer.</param>
        /// <returns><c>true</c> if the specified layer name is exists; otherwise, <c>false</c>.</returns>
        public static bool IsExists(string layerName)
        {
            int lyrCount = EnviVars.instance.MapControl.LayerCount ;
            if (lyrCount> 0)
            {
                for(int i=0;i<lyrCount;i++)
                {
                    if (EnviVars.instance.MapControl.get_Layer(i).Name == layerName)
                    { 
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
    }
}
