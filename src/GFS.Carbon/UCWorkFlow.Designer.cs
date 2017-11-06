namespace GFS.Carbon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorkFlow));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.btnGF = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.btnSingleDate = new System.Windows.Forms.Button();
            this.btnMultiDate = new System.Windows.Forms.Button();
            this.btnAfter = new System.Windows.Forms.Button();
            this.btnVerification = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btnGFDefault");
            this.imageList1.Images.SetKeyName(1, "dataMan.png");
            this.imageList1.Images.SetKeyName(2, "btnPrepareDefault");
            this.imageList1.Images.SetKeyName(3, "btnPrepareRunning");
            this.imageList1.Images.SetKeyName(4, "btnPrepareDone");
            this.imageList1.Images.SetKeyName(5, "btnSampleDefault");
            this.imageList1.Images.SetKeyName(6, "btnSampleRunning");
            this.imageList1.Images.SetKeyName(7, "btnSampleDone");
            this.imageList1.Images.SetKeyName(8, "btnSingleDateDefault");
            this.imageList1.Images.SetKeyName(9, "btnSingleDateRunning");
            this.imageList1.Images.SetKeyName(10, "btnSingleDateDone");
            this.imageList1.Images.SetKeyName(11, "btnAfterDefault");
            this.imageList1.Images.SetKeyName(12, "btnAfterRunning");
            this.imageList1.Images.SetKeyName(13, "btnAfterDone");
            this.imageList1.Images.SetKeyName(14, "btnVerificationDefault");
            this.imageList1.Images.SetKeyName(15, "btnVerificationRunning");
            this.imageList1.Images.SetKeyName(16, "btnVerificationDone");
            // 
            // btnGF
            // 
            this.btnGF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGF.FlatAppearance.BorderSize = 0;
            this.btnGF.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnGF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGF.ImageIndex = 0;
            this.btnGF.ImageList = this.imageList1;
            this.btnGF.Location = new System.Drawing.Point(27, 71);
            this.btnGF.Name = "btnGF";
            this.btnGF.Size = new System.Drawing.Size(80, 54);
            this.btnGF.TabIndex = 3;
            this.btnGF.Text = "GF卫星";
            this.btnGF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnGF, "流程说明，\r\n浮动状态无法显示。");
            this.btnGF.UseVisualStyleBackColor = false;
            // 
            // btnDB
            // 
            this.btnDB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDB.FlatAppearance.BorderSize = 0;
            this.btnDB.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDB.ImageIndex = 1;
            this.btnDB.ImageList = this.imageList1;
            this.btnDB.Location = new System.Drawing.Point(155, 71);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(80, 54);
            this.btnDB.TabIndex = 4;
            this.btnDB.Text = "数据管理系统";
            this.btnDB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnDB, "流程说明");
            this.btnDB.UseVisualStyleBackColor = false;
            // 
            // btnPrepare
            // 
            this.btnPrepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrepare.FlatAppearance.BorderSize = 0;
            this.btnPrepare.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnPrepare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepare.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrepare.ImageKey = "btnPrepareDefault";
            this.btnPrepare.ImageList = this.imageList1;
            this.btnPrepare.Location = new System.Drawing.Point(283, 71);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(80, 54);
            this.btnPrepare.TabIndex = 5;
            this.btnPrepare.Tag = "default";
            this.btnPrepare.Text = "测量数据准备";
            this.btnPrepare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPrepare, "流程说明");
            this.btnPrepare.UseVisualStyleBackColor = false;
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
            this.btnSample.Text = "训练样本选取";
            this.btnSample.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSample, "流程说明");
            this.btnSample.UseVisualStyleBackColor = false;
            // 
            // btnSingleDate
            // 
            this.btnSingleDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSingleDate.FlatAppearance.BorderSize = 0;
            this.btnSingleDate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnSingleDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleDate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSingleDate.ImageKey = "btnSingleDateDefault";
            this.btnSingleDate.ImageList = this.imageList1;
            this.btnSingleDate.Location = new System.Drawing.Point(539, 7);
            this.btnSingleDate.Name = "btnSingleDate";
            this.btnSingleDate.Size = new System.Drawing.Size(80, 54);
            this.btnSingleDate.TabIndex = 8;
            this.btnSingleDate.Tag = "default";
            this.btnSingleDate.Text = "单期分类";
            this.btnSingleDate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSingleDate, "流程说明");
            this.btnSingleDate.UseVisualStyleBackColor = false;
            // 
            // btnMultiDate
            // 
            this.btnMultiDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMultiDate.FlatAppearance.BorderSize = 0;
            this.btnMultiDate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnMultiDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiDate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMultiDate.ImageKey = "btnSingleDateDefault";
            this.btnMultiDate.ImageList = this.imageList1;
            this.btnMultiDate.Location = new System.Drawing.Point(539, 135);
            this.btnMultiDate.Name = "btnMultiDate";
            this.btnMultiDate.Size = new System.Drawing.Size(80, 54);
            this.btnMultiDate.TabIndex = 9;
            this.btnMultiDate.Tag = "default";
            this.btnMultiDate.Text = "多期分类";
            this.btnMultiDate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnMultiDate, "流程说明");
            this.btnMultiDate.UseVisualStyleBackColor = false;
            // 
            // btnAfter
            // 
            this.btnAfter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAfter.FlatAppearance.BorderSize = 0;
            this.btnAfter.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnAfter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAfter.ImageKey = "btnAfterDefault";
            this.btnAfter.ImageList = this.imageList1;
            this.btnAfter.Location = new System.Drawing.Point(667, 71);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.Size = new System.Drawing.Size(80, 54);
            this.btnAfter.TabIndex = 10;
            this.btnAfter.Tag = "default";
            this.btnAfter.Text = "分类后处理";
            this.btnAfter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnAfter, "流程说明");
            this.btnAfter.UseVisualStyleBackColor = false;
            // 
            // btnVerification
            // 
            this.btnVerification.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerification.FlatAppearance.BorderSize = 0;
            this.btnVerification.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnVerification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerification.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerification.ImageKey = "btnVerificationDefault";
            this.btnVerification.ImageList = this.imageList1;
            this.btnVerification.Location = new System.Drawing.Point(795, 71);
            this.btnVerification.Name = "btnVerification";
            this.btnVerification.Size = new System.Drawing.Size(80, 54);
            this.btnVerification.TabIndex = 11;
            this.btnVerification.Tag = "default";
            this.btnVerification.Text = "精度验证";
            this.btnVerification.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnVerification, "流程说明");
            this.btnVerification.UseVisualStyleBackColor = false;
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
            this.panel1.Controls.Add(this.btnGF, 1, 2);
            this.panel1.Controls.Add(this.btnDB, 2, 2);
            this.panel1.Controls.Add(this.btnPrepare, 3, 2);
            this.panel1.Controls.Add(this.btnSample, 4, 2);
            this.panel1.Controls.Add(this.btnSingleDate, 5, 1);
            this.panel1.Controls.Add(this.btnMultiDate, 5, 3);
            this.panel1.Controls.Add(this.btnAfter, 6, 2);
            this.panel1.Controls.Add(this.btnVerification, 7, 2);
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
        private System.Windows.Forms.Button btnGF;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Button btnSingleDate;
        private System.Windows.Forms.Button btnMultiDate;
        private System.Windows.Forms.Button btnAfter;
        private System.Windows.Forms.Button btnVerification;

    }
}
