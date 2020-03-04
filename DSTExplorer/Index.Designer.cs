
namespace DSTExplorer
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.infoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.picPanel = new System.Windows.Forms.Panel();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.export_button = new System.Windows.Forms.Button();
            this.one_button = new System.Windows.Forms.Button();
            this.open_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.adaptive_form_button = new System.Windows.Forms.Button();
            this.zooz_up_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.zooz_dw_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.backDraw = new System.ComponentModel.BackgroundWorker();
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
            this.toolsPanel.Controls.Add(this.export_button);
            this.toolsPanel.Controls.Add(this.one_button);
            this.toolsPanel.Controls.Add(this.open_button);
            this.toolsPanel.Controls.Add(this.settings_button);
            this.toolsPanel.Controls.Add(this.adaptive_form_button);
            this.toolsPanel.Controls.Add(this.zooz_up_button);
            this.toolsPanel.Controls.Add(this.next_button);
            this.toolsPanel.Controls.Add(this.zooz_dw_button);
            this.toolsPanel.Controls.Add(this.previous_button);
            this.toolsPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(790, 40);
            this.toolsPanel.TabIndex = 10;
            // 
            // export_button
            // 
            this.export_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.export_button.FlatAppearance.BorderSize = 0;
            this.export_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export_button.Location = new System.Drawing.Point(653, 6);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(65, 30);
            this.export_button.TabIndex = 13;
            this.export_button.Text = "导出";
            this.export_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.export_button.UseVisualStyleBackColor = false;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // one_button
            // 
            this.one_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.one_button.FlatAppearance.BorderSize = 0;
            this.one_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.one_button.Location = new System.Drawing.Point(162, 6);
            this.one_button.Name = "one_button";
            this.one_button.Size = new System.Drawing.Size(85, 30);
            this.one_button.TabIndex = 12;
            this.one_button.Text = "实物大小";
            this.one_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.one_button.UseVisualStyleBackColor = false;
            this.one_button.Click += new System.EventHandler(this.one_button_Click);
            // 
            // open_button
            // 
            this.open_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.open_button.FlatAppearance.BorderSize = 0;
            this.open_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_button.Location = new System.Drawing.Point(6, 6);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(65, 30);
            this.open_button.TabIndex = 5;
            this.open_button.Text = "打开";
            this.open_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.open_button.UseVisualStyleBackColor = false;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // settings_button
            // 
            this.settings_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Location = new System.Drawing.Point(722, 6);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(65, 30);
            this.settings_button.TabIndex = 11;
            this.settings_button.Text = "设置";
            this.settings_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settings_button.UseVisualStyleBackColor = false;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // adaptive_form_button
            // 
            this.adaptive_form_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.adaptive_form_button.FlatAppearance.BorderSize = 0;
            this.adaptive_form_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adaptive_form_button.Location = new System.Drawing.Point(73, 6);
            this.adaptive_form_button.Name = "adaptive_form_button";
            this.adaptive_form_button.Size = new System.Drawing.Size(85, 30);
            this.adaptive_form_button.TabIndex = 6;
            this.adaptive_form_button.Text = "适应窗口";
            this.adaptive_form_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.adaptive_form_button.UseVisualStyleBackColor = false;
            this.adaptive_form_button.Click += new System.EventHandler(this.adaptive_form_button_Click);
            // 
            // zooz_up_button
            // 
            this.zooz_up_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zooz_up_button.FlatAppearance.BorderSize = 0;
            this.zooz_up_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zooz_up_button.Location = new System.Drawing.Point(250, 6);
            this.zooz_up_button.Name = "zooz_up_button";
            this.zooz_up_button.Size = new System.Drawing.Size(65, 30);
            this.zooz_up_button.TabIndex = 7;
            this.zooz_up_button.Text = "放大";
            this.zooz_up_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zooz_up_button.UseVisualStyleBackColor = false;
            this.zooz_up_button.Click += new System.EventHandler(this.zooz_up_button_Click);
            // 
            // next_button
            // 
            this.next_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.next_button.FlatAppearance.BorderSize = 0;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Location = new System.Drawing.Point(464, 6);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 30);
            this.next_button.TabIndex = 10;
            this.next_button.Text = "下一个";
            this.next_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // zooz_dw_button
            // 
            this.zooz_dw_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zooz_dw_button.FlatAppearance.BorderSize = 0;
            this.zooz_dw_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zooz_dw_button.Location = new System.Drawing.Point(318, 6);
            this.zooz_dw_button.Name = "zooz_dw_button";
            this.zooz_dw_button.Size = new System.Drawing.Size(65, 30);
            this.zooz_dw_button.TabIndex = 8;
            this.zooz_dw_button.Text = "缩小";
            this.zooz_dw_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zooz_dw_button.UseVisualStyleBackColor = false;
            this.zooz_dw_button.Click += new System.EventHandler(this.zooz_dw_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.previous_button.FlatAppearance.BorderSize = 0;
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_button.Location = new System.Drawing.Point(386, 6);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(75, 30);
            this.previous_button.TabIndex = 9;
            this.previous_button.Text = "上一个";
            this.previous_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 10;
            this.drawTimer.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // backDraw
            // 
            this.backDraw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backDraw_DoWork);
            // 
            // Index
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
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刺锈文件查看器";
            this.ResizeBegin += new System.EventHandler(this.Index_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Index_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Index_SizeChanged);
            this.Resize += new System.EventHandler(this.Index_Resize);
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
        private System.Windows.Forms.Button zooz_up_button;
        private System.Windows.Forms.Button adaptive_form_button;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button zooz_dw_button;
        private System.Windows.Forms.Button one_button;
        /// <summary>
        /// 绘图延时
        /// </summary>
        private System.Windows.Forms.Timer drawTimer;
        private System.ComponentModel.BackgroundWorker backDraw;
        private System.Windows.Forms.Button export_button;
    }
}

