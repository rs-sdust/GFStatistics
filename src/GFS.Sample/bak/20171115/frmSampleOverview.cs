using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.Sample;
using DevExpress.XtraCharts;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using GFS.BLL;

namespace GFS.Sample
{
    public partial class frmSampleOverview : DevExpress.XtraEditors.XtraForm
    {
        private string files = null;
        private DataTable pTable = new DataTable();
        private DataTable CurrentTable = new DataTable();
        public frmSampleOverview(string file)
        {
            InitializeComponent();
            this.files = file;
        }

        private void frmSampleOverview_Load(object sender, EventArgs e)
        {
            pTable.Clear();
            pTable.Columns.Clear();
            IFeatureClass allVillage = EngineAPI.OpenFeatureClass(files);
            ITableConversion conver = new TableConversion();
            this.CurrentTable = conver.AETableToDataTable(allVillage);
            for (int i = 2; i < CurrentTable.Columns.Count; i++)
            {
                if (CurrentTable.Columns[i].DataType==typeof (double ))
                {
                    cBEHorizontal.Properties.Items.Add(CurrentTable.Columns[i]);
                    cBEvertical.Properties.Items.Add(CurrentTable.Columns[i]);
                    pTable.Columns.Add(new DataColumn(CurrentTable.Columns[i].ColumnName, CurrentTable.Columns[i].DataType));
                }
            }
            DataRow drr = null;
            for (int i = 0; i < CurrentTable.Rows.Count; i++)
            {
                drr = pTable.NewRow();
                for (int j = 0; j < pTable.Columns.Count; j++)
                {
                    //转换成亩
                    drr[j] = double.Parse(CurrentTable.Rows[i][pTable.Columns[j].ColumnName].ToString()) / 666.67;
                }
                pTable.Rows.Add(drr);
            }
        }
        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cBEHorizontal.Text.Trim()) && string.IsNullOrEmpty(cBEvertical.Text.Trim()))
            {
                MessageBox.Show("错误信息：\n纵轴的值：是必需的\n横轴的值：是必需的");
            }
            else
            {
                 chartControl1.Series.Clear();
                if (cBEHorizontal.Text == cBEvertical.Text)
                {
                    MessageBox.Show("错误信息：\n纵轴和横轴的值：是不同的，请重新选择");

                }
                else
                {
                    DataTable dat = new DataTable();
                    dat.Clear();
                    dat.Columns.Clear();
                    dat = pTable.DefaultView.ToTable(false, new string[] { cBEHorizontal.Text, cBEvertical.Text });
                    Series Series1 = new Series("样方", ViewType.Point);
                    Series1.ArgumentDataMember = cBEHorizontal.Text;
                    Series1.ValueDataMembers[0] = cBEvertical.Text;
                    Series1.DataSource = dat;
                    chartControl1.Series.Add(Series1);
                    
                    Series Series2 = new Series("1:1线", ViewType.Line);
                    ((LineSeriesView)Series2.View).LineStyle.DashStyle = DashStyle.Dot;
                    XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                    Series2.Points.Add(new SeriesPoint(diagram.AxisX.VisualRange.MinValue, diagram.AxisY.VisualRange.MinValue));
                    double X = Convert.ToDouble(diagram.AxisX.VisualRange.MaxValue);
                    double Y = Convert.ToDouble(diagram.AxisY.VisualRange.MaxValue);
                    if (X>=Y)
                    {
                        Series2.Points.Add(new SeriesPoint(diagram.AxisX.VisualRange.MaxValue, diagram.AxisX.VisualRange.MaxValue));
                    }
                    else
                        Series2.Points.Add(new SeriesPoint(diagram.AxisY.VisualRange.MaxValue, diagram.AxisY.VisualRange.MaxValue));

                    chartControl1.Series.Add(Series2);
                } 
            }
        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}