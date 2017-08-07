// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmDeleGroup.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : del RibbonPageGroup</summary>
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
using System.Xml;
using SDJT.Log;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmDeleGroup.
    /// </summary>
    public partial class frmDeleGroup : DevExpress.XtraEditors.XtraForm
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
        /// Initializes a new instance of the <see cref="frmDeleGroup" /> class.
        /// </summary>
        /// <param name="pluginMan">The plugin man.</param>
        public frmDeleGroup(frmPluginMan pluginMan)
        {
            InitializeComponent();
            this._frmPluginMan = pluginMan;
            this._container = this._frmPluginMan.m_Container;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Handles the Load event of the frmDeleGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void frmDeleGroup_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkedListGroup.Items.Clear();
                if (this._frmPluginMan.GetGroupItems() != null)
                {
                    for (int i = 0; i < this._frmPluginMan.GetGroupItems().Count; i++)
                    {
                        object obj2 = this._frmPluginMan.GetGroupItems()[i];
                        if (obj2.ToString() != AppMessage.MSG0049 && obj2.ToString() != AppMessage.MSG0116)
                        {
                            this.checkedListGroup.Items.Add(this._frmPluginMan.GetGroupItems()[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
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
                if (this.checkedListGroup.SelectedItems.Count >= 1)
                {
                    XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                    for (int i = 0; i < this.checkedListGroup.Items.Count; i++)
                    {
                        if (this.checkedListGroup.GetItemChecked(i))
                        {
                            string text = this.checkedListGroup.Items[i].ToString();
                            string name = this.SplitNameAndTxt(text);
                            this._container.ReomveRibbonPageGroup(name);
                            this._frmPluginMan.LoadGroups(this._frmPluginMan.GetSelectedPageName());
                            Configuration.instance.configManager.RemovePluginFromTempPageGroup(xmlDocByFilePath, name);
                            this.checkedListGroup.Items.RemoveAt(i);
                            i--;
                        }
                    }
                    xmlDocByFilePath.Save(ConstDef.FILE_PLUGINCONFIG);
                    base.Close();
                    //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FrmDelPageGroup.ACHOYMTAejoCGxdsPL, null);
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._frmPluginMan.ClearGroupItem();
            base.Close();
        }

        /// <summary>
        /// Splits the name and text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        private string SplitNameAndTxt(string text)
        {
            string result;
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    string[] array = text.Split(new char[]
                    {
                        '/'
                    });
                    if (array.Length == 2)
                    {
                        result = array[1].Trim();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }
    }
}