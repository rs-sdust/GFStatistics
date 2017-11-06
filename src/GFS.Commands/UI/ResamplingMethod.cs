using System;
using System.ComponentModel;

namespace GFS.Commands.UI
{
    public enum ResamplingMethod
    {
        [Description("Nearest Neighbor")]
        NEARSET,
        [Description("Bilinear Interpolation")]
        BILINEAR,
        [Description("Cubic Convolution")]
        CUBIC,
        [Description("Majority")]
        Majority
    }
}
