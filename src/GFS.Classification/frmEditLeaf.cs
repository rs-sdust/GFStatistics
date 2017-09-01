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
    public partial class frmEditLeaf : DevExpress.XtraEditors.XtraForm
    {
        private DecisionNode node = null;
        public frmEditLeaf()
        {
            InitializeComponent();
        }

        private void frmEditLeaf_Load(object sender, EventArgs e)
        {
            if (Canvas.instance.curNode == null)
                return;
            node = Canvas.instance.curNode;
            this.txtNodeaName.Text = node.text;
            this.spinClassValue.Value =node.classValue; 
            this.colorEdit1.Color = node.nodeColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            node.text = this.txtNodeaName.Text.TrimEnd();
            node.classValue = Convert.ToInt32(spinClassValue.Value);
            node.nodeColor = this.colorEdit1.Color;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}