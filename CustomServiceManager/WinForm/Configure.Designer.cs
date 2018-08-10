namespace CustomServiceManager
{
    partial class Configure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsbServList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbRunning = new System.Windows.Forms.CheckBox();
            this.ckbPaused = new System.Windows.Forms.CheckBox();
            this.ckbStopped = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslSettingInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbServGroup = new System.Windows.Forms.ComboBox();
            this.lsbGroupList = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbServName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnAddCustom = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdbServName = new System.Windows.Forms.RadioButton();
            this.rdbDispName = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbServList
            // 
            this.lsbServList.FormattingEnabled = true;
            this.lsbServList.ItemHeight = 18;
            this.lsbServList.Location = new System.Drawing.Point(32, 50);
            this.lsbServList.Name = "lsbServList";
            this.lsbServList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbServList.Size = new System.Drawing.Size(360, 400);
            this.lsbServList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service Installed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(406, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Filter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ckbRunning, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckbPaused, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckbStopped, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(406, 122);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(121, 98);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ckbRunning
            // 
            this.ckbRunning.AutoSize = true;
            this.ckbRunning.Checked = true;
            this.ckbRunning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbRunning.Location = new System.Drawing.Point(3, 67);
            this.ckbRunning.Name = "ckbRunning";
            this.ckbRunning.Size = new System.Drawing.Size(97, 22);
            this.ckbRunning.TabIndex = 4;
            this.ckbRunning.Text = "Running";
            this.ckbRunning.UseVisualStyleBackColor = true;
            // 
            // ckbPaused
            // 
            this.ckbPaused.AutoSize = true;
            this.ckbPaused.Checked = true;
            this.ckbPaused.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPaused.Location = new System.Drawing.Point(3, 35);
            this.ckbPaused.Name = "ckbPaused";
            this.ckbPaused.Size = new System.Drawing.Size(88, 22);
            this.ckbPaused.TabIndex = 3;
            this.ckbPaused.Text = "Paused";
            this.ckbPaused.UseVisualStyleBackColor = true;
            // 
            // ckbStopped
            // 
            this.ckbStopped.AutoSize = true;
            this.ckbStopped.Checked = true;
            this.ckbStopped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStopped.Location = new System.Drawing.Point(3, 3);
            this.ckbStopped.Name = "ckbStopped";
            this.ckbStopped.Size = new System.Drawing.Size(97, 22);
            this.ckbStopped.TabIndex = 2;
            this.ckbStopped.Text = "Stopped";
            this.ckbStopped.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslSettingInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 29);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslSettingInfo
            // 
            this.sslSettingInfo.Name = "sslSettingInfo";
            this.sslSettingInfo.Size = new System.Drawing.Size(195, 24);
            this.sslSettingInfo.Text = "toolStripStatusLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(582, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Service Group";
            // 
            // cbbServGroup
            // 
            this.cbbServGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbServGroup.FormattingEnabled = true;
            this.cbbServGroup.Location = new System.Drawing.Point(767, 18);
            this.cbbServGroup.Name = "cbbServGroup";
            this.cbbServGroup.Size = new System.Drawing.Size(148, 26);
            this.cbbServGroup.TabIndex = 7;
            // 
            // lsbGroupList
            // 
            this.lsbGroupList.FormattingEnabled = true;
            this.lsbGroupList.HorizontalScrollbar = true;
            this.lsbGroupList.ItemHeight = 18;
            this.lsbGroupList.Location = new System.Drawing.Point(585, 52);
            this.lsbGroupList.Name = "lsbGroupList";
            this.lsbGroupList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbGroupList.Size = new System.Drawing.Size(358, 400);
            this.lsbGroupList.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(409, 231);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 33);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(433, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 50);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(433, 380);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 50);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove <<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(843, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txbServName
            // 
            this.txbServName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txbServName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txbServName.Location = new System.Drawing.Point(166, 462);
            this.txbServName.Name = "txbServName";
            this.txbServName.Size = new System.Drawing.Size(226, 28);
            this.txbServName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Service Name";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(596, 464);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 33);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(730, 462);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(100, 33);
            this.btnDiscard.TabIndex = 16;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            // 
            // btnAddCustom
            // 
            this.btnAddCustom.Location = new System.Drawing.Point(417, 458);
            this.btnAddCustom.Name = "btnAddCustom";
            this.btnAddCustom.Size = new System.Drawing.Size(141, 33);
            this.btnAddCustom.TabIndex = 17;
            this.btnAddCustom.Text = "Add by Name";
            this.btnAddCustom.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.rdbServName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdbDispName, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(406, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(148, 64);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // rdbServName
            // 
            this.rdbServName.AutoSize = true;
            this.rdbServName.Checked = true;
            this.rdbServName.Location = new System.Drawing.Point(3, 3);
            this.rdbServName.Name = "rdbServName";
            this.rdbServName.Size = new System.Drawing.Size(141, 22);
            this.rdbServName.TabIndex = 0;
            this.rdbServName.TabStop = true;
            this.rdbServName.Text = "Service Name";
            this.rdbServName.UseVisualStyleBackColor = true;
            // 
            // rdbDispName
            // 
            this.rdbDispName.AutoSize = true;
            this.rdbDispName.Location = new System.Drawing.Point(3, 35);
            this.rdbDispName.Name = "rdbDispName";
            this.rdbDispName.Size = new System.Drawing.Size(141, 22);
            this.rdbDispName.TabIndex = 1;
            this.rdbDispName.TabStop = true;
            this.rdbDispName.Text = "Display Name";
            this.rdbDispName.UseVisualStyleBackColor = true;
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnAddCustom);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbServName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lsbGroupList);
            this.Controls.Add(this.cbbServGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbServList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configure";
            this.Text = "Service Group Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configure_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void InitializeEvent()
        {
            this.cbbServGroup.SelectedIndexChanged += new System.EventHandler(this.cbbServGroup_SelectedIndexChanged);
            this.cbbServGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbServGroup_KeyDown);

            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnAddCustom.Click += new System.EventHandler(this.btnAddCustom_Click);



        }
        #endregion

        private System.Windows.Forms.ListBox lsbServList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ckbRunning;
        private System.Windows.Forms.CheckBox ckbPaused;
        private System.Windows.Forms.CheckBox ckbStopped;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslSettingInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbServGroup;
        private System.Windows.Forms.ListBox lsbGroupList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbServName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnAddCustom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdbServName;
        private System.Windows.Forms.RadioButton rdbDispName;
    }
}