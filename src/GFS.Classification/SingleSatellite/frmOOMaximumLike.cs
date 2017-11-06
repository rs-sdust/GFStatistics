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
    public partial class frmOOMaximumLike : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        public frmOOMaximumLike()
        {
            InitializeComponent();
        }

        private void frmOOMaximumLike_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            MapAPI.GetAllLayers(cmbInRaster, null);
        }

        private void btnInRaster_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInRaster.Text = dlg.FileName;
        }

        private void btnInROI_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开样本文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "样本文件|*.sample";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtROI.Text = dlg.FileName;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = dialog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在分类...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                MaximumLikeHood ooC = new MaximumLikeHood(cmbInRaster.Text, txtROI.Text, txtOut.Text);
                ooC.Execute();
                if (XtraMessageBox.Show("分类完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    MAP.AddRasterFileToMap(txtOut.Text.TrimEnd());
                this.Close();
            }
            catch (Exception ex)
            {
                //此处调用成功并写出结果后IDL仍会抛出异常。通过判断输出文件确定是否成功
                Log.WriteLog(typeof(frmSegmentation), ex);
                if (File.Exists(txtOut.Text.TrimEnd()))
                {
                    FileInfo fInfo = new FileInfo(txtOut.Text.TrimEnd());
                    if (fInfo.Length / (1024 * 1024) > 1)
                    {
                        if (XtraMessageBox.Show("分类完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MAP.AddRasterFileToMap(txtOut.Text.TrimEnd());
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("分类失败：\r\n" + ex.Message, "提示信息");
                }
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
    }
}