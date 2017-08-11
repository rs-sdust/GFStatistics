// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmLayerTable.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
//using SDJT.Sys;
using ESRI.ArcGIS.Geodatabase;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class frmLayerTable.
    /// </summary>
    public partial class frmLayerTable : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// The _p ft layer
        /// </summary>
        private IFeatureLayer _pFtLayer;

        /// <summary>
        /// The _p map
        /// </summary>
        private IMap _pMap;

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "属性表： ";

        /// <summary>
        /// Gets the grid control.
        /// </summary>
        /// <value>The grid control.</value>
        public CtrlPageGridControl GridControl
        {
            get
            { return this.ctrlPageGridControl1; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmLayerTable"/> class.
        /// </summary>
        public frmLayerTable()
        {
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmLayerTable"/> class.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        /// <param name="pFtLayer">The p ft layer.</param>
        public frmLayerTable(IMap pMap, IFeatureLayer pFtLayer)
        {
            this.InitializeComponent();
            this._pFtLayer = pFtLayer;
            this._pMap = pMap;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Handles the Load event of the frmLayerTable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmLayerTable_Load(object sender, EventArgs e)
        {
            this.Text = MSG01 + this._pFtLayer.Name;
            if (this._pFtLayer.FeatureClass != null)
            {
                this.ctrlPageGridControl1._pFtLayer = this._pFtLayer;
                this.ctrlPageGridControl1.Initialize(this._pFtLayer.FeatureClass as ITable, null, this._pMap);
                //this.ctrlPageGridControl1.gridView.Columns[this._pFtLayer.FeatureClass.OIDFieldName].Visible = false;
            }
        }
    }
}