using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid;

namespace GFS.Sample
{
    public partial class frmAddField : DevExpress.XtraEditors.XtraForm
    {
        //private DataTable _DataSource= null;
        private IFeatureClass _FeatureClass = null;
        private IField _NewField = null;
        public frmAddField(IFeatureClass pFeatureClass)
        {
            InitializeComponent();
            this._FeatureClass = pFeatureClass;
            //this._DataSource = dataSource;
            this._NewField = new FieldClass();
        }

        private void frmAddField_Load(object sender, EventArgs e)
        {
            this.cmbFieldType.Properties.Items.Add("长整型");
            this.cmbFieldType.Properties.Items.Add("短整型");
            this.cmbFieldType.Properties.Items.Add("浮点型");
            this.cmbFieldType.Properties.Items.Add("双精度");
            this.cmbFieldType.Properties.Items.Add("文本型");
            this.cmbFieldType.SelectedIndex = 1; 

        }
        private void cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFieldType = cmbFieldType.Text;
            IFieldEdit pFieldEdit = _NewField as IFieldEdit;
            switch (strFieldType)
            {
                case "长整型":
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                        spinPre.EditValue = 0;
                        labelPre.Text = "精度";
                        break;
                    }
                case "短整型":
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSmallInteger;
                        spinPre.EditValue = 0;
                        labelPre.Text = "精度";
                        break;
                    }
                case "浮点型":
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle;
                        spinPre.EditValue = 0;
                        labelPre.Text = "精度";
                        break;
                    }
                case "双精度":
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                        spinPre.EditValue = 0;
                        labelPre.Text = "精度";
                        break;
                    }
                case "文本型":
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                        spinPre.EditValue = 50;
                        labelPre.Text = "长度";
                        break;
                    }
                default:
                    {
                        pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                        spinPre.EditValue = 50;
                        labelPre.Text = "长度";
                        break;
                    }
            }
        }

        private void spinPre_EditValueChanged(object sender, EventArgs e)
        {
            IFieldEdit pFieldEdit = _NewField as IFieldEdit;
            int length = int.Parse(spinPre.EditValue.ToString());
            if (length > 0)
            {
                pFieldEdit.Precision_2 = length;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.txtName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    XtraMessageBox.Show("字段名不能为空！","提示信息");
                }
                IFieldEdit pFieldEdit = _NewField as IFieldEdit;
                pFieldEdit.Name_2 = name;
                int index = _FeatureClass.FindField(name);
                if (index == -1)
                {
                    _FeatureClass.AddField(_NewField);
                    XtraMessageBox.Show("字段添加成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("字段已经存在！");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("添加字段失败："+ex.Message,"提示信息");
            }  
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}