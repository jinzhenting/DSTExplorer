using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSTExplorer
{
   public static class Pixels
    {
        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="mm">毫米</param>
        /// <returns>像素</returns>
        public static float Get()
        {
            Panel panel = new Panel();
            Graphics graphics = Graphics.FromHwnd(panel.Handle);
            IntPtr intptr = graphics.GetHdc();
            float width = GetDeviceCaps(intptr, 4);// HORZRES
            float pixels = GetDeviceCaps(intptr, 8);// BITSPIXEL
            graphics.ReleaseHdc(intptr);
            return (width / pixels) * 1.34f;
        }
        [DllImport("gdi32.dll")]// GDI_API
        private static extern int GetDeviceCaps(IntPtr hdc, int Home);
    }
}
