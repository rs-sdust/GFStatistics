using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using GFS.BLL;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.Commands.UI
{
    public class frmIdentify : XtraForm
    {
        private IContainer components = null;

        private PanelControl panelControl2;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private GridView gridView1;

        public TreeList treeList1;

        public GridControl gridControl1;

        private TreeListColumn treeListColumn1;

        private IScreenDisplay m_ScreenDisplay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelControl2 = new PanelControl();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            ((ISupportInitialize)this.treeList1).BeginInit();
            this.statusStrip1.SuspendLayout();
            base.SuspendLayout();
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Controls.Add(this.treeList1);
            this.panelControl2.Controls.Add(this.statusStrip1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(339, 423);
            this.panelControl2.TabIndex = 1;
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new Point(2, 148);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(335, 251);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView1
			});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.treeList1.Columns.AddRange(new TreeListColumn[]
			{
				this.treeListColumn1
			});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeList1.Location = new Point(2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new Size(335, 146);
            this.treeList1.TabIndex = 1;
            this.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.Click += new EventHandler(this.treeList1_Click);
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsFilter.AllowAutoFilter = false;
            this.treeListColumn1.OptionsFilter.AllowFilter = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatusLabel1
			});
            this.statusStrip1.Location = new Point(2, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(335, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new Size(0, 17);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            base.ClientSize = new Size(339, 423);
            base.Controls.Add(this.panelControl2);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmIdentify";
            this.Text = "识别";
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            ((ISupportInitialize)this.treeList1).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            base.ResumeLayout(false);
        }

        public frmIdentify(IScreenDisplay screenDisplay)
        {
            this.InitializeComponent();
            this.m_ScreenDisplay = screenDisplay;
        }

        public void UpdateStatusText(string statusLblText)
        {
            this.toolStripStatusLabel1.Text = statusLblText;
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (this.treeList1.Nodes.Count != 0 && this.treeList1.FocusedNode.Tag != null)
            {
                if (this.treeList1.FocusedNode.ParentNode != null)
                {
                    DataTable dataSource = this.treeList1.FocusedNode.Tag as DataTable;
                    this.gridControl1.DataSource = dataSource;
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            if (this.treeList1.Nodes.Count != 0 && this.treeList1.FocusedNode != null)
            {
                IIdentifyObj identifyObj;
                if (this.treeList1.FocusedNode.Level == 0)
                {
                    identifyObj = (this.treeList1.FocusedNode.Tag as IIdentifyObj);
                }
                else
                {
                    identifyObj = (this.treeList1.FocusedNode.ParentNode.Tag as IIdentifyObj);
                }
                identifyObj.Flash(this.m_ScreenDisplay);
            }
        }
    }
}
