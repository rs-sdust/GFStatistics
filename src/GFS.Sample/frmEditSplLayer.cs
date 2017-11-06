using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace GFS.Sample
{
    public partial class frmEditSplLayer : DevExpress.XtraEditors.XtraForm
    {
        private GridView _gv = null;
        private string _columnName = string.Empty;
        public frmEditSplLayer(GridView gv,string columName)
        {
            InitializeComponent();
            this._gv = gv;
            this._columnName = columName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int[] selectedRows = _gv.GetSelectedRows();
            if (selectedRows.Length > 0)
            {
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    DataRow row = _gv.GetDataRow(i);
                    row[_columnName] = spinEditLayer.EditValue;
                }
            }
            _gv.ClearSelection();
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}