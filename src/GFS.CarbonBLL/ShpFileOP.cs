using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using System.Windows.Forms;

namespace GFS.CarbonBLL
{
    public class ShpFileOP
    {
        /// <summary>
        /// 打开shp为IFeatureClass
        /// </summary>
        /// <param name="inFile">shp文件名.</param>
        /// <returns>IFeatureClass.</returns>
        public static IFeatureClass OpenFeatureClass(string inFile)
        {
            IFeatureClass pFeatureClass = null;
            try
            {
                //获取当前路径和文件名
                if (inFile != "")
                {
                    IWorkspaceFactory pWorkspaceFactory;
                    IFeatureWorkspace pFeatureWorkspace;
                    int Index = inFile.LastIndexOf("\\");
                    string filePath = inFile.Substring(0, Index);
                    string fileName = inFile.Substring(Index + 1);

                    //打开工作空间
                    pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
                    pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
                    //pFeatureLayer = new FeatureLayerClass();
                    pFeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);
                }
                return pFeatureClass;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开矢量文件失败！/r" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取shp字段列表
        /// </summary>
        /// <param name="inFile">输入shp文件名</param>
        /// <param name="isNum">true：只获取数字字段 false：只获取除数字以外的字段</param>
        /// <param name="fields">字段列表</param>
        public static void GetFields(string inFile, bool isNum, List<string> fields)
        {
            IFeatureClass featureClass = OpenFeatureClass(inFile);
            int nFields = featureClass.Fields.FieldCount;
            if (isNum)
            {
                for (int i = 0; i < nFields; i++)
                {
                    if (featureClass.Fields.get_Field(i).Type.GetHashCode() < 4)
                    {
                        string name = featureClass.Fields.get_Field(i).Name;
                        fields.Add(name);
                    }
                }
            }
            else
            {
                for (int i = 0; i < nFields; i++)
                {
                    if (featureClass.Fields.get_Field(i).Type.GetHashCode() > 3)
                    {
                        string name = featureClass.Fields.get_Field(i).Name;
                        fields.Add(name);
                    }
                }
            }


        }
    }
}
