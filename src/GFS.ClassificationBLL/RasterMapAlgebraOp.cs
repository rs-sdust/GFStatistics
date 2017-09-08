// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="RasterMapAlgebraOp.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>决策树分类的业务逻辑类</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using DevExpress.XtraEditors;
using System.IO;
using GFS.BLL;

namespace GFS.ClassificationBLL
{
    public class RasterMapAlgebraOp
    {
        private DecisionNode root =null;
        private DataTable variable= null;
        public RasterMapAlgebraOp(DecisionNode root, DataTable variable)
        {
            this.root = root;
            this.variable = variable;
        }
        public void Execute(string fileName)
        {
            try
            {
                //组合公式
                string expression = "Con(" + root.expression + "," + root.NodeName + "TRUE," + root.NodeName + "FALSE)";
                ExpCombine(root.lChild, root.rChild, ref expression);

                //绑定文件

                IMapAlgebraOp pRSalgebra = new RasterMapAlgebraOpClass();
                foreach (DataRow row in variable.Rows)
                {
                    pRSalgebra.BindRaster(OpenRasterDataset(row[1].ToString()) as IGeoDataset, row[0].ToString());
                }

                IGeoDataset resDataset = pRSalgebra.Execute(expression);
                ISaveAs pSaveAs = resDataset as ISaveAs;
                FileInfo fInfo = new FileInfo(fileName);
                IWorkspaceFactory pWKSF03 = new RasterWorkspaceFactoryClass();
                IWorkspace pWorkspace03 = pWKSF03.OpenFromFile(fInfo.DirectoryName, 0);
                if (fInfo.Extension == ".img")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "IMAGINE Image");
                }
                if (fInfo.Extension == ".tif")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace03, "TIFF");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        /// <summary>
        /// 将各节点决策条件组合
        /// </summary>
        /// <param name="lNode">The l node.</param>
        /// <param name="rNode">The r node.</param>
        /// <param name="exp">The exp.</param>
        private void ExpCombine(DecisionNode lNode,DecisionNode rNode,ref string exp)
        {
            if (lNode.lChild != null)
            {
                string subExp = "Con(" + lNode.expression + ","
                    + lNode.NodeName + "TRUE," + lNode.NodeName + "FALSE)";
                exp = exp.Replace(lNode.father.NodeName+"FALSE",subExp);

                ExpCombine(lNode.lChild, lNode.rChild,ref exp);
            }
            else
            {
                string subExp = lNode.classValue.ToString();
                exp = exp.Replace(lNode.father.NodeName + "FALSE", subExp);
            }

            if (rNode.lChild != null)
            {
                string subExp = "Con(" + rNode.expression + ","
                                   + rNode.NodeName + "TRUE," + rNode.NodeName + "FALSE)";
                exp = exp.Replace(rNode.father.NodeName + "TRUE", subExp);

                ExpCombine(rNode.lChild, rNode.rChild, ref exp);
            }
            else
            {
                string subExp = rNode.classValue.ToString();
                exp = exp.Replace(rNode.father.NodeName + "TRUE", subExp);
            }

        }
        /// <summary>
        /// 检查决策条件公式
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckExp(DecisionNode node,out string msg)
        {
            msg = "";
            if (node.lChild != null)
            {
                if (string.IsNullOrEmpty(node.expression))
                {
                    msg="节点" + node.Text + "公式为空！";
                    return false;
                }

                CheckExp(node.lChild,out msg);
                CheckExp(node.rChild,out msg);
            }
            return true;
            
        }

        //
        //打开栅格文件指定波段为RasterDataset
        //
        private IRasterDataset OpenRasterDataset(string inFile)
        {
            if (inFile.Contains(":Band_"))
            {
                int strIndex = inFile.LastIndexOf(":Band_");
                string file = inFile.Substring(0, strIndex);
                int bandIndex = int.Parse(inFile.Substring(strIndex + 6, inFile.Length - strIndex - 6));
                return OpenRasterDataset(file, bandIndex);
            }
            else
            {
                return OpenRasterDataset(inFile, -1);
            }
        }
        private IRasterDataset OpenRasterDataset(string inFile,int bandIndex)
        {
            IRasterDataset rasterDataset = null;

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory(); ;
            IRasterWorkspace rasterWorkspace;
            int Index = inFile.LastIndexOf("\\");
            string filePath = inFile.Substring(0, Index);
            string fileName = inFile.Substring(Index + 1);

            try
            {
                rasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
                rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                if (bandIndex > 0)
                {
                    IRasterBandCollection pRasterBandCollection = rasterDataset as IRasterBandCollection;
                    IRasterBand pBand = pRasterBandCollection.Item(bandIndex-1);
                    rasterDataset = pBand as IRasterDataset;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Failed in Opening RasterDataset. " + ex.InnerException.ToString());
                Log.WriteLog(typeof(RasterMapAlgebraOp), ex);
            }

            return rasterDataset;
        }

    }
}
