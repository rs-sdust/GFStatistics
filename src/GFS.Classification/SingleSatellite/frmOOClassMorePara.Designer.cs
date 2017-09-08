namespace GFS.Classification
{
    partial class frmOOClassMorePara
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
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.ztbMinActThres = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinMinActThres = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.ztbIteration = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinIteration = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.ztbHiddenLyr = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinHiddenLyr = new DevExpress.XtraEditors.SpinEdit();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMinActThres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMinActThres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinActThres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbIteration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinIteration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbHiddenLyr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbHiddenLyr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHiddenLyr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.labelControl12);
            this.groupControl4.Controls.Add(this.ztbMinActThres);
            this.groupControl4.Controls.Add(this.spinMinActThres);
            this.groupControl4.Controls.Add(this.labelControl13);
            this.groupControl4.Controls.Add(this.ztbIteration);
            this.groupControl4.Controls.Add(this.spinIteration);
            this.groupControl4.Controls.Add(this.labelControl14);
            this.groupControl4.Controls.Add(this.ztbHiddenLyr);
            this.groupControl4.Controls.Add(this.spinHiddenLyr);
            this.groupControl4.Location = new System.Drawing.Point(12, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(360, 131);
            this.groupControl4.TabIndex = 19;
            this.groupControl4.Text = "参数设置";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 96);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(72, 14);
            this.labelControl12.TabIndex = 16;
            this.labelControl12.Text = "最小激活阈值";
            // 
            // ztbMinActThres
            // 
            this.ztbMinActThres.EditValue = null;
            this.ztbMinActThres.Location = new System.Drawing.Point(92, 96);
            this.ztbMinActThres.Name = "ztbMinActThres";
            this.ztbMinActThres.Properties.Middle = 5;
            this.ztbMinActThres.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbMinActThres.Size = new System.Drawing.Size(194, 23);
            this.ztbMinActThres.TabIndex = 17;
            this.ztbMinActThres.EditValueChanged += new System.EventHandler(this.ztbMinActThres_EditValueChanged);
            // 
            // spinMinActThres
            // 
            this.spinMinActThres.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMinActThres.Location = new System.Drawing.Point(291, 95);
            this.spinMinActThres.Name = "spinMinActThres";
            this.spinMinActThres.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMinActThres.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinMinActThres.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinMinActThres.Size = new System.Drawing.Size(50, 20);
            this.spinMinActThres.TabIndex = 15;
            this.spinMinActThres.EditValueChanged += new System.EventHandler(this.spinMinActThres_EditValueChanged);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(11, 67);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(72, 14);
            this.labelControl13.TabIndex = 13;
            this.labelControl13.Text = "最大训练次数";
            // 
            // ztbIteration
            // 
            this.ztbIteration.EditValue = null;
            this.ztbIteration.Location = new System.Drawing.Point(92, 67);
            this.ztbIteration.Name = "ztbIteration";
            this.ztbIteration.Properties.Maximum = 1000;
            this.ztbIteration.Properties.Middle = 5;
            this.ztbIteration.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbIteration.Size = new System.Drawing.Size(194, 23);
            this.ztbIteration.TabIndex = 14;
            this.ztbIteration.EditValueChanged += new System.EventHandler(this.ztbIteration_EditValueChanged);
            // 
            // spinIteration
            // 
            this.spinIteration.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinIteration.Location = new System.Drawing.Point(291, 66);
            this.spinIteration.Name = "spinIteration";
            this.spinIteration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinIteration.Size = new System.Drawing.Size(50, 20);
            this.spinIteration.TabIndex = 12;
            this.spinIteration.EditValueChanged += new System.EventHandler(this.spinIteration_EditValueChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(11, 38);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(48, 14);
            this.labelControl14.TabIndex = 10;
            this.labelControl14.Text = "隐藏层数";
            // 
            // ztbHiddenLyr
            // 
            this.ztbHiddenLyr.EditValue = null;
            this.ztbHiddenLyr.Location = new System.Drawing.Point(92, 38);
            this.ztbHiddenLyr.Name = "ztbHiddenLyr";
            this.ztbHiddenLyr.Properties.Maximum = 2;
            this.ztbHiddenLyr.Properties.Middle = 5;
            this.ztbHiddenLyr.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbHiddenLyr.Size = new System.Drawing.Size(194, 23);
            this.ztbHiddenLyr.TabIndex = 11;
            this.ztbHiddenLyr.EditValueChanged += new System.EventHandler(this.ztbHiddenLyr_EditValueChanged);
            // 
            // spinHiddenLyr
            // 
            this.spinHiddenLyr.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinHiddenLyr.Location = new System.Drawing.Point(291, 37);
            this.spinHiddenLyr.Name = "spinHiddenLyr";
            this.spinHiddenLyr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinHiddenLyr.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spinHiddenLyr.Size = new System.Drawing.Size(50, 20);
            this.spinHiddenLyr.TabIndex = 9;
            this.spinHiddenLyr.EditValueChanged += new System.EventHandler(this.spinHiddenLyr_EditValueChanged);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(297, 157);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 21;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmOOClassMorePara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 230);
            this.Name = "frmOOClassMorePara";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更多设置";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMinActThres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMinActThres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinActThres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbIteration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinIteration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbHiddenLyr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbHiddenLyr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHiddenLyr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbMinActThres;
        private DevExpress.XtraEditors.SpinEdit spinMinActThres;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbIteration;
        private DevExpress.XtraEditors.SpinEdit spinIteration;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbHiddenLyr;
        private DevExpress.XtraEditors.SpinEdit spinHiddenLyr;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}