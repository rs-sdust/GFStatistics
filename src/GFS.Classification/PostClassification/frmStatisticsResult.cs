using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.ClassificationBLL;
using DevExpress.Utils;
using GFS.BLL;

namespace GFS.Classification
{
    public partial class frmStatisticsResult : DevExpress.XtraEditors.XtraForm
    {
        public frmStatisticsResult()
        {
            InitializeComponent();
        }
        private void frmStatisticsResult_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize;
            MapAPI.GetAllLayers(cBEResult, null);
        }
        private void siBResult_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                cBEResult.Text = file;
            }
        }

        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cBEResult.Text.Trim()))
            {
                MessageBox.Show("错误信息：n输入分类结果的值：是必需的");
            }
            else
            {
                WaitDialogForm frmWait = new WaitDialogForm("正在统计...", "提示信息");
                try
                {
                    frmWait.Owner = this;
                    frmWait.TopMost = false;
                    DataTable table = new DataTable();
                    StatisticsResult acc = new StatisticsResult();
                    if (acc.Statistics(cBEResult.Text, out table))
                    {
                        frmWait.Close();
                        frmStatisticsTable frm = new frmStatisticsTable(table);
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Log.WriteLog(typeof(frmStatisticsResult), ex);
                }
                finally
                {
                    frmWait.Close();
                    //this.Close();
                }
              
            }
        }
        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBHelp.Text = "显示帮助>>";
            }
        }


    }
}