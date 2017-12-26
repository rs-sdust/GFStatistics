using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.CarbonBLL;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using GFS.BLL;

namespace GFS.Carbon
{
    public partial class frmSoilCarbon : Form
    {
        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();


        public frmSoilCarbon()
        {
            InitializeComponent();
        }

        private void frmSoilCarbon_Load(object sender, EventArgs e)
        {

        }

        private void btnInShp_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "矢量文件|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbInShp.Text = openDlg.FileName;
                BindFields(openDlg.FileName);
            }
        }

        private void btnOutCarbon_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存文件";
            saveDlg.Filter = "Excel文件|*.xls";//过滤格式
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOutCarbon.Text = saveDlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbInShp.Text))
            {
                XtraMessageBox.Show("土壤矢量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbSoilType.Text))
            {
                XtraMessageBox.Show("土壤类型为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbSoilArea.Text))
            {
                XtraMessageBox.Show("土壤面积为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbSoilThick.Text))
            {
                XtraMessageBox.Show("土壤厚度为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbSoilWeight.Text))
            {
                XtraMessageBox.Show("土壤容重为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbOrganics.Text))
            {
                XtraMessageBox.Show("有机物含量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.cmbGravel.Text))
            {
                XtraMessageBox.Show("砾石含量为空！");
                return;
            }
            else if (string.IsNullOrEmpty(this.txtOutCarbon.Text))
            {
                XtraMessageBox.Show("输出文件为空！");
                return;
            }
            else
            {
                frmWaitDialog frmWait = new frmWaitDialog("正在处理...", "提示信息");
                frmWait.Owner = this;
                frmWait.TopMost = false;
                try
                {
                    SoilCarbon soil = new SoilCarbon(this.cmbInShp.Text, cmbSoilType.Text, cmbSoilArea.Text, cmbSoilThick.Text, cmbSoilWeight.Text, cmbOrganics.Text, cmbGravel.Text, txtOutCarbon.Text);
                    if(soil.Cal_Storage())
                    XtraMessageBox.Show("计算完毕！");
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

        private void BindFields(string file)
        {
            this.cmbSoilType.Properties.Items.Clear();
            this.cmbSoilArea.Properties.Items.Clear();
            this.cmbSoilThick.Properties.Items.Clear();
            this.cmbSoilWeight.Properties.Items.Clear();
            this.cmbOrganics.Properties.Items.Clear();
            this.cmbGravel.Properties.Items.Clear();

            this.cmbSoilType.Text = string.Empty;
            this.cmbSoilArea.Text = string.Empty;
            this.cmbSoilThick.Text = string.Empty;
            this.cmbSoilWeight.Text = string.Empty;
            this.cmbOrganics.Text = string.Empty;
            this.cmbGravel.Text = string.Empty;

            List<string> strFields = new List<string>();
            List<string> numFields = new List<string>();
            try
            {
                ShpFileOP.GetFields(file, true, numFields);
                ShpFileOP.GetFields(file, false, strFields);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            this.cmbSoilType.Properties.Items.AddRange(strFields);

            this.cmbSoilArea.Properties.Items.AddRange(numFields);
            this.cmbSoilThick.Properties.Items.AddRange(numFields);
            this.cmbSoilWeight.Properties.Items.AddRange(numFields);
            this.cmbOrganics.Properties.Items.AddRange(numFields);
            this.cmbGravel.Properties.Items.AddRange(numFields);


        }

        private void frmSoilCarbon_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }
    }
}
