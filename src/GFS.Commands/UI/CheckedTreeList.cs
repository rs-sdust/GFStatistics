using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Windows.Forms;

namespace GFS.Commands.UI
{
    public class CheckedTreeList : TreeList
    {
        public CheckedTreeList()
        {
            base.OptionsView.ShowCheckBoxes = true;
            base.OptionsView.ShowIndicator = false;
            base.AfterCheckNode += new NodeEventHandler(this.MyTreeList_AfterCheckNode);
        }

        private void MyTreeList_AfterCheckNode(object sender, NodeEventArgs e)
        {
            this.SetCheckedChildNodes(e.Node, e.Node.CheckState);
            this.SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                this.SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool flag = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    CheckState checkState = node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(checkState))
                    {
                        flag = !flag;
                        break;
                    }
                }
                node.ParentNode.CheckState = (flag ? CheckState.Indeterminate : check);
                this.SetCheckedParentNodes(node.ParentNode, check);
            }
        }
    }
}
