using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GFS.Classification
{
    public partial class frmStatisticsResult : DevExpress.XtraEditors.XtraForm
    {
        public frmStatisticsResult()
        {
            InitializeComponent();
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