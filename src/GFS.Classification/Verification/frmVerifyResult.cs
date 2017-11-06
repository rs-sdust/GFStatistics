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
    public partial class frmVerifyResult : DevExpress.XtraEditors.XtraForm
    {
        public frmVerifyResult()
        {
            InitializeComponent();
        }
        public frmVerifyResult(string file)
        {
            InitializeComponent();
            //this.richEditControl.LoadDocument(file);
            try
            {
                richTextBox.LoadFile(file, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            }
            catch (Exception)
            { }
            finally
            {
            }
        }
        public void SetDataSource(string file)
        {
            //this.richEditControl.LoadDocument(file);
            richTextBox.LoadFile(file, System.Windows.Forms.RichTextBoxStreamType.PlainText);
        }
    }
}