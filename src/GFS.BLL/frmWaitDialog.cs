using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data.Utils;
using System.Reflection;
using DevExpress.Utils.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.ComponentModel;

namespace GFS.BLL
{
    public class frmWaitDialog : XtraForm
    {
        private PictureBox pic;

        private string caption = "";

        private string title = "";

        private Font boldFont;

        private Font font;

        public override bool AllowFormSkin
        {
            get
            {
                return false;
            }
        }

        public string Caption
        {
            get
            {
                return this.caption;
            }
            set
            {
                this.caption = value;
                this.Refresh();
            }
        }

        private Font RegularFont
        {
            get
            {
                if (this.font == null)
                {
                    this.font = new System.Drawing.Font(AppearanceObject.DefaultFont.FontFamily, 9f, FontStyle.Regular);
                }
                return this.font;
            }
        }

        private Font BoldFont
        {
            get
            {
                if (this.boldFont == null)
                {
                    this.boldFont = new Font(AppearanceObject.DefaultFont.FontFamily, 9f, FontStyle.Bold);
                }
                return this.boldFont;
            }
        }

        public frmWaitDialog()
            : this("")
        {
        }

        public frmWaitDialog(string caption)
            : this(caption, "")
        {
        }

        public frmWaitDialog(string caption, string title)
            : this(caption, title, new Size(260, 50), null)
        {
        }

        public frmWaitDialog(string caption, Size size)
            : this(caption, "", size, null)
        {
        }

        public frmWaitDialog(string caption, string title, Size size)
            : this(caption, title, size, null)
        {
        }

        public frmWaitDialog(string caption, string title, Size size, Form parent)
        {
            this.caption = caption;
            this.title = ((title == "") ? "Loading Data. Please Wait." : title);
            this.pic = new PictureBox();
            base.FormBorderStyle = FormBorderStyle.None;
            base.ControlBox = false;
            base.ClientSize = size;
            if (parent == null)
            {
                base.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                base.StartPosition = FormStartPosition.Manual;
                base.Left = parent.Left + (parent.Width - base.Width) / 2;
                base.Top = parent.Top + (parent.Height - base.Height) / 2;
            }
            base.ShowInTaskbar = false;
            base.TopMost = true;
            base.Paint += new PaintEventHandler(this.WaitDialogPaint);
            this.pic.Size = new Size(32, 32);
            this.pic.Location = new Point(15, base.ClientSize.Height / 2 - 16);
            this.pic.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.pic.Image = ImageTool.ImageFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("GFS.Bll.Resources.loading.gif"));
            this.pic.Image = GFS.BLL.Resources.loadingBig;
            base.Controls.Add(this.pic);
            base.Show();
            this.Refresh();
        }

        public string GetCaption()
        {
            return this.Caption;
        }

        public void SetCaption(string newCaption)
        {
            this.Caption = newCaption;
        }

        private void WaitDialogPaint(object sender, PaintEventArgs e)
        {
            Rectangle clipRectangle = e.ClipRectangle;
            GraphicsCache graphicsCache = new GraphicsCache(e);
            using (StringFormat stringFormat = new StringFormat())
            {
                Brush solidBrush = graphicsCache.GetSolidBrush(LookAndFeelHelper.GetSystemColor(base.LookAndFeel, SystemColors.WindowText));
                stringFormat.Alignment = (stringFormat.LineAlignment = StringAlignment.Center);
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                if (base.LookAndFeel.ActiveLookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
                {
                    ObjectPainter.DrawObject(graphicsCache, new SkinTextBorderPainter(base.LookAndFeel), new BorderObjectInfoArgs(null, clipRectangle, null));
                }
                else
                {
                    ControlPaint.DrawBorder3D(e.Graphics, clipRectangle, Border3DStyle.RaisedInner);
                }
                clipRectangle.X += 30;
                clipRectangle.Width -= 30;
                clipRectangle.Height /= 3;
                clipRectangle.Y += clipRectangle.Height / 2;
                e.Graphics.DrawString(this.title, this.BoldFont, solidBrush, clipRectangle, stringFormat);
                clipRectangle.Y += clipRectangle.Height;
                e.Graphics.DrawString(this.caption, this.RegularFont, solidBrush, clipRectangle, stringFormat);
                graphicsCache.Dispose();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.pic.Image = null;
            this.boldFont = null;
            this.font = null;
            base.OnClosing(e);
        }
    }
}
