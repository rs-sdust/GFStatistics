// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="CmdZoomToRasterResolution.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using GFS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
//using SDJT.Log;
//using SDJT.Const;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdZoomToRasterResolution. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), Guid("8fd75dec-baa5-4ac4-9d6d-12ef12b9ac77"), ProgId("GFS.Commands.CmdZoomToRasterResolution")]
    public sealed class CmdZoomToRasterResolution : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

        /// <summary>
        /// The m_raster layer
        /// </summary>
        private IRasterLayer m_rasterLayer = null;

        /// <summary>
        /// The enabled state of this command, determines whether the command is usable.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        /// <remarks>Note to inheritors: By default, the 
        /// <see cref="F:ESRI.ArcGIS.ADF.BaseClasses.BaseCommand.m_enabled" /> field is returned from this member. 
        ///             It is possible to override this member, if you should need to provide a different implementation.</remarks>
        public override bool Enabled
        {
            get
            {
                this.m_rasterLayer = (CommandAPI.GetCurrentLayer(this.m_hookHelper) as IRasterLayer);
                return this.m_rasterLayer != null;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdZoomToRasterResolution.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdZoomToRasterResolution.ArcGISCategoryUnregistration(registerType);
        }

        /// <summary>
        /// Arcs the gis category registration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(cLSID);
        }

        /// <summary>
        /// Arcs the gis category unregistration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(cLSID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdZoomToRasterResolution"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdZoomToRasterResolution()
        {
            this.m_category = "TocMenu";
            this.m_caption = "缩放到实际像素";
            this.m_message = "缩放到实际像素";
            this.m_toolTip = "缩放到实际像素";
            this.m_name = "CmdZoomToRasterResolution";
        }

        /// <summary>
        /// Called when the command is created inside the application.
        /// </summary>
        /// <param name="hook">A reference to the application in which the command was created.
        ///             The hook may be an IApplication reference (for commands created in ArcGIS Desktop applications)
        ///             or an IHookHelper reference (for commands created on an Engine ToolbarControl).</param>
        /// <remarks>Note to inheritors: classes inheriting from BaseCommand must always 
        ///             override the OnCreate method. Use this method to store a reference to the host 
        ///             application, passed in via the hook parameter.</remarks>
        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        /// <summary>
        /// Called when the user clicks a command.
        /// </summary>
        /// <remarks>Note to inheritors: override OnClick and use this method to 
        ///             perform the actual work of the custom command.</remarks>
        public override void OnClick()
        {
            if (this.m_rasterLayer != null)
            {
                //Logger logger = new Logger();
                try
                {
                    if (this.m_hookHelper.FocusMap.SpatialReference != null && !(this.m_hookHelper.FocusMap.SpatialReference is IUnknownCoordinateSystem))
                    {
                        double mapScale = this.m_hookHelper.FocusMap.MapScale;
                        double num = MapAPI.ConvertPixelsToMapUnits(this.m_hookHelper.FocusMap as IActiveView, (this.m_rasterLayer.Raster as IGeoDataset).SpatialReference, 1.0, false);
                        if (num != 0.0)
                        {
                            IRasterProps rasterProps = this.m_rasterLayer.Raster as IRasterProps;
                            double x = rasterProps.MeanCellSize().X;
                            double mapScale2 = mapScale * x / num;
                            (this.m_hookHelper.FocusMap as IActiveView).Extent = this.m_rasterLayer.AreaOfInterest;
                            this.m_hookHelper.FocusMap.MapScale = mapScale2;
                            this.m_hookHelper.ActiveView.Refresh();
                            //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0106, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0106, ex);
                    Log.WriteLog(typeof(CmdZoomToRasterResolution), ex);
                }
            }
        }
    }
}
