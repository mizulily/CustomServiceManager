namespace CustomServiceManager
{
    partial class Event
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslEventInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.rdbTrigger = new System.Windows.Forms.RadioButton();
            this.rdbPeriodic = new System.Windows.Forms.RadioButton();
            this.cbbTimeUnit = new System.Windows.Forms.ComboBox();
            this.nupInterval = new System.Windows.Forms.NumericUpDown();
            this.dgvEventView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTriggerState = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbTriggerService = new System.Windows.Forms.ComboBox();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbbGroup = new System.Windows.Forms.ComboBox();
            this.cbbProcess = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTargetService = new System.Windows.Forms.ComboBox();
            this.dgvIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEnableCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvModeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcessCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTarServCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInfoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslEventInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 29);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslEventInfo
            // 
            this.sslEventInfo.Name = "sslEventInfo";
            this.sslEventInfo.Size = new System.Drawing.Size(195, 24);
            this.sslEventInfo.Text = "toolStripStatusLabel1";
            // 
            // rdbTrigger
            // 
            this.rdbTrigger.AutoSize = true;
            this.rdbTrigger.Location = new System.Drawing.Point(3, 42);
            this.rdbTrigger.Name = "rdbTrigger";
            this.rdbTrigger.Size = new System.Drawing.Size(96, 22);
            this.rdbTrigger.TabIndex = 1;
            this.rdbTrigger.TabStop = true;
            this.rdbTrigger.Text = "Trigger";
            this.rdbTrigger.UseVisualStyleBackColor = true;
            // 
            // rdbPeriodic
            // 
            this.rdbPeriodic.AutoSize = true;
            this.rdbPeriodic.Checked = true;
            this.rdbPeriodic.Location = new System.Drawing.Point(3, 3);
            this.rdbPeriodic.Name = "rdbPeriodic";
            this.rdbPeriodic.Size = new System.Drawing.Size(105, 22);
            this.rdbPeriodic.TabIndex = 0;
            this.rdbPeriodic.TabStop = true;
            this.rdbPeriodic.Text = "Periodic";
            this.rdbPeriodic.UseVisualStyleBackColor = true;
            // 
            // cbbTimeUnit
            // 
            this.cbbTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTimeUnit.FormattingEnabled = true;
            this.cbbTimeUnit.Location = new System.Drawing.Point(333, 3);
            this.cbbTimeUnit.Name = "cbbTimeUnit";
            this.cbbTimeUnit.Size = new System.Drawing.Size(111, 26);
            this.cbbTimeUnit.TabIndex = 3;
            // 
            // nupInterval
            // 
            this.nupInterval.Location = new System.Drawing.Point(233, 3);
            this.nupInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupInterval.Name = "nupInterval";
            this.nupInterval.Size = new System.Drawing.Size(90, 28);
            this.nupInterval.TabIndex = 4;
            this.nupInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvEventView
            // 
            this.dgvEventView.AllowUserToAddRows = false;
            this.dgvEventView.AllowUserToDeleteRows = false;
            this.dgvEventView.AllowUserToOrderColumns = true;
            this.dgvEventView.AllowUserToResizeRows = false;
            this.dgvEventView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEventView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvEventView.ColumnHeadersHeight = 25;
            this.dgvEventView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEventView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIDCol,
            this.dgvEnableCol,
            this.dgvModeCol,
            this.dgvProcessCol,
            this.dgvTarServCol,
            this.dgvInfoCol});
            this.dgvEventView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvEventView.Location = new System.Drawing.Point(14, 162);
            this.dgvEventView.Name = "dgvEventView";
            this.dgvEventView.RowHeadersWidth = 25;
            this.dgvEventView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEventView.RowTemplate.Height = 30;
            this.dgvEventView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEventView.Size = new System.Drawing.Size(750, 288);
            this.dgvEventView.TabIndex = 2;
            this.dgvEventView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventView_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Service Event";
            // 
            // cbbTriggerState
            // 
            this.cbbTriggerState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTriggerState.Enabled = false;
            this.cbbTriggerState.FormattingEnabled = true;
            this.cbbTriggerState.Location = new System.Drawing.Point(333, 42);
            this.cbbTriggerState.Name = "cbbTriggerState";
            this.cbbTriggerState.Size = new System.Drawing.Size(111, 26);
            this.cbbTriggerState.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.rdbPeriodic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbTrigger, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbTriggerState, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbTimeUnit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nupInterval, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbTriggerService, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(300, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 78);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cbbTriggerService
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbbTriggerService, 2);
            this.cbbTriggerService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTriggerService.Enabled = false;
            this.cbbTriggerService.FormattingEnabled = true;
            this.cbbTriggerService.Location = new System.Drawing.Point(123, 42);
            this.cbbTriggerService.Name = "cbbTriggerService";
            this.cbbTriggerService.Size = new System.Drawing.Size(200, 26);
            this.cbbTriggerService.TabIndex = 5;
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(506, 465);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(100, 33);
            this.btnDiscard.TabIndex = 19;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(381, 465);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 33);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(621, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 33);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(32, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 50);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(157, 90);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 50);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cbbGroup
            // 
            this.cbbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGroup.FormattingEnabled = true;
            this.cbbGroup.Location = new System.Drawing.Point(117, 50);
            this.cbbGroup.Name = "cbbGroup";
            this.cbbGroup.Size = new System.Drawing.Size(148, 26);
            this.cbbGroup.TabIndex = 22;
            // 
            // cbbProcess
            // 
            this.cbbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProcess.FormattingEnabled = true;
            this.cbbProcess.Location = new System.Drawing.Point(633, 23);
            this.cbbProcess.Name = "cbbProcess";
            this.cbbProcess.Size = new System.Drawing.Size(108, 26);
            this.cbbProcess.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Setting";
            // 
            // cbbTargetService
            // 
            this.cbbTargetService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTargetService.FormattingEnabled = true;
            this.cbbTargetService.Location = new System.Drawing.Point(381, 23);
            this.cbbTargetService.Name = "cbbTargetService";
            this.cbbTargetService.Size = new System.Drawing.Size(243, 26);
            this.cbbTargetService.TabIndex = 26;
            // 
            // dgvIDCol
            // 
            this.dgvIDCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvIDCol.DividerWidth = 3;
            this.dgvIDCol.Frozen = true;
            this.dgvIDCol.HeaderText = "ID";
            this.dgvIDCol.Name = "dgvIDCol";
            this.dgvIDCol.ReadOnly = true;
            this.dgvIDCol.Width = 30;
            // 
            // dgvEnableCol
            // 
            this.dgvEnableCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvEnableCol.HeaderText = "Enable";
            this.dgvEnableCol.MinimumWidth = 30;
            this.dgvEnableCol.Name = "dgvEnableCol";
            this.dgvEnableCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnableCol.Width = 68;
            // 
            // dgvModeCol
            // 
            this.dgvModeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvModeCol.HeaderText = "Mode";
            this.dgvModeCol.MinimumWidth = 40;
            this.dgvModeCol.Name = "dgvModeCol";
            this.dgvModeCol.ReadOnly = true;
            this.dgvModeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModeCol.Width = 80;
            // 
            // dgvProcessCol
            // 
            this.dgvProcessCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvProcessCol.HeaderText = "Process";
            this.dgvProcessCol.MinimumWidth = 40;
            this.dgvProcessCol.Name = "dgvProcessCol";
            this.dgvProcessCol.ReadOnly = true;
            this.dgvProcessCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProcessCol.Width = 107;
            // 
            // dgvTarServCol
            // 
            this.dgvTarServCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvTarServCol.HeaderText = "Service";
            this.dgvTarServCol.MinimumWidth = 120;
            this.dgvTarServCol.Name = "dgvTarServCol";
            this.dgvTarServCol.ReadOnly = true;
            this.dgvTarServCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTarServCol.Width = 120;
            // 
            // dgvInfoCol
            // 
            this.dgvInfoCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvInfoCol.HeaderText = "Infomation";
            this.dgvInfoCol.MinimumWidth = 150;
            this.dgvInfoCol.Name = "dgvInfoCol";
            this.dgvInfoCol.ReadOnly = true;
            this.dgvInfoCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfoCol.Width = 150;
            // 
            // Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.cbbTargetService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbProcess);
            this.Controls.Add(this.cbbGroup);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEventView);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Event";
            this.Text = "Service Event Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeEvent()
        {
            this.cbbGroup.SelectedIndexChanged += new System.EventHandler(this.cbbGroup_SelectedIndexChanged);
            this.rdbTrigger.CheckedChanged += new System.EventHandler(this.rdbTrigger_CheckedChanged);
            this.rdbPeriodic.CheckedChanged += new System.EventHandler(this.rdbPeriodic_CheckedChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslEventInfo;
        private System.Windows.Forms.RadioButton rdbPeriodic;
        private System.Windows.Forms.RadioButton rdbTrigger;
        private System.Windows.Forms.ComboBox cbbTimeUnit;
        private System.Windows.Forms.NumericUpDown nupInterval;
        private System.Windows.Forms.DataGridView dgvEventView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTriggerState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbbGroup;
        private System.Windows.Forms.ComboBox cbbProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbTargetService;
        private System.Windows.Forms.ComboBox cbbTriggerService;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIDCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvEnableCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvModeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProcessCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTarServCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInfoCol;
    }
}