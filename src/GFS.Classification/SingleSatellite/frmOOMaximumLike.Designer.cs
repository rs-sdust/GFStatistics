namespace GFS.Classification
{
    partial class frmOOMaximumLike
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOOMaximumLike));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtROI = new DevExpress.XtraEditors.TextEdit();
            this.btnInROI = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInRaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInRaster = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtROI);
            this.groupControl1.Controls.Add(this.btnInROI);
            this.groupControl1.Controls.Add(this.cmbInRaster);
            this.groupControl1.Controls.Add(this.btnInRaster);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 105);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "输入";
            // 
            // txtROI
            // 
            this.txtROI.Location = new System.Drawing.Point(94, 67);
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(219, 20);
            this.txtROI.TabIndex = 12;
            // 
            // btnInROI
            // 
            this.btnInROI.Image = ((System.Drawing.Image)(resources.GetObject("btnInROI.Image")));
            this.btnInROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnInROI.Location = new System.Drawing.Point(318, 65);
            this.btnInROI.Name = "btnInROI";
            this.btnInROI.Size = new System.Drawing.Size(24, 24);
            this.btnInROI.TabIndex = 11;
            this.btnInROI.Click += new System.EventHandler(this.btnInROI_Click);
            // 
            // cmbInRaster
            // 
            this.cmbInRaster.Location = new System.Drawing.Point(95, 35);
            this.cmbInRaster.Name = "cmbInRaster";
            this.cmbInRaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInRaster.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInRaster.Size = new System.Drawing.Size(219, 20);
            this.cmbInRaster.TabIndex = 10;
            // 
            // btnInRaster
            // 
            this.btnInRaster.Image = ((System.Drawing.Image)(resources.GetObject("btnInRaster.Image")));
            this.btnInRaster.Location = new System.Drawing.Point(320, 33);
            this.btnInRaster.Name = "btnInRaster";
            this.btnInRaster.Size = new System.Drawing.Size(24, 24);
            this.btnInRaster.TabIndex = 9;
            this.btnInRaster.Click += new System.EventHandler(this.btnInRaster_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 70);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "样本文件";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "分割后影像";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 123);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 74);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "输出";
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(320, 33);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 15;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(94, 35);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(219, 20);
            this.txtOut.TabIndex = 14;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "分类结果";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(177, 217);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 11;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(72, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(281, 217);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "显示帮助";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelCilp1);
            this.groupControl2.Location = new System.Drawing.Point(384, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(283, 228);
            this.groupControl2.TabIndex = 25;
            this.groupControl2.Text = "图像裁剪帮助";
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
            this.labelCilp1.Size = new System.Drawing.Size(279, 204);
            this.labelCilp1.TabIndex = 20;
            this.labelCilp1.Text = "该工具用于将栅格图像按\r\n照面状矢量文件的边界进\r\n行裁剪，得到矢量文件范\r\n围内的栅格图像。";
            // 
            // frmOOMaximumLike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(690, 305);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 305);
            this.Name = "frmOOMaximumLike";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "面向对象分类";
            this.Load += new System.EventHandler(this.frmOOMaximumLike_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtROI;
        private DevExpress.XtraEditors.SimpleButton btnInROI;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInRaster;
        private DevExpress.XtraEditors.SimpleButton btnInRaster;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelCilp1;
    }
}