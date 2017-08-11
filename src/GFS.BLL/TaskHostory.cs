﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace GFS.BLL
{
    public  class TaskHostory
    {
        private string historyFile;
        private List<string> taskHistory = null;
        public List<string> TaskHistory
        {
            get { return this.taskHistory; }
        }
        private int taskCount=0;
        private int imageIndex = 17;
        /// <summary>
        /// 记录最近的任务历史
        /// </summary>
        /// <param name="historyFile">历史文件</param>
        /// <param name="taskCount">要记录的历史个数</param>
        public TaskHostory(string historyFile,int taskCount)
        {
            taskHistory = new List<string>();
            this.historyFile = historyFile;
            this.taskCount = taskCount;
        }

        public void LoadHistory()
        {
            if (!File.Exists(historyFile))
            {
                Log.WriteLog(typeof(TaskHostory), "读取任务历史失败：文件不存在！");
                return;
            }
            //if (taskHistory.Count > 0)
            //    taskHistory.Clear();
            if (EnviVars.instance.RecentFilesCtrl.Items.Count > 0)
            {
                EnviVars.instance.RecentFilesCtrl.Items.Clear();
            }

            XmlTextReader xmlReader= new XmlTextReader(historyFile);
            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlReader.Name == "Task")
                        {
                            //taskHistory.Add(xmlReader.ReadElementContentAsString());
                            string taskFile=xmlReader.ReadElementContentAsString();
                            EnviVars.instance.RecentFilesCtrl.Items.Add(taskFile, imageIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Log.WriteLog(typeof(TaskHostory), ex);
            }
            finally
            {
                xmlReader.Close();
            }

        }

        public void AddTask(string taskFile)
        {
            //if (taskHistory.Count >= taskCount)
            //    taskHistory.RemoveAt(0);
            //taskHistory.Add(taskFile);
            try
            {
                //任务历史已存在
                if (TaskExits(taskFile))
                    return;
                //任务历史超过要记录个数
                if (EnviVars.instance.RecentFilesCtrl.Items.Count >= taskCount)
                {
                    EnviVars.instance.RecentFilesCtrl.Items.RemoveAt(0);
                }
                //添加任务到历史
                EnviVars.instance.RecentFilesCtrl.Items.Add(taskFile, imageIndex);
            }
            catch (Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(TaskHostory), ex);
            }
        }
        private bool TaskExits(string taskFile)
        {
            foreach (ImageListBoxItem task in EnviVars.instance.RecentFilesCtrl.Items)
            {
                if (taskFile == task.Value.ToString())
                    return true;
            }
            return false;
        }

        public void SaveHistory()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(historyFile,Encoding.UTF8);
            try
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("TaskHistory");
                foreach (ImageListBoxItem task in EnviVars.instance.RecentFilesCtrl.Items)
                {
                    xmlWriter.WriteStartElement("Task");
                    xmlWriter.WriteString(task.ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

            }
            catch(Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(TaskHostory), ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

        }





    }
}
