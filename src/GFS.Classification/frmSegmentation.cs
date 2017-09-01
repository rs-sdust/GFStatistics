using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.BLL;
using System.IO;
using DevExpress.Utils;

namespace GFS.Classification
{
    public partial class frmSegmentation : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        
        public frmSegmentation()
        {
            InitializeComponent();
        }

        private void frmSegmentation_Load(object sender, EventArgs e)
        {
            this.ztbSegment.Value = 50;
            this.ztbMerge.Value = 40;
            this.ztbKernel.Value = 5;
        }

        private void ztbSegment_EditValueChanged(object sender, EventArgs e)
        {
            this.spinSegment.EditValue = this.ztbSegment.EditValue;
        }

        private void spinSegment_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbSegment.EditValue = this.spinSegment.EditValue;
        }

        private void ztbMerge_EditValueChanged(object sender, EventArgs e)
        {
            this.spinMerge.EditValue = this.ztbMerge.EditValue;
        }

        private void spinMerge_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbMerge.EditValue = this.spinMerge.EditValue;
        }

        private void ztbKernel_EditValueChanged(object sender, EventArgs e)
        {
            this.spinKernel.EditValue = this.ztbKernel.EditValue;
        }

        private void spinKernel_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbKernel.EditValue = this.spinKernel.EditValue;
        }

        private void btnIn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.btnIn.Text = dlg.FileName;
        }

        private void btnOut_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog dilog = new SaveFileDialog();
            dilog.Title ="保存文件";
            dilog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (dilog.ShowDialog() == DialogResult.OK)
            {               
                this.btnOut.Text = dilog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(btnIn.Text.TrimEnd()))
            {
                XtraMessageBox.Show("输入文件不存在！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            IDLModel idl=null;
            WaitDialogForm frmWait = new WaitDialogForm("正在分割...", "提示信息");
            try
            {
                idl = new IDLModel(ConstDef.PATH_IDL);
                string cmd = "FX_Segmentonly,'" + btnIn.Text.TrimEnd() + "'," +
                            spinSegment.Value.ToString() + "," + spinMerge.Value.ToString() + "," +
                            spinKernel.Value.ToString() + ",'" + btnOut.Text.TrimEnd() + "'";
                idl.Execute(cmd);
            }
            catch(Exception ex)
            {
                //此处调用成功并写出结果后仍会抛出异常。
                //XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                if (idl != null)
                    idl.Distroy();
                frmWait.Close();
            }
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}