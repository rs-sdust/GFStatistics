// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 08-17-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-17-2017
// ***********************************************************************
// <copyright file="frmMain.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>main UI of classification</summary>
// ***********************************************************************
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
using GFS.Commands.UI;
using ESRI.ArcGIS.Geometry;

namespace GFS.Classification
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
            if (Internet.IsConnectInternet())
                BaseMap.Add(BaseMapLayer.ChinaPoi);
        }

        #endregion

        #region business events

        private void barBtnPOI_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaseMap.Add(BaseMapLayer.ChinaPoi);
        }

        private void barBtnImagery_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaseMap.Add(BaseMapLayer.Imagery);
        }
        //
        //更新任务
        //
        private void btnUpdateTask_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTask(EnviVars.instance.CurrentTask);

        }
        //
        //裁剪
        //
        private void btnMask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask,BLL.TaskState.DataPrepare);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnPrepare);
            //frmClipRaster frm = new frmClipRaster();
            //frm.ShowDialog();
            CmdClipRaster clip = new CmdClipRaster();
            clip.OnClick();
        }
        //
        //镶嵌
        //
        private void btnMosaic_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.DataPrepare);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnPrepare);
            frmMosaic frm = new frmMosaic();
            frm.ShowDialog();
        }
        private void btnDVI_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDVI frm = new frmDVI();
            frm.ShowDialog();
        }
        private void btnRVI_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRVI frm = new frmRVI();
            frm.ShowDialog();
        }

        private void btnEVI_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEVI frm = new frmEVI();
            frm.ShowDialog();
        }

        private void btnNDVI_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNDVI frm = new frmNDVI();
            frm.ShowDialog();
        }

        private void btnSAVI_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSAVI frm = new frmSAVI();
            frm.ShowDialog();
        }
        //
        //样本选取
        //
        private void btnSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnSample);
            CmdROI roiTool = new CmdROI();
            roiTool.OnCreate(this.m_mapControl);
            roiTool.OnClick();
        }
        //
        //样本分析
        //
        private void btnSampleAnaly_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnSample);
            frmSampleAnaly frm = new frmSampleAnaly();
            frm.ShowDialog();
        }
        //
        //神经网络硬分类
        //
        private void btnNNHard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);

        }
        private void btnWideInWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            frmNeuralNet frm = new frmNeuralNet();
            frm.Owner = this;
            frm.ShowDialog();
        }
        //
        //图像分割
        //
        private void btnfeatureAnaly_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            frmSegmentation frm = new frmSegmentation();
            frm.ShowDialog();
        }
        //
        //面向对象分类
        //
        private void btnSoftHard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            //frmOOClassification frm = new frmOOClassification();
            frmOOMaximumLike frm = new frmOOMaximumLike();
            frm.ShowDialog();
        }
        //
        //长时间序列
        //
        private void btnOverlayClass_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            string treeFile = System.IO.Path.Combine(BLL.ConstDef.STARTPATH, "gf4.tree");
            frmDecisionTree frm = new frmDecisionTree(treeFile);
            frm.Owner = this;
            frm.Show();
        }
        //
        //决策树分类
        //
        private void btnDecision_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            frmDecisionTree frm = new frmDecisionTree();
            frm.Owner = this;
            frm.Show();
        }
        //
        //光学影像分割
        //
        private void btnOpticsDiv_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
        }
        //
        //图斑像元综合分类
        //
        private void btnSyn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            frmGF3Classification frm = new frmGF3Classification();
            frm.ShowDialog();
        }
        //
        //重编码
        //
        private void btnRecode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnAfter);
            frmRecode frm = new frmRecode();
            frm.ShowDialog();
        }
        //
        //分类后校正
        //
        private void btnReject_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnAfter);
            frmReCorect frm = new frmReCorect();
            frm.Owner = this;
            frm.Show();
        }
        //
        //结果统计
        //
        private void btnStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnAfter);
            frmStatisticsResult frm = new frmStatisticsResult();
            frm.ShowDialog();
        }


        //
        //精度验证
        //
        private void btnVerify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.btnVerification);
            frmAccuracyVerify frm = new frmAccuracyVerify();
            frm.ShowDialog();
        }
        //
        //结果拼接
        //
        private void btnCropMosaic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task.UpdateTaskState(EnviVars.instance.CurrentTask, BLL.TaskState.Production);
            this.ucWorkFlow.RefreshFlow(FlowStatus.End);
            frmMosaic frm = new frmMosaic();
            frm.ShowDialog();
        }
        private void btnSpatialError_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSpatialError frm = new frmSpatialError();
            frm.Owner = this;
            frm.ShowDialog();
        }
        #endregion

        private void btnGF3Radar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnHyper_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHyperSpeClassification frm = new frmHyperSpeClassification();
            frm.Owner = this;
            frm.ShowDialog();
        }















    }
}
