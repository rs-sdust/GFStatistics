// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmAddPage.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Foem : Add RibbonPage</summary>
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
using SDJT.Sys;
using SDJT.Const;
using SDJT.Log;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmAddPage.
    /// </summary>
    public partial class frmAddPage : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The FRM pluginman
        /// </summary>
        private frmPluginMan _frmPluginMan;

        /// <summary>
        /// The _container
        /// </summary>
        private IContainerContext _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddPage" /> class.
        /// </summary>
        /// <param name="pluginMan">The plugin man.</param>
        public frmAddPage(frmPluginMan pluginMan)
        {
            InitializeComponent();
            this._frmPluginMan = pluginMan;
            this._container = this._frmPluginMan.m_Container;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
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
                    this._container.AddRibbonPage(name, text);
                    this._frmPluginMan.AddPageItem(index, text + @"/" + name);
                    //LanguageManager languageManager = EnviVars.instance.LanguageManager;
                    //string sKey = name;
                    //string sValue = text;
                    //string value = languageManager.Get(sKey);
                    //if (!string.IsNullOrEmpty(value))
                    //{
                    //    XtraMessageBox.Show(AppMessage.MSG0121, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    //    return;
                    //}
                    //Configuration.instance.dataManager.UpdataLangNode(sKey, sValue);
                }
                else
                {
                    this._frmPluginMan.ClearPageItem();
                }
                base.Close();
                //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FrmAddPage.ACHOYMTAejoCGxdsPL, null);
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
            this._frmPluginMan.ClearPageItem();
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