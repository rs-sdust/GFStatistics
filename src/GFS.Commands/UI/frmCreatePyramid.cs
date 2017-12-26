// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : Ricker Yan
// Created          : 04-01-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmCreatePyramid.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : Build pyramids</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geoprocessor;
using System.Text.RegularExpressions;
//using SDJT.Const;
using DevExpress.Utils;
using ESRI.ArcGIS.DataManagementTools;
using GFS.BLL;
//using SDJT.Log;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class frmCreatePyramid.
    /// </summary>
    public partial class frmCreatePyramid : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The default
        /// </summary>
        private const string C_DEFAULT = "DEFAULT";

        /// <summary>
        /// The LZ77
        /// </summary>
        private const string C_LZ77 = "LZ77";

        /// <summary>
        /// The JPEG
        /// </summary>
        private const string C_JPEG = "JPEG";

        /// <summary>
        /// The jpeg_ycbcr
        /// </summary>
        private const string C_JPEG_YCbCr = "JPEG_YCbCr";

        /// <summary>
        /// The none
        /// </summary>
        private const string C_NONE = "NONE";

        /// <summary>
        /// The nearest
        /// </summary>
        private const string C_NEAREST = "NEAREST";

        /// <summary>
        /// The bilinear
        /// </summary>
        private const string C_BILINEAR = "BILINEAR";

        /// <summary>
        /// The cubic
        /// </summary>
        private const string C_CUBIC = "CUBIC";

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "压缩质量值必须为0-100之间的整数值！";

        /// <summary>
        /// The geoProcessor
        /// </summary>
        private Geoprocessor _geoProcessor = null;

        /// <summary>
        /// The raster files
        /// </summary>
        private List<string> m_rasterFiles;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmCreatePyramid" /> class.
        /// </summary>
        /// <param name="rasterFiles">The raster files.</param>
        public frmCreatePyramid(List<string> rasterFiles)
        {
            InitializeComponent();
            this.m_rasterFiles = rasterFiles;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Handles the Load event of the frmCreatePyramid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void frmCreatePyramid_Load(object sender, EventArgs e)
        {
            this.comboBoxEditReSample.Properties.Items.Add("NEAREST");
            this.comboBoxEditReSample.Properties.Items.Add("BILINEAR");
            this.comboBoxEditReSample.Properties.Items.Add("CUBIC");
            this.comboBoxEditReSample.SelectedIndex = 0;
            this.comboBoxEditZip.Properties.Items.Add("DEFAULT");
            this.comboBoxEditZip.Properties.Items.Add("LZ77");
            this.comboBoxEditZip.Properties.Items.Add("JPEG");
            this.comboBoxEditZip.Properties.Items.Add("JPEG_YCbCr");
            this.comboBoxEditZip.Properties.Items.Add("NONE");
            this.comboBoxEditZip.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxEditZip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxEditZip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxEditZip.SelectedItem != null)
            {
                string text = this.comboBoxEditZip.SelectedItem.ToString();
                if (text != null)
                {
                    if (!(text == "DEFAULT"))
                    {
                        if (!(text == "LZ77"))
                        {
                            if (!(text == "JPEG"))
                            {
                                if (!(text == "JPEG_YCbCr"))
                                {
                                    if (text == "NONE")
                                    {
                                        this.spinEditQuality.Enabled = false;
                                    }
                                }
                                else
                                {
                                    this.spinEditQuality.Enabled = true;
                                }
                            }
                            else
                            {
                                this.spinEditQuality.Enabled = true;
                            }
                        }
                        else
                        {
                            this.spinEditQuality.Enabled = false;
                        }
                    }
                    else
                    {
                        this.spinEditQuality.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_rasterFiles != null && this.m_rasterFiles.Count != 0)
            {
                Regex regex = new Regex("^(0|[1-9]\\d|100)$");
                string text = this.spinEditQuality.Text.Trim();
                if (!regex.IsMatch(text))
                {
                    XtraMessageBox.Show(frmCreatePyramid.MSG01, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
                else
                {
                    //Logger logger = new Logger();
                    frmWaitDialog frmWait = new frmWaitDialog("正在创建金字塔" + "......", "提示信息");
                    try
                    {
                        frmWait.Owner = this;
                        frmWait.TopMost = false;
                        if (this._geoProcessor == null)
                        {
                            this._geoProcessor = new Geoprocessor();
                            this._geoProcessor.OverwriteOutput = true;
                        }
                        if (this.m_rasterFiles.Count == 1)
                        {
                            BuildPyramids buildPyramids = new BuildPyramids();
                            buildPyramids.in_raster_dataset = this.m_rasterFiles[0];
                            buildPyramids.resample_technique = this.comboBoxEditReSample.Text;
                            buildPyramids.compression_type = this.comboBoxEditZip.Text;
                            buildPyramids.compression_quality = Convert.ToInt32(text);
                            this._geoProcessor.Execute(buildPyramids, null);
                        }
                        else
                        {
                            BatchBuildPyramids batchBuildPyramids = new BatchBuildPyramids();
                            batchBuildPyramids.Input_Raster_Datasets = string.Join(";", this.m_rasterFiles);
                            batchBuildPyramids.Pyramid_resampling_technique = this.comboBoxEditReSample.Text;
                            batchBuildPyramids.Pyramid_compression_type = this.comboBoxEditZip.Text;
                            batchBuildPyramids.Compression_quality = Convert.ToInt32(text);
                            this._geoProcessor.Execute(batchBuildPyramids, null);
                        }
                        //logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                        base.DialogResult = System.Windows.Forms.DialogResult.OK;
                        base.Close();
                    }
                    catch (Exception ex)
                    {
                        //logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                        BLL.Log.WriteLog(typeof(frmCreatePyramid),ex);
                        base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                    finally
                    {
                        frmWait.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Form.Closed" /> 事件。
        /// </summary>
        /// <param name="e">一个包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnClosed(EventArgs e)
        {
            this._geoProcessor = null;
        }
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}