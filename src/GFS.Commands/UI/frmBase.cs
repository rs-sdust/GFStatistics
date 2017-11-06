using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.Commands.UI
{
    public class frmBase : XtraForm
    {
        private IContainer components = null;

        private ImageList imageList1;

        private ImageList imageList2;

        public ImageList DataImageList
        {
            get
            {
                return this.imageList1;
            }
        }

        public ImageList LayerImageList
        {
            get
            {
                return this.imageList2;
            }
        }

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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmBase));
            this.imageList1 = new ImageList();
            this.imageList2 = new ImageList();
            base.SuspendLayout();
            this.imageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "share.png");
            this.imageList1.Images.SetKeyName(1, "sharedir.png");
            this.imageList1.Images.SetKeyName(2, "disk.png");
            this.imageList1.Images.SetKeyName(3, "folder.png");
            this.imageList1.Images.SetKeyName(4, "002.bmp");
            this.imageList1.Images.SetKeyName(5, "003.bmp");
            this.imageList1.Images.SetKeyName(6, "004.bmp");
            this.imageList1.Images.SetKeyName(7, "mdb.png");
            this.imageList1.Images.SetKeyName(8, "dataset.png");
            this.imageList1.Images.SetKeyName(9, "annotation.png");
            this.imageList1.Images.SetKeyName(10, "gdpoint.png");
            this.imageList1.Images.SetKeyName(11, "gdline.png");
            this.imageList1.Images.SetKeyName(12, "gdpolygon.png");
            this.imageList1.Images.SetKeyName(13, "011.bmp");
            this.imageList1.Images.SetKeyName(14, "012.bmp");
            this.imageList1.Images.SetKeyName(15, "013.bmp");
            this.imageList1.Images.SetKeyName(16, "014.bmp");
            this.imageList1.Images.SetKeyName(17, "015.bmp");
            this.imageList1.Images.SetKeyName(18, "016.bmp");
            this.imageList1.Images.SetKeyName(19, "017.bmp");
            this.imageList1.Images.SetKeyName(20, "018.bmp");
            this.imageList1.Images.SetKeyName(21, "019.bmp");
            this.imageList1.Images.SetKeyName(22, "020.bmp");
            this.imageList1.Images.SetKeyName(23, "021.bmp");
            this.imageList1.Images.SetKeyName(24, "022.bmp");
            this.imageList1.Images.SetKeyName(25, "023.bmp");
            this.imageList1.Images.SetKeyName(26, "024.bmp");
            this.imageList1.Images.SetKeyName(27, "025.bmp");
            this.imageList1.Images.SetKeyName(28, "026.bmp");
            this.imageList1.Images.SetKeyName(29, "027.bmp");
            this.imageList1.Images.SetKeyName(30, "033.bmp");
            this.imageList1.Images.SetKeyName(31, "034.bmp");
            this.imageList1.Images.SetKeyName(32, "010.bmp");
            this.imageList1.Images.SetKeyName(33, "SDE.png");
            this.imageList1.Images.SetKeyName(34, "addsde.png");
            this.imageList1.Images.SetKeyName(35, "sdeconn.png");
            this.imageList1.Images.SetKeyName(36, "e00.png");
            this.imageList1.Images.SetKeyName(37, "mdb.png");
            this.imageList1.Images.SetKeyName(38, "gdb-dataset.png");
            this.imageList1.Images.SetKeyName(39, "annotation.png");
            this.imageList1.Images.SetKeyName(40, "gdpoint.png");
            this.imageList1.Images.SetKeyName(41, "gdline.png");
            this.imageList1.Images.SetKeyName(42, "gdpolygon.png");
            this.imageList1.Images.SetKeyName(43, "geodatabase_sde.png");
            this.imageList1.Images.SetKeyName(44, "gdb-dataset.png");
            this.imageList1.Images.SetKeyName(45, "annotation.png");
            this.imageList1.Images.SetKeyName(46, "gdline.png");
            this.imageList1.Images.SetKeyName(47, "gdpoint.png");
            this.imageList1.Images.SetKeyName(48, "gdpolygon.png");
            this.imageList1.Images.SetKeyName(49, "GeodatabaseTable16.png");
            this.imageList1.Images.SetKeyName(50, "Layer_LYR_File16.png");
            this.imageList1.Images.SetKeyName(51, "GeodatabaseMosaicDataset16.png");
            this.imageList2.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "LayerGroup16.png");
            this.imageList2.Images.SetKeyName(1, "LayerPoint16.png");
            this.imageList2.Images.SetKeyName(2, "LayerLine16.png");
            this.imageList2.Images.SetKeyName(3, "LayerPolygon16.png");
            this.imageList2.Images.SetKeyName(4, "LayerRaster16.png");
            this.imageList2.Images.SetKeyName(5, "LayerAnnotation16.png");
            this.imageList2.Images.SetKeyName(6, "LayerCAD16.png");
            this.imageList2.Images.SetKeyName(7, "LayerGeneric16.png");
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(448, 262);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Name = "frmBase";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "frmBase";
            base.ResumeLayout(false);
        }

        public frmBase()
        {
            this.InitializeComponent();
        }
    }
}
