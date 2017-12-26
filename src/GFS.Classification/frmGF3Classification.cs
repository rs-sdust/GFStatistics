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
using GFS.BLL;

namespace GFS.Classification
{
    public partial class frmGF3Classification : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 像元roi
        /// </summary>
        private string _pixelROI;
        /// <summary>
        /// 图斑roi
        /// </summary>
        private string _segmentROI;
        /// <summary>
        /// gf3极化特征
        /// </summary>
        private string _GF3Polarity;
        /// <summary>
        /// gf1影像
        /// </summary>
        private string _GF1;
        /// <summary>
        /// 修正的最终分类结果
        /// </summary>
        private string _class;


        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();

        public frmGF3Classification()
        {
            InitializeComponent();
        }

        private void frmGF3Classification_Load(object sender, EventArgs e)
        {
            MapAPI.GetAllLayers(cmbInGF3,null);
            MapAPI.GetAllLayers(cmbInGF1, null);
        }

        private void btnInGF3_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "栅格文件|*.tif";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInGF3.Text = openDlg.FileName;
        }

        private void btnInGF1_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "矢量文件|*.shp";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInGF1.Text = openDlg.FileName;
        }

        private void btnInROIFeature_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "样本文件|*.sample";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInROIFeature.Text = openDlg.FileName;
        }

        private void btnInROIPixel_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.FileName = string.Empty;
            openDlg.Filter = "样本文件|*.sample";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInROIPixel.Text = openDlg.FileName;
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
        private void cmbInGF3_TextChanged(object sender, EventArgs e)
        {
            _GF3Polarity = cmbInGF3.Text;
        }

        private void cmbInGF1_TextChanged(object sender, EventArgs e)
        {
            _GF1 = cmbInGF1.Text;
        }

        private void cmbInROIFeature_TextChanged(object sender, EventArgs e)
        {
            _segmentROI = cmbInROIFeature.Text;
        }

        private void cmbInROIPixel_TextChanged(object sender, EventArgs e)
        {
            _pixelROI = cmbInROIPixel.Text;
        }
        private void txtOut_TextChanged(object sender, EventArgs e)
        {
            _class = txtOut.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmWaitDialog frmWait = new frmWaitDialog("GF3分类...","提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                ClassificationBLL.GF3Classification gf3Class = new ClassificationBLL.GF3Classification(_GF3Polarity, _GF1, _pixelROI, _segmentROI,_class);
                frmWait.Caption = "参数检查...";
                string msg = "";
                if (!gf3Class.ChkPara(out msg))
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                frmWait.Caption = "极化特征区域统计...";
                if (!gf3Class.ZonalPolarity(out msg))
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                frmWait.Caption = "图斑尺度分类...";
                Application.DoEvents();
                if (!gf3Class.SVMFeature(out msg))
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                frmWait.Caption = "像元尺度分类...";
                Application.DoEvents();
                if (!gf3Class.SVMPixel(out msg))
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                frmWait.Caption = "计算图斑信息熵...";
                Application.DoEvents();
                if (!gf3Class.Entropy())
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                frmWait.Caption = "混合图斑修正...";
                Application.DoEvents();
                if (!gf3Class.ClassMerge())
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                BLL.ProductMeta meta = new ProductMeta(_class, "GF3", "", "图斑像元综合分类", "作物识别结果");
                meta.WriteGeoMeta();
                BLL.ProductQuickView view = new BLL.ProductQuickView(_class);
                view.Create();
                if (DialogResult.OK == XtraMessageBox.Show("分类完毕！是否加载结果？","提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    MapAPI.AddRasterFileToMap(_class);
                }
            }
            catch (Exception ex)
            {
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

        private void frmGF3Classification_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }






    }
}