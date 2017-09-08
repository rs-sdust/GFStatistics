using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.ClassificationBLL;
using DevExpress.Utils;
using System.Threading;
using GFS.BLL;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;

namespace GFS.Classification
{
    public partial class frmNDVI : DevExpress.XtraEditors.XtraForm
    {

        public frmNDVI()
        {
            InitializeComponent();
        }
        private void frmNDVI_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize; 
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
                cmbInRaster.Text = file;
                string[] Band;
                if (VegetationIndex.ReadBands(cmbInRaster.Text,  out Band))
                {
                    for (int j=0; j < Band.Length;j++ )
                    {
                        //cBERed.Properties.Items.Clear();
                        //cBENIRed.Properties.Items.Clear();
                        cBERed.Properties.Items.Add(Band[j]);
                        cBENIRed.Properties.Items.Add(Band[j]);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void siBOutput_Click(object sender, EventArgs e)
        {
            string localFilePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex =1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                txtOut.Text = saveFileDialog1.FileName;
            }
        }

        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbInRaster.Text.Trim()) || string.IsNullOrEmpty( cBERed.Text.Trim()) || string.IsNullOrEmpty(cBENIRed.Text.Trim())||string.IsNullOrEmpty(txtOut.Text.Trim()))
            {
                MessageBox.Show("错误信息：\n输入影像的值：是必需的\n参数的值：不能为空\n输出结果的值;是必需的");
            }
            else
            {

                WaitDialogForm frmWait = new WaitDialogForm("提示", "正在计算......");
                try
                {
                    frmWait.Owner = this;
                    frmWait.TopMost = false;
                    string Messagex = string.Empty;
                    VegetationIndex ndvi = new VegetationIndex();
                    if (ndvi.NDVI(cmbInRaster.Text, cBERed.Text, cBENIRed.Text, txtOut.Text))
                    {
                        System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("计算成功,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            //添加结果到主地图视图
                            MAP.AddRasterFileToMap(txtOut.Text);
                        }

                        else
                        {
                            XtraMessageBox.Show("加载失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                  
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Log.WriteLog(typeof(frmNDVI), ex);
                }
                finally
                {
                    frmWait.Close();
                    this.Close();
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

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}