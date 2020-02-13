using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DSTExplorer
{
    public partial class Index : Form
    {
        #region 初始化
        public Index()
        {
            InitializeComponent();
            this.DoubleBuffered = true;// 双缓冲绘图
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲绘图
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 双缓冲绘图
            this.SetStyle(ControlStyles.UserPaint, true);// 双缓冲绘图
            Pic.MouseWheel += new MouseEventHandler(Pic_MouseWheel);// 手动增加滚轮事件
            open_button.Image = Image.FromFile(@"Icons\folder-fill.png");
            adaptive_form_button.Image = Image.FromFile(@"Icons\compress-alt-fill.png");
            zooz_up_button.Image = Image.FromFile(@"Icons\plus-circle-fill.png");
            zooz_dw_button.Image = Image.FromFile(@"Icons\minus-circle-fill.png");
            previous_button.Image = Image.FromFile(@"Icons\caret-left.png");
            next_button.Image = Image.FromFile(@"Icons\caret-right.png");
            settings_button.Image = Image.FromFile(@"Icons\cog-fill.png");
            one_button.Image = Image.FromFile(@"Icons\1-1.png");
        }
        #endregion 初始化

        #region 元素声明
        private List<string> files;// 文件列表
        private byte[] header;// 文件头
        private byte[] stitch;// 针迹
        private byte[] end;// 文件尾
        private JObject messages;// 文件信息
        private List<Point> points = new List<Point>();// 坐标集
        private List<bool> jump_change = new List<bool>();// 跳针指令
        private bool jump_dw = true;// 是否显示跳针
        private string name;// 带号
        private string path;// 文件位置
        private int stitch_count;// 针数
        private int color_count;// 颜色数
        private List<Color> colou_plate = new List<Color>();// 色板
        private List<bool> color_change = new List<bool>();// 换色指令
        private int x_max;// 正X最大值
        private int x_min;// 负X最大值
        private int y_max;// 正Y最大值
        private int y_min;// 负Y最大值
        private int x_start;// X起点
        private int x_end;// X终点
        private int y_start;// Y起点
        private int y_end;// Y终点
        private Size dst_size;// DST尺寸
        private Size new_size;// 缩放尺寸
        private Bitmap bmp;// 画布
        private Graphics graphics;// 画板
        private float pixels;// 像素转毫米
        #endregion 元素声明

        /// <summary>
        /// 重置文件信息
        /// </summary>
        private void ReFileInfo()
        {
            if (header != null) header = stitch = end = null;
            if (messages != null) messages = null;
            if (points != null) points.Clear();
            if (jump_change != null) jump_change.Clear();
            if (colou_plate != null) colou_plate.Clear();
            if (color_change != null) color_change.Clear();
        }

        /// <summary>
        /// 绘制针迹
        /// </summary>
        /// <param name="in_size">绘制尺寸</param>
        /// <param name="location_mode">针迹位置：保持不变 = "default"；窗口左上 = "left_top"；窗口中心 = "window_center"；鼠标中心 = "mouse_center"；</param>
        public void Draw(Size in_size, string location_mode)
        {
            if (in_size.Width < 100 || in_size.Height < 100)  return; // 最少缩放到100像素
            if (in_size.Width > dst_size.Width * 2.5 || in_size.Height > dst_size.Height * 2.5) return;// 最大放大到原图2.5倍
            
            /// 画板尺寸
            float zooz = 1;// 缩放比
            float width_zooz = 1;// 宽缩放比
            float height_zooz = 1;// 高缩放比
            float dst_width = dst_size.Width;// 
            float dst_height = dst_size.Height;// 
            float in_width = in_size.Width;// 
            float in_height = in_size.Height;// 
            if (dst_width < in_width && dst_height < in_height)// 放大模式
            {
                width_zooz = in_width / dst_width;
                height_zooz = in_height / dst_height;
                if (width_zooz > height_zooz) zooz = height_zooz;// 宽的倍大时，以高的倍数放大
                else if (height_zooz > width_zooz) zooz = width_zooz;// 高的倍大时，以宽的倍数放大
                else if (height_zooz == width_zooz) zooz = height_zooz = width_zooz;
                new_size.Width = (int)(dst_width * zooz);
                new_size.Height = (int)(dst_height * zooz);
            }
            else if (in_width < dst_width || in_height < dst_height)// 缩小模式
            {
                width_zooz = in_width / dst_width;
                height_zooz = in_height / dst_height;
                if (width_zooz > height_zooz) zooz = height_zooz;// 宽的倍大时，以高的倍数放大
                else if (height_zooz > width_zooz) zooz = width_zooz;// 高的倍大时，以宽的倍数放大
                else if (height_zooz == width_zooz) zooz = height_zooz = width_zooz;
                new_size.Width = (int)(dst_width * zooz);
                new_size.Height = (int)(dst_height * zooz);
            }
            else// 1:1模式
            {
                new_size.Width = (int)in_width;
                new_size.Height = (int)in_height;
            }

            /// 位置
            int frame_size = (this.Size.Width - this.ClientSize.Width) / 2;// 窗口边框宽
            int title_size = this.Size.Height - this.ClientSize.Height - frame_size;// 窗口标题栏宽
            float old_mouse_X = Cursor.Position.X - this.Location.X - frame_size - panel1.Location.X;// 旧光标在窗口的X
            float old_mouse_Y = Cursor.Position.Y - this.Location.Y - title_size - panel1.Location.Y;// 旧光标在窗口的Y
            float old_X = Pic.Location.X;// 旧X
            float old_Y = Pic.Location.Y;// 旧Y
            float old_width = Pic.Width;// 旧宽
            float old_height = Pic.Height;// 旧高
            float new_X;// 新X
            float new_Y;// 新Y
            float new_width;// 新宽
            float new_heightH;// 新高
            float zooz_width;// 光标分分割后左部分宽占比
            float zooz_height;// 光标分分割后上部分高占比
            float zooz_X;// 宽放大值
            float zooz_Y;// 高放大值

            /// 绘图
            bmp = new Bitmap(new_size.Width + 5, new_size.Height + 5);// 创建图像
            graphics = Graphics.FromImage(bmp);// 载入画板
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;// 绘图质量 // .InterpolationMode = InterpolationMode.HighQualityBicubic; // .CompositingQuality = CompositingQuality.HighQuality;
            graphics.Clear(panel1.BackColor);// 清空画板
            Point start, end;// 起点终点坐标
            Pen pen = new Pen(colou_plate[0], 1);// 画笔
            int cor = 1; ;// 换色次数
            for (int i = 0; i < points.Count - 1; i++)// 绘制
            {
                if (color_change[i])// 换色
                {
                    pen.Color = colou_plate[cor];
                    cor++;
                }
                if (jump_change[i]) if (jump_dw) continue;// 跳针
                start = points[i];
                end = points[i + 1];
                graphics.DrawLine(pen, (int)((start.X - x_min) * zooz), (int)((start.Y - y_min) * zooz), (int)((end.X - x_min) * zooz), (int)((end.Y - y_min) * zooz));
            }
            graphics.Dispose();

            Pic.Image = bmp;// 载入bmp
            Pic.Width = bmp.Width;
            Pic.Height = bmp.Height;

            /// 位置
            if (location_mode == "windows_center") Pic.Location = new Point((panel1.Width - Pic.Width) / 2, (panel1.Height - Pic.Height) / 2);// 窗口居中
            else if (location_mode == "mouse_center")// 鼠标中心缩放
            {
                if (in_size.Width > new_size.Width && in_size.Height > new_size.Height)// 放大
                {
                    new_width = Pic.Width;
                    new_heightH = Pic.Height;
                    zooz_X = (old_mouse_X - old_X) / old_width;
                    zooz_Y = (old_mouse_Y - old_Y) / old_height;
                    zooz_width = new_width - old_width;
                    zooz_height = new_heightH - old_height;
                    new_X = old_X - zooz_width * zooz_X;
                    new_Y = old_Y - zooz_height * zooz_Y;
                    Pic.Location = new Point((int)new_X, (int)new_Y);
                }
                else// 缩小
                {
                    new_width = Pic.Width;
                    new_heightH = Pic.Height;
                    zooz_X = (old_mouse_X - old_X) / old_width;
                    zooz_Y = (old_mouse_Y - old_Y) / old_height;
                    zooz_width = old_width - new_width;
                    zooz_height = old_height - new_heightH;
                    new_X = old_X + zooz_width * zooz_X;
                    new_Y = old_Y + zooz_height * zooz_Y;
                    Pic.Location = new Point((int)new_X, (int)new_Y);
                }
            }
            else if (location_mode == "left_top") Pic.Location = new Point(0, 0);// 窗口左上
            else if (location_mode == "default") { }// Pic.Location = Pic.Location// 不变
            else
            {
                MessageBox.Show("绘图时位置信息传入错误");
                return;
            }

            ///
            toolStripStatusLabel1.Text = "带号：" + name + " | 针数：" + stitch_count + " | 颜色数：" + color_count + " | 宽：" + dst_size.Width / 10 + "mm | 高：" + dst_size.Height / 10 + "mm | 起针点：X=" + (points[0].X - x_min) / 10 + "mm Y=" + (points[0].Y - y_min) / 10 + "mm | 缩放倍数：" + (zooz/ pixels).ToString("F2");
        }

        /// <summary>
        /// 取整数的某一位
        /// </summary>
        /// <param name="resource">要取某一位的整数</param>
        /// <param name="mask">要取的位置索引，自右至左为0-7</param>
        /// <returns>返回某一位的值（0或者1）</returns>
        public static int Bit(int resource, int mask)
        {
            return resource >> mask & 1;
        }

        /// <summary>
        /// 生成颜色集
        /// </summary>
        /// <returns></returns>
        public void GetRandomColor()
        {
            int R = 0, G = 0, B = 0;
            for (int i = 0; i < color_count; i++)
            {
                R += 10;
                G += 50;
                B += 125;
                if (R > 255) R = 0;
                if (G > 255) G = 0;
                if (B > 255) B = 0;
                colou_plate.Add(Color.FromArgb(R, G, B));
            }
        }

        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="mm">毫米</param>
        /// <returns>像素</returns>
        public static float ToPixels() // length是毫米，1厘米=10毫米
        {
            Panel panel = new Panel();
            Graphics graphics = Graphics.FromHwnd(panel.Handle);
            IntPtr intptr = graphics.GetHdc();
            float width = GetDeviceCaps(intptr, 4);// HORZRES
            float pixels = GetDeviceCaps(intptr, 8);// BITSPIXEL
            graphics.ReleaseHdc(intptr);
            return width / pixels;
        }
        [DllImport("gdi32.dll")]// GDI_API
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);

        /// <summary>
        /// 文件头信息
        /// </summary>
        private void Header()
        {
            string json = "{" + Encoding.Default.GetString(header);// 文件头转换Json
            json = json.Replace(" ", "").Replace("\r", "").Replace("LA:", "\"LA\": \"").Replace("ST:", "\",\"ST\": \"").Replace("CO:", "\",\"CO\": \"").Replace("+X:", "\",\"+X\": \"").Replace("-X:", "\",\"-X\": \"").Replace("+Y:", "\",\"+Y\": \"").Replace("-Y:", "\",\"-Y\": \"").Replace("AX:", "\",\"AX\": \"").Replace("AY:", "\",\"AY\": \"").Replace("MX:", "\",\"MX\": \"").Replace("MY:", "\",\"MY\": \"").Replace("PD:", "\",\"PD\": \"");
            json += "\"}";
            messages = JObject.Parse(json);
            //name = (string)messages["LA"];
            stitch_count = (int)messages["ST"];
            color_count = (int)messages["CO"] + 1;
            x_max = (int)(messages["+X"]);
            x_min = (int)(messages["-X"]);
            y_max = (int)(messages["+Y"]);
            y_min = (int)(messages["-Y"]);
            x_start = (int)(messages["AX"]);
            x_end = (int)(messages["MX"]);
            y_start = (int)(messages["AY"]);
            y_end = (int)(messages["MY"]);
            dst_size.Width = x_max + x_min;
            dst_size.Height = y_max + y_min;
        }

        /// <summary>
        /// 读取文件到字节
        /// </summary>
        private void Read(string path)
        {
            FileStream filestream = File.OpenRead(path);// 读取文件到Byte
            header = new byte[123];
            filestream.Read(header, 0, header.Length);// 提取有信息的文件头
            byte[] tempbyte = new byte[389];
            filestream.Read(tempbyte, 0, tempbyte.Length);// 清除没意义的文件头
            stitch = new byte[filestream.Length - header.Length - tempbyte.Length - 3 - (filestream.Length - 512) % 3];// 总长 - 512 - 3 - 总长除3余数
            filestream.Read(stitch, 0, stitch.Length);// 提取针迹
            end = new byte[filestream.Length - header.Length - stitch.Length];
            filestream.Read(end, 0, end.Length);// 提取结束符
            filestream.Close();
        }

        /// <summary>
        /// 生成坐标集
        /// </summary>
        private void Stitch()
        {
            byte byte1, byte2, byte3;// 每3个字节为一组坐标
            x_min = y_min = 0;
            Point point = new Point(0, 0);// 初始坐标
            for (int i = 0; i < stitch.Length; i += 3)
            {
                byte1 = stitch[i];
                byte2 = stitch[i + 1];
                byte3 = stitch[i + 2];
                point.X += Bit(byte1, 0) - Bit(byte1, 1) + Bit(byte1, 2) * 9 - Bit(byte1, 3) * 9 + Bit(byte2, 0) * 3 - Bit(byte2, 1) * 3 + Bit(byte2, 2) * 27 - Bit(byte2, 3) * 27 + Bit(byte3, 2) * 81 - Bit(byte3, 3) * 81;
                point.Y -= Bit(byte1, 7) - Bit(byte1, 6) + Bit(byte1, 5) * 9 - Bit(byte1, 4) * 9 + Bit(byte2, 7) * 3 - Bit(byte2, 6) * 3 + Bit(byte2, 5) * 27 - Bit(byte2, 4) * 27 + Bit(byte3, 5) * 81 - Bit(byte3, 4) * 81;
                if (point.X < x_min) x_min = point.X;// 坐标负值修正
                if (point.Y < y_min) y_min = point.Y;// 坐标负值修正
                points.Add(point);// 坐标
                color_change.Add((Bit(byte3, 6) == 1));// 换色
                jump_change.Add((Bit(byte3, 7) == 1));// 跳针
            }
        }

        #region 工具栏
        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() != DialogResult.OK) return;
            path = openfiledialog.FileName;
            name = Path.GetFileNameWithoutExtension(path);
            ReFileInfo();// 重置文件信息
            Read(path);// 读取文件到字节
            Header();// 获取文件头信息
            GetRandomColor();// 生成颜色集
            Stitch();// 生针迹坐标
            pixels = ToPixels();
            adaptive_form_button_Click(null, null);// 自适应窗口大小
        }
        private void adaptive_form_button_Click(object sender, EventArgs e) { Draw(new Size(panel1.Width - 100, panel1.Height - 100), "windows_center"); }
        private void zooz_up_button_Click(object sender, EventArgs e) { Draw(new Size((int)(Pic.Width * 1.2), (int)(Pic.Height * 1.2)), "default"); }
        private void zooz_dw_button_Click(object sender, EventArgs e) { Draw(new Size((int)(Pic.Width * 0.8), (int)(Pic.Height * 0.8)), "default"); }
        private void one_button_Click(object sender, EventArgs e) { Draw(new Size((int)(dst_size.Width * pixels), (int)(dst_size.Height * pixels)), "windows_center"); }
        private void previous_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        private void next_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        private void settings_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        #endregion 工具栏

        #region 鼠标功能
        /// 滚轮
        private void Pic_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) Draw(new Size((int)(Pic.Width * 1.2), (int)(Pic.Height * 1.2)), "mouse_center");// 滚轮向上
            else Draw(new Size((int)(Pic.Width * 0.8), (int)(Pic.Height * 0.8)), "mouse_center");// 滚轮向下
        }

        /// 平移功能
        private Point mouse;
        private bool mouse_move;
        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                mouse.X = Cursor.Position.X;// 记录鼠标左键按下时位置
                mouse.Y = Cursor.Position.Y;
                mouse_move = true;
                Pic.Focus();// 鼠标滚轮事件(缩放时)需要picturebox有焦点
            }
        }
        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            Pic.Focus();// 鼠标在picturebox上时才有焦点，此时可以缩放
            if (mouse_move)
            {
                int x, y;// 新的Pic.Location(x,y)
                int moveX, moveY;// X方向，Y方向移动大小。
                moveX = Cursor.Position.X - mouse.X;
                moveY = Cursor.Position.Y - mouse.Y;
                x = Pic.Location.X + moveX;
                y = Pic.Location.Y + moveY;
                Pic.Location = new Point(x, y);
                mouse.X = Cursor.Position.X;
                mouse.Y = Cursor.Position.Y;
            }
        }
        private void Pic_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Left) mouse_move = false;
        }
        #endregion 鼠标功能

        ///
    }
}


#region 解码说明

/* 
维基
https://edutechwiki.unige.ch/en/Embroidery_format_DST

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
文件头（The header）总共512个字节，真正有意义的只有前面的114个字节，相应的数据的含义如下表
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
字节00-19    文件名(最大16字母)
字节20-30    总针数(最大7位)
字节31-37    总的换色次数(最大3位)
字节38-46    X方向的上限值(最大5位)
字节47-55    X方向的下限值(最大5位)
字节56-64    Y方向的上限值(最大5位)
字节65-73    Y方向的下限值(最大5位)
字节74-83    终点的X坐标值(最大6位)(符号占1位)
字节84-93    终点的Y坐标值(最大6位)
字节94-103   返回点的X值(最大6位)(符号占1位)
字节104-113  返回点的Y值(最大6位)(符号占1位)
字节114-127  无意义


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
针位信息记录（Stitch Record）一条针位信息的记录由三个字节表示；字节中三个字节中相应位对应的信息
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
字节1：
++++++
Bit7 : y+1
Bit6 : y-1
Bit5 : y+9
Bit4 : y-9
Bit3 : x-9
Bit2 : x+9
Bit1 : x-1
Bit0 : x+1
++++++
字节2：
++++++
Bit7 : y+3
Bit6 : y-3
Bit5 : y+27
Bit4 : y-27
Bit3 : x-27
Bit2 : x+27
Bit1 : x-3
Bit0 : x+3
++++++
字节3：
++++++
Bit7 : jumprecord（跳针记录）
Bit6 : colorchange（换色）
Bit5 : y+81
Bit4 : y-81
Bit3 : x-81
Bit2 : x+81
Bit1 : ]（总是1）
Bit0 : ]alwaysset（总是1）
++++++
x,y是离上一个点的x方向和y方向的偏移距离。单位(0.1毫米mm)

    
+++++++++++++++++++
文件结束符(The End)
+++++++++++++++++++
0x00,0x00,0x3f

    
++++++++
其他信息
++++++++
最大的针距为：±21.1MM。

*/

#endregion 解码说明