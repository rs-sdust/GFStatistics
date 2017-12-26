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
            this.btnForest = new System.Windows.Forms.Button();
            this.btnShrub = new System.Windows.Forms.Button();
            this.btnGrass = new System.Windows.Forms.Button();
            this.btnVeg = new System.Windows.Forms.Button();
            this.btnSoil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btnForestDefault");
            this.imageList1.Images.SetKeyName(1, "btnForestDone");
            this.imageList1.Images.SetKeyName(2, "btnForestRunning");
            this.imageList1.Images.SetKeyName(3, "btnGrassDefault");
            this.imageList1.Images.SetKeyName(4, "btnGrassDone");
            this.imageList1.Images.SetKeyName(5, "btnGrassRunning");
            this.imageList1.Images.SetKeyName(6, "btnShrubDefault");
            this.imageList1.Images.SetKeyName(7, "btnShrubDone");
            this.imageList1.Images.SetKeyName(8, "btnShrubRunning");
            this.imageList1.Images.SetKeyName(9, "btnSoilDefault");
            this.imageList1.Images.SetKeyName(10, "btnSoilDone");
            this.imageList1.Images.SetKeyName(11, "btnSoilRunning");
            this.imageList1.Images.SetKeyName(12, "btnVegDefault");
            this.imageList1.Images.SetKeyName(13, "btnVegDone");
            this.imageList1.Images.SetKeyName(14, "btnVegRunning");
            // 
            // btnForest
            // 
            this.btnForest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForest.FlatAppearance.BorderSize = 0;
            this.btnForest.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnForest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnForest.ImageKey = "btnForestDefault";
            this.btnForest.ImageList = this.imageList1;
            this.btnForest.Location = new System.Drawing.Point(155, 71);
            this.btnForest.Name = "btnForest";
            this.btnForest.Size = new System.Drawing.Size(80, 54);
            this.btnForest.TabIndex = 3;
            this.btnForest.Text = "森林碳汇";
            this.btnForest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnForest, "流程说明，\r\n浮动状态无法显示。");
            this.btnForest.UseVisualStyleBackColor = false;
            // 
            // btnShrub
            // 
            this.btnShrub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShrub.FlatAppearance.BorderSize = 0;
            this.btnShrub.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnShrub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShrub.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShrub.ImageKey = "btnShrubDefault";
            this.btnShrub.ImageList = this.imageList1;
            this.btnShrub.Location = new System.Drawing.Point(283, 71);
            this.btnShrub.Name = "btnShrub";
            this.btnShrub.Size = new System.Drawing.Size(80, 54);
            this.btnShrub.TabIndex = 4;
            this.btnShrub.Text = "灌丛碳汇";
            this.btnShrub.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnShrub, "流程说明");
            this.btnShrub.UseVisualStyleBackColor = false;
            // 
            // btnGrass
            // 
            this.btnGrass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGrass.FlatAppearance.BorderSize = 0;
            this.btnGrass.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnGrass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrass.ImageKey = "btnGrassDefault";
            this.btnGrass.ImageList = this.imageList1;
            this.btnGrass.Location = new System.Drawing.Point(411, 71);
            this.btnGrass.Name = "btnGrass";
            this.btnGrass.Size = new System.Drawing.Size(80, 54);
            this.btnGrass.TabIndex = 5;
            this.btnGrass.Tag = "default";
            this.btnGrass.Text = "草地碳汇";
            this.btnGrass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnGrass, "流程说明");
            this.btnGrass.UseVisualStyleBackColor = false;
            // 
            // btnVeg
            // 
            this.btnVeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVeg.FlatAppearance.BorderSize = 0;
            this.btnVeg.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnVeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVeg.ImageKey = "btnVegDefault";
            this.btnVeg.ImageList = this.imageList1;
            this.btnVeg.Location = new System.Drawing.Point(539, 71);
            this.btnVeg.Name = "btnVeg";
            this.btnVeg.Size = new System.Drawing.Size(80, 54);
            this.btnVeg.TabIndex = 7;
            this.btnVeg.Tag = "default";
            this.btnVeg.Text = "植被碳汇";
            this.btnVeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnVeg, "流程说明");
            this.btnVeg.UseVisualStyleBackColor = false;
            // 
            // btnSoil
            // 
            this.btnSoil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSoil.FlatAppearance.BorderSize = 0;
            this.btnSoil.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnSoil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoil.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSoil.ImageKey = "btnSoilDefault";
            this.btnSoil.ImageList = this.imageList1;
            this.btnSoil.Location = new System.Drawing.Point(667, 71);
            this.btnSoil.Name = "btnSoil";
            this.btnSoil.Size = new System.Drawing.Size(80, 54);
            this.btnSoil.TabIndex = 10;
            this.btnSoil.Tag = "default";
            this.btnSoil.Text = "土壤碳汇";
            this.btnSoil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSoil, "流程说明");
            this.btnSoil.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ColumnCount = 7;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel1.Controls.Add(this.btnForest, 1, 2);
            this.panel1.Controls.Add(this.btnShrub, 2, 2);
            this.panel1.Controls.Add(this.btnGrass, 3, 2);
            this.panel1.Controls.Add(this.btnVeg, 4, 2);
            this.panel1.Controls.Add(this.btnSoil, 5, 2);
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
        private System.Windows.Forms.Button btnForest;
        private System.Windows.Forms.Button btnShrub;
        private System.Windows.Forms.Button btnGrass;
        private System.Windows.Forms.Button btnVeg;
        private System.Windows.Forms.Button btnSoil;

    }
}
