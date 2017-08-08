// ***********************************************************************
// Assembly         : SDJT.Common
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-15-2016
// ***********************************************************************
// <copyright file="CommonAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Class CommonAPI.</summary>
// ***********************************************************************
using DevExpress.XtraEditors; 
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
//using SDJT.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// The Common namespace.
/// </summary>
namespace GFS.Common
{
    /// <summary>
    /// Class CommonAPI.
    /// </summary>
    public class CommonAPI
    {
        /// <summary>
        /// The c_ key
        /// </summary>
        private static readonly string C_KEY = "Software\\Microsoft\\Windows\\CurrentVersion";

        /// <summary>
        /// The key_ feature_ path
        /// </summary>
        public static readonly string KEY_FEATURE_PATH = "FeaturePath";

        /// <summary>
        /// The key_ output_ path
        /// </summary>
        public static readonly string KEY_OUTPUT_PATH = "OutputPath";

        /// <summary>
        /// Gets the path from registry.
        /// </summary>
        /// <param name="sKey">The s key.</param>
        /// <returns>System.String.</returns>
        public static string GetPathFromRegistry(string sKey)
        {
            string text = "";
            using (Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CommonAPI.C_KEY))
            {
                object value = registryKey.GetValue(sKey);
                if (value != null)
                {
                    text = value.ToString();
                }
                registryKey.Close();
            }
            if (string.IsNullOrEmpty(text))
            {
                text = System.IO.Directory.GetCurrentDirectory();
            }
            return text;
        }

        /// <summary>
        /// Converts to double.
        /// </summary>
        /// <param name="objValue">The object value.</param>
        /// <returns>System.Double.</returns>
        public static double ConvertToDouble(object objValue)
        {
            double result = -1.0;
            if (!CommonAPI.IsNullValue(objValue))
            {
                double.TryParse(objValue.ToString(), out result);
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is null value] [the specified object value].
        /// </summary>
        /// <param name="objValue">The object value.</param>
        /// <returns><c>true</c> if [is null value] [the specified object value]; otherwise, <c>false</c>.</returns>
        public static bool IsNullValue(object objValue)
        {
            bool result = false;
            if (objValue == null || System.Convert.IsDBNull(objValue))
            {
                result = true;
            }
            else if (string.IsNullOrWhiteSpace(objValue.ToString()))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Previews the item.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        public static System.Drawing.Bitmap PreviewItem(ISymbol Symbol, int Width, int Height)
        {
            if (Symbol == null)
            {
                return null;
            }
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(Width, Height);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            double resolution = (double)graphics.DpiY;
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(0.0, 0.0, (double)bitmap.Width, (double)bitmap.Height);
            tagRECT tagRECT = default(tagRECT);
            tagRECT.bottom = bitmap.Height;
            tagRECT.left = 0;
            tagRECT.right = bitmap.Width;
            tagRECT.top = 0;
            IDisplayTransformation displayTransformation = new DisplayTransformationClass();
            displayTransformation.VisibleBounds = envelope;
            displayTransformation.Bounds = envelope;
            displayTransformation.set_DeviceFrame(ref tagRECT);
            displayTransformation.Resolution = resolution;
            System.IntPtr hdc = graphics.GetHdc();
            int hDC = hdc.ToInt32();
            Symbol.SetupDC(hDC, displayTransformation);
            IGeometry symbolGeometry = CommonAPI.GetSymbolGeometry(Symbol, envelope);
            Symbol.Draw(symbolGeometry);
            Symbol.ResetDC();
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Gets the symbol geometry.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Envelop">The envelop.</param>
        /// <returns>IGeometry.</returns>
        private static IGeometry GetSymbolGeometry(ISymbol Symbol, IEnvelope Envelop)
        {
            IGeometry result = null;
            if (Symbol is IMarkerSymbol)
            {
                IArea area = Envelop as IArea;
                result = area.Centroid;
            }
            else if (Symbol is ILineSymbol)
            {
                IPolyline polyline = new PolylineClass();
                IPoint point = new PointClass();
                point.PutCoords(Envelop.XMin, (Envelop.YMax + Envelop.YMin) / 2.0);
                IPoint point2 = new PointClass();
                point2.PutCoords(Envelop.XMax, (Envelop.YMax + Envelop.YMin) / 2.0);
                polyline.FromPoint = point;
                polyline.ToPoint = point2;
                result = polyline;
            }
            else if (Symbol is IFillSymbol)
            {
                result = Envelop;
            }
            else if (Symbol is ITextSymbol)
            {
                IArea area2 = Envelop as IArea;
                result = area2.Centroid;
            }
            return result;
        }

        /// <summary>
        /// Gets the enum description.
        /// </summary>
        /// <param name="enumItem">The enum item.</param>
        /// <returns>System.String.</returns>
        public static string GetEnumDescription(System.Enum enumItem)
        {
            System.Type type = enumItem.GetType();
            string name = System.Enum.GetName(type, enumItem);
            string result;
            if (name == null)
            {
                result = null;
            }
            else
            {
                System.Reflection.FieldInfo field = type.GetField(name);
                object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (customAttributes == null || customAttributes.Length == 0)
                {
                    result = name;
                }
                else
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)customAttributes[0];
                    result = descriptionAttribute.Description;
                }
            }
            return result;
        }




    }
}
