namespace GFS.Classification
{
    partial class frmClassifyAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassifyAdjustment));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.siBResult = new DevExpress.XtraEditors.SimpleButton();
            this.cBEresult = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cBEreaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.siBRaster = new DevExpress.XtraEditors.SimpleButton();
            this.siBhelp = new DevExpress.XtraEditors.SimpleButton();
            this.siBconcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBEresult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBEreaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.siBResult);
            this.groupControl1.Controls.Add(this.cBEresult);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cBEreaster);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.siBRaster);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(392, 151);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "输入";
            // 
            // siBResult
            // 
            this.siBResult.Image = ((System.Drawing.Image)(resources.GetObject("siBResult.Image")));
            this.siBResult.ImageIndex = 1;
            this.siBResult.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBResult.Location = new System.Drawing.Point(362, 95);
            this.siBResult.Name = "siBResult";
            this.siBResult.Size = new System.Drawing.Size(20, 20);
            this.siBResult.TabIndex = 15;
            this.siBResult.Click += new System.EventHandler(this.siBResult_Click);
            // 
            // cBEresult
            // 
            this.cBEresult.Location = new System.Drawing.Point(75, 95);
            this.cBEresult.Name = "cBEresult";
            this.cBEresult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBEresult.Properties.ReadOnly = true;
            this.cBEresult.Size = new System.Drawing.Size(269, 20);
            this.cBEresult.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(15, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "分类结果";
            // 
            // cBEreaster
            // 
            this.cBEreaster.Location = new System.Drawing.Point(75, 47);
            this.cBEreaster.Name = "cBEreaster";
            this.cBEreaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBEreaster.Properties.ReadOnly = true;
            this.cBEreaster.Size = new System.Drawing.Size(269, 20);
            this.cBEreaster.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(15, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 25);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "栅格图像";
            // 
            // siBRaster
            // 
            this.siBRaster.Image = ((System.Drawing.Image)(resources.GetObject("siBRaster.Image")));
            this.siBRaster.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBRaster.Location = new System.Drawing.Point(362, 47);
            this.siBRaster.Name = "siBRaster";
            this.siBRaster.Size = new System.Drawing.Size(20, 20);
            this.siBRaster.TabIndex = 10;
            this.siBRaster.Click += new System.EventHandler(this.siBRaster_Click);
            // 
            // siBhelp
            // 
            this.siBhelp.Location = new System.Drawing.Point(329, 184);
            this.siBhelp.Name = "siBhelp";
            this.siBhelp.Size = new System.Drawing.Size(75, 23);
            this.siBhelp.TabIndex = 26;
            this.siBhelp.Text = "显示帮助>>";
            this.siBhelp.Click += new System.EventHandler(this.siBhelp_Click);
            // 
            // siBconcel
            // 
            this.siBconcel.Location = new System.Drawing.Point(217, 184);
            this.siBconcel.Name = "siBconcel";
            this.siBconcel.Size = new System.Drawing.Size(75, 23);
            this.siBconcel.TabIndex = 25;
            this.siBconcel.Text = "取消";
            this.siBconcel.Click += new System.EventHandler(this.siBconcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.Location = new System.Drawing.Point(108, 184);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(75, 23);
            this.siBOK.TabIndex = 24;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.memoEdit1);
            this.groupControl2.Location = new System.Drawing.Point(424, 1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(184, 222);
            this.groupControl2.TabIndex = 27;
            this.groupControl2.Text = "分类后校正";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "该工具用于分类后对于局部错分、漏分的像元，手动进行修改。提供两种图上修改方式，一是增加到当前激活类，即将一定范围内像元全部并入当前激活类中。二是减少当前激活类并入" +
                "其他类，即将当前激活类一定范围内的像元并入其他设定的类别中。";
            this.memoEdit1.Location = new System.Drawing.Point(2, 22);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(180, 198);
            this.memoEdit1.TabIndex = 0;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // frmClassifyAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 222);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.siBhelp);
            this.Controls.Add(this.siBconcel);
            this.Controls.Add(this.siBOK);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(615, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 250);
            this.Name = "frmClassifyAdjustment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分类后校正";
            this.Load += new System.EventHandler(this.siBhelp_Click);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBEresult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBEreaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton siBResult;
        private DevExpress.XtraEditors.ComboBoxEdit cBEresult;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cBEreaster;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton siBRaster;
        private DevExpress.XtraEditors.SimpleButton siBhelp;
        private DevExpress.XtraEditors.SimpleButton siBconcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}