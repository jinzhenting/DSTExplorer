using System.Collections.Generic;
using System.Drawing;
namespace DSTExplorer
{
    public class DstFile
    {
        private string filePath;
        /// <summary>
        /// 文件磁盘位置
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string fileName;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private int stitchCount;
        /// <summary>
        /// 针数
        /// </summary>
        public int StitchCount
        {
            get { return stitchCount; }
            set { stitchCount = value; }
        }

        private Size size;
        /// <summary>
        /// 尺寸（像素）
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        private Size oneSize;
        /// <summary>
        /// 尺寸（像素）
        /// </summary>
        public Size OneSize
        {
            get { return oneSize; }
            set { oneSize = value; }
        }

        private Size mmSize;
        /// <summary>
        /// 尺寸（mm）
        /// </summary>
        public Size MmSize
        {
            get { return mmSize; }
            set { mmSize = value; }
        }

        private int colorCount;
        /// <summary>
        /// 颜色数
        /// </summary>
        public int ColorCount
        {
            get { return colorCount; }
            set { colorCount = value; }
        }

        private List<bool> colorChange = new List<bool>();
        /// <summary>
        /// 换色指令
        /// </summary>
        public List<bool> ColorChange
        {
            get { return colorChange; }
            set { colorChange = value; }
        }

        private List<Color> colouPlate;
        /// <summary>
        /// 颜色板
        /// </summary>
        public List<Color> ColouPlate
        {
            get { return colouPlate; }
            set { colouPlate = value; }
        }

        private List<Point> locations = new List<Point>();
        /// <summary>
        /// 针迹坐标集
        /// </summary>
        public List<Point> Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        private List<bool> stitchJump = new List<bool>();
        /// <summary>
        /// 跳针指令
        /// </summary>
        public List<bool> StitchJump
        {
            get { return stitchJump; }
            set { stitchJump = value; }
        }

        private int startX;
        /// <summary>
        /// X起点
        /// </summary>
        public int StartX
        {
            get { return startX; }
            set { startX = value; }
        }

        private int endX;
        /// <summary>
        /// X终点
        /// </summary>
        public int EndX
        {
            get { return endX; }
            set { endX = value; }
        }

        private int startY;
        /// <summary>
        /// Y起点
        /// </summary>
        public int StartY
        {
            get { return startY; }
            set { startY = value; }
        }

        private int endY;
        /// <summary>
        /// Y终点
        /// </summary>
        public int EndY
        {
            get { return endY; }
            set { endY = value; }
        }

        private int maxX;
        /// <summary>
        /// 正X最大值
        /// </summary>
        public int MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        private int minX;
        /// <summary>
        /// 负X最大值
        /// </summary>
        public int MinX
        {
            get { return minX; }
            set { minX = value; }
        }

        private int maxY;
        /// <summary>
        /// 正Y最大值
        /// </summary>
        public int MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }

        private int minY;
        /// <summary>
        /// 负Y最大值
        /// </summary>
        public int MinY
        {
            get { return minY; }
            set { minY = value; }
        }
    }
}
