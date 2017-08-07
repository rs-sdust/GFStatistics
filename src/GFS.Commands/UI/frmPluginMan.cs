// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 03-29-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmPluginMan.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : Plugin Manager</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using SDJT.Const;
using DevExpress.Utils;
using SDJT.PluginEngine.PluginMan;
using System.Xml;
using System.Collections;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using SDJT.Log;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmPluginMan.
    /// </summary>
    public partial class frmPluginMan : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "请选择单个插件查看属性！";
        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02 = "请选择需要删除的插件！";
        /// <summary>
        /// The ms G03
        /// </summary>
        private static string MSG03 = "由于文件锁定，请重新启动系统，再执行操作！";
        /// <summary>
        /// The ms G04
        /// </summary>
        private static string MSG04 = "导入插件";
        /// <summary>
        /// The ms G05
        /// </summary>
        private static string MSG05 = "卸载插件";
        /// <summary>
        /// The ms G06
        /// </summary>
        private static string MSG06 = "添加到界面";
        /// <summary>
        /// The ms G07
        /// </summary>
        private static string MSG07 = "从界面移除";
        /// <summary>
        /// The ms G08
        /// </summary>
        private static string MSG08 = "正在导入插件......";
        /// <summary>
        /// The ms G09
        /// </summary>
        private static string MSG09 = "正在将插件添加到界面......";
        /// <summary>
        /// The m_ container
        /// </summary>
        public IContainerContext m_Container;

        /// <summary>
        /// Initializes static members of the <see cref="frmPluginMan" /> class.
        /// </summary>
        static frmPluginMan()
		{
            //frmPluginMan.MSG01 = "请选择单个插件查看属性！";
            //frmPluginMan.MSG02 = "请选择需要删除的插件！";
            //frmPluginMan.MSG03 = "由于文件锁定，请重新启动系统，再执行操作！";
            //frmPluginMan.MSG04 = "导入插件";
            //frmPluginMan.MSG05 = "卸载插件";
            //frmPluginMan.MSG06 = "添加到界面";
            //frmPluginMan.MSG07 = "从界面移除";
            //frmPluginMan.MSG08 = "正在导入插件......";
            //frmPluginMan.MSG09 = "正在将插件添加到界面......";
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="frmPluginMan" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public frmPluginMan(IContainerContext container)
        {
            InitializeComponent();
            this.m_Container = container;
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Handles the Load event of the frmPluginMan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void frmPluginMan_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkedListLeft.Items.Clear();
                foreach (KeyValuePair<string, PluginEntry> current in Configuration.instance.pluginManager.entriesWithNames)
                {
                    PluginEntry value = current.Value;
                    this.checkedListLeft.Items.Add(value.Name);
                }
                this.comboBoxPage.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                this.comboBoxGroup.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                this.comboBoxMenu.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                if (!base.DesignMode)
                {
                    this.LoadPages();
                    this.SetControlEnable();
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //----------------------------点击combo清空文本，重设界面可用性----------------------------------------------
        /// <summary>
        /// Handles the Click event of the comboBoxPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxPage_Click(object sender, EventArgs e)
        {
            this.comboBoxPage.Text = string.Empty;
            this.comboBoxGroup.Text = string.Empty;
            this.comboBoxMenu.Text = string.Empty;
            this.checkedListRight.Items.Clear();
            this.SetControlEnable();
        }
        /// <summary>
        /// Handles the Click event of the comboBoxGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxGroup_Click(object sender, EventArgs e)
        {
            this.comboBoxGroup.Text = string.Empty;
            this.comboBoxMenu.Text = string.Empty;
            this.checkedListRight.Items.Clear();
            this.SetControlEnable();
        }
        /// <summary>
        /// Handles the Click event of the comboBoxMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxMenu_Click(object sender, EventArgs e)
        {
            this.comboBoxMenu.Text = string.Empty;
            this.checkedListRight.Items.Clear();
            this.SetControlEnable();
        }

        /// <summary>
        /// Sets the control enable.
        /// 设置界面控件可用性
        /// </summary>
        private void SetControlEnable()
        {
            try
            {
                this.comboBoxGroup.Enabled = !string.IsNullOrEmpty(this.comboBoxPage.SelectedItem.ToString());
                this.comboBoxMenu.Enabled = !string.IsNullOrEmpty(this.comboBoxGroup.SelectedItem.ToString());
                this.btnDele.Enabled = !string.IsNullOrEmpty(this.comboBoxGroup.SelectedItem.ToString());
                this.btnOK.Enabled = !string.IsNullOrEmpty(this.comboBoxGroup.SelectedItem.ToString());
                this.checkedListRight.Enabled = !string.IsNullOrEmpty(this.comboBoxGroup.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //------------------------------combo选中项改变事件--------------------------------------------------------
        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string page = this.comboBoxPage.Text.Trim();
                if (page != AppMessage.MSG0048 && page != AppMessage.MSG0115)
                {
                    string selectedPageName = this.GetSelectedPageName();
                    if (string.IsNullOrEmpty(selectedPageName))
                    {
                        this.comboBoxGroup.Properties.Items.Clear();
                    }
                    else
                    {
                        this.LoadGroups(selectedPageName);
                        this.SetControlEnable();
                    }
                }
                else
                {
                    if (page == AppMessage.MSG0048)
                    {
                        frmAddPage frmAddPage = new frmAddPage(this);
                        frmAddPage.ShowDialog();
                    }
                    if (page == AppMessage.MSG0115)
                    {
                        frmDelePage frmDelPage = new frmDelePage(this);
                        frmDelPage.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string group = this.comboBoxGroup.Text.Trim();
                if (group != AppMessage.MSG0049 && group != AppMessage.MSG0116)
                {
                    this.comboBoxMenu.Properties.Items.Clear();
                    string selectedPageGroupName = this.GetSelectedPageGroupName();
                    if (string.IsNullOrEmpty(selectedPageGroupName))
                    {
                        this.comboBoxMenu.Properties.Items.Clear();
                    }
                    else
                    {
                        this.QueryGroupNameFromTemp();
                        this.LoadMenu(selectedPageGroupName);
                        this.SetControlEnable();
                    }
                }
                else
                {
                    if (group == AppMessage.MSG0049)
                    {
                        frmAddGroup frmAddPageGroup = new frmAddGroup(this);
                        frmAddPageGroup.ShowDialog();
                    }
                    if (group == AppMessage.MSG0116)
                    {
                        frmDeleGroup frmDelPageGroup = new frmDeleGroup(this);
                        frmDelPageGroup.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text = this.comboBoxMenu.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    this.QueryGroupNameFromTemp();
                }
                else if (text == AppMessage.MSG0050)
                {
                    frmAddMenu frmAddMenu = new frmAddMenu(this);
                    frmAddMenu.ShowDialog();
                }
                else if (text == AppMessage.MSG0117)
                {
                    frmDeleMenu frmDelMenu = new frmDeleMenu(this);
                    frmDelMenu.ShowDialog();
                }
                else
                {
                    this.QueryMenuFromTemp();
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }
        /// <summary>
        /// Queries the group name from temporary.
        /// </summary>
        public void QueryGroupNameFromTemp()
        {
            try
            {
                XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                XmlElement documentElement = xmlDocByFilePath.DocumentElement;
                XmlNodeList childNodes = Configuration.instance.configManager.GetChildNodes(documentElement);
                if (childNodes.Count != 0)
                {
                    foreach (XmlNode xmlNode in childNodes)
                    {
                        string innerText = ((XmlElement)xmlNode).GetElementsByTagName("groupName")[0].InnerText;
                        if (innerText.Trim() == this.GetSelectedPageGroupName())
                        {
                            this.checkedListRight.Items.Add(((XmlElement)xmlNode).GetElementsByTagName("name")[0].InnerText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }
        /// <summary>
        /// Queries the menu from temporary.
        /// </summary>
        public void QueryMenuFromTemp()
        {
            try
            {
                XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                XmlElement documentElement = xmlDocByFilePath.DocumentElement;
                XmlNodeList childNodes = Configuration.instance.configManager.GetChildNodes(documentElement);
                if (childNodes.Count != 0)
                {
                    foreach (XmlNode xmlNode in childNodes)
                    {
                        string innerText = ((XmlElement)xmlNode).GetElementsByTagName("listName")[0].InnerText;
                        if (innerText.Trim() == this.GetSelectedMenuName())
                        {
                            this.checkedListRight.Items.Add(((XmlElement)xmlNode).GetElementsByTagName("name")[0].InnerText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //---------------------------checkedit事件-----------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the checkEditLeftAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkEditLeftAll_Click(object sender, EventArgs e)
        {
            if (this.checkEditLeftAll.Checked)
            {
                for (int i = 0; i < this.checkedListLeft.Items.Count; i++)
                {
                    this.checkedListLeft.Items[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
            }
            else
            {
                this.checkEditLeftClear.Checked = false;
                for (int i = 0; i < this.checkedListLeft.Items.Count; i++)
                {
                    this.checkedListLeft.Items[i].CheckState = System.Windows.Forms.CheckState.Checked;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the checkEditLeftClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkEditLeftClear_Click(object sender, EventArgs e)
        {
            if (this.checkEditLeftClear.Checked==false)
			{
                for (int i = 0; i < this.checkedListLeft.Items.Count; i++)
				{
					this.checkedListLeft.Items[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
                this.checkEditLeftAll.Checked = false;
                //this.checkEditLeftClear.Checked = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the checkEditRightAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkEditRightAll_Click(object sender, EventArgs e)
        {
            if (this.checkEditRightAll.Checked)
            {
                for (int i = 0; i < this.checkedListRight.Items.Count; i++)
                {
                    this.checkedListRight.Items[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
            }
            else
            {
                this.checkEditRightClear.Checked = false;
                for (int i = 0; i < this.checkedListRight.Items.Count; i++)
                {
                    this.checkedListRight.Items[i].CheckState = System.Windows.Forms.CheckState.Checked;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the checkEditRightClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkEditRightClear_Click(object sender, EventArgs e)
        {
            if (this.checkEditRightClear.Checked == false)
            {
                for (int i = 0; i < this.checkedListRight.Items.Count; i++)
                {
                    this.checkedListRight.Items[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
                this.checkEditRightAll.Checked = false;
                //this.checkEditLeftClear.Checked = false;
            }
        }

        //------------------------导入插件----------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
			{
				System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
				folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					string text = Path.Combine(ConstDef.PATH_PLUGINS, (selectedPath.Substring(selectedPath.LastIndexOf(@"\") + 1)));
					if (Directory.Exists(text))
					{
						if (Configuration.instance.pluginManager.restartFlag)
						{
							XtraMessageBox.Show(frmPluginMan.MSG03, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
							return;
						}
						try
						{
							string[] files = Directory.GetFiles(text);
							for (int i = 0; i < files.Length; i++)
							{
								string path = files[i];
								File.SetAttributes(path, FileAttributes.Normal);
							}
							Directory.Delete(text, true);
						}
						catch (Exception ex)
						{
							XtraMessageBox.Show(ex.Message, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
						}
					}
					WaitDialogForm waitDialogForm = new WaitDialogForm(AppMessage.MSG0000, frmPluginMan.MSG08);
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					this.CopyPlugins(selectedPath, text, true, true);
					waitDialogForm.Close();
					DirectoryInfo pluginDir = new DirectoryInfo(text);
					Configuration.instance.pluginManager.pluginEntryList.Clear();
					IList<PluginEntry> allPlugIns = Configuration.instance.pluginManager.GetAllPlugIns(pluginDir);
					foreach (PluginEntry current in allPlugIns)
					{
						if (!Configuration.instance.pluginManager.entriesWithNames.ContainsKey(current.Name))
						{
							Configuration.instance.pluginManager.entriesWithNames.Add(current.Name, current);
						}
						bool flag = false;
						foreach (object current2 in this.checkedListLeft.Items)
						{
							if (current2.ToString() == current.Name)
							{
								flag = true;
							}
						}
						if (!flag)
						{
                            this.checkedListLeft.Items.Add(current.Name);
						}
					}
                    //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FormPlugInMan.ADFFT8iyi, null);
				}
			}
			catch (Exception ex)
			{
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
				XtraMessageBox.Show(ex.Message + ex.StackTrace, AppMessage.MSG0129, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
        }

        /// <summary>
        /// Copies the plugins.
        /// 复制插件到指定目录
        /// </summary>
        /// <param name="selectedPath">The selected path.</param>
        /// <param name="pluginPath">The plugin path.</param>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        /// <param name="flag2">if set to <c>true</c> [flag2].</param>
        private void CopyPlugins(string selectedPath, string pluginPath, bool flag, bool flag2)
		{
			try
			{
				string[] array = Directory.GetFiles(selectedPath);
				for (int i = 0; i < array.Length; i++)
				{
					string fromFile = array[i];
					string toFile = Path.Combine(pluginPath, fromFile.Substring(fromFile.LastIndexOf(@"\") + 1));
					if (File.Exists(toFile))
					{
						if (flag)
						{
							File.SetAttributes(toFile, FileAttributes.Normal);
							File.Copy(fromFile, toFile, flag);
						}
					}
					else
					{
						File.Copy(fromFile, toFile, flag);
					}
				}
				if (flag2)
				{
					array = Directory.GetDirectories(selectedPath);
					for (int i = 0; i < array.Length; i++)
					{
						string text3 = array[i];
						string text4 = Path.Combine(pluginPath, text3.Substring(text3.LastIndexOf(@"\") + 1));
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						this.CopyPlugins(text3, text4, flag, true);
					}
				}
			}
			catch (Exception ex)
			{
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
                XtraMessageBox.Show(ex.Message);
			}
		}

        //--------------------卸载插件--------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnUninst control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnUninst_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.checkedListLeft.CheckedItemsCount <= 0)
                {
                    XtraMessageBox.Show(frmPluginMan.MSG02, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
                else
                {
                    for (int i = 0; i < this.checkedListLeft.Items.Count; i++)
                    {
                        if (this.checkedListLeft.Items[i].CheckState == System.Windows.Forms.CheckState.Checked)
                        {
                            PluginEntry plugin = Configuration.instance.pluginManager.GetPlugin(this.checkedListLeft.Items[i].ToString());
                            this.checkedListLeft.Items.RemoveAt(i);
                            i--;
                            if (Configuration.instance.pluginManager.pluginsWithNames.ContainsKey(plugin.Name))
                            {
                                Configuration.instance.pluginManager.pluginsWithNames.Remove(plugin.Name);
                            }
                            if (Configuration.instance.pluginManager.entriesWithNames.ContainsKey(plugin.Name))
                            {
                                Configuration.instance.pluginManager.entriesWithNames.Remove(plugin.Name);
                            }
                            this.RemovePluginConf(plugin);
                            if (File.Exists(plugin.AssemblyPath))
                            {
                                File.Delete(plugin.AssemblyPath);
                            }
                        }
                    }

                    //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FormPlugInMan.AEgyk6Z0bt(H7o8133(h9j863Hen2, null);
                 }
             }
			catch (Exception ex)
			{
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
				XtraMessageBox.Show(frmPluginMan.MSG03, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}

        }
        /// <summary>
        /// Removes the plugin conf.
        /// 移除插件配置信息
        /// </summary>
        /// <param name="pluginEntry">The plugin entry.</param>
		private void RemovePluginConf(PluginEntry pluginEntry)
        {
            try
            {
                XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                XmlElement documentElement = xmlDocByFilePath.DocumentElement;
                XmlNodeList childNodes = Configuration.instance.configManager.GetChildNodes(documentElement);
                if (childNodes.Count > 0)
                {
                    Configuration.instance.configManager.RemovePluginFromTemp(xmlDocByFilePath, pluginEntry.Name);
                }
                xmlDocByFilePath.Save(ConstDef.FILE_PLUGINCONFIG);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //----------------------插件信息------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnPluginInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnPluginInfo_Click(object sender, EventArgs e)
        {
            if (this.checkedListLeft.CheckedItems.Count == 1)
            {
                PluginEntry plugin = Configuration.instance.pluginManager.GetPlugin(this.checkedListLeft.CheckedItems[0].ToString());
                frmPluginInfo frmPluginProperty = new frmPluginInfo(plugin);
                frmPluginProperty.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(frmPluginMan.MSG01, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }

        }

        //----------------------添加插件到界面------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                WaitDialogForm waitDialogForm = new WaitDialogForm(AppMessage.MSG0000, frmPluginMan.MSG09);
                foreach (object current in ((IEnumerable)this.checkedListLeft.CheckedItems))
                {
                    bool flag = false;
                    for (int i = 0; i < this.checkedListRight.Items.Count; i++)
					{
                        if (this.checkedListRight.Items[i].ToString() == current.ToString())
						{
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        this.checkedListRight.Items.Add(current);
                    }
                }
                for (int i = 0; i < this.checkedListRight.Items.Count; i++)
				{
                    this.checkedListRight.Items[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
                    PluginEntry plugin = Configuration.instance.pluginManager.GetPlugin(this.checkedListRight.Items[i].ToString());
                    if (plugin != null)
                    {
                        plugin.PageName = this.GetSelectedPageName();
                        plugin.PageText = this.GetSelectedPageText();
                        plugin.GroupName = this.GetSelectedPageGroupName();
                        plugin.GroupText = this.GetSelectedPageGroupText();
                        plugin.ListName = this.GetSelectedMenuName();
                        plugin.ListText = this.GetSelectedMenuText();
                        this.m_Container.UpdatePlugInButton(plugin);
                        this.AddPluginConf(plugin);
                    }
                }
                waitDialogForm.Close();
                //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FormPlugInMan.AFxqYT0oma8KpReRA94lMnnhS22a, null);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }

        }

        /// <summary>
        /// Adds the plugin conf.
        /// 添加插件配置信息
        /// </summary>
        /// <param name="pluginEntry">The plugin entry.</param>
        private void AddPluginConf(PluginEntry pluginEntry)
        {
            try
            {
                XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                XmlElement documentElement = xmlDocByFilePath.DocumentElement;
                XmlNodeList childNodes = Configuration.instance.configManager.GetChildNodes(documentElement);
                if (childNodes.Count > 0)
                {
                    Configuration.instance.configManager.UpdataPluginNode(xmlDocByFilePath, pluginEntry);
                }
                else
                {
                    documentElement.AppendChild(Configuration.instance.configManager.CreatePluginNode(xmlDocByFilePath, pluginEntry));
                }
                xmlDocByFilePath.Save(ConstDef.FILE_PLUGINCONFIG);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //-------------------------删除插件----------------------------------
        /// <summary>
        /// Handles the Click event of the btnDele control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnDele_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDocByFilePath = Configuration.instance.configManager.GetXmlDocByFilePath(ConstDef.FILE_PLUGINCONFIG);
                for (int i = 0; i < this.checkedListRight.Items.Count; i++)
				{
                    if (this.checkedListRight.GetItemChecked(i))
					{
                        string text = this.checkedListRight.Items[i].ToString();
                        this.m_Container.RemovePlugInButton(text);
                        Configuration.instance.configManager.RemovePluginFromTemp(xmlDocByFilePath, text);
                        this.checkedListRight.Items.RemoveAt(i);
                        i--;
                    }
                }
                xmlDocByFilePath.Save(ConstDef.FILE_PLUGINCONFIG);
                //Configuration.instance.logger.Log(LogLevel.Info, EventType.UserManagement, FormPlugInMan.AGTWxTXlf, null);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
                throw;
            }
        }
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.OK;
            base.Close();
        }
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the btnCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            base.Close();
        }

        //------------------------------获取选择的page->group->menu信息-----------------------------------------------------
        /// <summary>
        /// Gets the name of the selected page.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedPageName()
        {
            string result;
            try
            {
                string text = this.comboBoxPage.Text.Trim();
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
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        /// <summary>
        /// Gets the name of the selected page group.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedPageGroupName()
        {
            string result;
            try
            {
                string text = this.comboBoxGroup.Text.Trim();
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
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        /// <summary>
        /// Gets the name of the selected menu.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedMenuName()
        {
            string result;
            try
            {
                string text = this.comboBoxMenu.Text.Trim();
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
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        /// <summary>
        /// Gets the selected page text.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedPageText()
        {
            string result;
            try
            {
                string text = this.comboBoxPage.Text.Trim();
                string[] array = text.Split(new char[]
                {
                    '/'
                });
                if (array.Length == 2)
                {
                    result = array[0].Trim();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        /// <summary>
        /// Gets the selected page group text.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedPageGroupText()
        {
            string result;
            try
            {
                string text = this.comboBoxGroup.Text.Trim();
                string[] array = text.Split(new char[]
                {
                    '/'
                });
                if (array.Length == 2)
                {
                    result = array[0].Trim();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        /// <summary>
        /// Gets the selected menu text.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSelectedMenuText()
        {
            string result;
            try
            {
                string text = this.comboBoxMenu.Text.Trim();
                string[] array = text.Split(new char[]
                {
                    '/'
                });
                if (array.Length == 2)
                {
                    result = array[0].Trim();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
            result = string.Empty;
            return result;
        }

        //---------------------------加载当前page、group、menu信息到comobox-------------------------------------------------------------------
        /// <summary>
        /// Loads the pages.
        /// </summary>
        public void LoadPages()
        {
            try
            {
                this.comboBoxPage.Properties.Items.Clear();
                IList<RibbonPage> allRibbonPages = this.m_Container.GetAllRibbonPages();
                foreach (RibbonPage current in allRibbonPages)
                {
                    this.comboBoxPage.Properties.Items.Add(current.Text + @"/" + current.Name);
                }
                this.comboBoxPage.Properties.Items.Add(AppMessage.MSG0048);
                this.comboBoxPage.Properties.Items.Add(AppMessage.MSG0115);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }
        /// <summary>
        /// Loads the groups.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        public void LoadGroups(string pageName)
        {
            try
            {
                this.comboBoxGroup.Properties.Items.Clear();
                IList<RibbonPageGroup> subRibbonPageGroups = this.m_Container.GetSubRibbonPageGroups(pageName);
                foreach (RibbonPageGroup current in subRibbonPageGroups)
                {
                    this.comboBoxGroup.Properties.Items.Add(current.Text + @"/" + current.Name);
                }
                this.comboBoxGroup.Properties.Items.Add(AppMessage.MSG0049);
                this.comboBoxGroup.Properties.Items.Add(AppMessage.MSG0116);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }
        /// <summary>
        /// Loads the menu.
        /// </summary>
        /// <param name="pagegroupName">Name of the pagegroup.</param>
        public void LoadMenu(string pagegroupName)
        {
            try
            {
                this.comboBoxMenu.Properties.Items.Clear();
                IList<BarSubItem> ribbonListItems = this.m_Container.GetRibbonListItems(pagegroupName);
                foreach (BarSubItem current in ribbonListItems)
                {
                    this.comboBoxMenu.Properties.Items.Add(current.Caption + @"/" + current.Name);
                }
                this.comboBoxMenu.Properties.Items.Add(AppMessage.MSG0050);
                this.comboBoxMenu.Properties.Items.Add(AppMessage.MSG0117);
            }
            catch (Exception ex)
            {
                Configuration.instance.logger.Log(LogLevel.Error, EventType.UserManagement, null, ex);
            }
        }

        //----------------------新添加项插入到combo---------------------------------------------------------
        /// <summary>
        /// Adds the page item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void AddPageItem(int index, object item)
        {
            this.comboBoxPage.Properties.Items.Insert(index, item);
            this.comboBoxPage.SelectedIndex = index;
        }
        /// <summary>
        /// Adds the group item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void AddGroupItem(int index, object item)
        {
            this.comboBoxGroup.Properties.Items.Insert(index, item);
            this.comboBoxGroup.SelectedIndex = index;
        }
        /// <summary>
        /// Adds the menu item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void AddMenuItem(int index, object item)
        {
            this.comboBoxMenu.Properties.Items.Insert(index, item);
            this.comboBoxMenu.SelectedIndex = index;
        }

        //---------------------获取combo项目列表-----------------------------------------
        /// <summary>
        /// Gets the page items.
        /// </summary>
        /// <returns>ComboBoxItemCollection.</returns>
        public ComboBoxItemCollection GetPageItems()
        {
            ComboBoxItemCollection result;
            if (this.comboBoxPage.Properties.Items.Count > 0)
            {
                result = this.comboBoxPage.Properties.Items;
            }
            else
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// Gets the group items.
        /// </summary>
        /// <returns>ComboBoxItemCollection.</returns>
        public ComboBoxItemCollection GetGroupItems()
        {
            ComboBoxItemCollection result;
            if (this.comboBoxGroup.Properties.Items.Count > 0)
            {
                result = this.comboBoxGroup.Properties.Items;
            }
            else
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <returns>ComboBoxItemCollection.</returns>
        public ComboBoxItemCollection GetMenuItems()
        {
            ComboBoxItemCollection result;
            if (this.comboBoxMenu.Properties.Items.Count > 0)

            {
                result = this.comboBoxMenu.Properties.Items;
            }
            else
            {
                result = null;
            }
            return result;
        }

        //---------------------清空combo文本框------------------------------------------
        /// <summary>
        /// Clears the page item.
        /// </summary>
        public void ClearPageItem()
        {
            this.comboBoxPage.Text = string.Empty;
        }
        /// <summary>
        /// Clears the group item.
        /// </summary>
        public void ClearGroupItem()
        {
            this.comboBoxGroup.Text = string.Empty;
        }
        /// <summary>
        /// Clears the menu item.
        /// </summary>
        public void ClearMenuItem()
        {
            this.comboBoxMenu.Text = string.Empty;
        }

    }
}