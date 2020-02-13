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
        /// <summary>
        /// 文件列表
        /// </summary>
        private List<string> files;
        /// <summary>
        /// 文件头字节流
        /// </summary>
        private byte[] header;
        /// <summary>
        /// 针迹字节流
        /// </summary>
        private byte[] stitch;
        /// <summary>
        /// 文件尾字节流
        /// </summary>
        private byte[] end;
        /// <summary>
        /// 文件信息
        /// </summary>
        private JObject messages;
        /// <summary>
        /// 带号
        /// </summary>
        private string name;
        /// <summary>
        /// 文件位置
        /// </summary>
        private string path;
        /// <summary>
        /// 针数
        /// </summary>
        private int stitchCount;
        /// <summary>
        /// 颜色数
        /// </summary>
        private int colorCount;
        /// <summary>
        /// 色板
        /// </summary>
        private List<Color> colouPlate = new List<Color>();
        /// <summary>
        /// 换色指令
        /// </summary>
        private List<bool> colorChange = new List<bool>();
        /// <summary>
        /// 正X最大值
        /// </summary>
        private int maxX;
        /// <summary>
        /// 负X最大值
        /// </summary>
        private int minX;
        /// <summary>
        /// 正Y最大值
        /// </summary>
        private int maxY;
        /// <summary>
        /// 负Y最大值
        /// </summary>
        private int minY;
        /// <summary>
        /// X起点
        /// </summary>
        private int startX;
        /// <summary>
        /// X终点
        /// </summary>
        private int endX;
        /// <summary>
        /// Y起点
        /// </summary>
        private int startY;
        /// <summary>
        /// Y终点
        /// </summary>
        private int endY;
        /// <summary>
        /// 窗口边框宽
        /// </summary>
        private int frameSize;
        /// <summary>
        /// 窗口标题栏宽
        /// </summary>
        private int titleSize;
        public Index()
        {
            InitializeComponent();
            this.DoubleBuffered = true; this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); this.SetStyle(ControlStyles.UserPaint, true);// 双缓冲绘图
            pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);// 手动增加滚轮事件
            frameSize = (this.Size.Width - this.ClientSize.Width) / 2;// 窗口边框宽
            titleSize = this.Size.Height - this.ClientSize.Height - frameSize;// 窗口标题栏宽
            pixels = Pixels();// 
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

        /// <summary>
        /// 重置文件信息
        /// </summary>
        private void ReInfo()
        {
            if (header != null) header = stitch = end = null;
            if (messages != null) messages = null;
            if (points != null) points.Clear();
            if (stitchJump != null) stitchJump.Clear();
            if (colouPlate != null) colouPlate.Clear();
            if (colorChange != null) colorChange.Clear();
        }

        #region 绘图
        /// <summary>
        /// DST尺寸
        /// </summary>
        private Size dstSize;
        /// <summary>
        /// 缩放前尺寸
        /// </summary>
        private Size oldSize;
        /// <summary>
        /// 缩放尺寸
        /// </summary>
        private Size newSize;
        /// <summary>
        /// 画布
        /// </summary>
        private Bitmap bmp;
        /// <summary>
        /// 画板
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// 像素转毫米
        /// </summary>
        private float pixels;
        /// <summary>
        /// 针迹坐标集
        /// </summary>
        private List<Point> points = new List<Point>();
        /// <summary>
        /// 跳针指令
        /// </summary>
        private List<bool> stitchJump = new List<bool>();
        /// <summary>
        /// 是否显示跳针
        /// </summary>
        private bool displayJump = true;
        /// <summary>
        /// 缩放前，鼠标左上区域所占尺寸
        /// </summary>
        private Size liftTopSize;
        /// <summary>
        /// 增或减的尺寸
        /// </summary>
        private Size zoozSize;
        /// <summary>
        /// 鼠标左区域缩放率
        /// </summary>
        private float leftZooz;
        /// <summary>
        /// 鼠标上区域缩放率
        /// </summary>
        private float topZooz;
        /// <summary>
        /// 旧光标在窗口坐标
        /// </summary>
        private Point oldMousePoint;
        /// <summary>
        /// 旧坐标
        /// </summary>
        private Point oldPoint;
        /// <summary>
        /// 新坐标
        /// </summary>
        private Point newPoint;
        /// <summary>
        /// 是否缩放
        /// </summary>
        private bool? zooz;
        /// <summary>
        /// 宽缩放比
        /// </summary>
        private float zoozX = 1;
        /// <summary>
        /// 高缩放比
        /// </summary>
        private float zoozY = 1;
        /// <summary>
        /// 总缩放比
        /// </summary>
        private float zoozZ = 1;
        /// <summary>
        /// 缩放计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {






        }
        /// <summary>
        /// 绘制针迹
        /// </summary>
        /// <param name="inSize">绘制尺寸</param>
        /// <param name="location_mode">针迹位置：保持不变 = "default"；窗口左上 = "left_top"；窗口中心 = "window_center"；鼠标中心 = "mouse_center"；</param>
        private void Draw(Size inSize, string location_mode)
        {
            /// 尺寸限定
            if (inSize.Width < 30 || inSize.Height < 30) return; // 最少缩放到100像素
            if (inSize.Width > dstSize.Width * 5 || inSize.Height > dstSize.Height * 5) return;// 最大放大到原图2.5倍
            

            /// 缩放模式（相对于原DST尺寸）
            if (dstSize.Width < inSize.Width && dstSize.Height < inSize.Height) zooz = true;// 宽和高同时大于，放大模式
            else if (inSize.Width < dstSize.Width || inSize.Height < dstSize.Height) zooz = false;// 宽或高任意小于，缩小模式
            else zooz = null;// 宽高相等，1:1模式

            /// 画板尺寸
            if (zooz == true)// 放大模式
            {
                zoozX = (float)inSize.Width / (float)dstSize.Width;
                zoozY = (float)inSize.Height / (float)dstSize.Height;
                if (zoozX > zoozY) zoozZ = zoozY;// 宽的倍大时，以高的倍数放大
                else if (zoozY > zoozX) zoozZ = zoozX;// 高的倍大时，以宽的倍数放大
                else if (zoozY == zoozX) zoozZ = zoozY = zoozX;// 前面已排除1：1模式，理论上不存在zoozY == zoozX情况，但数值太大进行Float转换时，会出现误差，有概率发生此情况
            }
            else if (zooz == false)// 缩小模式
            {
                zoozX = (float)inSize.Width / (float)dstSize.Width;
                zoozY = (float)inSize.Height / (float)dstSize.Height;
                if (zoozX > zoozY) zoozZ = zoozY;// 宽的倍大时，以高的倍数放大
                else if (zoozY > zoozX) zoozZ = zoozX;// 高的倍大时，以宽的倍数放大
                else if (zoozY == zoozX) zoozZ = zoozY = zoozX;// 前面已排除1：1模式，理论上不存在zoozY == zoozX情况，但数值太大进行Float转换时，会出现误差，有概率发生此情况
            }
            else zoozZ = 1;// 1:1模式
            newSize = new Size((int)(dstSize.Width * zoozZ), (int)(dstSize.Height * zoozZ));// 得到绘制尺寸

            /// 位置
            oldMousePoint = new Point(Cursor.Position.X - Location.X - frameSize - picPanel.Location.X, Cursor.Position.Y - Location.Y - titleSize - picPanel.Location.Y);// 旧光标在窗口坐标
            oldPoint = pictureBox.Location;// 旧坐标
            oldSize = pictureBox.Size;// 旧尺寸


             


            /// 绘图
            bmp = new Bitmap(newSize.Width, newSize.Height);// 创建图像
            graphics = Graphics.FromImage(bmp);// 载入画板
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;// 绘图质量 // .InterpolationMode = InterpolationMode.HighQualityBicubic; // .CompositingQuality = CompositingQuality.HighQuality;
            graphics.Clear(picPanel.BackColor);// 清空画板
            Point start, end;// 起点终点坐标
            Pen pen = new Pen(colouPlate[0], 1);// 画笔
            int corCount = 1; ;// 换色次数
            for (int i = 0; i < points.Count - 1; i++)// 绘制
            {
                if (colorChange[i])// 换色
                {
                    pen.Color = colouPlate[corCount];
                    corCount++;
                }
                if (stitchJump[i]) if (displayJump) continue;// 跳针
                start = points[i];
                end = points[i + 1];
                graphics.DrawLine(pen, (int)((start.X - minX) * zoozZ), (int)((start.Y - minY) * zoozZ), (int)((end.X - minX) * zoozZ), (int)((end.Y - minY) * zoozZ));
            }
            graphics.Dispose();

            /// 载入画布先后级
            if (newSize.Width > oldSize.Width)
            {
                pictureBox.Size = newSize = bmp.Size;// 新尺寸
                pictureBox.Image = bmp;// 载入bmp
            }
            else
            {
                pictureBox.Image = bmp;// 载入bmp
                pictureBox.Size = newSize = bmp.Size;// 新尺寸
            }

            /// 位置
            liftTopSize = new Size(oldMousePoint.X - oldPoint.X, oldMousePoint.Y - oldPoint.Y);// 缩放前，鼠标左上区域所占尺寸
            leftZooz = (float)liftTopSize.Width / (float)oldSize.Width;// 缩放前，左边占总宽百分比
            topZooz = (float)liftTopSize.Height / (float)oldSize.Height;// 缩放前，上边占总高百分比
            zoozSize = new Size(newSize.Width - oldSize.Width, newSize.Height - oldSize.Height);// 增或减的尺寸，增为正，减为负
            if (location_mode == "windows_center") newPoint = new Point((picPanel.Width - pictureBox.Width) / 2, (picPanel.Height - pictureBox.Height) / 2);// 窗口居中
            else if (location_mode == "mouse_center") newPoint = new Point(oldPoint.X - (int)(leftZooz * zoozSize.Width), oldPoint.Y - (int)(topZooz * zoozSize.Height));// 鼠标中心缩放 zoozSize的值分正负
            else if (location_mode == "left_top") newPoint = new Point(0, 0);// 窗口左上
            else if (location_mode == "default") { }// 不变
            else MessageBox.Show("绘图时位置信息传入错误");
            pictureBox.Location = newPoint;

            ///
            infoLabel.Text = "带号：" + name + " | 针数：" + stitchCount + " | 颜色数：" + colorCount + " | 宽：" + dstSize.Width / 10 + "mm | 高：" + dstSize.Height / 10 + "mm | 起针点：X=" + (points[0].X - minX) / 10 + "mm Y=" + (points[0].Y - minY) / 10 + "mm | 缩放倍数：" + (zoozZ / pixels).ToString("F2");
        }
        #endregion 绘图

        /// <summary>
        /// 生成颜色集
        /// </summary>
        /// <returns></returns>
        private void GetRandomColor()
        {
            int R = 0, G = 0, B = 0;
            for (int i = 0; i < colorCount; i++)
            {
                R += 10;
                G += 50;
                B += 125;
                if (R > 255) R = 0;
                if (G > 255) G = 0;
                if (B > 255) B = 0;
                colouPlate.Add(Color.FromArgb(R, G, B));
            }
        }

        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="mm">毫米</param>
        /// <returns>像素</returns>
        public static float Pixels() // length是毫米，1厘米=10毫米
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
            stitchCount = (int)messages["ST"];
            colorCount = (int)messages["CO"] + 1;
            maxX = (int)(messages["+X"]);
            minX = (int)(messages["-X"]);
            maxY = (int)(messages["+Y"]);
            minY = (int)(messages["-Y"]);
            startX = (int)(messages["AX"]);
            endX = (int)(messages["MX"]);
            startY = (int)(messages["AY"]);
            endY = (int)(messages["MY"]);
            dstSize.Width = maxX + minX;
            dstSize.Height = maxY + minY;
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
            minX = minY = 0;
            Point point = new Point(0, 0);// 初始坐标
            for (int i = 0; i < stitch.Length; i += 3)
            {
                byte1 = stitch[i];
                byte2 = stitch[i + 1];
                byte3 = stitch[i + 2];
                point.X += Bit(byte1, 0) - Bit(byte1, 1) + Bit(byte1, 2) * 9 - Bit(byte1, 3) * 9 + Bit(byte2, 0) * 3 - Bit(byte2, 1) * 3 + Bit(byte2, 2) * 27 - Bit(byte2, 3) * 27 + Bit(byte3, 2) * 81 - Bit(byte3, 3) * 81;
                point.Y -= Bit(byte1, 7) - Bit(byte1, 6) + Bit(byte1, 5) * 9 - Bit(byte1, 4) * 9 + Bit(byte2, 7) * 3 - Bit(byte2, 6) * 3 + Bit(byte2, 5) * 27 - Bit(byte2, 4) * 27 + Bit(byte3, 5) * 81 - Bit(byte3, 4) * 81;
                if (point.X < minX) minX = point.X;// 坐标负值修正
                if (point.Y < minY) minY = point.Y;// 坐标负值修正
                points.Add(point);// 坐标
                colorChange.Add((Bit(byte3, 6) == 1));// 换色
                stitchJump.Add((Bit(byte3, 7) == 1));// 跳针
            }
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

        #region 工具栏
        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() != DialogResult.OK) return;
            path = openfiledialog.FileName;
            name = Path.GetFileNameWithoutExtension(path);
            ReInfo();// 重置文件信息
            Read(path);// 读取文件到字节
            Header();// 获取文件头信息
            GetRandomColor();// 生成颜色集
            Stitch();// 生针迹坐标
            adaptive_form_button_Click(null, null);// 自适应窗口大小
        }
        private void adaptive_form_button_Click(object sender, EventArgs e) { Draw(new Size(picPanel.Width - 100, picPanel.Height - 100), "windows_center"); }
        private void zooz_up_button_Click(object sender, EventArgs e) { Draw(new Size((int)(pictureBox.Width * 1.2), (int)(pictureBox.Height * 1.2)), "default"); }
        private void zooz_dw_button_Click(object sender, EventArgs e) { Draw(new Size((int)(pictureBox.Width * 0.8), (int)(pictureBox.Height * 0.8)), "default"); }
        private void one_button_Click(object sender, EventArgs e) { Draw(new Size((int)(dstSize.Width * pixels), (int)(dstSize.Height * pixels)), "windows_center"); }
        private void previous_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        private void next_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        private void settings_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }
        #endregion 工具栏

        #region 鼠标功能
        /// 滚轮
        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) Draw(new Size((int)(pictureBox.Width * 1.2), (int)(pictureBox.Height * 1.2)), "mouse_center");// 滚轮向上
            else Draw(new Size((int)(pictureBox.Width * 0.8), (int)(pictureBox.Height * 0.8)), "mouse_center");// 滚轮向下
        }

        /// 平移功能
        private Point mouse;
        private bool mouse_move;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                mouse.X = Cursor.Position.X;// 记录鼠标左键按下时位置
                mouse.Y = Cursor.Position.Y;
                mouse_move = true;
                pictureBox.Focus();// 鼠标滚轮事件(缩放时)需要PictureBox有焦点
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox.Focus();// 鼠标在PictureBox上时才有焦点，此时可以缩放
            if (mouse_move)
            {
                int x, y;// 新的pictureBox.Location(x,y)
                int moveX, moveY;// X方向，Y方向移动大小。
                moveX = Cursor.Position.X - mouse.X;
                moveY = Cursor.Position.Y - mouse.Y;
                x = pictureBox.Location.X + moveX;
                y = pictureBox.Location.Y + moveY;
                pictureBox.Location = new Point(x, y);
                mouse.X = Cursor.Position.X;
                mouse.Y = Cursor.Position.Y;
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
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