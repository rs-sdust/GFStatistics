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
using DevExpress.Utils;
using GFS.ClassificationBLL;
using System.Threading;

namespace GFS.Classification
{
    public partial class frmDVI : DevExpress.XtraEditors.XtraForm
    {
        public frmDVI()
        {
            InitializeComponent();
        }
        private void frmDVI_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize;
            MapAPI.GetAllLayers(cmbInRaster, null);
        }
        private void siBInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                int bandCount = MAP.GetBandCount(file);
                if (bandCount < 2)
                {
                    XtraMessageBox.Show("输入影像至少应包含两个波段！", "提示信息");
                    this.cmbInRaster.Text = string.Empty;
                }
                else
                    this.cmbInRaster.Text = file;
                InitialBands(bandCount);
            }
        }
        private void cmbInRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Empty == cmbInRaster.SelectedItem.ToString())
                return;
            int bandCount = MAP.GetBandCount(cmbInRaster.SelectedItem.ToString());
            if (bandCount < 2)
            {
                XtraMessageBox.Show("输入影像至少应包含两个波段！", "提示信息");
                this.cmbInRaster.Text = string.Empty;
            }
            InitialBands(bandCount);
        }

        private void siBOutput_Click(object sender, EventArgs e)
        {
            string localFilePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                txtOut.Text = saveFileDialog1.FileName;
            }
        }
        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbInRaster.Text.TrimEnd()))
            {
                XtraMessageBox.Show("输入文件不能为空！");
                return;
            }
            else if (cBERed.SelectedIndex <0)
            {
                XtraMessageBox.Show("请选择红光波段！");
                return;
            }
            else if (cBENIRed.SelectedIndex < 0)
            {
                XtraMessageBox.Show("请选择近红外波段！");
                return;
            }
            else if (string.IsNullOrEmpty(txtOut.Text.TrimEnd()))
            {
                XtraMessageBox.Show("输出文件不能为空！");
                return;
            }
            else
            {

                WaitDialogForm frmWait = new WaitDialogForm("正在计算...", "提示信息");
                try
                {
                    frmWait.Owner = this;
                    frmWait.TopMost = false;
                    VegetationIndex.Calculate(VegIndex.DVI, cmbInRaster.Text.TrimEnd(), txtOut.Text.TrimEnd()
                        , cBERed.SelectedIndex, cBENIRed.SelectedIndex);
                    Thread.Sleep(3000);
                    if (DialogResult.OK == XtraMessageBox.Show("计算完毕，是否加载结果文件?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        MAP.AddRasterFileToMap(txtOut.Text.TrimEnd());
                    }

                    this.Close();

                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Log.WriteLog(typeof(frmDVI), ex);
                }
                finally
                {
                    frmWait.Close();
                }
            }
        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBHelp.Text = "显示帮助>>";
            }
        }

        private void InitialBands(int bandCount)
        {
            this.cBERed.Properties.Items.Clear();
            this.cBENIRed.Properties.Items.Clear();

            if (bandCount < 2)
            {
                this.cBERed.Text = string.Empty;
                this.cBENIRed.Text = string.Empty;
                return;
            }
            for (int i = 0; i < bandCount; i++)
            {
                this.cBERed.Properties.Items.Add("Band_" + (i + 1));
                this.cBENIRed.Properties.Items.Add("Band_" + (i + 1));
            }
            if (bandCount >= 4)
            {
                this.cBERed.SelectedIndex = 2;
                this.cBENIRed.SelectedIndex = 3;
            }
        }



       
    }
}