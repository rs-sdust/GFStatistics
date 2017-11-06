using ESRI.ArcGIS.Carto;
using System;

namespace GFS.Commands.UI
{
    public class MyDataLayer
    {
        public ILayer Layer
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }
    }
}
