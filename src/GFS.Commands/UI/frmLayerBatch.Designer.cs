using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SDJT.Commands.UI
{
    partial class frmLayerBatch
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
            this.btnOK = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.ctrlListboxLayers1 = new CtrlListboxLayers();
            base.SuspendLayout();
            this.btnOK.Location = new Point(191, 349);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(284, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.ctrlListboxLayers1.Location = new Point(4, 5);
            this.ctrlListboxLayers1.Name = "ctrlListboxLayers1";
            this.ctrlListboxLayers1.Size = new Size(371, 328);
            this.ctrlListboxLayers1.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(371, 384);
            base.Controls.Add(this.ctrlListboxLayers1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.HelpButton = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmBatchRemoveLayers";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "移除图层";
            base.HelpButtonClicked += new CancelEventHandler(this.frmLayerBatch_HelpButtonClicked);
            base.Load += new EventHandler(this.frmLayerBatch_Load);
            base.ResumeLayout(false);
        }

        private SimpleButton btnOK;

        private SimpleButton btnCancel;

        private CtrlListboxLayers ctrlListboxLayers1;
        #endregion
    }
}