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
// <summary>系统配置</summary>
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

        public static readonly string STARTPATH = System.Windows.Forms.Application.StartupPath;

        /// <summary>
        /// 系统配置文件
        /// </summary>
        public static readonly string FILE_SYSTEMCONFIG;
        public static readonly string URL_UPDATETASK;
        /// <summary>
        /// The temporary path
        /// </summary>
        public static readonly string PATH_TEMP;

        /// <summary>
        /// The IDL path 
        /// </summary>
        public static readonly string PATH_IDL;
        /// <summary>
        /// 图像分割 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_SEGMENTONLY = "FX_Segmentonly";
        /// <summary>
        /// 人工神经网络分类 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_NEURAL_NET = "Neural_Net_Classification_Function";
        /// <summary>
        /// 混淆矩阵 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_CONFUSION = "Confusion_Matrix_Calcute";
        /// <summary>
        /// 最大似然分类 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_MAXIMUM = "MAXIMUM_LIKELIHOOD_CLASSIFICATION";

        /// <summary>
        /// 波段合成 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_BANDCOMPOSE = "bandcompose";
        /// <summary>
        /// 波段分解 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_BANDDECOMPOSE = "banddecompose";
        /// <summary>
        /// 波段运算 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_BANDMATH = "bandmath";
        /// <summary>
        /// 信息熵计算 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_ENTROPY= "entropy";
        /// <summary>
        /// svm分类 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_SVM = "svm";
        /// <summary>
        /// 误差空间表达 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_SpatialError = "Probability_calculation";
        /// <summary>
        /// 高光谱降维 IDL 过程名
        /// </summary>
        public static readonly string IDL_FUN_BANDREDUCE = "bandreduction";
        public static readonly string FILE_BANDS;

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
                Path.Combine(STARTPATH,  "GFS.ini");

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
            ConstDef.FILE_BANDS =
    Path.Combine(PATH_IDL, "bands.txt");

            //读取运管服务地址
            IniHelper ini = new IniHelper(ConstDef.FILE_SYSTEMCONFIG);
            ConstDef.URL_UPDATETASK = ini.ReadIniValue("UpdateTaskStatus", "url");

        }
    }
}
