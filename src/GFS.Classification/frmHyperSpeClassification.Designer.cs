namespace GFS.Classification
{
    partial class frmHyperSpeClassification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHyperSpeClassification));
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbInROI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInROI = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInHyper = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInHyper = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInHyper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(387, 243);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 17;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbInROI);
            this.groupControl1.Controls.Add(this.btnInROI);
            this.groupControl1.Controls.Add(this.cmbInHyper);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnInHyper);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 119);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "输入";
            // 
            // cmbInROI
            // 
            this.cmbInROI.Location = new System.Drawing.Point(116, 75);
            this.cmbInROI.Name = "cmbInROI";
            this.cmbInROI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInROI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInROI.Size = new System.Drawing.Size(290, 20);
            this.cmbInROI.TabIndex = 8;
            // 
            // btnInROI
            // 
            this.btnInROI.Image = ((System.Drawing.Image)(resources.GetObject("btnInROI.Image")));
            this.btnInROI.Location = new System.Drawing.Point(426, 73);
            this.btnInROI.Name = "btnInROI";
            this.btnInROI.Size = new System.Drawing.Size(24, 24);
            this.btnInROI.TabIndex = 7;
            this.btnInROI.Click += new System.EventHandler(this.btnInROI_Click);
            // 
            // cmbInHyper
            // 
            this.cmbInHyper.Location = new System.Drawing.Point(116, 35);
            this.cmbInHyper.Name = "cmbInHyper";
            this.cmbInHyper.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInHyper.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInHyper.Size = new System.Drawing.Size(290, 20);
            this.cmbInHyper.TabIndex = 8;
            this.cmbInHyper.TextChanged += new System.EventHandler(this.cmbInHyper_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "训练样本";
            // 
            // btnInHyper
            // 
            this.btnInHyper.Image = ((System.Drawing.Image)(resources.GetObject("btnInHyper.Image")));
            this.btnInHyper.Location = new System.Drawing.Point(426, 33);
            this.btnInHyper.Name = "btnInHyper";
            this.btnInHyper.Size = new System.Drawing.Size(24, 24);
            this.btnInHyper.TabIndex = 7;
            this.btnInHyper.Click += new System.EventHandler(this.btnInHyper_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "高光谱影像";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "结果文件";
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(426, 36);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 12;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(116, 38);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(290, 20);
            this.txtOut.TabIndex = 13;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 137);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(472, 77);
            this.groupControl3.TabIndex = 15;
            this.groupControl3.Text = "输出";
            // 
            // frmHyperSpeClassification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 293);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 332);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 332);
            this.Name = "frmHyperSpeClassification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "高光谱分类";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmHyperSpeClassification_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmHyperSpeClassification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInHyper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInROI;
        private DevExpress.XtraEditors.SimpleButton btnInROI;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInHyper;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInHyper;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}