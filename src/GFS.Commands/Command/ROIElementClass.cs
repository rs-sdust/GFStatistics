// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-11-2017
// ***********************************************************************
// <copyright file="ROIElementClass.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>record ROI element</summary>
// ***********************************************************************
using ESRI.ArcGIS.Carto;
using System;

namespace GFS.Commands
{
    public class ROIElementClass
    {
        public IElement Element
        {
            get;
            set;
        }

        public bool Checked
        {
            get;
            set;
        }
    }
}
