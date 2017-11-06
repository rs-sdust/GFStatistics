using System;
using System.ComponentModel;

namespace GFS.Commands.UI
{
    public enum EnumLayerType
    {
        [Description("矢量图层")]
        Vector,
        [Description("栅格图层")]
        Raster,
        [Description("所有图层")]
        VectorAndRaster
    }
}
