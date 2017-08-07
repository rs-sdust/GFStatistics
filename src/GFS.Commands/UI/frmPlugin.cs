// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmPlugin.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : To Load Plugin UserControl</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SDJT.PluginEngine.Plugin;
using SDJT.PluginEngine.PluginMan;
using System.IO;
using SDJT.Const;
using DevExpress.XtraBars;
//using ESRI.ArcGIS.Geometry;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmPlugin.
    /// </summary>
    public partial class frmPlugin : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The plugin panel
        /// </summary>
        private System.Windows.Forms.UserControl pluginPanel=null;

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "任务名称不能空";
        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02= "验证参数失败，请检查输入参数！";
        /// <summary>
        /// The ms G03
        /// </summary>
        private static string MSG03 = "添加到任务列表";
        /// <summary>
        /// The ms G04
        /// </summary>
        private static string MSG04 = "数据字典中不包含该插件";
        /// <summary>
        /// Gets or sets the plugin.
        /// </summary>
        /// <value>The plugin.</value>
        public IPlugin Plugin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the PluginEntry.
        /// </summary>
        /// <value>The PluginEntry.</value>
        public PluginEntry Entry
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmPlugin" /> class.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="plugin">The plugin.</param>
        public frmPlugin(PluginEntry entry,IPlugin plugin)
        {
            InitializeComponent();
            this.Plugin = plugin;
            this.Entry = entry;

        }

        /// <summary>
        /// Initializes static members of the <see cref="frmPlugin" /> class.
        /// </summary>
        static frmPlugin()
        {
            //frmPlugin.MSG01= "任务名称不能空";
            //frmPlugin.MSG02= "验证参数失败，请检查输入参数！";
            //frmPlugin.MSG03= "添加到任务列表";
            //frmPlugin.MSG04= "数据字典中不包含该插件";
        }

        /// <summary>
        /// Handles the Load event of the frmPlugin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void frmPlugin_Load(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                this.splitContainerControl1.Panel1.Controls.Clear();
                System.Windows.Forms.UserControl argumentPane = this.Plugin.GetArgumentPane();
                if (argumentPane != null)
                {
                    if (Configuration.instance.pluginManager.entriesWithNames.ContainsKey(this.Plugin.Name))
                    {
                        PluginEntry pluginEntry = Configuration.instance.pluginManager.entriesWithNames[this.Plugin.Name];
                        if (pluginEntry == null)
                        {
                            return;
                        }
                        string directoryName = Path.GetDirectoryName(pluginEntry.AssemblyPath);
                        string text = Path.Combine(System.Windows.Forms.Application.StartupPath, directoryName,"languages");
                        if (Directory.Exists(text))
                        {
                            //LanguageManager languageManager = new LanguageManager(text);
                            //languageManager.SetLanguage(argumentPane);
                        }
                        base.Height = argumentPane.Height + 200;
                        base.Width = argumentPane.Width + 100;
                        this.Text = this.Plugin.Name;
                        this.pluginPanel = argumentPane;
                        this.splitContainerControl1.Panel1.Controls.Add(argumentPane);
                        argumentPane.Dock = System.Windows.Forms.DockStyle.Fill;
                    }
                    else
                    {
                        //Configuration.instance.logger.Log(HTES.TAS.DB.Model.LogLevel.Error, EventType.UserManagement, FrmPluginBatchExec.AEgyk6Z0bt(H7o8133(h9j863Hen2, null);
                        XtraMessageBox.Show(frmPlugin.MSG04, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        base.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Plugin != null & this.Plugin.VerifyArguments())
                {

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                //Configuration.instance.logger.Log(HTES.TAS.DB.Model.LogLevel.Error, this.current.Name, this.current.Version, ex.Message, ex);
                XtraMessageBox.Show(ex.Message + ex.StackTrace, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}