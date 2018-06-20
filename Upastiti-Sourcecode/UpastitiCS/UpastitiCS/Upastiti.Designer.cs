namespace UpastitiCS
{
    partial class Upastiti
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Upastiti));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMaster = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.cbShiftCode = new System.Windows.Forms.ComboBox();
            this.lblShiftCode = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.lblStaffNo = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.colStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShiftCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblShiftSelected = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNPunchMissingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oUTPunchMissingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPlant = new System.Windows.Forms.Label();
            this.lbl1stShiftCount = new System.Windows.Forms.Label();
            this.lbl2ndShiftCount = new System.Windows.Forms.Label();
            this.lbl3rdShiftCount = new System.Windows.Forms.Label();
            this.lblGSCount = new System.Windows.Forms.Label();
            this.minTimer = new System.Windows.Forms.Timer(this.components);
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Font = new System.Drawing.Font("Tempus Sans ITC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(913, 42);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "Upastiti - A Biometric-based Attendance Management System";
            // 
            // btnMaster
            // 
            this.btnMaster.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaster.ForeColor = System.Drawing.Color.White;
            this.btnMaster.Image = global::UpastitiCS.Properties.Resources.records;
            this.btnMaster.Location = new System.Drawing.Point(409, 4);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(168, 63);
            this.btnMaster.TabIndex = 3;
            this.btnMaster.Text = "Staff Enrollment";
            this.btnMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaster.UseVisualStyleBackColor = false;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.cbShiftCode);
            this.panelButtons.Controls.Add(this.lblShiftCode);
            this.panelButtons.Controls.Add(this.btnStop);
            this.panelButtons.Controls.Add(this.btnStart);
            this.panelButtons.Controls.Add(this.btnConfiguration);
            this.panelButtons.Controls.Add(this.btnHistory);
            this.panelButtons.Controls.Add(this.btnMaster);
            this.panelButtons.Location = new System.Drawing.Point(7, 72);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(925, 68);
            this.panelButtons.TabIndex = 20;
            // 
            // cbShiftCode
            // 
            this.cbShiftCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShiftCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShiftCode.FormattingEnabled = true;
            this.cbShiftCode.Items.AddRange(new object[] {
            "1stShift-IN",
            "1stShift-OUT",
            "2ndShift-IN",
            "2ndShift-OUT",
            "3rdShift-IN",
            "3rdShift-OUT",
            "GS-IN",
            "GS-OUT"});
            this.cbShiftCode.Location = new System.Drawing.Point(7, 37);
            this.cbShiftCode.Name = "cbShiftCode";
            this.cbShiftCode.Size = new System.Drawing.Size(121, 24);
            this.cbShiftCode.TabIndex = 0;
            this.cbShiftCode.SelectedIndexChanged += new System.EventHandler(this.cbShiftCode_SelectedIndexChanged);
            // 
            // lblShiftCode
            // 
            this.lblShiftCode.AutoSize = true;
            this.lblShiftCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftCode.ForeColor = System.Drawing.Color.White;
            this.lblShiftCode.Location = new System.Drawing.Point(12, 10);
            this.lblShiftCode.Name = "lblShiftCode";
            this.lblShiftCode.Size = new System.Drawing.Size(107, 24);
            this.lblShiftCode.TabIndex = 24;
            this.lblShiftCode.Text = "Shift-Code";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Image = global::UpastitiCS.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(273, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 63);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.EnabledChanged += new System.EventHandler(this.btnStop_EnabledChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Image = global::UpastitiCS.Properties.Resources.start;
            this.btnStart.Location = new System.Drawing.Point(132, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 63);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.EnabledChanged += new System.EventHandler(this.btnStart_EnabledChanged);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguration.ForeColor = System.Drawing.Color.White;
            this.btnConfiguration.Image = global::UpastitiCS.Properties.Resources.conf;
            this.btnConfiguration.Location = new System.Drawing.Point(747, 4);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(172, 63);
            this.btnConfiguration.TabIndex = 5;
            this.btnConfiguration.Text = "Settings";
            this.btnConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguration.UseVisualStyleBackColor = false;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Image = global::UpastitiCS.Properties.Resources.history;
            this.btnHistory.Location = new System.Drawing.Point(583, 4);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(158, 63);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.Text = "History";
            this.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // lblStaffNo
            // 
            this.lblStaffNo.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffNo.ForeColor = System.Drawing.Color.White;
            this.lblStaffNo.Location = new System.Drawing.Point(713, 527);
            this.lblStaffNo.Name = "lblStaffNo";
            this.lblStaffNo.Size = new System.Drawing.Size(225, 24);
            this.lblStaffNo.TabIndex = 24;
            this.lblStaffNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.ForeColor = System.Drawing.Color.White;
            this.lblStaffName.Location = new System.Drawing.Point(715, 486);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(220, 35);
            this.lblStaffName.TabIndex = 25;
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbFinger
            // 
            this.pbFinger.BackColor = System.Drawing.Color.Transparent;
            this.pbFinger.Location = new System.Drawing.Point(750, 261);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(156, 213);
            this.pbFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger.TabIndex = 46;
            this.pbFinger.TabStop = false;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStaffNo,
            this.colStaffName,
            this.colGender,
            this.colPlant,
            this.colTime,
            this.colShiftCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendance.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendance.Location = new System.Drawing.Point(7, 146);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendance.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(700, 471);
            this.dgvAttendance.TabIndex = 47;
            this.dgvAttendance.TabStop = false;
            // 
            // colStaffNo
            // 
            this.colStaffNo.HeaderText = "Staff No";
            this.colStaffNo.Name = "colStaffNo";
            this.colStaffNo.ReadOnly = true;
            this.colStaffNo.Width = 80;
            // 
            // colStaffName
            // 
            this.colStaffName.HeaderText = "Name";
            this.colStaffName.Name = "colStaffName";
            this.colStaffName.ReadOnly = true;
            this.colStaffName.Width = 150;
            // 
            // colGender
            // 
            this.colGender.HeaderText = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            this.colGender.Width = 50;
            // 
            // colPlant
            // 
            this.colPlant.HeaderText = "Plant";
            this.colPlant.Name = "colPlant";
            this.colPlant.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 150;
            // 
            // colShiftCode
            // 
            this.colShiftCode.HeaderText = "Shift Code";
            this.colShiftCode.Name = "colShiftCode";
            this.colShiftCode.ReadOnly = true;
            // 
            // lblShiftSelected
            // 
            this.lblShiftSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblShiftSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftSelected.ForeColor = System.Drawing.Color.White;
            this.lblShiftSelected.Location = new System.Drawing.Point(718, 206);
            this.lblShiftSelected.Name = "lblShiftSelected";
            this.lblShiftSelected.Size = new System.Drawing.Size(220, 35);
            this.lblShiftSelected.TabIndex = 48;
            this.lblShiftSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.exit;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffEnrollmentToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.iNPunchMissingToolStripMenuItem,
            this.oUTPunchMissingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // staffEnrollmentToolStripMenuItem
            // 
            this.staffEnrollmentToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.records;
            this.staffEnrollmentToolStripMenuItem.Name = "staffEnrollmentToolStripMenuItem";
            this.staffEnrollmentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.staffEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffEnrollmentToolStripMenuItem.Text = "Staff &Enrollment";
            this.staffEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.staffEnrollmentToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.conf;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.settingsToolStripMenuItem.Text = "Sett&ings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // iNPunchMissingToolStripMenuItem
            // 
            this.iNPunchMissingToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.MissIN;
            this.iNPunchMissingToolStripMenuItem.Name = "iNPunchMissingToolStripMenuItem";
            this.iNPunchMissingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.iNPunchMissingToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.iNPunchMissingToolStripMenuItem.Text = "IN-Punch Missing";
            this.iNPunchMissingToolStripMenuItem.Click += new System.EventHandler(this.iNPunchMissingToolStripMenuItem_Click);
            // 
            // oUTPunchMissingToolStripMenuItem
            // 
            this.oUTPunchMissingToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.MissOUT;
            this.oUTPunchMissingToolStripMenuItem.Name = "oUTPunchMissingToolStripMenuItem";
            this.oUTPunchMissingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.oUTPunchMissingToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.oUTPunchMissingToolStripMenuItem.Text = "OUT-Punch Missing";
            this.oUTPunchMissingToolStripMenuItem.Click += new System.EventHandler(this.oUTPunchMissingToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.start;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.startToolStripMenuItem.Text = "&Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.stopToolStripMenuItem.Text = "Sto&p";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.history;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.historyToolStripMenuItem.Text = "&History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.userManualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.observer;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Image = global::UpastitiCS.Properties.Resources.um;
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.userManualToolStripMenuItem.Text = "&User Manual";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // lblPlant
            // 
            this.lblPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlant.ForeColor = System.Drawing.Color.White;
            this.lblPlant.Location = new System.Drawing.Point(10, 622);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(223, 33);
            this.lblPlant.TabIndex = 50;
            this.lblPlant.Text = "Plant:";
            this.lblPlant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1stShiftCount
            // 
            this.lbl1stShiftCount.BackColor = System.Drawing.Color.Transparent;
            this.lbl1stShiftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1stShiftCount.ForeColor = System.Drawing.Color.White;
            this.lbl1stShiftCount.Location = new System.Drawing.Point(259, 622);
            this.lbl1stShiftCount.Name = "lbl1stShiftCount";
            this.lbl1stShiftCount.Size = new System.Drawing.Size(163, 33);
            this.lbl1stShiftCount.TabIndex = 51;
            this.lbl1stShiftCount.Text = "1stShift: 0";
            this.lbl1stShiftCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2ndShiftCount
            // 
            this.lbl2ndShiftCount.BackColor = System.Drawing.Color.Transparent;
            this.lbl2ndShiftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2ndShiftCount.ForeColor = System.Drawing.Color.White;
            this.lbl2ndShiftCount.Location = new System.Drawing.Point(442, 622);
            this.lbl2ndShiftCount.Name = "lbl2ndShiftCount";
            this.lbl2ndShiftCount.Size = new System.Drawing.Size(154, 33);
            this.lbl2ndShiftCount.TabIndex = 52;
            this.lbl2ndShiftCount.Text = "2ndShift: 0";
            this.lbl2ndShiftCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3rdShiftCount
            // 
            this.lbl3rdShiftCount.BackColor = System.Drawing.Color.Transparent;
            this.lbl3rdShiftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3rdShiftCount.ForeColor = System.Drawing.Color.White;
            this.lbl3rdShiftCount.Location = new System.Drawing.Point(609, 622);
            this.lbl3rdShiftCount.Name = "lbl3rdShiftCount";
            this.lbl3rdShiftCount.Size = new System.Drawing.Size(154, 33);
            this.lbl3rdShiftCount.TabIndex = 53;
            this.lbl3rdShiftCount.Text = "3rdShift: 0";
            this.lbl3rdShiftCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGSCount
            // 
            this.lblGSCount.BackColor = System.Drawing.Color.Transparent;
            this.lblGSCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSCount.ForeColor = System.Drawing.Color.White;
            this.lblGSCount.Location = new System.Drawing.Point(773, 620);
            this.lblGSCount.Name = "lblGSCount";
            this.lblGSCount.Size = new System.Drawing.Size(154, 33);
            this.lblGSCount.TabIndex = 54;
            this.lblGSCount.Text = "GS: 0";
            this.lblGSCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minTimer
            // 
            this.minTimer.Interval = 60000;
            this.minTimer.Tick += new System.EventHandler(this.minTimer_Tick);
            // 
            // Upastiti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpastitiCS.Properties.Resources.gray3;
            this.ClientSize = new System.Drawing.Size(944, 662);
            this.Controls.Add(this.lblGSCount);
            this.Controls.Add(this.lbl3rdShiftCount);
            this.Controls.Add(this.lbl2ndShiftCount);
            this.Controls.Add(this.lbl1stShiftCount);
            this.Controls.Add(this.lblPlant);
            this.Controls.Add(this.lblShiftSelected);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.pbFinger);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.lblStaffNo);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Upastiti";
            this.Text = "Upastiti - A Biometric-based Attendance Management System (v2.1.2 Stable)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Upastiti_FormClosing);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblStaffNo;
        private System.Windows.Forms.PictureBox pbFinger;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Label lblShiftCode;
        private System.Windows.Forms.ComboBox cbShiftCode;
        private System.Windows.Forms.Label lblShiftSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNPunchMissingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oUTPunchMissingToolStripMenuItem;
        private System.Windows.Forms.Label lbl1stShiftCount;
        private System.Windows.Forms.Label lbl2ndShiftCount;
        private System.Windows.Forms.Label lbl3rdShiftCount;
        private System.Windows.Forms.Label lblGSCount;
        private System.Windows.Forms.Timer minTimer;
    }
}

