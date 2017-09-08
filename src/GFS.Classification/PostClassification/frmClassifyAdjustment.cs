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
    public partial class frmClassifyAdjustment : DevExpress.XtraEditors.XtraForm
    {
        public frmClassifyAdjustment()
        {
            InitializeComponent();
        }

        private void siBRaster_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                cBEreaster.Text = file;
            }
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
                cBEresult.Text = file;
            }
        }

        private void siBOK_Click(object sender, EventArgs e)
        {
            var ClassifyAdjustment=new frmClassifyAdjustment1();
            ClassifyAdjustment.ShowDialog();
        }

        private void siBconcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBhelp_Click(object sender, EventArgs e)
        {

            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBhelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBhelp.Text = "显示帮助>>";
            }
        }
    }
}