namespace SDJT.Commands.UI
{
    partial class frmLayerTable
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
            this.ctrlPageGridControl1 = new SDJT.Commands.UI.CtrlPageGridControl();
            this.SuspendLayout();
            // 
            // ctrlPageGridControl1
            // 
            this.ctrlPageGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPageGridControl1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPageGridControl1.Name = "ctrlPageGridControl1";
            this.ctrlPageGridControl1.Size = new System.Drawing.Size(584, 462);
            this.ctrlPageGridControl1.TabIndex = 0;
            // 
            // frmLayerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.ctrlPageGridControl1);
            this.Name = "frmLayerTable";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性表 :";
            this.Load += new System.EventHandler(this.frmLayerTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlPageGridControl ctrlPageGridControl1;
    }
}