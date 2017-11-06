using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using GFS.BLL;
using GFS.Common;
using GFS.BLL;

namespace GFS.Commands.UI
{
    public class CtrCurrentLayer : XtraUserControl
    {
        public delegate void SelectChangedHandle(ILayer layer);

        public delegate void BefroeInitEventHander();

        private IContainer components = null;

        private ComboBoxEdit cmbEditCurrentLayer;

        private List<MyDataLayer> m_layers = new List<MyDataLayer>();

        public event CtrCurrentLayer.SelectChangedHandle OnSelectChanged;

        public event CtrCurrentLayer.BefroeInitEventHander BeforeInit;

        public IMapControl2 MapControl
        {
            get;
            set;
        }

        public EnumLayerType EnumLayerType
        {
            get;
            set;
        }

        public EnumRasterBandCount EnumRasterBandCount
        {
            get;
            set;
        }

        public ILayer CurrentLayer
        {
            get;
            private set;
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
            this.cmbEditCurrentLayer = new ComboBoxEdit();
            ((ISupportInitialize)this.cmbEditCurrentLayer.Properties).BeginInit();
            base.SuspendLayout();
            this.cmbEditCurrentLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEditCurrentLayer.Location = new Point(0, 0);
            this.cmbEditCurrentLayer.Name = "cmbEditCurrentLayer";
            this.cmbEditCurrentLayer.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.cmbEditCurrentLayer.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cmbEditCurrentLayer.Size = new Size(265, 20);
            this.cmbEditCurrentLayer.TabIndex = 21;
            this.cmbEditCurrentLayer.SelectedIndexChanged += new EventHandler(this.cmbEditCurrentLayer_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.cmbEditCurrentLayer);
            base.Name = "CtrCurrentLayer";
            base.Size = new Size(265, 21);
            ((ISupportInitialize)this.cmbEditCurrentLayer.Properties).EndInit();
            base.ResumeLayout(false);
        }

        public CtrCurrentLayer()
        {
            this.InitializeComponent();
        }

        private void CtrCurrentLayer_OnAfterScreenDraw(int hdc)
        {
            List<ILayer> list;
            if (!this.CompareLayers(this.MapControl.Map, out list))
            {
                this.InitCurrentLayer(this.EnumLayerType, this.EnumRasterBandCount);
            }
        }

        public void RegisterMapEvent()
        {
            (EnviVars.instance.MapControl as IMapControlEvents2_Event).OnAfterScreenDraw += new IMapControlEvents2_OnAfterScreenDrawEventHandler(this.CtrCurrentLayer_OnAfterScreenDraw);
        }

        public void ReleaseMapEvent()
        {
            (EnviVars.instance.MapControl as IMapControlEvents2_Event).OnAfterScreenDraw -= new IMapControlEvents2_OnAfterScreenDrawEventHandler(this.CtrCurrentLayer_OnAfterScreenDraw);
        }

        public void Init()
        {
            if (this.BeforeInit != null)
            {
                this.BeforeInit();
            }
            this.InitCurrentLayer(this.EnumLayerType, this.EnumRasterBandCount);
        }

        public void SetCurrentLayer(CurrentLayer layer)
        {
            this.cmbEditCurrentLayer.EditValue = layer;
        }

        private void InitCurrentLayer(EnumLayerType layerType, EnumRasterBandCount rasterBandCount)
        {
            this.cmbEditCurrentLayer.Properties.BeginUpdate();
            try
            {
                this.cmbEditCurrentLayer.Properties.Items.Clear();
                List<ILayer> layers = EngineAPI.GetLayers(this.MapControl.ActiveView.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
                this.cmbEditCurrentLayer.Properties.Items.Clear();
                this.cmbEditCurrentLayer.EditValue = null;
                this.m_layers.Clear();
                int i = 0;
                while (i < layers.Count)
                {
                    ILayer layer = layers[i];
                    this.m_layers.Add(new MyDataLayer
                    {
                        Layer = layer,
                        Visible = layer.Visible
                    });
                    if (layer.Visible)
                    {
                        switch (layerType)
                        {
                            case EnumLayerType.Vector:
                                {
                                    IFeatureLayer featureLayer = layer as IFeatureLayer;
                                    if (featureLayer != null)
                                    {
                                        CurrentLayer item = new CurrentLayer
                                        {
                                            Name = featureLayer.Name,
                                            Layer = featureLayer
                                        };
                                        this.cmbEditCurrentLayer.Properties.Items.Add(item);
                                    }
                                    break;
                                }
                            case EnumLayerType.Raster:
                                {
                                    IRasterLayer rasterLayer = layer as IRasterLayer;
                                    if (rasterLayer != null)
                                    {
                                        string format = (rasterLayer.Raster as IRaster2).RasterDataset.Format;
                                        if (!format.StartsWith("Cache", StringComparison.OrdinalIgnoreCase))
                                        {
                                            this.InitLayerDic(rasterBandCount, rasterLayer);
                                        }
                                    }
                                    break;
                                }
                            case EnumLayerType.VectorAndRaster:
                                if (layer is IFeatureLayer || layer is IRasterLayer)
                                {
                                    if (layer is IRasterLayer)
                                    {
                                        IRasterLayer rasterLayer = layer as IRasterLayer;
                                        string format = (rasterLayer.Raster as IRaster2).RasterDataset.Format;
                                        if (format.StartsWith("Cache", StringComparison.OrdinalIgnoreCase))
                                        {
                                            break;
                                        }
                                    }
                                    CurrentLayer item = new CurrentLayer
                                    {
                                        Name = layer.Name,
                                        Layer = layer
                                    };
                                    this.cmbEditCurrentLayer.Properties.Items.Add(item);
                                }
                                break;
                        }
                    }
                IL_245:
                    i++;
                    continue;
                    goto IL_245;
                }
            }
            finally
            {
                this.cmbEditCurrentLayer.Properties.EndUpdate();
            }
            if (this.cmbEditCurrentLayer.Properties.Items.Count > 0)
            {
                this.cmbEditCurrentLayer.EditValue = this.cmbEditCurrentLayer.Properties.Items[0];
                this.CurrentLayer = (this.cmbEditCurrentLayer.EditValue as CurrentLayer).Layer;
            }
            else
            {
                this.CurrentLayer = null;
            }
        }

        private void InitLayerDic(EnumRasterBandCount renderType, IRasterLayer pRasterLayer)
        {
            switch (renderType)
            {
                case EnumRasterBandCount.One:
                    if (pRasterLayer.BandCount <= 1)
                    {
                        this.InitCmbBoxAndLayerDic(pRasterLayer);
                    }
                    break;
                case EnumRasterBandCount.MoreThanOne:
                    if (pRasterLayer.BandCount > 1)
                    {
                        this.InitCmbBoxAndLayerDic(pRasterLayer);
                    }
                    break;
                case EnumRasterBandCount.Any:
                    this.InitCmbBoxAndLayerDic(pRasterLayer);
                    break;
            }
        }

        private void InitCmbBoxAndLayerDic(IRasterLayer pRasterLayer)
        {
            CurrentLayer item = new CurrentLayer
            {
                Name = pRasterLayer.Name,
                Layer = pRasterLayer
            };
            this.cmbEditCurrentLayer.Properties.Items.Add(item);
        }

        private void cmbEditCurrentLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentLayer = (this.cmbEditCurrentLayer.SelectedItem as CurrentLayer).Layer;
            if (this.OnSelectChanged != null)
            {
                this.OnSelectChanged(this.CurrentLayer);
            }
        }

        private bool CompareLayers(IMap map, out List<ILayer> dataLayers)
        {
            dataLayers = EngineAPI.GetLayers(map, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
            bool result;
            if (dataLayers.Count != this.m_layers.Count)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < dataLayers.Count; i++)
                {
                    ILayer layer = dataLayers[i];
                    MyDataLayer myDataLayer = this.m_layers[i];
                    if (layer != myDataLayer.Layer || myDataLayer.Visible != layer.Visible)
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }
    }
}
