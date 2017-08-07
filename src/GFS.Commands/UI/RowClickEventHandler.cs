// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="RowClickEventHandler.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Delegate RowClickEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="RowClickEventArgs"/> instance containing the event data.</param>
    public delegate void RowClickEventHandler(object sender, RowClickEventArgs e);
}
