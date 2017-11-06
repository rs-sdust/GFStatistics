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
using System.IO;
using GFS.BLL;
using DevExpress.Utils;

namespace GFS.Classification
{
    public partial class frmStatisticsTable : DevExpress.XtraEditors.XtraForm
    {
        private DataTable datatable1 = null;
        //private  string[] stri = null;
        public frmStatisticsTable(DataTable datatable)
        {
            InitializeComponent();
            this.datatable1 = datatable;
            //this.stri = str1;
        }
        private void frmStatisticTable_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = datatable1;
            this.gridView1.BestFitColumns();
            gridView1.GroupPanelText = "各类别分类结果统计:";
        }
        private void siBResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存xls文件";
            dialog.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            } 

            ////已存在文件是否覆盖提示
            //if (System.IO.File.Exists(kk.FileName) && DevExpress.XtraEditors.XtraMessageBox.Show("该文件名已存在，是否覆盖？",
            //"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //{
            //    if (kk.ShowDialog() != DialogResult.OK)
            //        return;
            //}
            if (dialog.FileName != "")
            {
                try
                {
                    //System.IO.FileStream fs = (System.IO.FileStream)kk.OpenFile();
                    this.gridControl1.ExportToXls(dialog.FileName);
                    //fs.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("数据导出成功！", "提示");
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("数据导出失败！" + ex.Message, "提示");
                    Log.WriteLog(typeof(frmStatisticsResult), ex);
                }
                finally
                {
                    this.Close();
                }
            }
        }            
    }
}