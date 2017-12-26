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
using GFS.SampleBLL;
using DevExpress.Utils;
using System.IO;


namespace GFS.Sample
{
    public partial class frmSamplingSelect : DevExpress.XtraEditors.XtraForm
    {
        public frmSamplingSelect()
        {
            InitializeComponent();
        }
        private void frmSamplingSelect_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;

            MapAPI.GetAllLayers(null, cmbSecondUint);
            MapAPI.GetAllLayers(null, cmbFirstUnit);
            MapAPI.GetAllLayers(cmbASCDL, cmbCultivation);

            this.chkSecondUint.Checked = false;
            this.chkNewNet.Checked = true;
            this.chkSampleNum.Checked =true;
            cmbSecondUint.Enabled = btnSecondUint.Enabled = chkSecondUint.Checked;
            spinLength.Enabled = spinWidth.Enabled = cmbFirstUnit.Enabled = btnFirstUnit.Enabled = 
                cmbVillage.Enabled = cmbLayer.Enabled= cmbCultivation.Enabled = 
                cmbASCDL.Enabled = cmbCrop.Enabled = chkNewNet.Checked;
            spinSampleNum.Enabled = chkSampleNum.Checked;
            spinPercent.Enabled = chkPercent.Checked;

            InitialData();

        }

        private void InitialData()
        {
            cmbFirstUnit.Text = SampleData.firstSample;
            if (!string.IsNullOrEmpty(cmbFirstUnit.Text))
            {
                getFields();
                cmbVillage.Text = SampleData.villageField;
                cmbLayer.Text = SampleData.layerField;
            }

            cmbCultivation.Text = SampleData.farmLand;
            cmbASCDL.Text = SampleData.ASCDL;
            if (!string.IsNullOrEmpty(cmbASCDL.Text))
            {
                cmbCrop.Properties.Items.Clear();
                if (SampleData.classNames.Count > 0)
                {
                    cmbCrop.Properties.Items.AddRange(SampleData.classNames);
                }
                else
                {
                    try
                    {
                        string filePath = cmbASCDL.Text.TrimEnd();
                        FileInfo file = new FileInfo(filePath);
                        string fileHdr = filePath.Replace(file.Extension, ".hdr");
                        if (File.Exists(fileHdr))
                        {
                            SampleData.classNames = SampleFrame.GetClassFromHdr(fileHdr);
                            this.cmbCrop.Properties.Items.AddRange(SampleData.classNames);
                        }
                        else
                        {
                            SampleData.classNames = SampleFrame.GetClassFromRaster(filePath);
                            this.cmbCrop.Properties.Items.AddRange(SampleData.classNames);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.WriteLog(typeof(frmSampleFrame), ex);
                    }
                }

                if (SampleData.targetCrop >= 0)
                {
                    cmbCrop.Text = SampleData.classNames[SampleData.targetCrop];
                }
            }
        }

        private void chkSecondUint_CheckedChanged(object sender, EventArgs e)
        {
            chkNewNet.Checked = !chkSecondUint.Checked;
            cmbSecondUint.Enabled = btnSecondUint.Enabled = chkSecondUint.Checked;

            spinLength.Enabled = spinWidth.Enabled = chkNewNet.Checked;
            //cmbFirstUnit.Enabled = chkNewNet.Checked;
            //spinLength.Enabled = spinWidth.Enabled = cmbFirstUnit.Enabled = btnFirstUnit.Enabled =
            //    cmbVillage.Enabled = cmbLayer.Enabled = cmbCultivation.Enabled =
            //    cmbASCDL.Enabled = cmbCrop.Enabled = chkNewNet.Checked;
        }

        private void chkNewNet_CheckedChanged(object sender, EventArgs e)
        {
            chkSecondUint.Checked = !chkNewNet.Checked;
            cmbSecondUint.Enabled = btnSecondUint.Enabled = chkSecondUint.Checked;

            spinLength.Enabled = spinWidth.Enabled = chkNewNet.Checked;
            //cmbFirstUnit.Enabled = chkNewNet.Checked;
            //spinLength.Enabled = spinWidth.Enabled = cmbFirstUnit.Enabled = btnFirstUnit.Enabled =
            //    cmbVillage.Enabled = cmbLayer.Enabled = cmbCultivation.Enabled =
            //    cmbASCDL.Enabled = cmbCrop.Enabled = chkNewNet.Checked;
        }

        private void chkSampleNum_CheckedChanged(object sender, EventArgs e)
        {
            chkPercent.Checked = !chkSampleNum.Checked;
            spinSampleNum.Enabled = chkSampleNum.Checked;
            spinPercent.Enabled = chkPercent.Checked;
        }

        private void chkPercent_CheckedChanged(object sender, EventArgs e)
        {
            chkSampleNum.Checked = !chkPercent.Checked;
            spinSampleNum.Enabled = chkSampleNum.Checked;
            spinPercent.Enabled = chkPercent.Checked;
        }

        private void btnSecondUint_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.cmbSecondUint.Text = fileDialog.FileName;
            }
        }
        private void btnFirstUnit_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.cmbFirstUnit.Text = fileDialog.FileName;
                getFields();
            }
        }
        private void btnCultivation_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.cmbCultivation.Text = fileDialog.FileName;
            }
        }
        private void btnASCDL_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.cmbASCDL.Text = openDlg.FileName;
            }
        }
        private void cmbASCDL_TextChanged(object sender, EventArgs e)
        {
            string filePath = cmbASCDL.Text.TrimEnd();
            if (string.IsNullOrEmpty(filePath))
                return;
            FileInfo file = new FileInfo(filePath);
            string fileHdr = filePath.Replace(file.Extension, ".hdr");
            try
            {
                if (File.Exists(fileHdr))
                {
                    SampleData.classNames = SampleFrame.GetClassFromHdr(fileHdr);
                    this.cmbCrop.Properties.Items.Clear();
                    this.cmbCrop.Properties.Items.AddRange(SampleData.classNames);
                }
                else
                {
                    SampleData.classNames = SampleFrame.GetClassFromRaster(filePath);
                    this.cmbCrop.Properties.Items.Clear();
                    this.cmbCrop.Properties.Items.AddRange(SampleData.classNames);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WriteLog(typeof(frmSampleFrame), ex);
            }
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog .Title = "保存文件";
            dialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = dialog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            frmWaitDialog frmWait = new frmWaitDialog("正在执行...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                string fishNet = string.Empty;
                string firstUnit = this.cmbFirstUnit.Text;
                if (chkNewNet.Checked)
                {
                    SampleData.firstSample = cmbFirstUnit.Text;
                    SampleData.villageField = cmbVillage.Text;
                    SampleData.layerField = cmbLayer.Text;
                    SampleData.farmLand = cmbCultivation.Text;
                    SampleData.ASCDL = cmbASCDL.Text;
                    SampleData.targetCrop = cmbCrop.SelectedIndex;

                    if (!SampleSelection.ChkData(out msg))
                    {
                        XtraMessageBox.Show(msg);
                        return;
                    }
                    //一级单元范围内创建渔网
                    frmWait.Caption = "创建二级抽样单元...";
                    fishNet = System.IO.Path.Combine(ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                    int width = int.Parse(spinLength.EditValue.ToString());
                    int height = int.Parse(this.spinWidth.EditValue.ToString());
                    if (!EnviVars.instance.GpExecutor.CreateFishNet(firstUnit, width, height, fishNet, out msg))
                    {
                        XtraMessageBox.Show(msg);
                        return;
                    }
                }
                else
                {
                    SampleData.firstSample = cmbFirstUnit.Text;
                    SampleData.villageField = cmbVillage.Text;
                    SampleData.layerField = cmbLayer.Text;
                    SampleData.farmLand = cmbCultivation.Text;
                    SampleData.ASCDL = cmbASCDL.Text;
                    SampleData.targetCrop = cmbCrop.SelectedIndex;

                    if (!SampleSelection.ChkData(out msg))
                    {
                        XtraMessageBox.Show(msg);
                        return;
                    }

                    if (string.IsNullOrEmpty(cmbSecondUint.Text))
                    {
                        XtraMessageBox.Show("二级抽样单元为空！");
                        return;
                    }
                    fishNet = cmbSecondUint.Text;

                }

                //抽选样本
                frmWait.Caption = "抽选样本...";
                SamplePara para = new SamplePara();
                para.isNum = chkSampleNum.Checked;
                para.sampleNum = int.Parse(this.spinSampleNum.EditValue.ToString());
                para.sampleRate = double.Parse(this.spinPercent.EditValue.ToString())/100;
                SampleSelection.Sampling(firstUnit, cmbVillage.Text, cmbLayer.Text, fishNet, cmbCultivation.Text, para, txtOut.Text);

                SampleFrame sampleFrame = new SampleFrame();
                frmWait.Caption = "计算耕地面积...";
                if (!SampleSelection.CalLandArea(txtOut.Text, SampleData.farmLand, out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                frmWait.Caption = "计算分类面积...";
                if (!sampleFrame.CalClassArea(txtOut.Text, SampleData.ASCDL, SampleData.targetCrop, out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                BLL.ProductMeta meta = new ProductMeta(txtOut.Text.TrimEnd(), "", "", "二级样方", "抽样和面积推算结果");
                meta.WriteShpMeta();
                BLL.ProductQuickView view = new BLL.ProductQuickView(txtOut.Text.TrimEnd());
                view.Create();

                System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("抽样完成,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    MapAPI.AddShpFileToMap(txtOut.Text);
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Log.WriteLog(typeof(frmSymbolSelector),ex);
            }
            finally
            {

                frmWait.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
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



        private void getFields()
        {
            this.cmbVillage.Properties.Items.Clear();
            this.cmbLayer.Properties.Items.Clear();
            List<string> fieldsList = new List<string>();
            EnviVars.instance.GpExecutor.GetFields(cmbFirstUnit.Text, fieldsList);
            this.cmbVillage.Properties.Items.AddRange(fieldsList);
            this.cmbLayer.Properties.Items.AddRange(fieldsList);
        }

        private void frmSamplingSelect_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }






    }
}