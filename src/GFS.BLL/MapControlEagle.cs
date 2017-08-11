using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFS.BLL
{
    public class MapControlEagle
    {
        //private Dictionary<int, ILayer> _layerDict;

        private IMapControl4 _mapControlMain;

        private IMapControl4 _mapControlEagle;

        public MapControlEagle(IMapControl4 mapControlMain, IMapControl4 mapControlEagle)
        {
            this._mapControlMain = mapControlMain;
            this._mapControlEagle = mapControlEagle;
            //this._layerDict = new Dictionary<int, ILayer>();
            EnviVars.instance.MainForm.FormClosing += delegate(object s1, FormClosingEventArgs ev1)
            {
                EnviVars.instance.EagleVisible = false;
            };
            (this._mapControlMain as IMapControlEvents2_Event).OnExtentUpdated += new IMapControlEvents2_OnExtentUpdatedEventHandler(this.MapControlMain_OnExtentUpdated);
            (this._mapControlMain as IMapControlEvents2_Event).OnAfterScreenDraw += new IMapControlEvents2_OnAfterScreenDrawEventHandler(this.MapControlMain_OnAfterScreenDraw);
            (this._mapControlEagle as IMapControlEvents2_Event).OnMouseDown += new IMapControlEvents2_OnMouseDownEventHandler(this.MapControlEagle_OnMouseDown);
            (this._mapControlEagle as IMapControlEvents2_Event).OnMouseUp += new IMapControlEvents2_OnMouseUpEventHandler(this.MapControlEagle_OnMouseUp);
        }

        private void MapControlMain_OnExtentUpdated(object displayTransformation, bool sizeChanged, object newEnvelope)
        {
        }

        private void MapControlMain_OnAfterScreenDraw(int hdc)
        {
            this.UpdateEagleMapControl();
        }

        private void MapControlEagle_OnMouseDown(int button, int shift, int X, int Y, double mapX, double mapY)
        {
            if (this._mapControlEagle.LayerCount > 0)
            {
                if (button == 2)
                {
                    IEnvelope extent = this._mapControlEagle.TrackRectangle();
                    this._mapControlMain.Extent = extent;
                    this._mapControlMain.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }

        private void MapControlEagle_OnMouseUp(int button, int shift, int X, int Y, double mapX, double mapY)
        {
            if (this._mapControlEagle.LayerCount > 0)
            {
                if (button == 1)
                {
                    IPoint point = new PointClass();
                    point.PutCoords(mapX, mapY);
                    this._mapControlMain.CenterAt(point);
                    this._mapControlMain.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }

        public void UpdateEagleMapControl()
        {
            if (EnviVars.instance.EagleVisible)
            {
                //this.LogLayers(this._layerDict, this._mapControlMain.ActiveView.FocusMap);
                if (_mapControlEagle.LayerCount != _mapControlMain.LayerCount)
                {
                    MapAPI.CopyAndOverwriteMap(this._mapControlMain, this._mapControlEagle);
                    this._mapControlEagle.ActiveView.Extent = this._mapControlEagle.ActiveView.FullExtent;
                }
                this.DrawEagleExtent(this._mapControlMain.Extent);
                //this._mapControlEagle.ActiveView.Refresh();
            }
        }

        private void DrawEagleExtent(IEnvelope myEnvelope)
        {
            if (EnviVars.instance.EagleVisible)
            {
                this._mapControlEagle.ActiveView.GraphicsContainer.DeleteAllElements();
                IRectangleElement rectangleElement = new RectangleElementClass();
                IElement element = rectangleElement as IElement;
                element.Geometry = myEnvelope;
                IRgbColor rgbColor = new RgbColorClass();
                rgbColor.Red = 255;
                rgbColor.Green = 0;
                rgbColor.Blue = 0;
                ILineSymbol lineSymbol = new SimpleLineSymbolClass();
                lineSymbol.Color = rgbColor;
                lineSymbol.Width = 1.5;
                IRgbColor rgbColor2 = new RgbColorClass();
                rgbColor2.Transparency = 0;
                IFillSymbol fillSymbol = new SimpleFillSymbolClass();
                fillSymbol.Color = rgbColor2;
                fillSymbol.Outline = lineSymbol;
                IFillShapeElement fillShapeElement = rectangleElement as IFillShapeElement;
                fillShapeElement.Symbol = fillSymbol;
                this._mapControlEagle.ActiveView.GraphicsContainer.AddElement(element, 0);
                this._mapControlEagle.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private bool CompareLayers(Dictionary<int, ILayer> pLayerLog, IMap pMap)
        {
            bool result;
            if (pLayerLog.Count != pMap.LayerCount)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < pMap.LayerCount; i++)
                {
                    ILayer layer = null;
                    if (!pLayerLog.TryGetValue(i, out layer))
                    {
                        result = false;
                        return result;
                    }
                    if (layer != pMap.get_Layer(i))
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }

        private void LogLayers(Dictionary<int, ILayer> pLayerLog, IMap pMap)
        {
            pLayerLog.Clear();
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                pLayerLog.Add(i, pMap.get_Layer(i));
            }
        }
    }
}
