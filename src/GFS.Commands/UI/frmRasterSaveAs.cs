// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmRasterSaveAs.cs" company="SDJT">
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
using ESRI.ArcGIS.Geodatabase;
using SDJT.Sys;
using ESRI.ArcGIS.DataSourcesRaster;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmRasterSaveAs.
    /// </summary>
    public partial class frmRasterSaveAs : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The m_save as manager
        /// </summary>
        private RasterSaveAsManager m_saveAsManager = null;

        /// <summary>
        /// The m_raster
        /// </summary>
        private IRaster m_raster = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmRasterSaveAs"/> class.
        /// </summary>
        /// <param name="raster">The raster.</param>
        public frmRasterSaveAs(IRaster raster)
        {
            this.InitializeComponent();
            this.m_saveAsManager = new RasterSaveAsManager(this);
            this.m_raster = raster;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
        }

        /// <summary>
        /// Handles the Load event of the frmRasterSaveAs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmRasterSaveAs_Load(object sender, EventArgs e)
        {
            this.m_saveAsManager.Init(this.m_raster, this.cmbOutputType, this.cmbPixelType, this.cmbResamplingType, this.checkedCmbBand);
        }

        /// <summary>
        /// Handles the Click event of the btnOutputPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            this.m_saveAsManager.SetOutputPath(this.btnOutputPath);
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_saveAsManager.SaveAs(false, rstRepresentationType.DT_ATHEMATIC, true))
            {
                base.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /// <summary>
        /// Handles the HelpButtonClicked event of the frmRasterSaveAs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void frmRasterSaveAs_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            //HelpManager.ShowHelp(this);
        }
    }
}