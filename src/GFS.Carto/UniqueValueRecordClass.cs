// ***********************************************************************
// Assembly         : SDJT.Carto
// Author           : Ricker Yan
// Created          : 04-19-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="UniqueValueRecordClass.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFS.Common;

/// <summary>
/// The Carto namespace.
/// </summary>
namespace GFS.Carto
{
    /// <summary>
    /// Class 唯一值渲染.
    /// </summary>
    public class UniqueValueRecordClass
    {
        /// <summary>
        /// The value
        /// </summary>
        private string value;

        /// <summary>
        /// The label
        /// </summary>
        private string label = "";

        /// <summary>
        /// The symbol
        /// </summary>
        private ISymbol symbol;

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        public System.Drawing.Bitmap Bitmap
        {
            get
            {
                return CommonAPI.PreviewItem(this.symbol, 60, 20);
            }
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
            }
        }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public ISymbol Symbol
        {
            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueValueRecordClass"/> class.
        /// </summary>
        public UniqueValueRecordClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueValueRecordClass"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <param name="label">The label.</param>
        public UniqueValueRecordClass(ISymbol symbol, string value, string label)
        {
            this.symbol = symbol;
            this.value = value;
            this.label = label;
        }
    }
}
