namespace GFS.Classification
{
    partial class frmSAVI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSAVI));
            this.gCHelp = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.siBHelp = new DevExpress.XtraEditors.SimpleButton();
            this.siBConcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cBENIRed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cBERed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEL = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cEditFTP = new DevExpress.XtraEditors.CheckEdit();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cmbInRaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gCHelp)).BeginInit();
            this.gCHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBENIRed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBERed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cEditFTP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gCHelp
            // 
            this.gCHelp.Controls.Add(this.memoEdit1);
            this.gCHelp.Location = new System.Drawing.Point(416, 12);
            this.gCHelp.Name = "gCHelp";
            this.gCHelp.Size = new System.Drawing.Size(189, 357);
            this.gCHelp.TabIndex = 65;
            this.gCHelp.Text = "土壤调节植被指数(SAVI)";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "SAVI=((NIR-R)/(NIR+R+L))(1+L)，或两个波段反射率的计算;\r\n其中，L是随着植被密度变化的参数，取值范围从0-1，当植被覆盖度很高时为0" +
                "，很低时为1。很明显，如果L=0,SAVI=NDVI。在Huete的文章中指出，对于其研究的草地和棉花田，L取0.5时SAVI消除土壤反射率的效果较好。";
            this.memoEdit1.Location = new System.Drawing.Point(2, 22);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(185, 333);
            this.memoEdit1.TabIndex = 0;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // siBHelp
            // 
            this.siBHelp.ImageIndex = 2;
            this.siBHelp.Location = new System.Drawing.Point(307, 384);
            this.siBHelp.Name = "siBHelp";
            this.siBHelp.Size = new System.Drawing.Size(78, 25);
            this.siBHelp.TabIndex = 63;
            this.siBHelp.Text = "显示帮助>>";
            this.siBHelp.Click += new System.EventHandler(this.siBHelp_Click);
            // 
            // siBConcel
            // 
            this.siBConcel.ImageIndex = 2;
            this.siBConcel.Location = new System.Drawing.Point(223, 384);
            this.siBConcel.Name = "siBConcel";
            this.siBConcel.Size = new System.Drawing.Size(78, 25);
            this.siBConcel.TabIndex = 62;
            this.siBConcel.Text = "取消";
            this.siBConcel.Click += new System.EventHandler(this.siBConcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.ImageIndex = 2;
            this.siBOK.Location = new System.Drawing.Point(139, 384);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(78, 25);
            this.siBOK.TabIndex = 61;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cBENIRed);
            this.groupControl1.Controls.Add(this.cBERed);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textEL);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(11, 105);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(394, 146);
            this.groupControl1.TabIndex = 66;
            this.groupControl1.Text = "参数设置";
            // 
            // cBENIRed
            // 
            this.cBENIRed.EditValue = "Band_4";
            this.cBENIRed.Location = new System.Drawing.Point(98, 108);
            this.cBENIRed.Name = "cBENIRed";
            this.cBENIRed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBENIRed.Size = new System.Drawing.Size(147, 20);
            this.cBENIRed.TabIndex = 69;
            // 
            // cBERed
            // 
            this.cBERed.EditValue = "Band_3";
            this.cBERed.Location = new System.Drawing.Point(98, 74);
            this.cBERed.Name = "cBERed";
            this.cBERed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBERed.Size = new System.Drawing.Size(147, 20);
            this.cBERed.TabIndex = 68;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(20, 108);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 67;
            this.labelControl5.Text = "近红外波段";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 74);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 66;
            this.labelControl4.Text = "红光波段";
            // 
            // textEL
            // 
            this.textEL.EditValue = "";
            this.textEL.Location = new System.Drawing.Point(98, 42);
            this.textEL.Name = "textEL";
            this.textEL.Properties.EditFormat.FormatString = "\"d2\"";
            this.textEL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEL.Size = new System.Drawing.Size(147, 20);
            this.textEL.TabIndex = 65;
            this.textEL.ToolTip = "输入(0-1)之间的数";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 64;
            this.labelControl1.Text = "土壤调节系数";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cEditFTP);
            this.groupControl4.Controls.Add(this.txtOut);
            this.groupControl4.Controls.Add(this.btnOut);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Location = new System.Drawing.Point(11, 257);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(394, 112);
            this.groupControl4.TabIndex = 67;
            this.groupControl4.Text = "输出";
            // 
            // cEditFTP
            // 
            this.cEditFTP.Location = new System.Drawing.Point(88, 77);
            this.cEditFTP.Name = "cEditFTP";
            this.cEditFTP.Properties.Caption = "结果上传至服务器";
            this.cEditFTP.Size = new System.Drawing.Size(119, 19);
            this.cEditFTP.TabIndex = 66;
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(98, 43);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(242, 20);
            this.txtOut.TabIndex = 56;
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(350, 43);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 55;
            this.btnOut.Click += new System.EventHandler(this.siBOutput_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(20, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 25);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "输出影像";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cmbInRaster);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.btnIn);
            this.groupControl3.Location = new System.Drawing.Point(11, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(394, 87);
            this.groupControl3.TabIndex = 69;
            this.groupControl3.Text = "输入";
            // 
            // cmbInRaster
            // 
            this.cmbInRaster.Location = new System.Drawing.Point(88, 46);
            this.cmbInRaster.Name = "cmbInRaster";
            this.cmbInRaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInRaster.Size = new System.Drawing.Size(252, 20);
            this.cmbInRaster.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(20, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 25);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "输入影像";
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIn.Location = new System.Drawing.Point(350, 44);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(24, 24);
            this.btnIn.TabIndex = 13;
            this.btnIn.Click += new System.EventHandler(this.siBInput_Click);
            // 
            // frmSAVI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 421);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gCHelp);
            this.Controls.Add(this.siBHelp);
            this.Controls.Add(this.siBConcel);
            this.Controls.Add(this.siBOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(622, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(421, 450);
            this.Name = "frmSAVI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "土壤调节植被指数(SAVI)";
            this.Load += new System.EventHandler(this.frmSAVI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gCHelp)).EndInit();
            this.gCHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBENIRed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBERed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cEditFTP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gCHelp;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton siBHelp;
        private DevExpress.XtraEditors.SimpleButton siBConcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cBENIRed;
        private DevExpress.XtraEditors.ComboBoxEdit cBERed;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CheckEdit cEditFTP;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInRaster;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnIn;
    }
}