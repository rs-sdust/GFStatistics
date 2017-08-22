// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="TableConversion.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Convert ITable to DataTable</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
using ESRI.ArcGIS.DataSourcesFile;

namespace GFS.BLL
{
    public class TableConversion : ITableConversion
    {
        private struct Fiel
        {
            public int dtIndex;
            public string value;
        }

        #region ITableConversion 成员

        public DataTable AETableToDataTable(ITable table)
        {
            DataTable pDataTable = CreateDataTable(table, null);
            FillDataTable(table, esriGeometryType.esriGeometryNull, pDataTable);
            return pDataTable;
        }

        public DataTable AETableToDataTable(ITable table, string[] fieldsName)
        {
            DataTable pDataTable = CreateDataTable(table, fieldsName);
            FillDataTable(table, esriGeometryType.esriGeometryNull, pDataTable);
            return pDataTable;
        }

        public DataTable AETableToDataTable(IFeatureClass featureClass)
        {
            ITable table = featureClass as ITable;
            DataTable pDataTable = CreateDataTable(table, null);
            FillDataTable(table, featureClass.ShapeType, pDataTable);
            return pDataTable;
        }

        public ITable DataTableToAETable(DataTable table, string name)
        {
            IWorkspaceFactory workspaceFactory = new InMemoryWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create("", "MyWorkspace", null, 0);
            IName names = (IName)workspaceName;
            IWorkspace inmemWor = (IWorkspace)names.Open();
            ITable pTable = DataTableToAETable(table, inmemWor as IFeatureWorkspace, name);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(names);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workspaceFactory);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workspaceName);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(inmemWor);
            return pTable;
        }

        public ITable DataTableToAETable(DataTable table, string[] fieldName, string name)
        {
            IWorkspaceFactory workspaceFactory = new InMemoryWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create("", "MyWorkspace", null, 0);
            IName names = (IName)workspaceName;
            IWorkspace inmemWor = (IWorkspace)names.Open();
            return DataTableToAETable(table, inmemWor as IFeatureWorkspace, fieldName, name);
        }

        public ITable DataTableToAETable(DataTable table, IFeatureWorkspace featureWorkspace, string name)
        {
            return DataTableToAETable(table, featureWorkspace, null, name);
        }

        public ITable DataTableToAETable(DataTable table, IFeatureWorkspace featureWorkspace, string[] fieldsName, string name)
        {
            if (table != null && featureWorkspace != null)
            {
                IFields pFileds = new FieldsClass();
                IFieldsEdit pFieldsEdit = (IFieldsEdit)pFileds;

                Dictionary<string, string> fieldLookUp = new Dictionary<string, string>();
                string[] fName = FieldNameCopy(table, fieldsName, fieldLookUp);

                int count = fName.Length;
                if (count > 50)
                {
                    count = 50;
                }

                for (int i = 0; i < count; i++)
                {
                    esriFieldType type = GetAEFieldType(table.Columns[fieldLookUp[fName[i]]]);
                    if (type == esriFieldType.esriFieldTypeGeometry)
                    {
                        continue;
                    }

                    IField pField = new FieldClass();
                    IFieldEdit pFieldEdit = (IFieldEdit)pField;
                    pFieldEdit.Name_2 = fName[i];
                    pFieldEdit.Type_2 = type;
                    //pFieldEdit.Length_2 = 50;

                    pFieldsEdit.AddField(pField);
                }

                ITable pTable = featureWorkspace.CreateTable(name, pFileds, null, null, "");

                try
                {
                    if (count < fName.Length)
                    {
                        for (int i = count; i < fName.Length; i++)
                        {
                            esriFieldType type = GetAEFieldType(table.Columns[i]);

                            if (type == esriFieldType.esriFieldTypeGeometry || fName[i] == "ObjectId" || pFileds.FindField(fName[i]) != -1)
                            {
                                continue;
                            }

                            IField pField = new FieldClass();
                            IFieldEdit pFieldEdit = (IFieldEdit)pField;
                            pFieldEdit.Name_2 = fName[i];
                            pFieldEdit.Type_2 = type;
                            pTable.AddField(pField);
                        }
                    }

                    List<string> fNames = new List<string>();
                    List<int> index = new List<int>();
                    for (int i = 0; i < fName.Length; i++)
                    {
                        int id = pTable.Fields.FindField(fName[i]);
                        if (id != -1)
                        {
                            index.Add(id);
                            fNames.Add(fName[i]);
                        }
                    }
                    fName = fNames.ToArray();

                    ICursor cursor = pTable.Insert(true);
                    //添加内容
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        IRowBuffer rowBuffer = pTable.CreateRowBuffer();
                        DataRow myRow = table.Rows[j];
                        for (int i = 0; i < fName.Length; i++)
                        {
                            string dataTableField = fieldLookUp[fName[i]];
                            object obj = myRow[dataTableField];
                            if (obj.ToString() != "")
                            {
                                rowBuffer.set_Value(index[i], obj);
                            }
                        }
                        cursor.InsertRow(rowBuffer);
                    }

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pFileds);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pFieldsEdit);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureWorkspace);
                    return pTable;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return null;
        }        

        #endregion

        #region 私有方法

        private string[] FieldNameCopy(DataTable table,string[] fieldsName, Dictionary<string, string> fieldLookUp)
        {
            Encoding encoding = Encoding.Default;           

            List<string> fName = new List<string>();
            if (fieldsName == null)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    fName.Add(table.Columns[i].ColumnName);
                }
            }
            else
            {
                for (int i = 0; i < fieldsName.Length; i++)
                {
                    if (table.Columns.Contains(fieldsName[i]) == true)
                    {
                        fName.Add(fieldsName[i]);
                    }
                }
            }

            string[] strs = new string[fName.Count];

            for (int i = 0; i < fName.Count; i++)
            {
                string[] tmp = fName[i].Split(new char[] { '.', ':' });

                if (tmp != null && tmp.Length >= 2)
                {
                    strs[i] = tmp[1];
                }
                else
                {
                    strs[i] = fName[i];
                }

                byte[] buffer = encoding.GetBytes(strs[i]);

                if (buffer.Length > 10)
                {
                    strs[i] = encoding.GetString(buffer, 0, 10);
                }
            }

            List<string> sResult = new List<string>();
            for (int i = 0; i < strs.Length; i++)
            {
                string t = strs[i];

                int k = 1;
                while (sResult.Contains(t) == true)
                {
                    byte[] buffer = encoding.GetBytes(t);
                    if (buffer.Length > 8)
                    {
                        t = encoding.GetString(buffer, 0, 8);
                    }
                    t += "_" + k.ToString();
                    k++;
                }
                sResult.Add(t);
                fieldLookUp.Add(t, fName[i]);
            }
            return sResult.ToArray();
        }

        private esriFieldType GetAEFieldType(DataColumn column)
        {
            esriFieldType type = esriFieldType.esriFieldTypeGeometry;
            if (column.ColumnName == "FID" || column.ColumnName == "Shape")
            {
                return type;
            }

            //判断字段类型
            string dType = column.DataType.ToString().Trim();
            if (dType == "System.String")
                type = esriFieldType.esriFieldTypeString;
            else
                if (dType == "System.Single")
                    type = esriFieldType.esriFieldTypeSingle;
                else
                    if (dType == "System.DateTime")
                        type = esriFieldType.esriFieldTypeDate;
                    else
                        if (dType == "System.Double")
                            type = esriFieldType.esriFieldTypeDouble;
                        else
                            if (dType == "System.Int32" || dType == "System.Int16" || dType == "System.Int64")
                                type = esriFieldType.esriFieldTypeInteger;
                            else
                                if (dType == "System.Decimal")
                                    type = esriFieldType.esriFieldTypeInteger;
            return type;
        }

        private DataTable CreateDataTable(ITable table, string[] fieldsName)
        {
            //创建一个DataTable表
            DataTable pDataTable = new DataTable();
            //取得ITable接口
            IField pField = null;
            DataColumn pDataColumn;

            IFields fields = new FieldsClass();
            if (fieldsName == null)
            {
                fields = table.Fields;
            }
            else
            {
                for (int i = 0; i < fieldsName.Length; i++)
                {
                    int index = table.Fields.FindField(fieldsName[i]);
                    if (index != -1)
                    {
                        IField field = table.Fields.get_Field(index);
                        (fields as IFieldsEdit).AddField(field);
                    }
                }
            }

            //根据每个字段的属性建立DataColumn对象
            for (int i = 0; i < fields.FieldCount; i++)
            {
                pField = fields.get_Field(i);
                //新建一个DataColumn并设置其属性
                pDataColumn = new DataColumn(pField.Name);
                //if (pField.Name == table.OIDFieldName)
                //{
                //    pDataColumn.Unique = true;//字段值是否唯一
                //}
                //字段值是否允许为空
                pDataColumn.AllowDBNull = pField.IsNullable;
                //字段别名
                pDataColumn.Caption = pField.AliasName;
                //字段数据类型
                pDataColumn.DataType = System.Type.GetType(CovertFieldType(pField.Type));
                //字段默认值
                pDataColumn.DefaultValue = pField.DefaultValue;
                //当字段为String类型是设置字段长度
                //if (pField.VarType == 8&&pDataColumn.MaxLength < pField.Length)
                //{
                //    if (pField.Name=="FID_1")
                //    pDataColumn.MaxLength = pField.Length; 
                //}

                //字段添加到表中
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }

            return pDataTable;
        }

        private void FillDataTable(ITable table, esriGeometryType type, DataTable pDataTable)
        {
            try
            {
                List<int> dataTableIndex = new List<int>();
                List<int> fieldIndex = new List<int>();
                for (int i = 0; i < pDataTable.Columns.Count; i++)
                {
                    int index = table.Fields.FindField(pDataTable.Columns[i].ColumnName);
                    if (index != -1)
                    {
                        dataTableIndex.Add(i);
                        fieldIndex.Add(index);
                    }
                }

                //取得图层类型
                string shapeType = GetShapeType(type);
                //创建DataTable的行对象
                DataRow pDataRow = null;
                //从ILayer查询到ITable           
                ICursor pCursor = table.Search(null, false);
                //取得ITable中的行信息
                IRow pRow = pCursor.NextRow();

                List<Fiel> fiel = new List<Fiel>();
                int count = fieldIndex.Count;
                if (pRow != null)
                {
                    for (int i = count - 1; i >= 0; i--)
                    {
                        //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                        int dtIndex = dataTableIndex[i];
                        int index = fieldIndex[i];
                        if (pRow.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            Fiel f = new Fiel();
                            f.dtIndex = dtIndex;
                            f.value = shapeType;
                            fiel.Add(f);
                            fieldIndex.RemoveAt(i);
                            dataTableIndex.RemoveAt(i);
                        }
                        //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                        //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                        else if (pRow.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            Fiel f = new Fiel();
                            f.dtIndex = dtIndex;
                            f.value = "Element";
                            fiel.Add(f);
                            fieldIndex.RemoveAt(i);
                            dataTableIndex.RemoveAt(i);
                        }
                    }
                }

                while (pRow != null)
                {
                    pDataRow = pDataTable.NewRow();
                    for (int i = 0; i < fieldIndex.Count; i++)
                    {
                        pDataRow[dataTableIndex[i]] = pRow.get_Value(fieldIndex[i]);
                    }
                    for (int i = 0; i < fiel.Count; i++)
                    {
                        pDataRow[fiel[i].dtIndex] = fiel[i].value;
                    }

                    pDataTable.Rows.Add(pDataRow);
                    pRow = pCursor.NextRow();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string CovertFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }

        /// <summary>
        /// 获得图层的Shape类型
        /// </summary>
        /// <param name="pLayer">图层</param>
        /// <returns></returns>
        private string GetShapeType(ILayer pLayer)
        {
            IFeatureClass featureClass = (IFeatureClass)pLayer;
            if (featureClass != null)
            {
                return GetShapeType(featureClass.ShapeType);
            }
            return "";
        }

        /// <summary>
        /// 获得图层的Shape类型
        /// </summary>
        /// <param name="pLayer">图层</param>
        /// <returns></returns>
        private string GetShapeType(esriGeometryType shapeType)
        {
            switch (shapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return "";
            }
        }

        #endregion

    }
}