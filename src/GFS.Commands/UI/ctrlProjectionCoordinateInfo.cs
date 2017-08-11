using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Geometry;
using GFS.BLL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.Commands.UI
{
    public class ctrlProjectionCoordinateInfo : XtraUserControl
    {
        private IContainer components = null;

        private LabelControl lblCoordSysName;

        private LabelControl labelControl9;

        private LabelControl lblFactor;

        private LabelControl lblCentral;

        private LabelControl lblNorth;

        private LabelControl lblEast;

        private LabelControl lblProjection;

        private LabelControl labelControl1;

        private LabelControl labelControl5;

        private LabelControl labelControl4;

        private LabelControl labelControl3;

        private LabelControl labelControl2;

        private PanelControl panelControl2;

        private ctrlGeographicCoordinateInfo ctrlGeographicCoordinateInfo1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        public ctrlProjectionCoordinateInfo()
        {
            this.InitializeComponent();
        }

        public void Init(ISpatialReference spatialRef)
        {
            this.lblCoordSysName.Text = spatialRef.Name;
            if (spatialRef is IProjectedCoordinateSystem)
            {
                IProjectedCoordinateSystem projectedCoordinateSystem = spatialRef as IProjectedCoordinateSystem;
                this.lblProjection.Text = projectedCoordinateSystem.Projection.Name;
                this.lblCentral.Text = projectedCoordinateSystem.get_CentralMeridian(true).ToString();
                this.lblEast.Text = projectedCoordinateSystem.FalseEasting.ToString();
                this.lblNorth.Text = projectedCoordinateSystem.FalseNorthing.ToString();
                try
                {
                    this.lblFactor.Text = projectedCoordinateSystem.ScaleFactor.ToString();
                }
                catch (Exception var_1_B2)
                {
                    this.lblFactor.Text = "1";
                }
                this.ctrlGeographicCoordinateInfo1.Init(projectedCoordinateSystem.GeographicCoordinateSystem);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCoordSysName = new LabelControl();
            this.labelControl9 = new LabelControl();
            this.lblFactor = new LabelControl();
            this.lblCentral = new LabelControl();
            this.lblNorth = new LabelControl();
            this.lblEast = new LabelControl();
            this.lblProjection = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.panelControl2 = new PanelControl();
            this.ctrlGeographicCoordinateInfo1 = new ctrlGeographicCoordinateInfo();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.lblCoordSysName.Location = new System.Drawing.Point(101, 3);
            this.lblCoordSysName.Name = "lblCoordSysName";
            this.lblCoordSysName.Size = new Size(60, 14);
            this.lblCoordSysName.TabIndex = 45;
            this.lblCoordSysName.Text = "未知坐标系";
            this.labelControl9.Location = new System.Drawing.Point(23, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(72, 14);
            this.labelControl9.TabIndex = 44;
            this.labelControl9.Text = "坐标系名称：";
            this.lblFactor.Location = new System.Drawing.Point(101, 148);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new Size(0, 14);
            this.lblFactor.TabIndex = 32;
            this.lblCentral.Location = new System.Drawing.Point(101, 119);
            this.lblCentral.Name = "lblCentral";
            this.lblCentral.Size = new Size(0, 14);
            this.lblCentral.TabIndex = 31;
            this.lblNorth.Location = new System.Drawing.Point(101, 90);
            this.lblNorth.Name = "lblNorth";
            this.lblNorth.Size = new Size(0, 14);
            this.lblNorth.TabIndex = 30;
            this.lblEast.Location = new System.Drawing.Point(101, 61);
            this.lblEast.Name = "lblEast";
            this.lblEast.Size = new Size(0, 14);
            this.lblEast.TabIndex = 29;
            this.lblProjection.Location = new System.Drawing.Point(101, 32);
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new Size(0, 14);
            this.lblProjection.TabIndex = 28;
            this.labelControl1.Location = new System.Drawing.Point(23, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "投影名称：";
            this.labelControl5.Location = new System.Drawing.Point(23, 148);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 14);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "缩放比例：";
            this.labelControl4.Location = new System.Drawing.Point(23, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "中央经线：";
            this.labelControl3.Location = new System.Drawing.Point(23, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "北偏距离：";
            this.labelControl2.Location = new System.Drawing.Point(23, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "东偏距离：";
            this.panelControl2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.panelControl2.Appearance.BackColor = Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.ctrlGeographicCoordinateInfo1);
            this.panelControl2.Location = new System.Drawing.Point(0, 187);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(503, 190);
            this.panelControl2.TabIndex = 47;
            this.ctrlGeographicCoordinateInfo1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.ctrlGeographicCoordinateInfo1.Appearance.BackColor = Color.Transparent;
            this.ctrlGeographicCoordinateInfo1.Appearance.Options.UseBackColor = true;
            this.ctrlGeographicCoordinateInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlGeographicCoordinateInfo1.Name = "ctrlGeographicCoordinateInfo1";
            this.ctrlGeographicCoordinateInfo1.Size = new Size(503, 190);
            this.ctrlGeographicCoordinateInfo1.TabIndex = 0;
            this.tableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tableLayoutPanel1.Controls.Add(this.lblFactor, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCoordSysName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCentral, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNorth, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEast, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblProjection, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
            this.tableLayoutPanel1.Size = new Size(503, 178);
            this.tableLayoutPanel1.TabIndex = 1;
            base.Appearance.BackColor = Color.Transparent;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Controls.Add(this.panelControl2);
            base.Name = "ctrlProjectionCoordinateInfo";
            base.Size = new Size(503, 377);
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
