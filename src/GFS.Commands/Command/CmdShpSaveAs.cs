// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-11-2016
// ***********************************************************************
// <copyright file="CmdShpSaveAs.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.XtraEditors;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using SDJT.Const;
using SDJT.Sys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdShpSaveAs. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("ef317679-fc68-4260-a985-36d709e469eb")] 
    [ProgId("SDJT.Commands.CmdShpSaveAs")]
    public sealed class CmdShpSaveAs : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

        /// <summary>
        /// The m_current layer
        /// </summary>
        private ILayer m_currentLayer = null;

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
                this.m_currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
                return this.m_currentLayer is IFeatureLayer;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdShpSaveAs.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdShpSaveAs.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdShpSaveAs"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdShpSaveAs()
        {
            this.m_category = "TocMenu";
            this.m_caption = "矢量数据另存";
            this.m_message = "矢量数据另存";
            this.m_toolTip = "矢量数据另存";
            this.m_name = "CmdShpSaveAs";
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
            this.ExportShp();
        }

        /// <summary>
        /// Exports the SHP.
        /// </summary>
        private void ExportShp()
        {
            Logger logger = new Logger();
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "shape file (*.shp)|*.shp";
            saveFileDialog.Title = AppMessage.MSG0111;
            if (System.Windows.Forms.DialogResult.OK == saveFileDialog.ShowDialog(EnviVars.instance.MainForm))
            {
                try
                {
                    IFeatureLayer featureLayer = this.m_currentLayer as IFeatureLayer;
                    this.ExportToShp(featureLayer.FeatureClass, featureLayer.DataSourceType, saveFileDialog.FileName);
                    //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0111, null);
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0111, ex);
                    XtraMessageBox.Show(AppMessage.MSG0030, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>
        /// Exports to SHP.
        /// </summary>
        /// <param name="inputFeatureClass">The input feature class.</param>
        /// <param name="dataSourceType">Type of the data source.</param>
        /// <param name="saveShpFilePath">The save SHP file path.</param>
        public void ExportToShp(IFeatureClass inputFeatureClass, string dataSourceType, string saveShpFilePath)
        {
            IDataset dataset = inputFeatureClass as IDataset;
            string directoryName = Path.GetDirectoryName(saveShpFilePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(saveShpFilePath);
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspace workspace = workspaceFactory.OpenFromFile(directoryName, 0);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            if (File.Exists(saveShpFilePath))
            {
                IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass(fileNameWithoutExtension);
                IDataset dataset2 = featureClass as IDataset;
                if (!dataset2.CanDelete())
                {
                    XtraMessageBox.Show(AppMessage.MSG0112, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    return;
                }
                string a = Path.Combine(dataset.Workspace.PathName, dataset.Name + ".shp");
                if (a == saveShpFilePath && dataSourceType == "Shapefile Feature Class")
                {
                    XtraMessageBox.Show(AppMessage.MSG0112, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    return;
                }
                dataset2.Delete();
            }
            this.SaveAsShpfile(inputFeatureClass, dataset, fileNameWithoutExtension, workspace);
        }

        /// <summary>
        /// Saves as shpfile.
        /// </summary>
        /// <param name="inputFeatureClass">The input feature class.</param>
        /// <param name="pInDataset">The p in dataset.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="pOutWorkspace">The p out workspace.</param>
        private void SaveAsShpfile(IFeatureClass inputFeatureClass, IDataset pInDataset, string fileName, IWorkspace pOutWorkspace)
        {
            IFeatureClassName inputDatasetName = pInDataset.FullName as IFeatureClassName;
            IWorkspace workspace = pInDataset.Workspace;
            IDataset dataset = pOutWorkspace as IDataset;
            IWorkspaceName workspaceName = dataset.FullName as IWorkspaceName;
            IFeatureClassName featureClassName = new FeatureClassNameClass();
            IDatasetName datasetName = featureClassName as IDatasetName;
            datasetName.WorkspaceName = workspaceName;
            datasetName.Name = fileName;
            IFieldChecker fieldChecker = new FieldCheckerClass();
            fieldChecker.InputWorkspace = workspace;
            fieldChecker.ValidateWorkspace = pOutWorkspace;
            IFields fields = inputFeatureClass.Fields;
            IEnumFieldError enumFieldError;
            IFields outputFields;
            fieldChecker.Validate(fields, out enumFieldError, out outputFields);
            IFeatureDataConverter featureDataConverter = new FeatureDataConverterClass();
            featureDataConverter.ConvertFeatureClass(inputDatasetName, null, null, featureClassName, null, outputFields, "", 100, 0);
            XtraMessageBox.Show(AppMessage.MSG0029, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
        }
    }
}
