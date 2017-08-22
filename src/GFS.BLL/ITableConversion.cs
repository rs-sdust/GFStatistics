// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="ITableConversion.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Convert ITable to DataTable</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;

namespace GFS.BLL
{
    public interface ITableConversion
    {
        DataTable AETableToDataTable(ITable table);
        DataTable AETableToDataTable(IFeatureClass featureClass);
        DataTable AETableToDataTable(ITable table,string[] fieldsName);

        ITable DataTableToAETable(DataTable table, string name);
        ITable DataTableToAETable(DataTable table, string[] fieldName, string name);
        ITable DataTableToAETable(DataTable table, IFeatureWorkspace featureWorkspace, string name);
    }
}
