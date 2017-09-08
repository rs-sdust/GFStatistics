// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="Program.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>主入口</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ESRI.ArcGIS.esriSystem;
using DevExpress.XtraEditors;
using GFS.BLL;
using ESRI.ArcGIS;

namespace GFS.Classification
{
    static class Program
    {
        //private static LicenseInitializer m_AOLicenseInitializer = new LicenseInitializer();
        private static IAoInitialize m_AoInitialize = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Process process = ProcessCheck.RuningInstance();
                if (process != null)
                {
                    ProcessCheck.HandleRunningInstance(process);
                    //System.Threading.Thread.Sleep(1000);  
                    System.Environment.Exit(1);
                }
                if (!RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop))
                {
                    XtraMessageBox.Show("绑定ArcGisRuntime失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    m_AoInitialize = new AoInitializeClass();
                    if (m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced) != esriLicenseStatus.esriLicenseCheckedOut)
                    {
                        if (m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngine) != esriLicenseStatus.esriLicenseCheckedOut)
                        {
                            XtraMessageBox.Show("初始化许可失败!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        return;
                    }

                    if (m_AoInitialize.CheckOutExtension(esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst) != esriLicenseStatus.esriLicenseCheckedOut)
                    {
                        XtraMessageBox.Show("启用扩展失败：esriLicenseExtensionCodeSpatialAnalyst，相关模块无法运行。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                
                //bool licensed = m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeAdvanced },
                //                new esriLicenseExtensionCode[] { });
                //if (!licensed)
                //{
                //    XtraMessageBox.Show(m_AOLicenseInitializer.LicenseMessage(), "初始化许可失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}

                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace, "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                //m_AOLicenseInitializer.ShutdownApplication();
                if (m_AoInitialize != null)
                {
                    m_AoInitialize.CheckInExtension(esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);
                    m_AoInitialize.Shutdown();
                }
            }
        }
    }
}
