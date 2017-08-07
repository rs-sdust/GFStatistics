// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmBase.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Base Form of Custom OpenFile Dialog</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmBase.
    /// </summary>
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Gets the data image list.
        /// </summary>
        /// <value>The data image list.</value>
        public ImageList DataImageList
        {
            get
            {
                return this.imageList1;
            }
        }

        /// <summary>
        /// Gets the layer image list.
        /// </summary>
        /// <value>The layer image list.</value>
        public ImageList LayerImageList
        {
            get
            {
                return this.imageList2;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmBase" /> class.
        /// </summary>
        public frmBase()
        {
            InitializeComponent();
        }
    }
}