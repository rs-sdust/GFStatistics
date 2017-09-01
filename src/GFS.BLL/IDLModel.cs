// ***********************************************************************
// Assembly         : HDPro
// Author           : YXQ
// Created          : 10-27-2016
//
// Last Modified By : YXQ
// Last Modified On : 10-22-2016
// ***********************************************************************
// <copyright file="IDLModel.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>
//  编译和执行IDL代码
// </summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class IDLModel.
    /// </summary>
    public class IDLModel
    {
        /// <summary>
        /// The pro file path
        /// </summary>
        private string proFilePath;
        /// <summary>
        /// The pro file list
        /// </summary>
        private List<string> proFileList = new List<string>();
        /// <summary>
        /// The o COM IDL
        /// </summary>
        COM_IDL_connectLib.COM_IDL_connect oComIDL = new COM_IDL_connectLib.COM_IDL_connect();
        /// <summary>
        /// Initializes a new instance of the <see cref="IDLModel" /> class.
        /// </summary>
        /// <param name="proFilePath">The pro file path.</param>
        public IDLModel(string proFilePath)
        {
            this.proFilePath = proFilePath;
            this.IniProList();
            this.CompileAll();
        }
        //初始化pro文件列表
        /// <summary>
        /// Inis the pro list.
        /// </summary>
        private void IniProList()
        {
            proFileList.Clear();
            //获取当前目录下的所有pro文件
            string[] fNames = Directory.GetFiles(proFilePath, "*.pro");
            foreach (string file in fNames)
            {
                proFileList.Add(file.ToString());
            }
        }
        //编译所有pro文件
        /// <summary>
        /// Compiles all.
        /// </summary>
        private void CompileAll()
        {
            oComIDL.CreateObject(0, 0, 0);

            foreach (string file in proFileList)
            {
                oComIDL.ExecuteString(@".compile '" + file + "'");
            }
        }
        //执行命令
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        public void Execute(string cmd)
        {
            try
            {
                oComIDL.ExecuteString(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// //销毁对象
        /// </summary>
        public void Distroy()
        {
            oComIDL.DestroyObject();
        }

    }
}
