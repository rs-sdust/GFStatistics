// ***********************************************************************
// Assembly         : SDJT.System
// Author           : YXQ
// Created          : 04-19-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-25-2016
// ***********************************************************************
// <copyright file="CurrentLayer.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class CurrentLayer.
    /// </summary>
    public class CurrentLayer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the layer.
        /// </summary>
        /// <value>The layer.</value>
        public ILayer Layer
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Initializes static members of the <see cref="CurrentLayer" /> class.
        /// </summary>
        static CurrentLayer()
        {
        }
    }
}
