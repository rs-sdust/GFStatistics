// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-11-2017
// ***********************************************************************
// <copyright file="ROILayerClass.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>record ROI id\name\color\elements</summary>
// ***********************************************************************
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;

namespace GFS.Commands
{
    public class ROILayerClass
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<ROIElementClass> ElementList
        {
            get;
            set;
        }

        public IColor Color
        {
            get;
            set;
        }
    }
}
