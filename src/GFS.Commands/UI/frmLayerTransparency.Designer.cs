using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.Commands.UI
{
    partial class frmLayerTransparency
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
            this.zoomTrackBarControl1 = new ZoomTrackBarControl();
            this.btnOK = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.groupBox1 = new GroupBox();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.labelControl2 = new LabelControl();
            this.spinTransparency = new SpinEdit();
            this.labelControl1 = new LabelControl();
            ((ISupportInitialize)this.zoomTrackBarControl1).BeginInit();
            ((ISupportInitialize)this.zoomTrackBarControl1.Properties).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)this.spinTransparency.Properties).BeginInit();
            base.SuspendLayout();
            this.zoomTrackBarControl1.EditValue = null;
            this.zoomTrackBarControl1.Location = new Point(25, 34);
            this.zoomTrackBarControl1.Name = "zoomTrackBarControl1";
            this.zoomTrackBarControl1.Properties.BorderStyle = BorderStyles.UltraFlat;
            this.zoomTrackBarControl1.Properties.ExportMode = ExportMode.DisplayText;
            this.zoomTrackBarControl1.Properties.Maximum = 100;
            this.zoomTrackBarControl1.Properties.Minimum = 0;
            this.zoomTrackBarControl1.Properties.ScrollThumbStyle = ScrollThumbStyle.ArrowDownRight;
            this.zoomTrackBarControl1.Properties.ShowValueToolTip = true;
            this.zoomTrackBarControl1.Size = new Size(267, 25);
            this.zoomTrackBarControl1.TabIndex = 0;
            this.zoomTrackBarControl1.EditValueChanged += new EventHandler(this.zoomTrackBarControl1_EditValueChanged);
            this.btnOK.Location = new Point(149, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(87, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(253, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(87, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.zoomTrackBarControl1);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(328, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图层透明度设置";
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.spinTransparency, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Location = new Point(24, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.Size = new Size(200, 27);
            this.tableLayoutPanel1.TabIndex = 4;
            this.labelControl2.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl2.Location = new Point(183, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(12, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "%";
            this.spinTransparency.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            BaseEdit arg_4A0_0 = this.spinTransparency;
            int[] array = new int[4];
            arg_4A0_0.EditValue = new decimal(array);
            this.spinTransparency.Location = new Point(61, 3);
            this.spinTransparency.Name = "spinTransparency";
            this.spinTransparency.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton()
            });
            this.spinTransparency.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.spinTransparency.Properties.IsFloatValue = false;
            this.spinTransparency.Properties.Mask.EditMask = "N00";
            RepositoryItemSpinEdit arg_552_0 = this.spinTransparency.Properties;
            array = new int[4];
            array[0] = 100;
            arg_552_0.MaxValue = new decimal(array);
            this.spinTransparency.Size = new Size(116, 20);
            this.spinTransparency.TabIndex = 4;
            this.spinTransparency.EditValueChanged += new EventHandler(this.spinTransparency_EditValueChanged);
            this.labelControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl1.Location = new Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "透明度值:";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(349, 154);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.HelpButton = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLayerTransparency";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "图层透明度";
            base.HelpButtonClicked += new CancelEventHandler(this.frmLayerTransparency_HelpButtonClicked);
            base.Load += new EventHandler(this.frmLayerTransparency_Load);
            ((ISupportInitialize)this.zoomTrackBarControl1.Properties).EndInit();
            ((ISupportInitialize)this.zoomTrackBarControl1).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)this.spinTransparency.Properties).EndInit();
            base.ResumeLayout(false);
        }

        private ZoomTrackBarControl zoomTrackBarControl1;

        private SimpleButton btnOK;

        private SimpleButton btnCancel;

        private GroupBox groupBox1;

        private LabelControl labelControl2;

        private LabelControl labelControl1;

        private SpinEdit spinTransparency;

        private TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}