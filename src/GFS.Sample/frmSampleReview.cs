using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geodatabase;
using GFS.BLL;
using GFS.Common;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Carto;
using System.IO;
using GFS.SampleBLL;

namespace GFS.Sample
{
    public partial class frmSampleReview : DevExpress.XtraEditors.XtraForm
    {
        public frmSampleReview()
        {
            InitializeComponent();
        }

        private int vsRowNum = 0;
        private DataTable sampleSumTable = new DataTable();//总体样本的属性表
        private DataTable selectRows = new DataTable(); //选中行集合
        private List<int> rowsIndex = new List<int>(); //选中行索引
        private int sampleSum = 0;//样本总量
        private int deleted = 0;//已删除
        private int qualified = 0;
        private string filepath = null;
        public IFeatureLayer _pFtLayer;
        //private IMap _map = null;
        private frmSampleOverview Overview;
        private void frmSampleReview_Load(object sender, EventArgs e)
        {
            barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, deleted,qualified);
            
        }
        private void barBtnOpenShp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_pFtLayer != null)
                EnviVars.instance.MapControl.Map.DeleteLayer(_pFtLayer);

            OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = fileDialog.FileName.ToString();
                //sampleSumTable.Clear();//清空表
                //sampleSumTable.Columns.Clear();
                IFeatureClass allVillage = EngineAPI.OpenFeatureClass(filepath);
                ITableConversion conver = new TableConversion();
                this.sampleSumTable = conver.AETableToDataTable(allVillage);
                qualified = sampleSum = sampleSumTable.Rows.Count;//样本量
                if (sampleSumTable.Columns.Contains("shape"))
                {
                    sampleSumTable.Columns.Remove("shape");
                }
                selectRows = sampleSumTable.Clone();
                gridView1.Columns.Clear();
                sampleSumTable.DefaultView.Sort = "FID ASC";
                gridControlTable.DataSource = sampleSumTable;
                gridControlTable.Refresh();
                _pFtLayer = new FeatureLayerClass();
                _pFtLayer.FeatureClass= allVillage;
                FileInfo info = new FileInfo(filepath);
                //string filename = System.IO.Path .GetFileNameWithoutExtension(filepath);
                _pFtLayer.Name = info.Name ;
                //将数据加载到主地图上
                EnviVars.instance.MapControl.AddLayer(_pFtLayer);
                //MAP.AddShpFileToMap(filepath);
                deleted = sampleSum - qualified;
                barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, deleted, qualified);
                if (!(Overview == null || Overview.IsDisposed))
                {
                    Overview.Activate();
                    Overview.updatetable(sampleSumTable, _pFtLayer);
                }
            }
        }
        //选中一行
        private void gridControl1_Click(object sender, EventArgs e)
        {
            object ojb = this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FID");
            vsRowNum = Convert.ToInt32(ojb);
        }
        private void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (string.IsNullOrEmpty(vsRowNum.ToString()))
            {
                MessageBox.Show("错误信息：\n必须选中一行");
            }
            else
            {
               int[] Rows= gridView1.GetSelectedRows();
               for (int i = 0; i < Rows.Length ; i++)
                {
                    selectRows.ImportRow(sampleSumTable.Rows[Rows[i]]);
                }
                SampleAduit Aduit=new SampleAduit ();
               for (int j = 0; j < Rows.Length; j++)
               {
                   Aduit.RemoveRow(sampleSumTable, selectRows.Rows[selectRows.Rows .Count -1-j][0]);
                }

                barBtnUndo.Enabled = true;
                rowsIndex.Clear();

                deleted = deleted + Rows.Length;
                qualified = sampleSum - deleted;
                barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, deleted, qualified);
                if (!(Overview == null || Overview.IsDisposed))
                {
                    Overview.Activate();
                    Overview.UpdateSeries(sampleSumTable);
                }
            }

        }
        
        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (filepath == null)
            {
                MessageBox.Show("错误信息：\n样本调查数据的值：是必需的");
            }
            else
            {
                //if (selectRows.Rows.Count == 0)
                //{
                //    //加载地图
                //    EnviVars.instance.MapControl.AddLayer(_pFtLayer);
                //    //MAP.AddShpFileToMap(filepath);
                //}
                //else
                if(DialogResult.OK == XtraMessageBox.Show("是否保存？保存后无法撤销修改！","提示信息",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
                {
                    string queryStr = string.Empty;
                    for (int i = 0; i < selectRows.Rows.Count; i++)
                    {
                        queryStr = queryStr + "FID" + " = " + selectRows.Rows[i][0] + " OR ";

                    }
                    queryStr = queryStr.Substring(0, queryStr.Length - 4);
                    SampleAduit aduit = new SampleAduit();
                    if (aduit.DeleFeature(_pFtLayer.FeatureClass, queryStr))
                    {
                        XtraMessageBox.Show("保存成功！");
                        selectRows.Rows.Clear();
                        rowsIndex.Clear();

                        EnviVars.instance.MapControl.Refresh();

                        ITableConversion conver = new TableConversion();
                        this.sampleSumTable = conver.AETableToDataTable(_pFtLayer.FeatureClass);
                        if (sampleSumTable.Columns.Contains("shape"))
                        {
                            sampleSumTable.Columns.Remove("shape");
                        }
                        gridView1.Columns.Clear();
                        sampleSumTable.DefaultView.Sort = "FID ASC";
                        gridControlTable.DataSource = sampleSumTable;
                        gridControlTable.Refresh();

                    }

                }
            }
        }
        private void barBtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChkDoEnable();

            if (!barBtnUndo.Enabled)
                return;

            DataRow row = sampleSumTable .NewRow();
            row.ItemArray = selectRows.Rows[selectRows.Rows.Count - 1].ItemArray;

            int[] num = sampleSumTable.AsEnumerable().Select(d => d.Field<int>("FID")).ToArray();
            int firstNum = num.AsEnumerable().First(N => N > Convert.ToInt32(selectRows.Rows[selectRows.Rows.Count - 1][0]));

            DataColumn[] dcs = { sampleSumTable.Columns["FID"] };
            sampleSumTable.PrimaryKey = dcs;
            DataRow dr = sampleSumTable.Rows.Find(firstNum);
            int samIndex = sampleSumTable.Rows.IndexOf(dr);
            sampleSumTable.Rows.InsertAt(row, samIndex);
            //sampleSumTable. ImportRow(selectRows.Rows[selectRows.Rows.Count - 1]);
            rowsIndex.Add(Convert.ToInt32(selectRows.Rows[selectRows.Rows.Count - 1][0]));
            selectRows.Rows.RemoveAt(selectRows.Rows.Count - 1);
            gridControlTable.RefreshDataSource();
            barBtnRedo.Enabled = true;
            deleted--;
            qualified = sampleSum - deleted;
            barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, deleted, qualified);
            if (!(Overview == null || Overview.IsDisposed))
            {
                Overview.Activate();
                Overview.UpdateSeries(sampleSumTable);
            }
            ChkDoEnable();
        }

        private void barBtnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ChkDoEnable();
            if (!barBtnRedo.Enabled)
                return;

            //for (int j = 0; j < rowsIndex.Count; j++)
            //{
                
            //    SampleAduit Aduit = new SampleAduit();
               
            //    //sampleSumTable.Rows.Remove(sampleSumTable.Rows[j]);
            //    string foundKey = sampleSumTable.Columns[0].ColumnName + "=" + rowsIndex[rowsIndex.Count - 1 - j];
            //    DataRow[] foundRow = sampleSumTable.Select(foundKey);
            //    foreach (DataRow row in foundRow)
            //    {
            //        selectRows.ImportRow(row);
            //    }
            //    Aduit.RemoveRow(sampleSumTable, rowsIndex[rowsIndex.Count - 1 - j]);
            //    rowsIndex.RemoveAt(rowsIndex.Count - 1-j);
            //}
            SampleAduit Aduit = new SampleAduit();
            string queryStr = "FID = "  + rowsIndex[rowsIndex.Count-1];
            DataRow[] foundRow = sampleSumTable.Select(queryStr);
            if (foundRow.Length > 0)
            {
                selectRows.ImportRow(foundRow[0]);
                Aduit.RemoveRow(sampleSumTable, rowsIndex[rowsIndex.Count - 1]);
                rowsIndex.RemoveAt(rowsIndex.Count - 1);
                deleted++;
                qualified = sampleSum - deleted;
                barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, deleted, qualified);
            }
            if (!(Overview == null || Overview.IsDisposed))
            {
                Overview.Activate();
                Overview.UpdateSeries(sampleSumTable);
            }
            ChkDoEnable();
           
        }
       
        private void barBtnChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (filepath == null)
            {
                MessageBox.Show("未输入文件！");
                return;
            }
            else
            {
                if (Overview == null || Overview.IsDisposed)
                {
                    Overview = new frmSampleOverview(sampleSumTable, _pFtLayer);
                    Overview.Owner = this;
                    Overview.Show();
                }
                else
                {
                    Overview.Activate();
                }    
                //注册事件
                Overview.TransfEvent += Overview_TransfEvent;
            }
        }
        //事件处理方法
       public  void Overview_TransfEvent(List <object> list)
        {
            gridView1.ClearSelection();
            for(int i=0;i<list.Count ;i++)
            {
               DataRow[] foundRow = new DataRow[sampleSumTable.Rows.Count ];
               var SelectRows = sampleSumTable.Columns[0].ColumnName + " = "+list[i];
               foundRow = sampleSumTable.Select(SelectRows);
               foreach (DataRow row in foundRow)
                {
                    gridView1.FocusedRowHandle = sampleSumTable.Rows.IndexOf(row);
                    gridView1.SelectRow(sampleSumTable.Rows.IndexOf(row));
                }
            }
        }

        private void gridControlTable_DoubleClick(object sender, EventArgs e)
        {
            object ojb = this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FID");
            int index = Convert .ToInt32 (ojb);

            ILayer pLayer = _pFtLayer as ILayer;
            IFeatureLayer pFeaturelayer = (IFeatureLayer)pLayer;
            IFeatureClass pFeatureClass = pFeaturelayer.FeatureClass;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = "FID" + "=" + index.ToString();
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
            {
                IMap _map = EnviVars.instance.MapControl.Map;
                _map.ClearSelection();
                (_map as IActiveView).Extent = pFeature.Extent;
                _map.SelectFeature(pLayer, pFeature);
                (_map as IActiveView).Refresh();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
           barStatic.Caption = string.Format("样本总数：{0}  已删样本数 {1} 合格样本数 {2}", sampleSum, selectRows.Rows.Count, sampleSum - selectRows.Rows.Count);
        }
        private void ChkDoEnable()
        {
            if (rowsIndex.Count == 0)  
                barBtnRedo.Enabled = false;
            else
                barBtnRedo.Enabled = true;

            if (selectRows.Rows.Count == 0)
                barBtnUndo.Enabled = false;
            else
                barBtnUndo.Enabled = true;
        }

        private void frmSampleReview_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }
    }
}