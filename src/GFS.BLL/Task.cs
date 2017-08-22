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

namespace GFS.BLL
{
    public class Task
    {
        //调用运管模块提供接口更新任务
        public static void UpdateTask(string taskFile)
        {

                //2、调用运管提供webs接口更新任务

        }

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
                            EnviVars.instance.taskID = xmlReader.ReadElementContentAsInt();
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

        public static bool UpdateTaskState(string taskFile, TaskState state)
        {
            if(UpdateXmlNode(taskFile,"F_TASKSTATE",((int)state).ToString()))
                return true;
            else
                return false;
        }

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


