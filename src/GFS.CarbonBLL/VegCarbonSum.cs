// ***********************************************************************
// Assembly         : ForestModel
// Author           : YXQ
// Created          : 06-13-2016
//
// Last Modified By : YXQ
// Last Modified On : 07-01-2016
// ***********************************************************************
// <copyright file="ForestCarbon.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SpatialAnalyst;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

/// <summary>
/// The Math namespace.
/// </summary>
namespace GFS.CarbonBLL
{
    /// <summary>
    /// 植被储量计算类
    /// </summary>
    public class VegCarbonSum
    {


        /// <summary>
        /// 生物量文件列表
        /// </summary>
        List<string> biomass = new List<string>();
        /// <summary>
        /// 碳密度文件列表
        /// </summary>
        List<string> density = new List<string>();
        /// <summary>
        /// 碳储量列表
        /// </summary>
        List<double> storage = new List<double>();
        /// <summary>
        /// 输出总生物量
        /// </summary>
        private string sumBiomass = string.Empty;
        /// <summary>
        /// 输出总碳密度
        /// </summary>
        private string sumDensity = string.Empty;
        /// <summary>
        /// 输出总碳储量
        /// </summary>
        private string sumStorage = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="VegCarbonSum"/> class.
        /// </summary>
        /// <param name="biomass">The biomass.</param>
        /// <param name="density">The density.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="sumBiomass">The sum biomass.</param>
        /// <param name="sumDensity">The sum density.</param>
        /// <param name="sumStorage">The sum storage.</param>
        public VegCarbonSum(List<string> biomass,List<string> density, List<double> storage,
             string sumBiomass, string sumDensity, string sumStorage)
        {
            this.sumBiomass = sumBiomass;
            this.sumDensity = sumDensity;
            this.sumStorage = sumStorage;

            this.biomass = biomass;
            this.density = density;
            this.storage = storage;
        }



        /// <summary>
        /// 计算总生物量.
        /// </summary>
        /// <returns>Boolean.</returns>
        public Boolean CalBiomass()
        {
            BandSum sum = new BandSum(biomass, sumBiomass);
            if (sum.Sum())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 计算总碳密度.
        /// </summary>
        /// <returns>Boolean.</returns>
        public Boolean CalDensity()
        {
            BandSum sum = new BandSum(density, sumDensity);
            if (sum.Sum())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 计算总碳储量.
        /// </summary>
        /// <returns>Boolean.</returns>
        public Boolean CalStorage()
        {
            double sum = 0;
            foreach (double num in storage)
            {
                sum += num;
            }
            //TxtOP.WriteTxt(sumStorage, sum);
            DataTable dt = new DataTable();
            dt.Columns.Add("植被碳储量");
            DataRow newRow = dt.NewRow();
            newRow[0] = sum;
            dt.Rows.Add(newRow);
            GFS.BLL.ExcelHelper exclHelper = new GFS.BLL.ExcelHelper();
            exclHelper.DataTableToExcel(sumStorage, "Sheet", dt, true);
            exclHelper.Dispose();
            return true;
        }

    }
}
