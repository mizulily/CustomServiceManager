namespace CustomServiceManager
{
    partial class Manager
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
            this.cbbServListConfig = new System.Windows.Forms.ComboBox();
            this.lsbServListConfig = new System.Windows.Forms.ListBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslManagerInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPause = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServInfo = new System.Windows.Forms.Label();
            this.btnMode = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.softwareInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEventCnt = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbServListConfig
            // 
            this.cbbServListConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbServListConfig.FormattingEnabled = true;
            this.cbbServListConfig.Location = new System.Drawing.Point(57, 52);
            this.cbbServListConfig.Name = "cbbServListConfig";
            this.cbbServListConfig.Size = new System.Drawing.Size(148, 26);
            this.cbbServListConfig.TabIndex = 0;
            // 
            // lsbServListConfig
            // 
            this.lsbServListConfig.FormattingEnabled = true;
            this.lsbServListConfig.ItemHeight = 18;
            this.lsbServListConfig.Location = new System.Drawing.Point(32, 98);
            this.lsbServListConfig.Name = "lsbServListConfig";
            this.lsbServListConfig.Size = new System.Drawing.Size(325, 292);
            this.lsbServListConfig.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(228, 51);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(109, 32);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "Group...";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(122, 48);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(139, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(122, 48);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(139, 60);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(122, 48);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslManagerInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(678, 29);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslManagerInfo
            // 
            this.sslManagerInfo.Name = "sslManagerInfo";
            this.sslManagerInfo.Size = new System.Drawing.Size(195, 24);
            this.sslManagerInfo.Text = "toolStripStatusLabel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnPause, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRestart, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(385, 234);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 115);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(3, 60);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(122, 48);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Service List";
            // 
            // btnEvent
            // 
            this.btnEvent.Location = new System.Drawing.Point(546, 356);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(100, 34);
            this.btnEvent.TabIndex = 9;
            this.btnEvent.Text = "Event...";
            this.btnEvent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(382, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Service Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(382, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Service Process";
            // 
            // lblServInfo
            // 
            this.lblServInfo.Location = new System.Drawing.Point(385, 48);
            this.lblServInfo.Name = "lblServInfo";
            this.lblServInfo.Size = new System.Drawing.Size(273, 152);
            this.lblServInfo.TabIndex = 12;
            // 
            // btnMode
            // 
            this.btnMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnMode.Location = new System.Drawing.Point(388, 355);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(53, 34);
            this.btnMode.TabIndex = 13;
            this.btnMode.Text = "OFF";
            this.btnMode.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 32);
            // 
            // softwareInfoToolStripMenuItem
            // 
            this.softwareInfoToolStripMenuItem.Name = "softwareInfoToolStripMenuItem";
            this.softwareInfoToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
            this.softwareInfoToolStripMenuItem.Text = "Software Info...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Enabled";
            // 
            // lblEventCnt
            // 
            this.lblEventCnt.AutoSize = true;
            this.lblEventCnt.Location = new System.Drawing.Point(447, 364);
            this.lblEventCnt.Name = "lblEventCnt";
            this.lblEventCnt.Size = new System.Drawing.Size(0, 18);
            this.lblEventCnt.TabIndex = 15;
            this.lblEventCnt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 444);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblEventCnt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.lblServInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.lsbServListConfig);
            this.Controls.Add(this.cbbServListConfig);
            this.Name = "Manager";
            this.Text = "Service Manager";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void InitializeEvent()
        {
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);

            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);

            this.cbbServListConfig.SelectedIndexChanged += new System.EventHandler(this.cbbServListConfig_SelectedIndexChanged);
            this.lsbServListConfig.SelectedIndexChanged += new System.EventHandler(this.lsbServListConfig_SelectedIndexChanged);

            this.softwareInfoToolStripMenuItem.Click += new System.EventHandler(this.softwareInfoToolStripMenuItem_Click);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Manager_FormClosing);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbServListConfig;
        private System.Windows.Forms.ListBox lsbServListConfig;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslManagerInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServInfo;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem softwareInfoToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEventCnt;
    }
}

