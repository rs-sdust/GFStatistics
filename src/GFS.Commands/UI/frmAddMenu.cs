// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmAddMenu.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : Add RibbonPageBarSubItem</summary>
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
using SDJT.Const;
using SDJT.Sys;
using SDJT.Log;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmAddMenu.
    /// </summary>
    public partial class frmAddMenu : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01="名称和文本都不能为空！";
        /// <summary>
        /// The title
        /// </summary>
        private static string Title= "添加菜单";
        /// <summary>
        /// The FRM pluginman
        /// </summary>
        private frmPluginMan _frmPluginMan;
        /// <summary>
        /// The _container
        /// </summary>
        private IContainerContext _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddMenu" /> class.
        /// </summary>
        /// <param name="pluginMan">The plugin man.</param>
        public frmAddMenu(frmPluginMan pluginMan)
        {
            InitializeComponent();
            this._frmPluginMan = pluginMan;
            this._container = this._frmPluginMan.m_Container;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }
        /// <summary>
        /// Initializes static members of the <see cref="frmAddMenu" /> class.
        /// </summary>
        static frmAddMenu()
        {
            //frmAddMenu.MSG01 = "名称和文本都不能为空！";
            //frmAddMenu.Title = "添加菜单";
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPageGroupName = this._frmPluginMan.GetSelectedPageGroupName();
                string selectedMenuName = this._frmPluginMan.GetSelectedMenuName();
                string name = this.textEditName.Text.Trim();
                string text = this.textEditText.Text.Trim();
                string empty = string.Empty;
                int index = 0;
                if (!string.IsNullOrEmpty(empty))
                {
                    index = int.Parse(empty);
                }
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(text))
                {
                    this._container.AddRibbonListItems(index, selectedPageGroupName, name, text);
                    this._frmPluginMan.AddMenuItem(index, text + @"/" + name);
                    //LanguageManager languageManager = EnviVars.instance.LanguageManager;
                    //string sKey = name;
                    //string sValue = text;
                    //string value = languageManager.Get(sKey);
                    //if (string.IsNullOrEmpty(value))
                    //{
                    //    Configuration.instance.configManager.UpdataLangNode(sKey, sValue);
                    //    base.Close();
                    //    //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FrmAddMenu.ADFFT8iyi, null);
                    //}
                    //else
                    //{
                    //  XtraMessageBox.Show(AppMessage.MSG0121, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    //}
                }
                else
                {
                    XtraMessageBox.Show(frmAddMenu.MSG01, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    this._frmPluginMan.ClearMenuItem();
                }
                base.Close();
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._frmPluginMan.ClearMenuItem();
            base.Close();
        }

        /// <summary>
        /// Handles the EditValueChanged event of the textEditText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void textEditText_EditValueChanged(object sender, EventArgs e)
        {
            this.textEditName.Text = EnviVars.instance.MainForm.Name + "_" + DateTime.Now.ToString("yyyyMMddhhmmss");
        }
    }
}