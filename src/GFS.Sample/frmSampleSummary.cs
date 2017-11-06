using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.BLL;
using GFS.SampleBLL;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System.IO;
using GFS.Common;

namespace GFS.Sample
{
    public partial class frmSampleSummary : Form
    {
        private OpenFileDialog openDlg = new OpenFileDialog();
        private SaveFileDialog saveDlg = new SaveFileDialog();
        private string _sampleFile;
        private string _surveyFile;
        private IFeatureLayer _pSampleLayer = null;
        private IFeatureLayer _pSurveyLayer = null;
        private IMapControl3 _pMapControl = null;
        private ITOCControl2 _pTOCControl = null;

        public frmSampleSummary()
        {
            InitializeComponent();
            _pMapControl = EnviVars.instance.MapControl;
            _pTOCControl = EnviVars.instance.TOCControl;
        }

        private void frmSampleSummary_Load(object sender, EventArgs e)
        {
            MapAPI.GetAllLayers(null,cmbSecondUnit);
            MapAPI.GetAllLayers(null, cmbFieldSample);
        }

        private void btnSecondUnit_Click(object sender, EventArgs e)
        {
            openDlg.Title = "请选择文件";
            openDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                if (cmbSecondUnit.Text == openDlg.FileName)
                    return;

                if (_pSampleLayer != null)
                    _pMapControl.Map.DeleteLayer(_pSampleLayer);
                cmbSecondUnit.Text = openDlg.FileName;
            }
        }
        private void cmbSecondUnit_TextChanged(object sender, EventArgs e)
        {
            _sampleFile = cmbSecondUnit.Text;
            _pSampleLayer = null;
            for (int i = 0; i < _pMapControl.LayerCount; i++)
            {
                ILayer pLayer = _pMapControl.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    IFeatureClass pFClass = (pLayer as IFeatureLayer).FeatureClass;
                    string dtSource = Path.Combine((pFClass as IDataset).Workspace.PathName, (pFClass as IDataset).Name + ".shp");
                    if (dtSource == _sampleFile)
                        _pSampleLayer = pLayer as IFeatureLayer;
                }
            }
            if (_pSampleLayer == null)
            {
                IFeatureClass pFClass = EngineAPI.OpenFeatureClass(_sampleFile);
                _pSampleLayer = new FeatureLayerClass();
                _pSampleLayer.FeatureClass = pFClass;
                _pSampleLayer.Name = (pFClass as IDataset).Name;

                _pMapControl.AddLayer(_pSampleLayer);
            }
        }
        private void btnFieldSample_Click(object sender, EventArgs e)
        {
            openDlg.Title = "请选择文件";
            openDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                if (cmbFieldSample.Text == openDlg.FileName)
                    return;

                if (_pSurveyLayer != null)
                {
                    _pMapControl.Map.DeleteLayer(_pSurveyLayer);
                }
                cmbFieldSample.Text = openDlg.FileName;

            }
        }
        private void cmbFieldSample_TextChanged(object sender, EventArgs e)
        {
            _surveyFile = cmbFieldSample.Text;
            _pSurveyLayer = null;
            for (int i = 0; i < _pMapControl.LayerCount; i++)
            {
                ILayer pLayer = _pMapControl.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    IFeatureClass pFClass = (pLayer as IFeatureLayer).FeatureClass;
                    string dtSource = Path.Combine((pFClass as IDataset).Workspace.PathName, (pFClass as IDataset).Name + ".shp");
                    if (dtSource == _surveyFile)
                        _pSurveyLayer = pLayer as IFeatureLayer;
                }
            }
            if (_pSurveyLayer == null)
            {
                IFeatureClass pFClass = EngineAPI.OpenFeatureClass(_surveyFile);
                _pSurveyLayer = new FeatureLayerClass();
                _pSurveyLayer.FeatureClass = pFClass;
                _pSurveyLayer.Name = (pFClass as IDataset).Name;

                _pMapControl.AddLayer(_pSurveyLayer);
            }
            BindFields(_pSurveyLayer);
        }
        private void BindFields(IFeatureLayer layer)
        {
            this.cmbFieldVillage.Properties.Items.Clear();
            this.cmbFieldID.Properties.Items.Clear();
            this.cmbFieldArea.Properties.Items.Clear();
            this.cmbFieldCropType.Properties.Items.Clear();
            List<string> fieldsList = new List<string>();
            Common.EngineAPI.GetFields(_pSurveyLayer.FeatureClass, 2, fieldsList);
            this.cmbFieldVillage.Properties.Items.AddRange(fieldsList);
            this.cmbFieldID.Properties.Items.AddRange(fieldsList);
            this.cmbFieldArea.Properties.Items.AddRange(fieldsList);
            this.cmbFieldCropType.Properties.Items.AddRange(fieldsList);
        }

        private void cmbFieldCropType_TextChanged(object sender, EventArgs e)
        {
            cmbCropName.Properties.Items.Clear();
            cmbCropName.Properties.Items.AddRange(MapAPI.GetLayerUniqueFieldValue(_pSurveyLayer, cmbFieldCropType.Text));
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            saveDlg.Title = "保存文件";
            saveDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = saveDlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在汇总...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                SampleSummary summary = new SampleSummary(_pSampleLayer, _pSurveyLayer, cmbFieldVillage.Text, cmbFieldID.Text,cmbFieldCropType.Text,cmbCropName.Text, cmbFieldArea.Text, txtOut.Text);
                string msg = "";
                if (!summary.Summary(out msg))
                {
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (DialogResult.OK == XtraMessageBox.Show("汇总完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        MapAPI.AddShpFileToMap(txtOut.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                frmWait.Close();
                XtraMessageBox.Show("汇总完成！");
                _pMapControl.Refresh();
                _pTOCControl.Update();
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






    }
}
