// ***********************************************************************
// Assembly         : SDJT.Common
// Author           : Ricker Yan
// Created          : 03-30-2016
// Last Modified By : Ricker Yan
// Last Modified On : 04-06-2016
// ***********************************************************************
// <copyright file="DataType.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Enum DataType</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The Common namespace.
/// </summary>
namespace GFS.Common
{
    /// <summary>
    /// Enum DataType
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// The SHP
        /// </summary>
        shp = 1,
        /// <summary>
        /// The MDB
        /// </summary>
        mdb,
        /// <summary>
        /// The GDB
        /// </summary>
        gdb = 4,
        /// <summary>
        /// The sde
        /// </summary>
        sde = 8,
        /// <summary>
        /// All
        /// </summary>
        all = 16,
        /// <summary>
        /// The cad
        /// </summary>
        cad = 32,
        /// <summary>
        /// The raster
        /// </summary>
        raster = 64,
        /// <summary>
        /// The coverage
        /// </summary>
        coverage = 128,
        /// <summary>
        /// The e00
        /// </summary>
        e00 = 256
    }
}
