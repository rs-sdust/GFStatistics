// ***********************************************************************
// Assembly         : SDJT.Carto
// Author           : Ricker Yan
// Created          : 04-19-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="SymbleAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Display;
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
    /// Class SymbleAPI.
    /// </summary>
    public class SymbleAPI
    {
        /// <summary>
        /// Converts  color to  Icolor .
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>IColor.</returns>
        public static IColor ConvertColorToIColor(System.Drawing.Color color)
        {
            return new RgbColorClass
            {
                Red = (int)color.R,
                Green = (int)color.G,
                Blue = (int)color.B
            };
        }

        /// <summary>
        /// Creates the color from the RGB.
        /// </summary>
        /// <param name="myRed">My red.</param>
        /// <param name="myGreen">My green.</param>
        /// <param name="myBlue">My blue.</param>
        /// <returns>IRgbColor.</returns>
        public static IRgbColor CreateRGBColor(int myRed, int myGreen, int myBlue)
        {
            return new RgbColorClass
            {
                Red = myRed,
                Green = myGreen,
                Blue = myBlue
            };
        }
    }
}
