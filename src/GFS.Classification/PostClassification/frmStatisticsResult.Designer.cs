namespace GFS.Classification
{
    partial class frmStatisticsResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatisticsResult));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cBEResult = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.siBResult = new DevExpress.XtraEditors.SimpleButton();
            this.siBHelp = new DevExpress.XtraEditors.SimpleButton();
            this.siBConcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBEResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cBEResult);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.siBResult);
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(394, 87);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "输入";
            // 
            // cBEResult
            // 
            this.cBEResult.Location = new System.Drawing.Point(86, 44);
            this.cBEResult.Name = "cBEResult";
            this.cBEResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBEResult.Size = new System.Drawing.Size(261, 20);
            this.cBEResult.TabIndex = 15;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(23, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 25);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "分类结果";
            // 
            // siBResult
            // 
            this.siBResult.Image = ((System.Drawing.Image)(resources.GetObject("siBResult.Image")));
            this.siBResult.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBResult.Location = new System.Drawing.Point(364, 44);
            this.siBResult.Name = "siBResult";
            this.siBResult.Size = new System.Drawing.Size(20, 20);
            this.siBResult.TabIndex = 13;
            this.siBResult.Click += new System.EventHandler(this.siBResult_Click);
            // 
            // siBHelp
            // 
            this.siBHelp.ImageIndex = 2;
            this.siBHelp.Location = new System.Drawing.Point(326, 116);
            this.siBHelp.Name = "siBHelp";
            this.siBHelp.Size = new System.Drawing.Size(78, 25);
            this.siBHelp.TabIndex = 55;
            this.siBHelp.Text = "显示帮助>>";
            this.siBHelp.Click += new System.EventHandler(this.siBHelp_Click);
            // 
            // siBConcel
            // 
            this.siBConcel.ImageIndex = 2;
            this.siBConcel.Location = new System.Drawing.Point(217, 116);
            this.siBConcel.Name = "siBConcel";
            this.siBConcel.Size = new System.Drawing.Size(78, 25);
            this.siBConcel.TabIndex = 54;
            this.siBConcel.Text = "取消";
            this.siBConcel.Click += new System.EventHandler(this.siBConcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.ImageIndex = 2;
            this.siBOK.Location = new System.Drawing.Point(98, 116);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(78, 25);
            this.siBOK.TabIndex = 53;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.memoEdit1);
            this.groupControl2.Location = new System.Drawing.Point(438, -1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(160, 151);
            this.groupControl2.TabIndex = 56;
            this.groupControl2.Text = "结果统计";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "该工具用以统计分类结果中，各类别的像元个数、所占比例及面积。";
            this.memoEdit1.Location = new System.Drawing.Point(2, 22);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(156, 127);
            this.memoEdit1.TabIndex = 1;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // frmStatisticsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 162);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.siBHelp);
            this.Controls.Add(this.siBConcel);
            this.Controls.Add(this.siBOK);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(605, 191);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 191);
            this.Name = "frmStatisticsResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "结果统计";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmStatisticsResult_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmStatisticsResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cBEResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cBEResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton siBResult;
        private DevExpress.XtraEditors.SimpleButton siBHelp;
        private DevExpress.XtraEditors.SimpleButton siBConcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}