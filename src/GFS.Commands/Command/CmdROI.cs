// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-11-2017
// ***********************************************************************
// <copyright file="CmdROI.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>ICommand for select ROI</summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using GFS.BLL;
using GFS.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GFS.Commands
{
	[ClassInterface(ClassInterfaceType.None), Guid("9744edd2-e928-497e-be22-0b9279452601"), ProgId("HTES.TAS.Commands.CmdROI")]
	public sealed class CmdROI : BaseCommand
	{
		private IHookHelper m_hookHelper;

		public override bool Enabled
		{
			get
			{
				List<ILayer> layers = EngineAPI.GetLayers(this.m_hookHelper.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
				bool result;
				foreach (ILayer current in layers)
				{
					if (current is IRasterLayer)
					{
						IRasterLayer rasterLayer = current as IRasterLayer;
						string format = (rasterLayer.Raster as IRaster2).RasterDataset.Format;
						if (format.StartsWith("Cache", StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
					}
					if (EnviVars.instance.MapControl.SpatialReference != null)
					{
						result = true;
						return result;
					}
				}
				result = false;
				return result;
			}
		}

		[ComRegisterFunction, ComVisible(false)]
		private static void RegisterFunction(Type registerType)
		{
			CmdROI.ArcGISCategoryRegistration(registerType);
		}

		[ComUnregisterFunction, ComVisible(false)]
		private static void UnregisterFunction(Type registerType)
		{
			CmdROI.ArcGISCategoryUnregistration(registerType);
		}

		private static void ArcGISCategoryRegistration(Type registerType)
		{
			string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
			ControlsCommands.Register(cLSID);
		}

		private static void ArcGISCategoryUnregistration(Type registerType)
		{
			string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
			ControlsCommands.Unregister(cLSID);
		}

		public CmdROI()
		{
			this.m_category = "barItem";
			this.m_caption = "样本选取";
			this.m_message = "样本选取";
			this.m_toolTip = "样本选取";
			this.m_name = "CmdROI";
		}

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

		public override void OnClick()
		{
			ROIManager.instance.FrmROI.Owner = EnviVars.instance.MainForm;
            //ControlWrapper.SetFormLocation(ROIManager.instance.FrmROI, FormPositionMode.LeftBottom);
			ROIManager.instance.FrmROI.Show();
		}
	}
}
