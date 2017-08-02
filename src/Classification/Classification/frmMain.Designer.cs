namespace Classification
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAddData = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnMask = new DevExpress.XtraBars.BarButtonItem();
            this.btnMosaic = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSingleDate = new DevExpress.XtraBars.BarSubItem();
            this.bsiMultiDate = new DevExpress.XtraBars.BarSubItem();
            this.bsiRadarAndMultiSpectral = new DevExpress.XtraBars.BarSubItem();
            this.bsiMiddleAndHigh = new DevExpress.XtraBars.BarSubItem();
            this.btnSample = new DevExpress.XtraBars.BarButtonItem();
            this.btnSampleAnaly = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecode = new DevExpress.XtraBars.BarButtonItem();
            this.btnReject = new DevExpress.XtraBars.BarButtonItem();
            this.btnStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerify = new DevExpress.XtraBars.BarButtonItem();
            this.btnCropMosaic = new DevExpress.XtraBars.BarButtonItem();
            this.bsiAfter = new DevExpress.XtraBars.BarSubItem();
            this.btnNNHard = new DevExpress.XtraBars.BarButtonItem();
            this.btnSoftHard = new DevExpress.XtraBars.BarButtonItem();
            this.btnOverlayClass = new DevExpress.XtraBars.BarButtonItem();
            this.btnDecision = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpticsDiv = new DevExpress.XtraBars.BarButtonItem();
            this.btnSyn = new DevExpress.XtraBars.BarButtonItem();
            this.ribbion32 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTask = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSample = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSingle = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupMulti = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAfter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupVerify = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupCropMosaic = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpFlow = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucWorkFlow1 = new Classification.UCWorkFlow();
            this.dpLayers = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barbtnAddData = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFull = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnZomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnZomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFixZomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFixZomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnNextView = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnIdentity = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEagleEye = new DevExpress.XtraBars.BarButtonItem();
            this.barBMultiWin = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSample = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAfter = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnShutter = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.image16 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelMap = new DevExpress.XtraEditors.PanelControl();
            this.axToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbion32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dpFlow.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dpLayers.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMap)).BeginInit();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnAddData,
            this.btnNewTask,
            this.btnOpenTask,
            this.btnSaveTask,
            this.btnUpdateTask,
            this.btnMask,
            this.btnMosaic,
            this.bsiSingleDate,
            this.bsiMultiDate,
            this.bsiRadarAndMultiSpectral,
            this.bsiMiddleAndHigh,
            this.btnSample,
            this.btnSampleAnaly,
            this.btnRecode,
            this.btnReject,
            this.btnStatistics,
            this.btnVerify,
            this.btnCropMosaic,
            this.bsiAfter,
            this.btnNNHard,
            this.btnSoftHard,
            this.btnOverlayClass,
            this.btnDecision,
            this.btnOpticsDiv,
            this.btnSyn});
            this.ribbonControl.LargeImages = this.ribbion32;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 17;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1014, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnAddData
            // 
            this.btnAddData.Caption = "加载数据";
            this.btnAddData.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddData.Id = 1;
            this.btnAddData.LargeImageIndex = 0;
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddData_ItemClick);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Caption = "新建任务";
            this.btnNewTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNewTask.Id = 9;
            this.btnNewTask.LargeImageIndex = 1;
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewTask_ItemClick);
            // 
            // btnOpenTask
            // 
            this.btnOpenTask.Caption = "打开任务";
            this.btnOpenTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenTask.Id = 10;
            this.btnOpenTask.LargeImageIndex = 2;
            this.btnOpenTask.Name = "btnOpenTask";
            this.btnOpenTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenTask_ItemClick);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Caption = "保存任务";
            this.btnSaveTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSaveTask.Id = 11;
            this.btnSaveTask.LargeImageIndex = 3;
            this.btnSaveTask.Name = "btnSaveTask";
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Caption = "更新任务";
            this.btnUpdateTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnUpdateTask.Id = 12;
            this.btnUpdateTask.LargeImageIndex = 4;
            this.btnUpdateTask.Name = "btnUpdateTask";
            // 
            // btnMask
            // 
            this.btnMask.Caption = "图像裁剪";
            this.btnMask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMask.Id = 13;
            this.btnMask.LargeImageIndex = 5;
            this.btnMask.Name = "btnMask";
            this.btnMask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMask_ItemClick);
            // 
            // btnMosaic
            // 
            this.btnMosaic.Caption = "图像拼接";
            this.btnMosaic.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMosaic.Id = 14;
            this.btnMosaic.LargeImageIndex = 8;
            this.btnMosaic.Name = "btnMosaic";
            // 
            // bsiSingleDate
            // 
            this.bsiSingleDate.Caption = "单期影像分类";
            this.bsiSingleDate.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiSingleDate.Id = 15;
            this.bsiSingleDate.LargeImageIndex = 12;
            this.bsiSingleDate.Name = "bsiSingleDate";
            // 
            // bsiMultiDate
            // 
            this.bsiMultiDate.Caption = "多期影像分类";
            this.bsiMultiDate.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiMultiDate.Id = 16;
            this.bsiMultiDate.LargeImageIndex = 7;
            this.bsiMultiDate.Name = "bsiMultiDate";
            // 
            // bsiRadarAndMultiSpectral
            // 
            this.bsiRadarAndMultiSpectral.Caption = "雷达+多光谱";
            this.bsiRadarAndMultiSpectral.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiRadarAndMultiSpectral.Id = 17;
            this.bsiRadarAndMultiSpectral.LargeImageIndex = 10;
            this.bsiRadarAndMultiSpectral.Name = "bsiRadarAndMultiSpectral";
            // 
            // bsiMiddleAndHigh
            // 
            this.bsiMiddleAndHigh.Caption = "中分+高分";
            this.bsiMiddleAndHigh.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiMiddleAndHigh.Id = 18;
            this.bsiMiddleAndHigh.LargeImageIndex = 6;
            this.bsiMiddleAndHigh.Name = "bsiMiddleAndHigh";
            // 
            // btnSample
            // 
            this.btnSample.Caption = "样本选取";
            this.btnSample.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSample.Id = 19;
            this.btnSample.LargeImageIndex = 9;
            this.btnSample.Name = "btnSample";
            this.btnSample.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSample_ItemClick);
            // 
            // btnSampleAnaly
            // 
            this.btnSampleAnaly.Caption = "样本分析";
            this.btnSampleAnaly.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSampleAnaly.Id = 20;
            this.btnSampleAnaly.LargeImageIndex = 11;
            this.btnSampleAnaly.Name = "btnSampleAnaly";
            // 
            // btnRecode
            // 
            this.btnRecode.Caption = "地类重编码";
            this.btnRecode.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnRecode.Id = 22;
            this.btnRecode.ImageIndex = 0;
            this.btnRecode.LargeImageIndex = 13;
            this.btnRecode.Name = "btnRecode";
            this.btnRecode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecode_ItemClick);
            // 
            // btnReject
            // 
            this.btnReject.Caption = "分类后校正";
            this.btnReject.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnReject.Id = 23;
            this.btnReject.ImageIndex = 1;
            this.btnReject.LargeImageIndex = 14;
            this.btnReject.Name = "btnReject";
            // 
            // btnStatistics
            // 
            this.btnStatistics.Caption = "结果统计";
            this.btnStatistics.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStatistics.Id = 24;
            this.btnStatistics.ImageIndex = 2;
            this.btnStatistics.LargeImageIndex = 15;
            this.btnStatistics.Name = "btnStatistics";
            // 
            // btnVerify
            // 
            this.btnVerify.Caption = "精度验证";
            this.btnVerify.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVerify.Id = 2;
            this.btnVerify.LargeImageIndex = 17;
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerify_ItemClick);
            // 
            // btnCropMosaic
            // 
            this.btnCropMosaic.Caption = "区域作物拼接";
            this.btnCropMosaic.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCropMosaic.Id = 10;
            this.btnCropMosaic.LargeImageIndex = 16;
            this.btnCropMosaic.Name = "btnCropMosaic";
            this.btnCropMosaic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCropMosaic_ItemClick);
            // 
            // bsiAfter
            // 
            this.bsiAfter.Caption = "分类后处理";
            this.bsiAfter.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiAfter.Id = 5;
            this.bsiAfter.LargeImageIndex = 18;
            this.bsiAfter.Name = "bsiAfter";
            // 
            // btnNNHard
            // 
            this.btnNNHard.Caption = "神经网络硬分类";
            this.btnNNHard.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNNHard.Id = 7;
            this.btnNNHard.Name = "btnNNHard";
            // 
            // btnSoftHard
            // 
            this.btnSoftHard.Caption = "软硬分类";
            this.btnSoftHard.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSoftHard.Id = 8;
            this.btnSoftHard.Name = "btnSoftHard";
            // 
            // btnOverlayClass
            // 
            this.btnOverlayClass.Caption = "叠加分类";
            this.btnOverlayClass.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOverlayClass.Id = 9;
            this.btnOverlayClass.Name = "btnOverlayClass";
            // 
            // btnDecision
            // 
            this.btnDecision.Caption = "决策树分类";
            this.btnDecision.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDecision.Id = 10;
            this.btnDecision.Name = "btnDecision";
            // 
            // btnOpticsDiv
            // 
            this.btnOpticsDiv.Caption = "光学影像分割";
            this.btnOpticsDiv.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpticsDiv.Id = 11;
            this.btnOpticsDiv.Name = "btnOpticsDiv";
            // 
            // btnSyn
            // 
            this.btnSyn.Caption = "图斑/像元综合分类";
            this.btnSyn.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSyn.Id = 12;
            this.btnSyn.Name = "btnSyn";
            // 
            // ribbion32
            // 
            this.ribbion32.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbion32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbion32.ImageStream")));
            this.ribbion32.Images.SetKeyName(0, "多层.png");
            this.ribbion32.Images.SetKeyName(1, "new.png");
            this.ribbion32.Images.SetKeyName(2, "open32.png");
            this.ribbion32.Images.SetKeyName(3, "save32.png");
            this.ribbion32.Images.SetKeyName(4, "update32.png");
            this.ribbion32.Images.SetKeyName(5, "裁剪.png");
            this.ribbion32.Images.SetKeyName(6, "多层.png");
            this.ribbion32.Images.SetKeyName(7, "多图.png");
            this.ribbion32.Images.SetKeyName(8, "合并.png");
            this.ribbion32.Images.SetKeyName(9, "绘制多边形.png");
            this.ribbion32.Images.SetKeyName(10, "雷达.png");
            this.ribbion32.Images.SetKeyName(11, "随机.png");
            this.ribbion32.Images.SetKeyName(12, "图片.png");
            this.ribbion32.Images.SetKeyName(13, "recode32.png");
            this.ribbion32.Images.SetKeyName(14, "reject32.png");
            this.ribbion32.Images.SetKeyName(15, "resstatistics32.png");
            this.ribbion32.Images.SetKeyName(16, "拼接照片.png");
            this.ribbion32.Images.SetKeyName(17, "任务.png");
            this.ribbion32.Images.SetKeyName(18, "编辑.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupFile,
            this.ribbonPageGroupTask,
            this.ribbonPageGroupData,
            this.ribbonPageGroupSample,
            this.ribbonPageGroupSingle,
            this.ribbonPageGroupMulti,
            this.ribbonPageGroupAfter,
            this.ribbonPageGroupVerify,
            this.ribbonPageGroupCropMosaic});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroupFile
            // 
            this.ribbonPageGroupFile.ItemLinks.Add(this.btnAddData);
            this.ribbonPageGroupFile.Name = "ribbonPageGroupFile";
            this.ribbonPageGroupFile.Text = "文件管理";
            // 
            // ribbonPageGroupTask
            // 
            this.ribbonPageGroupTask.ItemLinks.Add(this.btnNewTask);
            this.ribbonPageGroupTask.ItemLinks.Add(this.btnOpenTask);
            this.ribbonPageGroupTask.ItemLinks.Add(this.btnSaveTask);
            this.ribbonPageGroupTask.ItemLinks.Add(this.btnUpdateTask);
            this.ribbonPageGroupTask.Name = "ribbonPageGroupTask";
            this.ribbonPageGroupTask.Text = "任务管理";
            // 
            // ribbonPageGroupData
            // 
            this.ribbonPageGroupData.ItemLinks.Add(this.btnMask);
            this.ribbonPageGroupData.ItemLinks.Add(this.btnMosaic);
            this.ribbonPageGroupData.Name = "ribbonPageGroupData";
            this.ribbonPageGroupData.Text = "测量数据准备";
            // 
            // ribbonPageGroupSample
            // 
            this.ribbonPageGroupSample.ItemLinks.Add(this.btnSample);
            this.ribbonPageGroupSample.ItemLinks.Add(this.btnSampleAnaly);
            this.ribbonPageGroupSample.Name = "ribbonPageGroupSample";
            this.ribbonPageGroupSample.Text = "训练样本提取";
            // 
            // ribbonPageGroupSingle
            // 
            this.ribbonPageGroupSingle.ItemLinks.Add(this.bsiSingleDate);
            this.ribbonPageGroupSingle.ItemLinks.Add(this.bsiMultiDate);
            this.ribbonPageGroupSingle.Name = "ribbonPageGroupSingle";
            this.ribbonPageGroupSingle.Text = "单星影像分类";
            // 
            // ribbonPageGroupMulti
            // 
            this.ribbonPageGroupMulti.ItemLinks.Add(this.bsiMiddleAndHigh);
            this.ribbonPageGroupMulti.ItemLinks.Add(this.bsiRadarAndMultiSpectral);
            this.ribbonPageGroupMulti.Name = "ribbonPageGroupMulti";
            this.ribbonPageGroupMulti.Text = "多星影像分类";
            // 
            // ribbonPageGroupAfter
            // 
            this.ribbonPageGroupAfter.ItemLinks.Add(this.bsiAfter);
            this.ribbonPageGroupAfter.Name = "ribbonPageGroupAfter";
            // 
            // ribbonPageGroupVerify
            // 
            this.ribbonPageGroupVerify.ItemLinks.Add(this.btnVerify);
            this.ribbonPageGroupVerify.Name = "ribbonPageGroupVerify";
            // 
            // ribbonPageGroupCropMosaic
            // 
            this.ribbonPageGroupCropMosaic.ItemLinks.Add(this.btnCropMosaic);
            this.ribbonPageGroupCropMosaic.Name = "ribbonPageGroupCropMosaic";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1014, 31);
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpLayers});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar"});
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dpFlow);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 548);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(1014, 20);
            // 
            // dpFlow
            // 
            this.dpFlow.Controls.Add(this.dockPanel1_Container);
            this.dpFlow.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpFlow.DockVertical = DevExpress.Utils.DefaultBoolean.False;
            this.dpFlow.FloatSize = new System.Drawing.Size(900, 256);
            this.dpFlow.ID = new System.Guid("46559745-e4c9-4c9c-a7cd-714ebfb75c7a");
            this.dpFlow.Location = new System.Drawing.Point(0, 0);
            this.dpFlow.Name = "dpFlow";
            this.dpFlow.OriginalSize = new System.Drawing.Size(256, 256);
            this.dpFlow.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpFlow.SavedIndex = 1;
            this.dpFlow.Size = new System.Drawing.Size(890, 256);
            this.dpFlow.Text = "业务流程";
            this.dpFlow.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucWorkFlow1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(882, 229);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucWorkFlow1
            // 
            this.ucWorkFlow1.BackColor = System.Drawing.SystemColors.Window;
            this.ucWorkFlow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucWorkFlow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkFlow1.Location = new System.Drawing.Point(0, 0);
            this.ucWorkFlow1.Name = "ucWorkFlow1";
            this.ucWorkFlow1.Size = new System.Drawing.Size(882, 229);
            this.ucWorkFlow1.TabIndex = 0;
            // 
            // dpLayers
            // 
            this.dpLayers.Controls.Add(this.dockPanel2_Container);
            this.dpLayers.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpLayers.ID = new System.Guid("281db4bf-3929-4ed7-bbc3-6e69fc19f90d");
            this.dpLayers.Location = new System.Drawing.Point(0, 147);
            this.dpLayers.Name = "dpLayers";
            this.dpLayers.OriginalSize = new System.Drawing.Size(256, 200);
            this.dpLayers.Size = new System.Drawing.Size(256, 401);
            this.dpLayers.Text = "图层";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.axTOCControl);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(248, 374);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("MapTool", new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295"))});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Images = this.image16;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnAddData,
            this.barBtnFull,
            this.barBtnPan,
            this.barBtnZomIn,
            this.barBtnZomOut,
            this.barBtnFixZomIn,
            this.barBtnFixZomOut,
            this.barBtnPreview,
            this.barBtnNextView,
            this.barBtnIdentity,
            this.barBtnEagleEye,
            this.barBMultiWin,
            this.barBtnSample,
            this.barBtnAfter,
            this.barBtnShutter});
            this.barManager.MaxItemId = 15;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnAddData),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnFull),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPan),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnZomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnZomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnFixZomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnFixZomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnNextView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnIdentity),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEagleEye),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBMultiWin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSample),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAfter),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnShutter)});
            this.barTop.OptionsBar.AllowQuickCustomization = false;
            this.barTop.Text = "Tools";
            // 
            // barbtnAddData
            // 
            this.barbtnAddData.Caption = "加载数据";
            this.barbtnAddData.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barbtnAddData.Id = 0;
            this.barbtnAddData.ImageIndex = 0;
            this.barbtnAddData.Name = "barbtnAddData";
            // 
            // barBtnFull
            // 
            this.barBtnFull.Caption = "全图";
            this.barBtnFull.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnFull.Id = 1;
            this.barBtnFull.ImageIndex = 3;
            this.barBtnFull.Name = "barBtnFull";
            // 
            // barBtnPan
            // 
            this.barBtnPan.Caption = "拖动";
            this.barBtnPan.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnPan.Id = 2;
            this.barBtnPan.ImageIndex = 5;
            this.barBtnPan.Name = "barBtnPan";
            // 
            // barBtnZomIn
            // 
            this.barBtnZomIn.Caption = "放大";
            this.barBtnZomIn.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnZomIn.Id = 3;
            this.barBtnZomIn.ImageIndex = 7;
            this.barBtnZomIn.Name = "barBtnZomIn";
            // 
            // barBtnZomOut
            // 
            this.barBtnZomOut.Caption = "缩小";
            this.barBtnZomOut.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnZomOut.Id = 4;
            this.barBtnZomOut.ImageIndex = 8;
            this.barBtnZomOut.Name = "barBtnZomOut";
            // 
            // barBtnFixZomIn
            // 
            this.barBtnFixZomIn.Caption = "固定放大";
            this.barBtnFixZomIn.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnFixZomIn.Id = 5;
            this.barBtnFixZomIn.ImageIndex = 2;
            this.barBtnFixZomIn.Name = "barBtnFixZomIn";
            // 
            // barBtnFixZomOut
            // 
            this.barBtnFixZomOut.Caption = "固定缩小";
            this.barBtnFixZomOut.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnFixZomOut.Id = 6;
            this.barBtnFixZomOut.ImageIndex = 1;
            this.barBtnFixZomOut.Name = "barBtnFixZomOut";
            // 
            // barBtnPreview
            // 
            this.barBtnPreview.Caption = "上一视图";
            this.barBtnPreview.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnPreview.Id = 7;
            this.barBtnPreview.ImageIndex = 6;
            this.barBtnPreview.Name = "barBtnPreview";
            // 
            // barBtnNextView
            // 
            this.barBtnNextView.Caption = "下一视图";
            this.barBtnNextView.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnNextView.Id = 8;
            this.barBtnNextView.ImageIndex = 4;
            this.barBtnNextView.Name = "barBtnNextView";
            // 
            // barBtnIdentity
            // 
            this.barBtnIdentity.Caption = "识别";
            this.barBtnIdentity.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnIdentity.Id = 9;
            this.barBtnIdentity.ImageIndex = 11;
            this.barBtnIdentity.Name = "barBtnIdentity";
            // 
            // barBtnEagleEye
            // 
            this.barBtnEagleEye.Caption = "鹰眼图";
            this.barBtnEagleEye.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnEagleEye.Id = 10;
            this.barBtnEagleEye.ImageIndex = 10;
            this.barBtnEagleEye.Name = "barBtnEagleEye";
            // 
            // barBMultiWin
            // 
            this.barBMultiWin.Caption = "分窗显示";
            this.barBMultiWin.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBMultiWin.Id = 11;
            this.barBMultiWin.ImageIndex = 12;
            this.barBMultiWin.Name = "barBMultiWin";
            // 
            // barBtnSample
            // 
            this.barBtnSample.Caption = "训练样本选取";
            this.barBtnSample.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnSample.Id = 12;
            this.barBtnSample.ImageIndex = 13;
            this.barBtnSample.Name = "barBtnSample";
            // 
            // barBtnAfter
            // 
            this.barBtnAfter.Caption = "分类后校正";
            this.barBtnAfter.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnAfter.Id = 13;
            this.barBtnAfter.ImageIndex = 9;
            this.barBtnAfter.Name = "barBtnAfter";
            // 
            // barBtnShutter
            // 
            this.barBtnShutter.Caption = "卷帘";
            this.barBtnShutter.CategoryGuid = new System.Guid("59eb89ab-f63f-4029-bbb5-d20005766295");
            this.barBtnShutter.Id = 14;
            this.barBtnShutter.ImageIndex = 14;
            this.barBtnShutter.Name = "barBtnShutter";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(2, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(754, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 599);
            this.barDockControlBottom.Size = new System.Drawing.Size(1014, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 599);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1014, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 599);
            // 
            // image16
            // 
            this.image16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image16.ImageStream")));
            this.image16.Images.SetKeyName(0, "add.png");
            this.image16.Images.SetKeyName(1, "fixZomIn.png");
            this.image16.Images.SetKeyName(2, "fixZomOut.png");
            this.image16.Images.SetKeyName(3, "FullExtent.png");
            this.image16.Images.SetKeyName(4, "nextView.png");
            this.image16.Images.SetKeyName(5, "Pan.png");
            this.image16.Images.SetKeyName(6, "preView.png");
            this.image16.Images.SetKeyName(7, "ZoomIn.png");
            this.image16.Images.SetKeyName(8, "ZoomOut.png");
            this.image16.Images.SetKeyName(9, "after.png");
            this.image16.Images.SetKeyName(10, "eagle.png");
            this.image16.Images.SetKeyName(11, "identity.png");
            this.image16.Images.SetKeyName(12, "multiWin.png");
            this.image16.Images.SetKeyName(13, "selectSample.png");
            this.image16.Images.SetKeyName(14, "shutter.png");
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.axToolbarControl);
            this.panelMap.Controls.Add(this.axMapControl);
            this.panelMap.Controls.Add(this.barDockControlTop);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(256, 147);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(758, 401);
            this.panelMap.TabIndex = 9;
            // 
            // axToolbarControl
            // 
            this.axToolbarControl.Location = new System.Drawing.Point(6, 39);
            this.axToolbarControl.Name = "axToolbarControl";
            this.axToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl.OcxState")));
            this.axToolbarControl.Size = new System.Drawing.Size(439, 28);
            this.axToolbarControl.TabIndex = 2;
            this.axToolbarControl.Visible = false;
            // 
            // axMapControl
            // 
            this.axMapControl.Location = new System.Drawing.Point(6, 73);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(439, 55);
            this.axMapControl.TabIndex = 1;
            // 
            // axTOCControl
            // 
            this.axTOCControl.Location = new System.Drawing.Point(3, 16);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(88, 97);
            this.axTOCControl.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 599);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.dpLayers);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Classification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbion32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dpFlow.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dpLayers.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMap)).EndInit();
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFile;
        private DevExpress.XtraBars.BarButtonItem btnAddData;
        private DevExpress.Utils.ImageCollection ribbion32;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTask;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSample;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSingle;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupMulti;
        private DevExpress.XtraBars.BarButtonItem btnNewTask;
        private DevExpress.XtraBars.BarButtonItem btnOpenTask;
        private DevExpress.XtraBars.BarButtonItem btnSaveTask;
        private DevExpress.XtraBars.BarButtonItem btnUpdateTask;
        private DevExpress.XtraBars.BarButtonItem btnMask;
        private DevExpress.XtraBars.BarButtonItem btnMosaic;
        private DevExpress.XtraBars.BarSubItem bsiSingleDate;
        private DevExpress.XtraBars.BarSubItem bsiMultiDate;
        private DevExpress.XtraBars.BarSubItem bsiRadarAndMultiSpectral;
        private DevExpress.XtraBars.BarSubItem bsiMiddleAndHigh;
        private DevExpress.XtraBars.BarButtonItem btnSample;
        private DevExpress.XtraBars.BarButtonItem btnSampleAnaly;
        private DevExpress.XtraBars.BarButtonItem btnRecode;
        private DevExpress.XtraBars.BarButtonItem btnReject;
        private DevExpress.XtraBars.BarButtonItem btnStatistics;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAfter;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpFlow;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpLayers;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.BarButtonItem btnVerify;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupVerify;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCropMosaic;
        private UCWorkFlow ucWorkFlow1;
        private DevExpress.XtraBars.BarButtonItem btnCropMosaic;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraEditors.PanelControl panelMap;
        private DevExpress.XtraBars.BarButtonItem barbtnAddData;
        private DevExpress.XtraBars.BarButtonItem barBtnFull;
        private DevExpress.XtraBars.BarButtonItem barBtnPan;
        private DevExpress.XtraBars.BarButtonItem barBtnZomIn;
        private DevExpress.XtraBars.BarButtonItem barBtnZomOut;
        private DevExpress.XtraBars.BarButtonItem barBtnFixZomIn;
        private DevExpress.XtraBars.BarButtonItem barBtnFixZomOut;
        private DevExpress.XtraBars.BarButtonItem barBtnPreview;
        private DevExpress.XtraBars.BarButtonItem barBtnNextView;
        private DevExpress.XtraBars.BarButtonItem barBtnIdentity;
        private DevExpress.XtraBars.BarButtonItem barBtnEagleEye;
        private DevExpress.XtraBars.BarButtonItem barBMultiWin;
        private DevExpress.Utils.ImageCollection image16;
        private DevExpress.XtraBars.BarButtonItem barBtnSample;
        private DevExpress.XtraBars.BarButtonItem barBtnAfter;
        private DevExpress.XtraBars.BarButtonItem barBtnShutter;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private DevExpress.XtraBars.BarSubItem bsiAfter;
        private DevExpress.XtraBars.BarButtonItem btnNNHard;
        private DevExpress.XtraBars.BarButtonItem btnSoftHard;
        private DevExpress.XtraBars.BarButtonItem btnOverlayClass;
        private DevExpress.XtraBars.BarButtonItem btnDecision;
        private DevExpress.XtraBars.BarButtonItem btnOpticsDiv;
        private DevExpress.XtraBars.BarButtonItem btnSyn;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
    }
}

