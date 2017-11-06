using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using GFS.Commands;
using GFS.Common;
using GFS.BLL;

namespace GFS.Commands.UI
{
    public class ClipUtility
    {
        public string GetFeaClassPath(IFeatureClass featureClass)
        {
            string result;
            if (featureClass == null)
            {
                result = string.Empty;
            }
            else
            {
                IDataset dataset = featureClass as IDataset;
                string path = (dataset.Workspace.Type == esriWorkspaceType.esriFileSystemWorkspace) ? (dataset.Name + ".shp") : dataset.Name;
                string path2 = (featureClass.FeatureDataset == null) ? string.Empty : featureClass.FeatureDataset.Name;
                string path3 = System.IO.Path.Combine(dataset.Workspace.PathName, path2);
                string text = System.IO.Path.Combine(path3, path);
                result = text;
            }
            return result;
        }

        public string CreateShpByROI()
        {
            string empty = string.Empty;
            IGeometryCollection geometryCollection = new PolygonClass();
            object missing = Type.Missing;
            foreach (KeyValuePair<int, ROILayerClass> current in FrmROI.RoiLayerDic)
            {
                foreach (ROIElementClass current2 in current.Value.ElementList)
                {
                    if (current2.Checked)
                    {
                        geometryCollection.AddGeometryCollection(current2.Element.Geometry as IGeometryCollection);
                    }
                }
            }
            if (geometryCollection.GeometryCount > 0)
            {
                IGeometry geometry = geometryCollection as IGeometry;
                geometry.SpatialReference = EnviVars.instance.MapControl.SpatialReference;
                if (geometry != null)
                {
                    if (!ROIManager.instance.GpExecutor.CreateShpFile(geometry, out empty))
                    {
                        empty = string.Empty;
                    }
                }
            }
            return empty;
        }

        public void DeleteShpFile(string shpfilePath)
        {
            if (!string.IsNullOrEmpty(shpfilePath))
            {
                string directoryName = System.IO.Path.GetDirectoryName(shpfilePath);
                string fileName = System.IO.Path.GetFileName(shpfilePath);
                IWorkspace workspace = EngineAPI.OpenWorkspace(directoryName, DataType.shp);
                IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass(fileName);
                if ((featureClass as IDataset).CanDelete())
                {
                    (featureClass as IDataset).Delete();
                }
            }
        }
    }
}
