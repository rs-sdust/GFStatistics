using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.Common;
using GFS.BLL;

namespace GFS.Commands.UI
{
    public class ControlAPI
    {
        public static readonly string CoveragePath = Directory.GetDirectoryRoot(Application.StartupPath) + "temp";

        public static void InitPathComboBox(string sPath, ImageComboBoxEdit cmbPath, DataType type)
        {
            cmbPath.Properties.BeginUpdate();
            try
            {
                cmbPath.Properties.Items.Clear();
                bool flag = false;
                if (type != DataType.sde)
                {
                    ControlAPI.AddItemToComboBox(IconType.Disk, ConstDef.PATH_DESKTOP, "桌面", cmbPath);
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    DriveInfo[] array = drives;
                    for (int i = 0; i < array.Length; i++)
                    {
                        DriveInfo driveInfo = array[i];
                        if (driveInfo.DriveType == DriveType.Fixed || driveInfo.DriveType == DriveType.Removable)
                        {
                            ControlAPI.AddItemToComboBox(IconType.Disk, driveInfo.Name, driveInfo.Name, cmbPath);
                        }
                    }
                }
                if (type == DataType.all || (type & DataType.sde) == DataType.sde)
                {
                    ImageComboBoxItem selectedItem = ControlAPI.AddItemToComboBox(IconType.SdeConnections, "数据库连接", "数据库连接", cmbPath);
                    if (sPath == "数据库连接")
                    {
                        cmbPath.SelectedItem = selectedItem;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(sPath))
                {
                    if (sPath.StartsWith(ConstDef.PATH_DESKTOP))
                    {
                        cmbPath.SelectedIndex = 0;
                    }
                    else
                    {
                        string[] array2 = sPath.Split(new char[]
						{
							'\\'
						});
                        foreach (ImageComboBoxItem imageComboBoxItem in cmbPath.Properties.Items)
                        {
                            if (!(imageComboBoxItem.Description != array2[0] + "\\"))
                            {
                                ImageComboBoxItem imageComboBoxItem2 = imageComboBoxItem;
                                for (int j = 1; j < array2.Length; j++)
                                {
                                    if (!string.IsNullOrEmpty(array2[j]))
                                    {
                                        string text = array2[0];
                                        for (int k = 1; k <= j; k++)
                                        {
                                            text = text + "\\" + array2[k];
                                        }
                                        if (!Directory.Exists(text))
                                        {
                                            cmbPath.SelectedItem = imageComboBoxItem2;
                                            flag = true;
                                            break;
                                        }
                                        int iIndex = cmbPath.Properties.Items.IndexOf(imageComboBoxItem2) + 1;
                                        imageComboBoxItem2 = ControlAPI.InsertItemToComboBox(IconType.Folder, text, array2[j], cmbPath, iIndex);
                                        if (j == array2.Length - 1)
                                        {
                                            cmbPath.SelectedItem = imageComboBoxItem2;
                                            flag = true;
                                            break;
                                        }
                                    }
                                }
                                if (!flag)
                                {
                                    cmbPath.SelectedItem = imageComboBoxItem;
                                    flag = true;
                                }
                                break;
                            }
                        }
                        if (!flag && cmbPath.Properties.Items.Count > 0)
                        {
                            cmbPath.SelectedIndex = 0;
                        }
                    }
                }
            }
            finally
            {
                cmbPath.Properties.EndUpdate();
            }
        }

        public static void OpenFolder(string sPath, ImageListBoxControl imageListBoxControl1, DataType type, List<WorkspaceInfo> pWorkspaceList, esriGeometryType geometryType)
        {
            imageListBoxControl1.BeginUpdate();
            imageListBoxControl1.Items.Clear();
            if (!Directory.Exists(sPath))
            {
                XtraMessageBox.Show("路径不存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                SortedDictionary<string, IconType> sortedDictionary = new SortedDictionary<string, IconType>();
                List<string> list = null;
                if (type == DataType.all || (type & DataType.raster) == DataType.raster)
                {
                    list = ControlAPI.GetRasterNames(sPath, pWorkspaceList);
                }
                DirectoryInfo[] array = directories;
                for (int i = 0; i < array.Length; i++)
                {
                    DirectoryInfo directoryInfo2 = array[i];
                    if ((directoryInfo2.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        if (directoryInfo2.Name.EndsWith(".gdb", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (type == DataType.all || (type & DataType.gdb) == DataType.gdb)
                            {
                                sortedDictionary.Add(directoryInfo2.Name, IconType.FGDB);
                            }
                        }
                        else if (list == null || !list.Contains(directoryInfo2.Name))
                        {
                            ControlAPI.AddItemToListBox(IconType.Folder, directoryInfo2.Name, imageListBoxControl1);
                        }
                    }
                }
                if (type == DataType.all || (type & DataType.mdb) == DataType.mdb)
                {
                    FileInfo[] files = directoryInfo.GetFiles("*.mdb");
                    FileInfo[] array2 = files;
                    for (int i = 0; i < array2.Length; i++)
                    {
                        FileInfo fileInfo = array2[i];
                        sortedDictionary.Add(fileInfo.Name, IconType.PGDB);
                    }
                }
                foreach (KeyValuePair<string, IconType> current in sortedDictionary)
                {
                    ControlAPI.AddItemToListBox(current.Value, current.Key, imageListBoxControl1);
                }
                if (list != null && list.Count > 0)
                {
                    foreach (string current2 in list)
                    {
                        ControlAPI.AddItemToListBox(IconType.RasterDataset, current2, imageListBoxControl1);
                    }
                }
                if (type == DataType.all || (type & DataType.shp) == DataType.shp)
                {
                    ControlAPI.ListShpFiles(sPath, imageListBoxControl1, pWorkspaceList, geometryType);
                }
                if (type == DataType.all || (type & DataType.cad) == DataType.cad)
                {
                    ControlAPI.OpenGeodatabase(sPath, imageListBoxControl1, DataType.cad, pWorkspaceList, geometryType, true, false);
                }
                imageListBoxControl1.EndUpdate();
            }
        }

        public static ImageComboBoxItem AddItemToComboBox(IconType iconType, string sValue, string sDesc, ImageComboBoxEdit cmbPath)
        {
            ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
            imageComboBoxItem.Description = sDesc;
            imageComboBoxItem.ImageIndex = (int)iconType;
            imageComboBoxItem.Value = sValue;
            cmbPath.Properties.Items.Add(imageComboBoxItem);
            return imageComboBoxItem;
        }

        public static ImageComboBoxItem InsertItemToComboBox(IconType iconType, string sValue, string sDesc, ImageComboBoxEdit cmbPath, int iIndex)
        {
            ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
            imageComboBoxItem.Description = sDesc;
            imageComboBoxItem.ImageIndex = (int)iconType;
            imageComboBoxItem.Value = sValue;
            cmbPath.Properties.Items.Insert(iIndex, imageComboBoxItem);
            return imageComboBoxItem;
        }

        public static void InsertItemToComboBox(IconType iconType, string sValue, string sDesc, ImageComboBoxEdit cmbPath)
        {
            for (int i = cmbPath.Properties.Items.Count - 1; i > cmbPath.SelectedIndex; i--)
            {
                ImageComboBoxItem imageComboBoxItem = cmbPath.Properties.Items[i];
                if (imageComboBoxItem.ImageIndex != 2 && imageComboBoxItem.ImageIndex != 33)
                {
                    cmbPath.Properties.Items.RemoveAt(i);
                }
            }
            ImageComboBoxItem selectedItem = ControlAPI.InsertItemToComboBox(iconType, sValue, sDesc, cmbPath, cmbPath.SelectedIndex + 1);
            cmbPath.SelectedItem = selectedItem;
        }

        public static void DrawPathItem(ListBoxDrawItemEventArgs e, ImageList imageList1)
        {
            ImageComboBoxItem imageComboBoxItem = e.Item as ImageComboBoxItem;
            if (imageComboBoxItem != null)
            {
                int num = 0;
                string text = imageComboBoxItem.Value.ToString();
                if (text == ConstDef.PATH_DESKTOP)
                {
                    num = 0;
                }
                else
                {
                    if (text.StartsWith(ConstDef.PATH_DESKTOP))
                    {
                        text = text.Substring(ConstDef.PATH_DESKTOP.Length);
                    }
                    string[] array = text.Split(new char[]
					{
						'\\'
					});
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == imageComboBoxItem.Description)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                SolidBrush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, e.Bounds);
                e.Graphics.DrawImage(imageList1.Images[imageComboBoxItem.ImageIndex], new System.Drawing.Point(e.Bounds.Left + num * 10, e.Bounds.Top));
                string description = imageComboBoxItem.Description;
                int num2 = (e.Bounds.Top + e.Bounds.Bottom) / 2 - 5;
                if (e.State == DrawItemState.Selected)
                {
                    int top = e.Bounds.Top;
                    int x = 25 + num * 10;
                    int height = e.Bounds.Height;
                    int width = (int)e.Graphics.MeasureString(description, e.Appearance.Font).Width;
                    SolidBrush brush2 = new SolidBrush(Color.LightGray);
                    Rectangle rect = new Rectangle(x, top, width, height);
                    e.Graphics.FillRectangle(brush2, rect);
                    e.Graphics.DrawString(description, e.Appearance.Font, SystemBrushes.HighlightText, new PointF((float)(25 + num * 10), (float)num2));
                }
                else
                {
                    e.Graphics.DrawString(description, e.Appearance.Font, new SolidBrush(e.Appearance.ForeColor), new PointF((float)(25 + num * 10), (float)num2));
                }
                e.Handled = true;
            }
        }

        public static void AddItemToListBox(IconType iconType, string sValue, ImageListBoxControl imageListBoxControl1)
        {
            ImageListBoxItem imageListBoxItem = new ImageListBoxItem();
            imageListBoxItem.ImageIndex = (int)iconType;
            imageListBoxItem.Value = sValue;
            imageListBoxControl1.Items.Add(imageListBoxItem);
        }

        public static void SaveCurrentPath(ImageComboBoxEdit cmbPath, string sKey)
        {
            ImageComboBoxItem imageComboBoxItem = cmbPath.SelectedItem as ImageComboBoxItem;
            if (imageComboBoxItem != null)
            {
                string text = imageComboBoxItem.Value.ToString();
                string description = imageComboBoxItem.Description;
                string sPath = text;
                IconType imageIndex = (IconType)imageComboBoxItem.ImageIndex;
                if (imageIndex <= IconType.Coverage)
                {
                    switch (imageIndex)
                    {
                        case IconType.PGDB:
                            break;
                        case IconType.PGDBDataset:
                            goto IL_AB;
                        default:
                            if (imageIndex != IconType.Coverage)
                            {
                                goto IL_DB;
                            }
                            break;
                    }
                }
                else if (imageIndex != IconType.Cad)
                {
                    switch (imageIndex)
                    {
                        case IconType.E00:
                        case IconType.FGDB:
                        case IconType.SDE:
                            break;
                        case IconType.FGDBDataset:
                        case IconType.SDEDataset:
                            goto IL_AB;
                        case IconType.FGDBAnnotation:
                        case IconType.FGDBPoint:
                        case IconType.FGDBLine:
                        case IconType.FGDBPolygon:
                            goto IL_DB;
                        default:
                            goto IL_DB;
                    }
                }
                sPath = text.Substring(0, text.Length - description.Length - 1);
                goto IL_DB;
            IL_AB:
                string text2 = text.Substring(0, text.Length - description.Length - 1);
                int length = text2.LastIndexOf('\\');
                sPath = text2.Substring(0, length);
            IL_DB:
                CommonAPI.SavePathToRegistry(sPath, sKey);
            }
        }

        public static string GetSelectedPath(ImageComboBoxEdit cmbPath)
        {
            ImageComboBoxItem imageComboBoxItem = cmbPath.SelectedItem as ImageComboBoxItem;
            string result;
            if (imageComboBoxItem == null)
            {
                result = null;
            }
            else
            {
                string text = imageComboBoxItem.Value.ToString();
                if (!text.EndsWith("\\"))
                {
                    text += "\\";
                }
                result = text;
            }
            return result;
        }

        public static bool IsExistGDB(string sOutputPath, IEnumerable<string> names, DataType type = DataType.gdb)
        {
            bool flag = false;
            string str = "";
            DirectoryInfo directoryInfo = new DirectoryInfo(sOutputPath);
            if (type == DataType.gdb)
            {
                DirectoryInfo[] directories = directoryInfo.GetDirectories("*.gdb");
                DirectoryInfo[] array = directories;
                for (int i = 0; i < array.Length; i++)
                {
                    DirectoryInfo directoryInfo2 = array[i];
                    ControlAPI.GetSameNames(directoryInfo2.Name, names, ref flag, ref str);
                }
            }
            else if (type == DataType.mdb)
            {
                FileInfo[] files = directoryInfo.GetFiles("*.mdb");
                FileInfo[] array2 = files;
                for (int i = 0; i < array2.Length; i++)
                {
                    FileInfo fileInfo = array2[i];
                    ControlAPI.GetSameNames(fileInfo.Name, names, ref flag, ref str);
                }
            }
            if (flag)
            {
                XtraMessageBox.Show("输出目录中“" + str + "”已经存在！\r\n请重新指定输出目录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return flag;
        }

        private static void GetSameNames(string sFileName, IEnumerable<string> names, ref bool bExist, ref string sMessage)
        {
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sFileName);
            foreach (string current in names)
            {
                string fileNameWithoutExtension2 = System.IO.Path.GetFileNameWithoutExtension(current);
                if (fileNameWithoutExtension2.Equals(fileNameWithoutExtension, StringComparison.CurrentCultureIgnoreCase))
                {
                    bExist = true;
                    if (string.IsNullOrEmpty(sMessage))
                    {
                        sMessage = sFileName;
                    }
                    else
                    {
                        sMessage = sMessage + "，" + sFileName;
                    }
                    break;
                }
            }
        }

        public static void InitDataTypeComboBox(DataType defaultType, DataType type, ComboBoxEdit cmbDataType)
        {
            cmbDataType.Properties.Items.BeginUpdate();
            try
            {
                cmbDataType.Properties.Items.Clear();
                if (type == DataType.all || (type & DataType.shp) == DataType.shp)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("shp文件（*.shp）");
                    if (defaultType == DataType.shp)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.mdb) == DataType.mdb)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("个人地理数据库（*.mdb）");
                    if (defaultType == DataType.mdb)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.gdb) == DataType.gdb)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("文件地理数据库（*.gdb）");
                    if (defaultType == DataType.gdb)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.e00) == DataType.e00)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("交换文件（*.e00）");
                    if (defaultType == DataType.e00)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.coverage) == DataType.coverage)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("coverage文件");
                    if (defaultType == DataType.coverage)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.cad) == DataType.cad)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("cad文件");
                    if (defaultType == DataType.cad)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
                if (type == DataType.all || (type & DataType.raster) == DataType.raster)
                {
                    int selectedIndex = cmbDataType.Properties.Items.Add("栅格数据");
                    if (defaultType == DataType.raster)
                    {
                        cmbDataType.SelectedIndex = selectedIndex;
                    }
                }
            }
            finally
            {
                cmbDataType.Properties.Items.EndUpdate();
            }
        }

        public static Dictionary<string, IFeatureClass> ReadE00Folder(string sPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
            FileInfo[] files = directoryInfo.GetFiles("*.e00");
            Dictionary<string, IFeatureClass> result;
            if (files == null || files.Length == 0)
            {
                result = null;
            }
            else
            {
                string coverageDir = ControlAPI.GetCoverageDir();
                FileInfo[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    FileInfo fileInfo = array[i];
                    EngineAPI.E00ToCoverage(fileInfo.FullName, coverageDir);
                }
                IWorkspace workspace = EngineAPI.OpenWorkspace(coverageDir, DataType.coverage);
                if (workspace == null)
                {
                    result = null;
                }
                else
                {
                    result = ControlAPI.ReadCoverage(workspace);
                }
            }
            return result;
        }

        public static Dictionary<string, IFeatureClass> ReadCoverage(IWorkspace pWorkspace)
        {
            Dictionary<string, IFeatureClass> dictionary = new Dictionary<string, IFeatureClass>();
            try
            {
                IEnumDataset enumDataset = pWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                try
                {
                    enumDataset.Reset();
                    IDataset dataset;
                    while ((dataset = enumDataset.Next()) != null)
                    {
                        string sPrefix = dataset.Name + "_";
                        IEnumDataset subsets = dataset.Subsets;
                        try
                        {
                            subsets.Reset();
                            IDataset dataset2;
                            while ((dataset2 = subsets.Next()) != null)
                            {
                                IFeatureClass featureClass = dataset2 as IFeatureClass;
                                if (featureClass != null)
                                {
                                    string covOrCadFCName = ControlAPI.GetCovOrCadFCName(sPrefix, dataset2.Name);
                                    if (!(covOrCadFCName == ""))
                                    {
                                        dictionary.Add(covOrCadFCName, featureClass);
                                    }
                                }
                            }
                        }
                        finally
                        {
                            if (subsets != null)
                            Marshal.ReleaseComObject(subsets);
                        }
                    }
                }
                finally
                {
                    if (enumDataset != null)
                    Marshal.ReleaseComObject(enumDataset);
                }
            }
            finally
            {
                if (pWorkspace != null)
                Marshal.ReleaseComObject(pWorkspace);
            }
            return dictionary;
        }

        public static string GetCovOrCadFCName(string sPrefix, string sName)
        {
            string result;
            if (string.IsNullOrEmpty(sPrefix))
            {
                result = sName;
            }
            else
            {
                sName = sName.Replace(' ', '_');
                string text = sName.ToLower();
                if (text != null)
                {
                    if (text == "tic" || text == "label" || text == "link")
                    {
                        result = "";
                        return result;
                    }
                }
                int num = sName.LastIndexOf('.');
                if (num >= 0)
                {
                    sName = sName.Substring(num + 1);
                }
                if (!sName.StartsWith(sPrefix))
                {
                    sName = sPrefix + sName;
                }
                result = sName;
            }
            return result;
        }

        public static string GetCoverageDir()
        {
            if (!Directory.Exists(ControlAPI.CoveragePath))
            {
                Directory.CreateDirectory(ControlAPI.CoveragePath);
            }
            string str = DateTime.Now.ToString().Replace(':', '-').Replace('/', '-').Replace(' ', '-');
            string text = ControlAPI.CoveragePath + "\\" + str;
            Directory.CreateDirectory(text);
            return text;
        }

        public static void OpenGeodatabase(string sPath, ImageListBoxControl imageListBoxControl1, DataType type, List<WorkspaceInfo> pWorkspaceList, esriGeometryType geometryType, bool bAppend = false, bool bAddTable = false)
        {
            IWorkspace workspace = ControlAPI.GetWorkspace(sPath, type, pWorkspaceList);
            imageListBoxControl1.BeginUpdate();
            try
            {
                if (!bAppend)
                {
                    imageListBoxControl1.Items.Clear();
                }
                if (workspace != null)
                {
                    ControlAPI.AddFeatureDatasetToListBox(workspace, imageListBoxControl1, type);
                    ControlAPI.AddFeatureClassToListBox(workspace, imageListBoxControl1, type, geometryType);
                    if (bAddTable)
                    {
                        ControlAPI.AddTableToListBox(workspace, imageListBoxControl1);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("无效的数据，加载数据失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                imageListBoxControl1.EndUpdate();
            }
        }

        public static List<string> GetRasterNames(string sPath, List<WorkspaceInfo> pWorkspaceList)
        {
            IWorkspace workspace = ControlAPI.GetWorkspace(sPath, DataType.raster, pWorkspaceList);
            List<string> result;
            if (workspace == null)
            {
                result = null;
            }
            else
            {
                List<string> list = new List<string>();
                IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTRasterDataset);
                try
                {
                    IDatasetName datasetName;
                    while ((datasetName = enumDatasetName.Next()) != null)
                    {
                        list.Add(datasetName.Name);
                    }
                    result = list;
                }
                finally
                {
                    if (enumDatasetName != null)
                    Marshal.ReleaseComObject(enumDatasetName);
                }
            }
            return result;
        }

        public static void ListShpFiles(string sPath, ImageListBoxControl imageListBoxControl1, List<WorkspaceInfo> pWorkspaceList, esriGeometryType geometryType)
        {
            string[] files = Directory.GetFiles(sPath, "*.shp");
            if (files != null && files.Length != 0)
            {
                IWorkspace workspace = ControlAPI.GetWorkspace(sPath, DataType.shp, pWorkspaceList);
                ControlAPI.AddFeatureClassToListBox(workspace, imageListBoxControl1, DataType.shp, geometryType);
            }
        }

        public static void ListE00Files(string sPath, ImageListBoxControl imageListBoxControl1)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
            FileInfo[] files = directoryInfo.GetFiles("*.e00");
            if (files != null && files.Length != 0)
            {
                FileInfo[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    FileInfo fileInfo = array[i];
                    if (!fileInfo.FullName.Contains(' '))
                    {
                        ControlAPI.AddItemToListBox(IconType.E00, fileInfo.Name, imageListBoxControl1);
                    }
                }
            }
        }

        public static void AddTableToListBox(IWorkspace pWorkspace, ImageListBoxControl imageListBoxControl1)
        {
            if (pWorkspace != null)
            {
                IconType iconType = IconType.Table;
                IEnumDatasetName enumDatasetName = pWorkspace.get_DatasetNames(esriDatasetType.esriDTTable);
                try
                {
                    enumDatasetName.Reset();
                    IDatasetName datasetName;
                    while ((datasetName = enumDatasetName.Next()) != null)
                    {
                        ITableName tableName = datasetName as ITableName;
                        if (tableName != null)
                        {
                            ControlAPI.AddItemToListBox(iconType, datasetName.Name, imageListBoxControl1);
                        }
                    }
                }
                finally
                {
                    if (enumDatasetName != null)
                    Marshal.ReleaseComObject(enumDatasetName);
                }
            }
        }

        public static void AddFeatureClassToListBox(IWorkspace pWorkspace, ImageListBoxControl imageListBoxControl1, DataType dataType, esriGeometryType geometryType)
        {
            if (pWorkspace != null)
            {
                IEnumDatasetName pEnumDatasetName = pWorkspace.get_DatasetNames(esriDatasetType.esriDTFeatureClass);
                ControlAPI.AddFeatureClassToListBox(pEnumDatasetName, imageListBoxControl1, dataType, geometryType);
            }
        }

        public static void AddFeatureClassToListBox(IEnumDatasetName pEnumDatasetName, ImageListBoxControl imageListBoxControl1, DataType dataType, esriGeometryType geometryType)
        {
            if (pEnumDatasetName != null)
            {
                IconType value = IconType.PGDBAnnotation;
                IconType value2 = IconType.PGDBPoint;
                IconType value3 = IconType.PGDBLine;
                IconType value4 = IconType.PGDBPolygon;
                if (dataType <= DataType.gdb)
                {
                    if (dataType != DataType.shp)
                    {
                        if (dataType == DataType.gdb)
                        {
                            value = IconType.FGDBAnnotation;
                            value2 = IconType.FGDBPoint;
                            value3 = IconType.FGDBLine;
                            value4 = IconType.FGDBPolygon;
                        }
                    }
                    else
                    {
                        value2 = IconType.ShpPoint;
                        value3 = IconType.ShpLine;
                        value4 = IconType.ShpPolygon;
                    }
                }
                else if (dataType != DataType.sde)
                {
                    if (dataType != DataType.cad)
                    {
                        if (dataType == DataType.coverage)
                        {
                            value = IconType.CovAnnotation;
                            value2 = IconType.CovPoint;
                            value3 = IconType.CovArc;
                            value4 = IconType.CovPolygon;
                        }
                    }
                    else
                    {
                        value = IconType.CadAnnotation;
                        value2 = IconType.CadPoint;
                        value3 = IconType.CadLine;
                        value4 = IconType.CadPolygon;
                    }
                }
                else
                {
                    value = IconType.SDEAnnotation;
                    value2 = IconType.SDEPoint;
                    value3 = IconType.SDELine;
                    value4 = IconType.SDEPolygon;
                }
                SortedDictionary<string, IconType> sortedDictionary = new SortedDictionary<string, IconType>();
                try
                {
                    pEnumDatasetName.Reset();
                    IDatasetName datasetName;
                    while ((datasetName = pEnumDatasetName.Next()) != null)
                    {
                        IFeatureClassName featureClassName = datasetName as IFeatureClassName;
                        if (featureClassName != null)
                        {
                            if (geometryType == esriGeometryType.esriGeometryAny || geometryType == featureClassName.ShapeType)
                            {
                                if (featureClassName.FeatureType == esriFeatureType.esriFTAnnotation || featureClassName.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                                {
                                    sortedDictionary.Add(datasetName.Name, value);
                                }
                                else if (featureClassName.FeatureType == esriFeatureType.esriFTSimple)
                                {
                                    switch (featureClassName.ShapeType)
                                    {
                                        case esriGeometryType.esriGeometryPoint:
                                        case esriGeometryType.esriGeometryMultipoint:
                                            sortedDictionary.Add(datasetName.Name, value2);
                                            break;
                                        case esriGeometryType.esriGeometryPolyline:
                                            sortedDictionary.Add(datasetName.Name, value3);
                                            break;
                                        case esriGeometryType.esriGeometryPolygon:
                                            sortedDictionary.Add(datasetName.Name, value4);
                                            break;
                                        case esriGeometryType.esriGeometryMultiPatch:
                                            sortedDictionary.Add(datasetName.Name, IconType.CadMultiPatch);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (pEnumDatasetName != null)
                    Marshal.ReleaseComObject(pEnumDatasetName);
                }
                foreach (KeyValuePair<string, IconType> current in sortedDictionary)
                {
                    ControlAPI.AddItemToListBox(current.Value, current.Key, imageListBoxControl1);
                }
            }
        }

        public static void AddFeatureDatasetToListBox(IWorkspace pWorkspace, ImageListBoxControl imageListBoxControl1, DataType type)
        {
            if (pWorkspace != null)
            {
                List<string> list = new List<string>();
                IEnumDatasetName enumDatasetName = pWorkspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
                try
                {
                    enumDatasetName.Reset();
                    IDatasetName datasetName;
                    while ((datasetName = enumDatasetName.Next()) != null)
                    {
                        list.Add(datasetName.Name);
                    }
                }
                finally
                {
                    if (enumDatasetName != null)
                    Marshal.ReleaseComObject(enumDatasetName);
                }
                list.Sort();
                IconType iconType = IconType.FGDBDataset;
                if (type <= DataType.sde)
                {
                    if (type != DataType.mdb)
                    {
                        if (type == DataType.sde)
                        {
                            iconType = IconType.SDEDataset;
                        }
                    }
                    else
                    {
                        iconType = IconType.PGDBDataset;
                    }
                }
                else if (type != DataType.cad)
                {
                    if (type == DataType.coverage)
                    {
                        iconType = IconType.Coverage;
                    }
                }
                else
                {
                    iconType = IconType.Cad;
                }
                foreach (string current in list)
                {
                    ControlAPI.AddItemToListBox(iconType, current, imageListBoxControl1);
                }
            }
        }

        public static IWorkspace GetWorkspace(string sFilePath, DataType type, List<WorkspaceInfo> pWorkspaceList)
        {
            IWorkspace workspace = ControlAPI.GetOpenedWorkspace(sFilePath, type, pWorkspaceList);
            if (workspace == null)
            {
                workspace = EngineAPI.OpenWorkspace(sFilePath, type);
                if (workspace != null)
                {
                    ControlAPI.AddWorkspaceInfo(sFilePath, type, workspace, pWorkspaceList);
                }
            }
            return workspace;
        }

        public static IWorkspace GetOpenedWorkspace(string sPath, DataType type, List<WorkspaceInfo> pWorkspaceList)
        {
            IWorkspace result;
            if (pWorkspaceList == null)
            {
                result = null;
            }
            else
            {
                foreach (WorkspaceInfo current in pWorkspaceList)
                {
                    if (current.Path == sPath && current.Type == type)
                    {
                        result = current.Workspace;
                        return result;
                    }
                }
                result = null;
            }
            return result;
        }

        public static void AddWorkspaceInfo(string sPath, DataType type, IWorkspace pWorkspace, List<WorkspaceInfo> pWorkspaceList)
        {
            if (pWorkspace != null && pWorkspaceList != null)
            {
                WorkspaceInfo item = new WorkspaceInfo
                {
                    Workspace = pWorkspace,
                    Type = type,
                    Path = sPath
                };
                pWorkspaceList.Add(item);
            }
        }
    }
}
