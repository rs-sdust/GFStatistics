namespace GFS.Commands.UI
{
    partial class frmCreatePyramid
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spinEditQuality = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditZip = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditReSample = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditQuality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditReSample.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "重采样方法：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "压缩方式：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 114);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "压缩质量：";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinEditQuality);
            this.groupControl1.Controls.Add(this.comboBoxEditZip);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.comboBoxEditReSample);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(9, 9);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(266, 150);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // spinEditQuality
            // 
            this.spinEditQuality.EditValue = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.spinEditQuality.Location = new System.Drawing.Point(89, 111);
            this.spinEditQuality.Name = "spinEditQuality";
            this.spinEditQuality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditQuality.Size = new System.Drawing.Size(165, 21);
            this.spinEditQuality.TabIndex = 6;
            // 
            // comboBoxEditZip
            // 
            this.comboBoxEditZip.Location = new System.Drawing.Point(89, 62);
            this.comboBoxEditZip.Name = "comboBoxEditZip";
            this.comboBoxEditZip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditZip.Size = new System.Drawing.Size(165, 21);
            this.comboBoxEditZip.TabIndex = 4;
            this.comboBoxEditZip.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditZip_SelectedIndexChanged);
            // 
            // comboBoxEditReSample
            // 
            this.comboBoxEditReSample.Location = new System.Drawing.Point(89, 14);
            this.comboBoxEditReSample.Name = "comboBoxEditReSample";
            this.comboBoxEditReSample.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditReSample.Size = new System.Drawing.Size(165, 21);
            this.comboBoxEditReSample.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "否";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "是";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmCreatePyramid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 206);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreatePyramid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建金字塔？";
            this.Load += new System.EventHandler(this.frmCreatePyramid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditQuality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditReSample.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditZip;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditReSample;
        private DevExpress.XtraEditors.SpinEdit spinEditQuality;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}