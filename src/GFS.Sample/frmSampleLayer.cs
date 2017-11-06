using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.SampleBLL;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using ESRI.ArcGIS.Carto;
using System.IO;
using GFS.BLL;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Controls;

namespace GFS.Sample
{
    public partial class frmSampleLayer : DevExpress.XtraEditors.XtraForm
    {
        //private IFeatureClass _FeatureClass = null;
        private IFeatureLayer _FeatureLayer = null;
        //private AttrEditCache _AttrCache = null;
        private DataTable _CurrentTable = null;
        private bool _up = true;                     //排序方式
        ITableSort _pTs;                             //处理排序
        private string _curColum = string.Empty;

        private IMapControl3 _pMapControl = null;
        private ITOCControl2 _pTOCControl = null;

        public frmSampleLayer()
        {
            InitializeComponent();
            _pMapControl = EnviVars.instance.MapControl;
            _pTOCControl = EnviVars.instance.TOCControl;
            
        }

        private void SampleLayer_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(SampleData.firstUnit))
            {
                XtraMessageBox.Show("请打开一级抽样单元！");
            }
            else
            {
                OpenAddFile(SampleData.firstUnit);
            }

        }

        private void barBtnOpenShp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "打开文件";
            dialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenAddFile(dialog.FileName);
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barBtnEdit.Down)
            {
                this.gridView1.OptionsBehavior.Editable = true;
                this.gridView1.OptionsBehavior.ReadOnly = false;
                barBtnEdit.Caption = "停止编辑";
            }
            else
            {
                //TODO　是否保存编辑
                DataTable editedRow = _CurrentTable.GetChanges();
                if (editedRow != null)
                {
                    if (DialogResult.OK == XtraMessageBox.Show("确定保存所做修改？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        SaveChanges(editedRow);
                    }
                }

                this.gridView1.OptionsBehavior.Editable = false ;
                this.gridView1.OptionsBehavior.ReadOnly = true;
                barBtnEdit.Caption = "开始编辑";

            }
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataTable editedRow = _CurrentTable.GetChanges();

            if (editedRow != null)
            {
                if (DialogResult.OK == XtraMessageBox.Show("确定保存所做修改？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    SaveChanges(editedRow);
                }
            }
            else
            {
                //XtraMessageBox.Show("未做任何更改！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barBtnAddField_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //save edit
            DataTable editedRow = _CurrentTable.GetChanges();
            if (editedRow != null)
            {
                if (DialogResult.OK == XtraMessageBox.Show("确定保存所做修改？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    SaveChanges(editedRow);
                }
            }
            //add field 
            frmAddField frm = new frmAddField(_FeatureLayer.FeatureClass);
            if (DialogResult.OK == frm.ShowDialog())
            {
                 //refresh view
                ITableConversion conver = new TableConversion();
                _CurrentTable = null;
                _CurrentTable = conver.AETableToDataTable(_FeatureLayer.FeatureClass);
                _CurrentTable.AcceptChanges();
                gridView1.Columns.Clear();
                gridControlTable.DataSource = _CurrentTable;
                //gridControlTable.Refresh();

            }


        }
        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowFindPanel();
        }
        private void barBtnBatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Base.GridCell[] selectedCells = gridView1.GetSelectedCells();
            //if (selectedCells.Length > 0)
            //{
            //    gridView1.ShowFilterEditor(selectedCells[0].Column);
            //}
            //else
            {
                gridView1.ShowFilterEditor(null);
            }

        }

        private void barBtnLayerField_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridColumn col = gridView1.FocusedColumn;
            if (col == null)
            {
                XtraMessageBox.Show("未选中任何列！");
                return;
            }
            if (col.ColumnType == typeof(int))
            {
                SampleData.layerField = col.FieldName;
                XtraMessageBox.Show(string.Format("成功设置字段{0}为分层字段！", col.FieldName));
            }
            else
                XtraMessageBox.Show("分层字段必须为整数！");
        }

        private void barBtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridControlTable_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Point pt = this.gridControlTable.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);

                //ILayer pLayer = _FeatureLayer as ILayer;
                //IFeatureLayer pFeaturelayer = (IFeatureLayer)pLayer;
                IFeatureClass pFeatureClass = _FeatureLayer.FeatureClass;

                if (info.InColumn)
                {
                    //string columName = info.Column.FieldName;
                    //SortFeatures(pFeatureClass, columName);
                }
                else
                {
                    int index = gridView1.FocusedRowHandle;

                    IFields pFields = pFeatureClass.Fields;
                    IField pField = pFields.get_Field(0);
                    IQueryFilter pQueryFilter = new QueryFilterClass();
                    pQueryFilter.WhereClause = pField.Name + "=" + index.ToString();
                    IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    if (pFeature != null)
                    {
                        IMap map = EnviVars.instance.MapControl.Map;
                        map.ClearSelection();
                        (map as IActiveView).Extent = pFeature.Extent;
                        map.SelectFeature(_FeatureLayer, pFeature);
                        (map as IActiveView).Refresh();
                        //EngineAPI.FlashGeometry(EnviVars.instance.MapControl, pFeature);
                    }
                    Marshal.ReleaseComObject(pFeatureCursor);
                }

            }
            catch (Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, this.Name, ex);
                Log.WriteLog(typeof(frmSampleLayer), ex);
            }
        }
        private void gridControlTable_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = this.gridControlTable.PointToClient(Control.MousePosition);
            GridHitInfo info = gridView1.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column.ColumnType == typeof(int))
                {
                    _curColum = info.Column.FieldName;
                    this.popupMenu.ShowPopup(Control.MousePosition);
                }
                else
                    XtraMessageBox.Show("分层字段必须为整型!", "提示信息");
            }
        }
        private void barBtnEditLayer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditSplLayer frm = new frmEditSplLayer(gridView1, _curColum);
            frm.ShowDialog();

        }

        private void frmSampleLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_CurrentTable != null)
                this.barBtnSave.PerformClick();
        }
        private void OpenAddFile(string file)
        {
            try
            {
                _FeatureLayer = null;
                for (int i = 0; i < _pMapControl.LayerCount; i++)
                {
                    ILayer pLayer = _pMapControl.get_Layer(i);
                    if (pLayer is IFeatureLayer)
                    {
                        IFeatureClass pFClass = (pLayer as IFeatureLayer).FeatureClass;
                        string dtSource = Path.Combine((pFClass as IDataset).Workspace.PathName, (pFClass as IDataset).Name + ".shp");
                        if (dtSource == file)
                            _FeatureLayer = pLayer as IFeatureLayer;
                    }
                }
                if (_FeatureLayer == null)
                {
                    IFeatureClass pFClass = EngineAPI.OpenFeatureClass(file);
                    _FeatureLayer = new FeatureLayerClass();
                    _FeatureLayer.FeatureClass = pFClass;
                    FileInfo fInfo = new FileInfo(file);
                    _FeatureLayer.Name = fInfo.Name.Substring(0, fInfo.Name.Length - 4);
                    _pMapControl.AddLayer(_FeatureLayer);
                }

                ITableConversion conver = new TableConversion();
                this._CurrentTable = conver.AETableToDataTable(_FeatureLayer.FeatureClass);
                _CurrentTable.AcceptChanges();
                gridView1.Columns.Clear();
                this.gridControlTable.DataSource = _CurrentTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SaveChanges(DataTable editedRow)
        {
            try
            {
                ITable aeTable = _FeatureLayer.FeatureClass as ITable;
                int fieldCount = aeTable.Fields.FieldCount;
                int fidIndex = aeTable.FindField("FID");

                IRow pRow = null;
                foreach (DataRow iRow in editedRow.Rows)
                {
                    ICursor pCursor = aeTable.Update(null, true);
                    while ((pRow = pCursor.NextRow()) != null)
                    {
                        if (pRow.get_Value(fidIndex).ToString() == iRow[fidIndex].ToString())
                        {
                            for (int i = 2; i < fieldCount; i++)
                            {
                                pRow.set_Value(i, iRow[i]);
                            }
                            pCursor.UpdateRow(pRow);
                        }
                    }
                    if (pCursor != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pCursor);
                }
                _CurrentTable.AcceptChanges();

                XtraMessageBox.Show("保存成功！");
                MapAPI.UniqueValueRender(_FeatureLayer, "分层");
                (_pMapControl.Map as IActiveView).Extent = _FeatureLayer.AreaOfInterest;
                _pMapControl.Refresh();
                _pTOCControl.Update();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 要素排序
        /// </summary>
        /// <param name="pFeatureClass">要排序的要素类</param>
        /// <param name="columName">Name of the colum.</param>
        private void SortFeatures(IFeatureClass pFeatureClass, string columName)
        {
            ITableSort pTableSort = new TableSortClass();
            IFields pFields = pFeatureClass.Fields;
            int index = pFields.FindFieldByAliasName(columName);
            IField pField = pFields.get_Field(index);

            pTableSort.Fields = pField.Name;

            switch (_up)
            {
                case true:
                    pTableSort.set_Ascending(pField.Name, true);
                    _up = false;
                    break;
                case false:
                    pTableSort.set_Ascending(pField.Name, false);
                    _up = true;
                    break;
            }
            pTableSort.set_CaseSensitive(pField.Name, true);
            pTableSort.Table = pFeatureClass as ITable;
            pTableSort.Sort(null);
            ICursor pCursor = pTableSort.Rows;
            _pTs = pTableSort;
            RefreshTable();
        }

        /// <summary>
        /// 刷新属性表
        /// </summary>
        private void RefreshTable()
        {
            IFeatureClass pFeatureClass = _FeatureLayer.FeatureClass;

            if (pFeatureClass == null) return;

            DataTable dt = new DataTable();
            DataColumn dc = null;

            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {

                dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                dt.Columns.Add(dc);

            }

            ICursor pCusor = _pTs.Rows;
            IRow pRow = pCusor.NextRow();
            DataRow dr = null;
            while (pRow != null)
            {
                dr = dt.NewRow();
                for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                {
                    if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                    {

                        dr[j] = pFeatureClass.ShapeType.ToString();
                    }
                    else
                    {
                        dr[j] = pRow.get_Value(j).ToString();

                    }
                }

                dt.Rows.Add(dr);
                pRow = pCusor.NextRow();
            }
            gridControlTable.DataSource = dt;
        }










    }
}