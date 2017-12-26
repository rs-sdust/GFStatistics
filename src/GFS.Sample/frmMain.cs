using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.BLL;
using GFS.Commands;
using ESRI.ArcGIS.Controls;
using DevExpress.XtraBars;
using ESRI.ArcGIS.SystemUI;
using GFS.SampleBLL;
using DevExpress.XtraEditors;

namespace GFS.Sample
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region  fields
        private ITOCControl2 m_tocControl = null;
        private IMapControl3 m_mapControl = null;
        private IToolbarControl2 m_toolBarControl = null;
        #endregion

        #region Constructor
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //绑定图层和工具条到map控件
            this.axToolbarControl.SetBuddyControl(this.axMapControl);
            this.axTOCControl.SetBuddyControl(this.axMapControl);
            //控件填充
            this.axMapControl.Dock = DockStyle.Fill;
            this.axMapControlEagle.Dock = DockStyle.Fill;
            this.axTOCControl.Dock = DockStyle.Fill;
            this.ucWorkFlow.Dock = DockStyle.Fill;
            //获取地图控件引用
            m_tocControl = (ITOCControl2)axTOCControl.Object;
            m_mapControl = (IMapControl3)axMapControl.Object;
            m_toolBarControl = (IToolbarControl2)axToolbarControl.Object;

            CMDInitializer.Initialize(m_toolBarControl);
            //工具条列表
            List<Bar> barList = new List<Bar>();
            barList.Add(this.barTop);
            GFSApplication app = new GFSApplication(m_mapControl, (IMapControl3)axMapControlEagle.Object, m_tocControl, m_toolBarControl, this);
            app.Initialize(barList, appMenu, popupMenuFrame, popupMenulayer, popupMenuRGB,
                barEditItemLayer, staticSpt, staticXY, staticRaster, barBtnSwipe,barBtnEagleEye,
                dpEagle,listRecently,controlContainer1);
            //BaseMap.Add(BaseMapLayer.ChinaPoi);
            if (Internet.IsConnectInternet())
                BaseMap.Add(BaseMapLayer.ChinaPoi);

            //axMapControl.LoadMxFile(@"G:\高分统计项目一期\遥感所模块\SampleTestForm\测试数据\DataMap0.mxd");
            //遥感所IDL模块初始化
            GFS.Integration.Initialize.InitializeIDL();
            GFS.Integration.Initialize.RegisterCMD(btnMaxClass, m_mapControl, m_tocControl, "MaxClassCommand");
            GFS.Integration.Initialize.RegisterCMD(btnCV, m_mapControl, m_tocControl, "CV1Commad");
        }

        #endregion

        #region 业务模块事件

        private void barBtnPOI_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaseMap.Add(BaseMapLayer.ChinaPoi);
        }

        private void barBtnImagery_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaseMap.Add(BaseMapLayer.Imagery);
        }

        private void btnAddData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNewTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnOpenTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnMask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnFrame);
            frmSampleFrame frm = new frmSampleFrame();
            frm.ShowDialog();
        }
        private void btnAutoLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnFrame);
            frmAutoLayer frm = new frmAutoLayer();
            frm.ShowDialog();
        }
        private void btnSampleLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnFrame);
            frmSampleLayer frm = new frmSampleLayer();
            frm.ShowDialog();
        }
        private void btnMosaic_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ucWorkFlow.RefreshFlow(FlowStatus.btnErrorAnalyze);
            //frmErrorAnalysis frm = new frmErrorAnalysis();
            //frm.ShowDialog();
            frmSpatialError frm = new frmSpatialError();
            frm.ShowDialog(); 
            
        }
        private void btnSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnSample);
            frmSamplingSelect frm = new frmSamplingSelect();
            frm.ShowDialog();
        }


        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderBrowserDialog Dlg = new FolderBrowserDialog();
            if(DialogResult.OK == Dlg.ShowDialog())
            {
                string toFolder = Dlg.SelectedPath;
                XtraMessageBox.Show(ExportData.Export(toFolder));
            }
        }

        private void btnEstimate_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnEstimate);
            frmAllEstimation frm = new frmAllEstimation();
            frm.ShowDialog();
        }

        private void btnSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnReview);
            frmSampleReview frm = new frmSampleReview();
            frm.Owner = this;
            frm.Show();
        }

        private void btnRecode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnSimulation);
            frmSampleSimulation frm = new frmSampleSimulation();
            frm.Owner = this;
            frm.Show();
        }

        private void btnSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSampleSummary frm = new frmSampleSummary();
            frm.Owner = this;
            frm.Show();
        }

        private void btnVerify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCropMosaic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion

        private void btnIniRADI_ItemClick(object sender, ItemClickEventArgs e)
        {
            //遥感所模块GIS命令注册
            //GFS.Integration.Initialize.RegisterCMD(btnTest,m_mapControl, m_tocControl);
        }














        #region basic GIS events

        #endregion

        #region fun

        #endregion




    }
}
