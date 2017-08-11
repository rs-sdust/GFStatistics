using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using ESRI.ArcGIS.Geometry;
using System.Drawing;

namespace GFS.Commands.UI
{
    public class ctrlGeographicCoordinateInfo : XtraUserControl
    {
        private IContainer components = null;

        private LabelControl lblName;

        private LabelControl labelControl6;

        private LabelControl lblFlattening;

        private LabelControl labelControl23;

        private LabelControl lblMinorAxis;

        private LabelControl labelControl21;

        private LabelControl lblMajorAxis;

        private LabelControl labelControl19;

        private LabelControl lblSpheroid;

        private LabelControl labelControl17;

        private LabelControl lblMeridian;

        private LabelControl labelControl13;

        private LabelControl lblDatum;

        private LabelControl labelControl11;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        public ctrlGeographicCoordinateInfo()
        {
            this.InitializeComponent();
        }

        public void Init(ISpatialReference spatialRef)
        {
            if (spatialRef is IGeographicCoordinateSystem)
            {
                this.lblName.Text = spatialRef.Name;
                IGeographicCoordinateSystem geographicCoordinateSystem = spatialRef as IGeographicCoordinateSystem;
                this.lblMeridian.Text = geographicCoordinateSystem.PrimeMeridian.Name;
                this.lblDatum.Text = geographicCoordinateSystem.Datum.Name;
                this.lblSpheroid.Text = geographicCoordinateSystem.Datum.Spheroid.Name;
                this.lblMajorAxis.Text = geographicCoordinateSystem.Datum.Spheroid.SemiMajorAxis.ToString();
                this.lblMinorAxis.Text = geographicCoordinateSystem.Datum.Spheroid.SemiMinorAxis.ToString();
                this.lblFlattening.Text = geographicCoordinateSystem.Datum.Spheroid.Flattening.ToString();
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
            this.lblName = new LabelControl();
            this.labelControl6 = new LabelControl();
            this.lblFlattening = new LabelControl();
            this.labelControl23 = new LabelControl();
            this.lblMinorAxis = new LabelControl();
            this.labelControl21 = new LabelControl();
            this.lblMajorAxis = new LabelControl();
            this.labelControl19 = new LabelControl();
            this.lblSpheroid = new LabelControl();
            this.labelControl17 = new LabelControl();
            this.lblMeridian = new LabelControl();
            this.labelControl13 = new LabelControl();
            this.lblDatum = new LabelControl();
            this.labelControl11 = new LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.lblName.Location = new System.Drawing.Point(125, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(0, 14);
            this.lblName.TabIndex = 71;
            this.labelControl6.Location = new System.Drawing.Point(23, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(96, 14);
            this.labelControl6.TabIndex = 70;
            this.labelControl6.Text = "地理坐标系名称：";
            this.lblFlattening.Location = new System.Drawing.Point(125, 171);
            this.lblFlattening.Name = "lblFlattening";
            this.lblFlattening.Size = new Size(0, 14);
            this.lblFlattening.TabIndex = 69;
            this.labelControl23.Location = new System.Drawing.Point(23, 171);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new Size(36, 14);
            this.labelControl23.TabIndex = 68;
            this.labelControl23.Text = "扁率：";
            this.lblMinorAxis.Location = new System.Drawing.Point(125, 143);
            this.lblMinorAxis.Name = "lblMinorAxis";
            this.lblMinorAxis.Size = new Size(0, 14);
            this.lblMinorAxis.TabIndex = 67;
            this.labelControl21.Location = new System.Drawing.Point(23, 143);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new Size(48, 14);
            this.labelControl21.TabIndex = 66;
            this.labelControl21.Text = "短半轴：";
            this.lblMajorAxis.Location = new System.Drawing.Point(125, 115);
            this.lblMajorAxis.Name = "lblMajorAxis";
            this.lblMajorAxis.Size = new Size(0, 14);
            this.lblMajorAxis.TabIndex = 65;
            this.labelControl19.Location = new System.Drawing.Point(23, 115);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new Size(48, 14);
            this.labelControl19.TabIndex = 64;
            this.labelControl19.Text = "长半轴：";
            this.lblSpheroid.Location = new System.Drawing.Point(125, 87);
            this.lblSpheroid.Name = "lblSpheroid";
            this.lblSpheroid.Size = new Size(0, 14);
            this.lblSpheroid.TabIndex = 63;
            this.labelControl17.Location = new System.Drawing.Point(23, 87);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new Size(48, 14);
            this.labelControl17.TabIndex = 62;
            this.labelControl17.Text = "椭球体：";
            this.lblMeridian.Location = new System.Drawing.Point(125, 31);
            this.lblMeridian.Name = "lblMeridian";
            this.lblMeridian.Size = new Size(0, 14);
            this.lblMeridian.TabIndex = 61;
            this.labelControl13.Location = new System.Drawing.Point(23, 31);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new Size(72, 14);
            this.labelControl13.TabIndex = 60;
            this.labelControl13.Text = "本初子午线：";
            this.lblDatum.Location = new System.Drawing.Point(125, 59);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new Size(0, 14);
            this.lblDatum.TabIndex = 59;
            this.labelControl11.Location = new System.Drawing.Point(23, 59);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new Size(72, 14);
            this.labelControl11.TabIndex = 58;
            this.labelControl11.Text = "大地基准面：";
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFlattening, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMinorAxis, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl13, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMajorAxis, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl11, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSpheroid, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl23, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDatum, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMeridian, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl17, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl19, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl21, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571f));
            this.tableLayoutPanel1.Size = new Size(503, 197);
            this.tableLayoutPanel1.TabIndex = 72;
            base.Appearance.BackColor = Color.Transparent;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Name = "ctrlGeographicCoordinateInfo";
            base.Size = new Size(503, 197);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
