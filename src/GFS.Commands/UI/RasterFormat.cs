using System;
using System.ComponentModel;

namespace GFS.Commands.UI
{
    public enum RasterFormat
    {
        [Description("TIFF")]
        TIFF,
        [Description("IMAGINE Image")]
        Imagine,
        [Description("JPG")]
        JPEG,
        [Description("JP2")]
        JP2000,
        [Description("BMP")]
        BMP,
        [Description("PNG")]
        PNG,
        [Description("ENVI")]
        ENVI,
        [Description("HDF4")]
        HDF4,
        [Description("PIX")]
        PCI,
        [Description("BIL")]
        BIL,
        [Description("BIP")]
        BIP,
        [Description("BSQ")]
        BSQ,
        [Description("GRID")]
        GRID
    }
}
