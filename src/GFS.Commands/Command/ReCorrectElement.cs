using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using System.Data;

namespace GFS.Commands
{
    public class ReCorrectElement
    {
        public int ID
        {
            get;
            set;
        }
        public IElement Element
        {
            get;
            set;
        }

        public bool Checked
        {
            get;
            set;
        }
        public DataTable CorrectMap
        {
            get;
            set;
        }

    }
}
