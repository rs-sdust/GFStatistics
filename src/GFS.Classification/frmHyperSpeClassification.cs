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
    public partial class frmHyperSpeClassification : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();

        private string _Hyper;
        private string _ROI;
        private string _Result;

        public frmHyperSpeClassification()
        {
            InitializeComponent();
        }


        private void frmHyperSpeClassification_Load(object sender, EventArgs e)
        {
            BLL.MapAPI.GetAllLayers(cmbInHyper, null);
        }
        private void btnInHyper_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "栅格文件|*.tif";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInHyper.Text = openDlg.FileName;
        }
        private void cmbInHyper_TextChanged(object sender, EventArgs e)
        {
            _Hyper = cmbInHyper.Text;
        }

        private void btnInROI_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "样本文件|*.sample";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _ROI = this.cmbInROI.Text = openDlg.FileName;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存文件";
            saveDlg.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                _Result = this.txtOut.Text = saveDlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string msg = "";
            BLL.frmWaitDialog frmWait = new BLL.frmWaitDialog("高光谱分类...", "提示信息");
            try
            {
                ClassificationBLL.HyperSpeClassification hyperClass = new ClassificationBLL.HyperSpeClassification(_Hyper, _ROI, _Result);
                frmWait.Caption = "参数检查...";
                Application.DoEvents();
                if (!hyperClass.ChkPara(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "数据降维...";
                Application.DoEvents();
                if (!hyperClass.BandReduce(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "svm分类...";
                Application.DoEvents();
                if (!hyperClass.SVM(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "信息熵计算...";
                Application.DoEvents();
                if (!hyperClass.Entropy(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                } 
                frmWait.Caption = "阈值计算...";
                Application.DoEvents();
                if (!hyperClass.CalEntropyMean(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "纯净像元提取...";
                Application.DoEvents();
                if (!hyperClass.ExtractPurePixel(out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "混合像元分解...";
                Application.DoEvents();
                if (!hyperClass.MergePixel(out msg))
                {
                    if (!msg.StartsWith("对 COM 组件的调用返回了错误"))
                    {
                        XtraMessageBox.Show(msg);
                        return;
                    }
                }
                BLL.ProductMeta meta = new BLL.ProductMeta(txtOut.Text.TrimEnd(), "GF5", "", "高光谱分类", "作物识别结果");
                meta.WriteGeoMeta();
                BLL.ProductQuickView view = new BLL.ProductQuickView(txtOut.Text.TrimEnd());
                view.Create();
                if (DialogResult.OK == XtraMessageBox.Show("分类完毕，是否加载结果？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    BLL.MapAPI.AddRasterFileToMap(_Result);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
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

        private void frmHyperSpeClassification_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            BLL.HelpManager.ShowHelp(this);
        }


    }
}