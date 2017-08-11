using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;
using GFS.BLL;
using ESRI.ArcGIS.Carto;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using GFS.Commands.UI;

namespace GFS.Commands
{
    /// <summary>
    /// Class CmdSaveFile. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("a1ab3ca2-9cdf-4b73-bc04-c733086c845f")]
    [ProgId("GFS.Commands.NewTask")]
    public sealed class CmdNewTask : BaseCommand
    {
                /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdNewTask.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdNewTask.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdSaveFile"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdNewTask()
        {
            this.m_category = "AppMenu";
            this.m_caption = "新建任务";
            this.m_message = "新建任务";
            this.m_toolTip = "新建任务";
            this.m_name = "CmdNewTask";
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
            try
            {
                EnviVars.instance.MainForm.UseWaitCursor = true;
                //if (!String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                //    EnviVars.instance.MapControl.CheckMxFile(EnviVars.instance.MapControl.DocumentFilename))
                //{
                //    if (XtraMessageBox.Show("保存当前任务？", "提示信息",
                //        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                //        == DialogResult.Cancel)
                //    {
                //        return;
                //    }

                //    if (XtraMessageBox.Show("保存当前任务？", "提示信息",
                //        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                //        == DialogResult.OK)
                //    {
                //        IMapDocument mapDocument = new MapDocumentClass();
                //        mapDocument.Open(EnviVars.instance.MapControl.DocumentFilename, "");
                //        mapDocument.ReplaceContents((IMxdContents)EnviVars.instance.PageLayoutControl.PageLayout);
                //        mapDocument.Save(mapDocument.UsesRelativePaths, true);
                //        mapDocument.Close();
                //    }

                    frmNewTask frm = new frmNewTask();
                    frm.ShowDialog(EnviVars.instance.MainForm);

            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(CmdNewTask), ex);
                XtraMessageBox.Show("创建任务失败：" + ex.Message, "提示信息",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnviVars.instance.MainForm.UseWaitCursor = false;
            }
 
        }
    }
}
