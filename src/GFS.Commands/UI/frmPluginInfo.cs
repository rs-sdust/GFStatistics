// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmPluginInfo.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : View Plugin Property</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SDJT.PluginEngine.PluginMan;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmPluginInfo.
    /// </summary>
    public partial class frmPluginInfo : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "不可用";
        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02 = "可用";
        /// <summary>
        /// The ms G03
        /// </summary>
        private static string MSG03 = "查看插件属性";
        /// <summary>
        /// The _plugin entry
        /// </summary>
        private PluginEntry _pluginEntry;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmPluginInfo" /> class.
        /// </summary>
        /// <param name="pluginEntry">The plugin entry.</param>
        public frmPluginInfo(PluginEntry pluginEntry)
        {
            InitializeComponent();
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            this._pluginEntry = pluginEntry;
            GetPluginInfo();
        }
        /// <summary>
        /// Initializes static members of the <see cref="frmPluginInfo" /> class.
        /// </summary>
        static frmPluginInfo()
        {
            //frmPluginInfo.MSG01 = "不可用";
            //frmPluginInfo.MSG02 = "可用";
            //frmPluginInfo.MSG03 ="查看插件属性";
        }


        /// <summary>
        /// Gets the plugin information.
        /// </summary>
        private void GetPluginInfo()
        {
            this.txtFile.Text = this._pluginEntry.AssemblyPath;
            this.txtName.Text = this._pluginEntry.Name;
   //         if (this._pluginEntry.Disabled.ToString() == "true")

   //         {
   //             this.txtDisable.Text = frmPluginInfo.MSG01;
   //         }
			//else
			//{
   //             this.txtDisable.Text = frmPluginInfo.MSG02;
   //         }
            this.txtDescription.Text = this._pluginEntry.Description;
            this.txtClass.Text = this._pluginEntry.TypeName;
            this.txtVersion.Text = this._pluginEntry.Version;
            this.txtIcon.Text = this._pluginEntry.IconPath;
            this.txtTime.Text = this._pluginEntry.JoinTime.ToString();
            //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FrmPluginProperty.ADFFT8iyi, null);
        }
    }
}