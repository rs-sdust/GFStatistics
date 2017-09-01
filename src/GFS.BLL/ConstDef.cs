// ***********************************************************************
// Assembly         : SDJT.Const
// Author           : Ricker Yan
// Created          : 03-25-2016
//
// Last Modified By : Ricker Yan
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
        /// The desktop path
        /// </summary>
        public static readonly string PATH_DESKTOP = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        private static readonly string STARTPATH = System.Windows.Forms.Application.StartupPath;

        /// <summary>
        /// 系统配置文件
        /// </summary>
        public static readonly string FILE_SYSTEMCONFIG;

        /// <summary>
        /// The temporary path
        /// </summary>
        public static readonly string PATH_TEMP;

        public static readonly string PATH_IDL;

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

        //public static int TASK_ID;
        //public static TaskState TASK_STATE;

        /// <summary>
        /// Initializes static members of the <see cref="ConstDef" /> class.
        /// </summary>
        static ConstDef()
        {
            ConstDef.FILE_SYSTEMCONFIG =
                Path.Combine(STARTPATH, "config", "system.ini");

            ConstDef.PATH_TEMP =
                Path.Combine(STARTPATH,"temp");

            ConstDef.FILE_STYLE =
                Path.Combine(STARTPATH, "styles", "System.ServerStyle");

            ConstDef.FILE_RENCENTFILES =
                Path.Combine(STARTPATH, "taskHistory.xml");

            ConstDef.FILE_HELPFILE =
                Path.Combine(STARTPATH, "help", "help.chm");

            ConstDef.PATH_IDL =
                Path.Combine(STARTPATH, "IDL");

        }
    }
}
