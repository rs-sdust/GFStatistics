namespace GFS.Sample
{
    partial class UCWorkFlow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorkFlow));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFrame = new System.Windows.Forms.Button();
            this.btnErrorAnalyze = new System.Windows.Forms.Button();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnEstimate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSummary = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btnErrorAnalyzeDefault");
            this.imageList1.Images.SetKeyName(1, "btnErrorAnalyzeDone");
            this.imageList1.Images.SetKeyName(2, "btnErrorAnalyzeRunning");
            this.imageList1.Images.SetKeyName(3, "btnEstimateDefault");
            this.imageList1.Images.SetKeyName(4, "btnEstimateDone");
            this.imageList1.Images.SetKeyName(5, "btnEstimateRunning");
            this.imageList1.Images.SetKeyName(6, "btnFrameDefault");
            this.imageList1.Images.SetKeyName(7, "btnFrameDone");
            this.imageList1.Images.SetKeyName(8, "btnFrameRunning");
            this.imageList1.Images.SetKeyName(9, "btnReviewDefault");
            this.imageList1.Images.SetKeyName(10, "btnReviewDone");
            this.imageList1.Images.SetKeyName(11, "btnReviewRunning");
            this.imageList1.Images.SetKeyName(12, "btnSampleDefault");
            this.imageList1.Images.SetKeyName(13, "btnSampleDone");
            this.imageList1.Images.SetKeyName(14, "btnSampleRunning");
            this.imageList1.Images.SetKeyName(15, "btnSimulationDefault");
            this.imageList1.Images.SetKeyName(16, "btnSimulationDone");
            this.imageList1.Images.SetKeyName(17, "btnSimulationRunning");
            this.imageList1.Images.SetKeyName(18, "btnSummaryDefault");
            this.imageList1.Images.SetKeyName(19, "btnSummaryDone");
            this.imageList1.Images.SetKeyName(20, "btnSummaryRunning");
            // 
            // btnFrame
            // 
            this.btnFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFrame.FlatAppearance.BorderSize = 0;
            this.btnFrame.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrame.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFrame.ImageKey = "btnFrameDefault";
            this.btnFrame.ImageList = this.imageList1;
            this.btnFrame.Location = new System.Drawing.Point(27, 71);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(80, 54);
            this.btnFrame.TabIndex = 3;
            this.btnFrame.Text = "构建抽样框";
            this.btnFrame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnFrame, "流程说明，\r\n浮动状态无法显示。");
            this.btnFrame.UseVisualStyleBackColor = false;
            // 
            // btnErrorAnalyze
            // 
            this.btnErrorAnalyze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnErrorAnalyze.FlatAppearance.BorderSize = 0;
            this.btnErrorAnalyze.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnErrorAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorAnalyze.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnErrorAnalyze.ImageKey = "btnErrorAnalyzeDefault";
            this.btnErrorAnalyze.ImageList = this.imageList1;
            this.btnErrorAnalyze.Location = new System.Drawing.Point(155, 71);
            this.btnErrorAnalyze.Name = "btnErrorAnalyze";
            this.btnErrorAnalyze.Size = new System.Drawing.Size(80, 54);
            this.btnErrorAnalyze.TabIndex = 4;
            this.btnErrorAnalyze.Text = "误差分析";
            this.btnErrorAnalyze.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnErrorAnalyze, "流程说明");
            this.btnErrorAnalyze.UseVisualStyleBackColor = false;
            // 
            // btnSimulation
            // 
            this.btnSimulation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimulation.FlatAppearance.BorderSize = 0;
            this.btnSimulation.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimulation.ImageKey = "btnSimulationDefault";
            this.btnSimulation.ImageList = this.imageList1;
            this.btnSimulation.Location = new System.Drawing.Point(283, 71);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(80, 54);
            this.btnSimulation.TabIndex = 5;
            this.btnSimulation.Tag = "default";
            this.btnSimulation.Text = "抽样仿真";
            this.btnSimulation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSimulation, "流程说明");
            this.btnSimulation.UseVisualStyleBackColor = false;
            // 
            // btnSample
            // 
            this.btnSample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSample.FlatAppearance.BorderSize = 0;
            this.btnSample.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSample.ImageKey = "btnSampleDefault";
            this.btnSample.ImageList = this.imageList1;
            this.btnSample.Location = new System.Drawing.Point(411, 71);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(80, 54);
            this.btnSample.TabIndex = 7;
            this.btnSample.Tag = "default";
            this.btnSample.Text = "样本抽选";
            this.btnSample.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSample, "流程说明");
            this.btnSample.UseVisualStyleBackColor = false;
            // 
            // btnReview
            // 
            this.btnReview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReview.FlatAppearance.BorderSize = 0;
            this.btnReview.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReview.ImageKey = "btnReviewDefault";
            this.btnReview.ImageList = this.imageList1;
            this.btnReview.Location = new System.Drawing.Point(667, 71);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(80, 54);
            this.btnReview.TabIndex = 10;
            this.btnReview.Tag = "default";
            this.btnReview.Text = "样本审核";
            this.btnReview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnReview, "流程说明");
            this.btnReview.UseVisualStyleBackColor = false;
            // 
            // btnEstimate
            // 
            this.btnEstimate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEstimate.FlatAppearance.BorderSize = 0;
            this.btnEstimate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnEstimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstimate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEstimate.ImageKey = "btnEstimateDefault";
            this.btnEstimate.ImageList = this.imageList1;
            this.btnEstimate.Location = new System.Drawing.Point(795, 71);
            this.btnEstimate.Name = "btnEstimate";
            this.btnEstimate.Size = new System.Drawing.Size(80, 54);
            this.btnEstimate.TabIndex = 11;
            this.btnEstimate.Tag = "default";
            this.btnEstimate.Text = "总体估计";
            this.btnEstimate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnEstimate, "流程说明");
            this.btnEstimate.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ColumnCount = 9;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.Controls.Add(this.btnFrame, 1, 2);
            this.panel1.Controls.Add(this.btnErrorAnalyze, 2, 2);
            this.panel1.Controls.Add(this.btnSimulation, 3, 2);
            this.panel1.Controls.Add(this.btnSample, 4, 2);
            this.panel1.Controls.Add(this.btnEstimate, 7, 2);
            this.panel1.Controls.Add(this.btnReview, 6, 2);
            this.panel1.Controls.Add(this.btnSummary, 5, 2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RowCount = 5;
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.Size = new System.Drawing.Size(902, 196);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.UCWorkFlow_Paint);
            // 
            // btnSummary
            // 
            this.btnSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSummary.FlatAppearance.BorderSize = 0;
            this.btnSummary.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSummary.ImageKey = "btnSummaryDefault";
            this.btnSummary.ImageList = this.imageList1;
            this.btnSummary.Location = new System.Drawing.Point(539, 71);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(80, 54);
            this.btnSummary.TabIndex = 10;
            this.btnSummary.Tag = "default";
            this.btnSummary.Text = "样本汇总";
            this.btnSummary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSummary.UseVisualStyleBackColor = false;
            // 
            // UCWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "UCWorkFlow";
            this.Size = new System.Drawing.Size(902, 196);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel panel1;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.Button btnErrorAnalyze;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnEstimate;
        private System.Windows.Forms.Button btnSummary;

    }
}
