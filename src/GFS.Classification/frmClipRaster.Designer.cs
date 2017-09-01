namespace GFS.Classification
{
    partial class frmClipRaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClipRaster));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.siBvector = new DevExpress.XtraEditors.SimpleButton();
            this.cBEvector = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cBEreaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.siBgrid = new DevExpress.XtraEditors.SimpleButton();
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            this.siBconcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelCilp = new DevExpress.XtraEditors.LabelControl();
            this.TXEEresult = new DevExpress.XtraEditors.TextEdit();
            this.SIBsave = new DevExpress.XtraEditors.SimpleButton();
            this.siBhelphide = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.cBEvector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBEreaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXEEresult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(20, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "输出结果";
            // 
            // siBvector
            // 
            this.siBvector.Image = ((System.Drawing.Image)(resources.GetObject("siBvector.Image")));
            this.siBvector.ImageIndex = 1;
            this.siBvector.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBvector.Location = new System.Drawing.Point(389, 85);
            this.siBvector.Name = "siBvector";
            this.siBvector.Size = new System.Drawing.Size(24, 24);
            this.siBvector.TabIndex = 9;
            this.siBvector.Click += new System.EventHandler(this.siBvector_Click);
            // 
            // cBEvector
            // 
            this.cBEvector.Location = new System.Drawing.Point(102, 87);
            this.cBEvector.Name = "cBEvector";
            this.cBEvector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBEvector.Size = new System.Drawing.Size(269, 20);
            this.cBEvector.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(20, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "裁剪范围";
            // 
            // cBEreaster
            // 
            this.cBEreaster.Location = new System.Drawing.Point(102, 46);
            this.cBEreaster.Name = "cBEreaster";
            this.cBEreaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBEreaster.Size = new System.Drawing.Size(269, 20);
            this.cBEreaster.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(20, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "被裁减图像";
            // 
            // siBgrid
            // 
            this.siBgrid.Image = ((System.Drawing.Image)(resources.GetObject("siBgrid.Image")));
            this.siBgrid.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBgrid.Location = new System.Drawing.Point(389, 44);
            this.siBgrid.Name = "siBgrid";
            this.siBgrid.Size = new System.Drawing.Size(24, 24);
            this.siBgrid.TabIndex = 1;
            this.siBgrid.Click += new System.EventHandler(this.siBgrid_Click);
            // 
            // labelCilp1
            // 
            this.labelCilp1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelCilp1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCilp1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelCilp1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelCilp1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.labelCilp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCilp1.LineVisible = true;
            this.labelCilp1.Location = new System.Drawing.Point(2, 22);
            this.labelCilp1.Name = "labelCilp1";
            this.labelCilp1.Size = new System.Drawing.Size(279, 230);
            this.labelCilp1.TabIndex = 20;
            this.labelCilp1.Text = "该工具用于将栅格图像按\r\n照面状矢量文件的边界进\r\n行裁剪，得到矢量文件范\r\n围内的栅格图像。";
            // 
            // siBconcel
            // 
            this.siBconcel.Location = new System.Drawing.Point(282, 244);
            this.siBconcel.Name = "siBconcel";
            this.siBconcel.Size = new System.Drawing.Size(75, 23);
            this.siBconcel.TabIndex = 18;
            this.siBconcel.Text = "取消";
            this.siBconcel.Click += new System.EventHandler(this.siBconcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.Location = new System.Drawing.Point(191, 244);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(75, 23);
            this.siBOK.TabIndex = 17;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // labelCilp
            // 
            this.labelCilp.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCilp.Location = new System.Drawing.Point(573, 12);
            this.labelCilp.Name = "labelCilp";
            this.labelCilp.Size = new System.Drawing.Size(80, 23);
            this.labelCilp.TabIndex = 16;
            this.labelCilp.Text = "图像裁剪";
            // 
            // TXEEresult
            // 
            this.TXEEresult.Location = new System.Drawing.Point(102, 41);
            this.TXEEresult.Name = "TXEEresult";
            this.TXEEresult.Size = new System.Drawing.Size(269, 20);
            this.TXEEresult.TabIndex = 11;
            // 
            // SIBsave
            // 
            this.SIBsave.Image = ((System.Drawing.Image)(resources.GetObject("SIBsave.Image")));
            this.SIBsave.ImageIndex = 0;
            this.SIBsave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SIBsave.Location = new System.Drawing.Point(389, 39);
            this.SIBsave.Name = "SIBsave";
            this.SIBsave.Size = new System.Drawing.Size(24, 24);
            this.SIBsave.TabIndex = 9;
            this.SIBsave.Click += new System.EventHandler(this.SIBsave_Click);
            // 
            // siBhelphide
            // 
            this.siBhelphide.Location = new System.Drawing.Point(372, 244);
            this.siBhelphide.Name = "siBhelphide";
            this.siBhelphide.Size = new System.Drawing.Size(75, 23);
            this.siBhelphide.TabIndex = 21;
            this.siBhelphide.Text = "显示帮助>>";
            this.siBhelphide.Click += new System.EventHandler(this.siBhelphide_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.siBvector);
            this.groupControl1.Controls.Add(this.cBEreaster);
            this.groupControl1.Controls.Add(this.cBEvector);
            this.groupControl1.Controls.Add(this.siBgrid);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(435, 126);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "输入";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.TXEEresult);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.SIBsave);
            this.groupControl2.Location = new System.Drawing.Point(12, 144);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(435, 81);
            this.groupControl2.TabIndex = 23;
            this.groupControl2.Text = "输出";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelCilp1);
            this.groupControl3.Location = new System.Drawing.Point(462, 13);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(283, 254);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "图像裁剪帮助";
            // 
            // frmClipRaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 282);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.siBhelphide);
            this.Controls.Add(this.siBconcel);
            this.Controls.Add(this.siBOK);
            this.Controls.Add(this.labelCilp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(763, 311);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 311);
            this.Name = "frmClipRaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图像裁剪";
            this.Load += new System.EventHandler(this.frmClipRaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cBEvector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBEreaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXEEresult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton siBvector;
        private DevExpress.XtraEditors.ComboBoxEdit cBEvector;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cBEreaster;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton siBgrid;
        private DevExpress.XtraEditors.LabelControl labelCilp1;
        private DevExpress.XtraEditors.SimpleButton siBconcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;
        private DevExpress.XtraEditors.LabelControl labelCilp;
        private DevExpress.XtraEditors.SimpleButton SIBsave;
        private DevExpress.XtraEditors.TextEdit TXEEresult;
        private DevExpress.XtraEditors.SimpleButton siBhelphide;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;


    }
}

