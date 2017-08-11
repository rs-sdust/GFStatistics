using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;

namespace GFS.Commands.UI
{
    partial class CtrlListboxLayers
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.btnSelectAll = new SimpleButton();
            this.btnRemoveAll = new SimpleButton();
            ((ISupportInitialize)this.treeList1).BeginInit();
            base.SuspendLayout();
            this.treeList1.Columns.AddRange(new TreeListColumn[]
            {
                this.treeListColumn1
            });
            this.treeList1.Location = new Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsSelection.MultiSelect = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowRoot = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ShowButtonMode = ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList1.Size = new Size(227, 277);
            this.treeList1.TabIndex = 0;
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 91;
            this.btnSelectAll.Location = new Point(233, 38);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(75, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "选择所有";
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.btnRemoveAll.Location = new Point(234, 77);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new Size(75, 23);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "取消选择";
            this.btnRemoveAll.Click += new EventHandler(this.btnRemoveAll_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.btnRemoveAll);
            base.Controls.Add(this.btnSelectAll);
            base.Controls.Add(this.treeList1);
            base.Name = "CtrlListboxLayers";
            base.Size = new Size(315, 279);
            ((ISupportInitialize)this.treeList1).EndInit();
            base.ResumeLayout(false);
        }

        private TreeList treeList1;

        private TreeListColumn treeListColumn1;

        private SimpleButton btnSelectAll;

        private SimpleButton btnRemoveAll;

        #endregion
    }
}
