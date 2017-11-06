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
using System.Runtime.InteropServices;

namespace GFS.Sample
{
    public partial class frmSampleOverview : DevExpress.XtraEditors.XtraForm
    {
        private   string files = null;
        private DataTable pTable = new DataTable();
        private DataTable CurrentTable = new DataTable();
        public frmSampleOverview(string file)
        {
            InitializeComponent();
            this.files = file;
        }

        private void frmSampleOverview_Load(object sender, EventArgs e)
        {
            IFeatureClass allVillage = EngineAPI.OpenFeatureClass(files);
            ITableConversion conver = new TableConversion();
            this.CurrentTable = conver.AETableToDataTable(allVillage);
            if (allVillage != null)
                Marshal.ReleaseComObject(allVillage);

            for (int i = 0; i < CurrentTable.Columns.Count; i++)
            {
                if (CurrentTable.Columns[i].ColumnName.Contains("调查"))
                {
                    cBEHorizontal.Properties.Items.Add(CurrentTable.Columns[i]);
                    pTable.Columns.Add(new DataColumn(CurrentTable.Columns[i].ColumnName, CurrentTable.Columns[i].DataType));
                }
                if (CurrentTable.Columns[i].ColumnName.Contains("分类"))
                {
                    cBEvertical.Properties.Items.Add(CurrentTable.Columns[i]);
                    pTable.Columns.Add(new DataColumn(CurrentTable.Columns[i].ColumnName, CurrentTable.Columns[i].DataType));
                }
            }
            DataRow dr = null;
            foreach (DataRow row in CurrentTable.Rows)
            {
                dr = pTable.NewRow();
                for (int j = 0; j < pTable.Columns.Count; j++)
                {
                    dr[j] = row[pTable.Columns[j].ColumnName];
                }
                pTable.Rows.Add(dr);
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
            chartControl1.Series.Clear();
            Series Series1 = new Series("样方", ViewType.Point);
            Series1.ArgumentDataMember = pTable.Columns[0].ColumnName;
            Series1.ValueDataMembers[0] = pTable.Columns[1].ColumnName;
            Series1.DataSource = pTable;
            chartControl1.Series.Add(Series1);
        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}