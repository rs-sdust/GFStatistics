// ***********************************************************************
// Assembly         : SDJT.Carto
// Author           : Ricker Yan
// Created          : 04-19-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="ClassifyRecordClass.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.Display;
using GFS.Common;
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
    /// Class 分类渲染.
    /// </summary>
    public class ClassifyRecordClass
    {
        /// <summary>
        /// The break value
        /// </summary>
        private double breakValue;

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
        /// Gets or sets the break value.
        /// </summary>
        /// <value>The break value.</value>
        public double BreakValue
        {
            get
            {
                return this.breakValue;
            }
            set
            {
                this.breakValue = value;
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
        /// Initializes a new instance of the <see cref="ClassifyRecordClass"/> class.
        /// </summary>
        public ClassifyRecordClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifyRecordClass"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="breakValue">The break value.</param>
        /// <param name="label">The label.</param>
        public ClassifyRecordClass(ISymbol symbol, double breakValue, string label)
        {
            this.symbol = symbol;
            this.breakValue = breakValue;
            this.label = label;
        }
    }
}
