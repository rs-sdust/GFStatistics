// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmLableLyr.cs" company="SDJT">
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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using SDJT.Sys;
using SDJT.Common;
using SDJT.Const;
using SDJT.Carto;
using ESRI.ArcGIS.Controls;
using SDJT.Log;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmLableLyr.
    /// </summary>
    public partial class frmLableLyr : DevExpress.XtraEditors.XtraForm
    {
        private Logger m_logger = new Logger();

        /// <summary>
        /// The _feature lyr
        /// </summary>
        private IFeatureLayer _featureLyr;

        /// <summary>
        /// The _p map
        /// </summary>
        private IMap _pMap;

        /// <summary>
        /// The _p text symbol
        /// </summary>
        private ITextSymbol _pTextSymbol;

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "请选择标注字段！";
        /// <summary>
        /// Initializes a new instance of the <see cref="frmLableLyr"/> class.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        /// <param name="featureLyr">The feature lyr.</param>
        public frmLableLyr(IMap pMap, IFeatureLayer featureLyr)
        {
            InitializeComponent();
            this._featureLyr = featureLyr;
            this._pMap = pMap;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel2);
        }

        /// <summary>
        /// Handles the Load event of the frmLableLyr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmLableLyr_Load(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer = this._featureLyr as IGeoFeatureLayer;
            this.chkIsLable.Checked = geoFeatureLayer.DisplayAnnotation;
            this.cmbField.InitialFields(this._featureLyr.FeatureClass);
            IAnnotateLayerPropertiesCollection annotationProperties = geoFeatureLayer.AnnotationProperties;
            for (int i = 0; i < annotationProperties.Count; i++)
            {
                IAnnotateLayerProperties annotateLayerProperties;
                IElementCollection elementCollection;
                IElementCollection elementCollection2;
                annotationProperties.QueryItem(i, out annotateLayerProperties, out elementCollection, out elementCollection2);
                ILabelEngineLayerProperties labelEngineLayerProperties = annotateLayerProperties as ILabelEngineLayerProperties;
                if (labelEngineLayerProperties != null)
                {
                    string text = labelEngineLayerProperties.Expression;
                    text = text.Replace("[", "");
                    text = text.Replace("]", "");
                    if (text != "")
                    {
                        this.cmbField.FieldName = text;
                    }
                    this._pTextSymbol = labelEngineLayerProperties.Symbol;
                    if (this._pTextSymbol.Text == "")
                    {
                        this._pTextSymbol.Text = "ABC";
                    }
                    if (!this.chkIsLable.Checked)
                    {
                        this._pTextSymbol.Size = 12.0;
                    }
                    if (this._pTextSymbol.Color != null)
                    {
                        this.cmbColor.Color = ColorTranslator.FromOle(this._pTextSymbol.Color.RGB);
                    }
                    else
                    {
                        this.cmbColor.Color = Color.Black;
                    }
                    this.cmbFont.EditValue = this._pTextSymbol.Font.Name;
                    this.cmbSize.Value = Convert.ToDecimal(this._pTextSymbol.Size);
                    IFormattedTextSymbol formattedTextSymbol = this._pTextSymbol as IFormattedTextSymbol;
                    if (formattedTextSymbol.Font.Bold)
                    {
                        this.btnBold.Checked = true;
                    }
                    if (formattedTextSymbol.Font.Italic)
                    {
                        this.btnItalic.Checked = true;
                    }
                    if (formattedTextSymbol.Font.Underline)
                    {
                        this.btnUnderLine.Checked = true;
                    }
                    if (formattedTextSymbol.Font.Strikethrough)
                    {
                        this.btnStrikeThrough.Checked = true;
                    }
                    this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
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
            try
            {
                if (!this.chkIsLable.Checked)
                {
                    IGeoFeatureLayer geoFeatureLayer = this._featureLyr as IGeoFeatureLayer;
                    geoFeatureLayer.DisplayAnnotation = this.chkIsLable.Checked;
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    string fieldName = this.cmbField.FieldName;
                    if (fieldName != "")
                    {
                        IColor color = SymbleAPI.ConvertColorToIColor(this.cmbColor.Color);
                        double num = Convert.ToDouble(this.cmbSize.Value);
                        double dRefScale = -1.0;
                        LayerAPI.AddLayerLable(this._pMap, this._featureLyr, fieldName, this._pTextSymbol, dRefScale);
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        XtraMessageBox.Show(frmLableLyr.MSG01, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                if (base.DialogResult == DialogResult.OK)
                {
                    //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                }
            }
            catch (Exception ex)
            {
                this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbColor_EditValueChanged(object sender, EventArgs e)
        {
            this._pTextSymbol.Color = SymbleAPI.ConvertColorToIColor(this.cmbColor.Color);
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the btnBold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBold_CheckedChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            if (this.btnBold.Checked)
            {
                fontDisp.Bold = true;
            }
            else
            {
                fontDisp.Bold = false;
            }
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the btnItalic control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnItalic_CheckedChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            if (this.btnItalic.Checked)
            {
                fontDisp.Italic = true;
            }
            else
            {
                fontDisp.Italic = false;
            }
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the btnUnderLine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUnderLine_CheckedChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            if (this.btnUnderLine.Checked)
            {
                fontDisp.Underline = true;
            }
            else
            {
                fontDisp.Underline = false;
            }
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the btnStrikeThrough control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStrikeThrough_CheckedChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            if (this.btnStrikeThrough.Checked)
            {
                fontDisp.Strikethrough = true;
            }
            else
            {
                fontDisp.Strikethrough = false;
            }
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cmbFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbFont_EditValueChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            fontDisp.Name = this.cmbFont.EditValue.ToString();
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the ValueChanged event of the cmbSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbSize_ValueChanged(object sender, EventArgs e)
        {
            stdole.IFontDisp fontDisp = this._pTextSymbol.Font;
            fontDisp.Size = Convert.ToDecimal(this.cmbSize.Value);
            this._pTextSymbol.Font = fontDisp;
            this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
        }

        /// <summary>
        /// Handles the Click event of the btnStyle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            frmSymbolSelector frmSymbolSelect = new frmSymbolSelector();
            IStyleGalleryItem item = frmSymbolSelect.GetItem(esriSymbologyStyleClass.esriStyleClassTextSymbols, this._pTextSymbol as ISymbol);
            if (item != null)
            {
                this._pTextSymbol = (ITextSymbol)item.Item;
                this.cmbColor.Color = ColorTranslator.FromOle(this._pTextSymbol.Color.RGB);
                this.cmbFont.EditValue = this._pTextSymbol.Font.Name;
                this.cmbSize.Text = this._pTextSymbol.Size.ToString();
                this.picturePreview.Image = CommonAPI.PreviewItem(this._pTextSymbol as ISymbol, this.picturePreview.Width, this.picturePreview.Height);
            }
        }

        /// <summary>
        /// Handles the HelpButtonClicked event of the frmLayerLable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void frmLayerLable_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            //HelpManager.ShowHelp(this);
        }

    }
}