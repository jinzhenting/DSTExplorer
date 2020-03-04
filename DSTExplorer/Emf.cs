using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace DSTExplorer
{
    public static class Emf
    {
        /// <summary>
        /// 生成EMF文件
        /// </summary>
        /// <param name="dst">DST实例</param>
        /// <param name="displayJump">显示跳针</param>
        /// <returns></returns>
        public static string Save(DstFile dst, bool displayJump)
        {
            string emf = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), dst.FileName + ".emf");
            Bitmap bmp = new Bitmap(dst.OneSize.Width, dst.OneSize.Height);// 创建图像
            Graphics g_bmp = Graphics.FromImage(bmp);
            g_bmp.SmoothingMode = SmoothingMode.AntiAlias;// 绘图质量
            Metafile metafile = new Metafile(emf, g_bmp.GetHdc());
            Graphics g_mef = Graphics.FromImage(metafile);
            Point startLocation, endLocation;// 起点终点坐标
            Pen pen = new Pen(dst.ColouPlate[0], 1);// 画笔
            int corCount = 1; ;// 换色次数
            float pixels = Pixels.Get();
            for (int i = 0; i < dst.Locations.Count - 1; i++)// 绘制
            {
                if (dst.ColorChange[i])// 换色
                {
                    pen.Color = dst.ColouPlate[corCount];
                    corCount++;
                }
                if (dst.StitchJump[i]) if (displayJump) continue;// 跳针
                startLocation = dst.Locations[i];
                endLocation = dst.Locations[i + 1];
                g_mef.DrawLine(pen, (int)((startLocation.X - dst.MinX) * pixels), (int)((startLocation.Y - dst.MinY) * pixels), (int)((endLocation.X - dst.MinX) * pixels), (int)((endLocation.Y - dst.MinY)) * pixels);
            }
            g_mef.Save();
            g_mef.Dispose();
            metafile.Dispose();
            g_bmp.Dispose();
            return emf;
        }
    }
}
