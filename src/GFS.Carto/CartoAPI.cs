// ***********************************************************************
// Assembly         : SDJT.Carto
// Author           : YXQ
// Created          : 04-19-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="CartoAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// Enum 图层类型
    /// </summary>
    public enum LayerType
    {
        /// <summary>
        /// The feature layer
        /// </summary>
        FeatureLayer,
        /// <summary>
        /// The raster layer
        /// </summary>
        RasterLayer
    }

    /// <summary>
    /// Enum 色彩模式
    /// </summary>
    public enum RandomColorStatus
    {
        /// <summary>
        /// The HSV color
        /// </summary>
        HsvColor,
        /// <summary>
        /// The color ramp
        /// </summary>
        ColorRamp
    }

    /// <summary>
    /// Enum 首要色度条
    /// </summary>
    public enum ColorRampsPriority
    {
        /// <summary>
        /// The random color ramps
        /// </summary>
        RandomColorRamps,
        /// <summary>
        /// The gradual color ramps
        /// </summary>
        GradualColorRamps
    }
}
