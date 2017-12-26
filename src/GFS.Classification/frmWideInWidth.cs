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
    public partial class frmWideInWidth : DevExpress.XtraEditors.XtraForm
    {

        private string _Img;
        private string _Sample;
        private string _Class;

        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();

        public frmWideInWidth()
        {
            InitializeComponent();
        }

        private void frmWideInWidth_Load(object sender, EventArgs e)
        {
            BLL.MapAPI.GetAllLayers(cmbInImg, null);
        }

        private void btnInImg_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "栅格文件|*.tif";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInImg.Text = openDlg.FileName;
        }

        private void btnInSample_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "样本文件|*.sample";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInSample.Text = openDlg.FileName;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存文件";
            saveDlg.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = saveDlg.FileName;
            }
        }
        private void cmbInImg_TextChanged(object sender, EventArgs e)
        {
            _Img = cmbInImg.Text;
        }

        private void cmbInSample_TextChanged(object sender, EventArgs e)
        {
            _Sample = cmbInSample.Text;
        }

        private void txtOut_TextChanged(object sender, EventArgs e)
        {
            _Class = txtOut.Text;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmWideInWidth_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            BLL.HelpManager.ShowHelp(this);
        }


    }
}