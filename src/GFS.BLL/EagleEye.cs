using System.Diagnostics;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace GFS.BLL
{
    public class EagleEye
    {
        private IMapControlDefault mainMapControl; //主 MapControl 地图窗口
        private IMapControlDefault smallMapControl; //鹰眼 MapControl 地图窗口
        private IMap pMainMap; //主地图
        private IMap pSmallMap; //鹰眼地图
        private IActiveView pMainAV; //主地图 ActiveView
        private IActiveView pSmallAV; //鹰眼地图 ActiveView
        private IGraphicsContainer pSmallGpContainer; //鹰眼地图 GraphicsContainer
        private IEnvelope pEnv; //记录地图的 Extent
        private bool bCanDrag; //鹰眼地图上的矩形框可移动的标志
        private IPoint pPoint; //在移动鹰眼地图上的矩形框的时候使用
        private Stopwatch pTimer; //记录在左键按下到弹起的时间，根据间隔判断是不是长按左键，然后执行不同的动作

        public IMapControlDefault MainMapControl
        {
            set { mainMapControl = value; }
        }

        public IMapControlDefault SmallMapControl
        {
            set { smallMapControl = value; }
        }

        //构造函数
        public EagleEye(IMapControlDefault mainMapControl, IMapControlDefault smallMapControl)
        {
            this.mainMapControl = mainMapControl;
            this.smallMapControl = smallMapControl;
            smallMapControl.AutoMouseWheel = false;
            pMainMap = mainMapControl.Map;
            pSmallMap = smallMapControl.Map;          
            pMainAV = mainMapControl.ActiveView;
            pSmallAV = smallMapControl.ActiveView;
            pSmallGpContainer = pSmallMap as IGraphicsContainer;
            bCanDrag = false;

            //为主地图窗口 mainMapControl 添加事件
            ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)mainMapControl).OnExtentUpdated +=
            new IMapControlEvents2_OnExtentUpdatedEventHandler(mainMapControl_OnExtentUpdated);
            ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)mainMapControl).OnMapReplaced +=
            new IMapControlEvents2_OnMapReplacedEventHandler(mainMapControl_OnMapReplaced);
            ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)mainMapControl.ActiveView).ItemAdded +=
            new ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler(mainMapControl_ItemAdded);
            ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)mainMapControl.ActiveView).ContentsCleared +=
            new ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsClearedEventHandler(mainMapControl_ContentsCleared);
            //为鹰眼地图窗口 smallMapControl 添加事件
            ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)smallMapControl).OnMouseDown +=
            new IMapControlEvents2_OnMouseDownEventHandler(smallMapControl_OnMouseDown);
            ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)smallMapControl).OnMouseMove +=
            new IMapControlEvents2_OnMouseMoveEventHandler(smallMapControl_OnMouseMove);
            ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)smallMapControl).OnMouseUp +=
            new IMapControlEvents2_OnMouseUpEventHandler(smallMapControl_OnMouseUp);
            //初次在鹰眼地图上画矩形框
            pSmallAV.Extent = pMainAV.FullExtent;
            pEnv = pSmallAV.Extent;
            DrawRectangle(pEnv);
        }

        #region 鹰眼地图窗口的响应事件函数
        void smallMapControl_OnMouseUp(int button, int shift, int X, int Y, double mapX, double mapY)
        {
            if (button == 1)
            {
                pTimer.Stop(); //停止计时
                if (pTimer.Elapsed.Milliseconds <= 150)
                {
                    //鼠标按下到弹起时间小于150毫秒，说明是单纯的点击，则
                    mainMapControl.CenterAt(pPoint);
                }
                else
                {
                    //时间大于150毫秒，说明是长按，应该就是发生了拖动的动作，则
                    if (bCanDrag) //判断是否可拖动
                    {
                        double Dx, Dy; //记录鼠标移动的距离
                        Dx = mapX - pPoint.X;
                        Dy = mapY - pPoint.Y;
                        pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
                        pPoint.PutCoords(mapX, mapY);
                        IPoint pTempPoint = new PointClass();
                        pTempPoint.PutCoords(pEnv.XMin + pEnv.Width / 2, pEnv.YMin + pEnv.Height / 2);
                        mainMapControl.CenterAt(pTempPoint);
                    }
                }
                bCanDrag = false;
            }
        }

        void smallMapControl_OnMouseMove(int button, int shift, int X, int Y, double mapX, double mapY)
        {
            if (mapX > pEnv.XMin && mapY > pEnv.YMin && mapX < pEnv.XMax && mapY < pEnv.YMax)
            //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
            {
                //新建图标,原来将此类封装为dll，所以将图标资源作为嵌入的资源处理
                //System.Drawing.Icon icon = new System.Drawing.Icon(this.GetType().Assembly.GetManifestResourceStream("EagleEye.MyIcon.ico"));
                //smallMapControl.MouseIcon = (stdole.IPictureDisp)ESRI.ArcGIS.ADF.COMSupport.OLE.GetIPictureDispFromIcon(icon);
                smallMapControl.MousePointer = esriControlsMousePointer.esriPointerPan;
                if (button == 2)
                    //如果在内部按下鼠标右键，将鼠标换回原来的
                    smallMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            else
            {
                //在其他位置将鼠标设为默认的样式
                smallMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            //if (bCanDrag)
            //{
            //    double Dx, Dy; //记录鼠标移动的距离
            //    Dx = mapX - pPoint.X;
            //    Dy = mapY - pPoint.Y;
            //    pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
            //    pPoint.PutCoords(mapX, mapY);
            //    DrawRectangle(pEnv);
            //}
        }

        void smallMapControl_OnMouseDown(int button, int shift, int X, int Y, double mapX, double mapY)
        {
            if (button == 1) //左键按下
            {
                if (mapX > pEnv.XMin && mapY > pEnv.YMin && mapX < pEnv.XMax && mapY < pEnv.YMax)
                    bCanDrag = true; //如果指针落在鹰眼的矩形框中，标记可移动
                pTimer = new Stopwatch(); //开始计时，到鼠标弹起时结束计时
                pPoint = new PointClass();
                pPoint.PutCoords(mapX, mapY); //记录点击的第一个点的坐标
                pTimer.Start();
            }
            else if (button == 2) //右键按下
            {
                //在鹰眼地图上面拉个矩形框，然后根据矩形框的范围和位置更改主地图显示范围
                //这里说明一下为什么还用 mainMapControl.CenterAt(pTempPoint); 这个语句
                //我是为了更新主地图 OnExtentUpdated 事件中的 newEnvelope,
                //单独的给 Extent 赋值，newEnvelope 是拉框的范围，我们知道我们拉框的时候
                //不可能把宽高比例和地图中的宽高比例弄的刚好一样，那么就利用 CenterAt()
                //让它自己重新调整 newEnvelope，那么我们依赖 newEnvelope 在鹰眼地图中画
                //矩形框的比例就和地图的宽高比例一致了，当然也可以用其他的办法
                //其他地方的调整我也是用的这样的方法
                IEnvelope pEnvelope = ((MapControl)smallMapControl).TrackRectangle();
                IPoint pTempPoint = new PointClass();
                pTempPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                mainMapControl.Extent = pEnvelope;
                mainMapControl.CenterAt(pTempPoint);
            }
        }
        #endregion

        #region 主地图窗口的响应事件函数
        //地图中所有的数据删除后
        void mainMapControl_ContentsCleared()
        {
            pSmallMap.ClearLayers(); //清空鹰眼地图中所有的图层
            //刷新地图
            pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pSmallAV.Extent);
            pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, pSmallAV.Extent);
        }

        //往主地图中添加数据时发生
        void mainMapControl_ItemAdded(object Item)
        {
            pSmallMap.ClearLayers(); //清空鹰眼地图中所有的图层
            //IFeatureLayer pFeatureLayer;
            //IFeatureClass pFeatureCls;
            pSmallMap.SpatialReference = pMainMap.SpatialReference; //设置鹰眼和主地图的坐标系统一致
            ILayer pLayer;
            int count = mainMapControl.LayerCount;
            //获得主地图中的图层数，然后遍历，往鹰眼地图中添加数据
            for (int i = count - 1; i >= 0; i--)
            {
                //pFeatureLayer = pMainMap.get_Layer(i) as IFeatureLayer;
                pLayer = pMainMap.get_Layer(i);
                if (pLayer != null&&pLayer.Visible)
                {
                    pSmallMap.AddLayer(pLayer);
                    //break;
                }
            }
            pSmallAV.Extent = mainMapControl.FullExtent; //设置鹰眼地图全图显示
            pEnv = mainMapControl.Extent as IEnvelope;
            DrawRectangle(pEnv);
            //刷新鹰眼地图
            pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pSmallAV.Extent);
            //pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, pSmallAV.Extent);
        }

        //主地图窗口更换地图文档后发生
        void mainMapControl_OnMapReplaced(object newMap)
        {
            if (pSmallMap.LayerCount > 0)
            //如果鹰眼地图中存在图层则删除它们
            {
                pSmallMap.ClearLayers();
            }
            pSmallMap.SpatialReference = pMainMap.SpatialReference; 
            try
            {
                ILayer pLayer;
                int count = mainMapControl.LayerCount;
                //获得主地图中的图层数，然后遍历，往鹰眼地图中添加数据
                for (int i = count - 1; i >= 0; i--)
                {
                    //pFeatureLayer = pMainMap.get_Layer(i) as IFeatureLayer;
                    pLayer = pMainMap.get_Layer(i);
                    if (pLayer != null && pLayer.Visible)
                    {
                        pSmallMap.AddLayer(pLayer);
                        break;
                    }
                }
            }
            catch (System.Exception)
            { }
            pSmallAV.Extent = mainMapControl.FullExtent;
            pEnv = mainMapControl.Extent as IEnvelope;
            DrawRectangle(pEnv);
            pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, pSmallAV.Extent);
            //pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pSmallAV.Extent);
        }

        void mainMapControl_OnExtentUpdated(object displayTransformation, bool sizeChanged, object newEnvelope)
        {
            //pSmallMap.ClearLayers();
            //for (int i = 0; i < pMainMap.LayerCount; i++)
            //{
            //    if (pMainMap.get_Layer(i).Visible)
            //    {
            //        pSmallMap.AddLayer(pMainMap.get_Layer(i));
            //        break;
            //    }
            //}
            //pSmallAV.Refresh();
            pEnv = newEnvelope as IEnvelope;
            //pEnv = mainMapControl.Extent as IEnvelope;
            DrawRectangle(pEnv);
        }
        #endregion

        //在鹰眼地图上画矩形框
        public void DrawRectangle(IEnvelope pEnvelope)
        {
            pSmallGpContainer.DeleteAllElements(); //清除之前绘制的矩形框
            //pSmallMap.SpatialReference = pMainMap.SpatialReference; //设置鹰眼和主地图的坐标系统一致
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pEle = pRectangleEle as IElement;
            pEle.Geometry = pEnvelope;

            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 1.5;
            pOutLine.Color = pColor;

            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;

            IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pSmallGpContainer.AddElement(pFillShapeEle as IElement, 0);
            pSmallAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, pSmallAV.Extent);
        }
    }
}