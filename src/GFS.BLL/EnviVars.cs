// ***********************************************************************
// Assembly         : SDJT.System
// Author           : Admin
// Created          : 03-30-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="EnviVars.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
//using SDJT.Const;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class EnviVars.
    /// </summary>
    public class EnviVars
    {
        /// <summary>
        /// The instance
        /// </summary>
        public static readonly EnviVars instance;

        /// <summary>
        /// Gets or sets the current document.
        /// </summary>
        /// <value>The current document.</value>
        public string CurrentDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the select element tool.
        /// </summary>
        /// <value>The select element tool.</value>
        public ITool SelectElementTool
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the toc control.
        /// </summary>
        /// <value>The toc control.</value>
        public ITOCControl2 TOCControl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the page layout control.
        /// </summary>
        /// <value>The page layout control.</value>
        public IPageLayoutControl2 PageLayoutControl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the map control.
        /// </summary>
        /// <value>The map control.</value>
        public IMapControl3 MapControl
        {
            get;
            set;
        }
        private IDLModel m_IdlModel=null;
        public IDLModel IdlModel
        {
            get
            {
                if (this.m_IdlModel == null)
                {
                    this.m_IdlModel = new IDLModel(ConstDef.PATH_IDL);
                }
                return this.m_IdlModel;
            }
            set
            {
                this.m_IdlModel = value;
            }
        }
        /// <summary>
        /// Gets or sets the main form.
        /// </summary>
        /// <value>The main form.</value>
        public System.Windows.Forms.Form MainForm
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the layer panel.
        /// </summary>
        /// <value>The layer panel.</value>
        public DockPanel LayerPanel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the table panel.
        /// </summary>
        /// <value>The table panel.</value>
        public DockPanel TablePanel
        {
            get;
            set;
        }
        public ControlContainer TableContainer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the recent files control.
        /// </summary>
        /// <value>The recent files control.</value>
        public ImageListBoxControl RecentFilesCtrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the engine editor.
        /// </summary>
        /// <value>The engine editor.</value>
        public IEngineEditor2 EngineEditor
        {
            get;
            set;
        }

        //public User CurrentUser
        //{
        //    get;
        //    set;
        //}


        /// <summary>
        /// Gets or sets a value indicating whether [eagle visible].
        /// </summary>
        /// <value><c>true</c> if [eagle visible]; otherwise, <c>false</c>.</value>
        public bool EagleVisible
        {
            get;
            set;
        }
        /// <summary>
        /// 任务历史管理对象
        /// </summary>
        public TaskHistory history
        {
            get;
            set;
        }
        /// <summary>
        /// 状态栏显示当前的XY坐标
        /// </summary>
        public BarItem barItemXY
        {
            get;
            set;
        }
        /// <summary>
        /// 状态栏显示的栅格图层当前像元信息
        /// </summary>
        public BarItem barItemRaster
        {
            get;
            set;
        }
        public string CurrentTask
        {
            get;
            set;
        }
        public long taskID
        {
            get;
            set;
        }
        public TaskState taskState
        {
            set;
            get;
        }
        private GPExecutor m_gpExecutor = null;
        public GPExecutor GpExecutor
        {
            get
            {
                if (this.m_gpExecutor == null)
                {
                    this.m_gpExecutor = new GPExecutor();
                }
                return this.m_gpExecutor;
            }
            //set
            //{
            //    this.m_gpExecutor = value;
            //}
        }
        /// <summary>
        /// Prevents a default instance of the <see cref="EnviVars" /> class from being created.
        /// </summary>
        private EnviVars()
        {
            try
            {
                this.m_gpExecutor = new GPExecutor();
                this.m_IdlModel = new IDLModel(ConstDef.PATH_IDL);
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Initializes static members of the <see cref="EnviVars" /> class.
        /// </summary>
        static EnviVars()
        {
            EnviVars.instance = new EnviVars();
        }
    }
}
