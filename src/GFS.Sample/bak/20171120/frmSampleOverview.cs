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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace GFS.Sample
{
    public partial class frmSampleOverview : DevExpress.XtraEditors.XtraForm
    {
        public delegate void TransfDelegate(List<object> list1);//委托和事件
        private DataTable CurrentTable = new DataTable();
        private Series Series1 = new Series("样方", ViewType.Point);
        private IFeatureLayer _pFtLayer;
        public frmSampleOverview(DataTable CurTable, IFeatureLayer IFeaLayer)
        {
            InitializeComponent();
            this.CurrentTable = CurTable;
            this._pFtLayer = IFeaLayer;
        }
        private void frmSampleOverview_Load(object sender, EventArgs e)
        {
            updatetable(CurrentTable, _pFtLayer);
        }
        //更新表和图层
        public void updatetable(DataTable pTable, IFeatureLayer IFeaLayer)
        {
            this.CurrentTable = pTable;
            this._pFtLayer = IFeaLayer;
            cBEHorizontal.Properties.Items.Clear();
            cBEvertical.Properties.Items.Clear();
            for (int i = 2; i < CurrentTable.Columns.Count; i++)
            {
                if (CurrentTable.Columns[i].DataType == typeof(double))
                {
                    cBEHorizontal.Properties.Items.Add(CurrentTable.Columns[i]);
                    cBEvertical.Properties.Items.Add(CurrentTable.Columns[i]);
                }
            }
            if (cBEvertical.Properties.Items.Count > 0)
            {
                cBEHorizontal.Text = cBEHorizontal.Properties.Items[0].ToString();
                cBEvertical.Text = cBEvertical.Properties.Items[0].ToString();
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
                UpdateSeries(CurrentTable);

                //Series Series1 = new Series("样方", ViewType.Point);
                //Series1.DataSource = pTable;
                //Series1.ArgumentScaleType = ScaleType.Numerical;
                //Series1.ArgumentDataMember = cBEHorizontal.Text;
                //Series1.ValueDataMembers[0] = cBEvertical.Text;
                chartControl1.Series.Add(Series1);
                Series Series2 = new Series("1:1线", ViewType.Line);
                ((LineSeriesView)Series2.View).LineStyle.DashStyle = DashStyle.Dot;
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                Series2.Points.Add(new SeriesPoint(diagram.AxisX.VisualRange.MinValue, diagram.AxisY.VisualRange.MinValue));
                double X = Convert.ToDouble(diagram.AxisX.VisualRange.MaxValue);
                double Y = Convert.ToDouble(diagram.AxisY.VisualRange.MaxValue);
                if (X >= Y)
                    Series2.Points.Add(new SeriesPoint(diagram.AxisX.VisualRange.MaxValue, diagram.AxisX.VisualRange.MaxValue));
                else
                    Series2.Points.Add(new SeriesPoint(diagram.AxisY.VisualRange.MaxValue, diagram.AxisY.VisualRange.MaxValue));
                chartControl1.Series.Add(Series2);
            }
        }
      //更新Series1
        public void UpdateSeries(DataTable ptable)
        {
            this.CurrentTable = ptable;
            Series1.Points.Dispose();//释放Series
            Series1.Points.Clear();
            Series1.ArgumentScaleType = ScaleType.Numerical;
            Series1.ArgumentDataMember = cBEHorizontal.SelectedItem.ToString();
            Series1.ValueDataMembers[0] = cBEvertical.SelectedItem.ToString();
            for (int i = 0; i < ptable.Rows.Count; i++)
            {
                Series1.Points.Add(new SeriesPoint(((double)ptable.Rows[i][cBEHorizontal.Text] / 666.67), ((double)ptable.Rows[i][cBEvertical.Text] / 666.67)));
            }  
        }
        public event TransfDelegate  TransfEvent;//委托
        private void chartControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<object > list = new List<object >();       
            ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.Location);
            if (hitInfo.SeriesPoint != null)
            {
                double X_value = Math.Round(double.Parse(hitInfo.SeriesPoint.Argument) * 666.67, 3);
                double Y_value = Math.Round(double.Parse((hitInfo.SeriesPoint.Values[0] * 666.67).ToString()), 3);
                for (int i = 0; i < CurrentTable.Rows.Count; i++)
                {
                    double X_temp = Math.Round(Convert.ToDouble(CurrentTable.Rows[i][cBEHorizontal.Text]), 3);
                    double Y_temp = Math.Round(Convert.ToDouble(CurrentTable.Rows[i][cBEvertical.Text]), 3);
                    if ((X_value == X_temp) && (Y_value == Y_temp))
                        list.Add(CurrentTable.Rows[i][0]);
                }

                DataRow[] foundRow = new DataRow[list.Count];
                IFeatureCursor pFeatureCursor = null;
                ILayer pLayer = _pFtLayer as ILayer;
                IFeatureLayer pFeaturelayer = (IFeatureLayer)pLayer;
                IFeatureClass pFeatureClass = pFeaturelayer.FeatureClass;
                IQueryFilter pQueryFilter = new QueryFilterClass();
                IEnvelope pEnv = new EnvelopeClass();
                IMap _map = EnviVars.instance.MapControl.Map;
                _map.ClearSelection();
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        pQueryFilter.WhereClause = "FID" + "=" + list[i].ToString();
                        pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
                        IFeature pFeature = pFeatureCursor.NextFeature();
                        pEnv.Union(pFeature.ShapeCopy.Envelope);
                        IGeometry pgeom = (IGeometry)pFeature.Shape;
                        if (pFeature != null)
                        {
                            //_map = EnviVars.instance.MapControl.Map;
                            //_map.ClearSelection();
                            //(_map as IActiveView).Extent=pFeature.Extent;
                            _map.SelectFeature(pLayer, pFeature);
                            //(_map as IActiveView).Refresh();
                        }
                    }
                    (_map as IActiveView).Extent = pEnv;
                    (_map as IActiveView).Refresh();
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
                    //触发事件
                    TransfEvent(list);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
            }
        }
        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}