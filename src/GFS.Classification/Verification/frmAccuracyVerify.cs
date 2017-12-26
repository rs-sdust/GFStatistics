using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using GFS.ClassificationBLL;
using GFS.BLL;
using System.IO;

namespace GFS.Classification
{
    public partial class frmAccuracyVerify : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        public frmAccuracyVerify()
        {
            InitializeComponent();
        }
        private void frmAccuracyVerify_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize;
            MapAPI.GetAllLayers(cmbClassFile, null);

        }

        private void cmbClassFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnClass_Click(object sender, EventArgs e)
        {
            dlg.Multiselect = true;
            dlg.Title = "请选择文件";
            dlg.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbClassFile.Text = dlg.FileName;
            }
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开样本文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "样本文件|*.sample";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtSample.Text = dlg.FileName;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存文件";
            dlg.Filter = "文本文件|*.txt|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
                this.txtOut.Text = dlg.FileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmWaitDialog frmWait = new frmWaitDialog("正在验证...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                Verification verify = new Verification(cmbClassFile.Text.TrimEnd(), txtSample.Text.TrimEnd(), txtOut.Text.TrimEnd());
                verify.Verify();
                frmWait.Close();
                //show result
                frmVerifyResult frm = new frmVerifyResult(txtOut.Text.TrimEnd());
                frm.TopMost = true;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                //此处调用成功并写出结果后仍会抛出异常。
                Log.WriteLog(typeof(frmSegmentation), ex);
                if (File.Exists(txtOut.Text.TrimEnd()))
                {
                    frmWait.Close();
                    //show result
                    frmVerifyResult frm = new frmVerifyResult(txtOut.Text.TrimEnd());
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                else
                    XtraMessageBox.Show("执行验证失败：" + ex.Message);
            }
            finally
            {
                frmWait.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                btnHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                btnHelp.Text = "显示帮助>>";
            }
        }

        private void frmAccuracyVerify_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }


    }
}