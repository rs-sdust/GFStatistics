// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CtrlFieldCmb.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class CtrlFieldCmb.
    /// </summary>
    public partial class CtrlFieldCmb : UserControl
    {
        /// <summary>
        /// The string field name
        /// </summary>
        private string strFieldName = "";
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName
        {
            get
            {
                return this.strFieldName;
            }
            set
            {
                this.strFieldName = value;
                this.cmbFields.SelectedItem = this.strFieldName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtrlFieldCmb"/> class.
        /// </summary>
        public CtrlFieldCmb()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initials the fields.
        /// </summary>
        /// <param name="pFeatClass">The p feat class.</param>
        public void InitialFields(IFeatureClass pFeatClass)
        {
            IFields fields = pFeatClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    this.cmbFields.Properties.Items.Add(field.Name);
                }
            }
        }

        /// <summary>
        /// Initials the fields.
        /// </summary>
        /// <param name="pLayerFields">The p layer fields.</param>
        public void InitialFields(ILayerFields pLayerFields)
        {
            for (int i = 0; i < pLayerFields.FieldCount; i++)
            {
                IField field = pLayerFields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    this.cmbFields.Properties.Items.Add(field.AliasName);
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbFields control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.strFieldName = this.cmbFields.SelectedItem.ToString();
        }
    }
}
