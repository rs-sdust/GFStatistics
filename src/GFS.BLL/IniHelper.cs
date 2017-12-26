// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 11-16-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 11-16-2017
// ***********************************************************************
// <copyright file="IniHelper.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>read write ini files</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The BLL namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class IniHelper.
    /// </summary>
    public class IniHelper
    {
        /// <summary>
        /// The M_S ini filepath
        /// </summary>
        private string m_sIniFilepath;

        /// <summary>
        /// Writes the private profile string.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="val">The value.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.Int64.</returns>
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// Gets the private profile string.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="def">The definition.</param>
        /// <param name="retVal">The ret value.</param>
        /// <param name="size">The size.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.Int32.</returns>
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// Initializes a new instance of the <see cref="IniHelper"/> class.
        /// </summary>
        /// <param name="sIniFilePath">The s ini file path.</param>
        public IniHelper(string sIniFilePath)
        {
            this.m_sIniFilepath = sIniFilePath;
        }

        /// <summary>
        /// Writes the ini value.
        /// </summary>
        /// <param name="Section">The section.</param>
        /// <param name="Key">The key.</param>
        /// <param name="Value">The value.</param>
        public void WriteIniValue(string Section, string Key, string Value)
        {
            IniHelper.WritePrivateProfileString(Section, Key, Value, this.m_sIniFilepath);
        }

        /// <summary>
        /// Reads the ini value.
        /// </summary>
        /// <param name="Section">The section.</param>
        /// <param name="Key">The key.</param>
        /// <returns>System.String.</returns>
        public string ReadIniValue(string Section, string Key)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(500);
            int privateProfileString = IniHelper.GetPrivateProfileString(Section, Key, "", stringBuilder, 500, this.m_sIniFilepath);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Determines whether [is exist ini file].
        /// </summary>
        /// <returns><c>true</c> if [is exist ini file]; otherwise, <c>false</c>.</returns>
        public bool IsExistIniFile()
        {
            return System.IO.File.Exists(this.m_sIniFilepath);
        }
    }
}
