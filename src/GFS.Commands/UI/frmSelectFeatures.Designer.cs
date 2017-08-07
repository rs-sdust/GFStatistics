namespace SDJT.Commands.UI
{
    partial class frmSelectFeatures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectFeatures));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.imageComboBoxPath = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnDir = new DevExpress.XtraEditors.SimpleButton();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.imageListFile = new DevExpress.XtraEditors.ImageListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListFile)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.imageComboBoxPath);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.btnDir);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(484, 27);
            this.panelTop.TabIndex = 0;
            // 
            // imageComboBoxPath
            // 
            this.imageComboBoxPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageComboBoxPath.Location = new System.Drawing.Point(48, 2);
            this.imageComboBoxPath.Name = "imageComboBoxPath";
            this.imageComboBoxPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.imageComboBoxPath.Properties.Appearance.Options.UseFont = true;
            this.imageComboBoxPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxPath.Size = new System.Drawing.Size(411, 22);
            this.imageComboBoxPath.TabIndex = 15;
            this.imageComboBoxPath.SelectedIndexChanged += new System.EventHandler(this.imageComboBoxPath_SelectedIndexChanged);
            this.imageComboBoxPath.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.imageComboBoxPath_DrawItem);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBack.Location = new System.Drawing.Point(459, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDir
            // 
            this.btnDir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDir.Location = new System.Drawing.Point(2, 2);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(46, 23);
            this.btnDir.TabIndex = 13;
            this.btnDir.TabStop = false;
            this.btnDir.Text = "目录：";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panel1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 275);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(484, 37);
            this.panelBottom.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(253, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 33);
            this.panel1.TabIndex = 20;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(26, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(131, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imageListFile
            // 
            this.imageListFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageListFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListFile.Location = new System.Drawing.Point(0, 27);
            this.imageListFile.Name = "imageListFile";
            this.imageListFile.Size = new System.Drawing.Size(484, 248);
            this.imageListFile.TabIndex = 2;
            this.imageListFile.Paint += new System.Windows.Forms.PaintEventHandler(this.imageListFile_Paint);
            this.imageListFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageListFile_KeyDown);
            this.imageListFile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.imageListFile_KeyUp);
            this.imageListFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageListFile_MouseDoubleClick);
            this.imageListFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageListFile_MouseDown);
            this.imageListFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageListFile_MouseMove);
            this.imageListFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageListFile_MouseUp);
            // 
            // frmSelectFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.imageListFile);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectFeatures";
            this.ShowIcon = false;
            this.Text = "frmSelectFeatures";
            this.Load += new System.EventHandler(this.frmSelectFeatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.ImageListBoxControl imageListFile;
        private DevExpress.XtraEditors.SimpleButton btnDir;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxPath;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}