using System;
using System.ComponentModel;

namespace GFS.Commands.UI
{
    public enum PixelType
    {
        [Description("unsigned 8 bit integers")]
        Pt_uchar,
        [Description("8 bit integers")]
        Pt_char,
        [Description("unsigned 16 bit integers")]
        Pt_ushort,
        [Description("16 bit integers")]
        Pt_short,
        [Description("unsigned 32 bit integers")]
        Pt_ulong,
        [Description("32 bit integers")]
        Pt_long,
        [Description("32 floating point")]
        Pt_float32,
        [Description("64 floating point")]
        Pt_float64
    }
}
