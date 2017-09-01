using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductionMeta
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "选择产品数据";
            openDialog.Multiselect = true;
            openDialog.Title = "请选择文件";
            openDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openDialog.FileNames)
                {
                    this.listBoxFile.Items.Add(file);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listBoxFile.Items.Count < 1)
                return;
            if (string.IsNullOrEmpty(textBoxDataSource.Text.TrimEnd()))
            {
                MessageBox.Show("请填写数据源！");
            }
            else
            {
 
            }
        }
    }
}
