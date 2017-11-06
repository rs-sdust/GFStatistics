using ESRI.ArcGIS.Geodatabase;
//using PS.Plot.Common;
using System;
using GFS.Common;

namespace GFS.Commands.UI
{
    public class WorkspaceInfo
    {
        public IWorkspace Workspace
        {
            get;
            set;
        }

        public DataType Type
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }
    }
}
