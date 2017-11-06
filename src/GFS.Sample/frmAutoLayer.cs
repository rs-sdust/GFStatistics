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
using GFS.BLL;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using GFS.Common;
using System.IO;
using GFS.SampleBLL;
using System.Runtime.InteropServices;

namespace GFS.Sample
{
    public partial class frmAutoLayer : DevExpress.XtraEditors.XtraForm
    {
        private IFeatureLayer _pFLayer = null;
        private DataTable _pFDt = null;
        private string _file;
        private string _lyrField;
        private int _lyrNum;
        private IMapControl3 _pMapControl = null;
        private ITOCControl2 _pTOCControl = null;
        public frmAutoLayer()
        {
            InitializeComponent();
            _pMapControl = EnviVars.instance.MapControl;
            _pTOCControl = EnviVars.instance.TOCControl;
        }

        private void frmAutoLayer_Load(object sender, EventArgs e)
        {
            MapAPI.GetAllLayers(null,cmbFUnit);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "打开文件";
            openDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                if (cmbFUnit.Text == openDlg.FileName)
                    return;

                if (_pFLayer != null)
                    _pMapControl.Map.DeleteLayer(_pFLayer);
                cmbFUnit.Text= openDlg.FileName;
            }
        }
        private void cmbFUnit_TextChanged(object sender, EventArgs e)
        {
            _file = cmbFUnit.Text;
            _pFLayer = null;
            for (int i = 0; i < _pMapControl.LayerCount; i++)
            {
                ILayer pLayer = _pMapControl.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    IFeatureClass pFClass = (pLayer as IFeatureLayer).FeatureClass;
                    string dtSource = Path.Combine((pFClass as IDataset).Workspace.PathName ,(pFClass as IDataset).Name + ".shp");
                    if (dtSource == _file)
                        _pFLayer = pLayer as IFeatureLayer;
                }
            }
            if (_pFLayer == null)
            {
                IFeatureClass pFClass = EngineAPI.OpenFeatureClass(_file);
                _pFLayer = new FeatureLayerClass();
                _pFLayer.FeatureClass = pFClass;
                FileInfo fInfo = new FileInfo(_file);
                _pFLayer.Name = fInfo.Name.Substring(0, fInfo.Name.Length - 4);

                _pMapControl.AddLayer(_pFLayer);
            }

            BindField(_pFLayer.FeatureClass, cmbLyrField, true);
        }
        private void cmbFUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbLyrField_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lyrField = cmbLyrField.SelectedItem.ToString();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            ITableConversion conver = new TableConversion();
            DataTable dt = conver.AETableToDataTable(_pFLayer.FeatureClass);
            AutoLayer auto = new AutoLayer();
            _pFDt = auto.OptimalStratifying(dt,_lyrField,_lyrNum);

            ITable pTable = _pFLayer.FeatureClass as ITable;
            //添加分层字段
            string fName = "FCBH";
            if (pTable.FindField(fName) < 0)
            {
                IField layerField = new FieldClass();
                IFieldEdit fieldEdit = layerField as IFieldEdit;
                fieldEdit.Name_2 = fName;
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pTable.AddField(layerField);
            }
            //字段赋值
            ICursor pCursor = pTable.Update(null, false);
            IRow pRow=null;
            int layerIndex = pTable.FindField(fName);
            if(layerIndex<0)
            {
                XtraMessageBox.Show("添加分层字段失败！");
                return;
            }
            while ((pRow = pCursor.NextRow() )!= null)
            {
                string value = pRow.get_Value(0).ToString();
                foreach(DataRow dRow in  _pFDt.Rows)
                {
                    if (value == dRow["FID"].ToString())
                    {
                        pRow.set_Value(layerIndex, dRow[fName]);
                        pCursor.UpdateRow(pRow);
                        continue;
                    }
                }
            }
            Marshal.ReleaseComObject(pCursor);

            XtraMessageBox.Show("分层完毕！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            {
                MapAPI.UniqueValueRender(_pFLayer, fName);
                (_pMapControl.Map as IActiveView).Extent = _pFLayer.AreaOfInterest;
                _pMapControl.Refresh();
                _pTOCControl.Update();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindField(IFeatureClass featureClass, ComboBoxEdit cmb, bool isNum)
        {
            List<string> fields = new List<string>();
            EngineAPI.GetFields(_pFLayer.FeatureClass, 0, fields);
            cmb.Properties.Items.Clear();
            cmb.Properties.Items.AddRange(fields);
        }

        private void spinLyrNum_EditValueChanged(object sender, EventArgs e)
        {
            _lyrNum = int.Parse(spinLyrNum.EditValue.ToString());
        }




    }
}