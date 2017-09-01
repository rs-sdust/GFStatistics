namespace GFS.ClassificationBLL
{
    partial class frmEditLeaf
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spinClassValue = new DevExpress.XtraEditors.SpinEdit();
            this.colorEdit1 = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNodeaName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinClassValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodeaName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(197, 163);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(74, 163);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinClassValue);
            this.groupControl1.Controls.Add(this.colorEdit1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtNodeaName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(284, 145);
            this.groupControl1.TabIndex = 3;
            // 
            // spinClassValue
            // 
            this.spinClassValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinClassValue.Location = new System.Drawing.Point(102, 72);
            this.spinClassValue.Name = "spinClassValue";
            this.spinClassValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinClassValue.Size = new System.Drawing.Size(146, 20);
            this.spinClassValue.TabIndex = 6;
            this.spinClassValue.EditValueChanged += new System.EventHandler(this.txtNodeaName_EditValueChanged);
            // 
            // colorEdit1
            // 
            this.colorEdit1.EditValue = System.Drawing.Color.Empty;
            this.colorEdit1.Location = new System.Drawing.Point(102, 113);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit1.Size = new System.Drawing.Size(146, 20);
            this.colorEdit1.TabIndex = 5;
            this.colorEdit1.EditValueChanged += new System.EventHandler(this.txtNodeaName_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 116);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "颜色";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "像元值";
            // 
            // txtNodeaName
            // 
            this.txtNodeaName.Location = new System.Drawing.Point(102, 32);
            this.txtNodeaName.Name = "txtNodeaName";
            this.txtNodeaName.Size = new System.Drawing.Size(146, 20);
            this.txtNodeaName.TabIndex = 1;
            this.txtNodeaName.EditValueChanged += new System.EventHandler(this.txtNodeaName_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "节点名称";
            // 
            // frmEditLeaf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 237);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 237);
            this.Name = "frmEditLeaf";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑类别";
            this.Load += new System.EventHandler(this.frmEditLeaf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinClassValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodeaName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNodeaName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ColorEdit colorEdit1;
        private DevExpress.XtraEditors.SpinEdit spinClassValue;
    }
}