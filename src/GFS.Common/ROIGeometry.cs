// ***********************************************************************
// Assembly         : GFS.Common
// Author           : Ricker Yan
// Created          : 08-16-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-16-2017
// ***********************************************************************
// <copyright file="ROIGeometry.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>record ROI name/elements's geomerty</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace GFS.Common
{
    public class ROIGeometry
    {
        public string name
        { get; set; }
        public IGeometry geometry
        { get; set; }
        public ROIGeometry(string name,IGeometry geometry)
        {
            this.name = name;
            this.geometry=geometry;
        }
    }
}
