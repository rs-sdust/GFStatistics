using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GFS.Classification
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region  fields
        #endregion

        #region Constructor
        public frmMain()
        {
            InitializeComponent();
            //绑定图层和工具条到map控件
            this.axToolbarControl.SetBuddyControl(this.axMapControl);
            this.axTOCControl.SetBuddyControl(this.axMapControl);
            //控件填充
            this.axMapControl.Dock = DockStyle.Fill;
            this.axTOCControl.Dock = DockStyle.Fill;
            this.ucWorkFlow.Dock = DockStyle.Fill;
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

        private void panelMap_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region basic GIS events
        #endregion




    }
}
