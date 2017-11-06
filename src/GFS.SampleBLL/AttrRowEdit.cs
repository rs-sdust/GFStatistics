using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GFS.SampleBLL
{

    public class AttrEditCache
    {
        public DataTable beforTable = null;
        public DataTable afterTable = null;
        public int editCount
        {
            get
            {
                return beforTable == null ? 0 : beforTable.Rows.Count;
            }
        }
        public int doIndex ;
        public AttrEditCache(DataTable srcTable)
        {
            beforTable = srcTable.Clone();
            afterTable = srcTable.Clone();
            doIndex = -1;
        }
        public void ImportRow(DataRow row )
        {
            try
            {
                beforTable.ImportRow(row);
                afterTable.ImportRow(row);
                doIndex = editCount - 1 ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
