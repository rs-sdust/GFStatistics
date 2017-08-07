// ***********************************************************************
// Assembly         : SDJT.Common
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-06-2016
// ***********************************************************************
// <copyright file="WorkspaceInfo.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Class WorkspaceInfo.</summary>
// ***********************************************************************
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The Common namespace.
/// </summary>
namespace SDJT.Common
{
    /// <summary>
    /// Class WorkspaceInfo.
    /// </summary>
    public class WorkspaceInfo
    {
        /// <summary>
        /// Gets or sets the workspace.
        /// </summary>
        /// <value>The workspace.</value>
        public IWorkspace Workspace
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public DataType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get;
            set;
        }
    }
}
