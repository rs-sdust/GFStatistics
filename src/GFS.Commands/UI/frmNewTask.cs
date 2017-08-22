using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.SystemUI;
using GFS.BLL;
using ESRI.ArcGIS.Carto;
using System.Xml;

namespace GFS.Commands.UI
{
    public partial class frmNewTask : DevExpress.XtraEditors.XtraForm
    {
        private string taskFile = string.Empty;
        public frmNewTask()
        {
            InitializeComponent();
        }

        private void frmNewTask_Load(object sender, EventArgs e)
        {
            this.updateTime.EditValue = DateTime.Now;
        }

        private void btnTaskFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "新建任务文档";
            dialog.Filter = string.Format("{0} (*.mxd)|*.mxd", "任务文档");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.btnTaskFile.EditValue = this.taskFile = dialog.FileName;            
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //此处添加参数检查

            //此处清空图层，新建地图文档，新建任务xml
            ICommand cmd = new CmdClearLayers();
            cmd.OnCreate(EnviVars.instance.MapControl.Object);
            cmd.OnClick();
            //保存空白地图文档
            IMxdContents mxdContents = EnviVars.instance.MapControl.Map as IMxdContents;
            MapAPI.SaveMapDocument(mxdContents, taskFile, false);
            //新建任务xml
            NewTaskXML();
            GFS.BLL.EnviVars.instance.history.AddTask(taskFile);
            this.Close();

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewTaskXML()
        {
            int indexDot = taskFile.LastIndexOf(".");
            string taskXML = taskFile.Substring(0, indexDot) + ".xml";
            XmlTextWriter xmlWriter = new XmlTextWriter(taskXML, Encoding.UTF8);
            try
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("DocumentElement");
                xmlWriter.WriteStartElement("QueryResult");
                xmlWriter.WriteStartElement("F_TASKID");
                xmlWriter.WriteString(txtTaskID.Text);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("F_TASKNAME");
                xmlWriter.WriteString(txtTaskName.Text);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("F_PRODUCTNAME");
                xmlWriter.WriteString(txtProduct.Text);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("F_TASKSTATE");
                xmlWriter.WriteString("0");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("F_UNIT");
                xmlWriter.WriteString(txtCompany.Text);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("F_UPDATETIME ");
                xmlWriter.WriteString(updateTime.EditValue.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

            }
            catch (Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(TaskHistory), ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
    }
}