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
    public partial class frmReName : DevExpress.XtraEditors.XtraForm
    {
        public frmReName()
        {
            InitializeComponent();
        }
        private void siBReset_Click(object sender, EventArgs e)
        {

        }

        private void siBOK_Click(object sender, EventArgs e)
        {

        }
        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}