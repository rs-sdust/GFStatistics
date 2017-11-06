// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CtrlPageGridControl.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geometry;
using GFS.Common;
using ESRI.ArcGIS.esriSystem;
//using SDJT.Sys;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GFS.BLL;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class CtrlPageGridControl.
    /// </summary>
    public partial class CtrlPageGridControl : UserControl
    {
        /// <summary>
        /// The _DT
        /// </summary>
        private DataTable _dt;

        /// <summary>
        /// The _p table
        /// </summary>
        private ITable _pTable;

        /// <summary>
        /// The _p query filter
        /// </summary>
        private IQueryFilter _pQueryFilter;

        /// <summary>
        /// The _p ft layer
        /// </summary>
        public IFeatureLayer _pFtLayer;

        /// <summary>
        /// The _map
        /// </summary>
        private IMap _map = null;

        /// <summary>
        /// The _up
        /// </summary>
        private bool _up = true;                     //排序方式

        /// <summary>
        /// The _p ts
        /// </summary>
        ITableSort _pTs;                             //处理排序

        /// <summary>
        /// The _ page count
        /// </summary>
        private int _PageCount = 0;

        /// <summary>
        /// The _ pagesize
        /// </summary>
        private int _Pagesize = 2000;

        /// <summary>
        /// The _ page row
        /// </summary>
        private int _PageRow = 0;

        /// <summary>
        /// The _start index
        /// </summary>
        private int _startIndex;

        /// <summary>
        /// The _end index
        /// </summary>
        private int _endIndex;

        /// <summary>
        /// The _ page index
        /// </summary>
        private int _PageIndex = 1;

        /// <summary>
        /// The _s oid field name
        /// </summary>
        private string _sOIDFieldName = "";

        /// <summary>
        /// The _display trans
        /// </summary>
        private IDisplayTransformation _displayTrans = null;

        /// <summary>
        /// Occurs when [row click].
        /// </summary>
        public event RowClickEventHandler RowClick;
        /// <summary>
        /// Initializes a new instance of the <see cref="CtrlPageGridControl"/> class.
        /// </summary>
        public CtrlPageGridControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the <see cref="E:RowClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RowClickEventArgs"/> instance containing the event data.</param>
        protected void OnRowClick(object sender, RowClickEventArgs e)
        {
            if (this.RowClick != null)
            {
                this.RowClick(sender, e);
            }
        }

        /// <summary>
        /// Handles the RowClick event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowClickEventArgs"/> instance containing the event data.</param>
        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            this.OnRowClick(sender, e);
        }

        /// <summary>
        /// Initializes the specified data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="map">The map.</param>
        public void Initialize(DataTable dataTable, IMap map)
        {
            this._dt = dataTable;
            this._map = map;
            this._displayTrans = (this._map as IActiveView).ScreenDisplay.DisplayTransformation;
            this._PageRow = this._dt.Rows.Count;
            if (this._PageRow % this._Pagesize > 0)
            {
                this._PageCount = this._PageRow / this._Pagesize + 1;
            }
            else
            {
                this._PageCount = this._PageRow / this._Pagesize;
            }
            this.dataNavigator.TextStringFormat = string.Format("第 {0} 页,共 {1} 页",_PageIndex,_PageCount );

            DataTable dataSource = this._dt.AsEnumerable().Take(this._Pagesize).CopyToDataTable<DataRow>();
            this.gridView.Columns.Clear();
            this.gridControl.DataSource = dataSource;
            this.dataNavigator.Buttons.CustomButtons[0].Enabled = false;
            this.dataNavigator.Buttons.CustomButtons[1].Enabled = false;
            if (this._PageCount > 1)
            {
                this.dataNavigator.Buttons.CustomButtons[2].Enabled = true;
                this.dataNavigator.Buttons.CustomButtons[3].Enabled = true;
            }
            else
            {
                this.dataNavigator.Buttons.CustomButtons[2].Enabled = false;
                this.dataNavigator.Buttons.CustomButtons[3].Enabled = false;
            }
        }

        /// <summary>
        /// Initializes the specified p table.
        /// </summary>
        /// <param name="pTable">The p table.</param>
        /// <param name="pQueryFilter">The p query filter.</param>
        /// <param name="map">The map.</param>
        public void Initialize(ITable pTable, IQueryFilter pQueryFilter, IMap map)
        {
            if (pTable != null)
            {
                this._map = map;
                this._displayTrans = (this._map as IActiveView).ScreenDisplay.DisplayTransformation;
                this._sOIDFieldName = pTable.OIDFieldName;
                this._pTable = pTable;
                this._pQueryFilter = pQueryFilter;
                this._dt = this.GetDataTable(pTable, pQueryFilter, this._PageIndex);
                if (this._dt != null)
                {
                    this.gridView.Columns.Clear();
                    this.gridControl.DataSource = _dt;
                }
            }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="pTable">The p table.</param>
        /// <param name="pQueryFilter">The p query filter.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns>DataTable.</returns>
        private DataTable GetDataTable(ITable pTable, IQueryFilter pQueryFilter, int pageIndex)
        {
            ICursor cursor = pTable.Search(pQueryFilter, true);
            IRow row = cursor.NextRow();
            DataTable result;
            if (row == null)
            {
                result = null;
            }
            else
            {
                DataTable dataTable = new DataTable("Temp");
                DataColumn dataColumn=null;
                for (int i = 0; i < row.Fields.FieldCount; i++)
                {
                    IField field = row.Fields.get_Field(i);
                    if (!field.Name.StartsWith("SHAPE", StringComparison.OrdinalIgnoreCase))
                    {
                        dataColumn = dataTable.Columns.Add(row.Fields.get_Field(i).AliasName);
                    }
                }
                while (row != null)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        string columnName = dataTable.Columns[j].ColumnName;
                        int index = row.Fields.FindFieldByAliasName(columnName);
                        dataRow[j] = row.get_Value(index);
                    }
                    dataTable.Rows.Add(dataRow);
                    row = cursor.NextRow();
                }
                if (cursor != null)
                Marshal.ReleaseComObject(cursor);
                result = dataTable;
            }
            return result;
        }


        /// <summary>
        /// Handles the DoubleClick event of the gridControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            //Logger logger = new Logger();

            //DataRow dataRow = this.gridView.GetDataRow(this.gridView.FocusedRowHandle);
            try
            {
                System.Drawing.Point pt = gridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView.CalcHitInfo(pt);

                ILayer pLayer = _pFtLayer as ILayer;
                IFeatureLayer pFeaturelayer = (IFeatureLayer)pLayer;
                IFeatureClass pFeatureClass = pFeaturelayer.FeatureClass;

                if (info.InColumn)
                {
                    string columName = info.Column.FieldName;
                    SortFeatures(pFeatureClass, columName);
                }
                else
                {
                    int index = gridView.FocusedRowHandle;

                    IFields pFields = pFeatureClass.Fields;
                    IField pField = pFields.get_Field(0);
                    IQueryFilter pQueryFilter = new QueryFilterClass();
                    pQueryFilter.WhereClause = pField.Name + "=" + index.ToString();
                    IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    if (pFeature != null)
                    {
                        _map.ClearSelection();
                        (_map as IActiveView).Extent = pFeature.Extent;
                        _map.SelectFeature(pLayer, pFeature);
                        (_map as IActiveView).Refresh();
                        //EngineAPI.FlashGeometry(EnviVars.instance.MapControl, pFeature);
                    }
                }
                //---------------------------------------------------------------
                //int columnIndex = dataRow.Table.Columns.IndexOf(this._sOIDFieldName);
                //int iD = Convert.ToInt32(dataRow[columnIndex]);
                //IFeature feature = this._pFtLayer.FeatureClass.GetFeature(iD);
                //if (feature != null)
                //{
                //    try
                //    {
                //        IGeometry shapeCopy = feature.ShapeCopy;
                //        if (!EngineAPI.IsEqualSpatialReference(shapeCopy.SpatialReference, this._map.SpatialReference))
                //        {
                //            shapeCopy.Project(this._map.SpatialReference);
                //        }
                //        IEnvelope envelope = shapeCopy.Envelope;
                //        if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                //        {
                //            double num = EngineAPI.ConvertUnit(20.0, esriUnits.esriMeters, this._map.MapUnits);
                //            IPoint point = shapeCopy as IPoint;
                //            IPoint point2 = new PointClass();
                //            point2.SpatialReference = point.SpatialReference;
                //            point2.PutCoords(point.X + num, point.Y + num);
                //            IPoint point3 = new PointClass();
                //            point3.SpatialReference = point.SpatialReference;
                //            point3.PutCoords(point.X - num, point.Y - num);
                //            ILine line = new LineClass();
                //            line.SpatialReference = point.SpatialReference;
                //            line.PutCoords(point3, point2);
                //            envelope = line.Envelope;
                //        }
                //        (this._map as IActiveView).Extent = envelope;
                //        (this._map as IActiveView).Refresh();
                //        EngineAPI.FlashGeometry(EnviVars.instance.MapControl, shapeCopy);
                //    }
                //    finally
                //    {
                //        Marshal.ReleaseComObject(feature);
                //    }
                //}

            }
            catch(Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, this.Name, ex);
                Log.WriteLog(typeof(CtrlPageGridControl), ex);
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
            int index=pFields.FindFieldByAliasName(columName);
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
            IFeatureClass pFeatureClass = _pFtLayer.FeatureClass;

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
            this.gridView.Columns.Clear();
            gridControl.DataSource = dt;
        }
    }
}
