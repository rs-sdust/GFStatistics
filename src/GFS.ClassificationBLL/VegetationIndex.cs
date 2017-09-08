using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ESRI.ArcGIS.Geoprocessor;
//using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.SpatialAnalyst;
//using System.Threading.Tasks;
using ESRI.ArcGIS.GeoAnalyst;
//using GFS.BLL;
using DevExpress.XtraEditors;

namespace GFS.ClassificationBLL
{
    public enum VegIndex
    {
        DVI,
        EVI,
        NDVI,
        RVI,
        SAVI
    }
    public class VegetationIndex
    {
        /// <summary>
        /// Calculates the specified veg index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="inFile">The in file.</param>
        /// <param name="outFile">The out file.</param>
        /// <param name="redIndex">Index of the red.</param>
        /// <param name="nirIndex">Index of the nir.</param>
        /// <param name="blueIndex">Index of the blue.</param>
        /// <param name="land">The land index.</param>
        /// <exception cref="System.Exception">不支持的植被指数</exception>
        public static void Calculate(VegIndex index, string inFile, string outFile, int redIndex, int nirIndex, int blueIndex = -1, float land = -1f)
        {
            IMapAlgebraOp pRSalgebra = null;
            IGeoDataset resDataset = null;
            ISaveAs pSaveAs = null;
            IWorkspaceFactory pWKSF = null;
            IWorkspace pWorkspace = null;
            string expression = string.Empty;
            try
            {
                pRSalgebra = new RasterMapAlgebraOpClass();
                switch (index)
                {
                    case VegIndex.DVI:
                        expression = "[NIR] - [RED]";
                        break;
                    case VegIndex.EVI:
                        expression = "2.5 * (([NIR] - [RED]) / ([NIR] + 6 * [RED] - 7.5 * [BLUE] + 1))";
                        pRSalgebra.BindRaster(GFS.Common.EngineAPI.OpenRasterDataset(inFile, blueIndex) as IGeoDataset, "BLUE");
                        break;
                    case VegIndex.NDVI:
                        expression = "([NIR] - [RED]) / ([NIR] + [RED])";
                        break;
                    case VegIndex.RVI:
                        expression = "[NIR] / [RED]";
                        break;
                    case VegIndex.SAVI:
                        expression = "([NIR] - [RED]) * (1 + " + land + ") / ([NIR] + [RED] + " + land + ")";
                        break;
                    default:
                        throw new Exception("不支持的植被指数");
                }
                pRSalgebra.BindRaster(GFS.Common.EngineAPI.OpenRasterDataset(inFile,redIndex) as IGeoDataset,"RED");
                pRSalgebra.BindRaster(GFS.Common.EngineAPI.OpenRasterDataset(inFile, nirIndex) as IGeoDataset, "NIR");
                resDataset = pRSalgebra.Execute(expression);
                pSaveAs = resDataset as ISaveAs;
                if (File.Exists(outFile))
                {
                    File.Delete(outFile);
                }
                FileInfo fInfo = new FileInfo(outFile);
                pWKSF = new RasterWorkspaceFactoryClass();
                pWorkspace = pWKSF.OpenFromFile(fInfo.DirectoryName, 0);
                if (fInfo.Extension == ".img")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace, "IMAGINE Image");
                }
                if (fInfo.Extension == ".tif")
                {
                    pSaveAs.SaveAs(fInfo.Name, pWorkspace, "TIFF");
                }
            }
            catch (Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(VegetationIndex),ex);
                throw ex;

            }
            finally
            {
                if(pSaveAs != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pSaveAs);
                if (resDataset != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(resDataset);
                if (pRSalgebra != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pRSalgebra);
                if (pWorkspace != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pWorkspace);
                if (pWKSF != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pWKSF);
            }
        }
     }
}

