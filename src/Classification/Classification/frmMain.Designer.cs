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
            this.image32 = new DevExpress.Utils.ImageCollection();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTask = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSample = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSingle = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupMulti = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAfter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image32)).BeginInit();
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
            this.btnStatistics});
            this.ribbonControl.LargeImages = this.image32;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 1;
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
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnAddData
            // 
            this.btnAddData.Caption = "加载数据";
            this.btnAddData.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddData.Id = 1;
            this.btnAddData.LargeImageIndex = 0;
            this.btnAddData.Name = "btnAddData";
            // 
            // btnNewTask
            // 
            this.btnNewTask.Caption = "新建任务";
            this.btnNewTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNewTask.Id = 9;
            this.btnNewTask.LargeImageIndex = 1;
            this.btnNewTask.Name = "btnNewTask";
            // 
            // btnOpenTask
            // 
            this.btnOpenTask.Caption = "打开任务";
            this.btnOpenTask.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenTask.Id = 10;
            this.btnOpenTask.LargeImageIndex = 2;
            this.btnOpenTask.Name = "btnOpenTask";
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
            this.btnRecode.Name = "btnRecode";
            // 
            // btnReject
            // 
            this.btnReject.Caption = "分类后校正";
            this.btnReject.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnReject.Id = 23;
            this.btnReject.Name = "btnReject";
            // 
            // btnStatistics
            // 
            this.btnStatistics.Caption = "结果统计";
            this.btnStatistics.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStatistics.Id = 24;
            this.btnStatistics.Name = "btnStatistics";
            // 
            // image32
            // 
            this.image32.ImageSize = new System.Drawing.Size(32, 32);
            this.image32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image32.ImageStream")));
            this.image32.Images.SetKeyName(0, "多层.png");
            this.image32.Images.SetKeyName(1, "new.png");
            this.image32.Images.SetKeyName(2, "open32.png");
            this.image32.Images.SetKeyName(3, "save32.png");
            this.image32.Images.SetKeyName(4, "update32.png");
            this.image32.Images.SetKeyName(5, "裁剪.png");
            this.image32.Images.SetKeyName(6, "多层.png");
            this.image32.Images.SetKeyName(7, "多图.png");
            this.image32.Images.SetKeyName(8, "合并.png");
            this.image32.Images.SetKeyName(9, "绘制多边形.png");
            this.image32.Images.SetKeyName(10, "雷达.png");
            this.image32.Images.SetKeyName(11, "随机.png");
            this.image32.Images.SetKeyName(12, "图片.png");
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
            this.ribbonPageGroupAfter});
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
            this.ribbonPageGroupAfter.ItemLinks.Add(this.btnRecode);
            this.ribbonPageGroupAfter.ItemLinks.Add(this.btnReject);
            this.ribbonPageGroupAfter.ItemLinks.Add(this.btnStatistics);
            this.ribbonPageGroupAfter.Name = "ribbonPageGroupAfter";
            this.ribbonPageGroupAfter.Text = "分类后处理";
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 595);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl;
            this.Text = "Classification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image32)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFile;
        private DevExpress.XtraBars.BarButtonItem btnAddData;
        private DevExpress.Utils.ImageCollection image32;
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
    }
}

