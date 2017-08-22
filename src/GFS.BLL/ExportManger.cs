// ***********************************************************************
// Assembly         : SDJT.System
// Author           : Ricker Yan
// Created          : 04-06-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-06-2016
// ***********************************************************************
// <copyright file="ExportManger.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>导出地图</summary>
// ***********************************************************************
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class ExportManager.
    /// </summary>
    public class ExportManager
    {
        /// <summary>
        /// Exports the map extent.
        /// </summary>
        /// <param name="activeView">The active view.</param>
        /// <param name="outRect">The out rect.</param>
        /// <param name="sOutputPath">The output file path.</param>
        /// <param name="dResolution">The d resolution.</param>
        /// <returns><c>true</c> if succeed, <c>false</c> otherwise.</returns>
        public bool ExportMapExtent(IActiveView activeView, Size outRect, string sOutputPath, double dResolution)
        {
            bool result;
            try
            {
                if (activeView == null)
                {
                    result = false;
                }
                else
                {
                    IExport export = null;
                    if (sOutputPath.EndsWith(".jpg"))

                    {
                        export = new ExportJPEGClass();
                    }
                    else if (sOutputPath.EndsWith(".tif"))

                    {
                        export = new ExportTIFFClass();
                    }
                    else if (sOutputPath.EndsWith(".bmp"))

                    {
                        export = new ExportBMPClass();
                    }
                    else if (sOutputPath.EndsWith(".emf"))

                    {
                        export = new ExportEMFClass();
                    }
                    else if (sOutputPath.EndsWith(".png"))

                    {
                        export = new ExportPNGClass();
                    }
                    else if (sOutputPath.EndsWith(".gif"))

                    {
                        export = new ExportGIFClass();
                    }
                    export.ExportFileName = sOutputPath;
                    IEnvelope extent = activeView.Extent;
                    export.Resolution = dResolution;
                    tagRECT tagRECT = default(tagRECT);
                    tagRECT.left = (tagRECT.top = 0);
                    tagRECT.right = outRect.Width;
                    tagRECT.bottom = (int)((double)tagRECT.right * extent.Height / extent.Width);
                    IEnvelope envelope = new EnvelopeClass();
                    envelope.PutCoords((double)tagRECT.left, (double)tagRECT.top, (double)tagRECT.right, (double)tagRECT.bottom);
                    export.PixelBounds = envelope;
                    ITrackCancel trackCancel = new CancelTrackerClass();
                    export.TrackCancel = trackCancel;
                    trackCancel.Reset();
                    trackCancel.CancelOnKeyPress = true;
                    trackCancel.CancelOnClick = false;
                    trackCancel.ProcessMessages = true;
                    int hDC = export.StartExporting();
                    activeView.Output(hDC, (int)((short)export.Resolution), ref tagRECT, extent, trackCancel);
                    bool flag = trackCancel.Continue();
                    if (flag)
                    {
                        export.FinishExporting();
                        export.Cleanup();
                    }
                    else
                    {
                        export.Cleanup();
                    }
                    flag = trackCancel.Continue();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Saves the current to image.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="outRect">The out rect.</param>
        /// <param name="envelope">The envelope.</param>
        /// <returns>Image.</returns>
        public Image SaveCurrentToImage(IMap map, Size outRect, IEnvelope envelope)
        {
            tagRECT tagRECT = default(tagRECT);
            tagRECT.left = (tagRECT.top = 0);
            tagRECT.right = outRect.Width;
            tagRECT.bottom = outRect.Height;
            Image result;
            try
            {
                IActiveView activeView = (IActiveView)map;
                Image image = new Bitmap(outRect.Width, outRect.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.FillRectangle(Brushes.White, 0, 0, outRect.Width, outRect.Height);
                int dpi = (int)((double)outRect.Width / envelope.Width);
                activeView.Output(graphics.GetHdc().ToInt32(), dpi, ref tagRECT, envelope, null);
                graphics.ReleaseHdc();
                result = image;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Initializes static members of the <see cref="ExportManager" /> class.
        /// </summary>
        static ExportManager()
        {
        }
    }
}
