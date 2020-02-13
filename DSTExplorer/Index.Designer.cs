
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.one_button = new System.Windows.Forms.Button();
            this.open_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.adaptive_form_button = new System.Windows.Forms.Button();
            this.zooz_up_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.zooz_dw_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Pic
            // 
            this.Pic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Pic.Location = new System.Drawing.Point(25, 23);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(50, 50);
            this.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic.TabIndex = 4;
            this.Pic.TabStop = false;
            this.toolTip1.SetToolTip(this.Pic, "鼠标左键移动，滚动缩放。");
            this.Pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.Pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
            this.Pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Pic);
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 553);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.one_button);
            this.panel2.Controls.Add(this.open_button);
            this.panel2.Controls.Add(this.settings_button);
            this.panel2.Controls.Add(this.adaptive_form_button);
            this.panel2.Controls.Add(this.zooz_up_button);
            this.panel2.Controls.Add(this.next_button);
            this.panel2.Controls.Add(this.zooz_dw_button);
            this.panel2.Controls.Add(this.previous_button);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 40);
            this.panel2.TabIndex = 10;
            // 
            // one_button
            // 
            this.one_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.one_button.FlatAppearance.BorderSize = 0;
            this.one_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.one_button.Location = new System.Drawing.Point(162, 5);
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
            this.open_button.Location = new System.Drawing.Point(6, 5);
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
            this.settings_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Location = new System.Drawing.Point(542, 5);
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
            this.adaptive_form_button.Location = new System.Drawing.Point(74, 5);
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
            this.zooz_up_button.Location = new System.Drawing.Point(250, 5);
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
            this.next_button.Location = new System.Drawing.Point(464, 5);
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
            this.zooz_dw_button.Location = new System.Drawing.Point(318, 5);
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
            this.previous_button.Location = new System.Drawing.Point(386, 5);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(75, 30);
            this.previous_button.TabIndex = 9;
            this.previous_button.Text = "上一个";
            this.previous_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(790, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刺锈文件查看器";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox Pic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button zooz_up_button;
        private System.Windows.Forms.Button adaptive_form_button;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button zooz_dw_button;
        private System.Windows.Forms.Button one_button;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

