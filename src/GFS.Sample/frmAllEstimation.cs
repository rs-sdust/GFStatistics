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
using System.IO;
using DevExpress.XtraExport;
using GFS.SampleBLL;

namespace GFS.Sample
{
    public partial class frmAllEstimation : DevExpress.XtraEditors.XtraForm
    {
        public frmAllEstimation()
        {
            InitializeComponent();
        }
        private void frmAllEstimation_Load(object sender, EventArgs e)
        {
            this.cBEMethod.SelectedIndex = 0;
            MapAPI.GetAllLayers(null, cBSamplePopu);
            MapAPI.GetAllLayers(null, cBESample);
        }
        //入样总体数据输入
        private void siBSamplePopu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                cBSamplePopu.Text = filepath;//获取文件路径
               
            }
        }
        private void cBSamplePopu_TextChanged(object sender, EventArgs e)
        {
            ExportData.firstUnit = cBSamplePopu.Text;
            SampleSimulation.BindFields(cBSamplePopu.Text, cBEPopuBasis);
            SampleSimulation.BindFields(cBSamplePopu.Text, cBEPopuLayer);
        }
        //样本数据输入
        private void siBSample_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                cBESample.Text = filepath;//获取文件路径

            }
        }
        private void cBESample_TextChanged(object sender, EventArgs e)
        {
            ExportData.secSample = cBESample.Text;
            SampleSimulation.BindFields(cBESample.Text, cBESamBasis);
            SampleSimulation.BindFields(cBESample.Text, cBESamLayer);
            SampleSimulation.BindFields(cBESample.Text, cBESamSurvey);
            SampleSimulation.BindFields(cBESample.Text, cBESamCunName);  
        }
        //保存文件
        private void siBsave_Click(object sender, EventArgs e)
        {
            //设置保存文件对话框
            SaveFileDialog save = new SaveFileDialog();
            //save.Filter = "XLSX (*.XLSX)|*.xlsx|XLS (*.XLS)|*.xls|All Files (*.*)|*.*||";
            save.Filter = "TXT (*.TXT)|*.txt|All Files (*.*)|*.*||";
            save.RestoreDirectory = true;
            save.FilterIndex = 1;
            if (save.ShowDialog() == DialogResult.OK)
            {
                string savepath = save.FileName.ToString();
                cBExport.Text = savepath;//文件保存路径
            }
        }
        // OK
        private void siB_Ok_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在生成...", "提示信息");
            try 
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                SampleAduit Aduit=new SampleAduit ();
                if(cBEMethod.Text =="分层比率估计")
                {
                    if (Aduit.RatioPreprocessing(cBSamplePopu.Text, cBESample.Text, cBESamSurvey.Text, cBEPopuLayer.Text, cBESamLayer.Text, cBEPopuBasis.Text, cBESamCunName.Text, cBExport.Text, cBESamBasis.Text))
                    {
                        MessageBox.Show("估算成功！");
                        ExportData.report = cBExport.Text;
                    } 
                }
                else 
                {
                    if (Aduit.ProbabilityProcessing(cBSamplePopu.Text, cBESample.Text,cBEPopuBasis.Text,cBEPopuLayer.Text, cBESamLayer.Text,cBESamBasis.Text,cBESamSurvey.Text, cBESamCunName.Text,cBExport.Text))
                    {
                        MessageBox.Show("估算成功！");
                        ExportData.report = cBExport.Text;
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(frmSampleSimulation), ex);
            }
            finally
            {
                frmWait.Close();
                this.Close();
            }
        }
        //取消
        private void siBcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //帮助
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

        private void cBEMethod_EditValueChanged(object sender, EventArgs e)
        {

            if (cBEMethod.Text == "分层比率估计")
            {
                labelCBasis.Text = "总体分类结果";
                lCSample.Text = "样本分类结果";
            }
            else
            {
                labelCBasis.Text = "总体耕地";
                lCSample.Text = "村代码";
            }
        }






    }
}