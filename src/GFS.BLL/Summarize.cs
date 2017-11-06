using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GFS.BLL
{
    /// <summary>
    /// 汇总类
    /// </summary>
    public class Summarize
    {
        private DataTable _dataTable;
        private bool _useFilter;
        private string _filter;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">需要进行汇总的数据表</param>
        public Summarize(DataTable dataTable)
        {
            _dataTable = dataTable;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">需要进行汇总的数据表</param>
        /// <param name="useFilter">是否使用过滤器</param>
        /// <param name="filter">过滤器表达式</param>
        public Summarize(DataTable dataTable, bool useFilter, string filter)
        {
            _dataTable = dataTable;
            _useFilter = useFilter;
            _filter = filter;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 需要汇总的数据表
        /// </summary>
        public DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }

        /// <summary>
        /// 是否使用过滤器
        /// </summary>
        public bool UseFilter
        {
            get { return _useFilter; }
            set { _useFilter = value; }
        }

        /// <summary>
        /// 过滤器表达式
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }
        #endregion

        #region 公有方法

        /// <summary>
        /// 计算最小值
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与最小值表</returns>
        public DataTable MiniMum(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Min_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Min(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 计算最大值
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与最大值表</returns>
        public DataTable MaxiMum(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Max_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Max(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 计算平均值
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与平均值表</returns>
        public DataTable Avg(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Avg_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Avg(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 计算总和
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与总和表</returns>
        public DataTable Sum(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Sum_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Sum(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与数量表</returns>
        public DataTable Count(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Count_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Count(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 统计标准偏差
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与标准偏差表</returns>
        public DataTable StDev(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "StDev_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "StDev(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 统计方差
        /// </summary>
        /// <param name="calColumnIndex">需要汇总的列</param>
        /// <param name="referColumnIndex">参考列</param>
        /// <returns>参考列唯一值与方差表</returns>
        public DataTable Var(int calColumnIndex, int referColumnIndex)
        {
            if (!IsInTable(calColumnIndex))
                return null;

            string columnName = "Var_" + _dataTable.Columns[calColumnIndex].ColumnName;
            columnName = GetColumnName(columnName);

            string expression = "Var(" + _dataTable.Columns[calColumnIndex].ColumnName + ")";
            DataTable dataTable = Compute(expression, columnName, referColumnIndex);
            return dataTable;
        }

        /// <summary>
        /// 列类型是否是数字类型
        /// </summary>
        /// <param name="type">列类型</param>
        /// <returns>true，则列是数字类型；反之，则不是</returns>
        public static bool IsNumber(Type type)
        {
            if (type == typeof(byte) || type == typeof(decimal) || type == typeof(double) || type == typeof(Int16) || type == typeof(Int32)
                || type == typeof(Int64) || type == typeof(sbyte) || type == typeof(Single) || type == typeof(UInt16) || type == typeof(UInt32)
                || type == typeof(UInt64))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 得到某一列的唯一值
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private DataTable GetUniqueValue(int columnIndex)
        {
            if (!IsInTable(columnIndex))
                return null;

            DataTable dataTable = _dataTable.Copy();
            DataView view = dataTable.DefaultView;
            if (_useFilter)
                view.RowFilter = _filter;

            DataTable newTable = view.ToTable(true, dataTable.Columns[columnIndex].ColumnName);
            return newTable;
        }

        /// <summary>
        /// 列是否在数据表中
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <returns>true则列在数据表中,false则列不在数据表中</returns>
        private bool IsInTable(int columnIndex)
        {
            if (_dataTable == null || columnIndex < 0 || columnIndex >= _dataTable.Columns.Count)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 避免重复列名
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns>重命名后的列名</returns>
        private string GetColumnName(string columnName)
        {
            if (_dataTable.Columns.Contains(columnName))
            {
                int i = 0;
                while (true)
                {
                    columnName += i.ToString();
                    if (!_dataTable.Columns.Contains(columnName))
                        break;
                    i++;
                }
            }

            return columnName;
        }

        /// <summary>
        /// 根据表达式计算值
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="columnName">列名</param>
        /// <param name="referColumnIndex">用于过滤的列索引</param>
        /// <returns>生成的数据表</returns>
        private DataTable Compute(string expression, string columnName, int referColumnIndex)
        {
            DataTable dataTable = new DataTable();

            if (IsInTable(referColumnIndex))
            {
                DataTable refTable = GetUniqueValue(referColumnIndex);
                bool isNumber = IsNumber(_dataTable.Columns[referColumnIndex].DataType);
                dataTable.Columns.Add(_dataTable.Columns[referColumnIndex].ColumnName, _dataTable.Columns[referColumnIndex].DataType);
                dataTable.Columns.Add(columnName);
                if (refTable != null && refTable.Columns.Count > 0)
                {
                    foreach (DataRow row in refTable.Rows)
                    {
                        if (row[0] != null)
                        {
                            object[] values = new object[2];
                            values[0] = row[0];
                            string filter = "";
                            if (isNumber)
                            {
                                filter = _dataTable.Columns[referColumnIndex].ColumnName + "=" + row[0].ToString();
                            }
                            else
                            {
                                filter = _dataTable.Columns[referColumnIndex].ColumnName + "='" + row[0].ToString() + "'";
                            }

                            if (_useFilter && _filter != null && _filter != "")
                            {
                                filter += " And " + _filter;
                            }
                            values[1] = _dataTable.Compute(expression, filter);

                            dataTable.Rows.Add(values);
                            
                        }
                    }
                }
            }
            else
            {
                dataTable.Columns.Add(columnName, typeof(double));
                string filter = "";
                if (_useFilter)
                {
                    filter += " AND " + _filter;
                }
                object[] value = new object[] { _dataTable.Compute(expression,filter) };
                dataTable.Rows.Add(value);
            }

            return dataTable;
        }
        #endregion
    }
}
