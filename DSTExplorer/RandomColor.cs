using System.Collections.Generic;
using System.Drawing;

namespace DSTExplorer
{
    public static class RandomColor
    {
        /// <summary>
        /// 颜色列表生成器
        /// </summary>
        /// <param name="count">颜色数</param>
        /// <returns>颜色列表</returns>
        public static List<Color> Get(int count)
        {
            List<Color> colors = new List<Color>();
            int R = 0, G = 0, B = 0;
            for (int i = 0; i < count; i++)
            {
                R += 10;
                G += 50;
                B += 125;
                if (R > 255) R = 0;
                if (G > 255) G = 0;
                if (B > 255) B = 0;
                colors.Add(Color.FromArgb(R, G, B));
            }
            return colors;
        }
    }
}
