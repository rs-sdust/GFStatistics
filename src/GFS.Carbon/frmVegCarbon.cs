using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.CarbonBLL;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace GFS.Carbon
{
    public partial class frmVegCarbon : Form
    {
        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();
        public frmVegCarbon()
        {
            InitializeComponent();
        }

        private void frmVegCarbon_Load(object sender, EventArgs e)
        {

        }

        private void btnForestBiology_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbForestBiology.Text = openDlg.FileName;
            }
        }

        private void btnForestDensity_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbForestDensity.Text = openDlg.FileName;
            }
        }

        private void btnShrubBiology_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbShrubBiology.Text = openDlg.FileName;
            }
        }

        private void btnShrubDensity_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbShrubDensity.Text = openDlg.FileName;
            }
        }

        private void btnGrassBiology_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbGrassBiology.Text = openDlg.FileName;
            }
        }

        private void btnGrassDensity_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbGrassDensity.Text = openDlg.FileName;
            }
        }

        private void btnOutBiology_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存生物量文件";
            saveDlg.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOutBiology.Text = saveDlg.FileName;
            }
        }

        private void btnOutCarbonDensity_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存碳密度文件";
            saveDlg.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOutCarbonDensity.Text = saveDlg.FileName;
            }
        }

        private void btnOutCarbon_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存碳储量文件";
            saveDlg.Filter = "Excel文件(*.xls)|*.xls";//过滤格式
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOutCarbon.Text = saveDlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbForestBiology.Text))
            {
                XtraMessageBox.Show("森林生物量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(cmbForestDensity.Text))
            {
                XtraMessageBox.Show("森林碳密度为空！");
                return;
            }
            else if (string.IsNullOrEmpty(cmbShrubBiology.Text))
            {
                XtraMessageBox.Show("灌丛生物量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(cmbShrubDensity.Text))
            {
                XtraMessageBox.Show("灌丛碳密度为空！");
                return;
            }
            else if (string.IsNullOrEmpty(cmbGrassBiology.Text))
            {
                XtraMessageBox.Show("草地生物量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(cmbGrassDensity.Text))
            {
                XtraMessageBox.Show("草地碳密度为空！");
                return;
            }
            else if (string.IsNullOrEmpty(txtOutBiology.Text))
            {
                XtraMessageBox.Show("总生物量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(txtOutCarbonDensity.Text))
            {
                XtraMessageBox.Show("总碳密度为空！");
                return;
            }
            else if (string.IsNullOrEmpty(txtOutCarbon.Text))
            {
                XtraMessageBox.Show("总碳储量为空！");
                return;
            }
            else
            {
                WaitDialogForm frmWait = new WaitDialogForm("正在处理...", "提示信息");
                frmWait.Owner = this;
                frmWait.TopMost = false;
                try
                {
                    List<string> biomass = new List<string>() { this.cmbForestBiology.Text, this.cmbShrubBiology.Text, this.cmbGrassBiology.Text };
                    List<string> density = new List<string>() { this.cmbForestDensity.Text, this.cmbGrassDensity.Text, this.cmbGrassDensity.Text };
                    List<double> storage = new List<double>() { double.Parse(this.spinForestCarbon.Value.ToString()), 
                double.Parse(this.spinShrubCarbon.Value.ToString()), double.Parse(this.spinGrassCarbon.Value.ToString()) };
                    VegCarbonSum sum = new VegCarbonSum(biomass, density, storage,
                                        this.txtOutBiology.Text, this.txtOutCarbonDensity.Text, this.txtOutCarbon.Text);
                    frmWait.Caption = "计算总生物量...";
                    if (!(sum.CalBiomass()))
                    {
                    }
                    frmWait.Caption = "计算总碳密度...";
                    if (!(sum.CalDensity()))
                    { }
                    frmWait.Caption = "计算总碳储量...";
                    if (!(sum.CalStorage()))
                    { }
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

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
