using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using GFS.BLL;
using GFS.Commands.UI;
using ESRI.ArcGIS.Controls;
using System.IO;

namespace GFS.Classification
{
    public  partial class frmPreview : DevExpress.XtraEditors.XtraForm
    {
        private string rasterExtension = ".tif .tiff .img ";
        List<string> dataList = null;
        public  frmPreview(List<string> dataList)
        {
            InitializeComponent();
            this.dataList = dataList;
        }
        private void Look_Load(object sender, EventArgs e)
        {
            this.axMapControl.Dock = DockStyle.Fill;
            AddAllLayers();
        }

        public void AddAllLayers()
        {
            if (dataList == null)
                return;
            foreach (string file in dataList)
            {
                try
                {
                    FileInfo info = new FileInfo(file);
                    if (rasterExtension.Contains(info.Extension.ToLower()))
                    {
                        AddRasterFileToMap(file);
                    }
                    else if (info.Extension.ToLower() == ".shp")
                    {
                        AddShpFileToMap(file);
                    }
                    else
                    {
 
                    }
                }
                catch(Exception)
                {
                    //XtraMessageBox.Show("加载数据失败: " + file , "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    continue;
                }
                finally
                {}
            }
            axMapControl.Extent = this.axMapControl.FullExtent;

        }

        /// <summary>
        /// 加载栅格文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        private  void AddRasterFileToMap(string rasterPath)
        {
            try
            {
                IRasterLayer rasterLayer = new RasterLayerClass();
                string directoryName = System.IO.Path.GetDirectoryName(rasterPath);
                string fileName = System.IO.Path.GetFileName(rasterPath);
                IRasterWorkspace rasterWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.raster) as IRasterWorkspace;
                IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                rasterLayer.CreateFromDataset(rasterDataset);
                IRasterPyramid3 rasterPyramid = rasterDataset as IRasterPyramid3;
                if (rasterPyramid != null && !rasterPyramid.Present)
                {
                    new frmCreatePyramid(new List<string>
					{
						rasterLayer.FilePath
					})
                    {
                        Owner = EnviVars.instance.MainForm
                    }.ShowDialog();
                }
                this.axMapControl.AddLayer(rasterLayer, 0);
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("加载数据失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(frmPreview), ex);
                throw ex;
            }
        }

        /// <summary>
        /// 加载矢量文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        private void AddShpFileToMap(string filePath)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(filePath);
                string path = filePath.Substring(0, filePath.Length - fileinfo.Name.Length);
                string filename = fileinfo.Name;
                this.axMapControl.AddShapeFile(path, filename);
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(frmPreview), ex);
                throw ex;
            }
        }
    }
}