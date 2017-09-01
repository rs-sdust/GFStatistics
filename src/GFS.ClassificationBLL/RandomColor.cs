// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-28-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-28-2017
// ***********************************************************************
// <copyright file="RandomColor.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>随机获取一个颜色</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GFS.ClassificationBLL
{
    public class RandomColor
    {
        /// <summary>
        /// Gets the random color.
        /// </summary>
        /// <param name="seed">random seed.</param>
        /// <returns>Color.</returns>
        public static Color GetRandomColor(int seed)
        {
            Random ro = new Random(seed); 
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL)|(int)(tick >> 32));
            int R = ran.Next(255);
            int G = ran.Next(255);
            int B = ran.Next(255);
            B =(R + G > 400) ? R+G-400:B;//0 : 380 - R - G;
            B = (B > 255) ? 255 : B;
            return Color.FromArgb(R, G, B);
        }

        /// <summary>
        /// Gets the random color.
        /// </summary>
        /// <returns>System.Drawing.Color.</returns>
        public static System.Drawing.Color GetRandomColor()
        {
            Random randomNum_1 = new Random(Guid.NewGuid().GetHashCode());
            System.Threading.Thread.Sleep(randomNum_1.Next(1));
            int int_Red = randomNum_1.Next(255);

            Random randomNum_2 = new Random((int)DateTime.Now.Ticks);
            int int_Green = randomNum_2.Next(255);

            Random randomNum_3 = new Random(Guid.NewGuid().GetHashCode());

            int int_Blue = randomNum_3.Next(255);
            int_Blue = (int_Red + int_Green > 380) ? int_Red + int_Green - 380 : int_Blue;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;


            return GetDarkerColor(System.Drawing.Color.FromArgb(int_Red, int_Green, int_Blue));
        }

        //获取加深颜色
        private static Color GetDarkerColor(Color color)
        {
            const int max = 255;
            int increase = new Random(Guid.NewGuid().GetHashCode()).Next(30, 255); //还可以根据需要调整此处的值


            int r = Math.Abs(Math.Min(color.R - increase, max));
            int g = Math.Abs(Math.Min(color.G - increase, max));
            int b = Math.Abs(Math.Min(color.B - increase, max));


            return Color.FromArgb(r, g, b);
        }


    }
}
