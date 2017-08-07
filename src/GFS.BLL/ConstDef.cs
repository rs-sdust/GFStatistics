// ***********************************************************************
// Assembly         : SDJT.Const
// Author           : yxq
// Created          : 03-25-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="ConstDef.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// The Const namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class ConstDef.
    /// </summary>
    public class ConstDef
    {

        /// <summary>
        /// The deskto path
        /// </summary>
        public static readonly string PATH_DESKTOP = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
        /// <summary>
        /// The config path
        /// </summary>
        public static readonly string PATH_CONFIG = System.Windows.Forms.Application.StartupPath + "\\config";

        /// <summary>
        /// The temporary path
        /// </summary>
        public static readonly string PATH_TEMP = System.Windows.Forms.Application.StartupPath + "\\temp";

        /// <summary>
        /// 系统配置文件
        /// </summary>
        public static readonly string FILE_SYSTEMCONFIG;
        /// <summary>
        /// 图标配置文件
        /// </summary>
        public static readonly string FILE_ICONCONFIG;

        /// <summary>
        /// 图标配置文件
        /// </summary>
        public static readonly string FILE_SPLASH;

        /// <summary>
        /// 默认插件图标
        /// </summary>
        public static readonly string FILE_PLUGINSICONDEF;

        /// <summary>
        /// 默认插件组图标
        /// </summary>
        public static readonly string FILE_PLUGINSMENUICONDEF;

        /// <summary>
        /// esri符号文件
        /// </summary>
        public static readonly string FILE_STYLE;

        /// <summary>
        /// 标注符号文件
        /// </summary>
        public static readonly string PATH_MARK_STYLE;

        /// <summary>
        /// 最近使用文件列表
        /// </summary>
        public static readonly string FILE_RENCENTFILES;

        /// <summary>
        /// 帮助文件
        /// </summary>
        public static readonly string FILE_HELPFILE;

        /// <summary>
        /// 语言文件目录
        /// </summary>
        public static readonly string PATH_LANGUAGES;

        /// <summary>
        /// 插件程序目录
        /// </summary>
        public static readonly string PATH_PLUGINS;

        /// <summary>
        /// 插件配置文件
        /// </summary>
        public static readonly string FILE_PLUGINCONFIG;


        /// <summary>
        /// Initializes static members of the <see cref="ConstDef" /> class.
        /// </summary>
        static ConstDef()
        {
            ConstDef.FILE_SYSTEMCONFIG =
                Path.Combine(System.Windows.Forms.Application.StartupPath, "config", "system.ini");

            ConstDef.FILE_ICONCONFIG = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "config", "iconConfig.txt");

            ConstDef.FILE_SPLASH =
                Path.Combine(System.Windows.Forms.Application.StartupPath, @"icons", "splash.png");

            ConstDef.FILE_PLUGINSICONDEF = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, @"icons\Plugins", "default.png");

            ConstDef.FILE_PLUGINSMENUICONDEF = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, @"icons\Plugins", "menu.png");

            ConstDef.FILE_STYLE = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "styles", "System.ServerStyle");

            ConstDef.FILE_RENCENTFILES = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "config","recentFiles.xml");

            ConstDef.FILE_PLUGINCONFIG = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "config", "pluginConfig.xml");

            ConstDef.FILE_HELPFILE = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "help", "help.chm");

            ConstDef.PATH_LANGUAGES = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "languages");

            ConstDef.PATH_PLUGINS = 
                Path.Combine(System.Windows.Forms.Application.StartupPath, "plugins");
        }
    }
}
