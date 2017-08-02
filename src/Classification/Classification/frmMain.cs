using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classification
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            this.axMapControl.Dock = DockStyle.Fill;
            this.axTOCControl.Dock = DockStyle.Fill;
        }


        private void btnAddData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNewTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.Start);
        }

        private void btnOpenTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.Start);
        }

        private void btnMask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.btnPrepare);
        }

        private void btnSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.btnSample);
        }

        private void btnRecode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.btnAfter);
        }

        private void btnVerify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.btnVerification);
        }

        private void btnCropMosaic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ucWorkFlow1.RefreshFlow(FlowStatus.End);
        }
    }
}
