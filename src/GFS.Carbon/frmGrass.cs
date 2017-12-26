using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using GFS.CarbonBLL;
using DevExpress.Utils;
using GFS.BLL;

namespace GFS.Carbon
{
    public partial class frmGrass : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 指数数据
        /// </summary>
        Dictionary<string, string> _Index = new Dictionary<string, string>();

        public frmGrass()
        {
            InitializeComponent();
        }


        private void btnLandCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "选择土地覆盖文件";
            openFD.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                this.cmbLandCover.Text = openFD.FileName;
                List<string> classList = RasterOP.GetClassFromRaster(cmbLandCover.Text);
                this.cmbPixel.Properties.Items.Clear();
                this.cmbPixel.Properties.Items.AddRange(classList);
            }
        }

        private void btnAddIndex_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Multiselect = true;
            openFD.Title = "选择指数文件";
            openFD.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                string[] ndviFiles = openFD.FileNames;
                if (ndviFiles != null && ndviFiles.Length > 0)
                {
                    foreach (string file in ndviFiles)
                    {
                        FileInfo fileinfo = new FileInfo(file);
                        string key = "[" + fileinfo.Name + "]";
                        this.listIndex.Items.Add(key);
                        _Index.Add(fileinfo.Name, fileinfo.FullName);
                    }
                }
            }
        }

        private void siBdelete_Click(object sender, EventArgs e)
        {
            if (listIndex.SelectedItem != null)
            {
                string key = listIndex.SelectedItem.ToString();
                _Index.Remove(key.Substring(1, key.Length - 2));
                listIndex.Items.Remove(listIndex.SelectedItem);
            }
        }

        private void btnOutBiology_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "保存生物量文件";
            saveFD.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                this.txtOutBiology.Text = saveFD.FileName;
            }
        }

        private void btnOutCarbonDensity_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "保存碳密度文件";
            saveFD.Filter = "影像文件(*.tif;*.img)|*.tif;*.img";//过滤格式
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                this.txtOutCarbonDensity.Text = saveFD.FileName;
            }
        }

        private void btnOutCarbon_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "保存碳储量文件";
            saveFD.Filter = "Excel文件(*.xls)|*.xls";//过滤格式
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                this.txtOutCarbon.Text = saveFD.FileName;
            }
        }

        private void listIndex_DoubleClick(object sender, EventArgs e)
        {
            if (listIndex.SelectedItem != null)
            {
                string expression = this.txtExpression.Text;
                int curIndex = txtExpression.SelectionStart;
                string file = listIndex.SelectedItem.ToString();
                expression = expression.Insert(curIndex,file );
                this.txtExpression.Text = expression;
                this.txtExpression.SelectionStart = curIndex + file.Length;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbLandCover.Text))
            {
                XtraMessageBox.Show("土地覆盖文件为空！");
            }
            else if (string.IsNullOrEmpty(cmbPixel.Text))
            {
                XtraMessageBox.Show("草地像元值为空！");
            }
            else if (string.IsNullOrEmpty(txtExpression.Text))
            {
                XtraMessageBox.Show("反演模型为空！");
            }
            else if (string.IsNullOrEmpty(txtOutBiology.Text))
            {
                XtraMessageBox.Show("草地生物量为空！");
            }
            else if (string.IsNullOrEmpty(txtOutCarbonDensity.Text))
            {
                XtraMessageBox.Show("草地碳密度为空！");
            }
            else if (string.IsNullOrEmpty(txtOutCarbon.Text))
            {
                XtraMessageBox.Show("草地碳储量为空！");
            }
            else
            {
                VegetationCarbon fc = new VegetationCarbon(this.cmbLandCover.Text, int.Parse(this.cmbPixel.Text), _Index, this.txtExpression.Text.TrimEnd(), Convert.ToDouble(this.spinCarbonIndex.Value), this.txtOutBiology.Text, this.txtOutCarbonDensity.Text, this.txtOutCarbon.Text);
                string msg;

                frmWaitDialog frmWait = new frmWaitDialog("正在处理...", "提示信息");
                frmWait.Owner = this;
                frmWait.TopMost = false;

                frmWait.Caption = "计算生物量...";
                if (fc.Cal_Biomass())
                {
                    frmWait.Caption = "计算碳密度...";
                    if (fc.Cal_carbonDensity())
                    {
                        frmWait.Caption = "计算植被面积...";
                        if (fc.Cal_forestCoverBlock())
                        {
                            frmWait.Caption = "计算碳储量...";
                            if (fc.Cal_carbonStorageBlock())
                            {
                                //isDone = true;
                                frmWait.Caption = "计算完毕！";
                                try
                                {
                                    GFS.BLL.MapAPI.AddRasterFileToMap(txtOutBiology.Text);
                                    GFS.BLL.MapAPI.AddRasterFileToMap(txtOutCarbonDensity.Text);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("加载计算结果失败！/r/n" + ex.Message);
                                }
                                frmWait.Close();

                            }
                        }

                    }
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            string expression = this.txtExpression.Text;
            int curIndex = txtExpression.SelectionStart;
            expression = expression.Insert(curIndex, btn.Text);
            this.txtExpression.Text = expression;
            this.txtExpression.SelectionStart = curIndex + btn.Text.Length;

        }

        private void frmGrass_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }






    }
}