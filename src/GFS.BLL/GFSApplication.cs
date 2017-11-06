// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-17-2017
// ***********************************************************************
// <copyright file="GFSApplication.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>main GIS frame logic</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.IO;
using ESRI.ArcGIS.SystemUI;
using System.Collections;
using ESRI.ArcGIS.Display;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Docking;

namespace GFS.BLL
{
    public class GFSApplication
    {
        //地图控件
        private IMapControl3 _mapControl = null;
        //鹰眼地图
        private IMapControl3 _mapControlEagle = null;
        //图层控件
        private ITOCControl2 _tocControl = null;
        //GIS工具条控件
        private IToolbarControl2 _toolbarControl = null;
        private Form _mainForm;

        //工具条列表
        private List<Bar> _barList = null;
        // 开始菜单
        private ApplicationMenu _appMenu = null;
        //图框菜单
        private PopupMenu _popMenuFrame = null;
        //图层菜单
        private PopupMenu _popMenuLayer = null;
        //波段组合菜单
        private PopupMenu _popMenuRGB = null;
        //最近使用任务控件
        private ImageListBoxControl _lstRecently = null;
        private TaskHistory history = null;
        //状态栏坐标系
        private BarItem _barItemSPt = null;
        //状态栏坐标
        private BarItem _barItemXY = null;
        //状态栏像素信息
        private BarItem _barItemRaster = null;
        //顶层栅格
        private IRasterLayer _rasterLayer;
        //当前空间参考
        ISpatialReference _spatialReference;
        //图层列表
        private List<ILayer> _lyrList = new List<ILayer>();
        //选择图层控件
        private BarEditItem _barEditLyList = null;
        //卷帘按钮
        private BarItem _barItemSwipe = null;
        private ILayerEffectProperties _layerEffectProperties = null;
        //鹰眼按钮
        private BarButtonItem _barEagle = null;
        //private EagleEye _eagleEye = null;
        private MapControlEagle _eagleEye = null;
        private DockPanel _dpEagle = null;
        private bool tmp1 = false;

        /// <summary>
        /// 传递所有GIS控件和主窗体
        /// </summary>
        /// <param name="mapControl">地图控件</param>
        /// <param name="mapControlEagle">鹰眼控件</param>
        /// <param name="tocControl">图层控件</param>
        /// <param name="toolbarControl">gis工具条</param>
        /// <param name="mainForm">主窗体</param>
        public GFSApplication(IMapControl3 mapControl,IMapControl3 mapControlEagle, ITOCControl2 tocControl,
            IToolbarControl2 toolbarControl,Form mainForm)
        {
            this._mapControl = mapControl;
            this._mapControlEagle = mapControlEagle;
            this._tocControl = tocControl;
            this._toolbarControl = toolbarControl;
            this._mainForm = mainForm;
            EnviVars.instance.MapControl = mapControl;
            EnviVars.instance.TOCControl = tocControl;
            EnviVars.instance.MainForm = mainForm;

            (mapControl as IMapControlEvents2_Event).OnMouseMove += new IMapControlEvents2_OnMouseMoveEventHandler(this.mapControl_OnMouseMove);
            (mapControl as IMapControlEvents2_Event).OnAfterScreenDraw += new IMapControlEvents2_OnAfterScreenDrawEventHandler(this.mapControl_OnAfterScreenDraw);
            (mapControl as IMapControlEvents2_Event).OnMouseDown += new IMapControlEvents2_OnMouseDownEventHandler(this.mapControl_OnMouseDown);

            (tocControl as ITOCControlEvents_Event).OnMouseDown += new ITOCControlEvents_OnMouseDownEventHandler(this.tocControl_OnMouseDown);
            (tocControl as ITOCControlEvents_Event).OnDoubleClick += new ITOCControlEvents_OnDoubleClickEventHandler(this.tocControl_OnDoubleClick);
            (tocControl as ITOCControlEvents_Event).OnBeginLabelEdit += new ITOCControlEvents_OnBeginLabelEditEventHandler(this.tocControl_OnBeginLabelEdit);
            (tocControl as ITOCControlEvents_Event).OnEndLabelEdit += new ITOCControlEvents_OnEndLabelEditEventHandler(this.tocControl_OnEndLabelEdit);        
            mainForm.FormClosed += new FormClosedEventHandler(this.MainFormClosed);
        }

        /// <summary>
        /// 初始化主程序类
        /// </summary>
        /// <param name="barList">工具条列表</param>
        /// <param name="appMenu">开始菜单</param>
        /// <param name="frameMenu">图框菜单</param>
        /// <param name="lyrMenu">图层菜单</param>
        /// <param name="rgbMenu">波段组合菜单</param>
        /// <param name="layerItem">图层选择控件</param>
        /// <param name="sptItem">状态栏坐标系</param>
        /// <param name="xyItem">状态栏坐标</param>
        /// <param name="rasterItem">状态栏栅格信息</param>
        /// <param name="swipeItem">卷帘按钮</param>
        /// <param name="eagleItem">鹰眼按钮</param>
        /// <param name="dpEagle">鹰眼控件</param>
        /// <param name="lstRecentFiles">最近历史控件</param>
        /// <param name="tableContainer">属性表容器</param>
        public void Initialize(List<Bar> barList,ApplicationMenu appMenu,
            PopupMenu frameMenu, PopupMenu lyrMenu, PopupMenu rgbMenu, 
            BarEditItem layerItem,BarItem sptItem,BarItem xyItem,
            BarItem rasterItem, BarItem swipeItem, BarButtonItem eagleItem,DockPanel dpEagle,
            ImageListBoxControl lstRecentFiles,ControlContainer tableContainer)
        {
            MapAPI.NewDocument();

            this._barList = barList;
            this._appMenu = appMenu;
            this._popMenuFrame = frameMenu;
            this._popMenuLayer = lyrMenu;
            this._popMenuRGB = rgbMenu;
            this._barEditLyList = layerItem;
            this._barItemSwipe = swipeItem;
            this._layerEffectProperties = new CommandsEnvironmentClass();
            this._barItemSPt = sptItem;
            this._barItemXY = xyItem;
            this._barItemRaster = rasterItem;
            this._barEagle = eagleItem;
            this._dpEagle = dpEagle;
            this._lstRecently = lstRecentFiles;
            //EnviVars.instance.TablePanel = tablePanel;
            EnviVars.instance.TableContainer = tableContainer;
            EnviVars.instance.RecentFilesCtrl = lstRecentFiles;
            history = new TaskHistory(ConstDef.FILE_RENCENTFILES, 5);
            EnviVars.instance.history = history;
            history.LoadHistory();
            _eagleEye = new MapControlEagle(this._mapControl as IMapControl4, this._mapControlEagle as IMapControl4);
            this._barEagle.ItemClick += new ItemClickEventHandler(this._barEagle_ItemClick);
            lstRecentFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstRecently_MouseClick);
            this._barEditLyList.EditValueChanged += new EventHandler(this.barEditLyList_EditValueChanged);
            
            //绑定工具条按钮事件
            IEnumerator enumerator;
            foreach (Bar current in barList)
            {
                enumerator = current.ItemLinks.GetEnumerator();
                this.GetContainerCommandList(enumerator);
            }
            //绑定开始菜单按钮事件
            enumerator = appMenu.ItemLinks.GetEnumerator();
            this.GetContainerCommandList(enumerator);
            //绑定图框菜单按钮事件
            enumerator = frameMenu.ItemLinks.GetEnumerator();
            this.GetContainerCommandList(enumerator);
            //绑定图层菜单按钮事件
            enumerator = lyrMenu.ItemLinks.GetEnumerator();
            this.GetContainerCommandList(enumerator);
        }

        //
        //获取按钮tag信息中所有command并绑定事件
        //
        private void GetContainerCommandList(IEnumerator enumerator)
        {
            try
            {
                while (enumerator.MoveNext())
                {
                    BarItemLink barItemLink = (BarItemLink)enumerator.Current;
                    this.BindCommandClick(barItemLink);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
        private void BindCommandClick(BarItemLink barItemLink)
        {
            BarItem item = barItemLink.Item;
            if (item is BarSubItem)
            {
                BarSubItem barSubItem = item as BarSubItem;
                foreach (BarItemLink barItemLink2 in barSubItem.ItemLinks)
                {
                    this.BindCommandClick(barItemLink2);
                }
            }
            else if (item.Tag != null)
            {
                string text = item.Tag.ToString();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    item.ItemClick += new ItemClickEventHandler(this.Item_OnClick);
                }
            }
        }
        private void Item_OnClick(object obj, ItemClickEventArgs itemClickEventArgs)
        {
            string cmdName = itemClickEventArgs.Item.Tag.ToString();
            if (cmdName == null)
                return;
            ICommand pCommand;
            if (this._toolbarControl == null) return;
            for (int i = 0; i < _toolbarControl.CommandPool.Count; i++)
            {
                pCommand = _toolbarControl.CommandPool.get_Command(i);
                if (pCommand.Name == cmdName)
                {
                    if (pCommand is ITool)
                    {
                        (_toolbarControl.Buddy as IMapControl3).CurrentTool = pCommand as ITool;
                    }
                    pCommand.OnClick();
                    break;
                }
            }
        }
        //
        //鹰眼按钮点击
        //
        private void _barEagle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._barEagle.Down)
            {
                this._dpEagle.Visibility = DockVisibility.Visible;
                EnviVars.instance.EagleVisible = true;
                this._eagleEye.UpdateEagleMapControl();
            }
            else
            {
                this._dpEagle.Visibility = DockVisibility.Hidden;
                EnviVars.instance.EagleVisible = false;
            }
        }
        //
        //历史任务双击击事件
        //
        private void lstRecently_MouseClick(object obj, System.Windows.Forms.MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int num = this._lstRecently.IndexFromPoint(mouseEventArgs.Location);
                if (num >= 0)
                {
                    ImageListBoxItem task = this._lstRecently.Items[num];
                    string file = task.Value.ToString();
                    if (File.Exists(file))
                    {
                        MapAPI.OpenDocument(file);
                    }
                    else
                    {
                        XtraMessageBox.Show("未找到任务文档！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _lstRecently.Items.RemoveAt(num);
                    }
                }
            }
        }
        //
        //卷帘选择图层改变
        //
        private void barEditLyList_EditValueChanged(object obj, EventArgs eventArgs)
        {
            CurrentLayer currentLayer = this._barEditLyList.EditValue as CurrentLayer;
            if (currentLayer == null)
            {
                this._layerEffectProperties.SwipeLayer = null;
            }
            else
            {
                this._layerEffectProperties.SwipeLayer = currentLayer.Layer;
            }
        }
        //
        //GISControl events
        //
        private void mapControl_OnMouseMove(int button, int shift, int x, int y, double mapX, double mapY)
        {
            this.GetStatusXY(mapX, mapY);
        }
        private void mapControl_OnMouseDown(int button, int shift, int x, int y, double mapX, double mapY)
        {
            //按下中键绑定移动图层命令
            ITool tool=null;
            if (button == 4)
            {
                //清空地图工具，防止误操作
                tool = this._mapControl.CurrentTool;
                this._mapControl.CurrentTool = null;
                //更改鼠标样式
                _mapControl.MousePointer = esriControlsMousePointer.esriPointerPan;
                //拖动图层
                _mapControl.Pan();
            }
            this._mapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }
        private void mapControl_OnAfterScreenDraw(int hdc)
        {
            this.UpdateLyrList(this._mapControl.Map);
            this.SetBarItemEnabled();
            this.GetSpRf(this._mapControl.SpatialReference);
        }
        
        private void tocControl_OnMouseDown(int button, int shift, int x, int y)
        {
            esriTOCControlItem esriTOCControlItem = esriTOCControlItem.esriTOCControlItemNone;
            object obj = null;
            object obj2 = null;
            IBasicMap basicMap = null;
            ILayer layer = null;
            this._tocControl.HitTest(x, y, ref esriTOCControlItem, ref basicMap, ref layer, ref obj, ref obj2);
            if (button == 2)
            {
                switch (esriTOCControlItem)
                {
                    case esriTOCControlItem.esriTOCControlItemMap:
                        this._tocControl.SelectItem(basicMap, null);
                        this._mapControl.CustomProperty = basicMap;
                        this._popMenuFrame.ShowPopup(System.Windows.Forms.Control.MousePosition);
                        break;
                    case esriTOCControlItem.esriTOCControlItemLayer:
                        this._tocControl.SelectItem(layer, null);
                        this._mapControl.CustomProperty = layer;
                        this.SetBarItemEnabled();
                        this._popMenuLayer.ShowPopup(System.Windows.Forms.Control.MousePosition);
                        break;
                }
            }
        }

        private void tocControl_OnDoubleClick(int button, int shift, int x, int y)
        {
            esriTOCControlItem esriTOCControlItem = esriTOCControlItem.esriTOCControlItemNone;
            object obj = null;
            object obj2 = null;
            IBasicMap basicMap = null;
            ILayer layer = null;
            this._tocControl.HitTest(x, y, ref esriTOCControlItem, ref basicMap, ref layer, ref obj, ref obj2);
            if (button == 1)
            {
                if (esriTOCControlItem == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    if (layer is IRasterLayer)
                    {
                        IRasterLayer rasterLayer = layer as IRasterLayer;
                        if (rasterLayer.Renderer is IRasterRGBRenderer)
                        {
                            this._mapControl.CustomProperty = layer;
                            this.AddPopMenuRGBItem(obj2, rasterLayer);
                        }
                        else if (rasterLayer.Renderer is IRasterUniqueValueRenderer)
                        {
                            IRasterUniqueValueRenderer rasterUniqueValueRenderer = rasterLayer.Renderer as IRasterUniqueValueRenderer;
                            ISymbol symbol = rasterUniqueValueRenderer.get_Symbol(0, (int)obj2);
                            this.RenderRasterUniqueValue(layer, rasterUniqueValueRenderer, symbol, 0, (int)obj2);
                        }
                        else if (rasterLayer.Renderer is IRasterStretchColorRampRenderer)
                        {
                            frmLayerRender frmLayerRender = new frmLayerRender(layer);
                            if (frmLayerRender.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                            {
                                EnviVars.instance.TOCControl.Update();
                                RefreshView(layer);
                            }
                        }
                            
                    }
                    else
                    {
                        ESRI.ArcGIS.Carto.ILegendClass pLC = new LegendClassClass();
                        ESRI.ArcGIS.Carto.ILegendGroup pLG = new LegendGroupClass();
                        if (obj is ILegendGroup)
                        {
                            pLG = (ILegendGroup)obj;
                        }
                        pLC = pLG.get_Class((int)obj2);
                        pLC.Symbol = this.ChangeSymbol(layer, pLC.Symbol);
                        RefreshView(layer);
                    }
                }
            }
        }

        private void tocControl_OnBeginLabelEdit(int x, int y, ref bool canEdit)
        {
            canEdit = true;
        }

        private void tocControl_OnEndLabelEdit(int x, int y, string newLable, ref bool canEdit)
        {
            if (string.IsNullOrWhiteSpace(newLable))
            {
                canEdit = false;
            }
        }
        //
        //主窗体关闭保存最近历史
        //
        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                history.SaveHistory();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Log.WriteLog(typeof(GFSApplication), ex);
            }
            try
            { CommonAPI.DelectDir(ConstDef.PATH_TEMP); }
            catch (Exception)
            { }

        }
        //
        //创建RGB波段组合菜单项
        //
        private void AddPopMenuRGBItem(object obj, IRasterLayer rasterLayer)
        {
            ItemClickEventHandler itemClickEventHandler = null;
            GFSApplication.RGBBandMtch bandMatch = new GFSApplication.RGBBandMtch();
            bandMatch._rasterLayer = rasterLayer;
            bandMatch._applicationClass = this;
            bandMatch._rasterRGBRender = bandMatch._rasterLayer.Renderer as IRasterRGBRenderer;
            this._popMenuRGB.ClearLinks();
            List<BarCheckItem> list = new List<BarCheckItem>();
            bandMatch._bandIndex = (int)obj;
            bandMatch._barCheckItem = new BarCheckItem();
            list.Add(bandMatch._barCheckItem);
            bandMatch._barCheckItem.Caption = "可见";
            this.GetUseBand(bandMatch._rasterRGBRender, bandMatch._bandIndex, bandMatch._barCheckItem);
            this._popMenuRGB.AddItem(bandMatch._barCheckItem);
            IRasterBandCollection rasterBandCollection = (bandMatch._rasterLayer.Raster as IRaster2).RasterDataset as IRasterBandCollection;
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                IRasterBand rasterBand = rasterBandCollection.Item(i);
                BarCheckItem barCheckItem = new BarCheckItem();
                list.Add(barCheckItem);
                barCheckItem.GroupIndex = 8;
                barCheckItem.Caption = rasterBand.Bandname;
                barCheckItem.Tag = i;
                int num = -1;
                switch (bandMatch._bandIndex)
                {
                    case 0:
                        num = bandMatch._rasterRGBRender.RedBandIndex;
                        break;
                    case 1:
                        num = bandMatch._rasterRGBRender.GreenBandIndex;
                        break;
                    case 2:
                        num = bandMatch._rasterRGBRender.BlueBandIndex;
                        break;
                }
                if (i == num)
                {
                    barCheckItem.Checked = true;
                }
                this._popMenuRGB.AddItem(barCheckItem);
            }
            foreach (BarCheckItem barCheckItem in list)
            {
                if (itemClickEventHandler == null)
                {
                    itemClickEventHandler = new ItemClickEventHandler(bandMatch.BarItem_Click);
                }
                barCheckItem.CheckedChanged += itemClickEventHandler;
            }
            this._popMenuRGB.ShowPopup(System.Windows.Forms.Control.MousePosition);
        }
        //
        //获取波段可用性
        //
        private void GetUseBand(IRasterRGBRenderer rasterRGBRenderer, int num, BarCheckItem barCheckItem)
        {
            switch (num)
            {
                case 0:
                    barCheckItem.Checked = rasterRGBRenderer.UseRedBand;
                    break;
                case 1:
                    barCheckItem.Checked = rasterRGBRenderer.UseGreenBand;
                    break;
                case 2:
                    barCheckItem.Checked = rasterRGBRenderer.UseBlueBand;
                    break;
            }
        }
        //
        //设置波段可用性
        //
        private void SetUseBand(IRasterRGBRenderer rasterRGBRenderer, int num, BarCheckItem barCheckItem)
        {
            switch (num)
            {
                case 0:
                    rasterRGBRenderer.UseRedBand = barCheckItem.Checked;
                    break;
                case 1:
                    rasterRGBRenderer.UseGreenBand = barCheckItem.Checked;
                    break;
                case 2:
                    rasterRGBRenderer.UseBlueBand = barCheckItem.Checked;
                    break;
            }
        }
        //
        //更改栅格唯一值渲染符号
        //
        private void RenderRasterUniqueValue(ILayer layerOrElement, IRasterUniqueValueRenderer rasterUniqueValueRenderer, ISymbol symbol, int iHeading, int iClass)
        {
            esriSymbologyStyleClass styleClass;
            if (symbol is IFillSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
            }
            else if (symbol is IMarkerSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            }
            else
            {
                if (!(symbol is ILineSymbol))
                {
                    return;
                }
                styleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
            }
            IStyleGalleryItem item = new frmSymbolSelector
            {
                Owner = EnviVars.instance.MainForm
            }.GetItem(styleClass, symbol);
            if (item != null)
            {
                rasterUniqueValueRenderer.set_Symbol(iHeading, iClass, item.Item as ISymbol);
                this._mapControl.ActiveView.ContentsChanged();
                this._mapControl.Refresh(esriViewDrawPhase.esriViewGeography, layerOrElement, null);
            }
        }
        //
        //更改矢量唯一值渲染符号
        //
        private ISymbol ChangeSymbol(ILayer layer, ISymbol symbol)
        {
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            if (featureLayer != null)
            {
                if (symbol != null)
                {
                    esriSymbologyStyleClass styleClass;
                    switch (featureLayer.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPoint:
                            styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                            goto IL_CF;
                        case esriGeometryType.esriGeometryPolyline:
                            styleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                            goto IL_CF;
                        case esriGeometryType.esriGeometryPolygon:
                            styleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                            goto IL_CF;
                    }
                    return symbol;
                IL_CF:
                    IStyleGalleryItem item = new frmSymbolSelector
                    {
                        Owner = EnviVars.instance.MainForm
                    }.GetItem(styleClass, symbol);
                    if (item != null)
                    {
                        symbol = (ISymbol)item.Item;

                    }
                }
            }
            return symbol;
        }
        //
        //刷新图层
        //
        private void RefreshView(ILayer layer)
        {
            this._mapControl.ActiveView.ContentsChanged();
            this._mapControl.Refresh(esriViewDrawPhase.esriViewGeography, layer, null);
        }
        //
        //设置command按钮是否激活
        //
        private void SetBarItemEnabled()
        {
            try
            {
                if (!this.tmp1)
                {
                    Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
                    for (int i = 0; i < this._toolbarControl.CommandPool.Count; i++)
                    {
                        ICommand command = this._toolbarControl.CommandPool.get_Command(i);
                        dictionary.Add(command.Name, command.Enabled);

                    }
                    if (this._barList != null)
                    {
                        foreach (Bar currentBar in this._barList)
                        {
                            this.SetBarItemEnabled(dictionary, currentBar.Manager.Items);
                        }
                        this._barEditLyList.Enabled = this._barItemSwipe.Enabled;
                    }
                    if (this._popMenuLayer != null)
                    {
                        this.SetBarItemEnabled(dictionary, this._popMenuLayer.Manager.Items);
                    }
                }
            }
            catch(Exception)
            {}
        }
        private void SetBarItemEnabled(Dictionary<string, bool> dictionary, BarItems barItems)
        {
            foreach (BarItem barItem in barItems)
            {
                if (barItem.Tag != null)
                {
                    string text = barItem.Tag.ToString();
                    if (!string.IsNullOrWhiteSpace(text) && dictionary.ContainsKey(text))
                    {
                        barItem.Enabled = dictionary[text];
                    }
                }
            }
        }
        //
        //更新图层列表
        //
        private void UpdateLyrList(IMap map)
        {
            if (this._barEditLyList != null && this._barEditLyList.Edit is RepositoryItemComboBox)
            {
                List<ILayer> list;
                if (!this.CompareLyrList(map, out list))
                {
                    this._lyrList.Clear();
                    foreach (ILayer current in list)
                    {
                        this._lyrList.Add(current);
                    }
                    this.UpdateLyrListUI(list);
                }
            }
        }
        private bool CompareLyrList(IMap pMap, out List<ILayer> ptr)
        {
            ptr = EngineAPI.GetLayers(pMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
            bool result;
            if (ptr.Count != this._lyrList.Count)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < ptr.Count; i++)
                {
                    ILayer layer = ptr[i];
                    ILayer layer2 = this._lyrList[i];
                    if (layer != layer2)
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }
        private void UpdateLyrListUI(List<ILayer> list)
        {
            this._rasterLayer = null;
            RepositoryItemComboBox repositoryItemComboBox = this._barEditLyList.Edit as RepositoryItemComboBox;
            repositoryItemComboBox.BeginUpdate();
            try
            {
                repositoryItemComboBox.Items.Clear();
                CurrentLayer currentLayer = null;
                int num = 0;
                foreach (ILayer current in list)
                {
                    CurrentLayer currentLayer2 = new CurrentLayer();
                    currentLayer2.Name = current.Name;
                    currentLayer2.Layer = current;
                    repositoryItemComboBox.Items.Add(currentLayer2);
                    if (this._barEditLyList.EditValue is CurrentLayer && (this._barEditLyList.EditValue as CurrentLayer).Layer == current)
                    {
                        currentLayer = currentLayer2;
                    }
                    if (num == 0 && current.Visible && current is IRasterLayer)
                    {
                        this._rasterLayer = (current as IRasterLayer);
                        num++;
                    }
                }
                if (currentLayer == null && repositoryItemComboBox.Items.Count > 0)
                {
                    currentLayer = (repositoryItemComboBox.Items[0] as CurrentLayer);
                }
                this._barEditLyList.EditValue = currentLayer;
            }
            finally
            {
                repositoryItemComboBox.EndUpdate();
            }
        }
        //
        //获取空间参考
        //
        private void GetSpRf(ISpatialReference spatialReference)
        {
            if (this._barItemSPt != null)
            {
                string arg = "未知坐标系";
                if (spatialReference != null)
                {
                    this._spatialReference = spatialReference;
                    if (!(spatialReference is IUnknownCoordinateSystem))
                    {
                        if (string.IsNullOrEmpty(spatialReference.Alias))
                        {
                            arg = spatialReference.Name;
                        }
                        else
                        {
                            arg = spatialReference.Alias;
                        }
                    }
                }
                this._barItemSPt.Caption = string.Format("坐标系： {0}", arg);
            }
        }
        //
        //获取地图状态信息
        //
        private void GetStatusXY(double mapX, double mapY)
        {
            try
            {

                if (this._barItemXY != null)
                {
                    ISpatialReference spatialReference = this._mapControl.SpatialReference;
                    if (spatialReference != null)
                    {
                        if (spatialReference is IProjectedCoordinateSystem)
                        {
                            IProjectedCoordinateSystem projectedCoordinateSystem = spatialReference as IProjectedCoordinateSystem;
                            IPoint point = new PointClass();
                            point.SpatialReference = spatialReference;
                            point.X = mapX;
                            point.Y = mapY;
                            point.Project(projectedCoordinateSystem.GeographicCoordinateSystem);
                            double lon = point.X;
                            double lat = point.Y;
                            int lon_degree = (int)Math.Floor(Convert.ToDecimal(lon));
                            int lat_degree = (int)Math.Floor(Convert.ToDecimal(lat));
                            lon = (lon - lon_degree)*60;
                            lat = (lat - lat_degree) * 60;
                            int lon_m = (int)Math.Floor(Convert.ToDecimal(lon));
                            int lat_m = (int)Math.Floor(Convert.ToDecimal(lat));
                            lon = (lon - lon_m) * 60;
                            lat = (lat - lat_m) * 60;
                            int lon_s = (int)Math.Floor(Convert.ToDecimal(lon));
                            int lat_s = (int)Math.Floor(Convert.ToDecimal(lat));
                            string strLon = "";
                            string strLat = "";
                            if (lon_degree > 0)
                            {
                                strLon = lon_degree + "° " + lon_m + "′ " + lon_s + "″ E";                      
                            }
                            else 
                            {
                                strLon = lon_degree + "° " + lon_m + "′ " + lon_s + "″ E";
                            }
                            if (lat_degree > 0)
                            {
                                strLat = lat_degree + "° " + lat_m + "′ " + lat_s + "″ N";
                            }
                            else
                            {
                                strLat = lat_degree + "° " + lat_m + "′ " + lat_s + "″ N";
                            }
                            this._barItemXY.Caption = string.Format("坐标：{0},{1}", strLon, strLat);
                        }
                    }
                    else
                        this._barItemXY.Caption = string.Format("坐标：{0},{1}", mapX, mapY);
                }
                if (this._barItemRaster != null)
                {
                    this._barItemRaster.Visibility = BarItemVisibility.Never;
                    if (this._rasterLayer != null)
                    {
                        IRaster2 raster = this._rasterLayer.Raster as IRaster2;
                        IPoint point = new PointClass();
                        point.X = mapX;
                        point.Y = mapY;
                        point.SpatialReference = this._spatialReference;
                        ISpatialReference spatialReference = (raster as IGeoDataset).SpatialReference;
                        if (!EngineAPI.IsEqualSpatialReference(this._spatialReference, spatialReference))
                        {
                            point.Project(spatialReference);
                        }
                        int colum;
                        int row;
                        raster.MapToPixel(point.X, point.Y, out colum, out row);
                        if (colum >= 0 && colum <= this._rasterLayer.ColumnCount && row >= 0 && row <= this._rasterLayer.RowCount)
                        {
                            this._barItemRaster.Visibility = BarItemVisibility.Always;

                            double value = CommonAPI.ConvertToDouble(raster.GetPixelValue(0, colum, row));
                            this._barItemRaster.Caption = string.Format("行：{0}, 列：{1}, 像素值：{2}", row, colum, value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(GFSApplication), ex);
            }
        }
        //
        //波段组合类
        //
        private sealed class RGBBandMtch
        {
            /// <summary>
            /// The _raster RGB render
            /// </summary>
            public IRasterRGBRenderer _rasterRGBRender;

            /// <summary>
            /// The _band index
            /// </summary>
            public int _bandIndex;

            /// <summary>
            /// The _bar check item
            /// </summary>
            public BarCheckItem _barCheckItem;

            /// <summary>
            /// The _application class
            /// </summary>
            public GFSApplication _applicationClass;

            /// <summary>
            /// The _raster layer
            /// </summary>
            public IRasterLayer _rasterLayer;

            /// <summary>
            /// Handles the Click event of the BarItem control.
            /// </summary>
            /// <param name="obj">The source of the event.</param>
            /// <param name="itemClickEventArgs">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
            public void BarItem_Click(object obj, ItemClickEventArgs itemClickEventArgs)
            {
                BarCheckItem barCheckItem = obj as BarCheckItem;
                if (barCheckItem.Tag == null)
                {
                    this._applicationClass.SetUseBand(this._rasterRGBRender, this._bandIndex, this._barCheckItem);
                }
                else
                {
                    int index = (int)barCheckItem.Tag;
                    switch (this._bandIndex)
                    {
                        case 0:
                            this._rasterRGBRender.RedBandIndex = index;
                            break;
                        case 1:
                            this._rasterRGBRender.GreenBandIndex = index;
                            break;
                        case 2:
                            this._rasterRGBRender.BlueBandIndex = index;
                            break;
                    }
                }
                this._rasterLayer.Renderer = (this._rasterRGBRender as IRasterRenderer);
                this._applicationClass._mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, this._rasterLayer, null);
                this._applicationClass._mapControl.ActiveView.ContentsChanged();
            }
            /// <summary>
            /// Initializes static members of the <see cref="RGBBandMtch"/> class.
            /// </summary>
            static RGBBandMtch()
            {
            }
        }



    }
}
