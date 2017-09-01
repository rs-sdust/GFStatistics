namespace GFS.ClassificationBLL
{
    partial class frmEditNode
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtData = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtExp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNodeaName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodeaName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtData);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtExp);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtNodeaName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(284, 145);
            this.groupControl1.TabIndex = 0;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(66, 107);
            this.txtData.Name = "txtData";
            this.txtData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtData.Size = new System.Drawing.Size(206, 20);
            this.txtData.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "决策数据";
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(66, 66);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(206, 20);
            this.txtExp.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "决策条件";
            // 
            // txtNodeaName
            // 
            this.txtNodeaName.Location = new System.Drawing.Point(66, 26);
            this.txtNodeaName.Name = "txtNodeaName";
            this.txtNodeaName.Size = new System.Drawing.Size(206, 20);
            this.txtNodeaName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "节点名称";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(66, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(197, 160);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmEditNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 195);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 234);
            this.Name = "frmEditNode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEditNode";
            this.Load += new System.EventHandler(this.frmEditNode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodeaName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNodeaName;
        private DevExpress.XtraEditors.ButtonEdit txtData;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtExp;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}