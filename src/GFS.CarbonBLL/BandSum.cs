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

/// <summary>
/// The Math namespace.
/// </summary>
namespace GFS.CarbonBLL
{

    /// <summary>
    /// 多影像求和.
    /// </summary>
    public class BandSum
    {
        /// <summary>
        /// 文件列表
        /// </summary>
        private List<string> fileList = null;
        /// <summary>
        /// 输出结果
        /// </summary>
        private string outFile = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BandSum"/> class.
        /// </summary>
        /// <param name="fileList">The file list.</param>
        /// <param name="outFile">The out file.</param>
        public BandSum(List<string> fileList,string outFile)
        {
            this.fileList = fileList;
            this.outFile = outFile;
        }
        /// <summary>
        /// 求和.
        /// </summary>
        /// <returns>Boolean.</returns>
        public Boolean Sum()
        {
            //栅格代数
            string exp = string.Empty;
            IMapAlgebraOp mapAlgebraOp = null;
            IRasterDataset rasterDataset = null;
            IGeoDataset rasout = null;
            ISaveAs2 saveAs = null;

            try
            {
                //读取和绑定栅格
                mapAlgebraOp = new RasterMapAlgebraOpClass();
                //根据文件列表生成计算公式和绑定栅格
                for (int i = 0; i < fileList.Count; i++)
                {
                    string symbol="[ras" + i + "]";
                    rasterDataset = RasterOP.OpenFileRasterDataset(fileList[i]);
                    mapAlgebraOp.BindRaster((IGeoDataset)rasterDataset, symbol.Substring(1,symbol.Length-2));
                    exp= exp + symbol + " + ";
                }
                exp = exp.Substring(0, exp.Length - 3);
                //执行
                rasout = mapAlgebraOp.Execute(exp);

                //删除原有输出文件
                if (File.Exists(outFile))
                {
                    File.Delete(outFile);
                }

                //保存文件
                saveAs = (ISaveAs2)rasout;
                //saveAs.SaveAs(outFile, workspace, "TIFF");
                IDataset o = saveAs.SaveAs(outFile, null, "TIFF");
                if(o!=null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("计算生物量失败！/n" + ex.Message);
                return false;
            }
            finally
            {
                //释放
                if (saveAs != null)
                    Marshal.ReleaseComObject(saveAs);
                if (rasout != null)
                    Marshal.ReleaseComObject(rasout);
                if (rasterDataset != null)
                    Marshal.ReleaseComObject(rasterDataset);
                if (mapAlgebraOp != null)
                    Marshal.ReleaseComObject(mapAlgebraOp);
            }
        }

    }
}
