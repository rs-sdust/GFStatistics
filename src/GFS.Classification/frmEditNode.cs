using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using GFS.ClassificationBLL;

namespace GFS.ClassificationBLL
{
    public partial class frmEditNode : DevExpress.XtraEditors.XtraForm
    {
        public frmEditNode()
        {
            InitializeComponent();
        }

        private void frmEditNode_Load(object sender, EventArgs e)
        {
            if (Canvas.instance.curNode == null)
                return;
            this.txtNodeaName.Text = Canvas.instance.curNode.text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}