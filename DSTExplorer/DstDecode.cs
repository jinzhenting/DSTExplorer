using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System;
using System.Windows.Forms;

namespace DSTExplorer
{
    public static class DstDecode
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="inpath">文件路径</param>
        public static DstFile LoadFile(string inpath)
        {
            FileStream filestream = File.OpenRead(inpath);// 读取文件到Byte
            byte[] header = new byte[123];
            filestream.Read(header, 0, header.Length);// 提取有信息的文件头
            byte[] tempbyte = new byte[389];
            filestream.Read(tempbyte, 0, tempbyte.Length);// 清除没意义的文件头
            byte[] stitch = new byte[filestream.Length - header.Length - tempbyte.Length - 3 - (filestream.Length - 512) % 3];// 总长 - 512 - 3 - 总长除3余数
            filestream.Read(stitch, 0, stitch.Length);// 提取针迹
            byte[] end = new byte[filestream.Length - header.Length - stitch.Length];
            filestream.Read(end, 0, end.Length);// 提取结束符
            filestream.Close();
            ///
            DstFile dst = new DstFile();
            dst.FilePath = inpath;
            dst.FileName = Path.GetFileNameWithoutExtension(inpath);
            ///
            try
            {
                string json = "{" + Encoding.Default.GetString(header);// 文件头转换Json
                json = json.Replace(" ", "").Replace("\r", "").Replace("LA:", "\"LA\": \"").Replace("ST:", "\",\"ST\": \"").Replace("CO:", "\",\"CO\": \"").Replace("+X:", "\",\"+X\": \"").Replace("-X:", "\",\"-X\": \"").Replace("+Y:", "\",\"+Y\": \"").Replace("-Y:", "\",\"-Y\": \"").Replace("AX:", "\",\"AX\": \"").Replace("AY:", "\",\"AY\": \"").Replace("MX:", "\",\"MX\": \"").Replace("MY:", "\",\"MY\": \"").Replace("PD:", "\",\"PD\": \"");
                json += "\"}";
                JObject messages = JObject.Parse(json);
                //name = (string)messages["LA"];
                dst.StitchCount = (int)messages["ST"];
                dst.ColorCount = (int)messages["CO"] + 1;
                dst.ColouPlate = RandomColor.Get(dst.ColorCount);
                dst.MaxX = (int)(messages["+X"]);
                dst.MinX = (int)(messages["-X"]);
                dst.MaxY = (int)(messages["+Y"]);
                dst.MinY = (int)(messages["-Y"]);
                dst.StartX = (int)(messages["AX"]);
                dst.EndX = (int)(messages["MX"]);
                dst.StartY = (int)(messages["AY"]);
                dst.EndY = (int)(messages["MY"]);
                dst.Size = new Size(dst.MaxX + dst.MinX, dst.MaxY + dst.MinY);
                dst.MmSize = new Size((dst.MaxX + dst.MinX) / 10, (dst.MaxY + dst.MinY) / 10);
                dst.OneSize = new Size((int)(dst.Size.Width * Pixels.Get()), (int)(dst.Size.Height * Pixels.Get()));
            }
            catch
            {
                MessageBox.Show("文件格式错误");
                return null;
            }
            ///            
            byte byte1, byte2, byte3;// 每3个字节为一组坐标
            dst.MinX = dst.MinY = 0;
            Point point = new Point(0, 0);// 初始坐标
            float pixels = Pixels.Get();
            for (int i = 0; i < stitch.Length; i += 3)
            {
                byte1 = stitch[i];
                byte2 = stitch[i + 1];
                byte3 = stitch[i + 2];
                point.X += Bit(byte1, 0) - Bit(byte1, 1) + Bit(byte1, 2) * 9 - Bit(byte1, 3) * 9 + Bit(byte2, 0) * 3 - Bit(byte2, 1) * 3 + Bit(byte2, 2) * 27 - Bit(byte2, 3) * 27 + Bit(byte3, 2) * 81 - Bit(byte3, 3) * 81;
                point.Y -= Bit(byte1, 7) - Bit(byte1, 6) + Bit(byte1, 5) * 9 - Bit(byte1, 4) * 9 + Bit(byte2, 7) * 3 - Bit(byte2, 6) * 3 + Bit(byte2, 5) * 27 - Bit(byte2, 4) * 27 + Bit(byte3, 5) * 81 - Bit(byte3, 4) * 81;
                if (point.X < dst.MinX) dst.MinX = point.X;// 坐标负值修正
                if (point.Y < dst.MinY) dst.MinY = point.Y;// 坐标负值修正
                dst.Locations.Add(point);// 坐标
                dst.ColorChange.Add((Bit(byte3, 6) == 1));// 换色
                dst.StitchJump.Add((Bit(byte3, 7) == 1));// 跳针
            }
            return dst;
        }
        
        /// <summary>
        /// 取整数的某一位
        /// </summary>
        /// <param name="resource">要取某一位的整数</param>
        /// <param name="mask">要取的位置索引，自右至左为0-7</param>
        /// <returns>返回某一位的值（0或者1）</returns>
        private static int Bit(int resource, int mask)
        {
            return resource >> mask & 1;
        }
        
    }
}
