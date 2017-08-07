// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmSymbolSelector.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using SDJT.Sys;
using System.IO;
//using SDJT.Const;
using GFS.BLL;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using GFS.Carto;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class frmSymbolSelector.
    /// </summary>
    public partial class frmSymbolSelector : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The _style gallery item
        /// </summary>
        public IStyleGalleryItem _styleGalleryItem;
        /// <summary>
        /// The _fill symble
        /// </summary>
        private IFillSymbol _fillSymble;
        /// <summary>
        /// The _marker symble
        /// </summary>
        private IMarkerSymbol _markerSymble;
        /// <summary>
        /// The _line symble
        /// </summary>
        private ILineSymbol _lineSymble;
        /// <summary>
        /// The _TXT symble
        /// </summary>
        private ITextSymbol _txtSymble;
        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01;
        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02;
        /// <summary>
        /// The ms G03
        /// </summary>
        private static string MSG03;
        /// <summary>
        /// The ok
        /// </summary>
        private string ok;

        /// <summary>
        /// Initializes static members of the <see cref="frmSymbolSelector"/> class.
        /// </summary>
        static frmSymbolSelector()
        {
            frmSymbolSelector.MSG01 = "当前符号";
            frmSymbolSelector.MSG02 = "米";
            frmSymbolSelector.MSG03 = "千米";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmSymbolSelector"/> class.
        /// </summary>
        public frmSymbolSelector()
        {
            InitializeComponent();
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            this.cmbScaleBarUnit.Properties.Items.Add(frmSymbolSelector.MSG02);
            this.cmbScaleBarUnit.Properties.Items.Add(frmSymbolSelector.MSG03);
        }

        /// <summary>
        /// Handles the Load event of the frmSymbolSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmSymbolSelector_Load(object sender, EventArgs e)
        {
            if (File.Exists(GFS.BLL.ConstDef.FILE_STYLE))
            {
                this.axSymbologyControl1.LoadStyleFile(GFS.BLL.ConstDef.FILE_STYLE);
            }
            this.Init();
        }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            this.cmbMarkerAngel.ValueChanged += new EventHandler(this.cmbMarkerAngel_EditValueChanged);
            this.cmbMarkerSize.ValueChanged += new EventHandler(this.cmbMarkerSize_EditValueChanged);
            this.cmbFillWidth.ValueChanged += new EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
            this.cmbLineWith.ValueChanged += new EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
            this.cmbFillColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
            this.cmbLineColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
            this.cmbMarkerColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
            this.cmbFillLineColor.EditValueChanged += new EventHandler(this.cmbFillOutlineColor_EditValueChanged);
            try
            {
                switch (this.axSymbologyControl1.StyleClass)
                {
				    case esriSymbologyStyleClass.esriStyleClassNorthArrows:
                        this.ViewSymble();
                            break;
				    case esriSymbologyStyleClass.esriStyleClassScaleBars:
                            //this.ATkkXSKKpfdmXX();
                            this.panelScaleBar.Visible = true;
                            this.ViewSymble();
                            break;
                    case esriSymbologyStyleClass.esriStyleClassScaleTexts:
					    //this.AG5IDo6GN(vpC.Visible = false;
                            this.ViewSymble();
                            break;
                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:
					    if (this._styleGalleryItem != null)
                        {
                            this._fillSymble = (this._styleGalleryItem.Item as IFillSymbol);
                            if (this._fillSymble.Color != null)
                            {
                                IRgbColor rgbColor = new RgbColorClass();
                                rgbColor.RGB = this._fillSymble.Color.RGB;
                                this.cmbFillColor.Color = this.RGBToColor(rgbColor);
                            }
                            else
                            {
                                this.cmbFillColor.Color = Color.Empty;
                            }
                            if (this._fillSymble.Outline != null && this._fillSymble.Outline.Color != null)
                            {
                                IRgbColor rgbColor2 = new RgbColorClass();
                                rgbColor2.RGB = this._fillSymble.Outline.Color.RGB;
                                this.cmbFillLineColor.Color = this.RGBToColor(rgbColor2);
                            }
                            else
                            {
                                this.cmbFillLineColor.Color = Color.Empty;
                            }
                            this.cmbFillWidth.Value = Convert.ToDecimal(this._fillSymble.Outline.Width);
                        }
                            //this.AUMM5FA5sgdJiat.SelectedTabPage = this.AVsbnC0QV4ZAblRWJQ;
                            this.panelFill.Visible = true;
                            this.ViewSymble();
                            break;
                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:
					    if (this._styleGalleryItem != null)
                        {
                            this._lineSymble = (this._styleGalleryItem.Item as ILineSymbol);
                            if (this._lineSymble.Color != null)
                            {
                                IRgbColor rgbColor3 = new RgbColorClass();
                                rgbColor3.RGB = this._lineSymble.Color.RGB;
                                this.cmbLineColor.Color = this.RGBToColor(rgbColor3);
                            }
                            else
                            {
                                this.cmbLineColor.Color = Color.Empty;
                            }
                            this.cmbLineWith.Value = Convert.ToDecimal(this._lineSymble.Width);
                        }
                            //this.AUMM5FA5sgdJiat.SelectedTabPage = this.A)WxLsGhbBQBQW(v0KV;
                            this.panelLine.Visible = true;
                            this.ViewSymble();
                            break;
                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
					    if (this._styleGalleryItem != null)
                        {
                            this._markerSymble = (this._styleGalleryItem.Item as IMarkerSymbol);
                            IRgbColor rgbColor4 = new RgbColorClass();
                            if (this._markerSymble.Color != null)
                            {
                                rgbColor4.RGB = this._markerSymble.Color.RGB;
                                this.cmbMarkerColor.Color = this.RGBToColor(rgbColor4);
                            }
                            else
                            {
                                this.cmbMarkerColor.Color = Color.Empty;
                            }
                            this.cmbMarkerSize.Value = Convert.ToDecimal(this._markerSymble.Size);
                            this.cmbMarkerAngel.Value = Convert.ToDecimal(this._markerSymble.Angle);
                        }
                            this.panelMarker.Visible = true;
                            this.ViewSymble();
                            break;
                    case esriSymbologyStyleClass.esriStyleClassTextSymbols:
					    if (this._styleGalleryItem != null)
                        {
                            this._txtSymble = (this._styleGalleryItem.Item as ITextSymbol);
                            if (this.cmbTxtColor.Color != null)
                            {
                                IRgbColor rgbColor5 = new RgbColorClass();
                                rgbColor5.RGB = this._txtSymble.Color.RGB;
                                this.cmbTxtColor.Color = this.RGBToColor(rgbColor5);
                            }
                            else
                            {
                                this.cmbTxtColor.Color = Color.Empty;
                            }
                            this.cmbTxtSize.Value = Convert.ToDecimal(this._txtSymble.Size);
                            this.cmbTxtFont.EditValue = this._txtSymble.Font.Name;
                        }
                            this.panelTxt.Visible = true;
                            this.ViewSymble();
                            break;
                }
            }
            finally
            {
                this.cmbMarkerAngel.ValueChanged += new EventHandler(this.cmbMarkerAngel_EditValueChanged);
                this.cmbMarkerSize.ValueChanged += new EventHandler(this.cmbMarkerSize_EditValueChanged);
                this.cmbFillWidth.ValueChanged += new EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
                this.cmbLineWith.ValueChanged += new EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
                this.cmbFillColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
                this.cmbLineColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
                this.cmbMarkerColor.EditValueChanged += new EventHandler(this.cmbColor_EditValueChanged);
                this.cmbFillLineColor.EditValueChanged += new EventHandler(this.cmbFillOutlineColor_EditValueChanged);
            }
        }

        /// <summary>
        /// Views the symble.
        /// </summary>
        private void ViewSymble()
        {
            if (this._styleGalleryItem != null)
            {
                ISymbologyStyleClass styleClass = this.axSymbologyControl1.GetStyleClass(this.axSymbologyControl1.StyleClass);
                stdole.IPictureDisp pictureDisp = styleClass.PreviewItem(this._styleGalleryItem, this.pictureEdit.Width, this.pictureEdit.Height);
                Image image = Image.FromHbitmap(new IntPtr(pictureDisp.Handle));
                this.pictureEdit.Image = image;
            }
        }
        /// <summary>
        /// RGBs to color.
        /// </summary>
        /// <param name="rgbColor">Color of the RGB.</param>
        /// <returns>Color.</returns>
        private Color RGBToColor(IRgbColor rgbColor)
		{
			return ColorTranslator.FromOle(rgbColor.RGB);
		}
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="styleClass">The style class.</param>
        /// <param name="styleItem">The style item.</param>
        /// <returns>IStyleGalleryItem.</returns>
        public IStyleGalleryItem GetItem(esriSymbologyStyleClass styleClass, object styleItem)
        {
            this._styleGalleryItem = null;
            this.axSymbologyControl1.StyleClass = styleClass;
            ISymbologyStyleClass styleClass2 = this.axSymbologyControl1.GetStyleClass(styleClass);
            if (styleItem != null)
            {
                this._styleGalleryItem = new ServerStyleGalleryItemClass();
                this._styleGalleryItem.Item = styleItem;
                this._styleGalleryItem.Name = frmSymbolSelector.MSG01;
                styleClass2.AddItem(this._styleGalleryItem, 0);
                styleClass2.SelectItem(0);
            }
            base.ShowDialog();
            return this._styleGalleryItem;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbMarkerSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbMarkerSize_EditValueChanged(object sender, EventArgs e)
        {
            if (this._styleGalleryItem.Item != null)
            {
                double size = Convert.ToDouble(cmbMarkerSize.Value);
                this._markerSymble = (this._styleGalleryItem.Item as IMarkerSymbol);
                this._markerSymble.Size = size;
                this.ViewSymble();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbMarkerAngel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbMarkerAngel_EditValueChanged(object sender, EventArgs e)
        {
            if (this._styleGalleryItem.Item != null)
            {
                this._markerSymble = (this._styleGalleryItem.Item as IMarkerSymbol);
                this._markerSymble.Angle = Convert.ToDouble(this.cmbMarkerAngel.Value);
                this.ViewSymble();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbFillOutlineColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbFillOutlineColor_EditValueChanged(object sender, EventArgs e)
        {
            if (this._styleGalleryItem != null)
            {
                IColor color = SymbleAPI.ConvertColorToIColor(cmbFillLineColor.Color);
                IFillSymbol fillSymbol = this._styleGalleryItem.Item as IFillSymbol;
                ILineSymbol outline = fillSymbol.Outline;
                outline.Color = color;
                fillSymbol.Outline = outline;
                this.ViewSymble();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbFillAndLineWidth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbFillAndLineWidth_EditValueChanged(object sender, EventArgs e)
        {
            if (this._styleGalleryItem.Item != null)
            {
                switch (this.axSymbologyControl1.StyleClass)

                {
				case esriSymbologyStyleClass.esriStyleClassFillSymbols:
				{
                        this._fillSymble = (this._styleGalleryItem.Item as IFillSymbol);
                        ILineSymbol outline = this._fillSymble.Outline;
                        outline.Width = Convert.ToDouble(this.cmbFillWidth.Value);
                        this._fillSymble.Outline = outline;
                        break;
                    }
				case esriSymbologyStyleClass.esriStyleClassLineSymbols:
					this._lineSymble = (this._styleGalleryItem.Item as ILineSymbol);
                    this._lineSymble.Width = Convert.ToDouble(this.cmbLineWith.Value);
                        break;
                }
                this.ViewSymble();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbColor_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Axes the symbology control1_ on item selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            this._styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
            this.Init();
        }

        /// <summary>
        /// Handles the Click event of the btnSelectStyle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectStyle_Click(object sender, EventArgs e)
        {
            string startupPath = System.Windows.Forms.Application.StartupPath;
            string path = Path.Combine(startupPath, "styles");
            string[] files = Directory.GetFiles(path, "*.ServerStyle");
            System.Windows.Forms.MenuItem[] array = new System.Windows.Forms.MenuItem[files.Length + 1];
            for (int i = 0; i < files.Length; i++)
            {
                array[i] = new System.Windows.Forms.MenuItem(Path.GetFileNameWithoutExtension(files[i]));
                array[i].Name = files[i];
                array[i].Click += new EventHandler(this.SelectStyleMenuItem_Click);
            }
            array[files.Length] = new System.Windows.Forms.MenuItem("更多" + "...", new EventHandler(this.MenuItemMore_Click));
            System.Windows.Forms.ContextMenu contextMenu = new System.Windows.Forms.ContextMenu(array);
            contextMenu.Show(this, this.btnSelectStyle.Location);
        }

        /// <summary>
        /// Handles the Click event of the SelectStyleMenuItem control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectStyleMenuItem_Click(object obj, EventArgs eventArgs)
        {
            System.Windows.Forms.MenuItem menuItem = (System.Windows.Forms.MenuItem)obj;
            this.axSymbologyControl1.LoadStyleFile(menuItem.Name);
            this.axSymbologyControl1.Refresh();
            
        }
        /// <summary>
        /// Handles the Click event of the MenuItemMore control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MenuItemMore_Click(object obj, EventArgs eventArgs)
        {
            MapAPI.AddStyleFile(this.axSymbologyControl1, Path.Combine(System.Windows.Forms.Application.StartupPath,"styles"));
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbTxtFont control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbTxtFont_EditValueChanged(object obj, EventArgs eventArgs)
        {
            this._txtSymble = (this._styleGalleryItem.Item as ITextSymbol);
            stdole.IFontDisp font = this._txtSymble.Font;
            font.Name = this.cmbTxtFont.EditValue.ToString();
            this._txtSymble.Font = font;
            this.ViewSymble();
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbTxtSize control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbTxtSize_EditValueChanged(object obj, EventArgs eventArgs)
        {
            decimal size = Convert.ToDecimal(this.cmbTxtSize.Value);
            this._txtSymble = (this._styleGalleryItem.Item as ITextSymbol);
            stdole.IFontDisp font = this._txtSymble.Font;
            font.Size = size;
            this._txtSymble.Font = font;
            this.ViewSymble();
        }

        /// <summary>
        /// Handles the Click event of the btnChangeOutlineStyle control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnChangeOutlineStyle_Click(object obj, EventArgs eventArgs)
        {
            if (this._styleGalleryItem != null)
            {
                this._fillSymble = (this._styleGalleryItem.Item as IFillSymbol);
                if (this._fillSymble != null)
                {
                    ILineSymbol lineSymbol = this._fillSymble.Outline;
                    frmSymbolSelector frmSymbolSelect = new frmSymbolSelector();
                    IStyleGalleryItem item = frmSymbolSelect.GetItem(esriSymbologyStyleClass.esriStyleClassLineSymbols, lineSymbol as ISymbol);
                    if (item != null)
                    {
                        lineSymbol = (item.Item as ILineSymbol);
                        if (lineSymbol.Color != null)
                        {
                            this.cmbFillLineColor.Color = ColorTranslator.FromOle(lineSymbol.Color.RGB);
                        }
                        else
                        {
                            this.cmbFillLineColor.Color = Color.Empty;
                        }
                        this.cmbFillWidth.Value = Convert.ToDecimal(lineSymbol.Width);
                        this._fillSymble.Outline = lineSymbol;
                        this.ViewSymble();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbScaleBarUnit control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbScaleBarUnit_EditValueChanged(object obj, EventArgs eventArgs)
        {
            this.ChangScaleBarUnit();
            this.ViewSymble();
        }

        /// <summary>
        /// Changs the scale bar unit.
        /// </summary>
        private void ChangScaleBarUnit()
        {
            if (this._styleGalleryItem != null)
            {
                IMapSurround mapSurround = this._styleGalleryItem.Item as IMapSurround;
                if (mapSurround != null)
                {
                    IScaleBar scaleBar = mapSurround as IScaleBar;
                    if (scaleBar != null)
                    {
                        if (this.cmbScaleBarUnit.SelectedIndex == 0)
						{
                            scaleBar.Units = esriUnits.esriMeters;
                        }
						else
						{
                            scaleBar.Units = esriUnits.esriKilometers;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ok = "ok";
            base.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._styleGalleryItem = null;
            base.Close();
        }

        /// <summary>
        /// Handles the FormClosed event of the frmSymbolSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void frmSymbolSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ok != "ok")

            {
                this._styleGalleryItem = null;
            }
        }
    }
}