using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GFS.Classification
{
    public partial class frmSampleAnalystResult : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dt = null;
        public frmSampleAnalystResult(DataTable dt)
        {
            InitializeComponent();
            this._dt = dt;
        }

        private void frmSampleAnalystResult_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this._dt;
        }

    }
}