using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;

/*
 * 
 * 进度：
 * 导出EMF改为导出PLT
 * 
 * 
 * 
 * 
 * 
 * 
*/


namespace DSTExplorer
{
    public partial class Index : Form
    {
        #region 初始化

        /// <summary>
        /// 刺绣文件列表
        /// </summary>
        private FileInfo[] files;

        /// <summary>
        /// 刺绣文件
        /// </summary>
        private DstFile dst;

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
            ///
            this.DoubleBuffered = true;// 双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.Opaque, true);// 不绘制窗口背景
            ///
            pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);// 手动增加滚轮事件
            ///
            frameSize = (this.Size.Width - this.ClientSize.Width) / 2;// 窗口边框宽
            titleSize = this.Size.Height - this.ClientSize.Height - frameSize;// 窗口标题栏宽
            ///
            open_button.Image = Image.FromFile(@"Icons\folder-fill.png");
            adaptive_form_button.Image = Image.FromFile(@"Icons\compress-alt-fill.png");
            zooz_up_button.Image = Image.FromFile(@"Icons\plus-circle-fill.png");
            zooz_dw_button.Image = Image.FromFile(@"Icons\minus-circle-fill.png");
            previous_button.Image = Image.FromFile(@"Icons\caret-left.png");
            next_button.Image = Image.FromFile(@"Icons\caret-right.png");
            settings_button.Image = Image.FromFile(@"Icons\cog-fill.png");
            one_button.Image = Image.FromFile(@"Icons\1-1.png");
            export_button.Image = Image.FromFile(@"Icons\share.png");
            //picPanel.BackgroundImage = Image.FromFile(@"image/01.jpg");// 载入背景
            //picPanel.BackColor = Color.Red;
            pictureBox.BackColor = Color.Transparent;
        }
        #endregion 初始化

        #region 绘图
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
        /// 是否显示跳针
        /// </summary>
        private bool displayJump = true;
        /// <summary>
        /// 缩放前，缩放点左上区域所占尺寸
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
        private Point oldMouseLocation;
        /// <summary>
        /// 旧坐标
        /// </summary>
        private Point oldLocation;
        /// <summary>
        /// 新坐标
        /// </summary>
        private Point newLocation;
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
        /// 缩放
        /// </summary>
        /// <param name="inSize">绘制尺寸</param>
        /// <param name="location_mode">针迹位置：保持不变 = "default"；窗口左上 = "left_top"；窗口中心 = "window_center"；鼠标中心 = "mouse_center"；</param>
        private void Zooz(Size inSize, string location_mode)
        {
            #region 缩放限定
            if (inSize.Width > 20480 || inSize.Height > 20480)
            {
                MessageBox.Show("分辨率超出最大支持范围：20480 x 20480");
                return;
            }
            else if (inSize.Width < 50 || inSize.Height < 50)
            {
                MessageBox.Show("分辨率超出最小支持范围：50 x 50");
                return;
            }
            #endregion 缩放限定

            drawTimer.Stop();// 延时开关
            oldSize = pictureBox.Size;// 旧尺寸
            oldMouseLocation = new Point(Cursor.Position.X - Location.X - frameSize - picPanel.Location.X, Cursor.Position.Y - Location.Y - titleSize - picPanel.Location.Y);// 旧光标在窗口坐标
            oldLocation = pictureBox.Location;// 旧坐标

            #region 新尺寸
            zoozX = (float)inSize.Width / (float)dst.Size.Width;
            zoozY = (float)inSize.Height / (float)dst.Size.Height;
            if (zoozX > zoozY) zoozZ = zoozY;// 宽的倍大时，以高的倍数放大
            else if (zoozY > zoozX) zoozZ = zoozX;// 高的倍大时，以宽的倍数放大
            else if (zoozY == zoozX) zoozZ = zoozY = zoozX;// 前面已排除1：1模式，理论上不存在zoozY == zoozX情况，但数值太大进行Float转换时，会出现误差，有概率发生此情况
            newSize = new Size((int)(dst.Size.Width * zoozZ), (int)(dst.Size.Height * zoozZ));// 得到绘制尺寸
            pictureBox.Size = newSize;
            #endregion 新尺寸

            #region 新坐标
            if (location_mode == "pic_center") newLocation = new Point((picPanel.Width - pictureBox.Width) / 2, (picPanel.Height - pictureBox.Height) / 2);// 图片中心对齐窗口中心
            else if (location_mode == "mouse_center")// 鼠标中心缩放 zoozSize的值分正负
            {
                liftTopSize = new Size(oldMouseLocation.X - oldLocation.X, oldMouseLocation.Y - oldLocation.Y);// 缩放前，鼠标左上区域所占尺寸
                leftZooz = (float)liftTopSize.Width / (float)oldSize.Width;// 缩放前，缩放点左边占总宽百分比
                topZooz = (float)liftTopSize.Height / (float)oldSize.Height;// 缩放前，缩放点上边占总高百分比
                zoozSize = new Size(pictureBox.Width - oldSize.Width, pictureBox.Height - oldSize.Height);// 增或减的尺寸，增为正，减为负
                newLocation = new Point(oldLocation.X - (int)(leftZooz * zoozSize.Width), oldLocation.Y - (int)(topZooz * zoozSize.Height));
            }
            else if (location_mode == "left_top") newLocation = new Point(0, 0);// 对齐窗口左上
            else if (location_mode == "windows_center")// 窗口中心缩放 zoozSize的值分正负
            {
                liftTopSize = new Size(picPanel.Width / 2 - oldLocation.X, picPanel.Height / 2 - oldLocation.Y);// 缩放前，缩放点左上区域所占尺寸
                leftZooz = (float)liftTopSize.Width / (float)oldSize.Width;// 缩放前，缩放点左边占总宽百分比
                topZooz = (float)liftTopSize.Height / (float)oldSize.Height;// 缩放前，缩放点上边占总高百分比
                zoozSize = new Size(pictureBox.Width - oldSize.Width, pictureBox.Height - oldSize.Height);// 增或减的尺寸，增为正，减为负
                newLocation = new Point(oldLocation.X - (int)(leftZooz * zoozSize.Width), oldLocation.Y - (int)(topZooz * zoozSize.Height));
            }
            else if (location_mode == "default") { }// 不变
            else MessageBox.Show("绘图时位置信息传入错误，坐标保持不变");
            pictureBox.Location = newLocation;
            #endregion 新坐标

            if (oldSize != newSize) drawTimer.Start();// 绘制

            /// 信息
            infoLabel.Text = "带号：" + dst.FileName + " | 针数：" + dst.StitchCount + " | 颜色数：" + dst.ColorCount + " | 宽：" + dst.MmSize.Width + "mm | 高：" + dst.MmSize.Height + "mm | 起针点：X=" + (dst.Locations[0].X - dst.MinX) / 10 + "mm Y=" + (dst.Locations[0].Y - dst.MinY) / 10 + "mm | 缩放倍数：" + (zoozZ / Pixels.Get()).ToString("F2");

        }
        /// <summary>
        /// 绘图延时
        /// </summary>
        private void timerDraw_Tick(object sender, EventArgs e)
        {
            drawTimer.Stop();
            if (backDraw.IsBusy) return;
            backDraw.RunWorkerAsync();
        }
        /// <summary>
        /// 绘图
        /// </summary>
        private void backDraw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (drawTimer.Enabled) return;// 检测延时有否重置
            bmp = new Bitmap(newSize.Width, newSize.Height);// 创建图像
            graphics = Graphics.FromImage(bmp);// 载入画板
            graphics.SmoothingMode = SmoothingMode.AntiAlias;// 绘图质量
            graphics.InterpolationMode = InterpolationMode.Low;
            graphics.CompositingQuality = CompositingQuality.Default;
            graphics.Clear(Color.Transparent);// 清空画板
            Point startLocation, endLocation;// 起点终点坐标
            Pen pen = new Pen(dst.ColouPlate[0], 1);// 画笔
            int corCount = 1; ;// 换色次数
            for (int i = 0; i < dst.Locations.Count - 1; i++)// 绘制
            {
                if (drawTimer.Enabled) return;// 检测延时有否重置
                if (dst.ColorChange[i])// 换色
                {
                    pen.Color = dst.ColouPlate[corCount];
                    corCount++;
                }
                if (dst.StitchJump[i]) if (displayJump) continue;// 跳针
                startLocation = dst.Locations[i];
                endLocation = dst.Locations[i + 1];
                graphics.DrawLine(pen, (int)((startLocation.X - dst.MinX) * zoozZ), (int)((startLocation.Y - dst.MinY) * zoozZ), (int)((endLocation.X - dst.MinX) * zoozZ), (int)((endLocation.Y - dst.MinY) * zoozZ));
            }
            pictureBox.Image = bmp;
            graphics.Dispose();
        }
        #endregion 绘图


        #region 工具栏
        /// <summary>
        /// 打开
        /// </summary>
        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "刺绣文件(*.dst)|*.dst";// 文件类型
            openfiledialog.DefaultExt = "dst";// 默认格式
            if (openfiledialog.ShowDialog() != DialogResult.OK) return;
            dst = DstDecode.LoadFile(openfiledialog.FileName);
            Zooz(picPanel.Size, "pic_center");
            ///
            DirectoryInfo directorys = new DirectoryInfo(Path.GetDirectoryName(openfiledialog.FileName));
            files = directorys.GetFiles(@"*.dst", SearchOption.TopDirectoryOnly);// 扫描
            if (files.Length > 1)
            {
                previous_button.Enabled = true;
                next_button.Enabled = true;
            }
            else
            {
                previous_button.Enabled = false;
                next_button.Enabled = false;
            }
        }

        /// <summary>
        /// 适应窗口
        /// </summary>
        private void adaptive_form_button_Click(object sender, EventArgs e)
        {
            if (dst != null) Zooz(picPanel.Size, "pic_center");
            else MessageBox.Show("未选择刺绣文件");
        }

        /// <summary>
        /// 放大
        /// </summary>
        private void zooz_up_button_Click(object sender, EventArgs e)
        {
            if (dst != null) Zooz(new Size((int)(pictureBox.Width * 1.2), (int)(pictureBox.Height * 1.2)), "windows_center");
            else MessageBox.Show("未选择刺绣文件");
        }

        /// <summary>
        /// 缩小
        /// </summary>
        private void zooz_dw_button_Click(object sender, EventArgs e)
        {
            if (dst != null) Zooz(new Size((int)(pictureBox.Width * 0.8), (int)(pictureBox.Height * 0.8)), "windows_center");
            else MessageBox.Show("未选择刺绣文件");
        }

        /// <summary>
        /// 实物大小
        /// </summary>
        private void one_button_Click(object sender, EventArgs e)
        {
            if (dst != null) Zooz(dst.OneSize, "pic_center");
            else MessageBox.Show("未选择刺绣文件");
        }

        /// <summary>
        /// 上一个
        /// </summary>
        private void previous_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }

        /// <summary>
        /// 下一个
        /// </summary>
        private void next_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }

        /// <summary>
        /// 设置
        /// </summary>
        private void settings_button_Click(object sender, EventArgs e) { MessageBox.Show("功能未完成"); }

        /// <summary>
        /// 导出
        /// </summary>
        private void export_button_Click(object sender, EventArgs e)
        {
            if (dst != null) Export();
            else MessageBox.Show("未选择刺绣文件");
        }
        #endregion 工具栏

        #region 鼠标功能
        /// 滚轮
        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) Zooz(new Size((int)(pictureBox.Width * 1.2), (int)(pictureBox.Height * 1.2)), "mouse_center");// 滚轮向上
            else Zooz(new Size((int)(pictureBox.Width * 0.8), (int)(pictureBox.Height * 0.8)), "mouse_center");// 滚轮向下
        }

        /// 平移功能
        private Point mousePosition;
        private bool mouseMove;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                mousePosition.X = Cursor.Position.X;// 记录鼠标左键按下时位置
                mousePosition.Y = Cursor.Position.Y;
                mouseMove = true;
                pictureBox.Focus();// 鼠标滚轮事件(缩放时)需要PictureBox有焦点
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox.Focus();// 鼠标在PictureBox上时才有焦点，此时可以缩放
            if (mouseMove)
            {
                int x, y;// 新的pictureBox.Location(x,y)
                int moveX, moveY;// X方向，Y方向移动大小。
                moveX = Cursor.Position.X - mousePosition.X;
                moveY = Cursor.Position.Y - mousePosition.Y;
                x = pictureBox.Location.X + moveX;
                y = pictureBox.Location.Y + moveY;
                pictureBox.Location = new Point(x, y);
                mousePosition.X = Cursor.Position.X;
                mousePosition.Y = Cursor.Position.Y;
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Left) mouseMove = false;
        }
        #endregion 鼠标功能

        #region 窗口调整功能
        //private Size windowsOld;
        //private Size windowsAdd;
        //float windowsZoozX;
        //float windowsZoozY;
        //float windowsZoozZ;
        private void Index_Resize(object sender, EventArgs e)
        {

        }
        private void Index_SizeChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗口调整前
        /// </summary>
        private void Index_ResizeBegin(object sender, EventArgs e)
        {
            //windowsOld = Size;
        }
        /// <summary>
        /// 窗口调整后
        /// </summary>
        private void Index_ResizeEnd(object sender, EventArgs e)
        {
            //windowsAdd = new Size(Width - windowsOld.Width, Height - windowsOld.Height);// 增加或减少的大小
            //windowsZoozX = (float)Width / (float)windowsOld.Width;// 宽增加或减少的百分比
            //windowsZoozY = (float)Height / (float)windowsOld.Height;// 高增加或减少的百分比
            //if (windowsZoozX > windowsZoozY) windowsZoozZ = windowsZoozY;// 宽增加的百分比较大时，以高的百分比缩放
            //else if (windowsZoozY > windowsZoozX) windowsZoozZ = windowsZoozX;// 高增加的百分比较大时，以宽的百分比缩放
            //else windowsZoozZ = windowsZoozX = windowsZoozY;// 相等
            //MessageBox.Show(windowsZoozZ + " ");
            //if (File.Exists(path)) Zooz(new Size((int)(pictureBox.Width * windowsZoozZ), (int)(pictureBox.Height * windowsZoozZ)), "windows_center");
            //else MessageBox.Show("未选择刺绣文件");
        }















        #endregion 窗口调整功能

        /// <summary>
        /// 导出EMF
        /// </summary>
        private void Export()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "惠普绘图仪文件(*.plt)|*.plt";// 文件类型
            saveFileDialog.FileName = dst.FileName;// 默认文件名
            saveFileDialog.DefaultExt = "plt";// 默认格式
            saveFileDialog.AddExtension = true;// 自动添加扩展名
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            ///
            CorelDraw.Emf2Plt(Emf.Save(dst, displayJump), saveFileDialog.FileName);
            MessageBox.Show("完成");
        }
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