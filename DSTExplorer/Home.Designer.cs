
namespace DSTExplorer
{
    partial class Home
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.infoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.picPanel = new System.Windows.Forms.Panel();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.adaptiveFormButton = new System.Windows.Forms.Button();
            this.zoozUpButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.zoozDownButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.drawBack = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.picPanel.SuspendLayout();
            this.toolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.infoLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 584);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(790, 29);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 23);
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(17, 24);
            this.infoLabel.Text = "   ";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.Location = new System.Drawing.Point(23, 18);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(50, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPanel.Controls.Add(this.pictureBox);
            this.picPanel.Location = new System.Drawing.Point(1, 41);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(788, 542);
            this.picPanel.TabIndex = 7;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolsPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.toolsPanel.Controls.Add(this.exportButton);
            this.toolsPanel.Controls.Add(this.oneButton);
            this.toolsPanel.Controls.Add(this.openButton);
            this.toolsPanel.Controls.Add(this.settingsButton);
            this.toolsPanel.Controls.Add(this.adaptiveFormButton);
            this.toolsPanel.Controls.Add(this.zoozUpButton);
            this.toolsPanel.Controls.Add(this.nextButton);
            this.toolsPanel.Controls.Add(this.zoozDownButton);
            this.toolsPanel.Controls.Add(this.previousButton);
            this.toolsPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(790, 40);
            this.toolsPanel.TabIndex = 10;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Location = new System.Drawing.Point(653, 6);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(65, 30);
            this.exportButton.TabIndex = 13;
            this.exportButton.Text = "导出";
            this.exportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.oneButton.FlatAppearance.BorderSize = 0;
            this.oneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oneButton.Location = new System.Drawing.Point(162, 6);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(85, 30);
            this.oneButton.TabIndex = 12;
            this.oneButton.Text = "实物大小";
            this.oneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Location = new System.Drawing.Point(6, 6);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(65, 30);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "打开";
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Location = new System.Drawing.Point(722, 6);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(65, 30);
            this.settingsButton.TabIndex = 11;
            this.settingsButton.Text = "设置";
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // adaptiveFormButton
            // 
            this.adaptiveFormButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.adaptiveFormButton.FlatAppearance.BorderSize = 0;
            this.adaptiveFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adaptiveFormButton.Location = new System.Drawing.Point(73, 6);
            this.adaptiveFormButton.Name = "adaptiveFormButton";
            this.adaptiveFormButton.Size = new System.Drawing.Size(85, 30);
            this.adaptiveFormButton.TabIndex = 6;
            this.adaptiveFormButton.Text = "适应窗口";
            this.adaptiveFormButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.adaptiveFormButton.UseVisualStyleBackColor = false;
            this.adaptiveFormButton.Click += new System.EventHandler(this.adaptiveFormButton_Click);
            // 
            // zoozUpButton
            // 
            this.zoozUpButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zoozUpButton.FlatAppearance.BorderSize = 0;
            this.zoozUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoozUpButton.Location = new System.Drawing.Point(250, 6);
            this.zoozUpButton.Name = "zoozUpButton";
            this.zoozUpButton.Size = new System.Drawing.Size(65, 30);
            this.zoozUpButton.TabIndex = 7;
            this.zoozUpButton.Text = "放大";
            this.zoozUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoozUpButton.UseVisualStyleBackColor = false;
            this.zoozUpButton.Click += new System.EventHandler(this.zoozUpButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(464, 6);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 30);
            this.nextButton.TabIndex = 10;
            this.nextButton.Text = "下一个";
            this.nextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // zoozDownButton
            // 
            this.zoozDownButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zoozDownButton.FlatAppearance.BorderSize = 0;
            this.zoozDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoozDownButton.Location = new System.Drawing.Point(318, 6);
            this.zoozDownButton.Name = "zoozDownButton";
            this.zoozDownButton.Size = new System.Drawing.Size(65, 30);
            this.zoozDownButton.TabIndex = 8;
            this.zoozDownButton.Text = "缩小";
            this.zoozDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoozDownButton.UseVisualStyleBackColor = false;
            this.zoozDownButton.Click += new System.EventHandler(this.zoozDownButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(386, 6);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 30);
            this.previousButton.TabIndex = 9;
            this.previousButton.Text = "上一个";
            this.previousButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 10;
            this.drawTimer.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // drawBack
            // 
            this.drawBack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.drawBack_DoWork);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(790, 613);
            this.Controls.Add(this.toolsPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.picPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(480, 361);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刺锈文件查看器";
            this.ResizeBegin += new System.EventHandler(this.Home_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Home_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Home_SizeChanged);
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.picPanel.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel infoLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.Panel toolsPanel;
        private System.Windows.Forms.Button zoozUpButton;
        private System.Windows.Forms.Button adaptiveFormButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button zoozDownButton;
        private System.Windows.Forms.Button oneButton;
        /// <summary>
        /// 绘图延时
        /// </summary>
        private System.Windows.Forms.Timer drawTimer;
        private System.ComponentModel.BackgroundWorker drawBack;
        private System.Windows.Forms.Button exportButton;
    }
}

