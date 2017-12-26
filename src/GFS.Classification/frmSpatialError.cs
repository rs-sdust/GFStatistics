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
    public partial class frmSpatialError : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();
        private string _classFile = "";
        private int _classValue = 0;
        public frmSpatialError()
        {
            InitializeComponent();
        }

        private void frmSpatialError_Load(object sender, EventArgs e)
        {
            BLL.MapAPI.GetAllLayers(cmbInClass, null);
        }

        private void btnInClass_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "栅格文件|*.tif";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInClass.Text = openDlg.FileName;
        }

        //private void btnInCrop_Click(object sender, EventArgs e)
        //{

        //}

        private void cmbInClass_TextChanged(object sender, EventArgs e)
        {
            _classFile = cmbInClass.Text;
            //获取_classFile唯一值
            List<string> classList = Common.EngineAPI.GetRasterUniqueValue(_classFile);
            this.cmbInCrop.Properties.Items.Clear();
            this.cmbInCrop.Properties.Items.AddRange(classList);
        }

        private void cmbInCrop_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbInCrop.Text, out _classValue))
            {
                _classValue = 0;
                XtraMessageBox.Show("目标作物数据类型错误！");
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            BLL.frmWaitDialog frmWait = new BLL.frmWaitDialog("参数检查...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                string msg = "";
                ClassificationBLL.SpatialError spError = new ClassificationBLL.SpatialError(_classFile, _classValue, 45, txtOut.Text);
                if (!spError.ChkParam(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "误差空间表达...";
                if (spError.Execute(out msg))
                {
                    if (DialogResult.OK == XtraMessageBox.Show("执行成功！是否加载结果？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        BLL.MapAPI.AddRasterFileToMap(txtOut.Text);
                    }
                }
                else
                {
                    XtraMessageBox.Show(msg);
                    return;
                }

            }
            catch (Exception ex)
            {
                BLL.Log.WriteLog(typeof(frmSpatialError), ex);
                XtraMessageBox.Show(ex.Message);
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

        private void frmSpatialError_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            BLL.HelpManager.ShowHelp(this);
        }
    }
}