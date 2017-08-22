// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-11-2017
// ***********************************************************************
// <copyright file="ROIManager.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>mangage ROI</summary>
// ***********************************************************************
using GFS.BLL;
using System;
using System.Windows.Forms;
using GFS.Commands.UI;
using GFS.Common;

namespace GFS.Commands
{
    public class ROIManager
    {
        public static readonly ROIManager instance = new ROIManager();

        private FrmROI m_FrmROI = null;

        private GPExecutor m_gpExecutor = null;

        public FrmROI FrmROI
        {
            get
            {
                if (this.m_FrmROI == null || this.m_FrmROI.IsDisposed)
                {
                    this.m_FrmROI = new FrmROI();
                    this.m_FrmROI.FormClosed += delegate(object w, System.Windows.Forms.FormClosedEventArgs ev)
                    {
                        EnviVars.instance.MapControl.CurrentTool = null;
                        this.m_FrmROI = null;
                    };
                }
                return this.m_FrmROI;
            }
        }

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
            set
            {
                this.m_gpExecutor = value;
            }
        }
    }
}
