// ***********************************************************************
// Assembly         : SDJT.Carto
// Author           : Ricker Yan
// Created          : 04-19-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-15-2016
// ***********************************************************************
// <copyright file="LayerAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The Carto namespace.
/// </summary>
namespace GFS.Carto
{
    /// <summary>
    /// Class LayerAPI.
    /// </summary>
    public class LayerAPI
    {
        /// <summary>
        /// Adds the layer lable.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        /// <param name="layer">The layer.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="pTextSymbol">The p text symbol.</param>
        /// <param name="dRefScale">The d reference scale.</param>
        public static void AddLayerLable(IMap pMap, ILayer layer, string fieldName, ITextSymbol pTextSymbol, double dRefScale)
        {
            IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
            IAnnotateLayerPropertiesCollection annotationProperties = geoFeatureLayer.AnnotationProperties;
            annotationProperties.Clear();
            ILineLabelPosition lineLabelPosition = new LineLabelPositionClass
            {
                Parallel = false,
                Perpendicular = false,
                InLine = true,
                OnTop = true,
                Above = false,
                Horizontal = true
            };
            LineLabelPlacementPrioritiesClass lineLabelPlacementPrioritiesClass = new LineLabelPlacementPrioritiesClass();
            lineLabelPlacementPrioritiesClass.AboveStart = 5;
            lineLabelPlacementPrioritiesClass.BelowAfter = 4;
            IBasicOverposterLayerProperties basicOverposterLayerProperties = new BasicOverposterLayerPropertiesClass
            {
                LineLabelPosition = lineLabelPosition
            };
            ILabelEngineLayerProperties labelEngineLayerProperties;
            if (pMap.AnnotationEngine.Name.Equals("Esri Maplex Label Engine", System.StringComparison.CurrentCultureIgnoreCase))
            {
                labelEngineLayerProperties = new MaplexLabelEngineLayerPropertiesClass();
                IMaplexOverposterLayerProperties maplexOverposterLayerProperties = new MaplexOverposterLayerPropertiesClass();
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                switch (featureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        maplexOverposterLayerProperties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                        maplexOverposterLayerProperties.PointPlacementMethod = esriMaplexPointPlacementMethod.esriMaplexAroundPoint;
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        maplexOverposterLayerProperties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                        maplexOverposterLayerProperties.LinePlacementMethod = esriMaplexLinePlacementMethod.esriMaplexCenteredStraightOnLine;
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        maplexOverposterLayerProperties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
                        maplexOverposterLayerProperties.PolygonPlacementMethod = esriMaplexPolygonPlacementMethod.esriMaplexHorizontalInPolygon;
                        break;
                }
                maplexOverposterLayerProperties.CanRemoveOverlappingLabel = false;
                maplexOverposterLayerProperties.RepeatLabel = false;
                (labelEngineLayerProperties as ILabelEngineLayerProperties2).OverposterLayerProperties = (maplexOverposterLayerProperties as IOverposterLayerProperties);
                IMapOverposter mapOverposter = pMap as IMapOverposter;
                IOverposterProperties overposterProperties = mapOverposter.OverposterProperties;
                IMaplexOverposterProperties maplexOverposterProperties = overposterProperties as IMaplexOverposterProperties;
                maplexOverposterProperties.LabelLargestPolygon = false;
            }
            else
            {
                labelEngineLayerProperties = new LabelEngineLayerPropertiesClass();
                labelEngineLayerProperties.BasicOverposterLayerProperties = basicOverposterLayerProperties;
            }
            labelEngineLayerProperties.Symbol = pTextSymbol;
            labelEngineLayerProperties.IsExpressionSimple = true;
            labelEngineLayerProperties.Expression = "[" + fieldName + "]";
            IAnnotateLayerProperties item = labelEngineLayerProperties as IAnnotateLayerProperties;
            if (dRefScale != -1.0)
            {
                IAnnotateLayerTransformationProperties annotateLayerTransformationProperties = labelEngineLayerProperties as IAnnotateLayerTransformationProperties;
                annotateLayerTransformationProperties.ReferenceScale = dRefScale;
            }
            annotationProperties.Add(item);
            geoFeatureLayer.DisplayAnnotation = true;
        }

        /// <summary>
        /// Gets the layers from map.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        /// <returns>System.Collections.Generic.List&lt;ILayer&gt;.</returns>
        public static System.Collections.Generic.List<ILayer> GetLayersFromMap(IMap pMap)
        {
            IEnumLayer enumLayer = pMap.get_Layers(new UIDClass
            {
                Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}"
            }, true);
            enumLayer.Reset();
            System.Collections.Generic.List<ILayer> list = new System.Collections.Generic.List<ILayer>();
            ILayer item;
            while ((item = enumLayer.Next()) != null)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
