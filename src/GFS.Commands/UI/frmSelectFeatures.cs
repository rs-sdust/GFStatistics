using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.Common;
using GFS.BLL;

namespace GFS.Commands.UI
{
    public class frmSelectFeatures : frmBase
    {
        private IContainer components = null;

        private LabelControl labelControl1;

        private ImageComboBoxEdit cmbPath;

        private SimpleButton btnUp;

        private ImageListBoxControl imageListBoxControl1;

        private SimpleButton btnOK;

        private SimpleButton btnClose;

        private TableLayoutPanel tableLayoutPanel1;

        private List<WorkspaceInfo> m_pWorkspaceList = new List<WorkspaceInfo>();

        private System.Drawing.Point m_pStartPoint = System.Drawing.Point.Empty;

        private Rectangle m_pRect = Rectangle.Empty;

        private bool m_bPressedShiftKey = false;

        private bool m_bPressedCtrlKey = false;

        private static string MSG_ERROR01 = "存在已损坏图层！读取失败！";

        private static string MSG_ERROR02 = "图层已损坏！读取失败！";

        private static string MSG_CONST01 = "添加SDE连接";

        public List<IFeatureClass> SelectedFeatures
        {
            get
            {
                List<IFeatureClass> list = new List<IFeatureClass>();
                list.AddRange(this.FeaturesDict.Values);
                return list;
            }
        }

        public SortedDictionary<string, IFeatureClass> FeaturesDict
        {
            get;
            private set;
        }

        public List<IRasterDataset> RasterList
        {
            get;
            private set;
        }

        public Dictionary<string, IRasterDataset> RasterDict
        {
            get;
            private set;
        }

        public bool HasTables
        {
            get;
            private set;
        }

        public bool IsMultiSelect
        {
            get;
            set;
        }

        public esriGeometryType GeometryType
        {
            get;
            set;
        }

        public DataType DataType
        {
            get;
            set;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectFeatures));
            this.labelControl1 = new LabelControl();
            this.cmbPath = new ImageComboBoxEdit();
            this.btnUp = new SimpleButton();
            this.imageListBoxControl1 = new ImageListBoxControl();
            this.btnOK = new SimpleButton();
            this.btnClose = new SimpleButton();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            ((ISupportInitialize)this.cmbPath.Properties).BeginInit();
            ((ISupportInitialize)this.imageListBoxControl1).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.labelControl1.Anchor = AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "查找范围：";
            this.cmbPath.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            this.cmbPath.Location = new System.Drawing.Point(69, 6);
            this.cmbPath.Name = "cmbPath";
            this.cmbPath.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.cmbPath.Size = new Size(266, 20);
            this.cmbPath.TabIndex = 1;
            this.cmbPath.SelectedIndexChanged += new EventHandler(this.cmbPath_SelectedIndexChanged);
            this.cmbPath.DrawItem += new ListBoxDrawItemEventHandler(this.cmbPath_DrawItem);
            this.btnUp.Anchor = AnchorStyles.Left;
            this.btnUp.Image = (Image)componentResourceManager.GetObject("btnUp.Image");
            this.btnUp.Location = new System.Drawing.Point(341, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new Size(24, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.Click += new EventHandler(this.btnUp_Click);
            this.imageListBoxControl1.Location = new System.Drawing.Point(3, 48);
            this.imageListBoxControl1.MultiColumn = true;
            this.imageListBoxControl1.Name = "imageListBoxControl1";
            this.imageListBoxControl1.SelectionMode = SelectionMode.MultiExtended;
            this.imageListBoxControl1.Size = new Size(446, 269);
            this.imageListBoxControl1.TabIndex = 3;
            this.imageListBoxControl1.Paint += new PaintEventHandler(this.imageListBoxControl1_Paint);
            this.imageListBoxControl1.KeyDown += new KeyEventHandler(this.imageListBoxControl1_KeyDown);
            this.imageListBoxControl1.KeyUp += new KeyEventHandler(this.imageListBoxControl1_KeyUp);
            this.imageListBoxControl1.MouseDoubleClick += new MouseEventHandler(this.imageListBoxControl1_MouseDoubleClick);
            this.imageListBoxControl1.MouseDown += new MouseEventHandler(this.imageListBoxControl1_MouseDown);
            this.imageListBoxControl1.MouseMove += new MouseEventHandler(this.imageListBoxControl1_MouseMove);
            this.imageListBoxControl1.MouseUp += new MouseEventHandler(this.imageListBoxControl1_MouseUp);
            this.btnOK.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.btnOK.Location = new System.Drawing.Point(270, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(362, 325);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "取消";
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUp, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
            this.tableLayoutPanel1.Size = new Size(368, 32);
            this.tableLayoutPanel1.TabIndex = 6;
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(449, 355);
            base.Controls.Add(this.tableLayoutPanel1);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.imageListBoxControl1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSelectFeatures";
            this.Text = "选择要素";
            base.Load += new EventHandler(this.frmSelectFeatures_Load);
            ((ISupportInitialize)this.cmbPath.Properties).EndInit();
            ((ISupportInitialize)this.imageListBoxControl1).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }

        public frmSelectFeatures()
        {
            this.InitializeComponent();
            this.IsMultiSelect = true;
            this.GeometryType = esriGeometryType.esriGeometryAny;
            this.DataType = (DataType)47;
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
        }

        private void frmSelectFeatures_Load(object sender, EventArgs e)
        {
            this.FeaturesDict = new SortedDictionary<string, IFeatureClass>();
            this.RasterList = new List<IRasterDataset>();
            this.RasterDict = new Dictionary<string, IRasterDataset>();
            this.imageListBoxControl1.ImageList = base.DataImageList;
            this.cmbPath.Properties.SmallImages = base.DataImageList;
            this.imageListBoxControl1.SelectionMode = (this.IsMultiSelect ? SelectionMode.MultiExtended : SelectionMode.One);
            string pathFromRegistry = CommonAPI.GetPathFromRegistry(CommonAPI.KEY_FEATURE_PATH);
            ControlAPI.InitPathComboBox(pathFromRegistry, this.cmbPath, this.DataType);
        }

        private void cmbPath_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            ControlAPI.DrawPathItem(e, base.DataImageList);
        }

        private void cmbPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnUp.Enabled = false;
            ImageComboBoxItem imageComboBoxItem = this.cmbPath.SelectedItem as ImageComboBoxItem;
            if (imageComboBoxItem != null)
            {
                if (imageComboBoxItem.ImageIndex != 2 && imageComboBoxItem.ImageIndex != 33)
                {
                    this.btnUp.Enabled = true;
                }
                string sPath = imageComboBoxItem.Value.ToString();
                IconType imageIndex = (IconType)imageComboBoxItem.ImageIndex;
                if (imageIndex <= IconType.Cad)
                {
                    switch (imageIndex)
                    {
                        case IconType.Disk:
                        case IconType.Folder:
                            ControlAPI.OpenFolder(sPath, this.imageListBoxControl1, this.DataType, this.m_pWorkspaceList, this.GeometryType);
                            break;
                        case IconType.ShpPoint:
                        case IconType.ShpLine:
                        case IconType.ShpPolygon:
                            break;
                        case IconType.PGDB:
                            ControlAPI.OpenGeodatabase(sPath, this.imageListBoxControl1, DataType.mdb, this.m_pWorkspaceList, this.GeometryType, false, this.HasTables);
                            break;
                        case IconType.PGDBDataset:
                            this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.mdb, this.GeometryType);
                            break;
                        default:
                            if (imageIndex != IconType.Coverage)
                            {
                                if (imageIndex == IconType.Cad)
                                {
                                    this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.cad, this.GeometryType);
                                }
                            }
                            else
                            {
                                this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.coverage, this.GeometryType);
                            }
                            break;
                    }
                }
                else if (imageIndex != IconType.SdeConnections)
                {
                    switch (imageIndex)
                    {
                        case IconType.FGDB:
                            ControlAPI.OpenGeodatabase(sPath, this.imageListBoxControl1, DataType.gdb, this.m_pWorkspaceList, this.GeometryType, false, this.HasTables);
                            break;
                        case IconType.FGDBDataset:
                            this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.gdb, this.GeometryType);
                            break;
                        default:
                            switch (imageIndex)
                            {
                                case IconType.SDE:
                                    ControlAPI.OpenGeodatabase(sPath, this.imageListBoxControl1, DataType.sde, this.m_pWorkspaceList, this.GeometryType, false, this.HasTables);
                                    break;
                                case IconType.SDEDataset:
                                    this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.sde, this.GeometryType);
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    this.GetSDEConnInfo();
                }
                this.ClearImageListSelectedItems();
            }
        }

        private void imageListBoxControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int num = this.imageListBoxControl1.IndexFromPoint(e.Location);
                if (num >= 0)
                {
                    string selectedPath = ControlAPI.GetSelectedPath(this.cmbPath);
                    if (selectedPath != null)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            string itemText = this.imageListBoxControl1.GetItemText(num);
                            string text = selectedPath + itemText;
                            switch (this.imageListBoxControl1.GetItemImageIndex(num))
                            {
                                case 3:
                                    ControlAPI.InsertItemToComboBox(IconType.Folder, text, itemText, this.cmbPath);
                                    break;
                                case 4:
                                case 5:
                                case 6:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.shp);
                                    break;
                                case 7:
                                    ControlAPI.InsertItemToComboBox(IconType.PGDB, text, itemText, this.cmbPath);
                                    break;
                                case 8:
                                    ControlAPI.InsertItemToComboBox(IconType.PGDBDataset, text, itemText, this.cmbPath);
                                    break;
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.mdb);
                                    break;
                                case 17:
                                    ControlAPI.InsertItemToComboBox(IconType.Coverage, text, itemText, this.cmbPath);
                                    break;
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.coverage);
                                    break;
                                case 24:
                                    ControlAPI.InsertItemToComboBox(IconType.Cad, text, itemText, this.cmbPath);
                                    break;
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.cad);
                                    break;
                                case 31:
                                    this.OpenRasterDataset(selectedPath, itemText);
                                    break;
                                case 34:
                                    this.AddSDEConn(selectedPath);
                                    break;
                                case 35:
                                    this.OpenSDEConn(itemText, text);
                                    break;
                                case 36:
                                    {
                                        string coverageDir = ControlAPI.GetCoverageDir();
                                        if (EngineAPI.E00ToCoverage(text, coverageDir))
                                        {
                                            string sName = System.IO.Path.GetFileNameWithoutExtension(text).ToLower();
                                            this.GetDatasetFeatures(coverageDir, sName, DataType.coverage);
                                            if (this.FeaturesDict != null && this.FeaturesDict.Count > 0)
                                            {
                                                base.DialogResult = DialogResult.OK;
                                            }
                                        }
                                        break;
                                    }
                                case 37:
                                    ControlAPI.InsertItemToComboBox(IconType.FGDB, text, itemText, this.cmbPath);
                                    break;
                                case 38:
                                    ControlAPI.InsertItemToComboBox(IconType.FGDBDataset, text, itemText, this.cmbPath);
                                    break;
                                case 39:
                                case 40:
                                case 41:
                                case 42:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.gdb);
                                    break;
                                case 44:
                                    ControlAPI.InsertItemToComboBox(IconType.SDEDataset, text, itemText, this.cmbPath);
                                    break;
                                case 45:
                                case 46:
                                case 47:
                                case 48:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.sde);
                                    break;
                            }
                        }
                        finally
                        {
                            System.Windows.Forms.Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void imageListBoxControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                this.m_bPressedShiftKey = true;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                this.m_bPressedCtrlKey = true;
            }
        }

        private void imageListBoxControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                this.m_bPressedShiftKey = false;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                this.m_bPressedCtrlKey = false;
            }
        }

        private void imageListBoxControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect)
            {
                if (!this.m_bPressedCtrlKey && !this.m_bPressedShiftKey)
                {
                    this.ClearImageListSelectedItems();
                }
                this.m_pStartPoint = e.Location;
                this.m_pRect = Rectangle.Empty;
            }
        }

        private void imageListBoxControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pStartPoint.IsEmpty)
            {
                this.m_pRect = this.GetRect(e);
                this.SelectImageListBoxItems();
                this.imageListBoxControl1.Refresh();
            }
        }

        private void imageListBoxControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pStartPoint.IsEmpty)
            {
                this.m_pStartPoint = System.Drawing.Point.Empty;
                this.m_pRect = Rectangle.Empty;
                this.imageListBoxControl1.Refresh();
            }
        }

        private void imageListBoxControl1_Paint(object sender, PaintEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pRect.IsEmpty)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), this.m_pRect);
            }
        }

        private Rectangle GetRect(MouseEventArgs e)
        {
            int num = Math.Min(this.m_pStartPoint.X, e.X);
            int num2 = Math.Min(this.m_pStartPoint.Y, e.Y);
            int num3 = Math.Max(this.m_pStartPoint.X, e.X);
            int num4 = Math.Max(this.m_pStartPoint.Y, e.Y);
            Rectangle result = new Rectangle(num, num2, num3 - num, num4 - num2);
            return result;
        }

        private void SelectImageListBoxItems()
        {
            if (!this.m_pRect.IsEmpty)
            {
                for (int i = 0; i < this.imageListBoxControl1.Items.Count; i++)
                {
                    Rectangle itemRectangle = this.imageListBoxControl1.GetItemRectangle(i);
                    bool value = false;
                    if (itemRectangle.IntersectsWith(this.m_pRect))
                    {
                        value = true;
                    }
                    this.imageListBoxControl1.SetSelected(i, value);
                }
            }
        }

        private void ClearImageListSelectedItems()
        {
            for (int i = 0; i < this.imageListBoxControl1.Items.Count; i++)
            {
                this.imageListBoxControl1.SetSelected(i, false);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.cmbPath.SelectedIndex >= 1)
            {
                this.cmbPath.SelectedIndex = this.cmbPath.SelectedIndex - 1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string selectedPath = ControlAPI.GetSelectedPath(this.cmbPath);
            if (selectedPath != null)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                    List<ImageListBoxItem> list = new List<ImageListBoxItem>();
                    int num = 0;
                    foreach (ImageListBoxItem imageListBoxItem in ((IEnumerable)this.imageListBoxControl1.SelectedItems))
                    {
                        string text = imageListBoxItem.Value.ToString();
                        IconType imageIndex = (IconType)imageListBoxItem.ImageIndex;
                        IconType imageIndex2 = (IconType)imageListBoxItem.ImageIndex;
                        if (imageIndex2 <= IconType.Coverage)
                        {
                            if (imageIndex2 == IconType.Folder)
                            {
                                ControlAPI.InsertItemToComboBox(IconType.Folder, selectedPath + text, text, this.cmbPath);
                                return;
                            }
                            switch (imageIndex2)
                            {
                                case IconType.PGDB:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.PGDB, selectedPath + text, text, this.cmbPath);
                                        return;
                                    }
                                    num++;
                                    break;
                                case IconType.PGDBDataset:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.PGDBDataset, selectedPath + text, text, this.cmbPath);
                                        return;
                                    }
                                    break;
                                default:
                                    if (imageIndex2 == IconType.Coverage)
                                    {
                                        if (!this.IsMultiSelect)
                                        {
                                            ControlAPI.InsertItemToComboBox(IconType.Coverage, selectedPath + text, text, this.cmbPath);
                                            return;
                                        }
                                    }
                                    break;
                            }
                        }
                        else if (imageIndex2 != IconType.Cad)
                        {
                            switch (imageIndex2)
                            {
                                case IconType.AddSdeConn:
                                    this.AddSDEConn(selectedPath);
                                    return;
                                case IconType.SdeConnection:
                                    this.OpenSDEConn(text, selectedPath + text);
                                    return;
                                case IconType.E00:
                                    break;
                                case IconType.FGDB:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.FGDB, selectedPath + text, text, this.cmbPath);
                                        return;
                                    }
                                    num++;
                                    break;
                                case IconType.FGDBDataset:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.FGDBDataset, selectedPath + text, text, this.cmbPath);
                                        return;
                                    }
                                    break;
                                default:
                                    if (imageIndex2 == IconType.SDEDataset)
                                    {
                                        if (!this.IsMultiSelect)
                                        {
                                            ControlAPI.InsertItemToComboBox(IconType.SDEDataset, selectedPath + text, text, this.cmbPath);
                                            return;
                                        }
                                    }
                                    break;
                            }
                        }
                        else if (!this.IsMultiSelect)
                        {
                            ControlAPI.InsertItemToComboBox(IconType.Cad, selectedPath + text, text, this.cmbPath);
                            return;
                        }
                        list.Add(imageListBoxItem);
                    }
                    if (list.Count != 0 && num <= 1)
                    {
                        this.FeaturesDict.Clear();
                        this.RasterList.Clear();
                        this.RasterDict.Clear();
                        string text2 = selectedPath.TrimEnd(new char[]
						{
							'\\'
						});
                        string text3 = "";
                        foreach (ImageListBoxItem imageListBoxItem in list)
                        {
                            string text = imageListBoxItem.Value.ToString();
                            switch (imageListBoxItem.ImageIndex)
                            {
                                case 4:
                                case 5:
                                case 6:
                                    if (!this.GetFeatures(selectedPath, text, DataType.shp))
                                    {
                                        return;
                                    }
                                    break;
                                case 7:
                                    if (!this.GetWorkspaceFeatures(text2, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 8:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    if (!this.GetFeatures(selectedPath, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 17:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.coverage))
                                    {
                                        return;
                                    }
                                    break;
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                    if (!this.GetFeatures(selectedPath, text, DataType.coverage))
                                    {
                                        return;
                                    }
                                    break;
                                case 24:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.cad))
                                    {
                                        return;
                                    }
                                    break;
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                    if (!this.GetFeatures(selectedPath, text, DataType.cad))
                                    {
                                        return;
                                    }
                                    break;
                                case 31:
                                    this.GetRasterDataset(selectedPath, text);
                                    break;
                                case 36:
                                    {
                                        if (text3 == "")
                                        {
                                            text3 = ControlAPI.GetCoverageDir();
                                        }
                                        string text4 = text2 + "\\" + text;
                                        if (EngineAPI.E00ToCoverage(text4, text3))
                                        {
                                            string sName = System.IO.Path.GetFileNameWithoutExtension(text4).ToLower();
                                            this.GetDatasetFeatures(text3, sName, DataType.coverage);
                                        }
                                        break;
                                    }
                                case 37:
                                    if (!this.GetWorkspaceFeatures(text2, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 38:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 39:
                                case 40:
                                case 41:
                                case 42:
                                    if (!this.GetFeatures(selectedPath, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 44:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.sde))
                                    {
                                        return;
                                    }
                                    break;
                                case 45:
                                case 46:
                                case 47:
                                case 48:
                                    if (!this.GetFeatures(selectedPath, text, DataType.sde))
                                    {
                                        return;
                                    }
                                    break;
                            }
                        }
                        base.DialogResult = DialogResult.OK;
                    }
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            foreach (WorkspaceInfo current in this.m_pWorkspaceList)
            {
                if (current.Workspace != null)
                Marshal.ReleaseComObject(current.Workspace);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ControlAPI.SaveCurrentPath(this.cmbPath, CommonAPI.KEY_FEATURE_PATH);
        }

        private void OpenGeodatabaseDataset(string sPath, string sName, DataType type, esriGeometryType geometryType)
        {
            string sFilePath = sPath.Substring(0, sPath.Length - sName.Length - 1);
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath, type, this.m_pWorkspaceList);
            this.imageListBoxControl1.BeginUpdate();
            try
            {
                this.imageListBoxControl1.Items.Clear();
                if (workspace != null)
                {
                    IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
                    try
                    {
                        enumDatasetName.Reset();
                        IDatasetName datasetName;
                        while ((datasetName = enumDatasetName.Next()) != null)
                        {
                            if (datasetName.Name == sName)
                            {
                                break;
                            }
                        }
                        ControlAPI.AddFeatureClassToListBox(datasetName.SubsetNames, this.imageListBoxControl1, type, geometryType);
                    }
                    finally
                    {
                        if (enumDatasetName != null)
                        Marshal.ReleaseComObject(enumDatasetName);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("无效的数据，加载数据失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                this.imageListBoxControl1.EndUpdate();
            }
        }

        private bool GetWorkspaceFeatures(string sFilePath, string sName, DataType type)
        {
            string sFilePath2 = sFilePath + "\\" + sName;
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath2, type, this.m_pWorkspaceList);
            bool result;
            if (workspace == null)
            {
                result = true;
            }
            else
            {
                try
                {
                    IEnumDataset enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                    try
                    {
                        IDataset dataset;
                        while ((dataset = enumDataset.Next()) != null)
                        {
                            if (this.FeaturesDict.ContainsKey(dataset.Name))
                            {
                                if (dataset != null)
                                Marshal.ReleaseComObject(dataset);
                            }
                            else
                            {
                                this.FeaturesDict.Add(dataset.Name, dataset as IFeatureClass);
                            }
                        }
                    }
                    finally
                    {
                        if (enumDataset != null)
                        Marshal.ReleaseComObject(enumDataset);
                    }
                    enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                    try
                    {
                        IDataset dataset;
                        while ((dataset = enumDataset.Next()) != null)
                        {
                            IEnumDataset subsets = (dataset as IFeatureDataset).Subsets;
                            try
                            {
                                IDataset dataset2;
                                while ((dataset2 = subsets.Next()) != null)
                                {
                                    if (this.FeaturesDict.ContainsKey(dataset2.Name))
                                    {
                                        if (dataset2 != null)
                                        Marshal.ReleaseComObject(dataset2);
                                    }
                                    else
                                    {
                                        this.FeaturesDict.Add(dataset2.Name, dataset2 as IFeatureClass);
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
                    result = true;
                }
                catch
                {
                    XtraMessageBox.Show(frmSelectFeatures.MSG_ERROR01, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                }
            }
            return result;
        }

        private bool GetDatasetFeatures(string sPath, string sName, DataType type)
        {
            string sPrefix = "";
            string sFilePath;
            if (type <= DataType.sde)
            {
                switch (type)
                {
                    case DataType.mdb:
                    case DataType.gdb:
                        break;
                    case (DataType)3:
                        goto IL_80;
                    default:
                        if (type != DataType.sde)
                        {
                            goto IL_80;
                        }
                        break;
                }
                sFilePath = sPath.TrimEnd(new char[]
				{
					'\\'
				});
                goto IL_88;
            }
            if (type == DataType.cad || type == DataType.coverage)
            {
                sPrefix = sName + "_";
                sFilePath = sPath.TrimEnd(new char[]
				{
					'\\'
				});
                goto IL_88;
            }
        IL_80:
            bool result = true;
            return result;
        IL_88:
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath, type, this.m_pWorkspaceList);
            if (workspace == null)
            {
                result = true;
            }
            else
            {
                try
                {
                    IFeatureDataset featureDataset = (workspace as IFeatureWorkspace).OpenFeatureDataset(sName);
                    IEnumDataset subsets = featureDataset.Subsets;
                    try
                    {
                        subsets.Reset();
                        IDataset dataset;
                        while ((dataset = subsets.Next()) != null)
                        {
                            IFeatureClass featureClass = dataset as IFeatureClass;
                            if (featureClass != null)
                            {
                                string covOrCadFCName = ControlAPI.GetCovOrCadFCName(sPrefix, dataset.Name);
                                if (covOrCadFCName == "" || this.FeaturesDict.ContainsKey(covOrCadFCName))
                                {
                                    if (featureClass != null)
                                    Marshal.ReleaseComObject(featureClass);
                                }
                                else
                                {
                                    this.FeaturesDict.Add(covOrCadFCName, featureClass);
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (subsets != null)
                        Marshal.ReleaseComObject(subsets);
                        if (featureDataset != null)
                        Marshal.ReleaseComObject(featureDataset);
                    }
                    result = true;
                }
                catch
                {
                    XtraMessageBox.Show(frmSelectFeatures.MSG_ERROR01, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                }
            }
            return result;
        }

        private bool GetFeatures(string sPath, string sName, DataType type)
        {
            string sPrefix = "";
            string text = "";
            string text2 = sPath.TrimEnd(new char[]
			{
				'\\'
			});
            if (type <= DataType.sde)
            {
                switch (type)
                {
                    case DataType.mdb:
                        {
                            int num = text2.LastIndexOf(".mdb", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                            break;
                        }
                    case (DataType)3:
                        break;
                    case DataType.gdb:
                        {
                            int num = text2.LastIndexOf(".gdb", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                            break;
                        }
                    default:
                        if (type == DataType.sde)
                        {
                            int num = text2.LastIndexOf(".sde", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                        }
                        break;
                }
            }
            else if (type == DataType.cad || type == DataType.coverage)
            {
                int num = text2.LastIndexOf('\\');
                text = text2.Substring(num + 1);
                int num2 = text.LastIndexOf('.');
                if (num2 >= 0)
                {
                    sPrefix = text.Substring(0, num2) + "_";
                }
                else
                {
                    sPrefix = text + "_";
                }
                text2 = text2.Substring(0, num);
            }
            IFeatureWorkspace featureWorkspace = ControlAPI.GetWorkspace(text2, type, this.m_pWorkspaceList) as IFeatureWorkspace;
            bool result;
            if (featureWorkspace == null)
            {
                result = true;
            }
            else
            {
                IFeatureClass featureClass = null;
                try
                {
                    if (type <= DataType.sde)
                    {
                        switch (type)
                        {
                            case DataType.shp:
                            case DataType.mdb:
                            case DataType.gdb:
                                break;
                            case (DataType)3:
                                goto IL_202;
                            default:
                                if (type != DataType.sde)
                                {
                                    goto IL_202;
                                }
                                break;
                        }
                        featureClass = featureWorkspace.OpenFeatureClass(sName);
                    }
                    else if (type == DataType.cad || type == DataType.coverage)
                    {
                        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(text);
                        IEnumDataset subsets = featureDataset.Subsets;
                        try
                        {
                            subsets.Reset();
                            IDataset dataset;
                            while ((dataset = subsets.Next()) != null)
                            {
                                if (dataset.Name == sName)
                                {
                                    featureClass = (dataset as IFeatureClass);
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            if (subsets != null)
                            Marshal.ReleaseComObject(subsets);
                            if (featureDataset != null)
                            Marshal.ReleaseComObject(featureDataset);
                        }
                    }
                IL_202: ;
                }
                catch
                {
                    XtraMessageBox.Show(sName + "：" + frmSelectFeatures.MSG_ERROR02, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                    return result;
                }
                if (featureClass != null)
                {
                    string covOrCadFCName = ControlAPI.GetCovOrCadFCName(sPrefix, sName);
                    if (covOrCadFCName == "" || this.FeaturesDict.ContainsKey(covOrCadFCName))
                    {
                        if (featureClass != null)
                        Marshal.ReleaseComObject(featureClass);
                        result = true;
                        return result;
                    }
                    this.FeaturesDict.Add(covOrCadFCName, featureClass);
                }
                result = true;
            }
            return result;
        }

        private void GetRasterDataset(string sPath, string sName)
        {
            try
            {
                IRasterWorkspace2 rasterWorkspace = ControlAPI.GetWorkspace(sPath, DataType.raster, this.m_pWorkspaceList) as IRasterWorkspace2;
                if (rasterWorkspace != null)
                {
                    IEnumDatasetName enumDatasetName = (rasterWorkspace as IWorkspace).get_DatasetNames(esriDatasetType.esriDTRasterDataset);
                    try
                    {
                        enumDatasetName.Reset();
                        IDatasetName datasetName;
                        while ((datasetName = enumDatasetName.Next()) != null)
                        {
                            if (string.Equals(datasetName.Name, sName, StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }
                        }
                        if (datasetName != null)
                        {
                            IRasterDataset rasterDataset = (datasetName as IName).Open() as IRasterDataset;
                            this.RasterList.Add(rasterDataset);
                            string key = System.IO.Path.Combine(sPath, sName);
                            if (this.RasterDict.ContainsKey(key))
                            {
                                this.RasterDict[key] = rasterDataset;
                            }
                            else
                            {
                                this.RasterDict.Add(key, rasterDataset);
                            }
                        }
                    }
                    finally
                    {
                        if (enumDatasetName!=null)
                        Marshal.ReleaseComObject(enumDatasetName);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("无效的数据，加载数据失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void OpenFeatureClass(string sPath, string sName, DataType type)
        {
            this.FeaturesDict.Clear();
            this.GetFeatures(sPath, sName, type);
            if (this.FeaturesDict.Count == 1)
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void OpenRasterDataset(string sPath, string sName)
        {
            this.RasterList.Clear();
            this.RasterDict.Clear();
            this.GetRasterDataset(sPath, sName);
            if (this.RasterList.Count == 1)
            {
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void GetSDEConnInfo()
        {
            //this.imageListBoxControl1.BeginUpdate();
            //this.imageListBoxControl1.Items.Clear();
            //ControlAPI.AddItemToListBox(IconType.AddSdeConn, frmSelectFeatures.MSG_CONST01, this.imageListBoxControl1);
            //DirectoryInfo directoryInfo = new DirectoryInfo(ConstDef.CONFIG_PATH);
            //FileInfo[] files = directoryInfo.GetFiles("*.sde", SearchOption.AllDirectories);
            //FileInfo[] array = files;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    FileInfo fileInfo = array[i];
            //    ControlAPI.AddItemToListBox(IconType.SdeConnection, fileInfo.Name, this.imageListBoxControl1);
            //}
            //this.imageListBoxControl1.EndUpdate();
        }

        private void OpenSDEConn(string sName, string sCurrentPath)
        {
            //IWorkspace workspace = ControlAPI.GetOpenedWorkspace(sCurrentPath, DataType.sde, this.m_pWorkspaceList);
            //if (workspace == null)
            //{
            //    workspace = EngineAPI.OpenWorkspace(PS.Plot.Common.ConstDef.CONFIG_PATH + "\\" + sName, DataType.sde);
            //    ControlAPI.AddWorkspaceInfo(sCurrentPath, DataType.sde, workspace, this.m_pWorkspaceList);
            //}
            //ControlAPI.InsertItemToComboBox(IconType.SDE, sCurrentPath, sName, this.cmbPath);
        }

        private void AddSDEConn(string sPath)
        {
            //frmAddSdeConn frmAddSdeConn = new frmAddSdeConn();
            //if (frmAddSdeConn.ShowDialog(this) == DialogResult.OK)
            //{
            //    string text = sPath + frmAddSdeConn.SdeName;
            //    bool flag = false;
            //    foreach (WorkspaceInfo current in this.m_pWorkspaceList)
            //    {
            //        if (text == current.Path && current.Type == DataType.sde)
            //        {
            //            flag = true;
            //            current.Workspace = frmAddSdeConn.SdeWorkspace;
            //            break;
            //        }
            //    }
            //    if (!flag)
            //    {
            //        ControlAPI.AddWorkspaceInfo(text, DataType.sde, frmAddSdeConn.SdeWorkspace, this.m_pWorkspaceList);
            //    }
            //    ControlAPI.InsertItemToComboBox(IconType.SDE, text, frmAddSdeConn.SdeName, this.cmbPath);
            //}
        }
    }
}
