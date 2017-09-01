namespace GFS.Classification
{
    partial class frmSegmentation
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnIn = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ztbKernel = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinKernel = new DevExpress.XtraEditors.SpinEdit();
            this.ztbMerge = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinMerge = new DevExpress.XtraEditors.SpinEdit();
            this.ztbSegment = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinSegment = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnOut = new DevExpress.XtraEditors.ButtonEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ztbKernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbKernel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKernel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMerge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMerge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMerge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbSegment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSegment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnIn);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 77);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "输入";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "待分割影像";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(95, 35);
            this.btnIn.Name = "btnIn";
            this.btnIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnIn.Size = new System.Drawing.Size(249, 20);
            this.btnIn.TabIndex = 0;
            this.btnIn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnIn_ButtonClick);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.ztbKernel);
            this.groupControl2.Controls.Add(this.spinKernel);
            this.groupControl2.Controls.Add(this.ztbMerge);
            this.groupControl2.Controls.Add(this.spinMerge);
            this.groupControl2.Controls.Add(this.ztbSegment);
            this.groupControl2.Controls.Add(this.spinSegment);
            this.groupControl2.Location = new System.Drawing.Point(12, 95);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(360, 138);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "参数设置";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "纹理内核大小";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "融合尺度";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "分隔尺度";
            // 
            // ztbKernel
            // 
            this.ztbKernel.EditValue = null;
            this.ztbKernel.Location = new System.Drawing.Point(95, 108);
            this.ztbKernel.Name = "ztbKernel";
            this.ztbKernel.Properties.Middle = 5;
            this.ztbKernel.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbKernel.Size = new System.Drawing.Size(194, 23);
            this.ztbKernel.TabIndex = 2;
            this.ztbKernel.EditValueChanged += new System.EventHandler(this.ztbKernel_EditValueChanged);
            // 
            // spinKernel
            // 
            this.spinKernel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinKernel.Location = new System.Drawing.Point(294, 107);
            this.spinKernel.Name = "spinKernel";
            this.spinKernel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinKernel.Size = new System.Drawing.Size(50, 20);
            this.spinKernel.TabIndex = 1;
            this.spinKernel.EditValueChanged += new System.EventHandler(this.spinKernel_EditValueChanged);
            // 
            // ztbMerge
            // 
            this.ztbMerge.EditValue = null;
            this.ztbMerge.Location = new System.Drawing.Point(95, 71);
            this.ztbMerge.Name = "ztbMerge";
            this.ztbMerge.Properties.Maximum = 100;
            this.ztbMerge.Properties.Middle = 5;
            this.ztbMerge.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbMerge.Size = new System.Drawing.Size(194, 23);
            this.ztbMerge.TabIndex = 2;
            this.ztbMerge.EditValueChanged += new System.EventHandler(this.ztbMerge_EditValueChanged);
            // 
            // spinMerge
            // 
            this.spinMerge.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMerge.Location = new System.Drawing.Point(294, 70);
            this.spinMerge.Name = "spinMerge";
            this.spinMerge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMerge.Size = new System.Drawing.Size(50, 20);
            this.spinMerge.TabIndex = 1;
            this.spinMerge.EditValueChanged += new System.EventHandler(this.spinMerge_EditValueChanged);
            // 
            // ztbSegment
            // 
            this.ztbSegment.EditValue = null;
            this.ztbSegment.Location = new System.Drawing.Point(95, 34);
            this.ztbSegment.Name = "ztbSegment";
            this.ztbSegment.Properties.Maximum = 100;
            this.ztbSegment.Properties.Middle = 5;
            this.ztbSegment.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbSegment.Size = new System.Drawing.Size(194, 23);
            this.ztbSegment.TabIndex = 2;
            this.ztbSegment.EditValueChanged += new System.EventHandler(this.ztbSegment_EditValueChanged);
            // 
            // spinSegment
            // 
            this.spinSegment.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinSegment.Location = new System.Drawing.Point(294, 33);
            this.spinSegment.Name = "spinSegment";
            this.spinSegment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSegment.Size = new System.Drawing.Size(50, 20);
            this.spinSegment.TabIndex = 1;
            this.spinSegment.EditValueChanged += new System.EventHandler(this.spinSegment_EditValueChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Location = new System.Drawing.Point(12, 239);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 77);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "输出";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "结果文件";
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(95, 35);
            this.btnOut.Name = "btnOut";
            this.btnOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnOut.Size = new System.Drawing.Size(249, 20);
            this.btnOut.TabIndex = 0;
            this.btnOut.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnOut_ButtonClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 336);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(297, 336);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmSegmentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 373);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "frmSegmentation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图像分割";
            this.Load += new System.EventHandler(this.frmSegmentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ztbKernel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbKernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKernel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMerge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMerge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMerge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbSegment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSegment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOut.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit btnIn;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbKernel;
        private DevExpress.XtraEditors.SpinEdit spinKernel;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbMerge;
        private DevExpress.XtraEditors.SpinEdit spinMerge;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbSegment;
        private DevExpress.XtraEditors.SpinEdit spinSegment;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ButtonEdit btnOut;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
    }
}