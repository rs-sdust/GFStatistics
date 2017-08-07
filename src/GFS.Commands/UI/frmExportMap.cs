// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmExportMap.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : Export Map</summary>
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
using SDJT.Const;
using SDJT.Sys;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmExportMap.
    /// </summary>
    public partial class frmExportMap : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The _active view
        /// </summary>
        private IActiveView _activeView = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmExportMap" /> class.
        /// </summary>
        /// <param name="activeView">The active view.</param>
        public frmExportMap(IActiveView activeView)
        {
            InitializeComponent();
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
            this._activeView = activeView;
        }

        /// <summary>
        /// Handles the Click event of the btnFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Title = AppMessage.MSG0028;
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "TIFF (*.tif)|*.tif|JPEG (*.jpg)|*.jpg|BMP (*.BMP)|*.bmp|PNG (*.png)|*.png";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string text = this.txtFile.Text;
            if (string.IsNullOrEmpty(text))
            {
                XtraMessageBox.Show(AppMessage.MSG0028 + "！", AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
            else
            {
                double num = Convert.ToDouble(this.spinDpi.Value);
                if (num > 300.0)
                {
                    XtraMessageBox.Show(AppMessage.MSG0027, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
                else
                {
                    //Logger logger = new Logger();
                    int width = Convert.ToInt32(this.txtWidth.Text);
                    int height = Convert.ToInt32(this.txtHeight.Text);
                    ExportManager exportManager = new ExportManager();
                    string text2 = AppMessage.MSG0029;
                    if (!exportManager.ExportMapExtent(this._activeView, new Size(width, height), text, num))
                    {
                        text2 = AppMessage.MSG0030;
                        //logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, new Exception(text2));
                    }
                    else
                    {
                        //logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                    }
                    XtraMessageBox.Show(text2, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    base.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtWidth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtWidth_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtWidth.Text == "")
                return;
            int width = Convert.ToInt32(this.txtWidth.Text);
            int height = (int)((double)width* this._activeView.Extent.Height / this._activeView.Extent.Width);
            this.txtHeight.Text = height.ToString();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            base.Close();
        }
    }
}