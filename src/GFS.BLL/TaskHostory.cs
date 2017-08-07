using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

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
            if (taskHistory.Count > 0)
                taskHistory.Clear();
            XmlTextReader xmlReader= new XmlTextReader(historyFile);
            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlReader.Name == "Task")
                        {
                            taskHistory.Add(xmlReader.ReadElementContentAsString());
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
            if (taskHistory.Count >= taskCount)
                taskHistory.RemoveAt(0);
            taskHistory.Add(taskFile);
        }

        public void SaveHistory()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(historyFile,Encoding.UTF8);
            try
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("TaskHistory");
                foreach (string task in taskHistory)
                {
                    xmlWriter.WriteStartElement("Task");
                    xmlWriter.WriteString(task);
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
