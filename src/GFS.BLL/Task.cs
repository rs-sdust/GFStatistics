// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="Task.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>parse and update task</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace GFS.BLL
{
    public class Task
    {
        /// <summary>
        /// 调用运管提供webs接口更新任务
        /// </summary>
        /// <param name="taskFile">The task file.</param>
        public static void UpdateTask(string taskFile)
        {
                //2、调用运管提供webs接口更新任务
            string[] args = new string[1];
            args[0] = DeserializeTask(taskFile);
            WSHelper.InvokeWebService(ConstDef.URL_UPDATETASK, "UpdateTask", args);
        }

        /// <summary>
        /// 反序列化任务文件.
        /// </summary>
        /// <param name="taskFile">The task file.</param>
        /// <returns>System.String.</returns>
        private static string DeserializeTask(string taskFile)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(taskFile);
                string strTask=xdoc.InnerXml;
                
                //XmlSerializer xs = new XmlSerializer(typeof(string));
                //StringReader sr = new StringReader(taskFile);
                //string strTask = (string)xs.Deserialize(sr);
                //sr.Close();
                //sr.Dispose();
                return strTask;
            }
            catch(Exception ex)
            {
                Log.WriteLog(typeof(Task),ex);
                return "";
            }
        }
        /// <summary>
        /// 解析任务文件.
        /// </summary>
        /// <param name="taskFile">The task file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ParseTask(string taskFile)
        {
            XmlTextReader xmlReader = new XmlTextReader(taskFile);
            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlReader.Name == "F_TASKID")
                        {
                            EnviVars.instance.taskID = xmlReader.ReadElementContentAsLong();
                        }
                        else if (xmlReader.Name == "F_TASKSTATE")
                        {
                            EnviVars.instance.taskState = (TaskState)xmlReader.ReadElementContentAsInt();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取任务文件失败:" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(TaskHistory), ex);
                return false;
            }
            finally
            {
                xmlReader.Close();
            }
        }

        /// <summary>
        /// 更新任务状态到任务文件.
        /// </summary>
        /// <param name="taskFile">The task file.</param>
        /// <param name="state">The state.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateTaskState(string taskFile, TaskState state)
        {
            if(UpdateXmlNode(taskFile,"F_TASKSTATE",((int)state).ToString()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新xml指定节点.
        /// </summary>
        /// <param name="taskFile">The task file.</param>
        /// <param name="NodeName">Name of the node.</param>
        /// <param name="NodeValue">The node value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool UpdateXmlNode(string taskFile, string NodeName, string NodeValue)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(taskFile);
                XmlNode xn = doc.SelectSingleNode("//" + NodeName + "");
                xn.InnerText = NodeValue;
                doc.Save(taskFile);
                return true;
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("更新任务文件失败:" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(Task), ex);
                return false;
            }
            finally
            {
            }
        }
    }
}


