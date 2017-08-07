// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmSystemSetting.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDJT.Sys;
using System.IO;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using SDJT.Const;
using SDJT.Log;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmSystemSetting.
    /// </summary>
    public partial class frmSystemSetting : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The _ini op
        /// </summary>
        private IniOperator _iniOp = null;

        /// <summary>
        /// The _s initialize language
        /// </summary>
        private string _sInitLanguage = "";

        /// <summary>
        /// The _s initialize skin
        /// </summary>
        private string _sInitSkin = "";

        /// <summary>
        /// The _i initialize mouse wheel
        /// </summary>
        private int _iInitMouseWheel = 1;

        /// <summary>
        /// The _s initialize sea path
        /// </summary>
        private string _sInitSeaPath = "";

        /// <summary>
        /// The language file
        /// </summary>
        private Dictionary<string, string> langFile=new Dictionary<string,string> ();

        //private Logger _logger = new Logger();

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01;

        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02;

        /// <summary>
        /// Initializes static members of the <see cref="frmSystemSetting"/> class.
        /// </summary>
        static frmSystemSetting()
        {
            frmSystemSetting.MSG01 = "中文（中文简体）";
            frmSystemSetting.MSG02 = "英语（美国）";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmSystemSetting"/> class.
        /// </summary>
        public frmSystemSetting()
        {
            InitializeComponent();

            this.langFile.Add("zh-cn", frmSystemSetting.MSG01);
            this.langFile.Add("en-us", frmSystemSetting.MSG02);
        }

        /// <summary>
        /// Handles the Load event of the frmSystemSetting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmSystemSetting_Load(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            try
            {
                //加载皮肤
                SkinHelper.InitSkinGallery(this.galleryControlSkin);
                this._iniOp = new IniOperator(SDJT.Const.ConstDef.FILE_SYSTEMCONFIG);
                this._sInitSkin = _iniOp.ReadIniValue("System", "Skin");
                //galleryControlSkin.Tag = _sInitSkin;

                //加载语言文件
                this._sInitLanguage = _iniOp.ReadIniValue("System", "Language");
                DirectoryInfo langPathInfo = new DirectoryInfo(SDJT.Const.ConstDef.PATH_LANGUAGES);
                FileInfo[] langFileInfo = langPathInfo.GetFiles("*.xml");
                foreach (FileInfo langInfo in langFileInfo)
                {
                    string lang = Path.GetFileNameWithoutExtension(langInfo.FullName);
                    int selectedIndex = 0;
                    selectedIndex = this.cmbLang.Properties.Items.Add(langFile[lang]);

                    //选中当前语言
                    if (_sInitLanguage == lang)
                    {
                        this.cmbLang.SelectedIndex = selectedIndex;
                    }
                }

            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
            finally
            {}
        }

        /// <summary>
        /// Handles the ItemClick event of the galleryControlGallery1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs"/> instance containing the event data.</param>
        private void galleryControlGallery1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Logger logger = new Logger();
            try
            {
                //写入皮肤配置
                if (galleryControlSkin.Gallery != null)
                {
                    string newSkin = galleryControlSkin.Gallery.GetCheckedItem().Caption;
                    if (_sInitSkin != newSkin)
                    {
                        _iniOp.WriteIniValue("System", "Skin", newSkin);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
            finally
            {
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            try
            {
                //写入语言配置
                if (this.cmbLang.SelectedItem != null)
                {
                    string newLang = this.cmbLang.SelectedItem.ToString();
                    if (this.langFile[_sInitLanguage] != newLang)
                    {
                        foreach(KeyValuePair<string, string> kvp in langFile)
                        {
                            if (kvp.Value == newLang)
                            {
                                newLang = kvp.Key;
                            }
                        }

                        this._iniOp.WriteIniValue("System", "Language", newLang);
                        XtraMessageBox.Show(AppMessage.MSG0019, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
            finally
            {
                base.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }



    }
}
