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

namespace GFS.Carbon
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
        }

        #endregion

        #region 业务模块事件
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
  
        }

        private void btnSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRecode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnVerify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCropMosaic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion

        #region basic GIS events

        #endregion

        #region fun

        #endregion




    }
}
