namespace UpastitiCS
{
    partial class MasterRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterRecord));
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.lblPlant = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.gbStaffDetails = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbSamiti = new System.Windows.Forms.ComboBox();
            this.lblSamiti = new System.Windows.Forms.Label();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.lblSkill = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.gbFT = new System.Windows.Forms.GroupBox();
            this.pbFinger2 = new System.Windows.Forms.PictureBox();
            this.pbFinger1 = new System.Windows.Forms.PictureBox();
            this.lblFT2 = new System.Windows.Forms.Label();
            this.lblFT1 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbStaffNumber = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStaffNumber = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnUpdateFT = new System.Windows.Forms.Button();
            this.colSlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBoxAsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FathersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractorsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMCUNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSamiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.gbStaffDetails.SuspendLayout();
            this.gbFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger1)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPlant
            // 
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(117, 51);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(211, 23);
            this.cbPlant.TabIndex = 3;
            // 
            // lblPlant
            // 
            this.lblPlant.AutoSize = true;
            this.lblPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlant.ForeColor = System.Drawing.Color.White;
            this.lblPlant.Location = new System.Drawing.Point(64, 52);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(51, 18);
            this.lblPlant.TabIndex = 30;
            this.lblPlant.Tag = "";
            this.lblPlant.Text = "Plant:";
            this.lblPlant.UseMnemonic = false;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlNo,
            this.dgcUnit,
            this.dgcBoxAsm,
            this.FathersName,
            this.colGender,
            this.ContractorsName,
            this.dgcMCUNo,
            this.colSkill,
            this.colSamiti});
            this.dgvAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvAttendance.Location = new System.Drawing.Point(12, 334);
            this.dgvAttendance.MultiSelect = false;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvAttendance.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(766, 326);
            this.dgvAttendance.TabIndex = 2;
            this.dgvAttendance.SelectionChanged += new System.EventHandler(this.dgvAttendance_SelectionChanged);
            // 
            // gbStaffDetails
            // 
            this.gbStaffDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbStaffDetails.Controls.Add(this.comboBox1);
            this.gbStaffDetails.Controls.Add(this.label2);
            this.gbStaffDetails.Controls.Add(this.label1);
            this.gbStaffDetails.Controls.Add(this.textBox1);
            this.gbStaffDetails.Controls.Add(this.cbSamiti);
            this.gbStaffDetails.Controls.Add(this.lblSamiti);
            this.gbStaffDetails.Controls.Add(this.cbSkill);
            this.gbStaffDetails.Controls.Add(this.lblSkill);
            this.gbStaffDetails.Controls.Add(this.cbGender);
            this.gbStaffDetails.Controls.Add(this.lblGender);
            this.gbStaffDetails.Controls.Add(this.gbFT);
            this.gbStaffDetails.Controls.Add(this.tbName);
            this.gbStaffDetails.Controls.Add(this.lblName);
            this.gbStaffDetails.Controls.Add(this.btnCancel);
            this.gbStaffDetails.Controls.Add(this.tbStaffNumber);
            this.gbStaffDetails.Controls.Add(this.btnSave);
            this.gbStaffDetails.Controls.Add(this.lblStaffNumber);
            this.gbStaffDetails.Controls.Add(this.cbPlant);
            this.gbStaffDetails.Controls.Add(this.lblPlant);
            this.gbStaffDetails.Enabled = false;
            this.gbStaffDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStaffDetails.ForeColor = System.Drawing.Color.White;
            this.gbStaffDetails.Location = new System.Drawing.Point(12, 64);
            this.gbStaffDetails.Name = "gbStaffDetails";
            this.gbStaffDetails.Size = new System.Drawing.Size(766, 264);
            this.gbStaffDetails.TabIndex = 1;
            this.gbStaffDetails.TabStop = false;
            this.gbStaffDetails.Text = "Staff Details";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GRETS",
            "SUNRISE",
            "CLASS"});
            this.comboBox1.Location = new System.Drawing.Point(152, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 23);
            this.comboBox1.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Contractor\'s Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(334, 54);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Father\'s Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(479, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 22);
            this.textBox1.TabIndex = 43;
            // 
            // cbSamiti
            // 
            this.cbSamiti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSamiti.FormattingEnabled = true;
            this.cbSamiti.Location = new System.Drawing.Point(117, 113);
            this.cbSamiti.Name = "cbSamiti";
            this.cbSamiti.Size = new System.Drawing.Size(211, 23);
            this.cbSamiti.TabIndex = 5;
            // 
            // lblSamiti
            // 
            this.lblSamiti.AutoSize = true;
            this.lblSamiti.BackColor = System.Drawing.Color.Transparent;
            this.lblSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamiti.ForeColor = System.Drawing.Color.White;
            this.lblSamiti.Location = new System.Drawing.Point(7, 114);
            this.lblSamiti.Name = "lblSamiti";
            this.lblSamiti.Size = new System.Drawing.Size(109, 18);
            this.lblSamiti.TabIndex = 42;
            this.lblSamiti.Tag = "";
            this.lblSamiti.Text = "Samiti Name:";
            this.lblSamiti.UseMnemonic = false;
            // 
            // cbSkill
            // 
            this.cbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSkill.FormattingEnabled = true;
            this.cbSkill.Items.AddRange(new object[] {
            "UNSKILLED",
            "SKILLED",
            "HIGHLY-SKILLED"});
            this.cbSkill.Location = new System.Drawing.Point(117, 84);
            this.cbSkill.Name = "cbSkill";
            this.cbSkill.Size = new System.Drawing.Size(211, 23);
            this.cbSkill.TabIndex = 4;
            // 
            // lblSkill
            // 
            this.lblSkill.AutoSize = true;
            this.lblSkill.BackColor = System.Drawing.Color.Transparent;
            this.lblSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkill.ForeColor = System.Drawing.Color.White;
            this.lblSkill.Location = new System.Drawing.Point(70, 86);
            this.lblSkill.Name = "lblSkill";
            this.lblSkill.Size = new System.Drawing.Size(50, 18);
            this.lblSkill.TabIndex = 40;
            this.lblSkill.Tag = "";
            this.lblSkill.Text = "Skill: ";
            this.lblSkill.UseMnemonic = false;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "FEMALE",
            "MALE"});
            this.cbGender.Location = new System.Drawing.Point(641, 22);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(111, 23);
            this.cbGender.TabIndex = 2;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(576, 24);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 16);
            this.lblGender.TabIndex = 37;
            this.lblGender.Text = "Gender:";
            // 
            // gbFT
            // 
            this.gbFT.Controls.Add(this.pbFinger2);
            this.gbFT.Controls.Add(this.pbFinger1);
            this.gbFT.Controls.Add(this.lblFT2);
            this.gbFT.Controls.Add(this.lblFT1);
            this.gbFT.Controls.Add(this.btnCapture);
            this.gbFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFT.ForeColor = System.Drawing.Color.White;
            this.gbFT.Location = new System.Drawing.Point(354, 113);
            this.gbFT.Name = "gbFT";
            this.gbFT.Size = new System.Drawing.Size(412, 135);
            this.gbFT.TabIndex = 7;
            this.gbFT.TabStop = false;
            this.gbFT.Text = "Fingerprint Templates";
            // 
            // pbFinger2
            // 
            this.pbFinger2.Location = new System.Drawing.Point(269, 20);
            this.pbFinger2.Name = "pbFinger2";
            this.pbFinger2.Size = new System.Drawing.Size(100, 86);
            this.pbFinger2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger2.TabIndex = 46;
            this.pbFinger2.TabStop = false;
            // 
            // pbFinger1
            // 
            this.pbFinger1.Location = new System.Drawing.Point(155, 20);
            this.pbFinger1.Name = "pbFinger1";
            this.pbFinger1.Size = new System.Drawing.Size(100, 86);
            this.pbFinger1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger1.TabIndex = 45;
            this.pbFinger1.TabStop = false;
            // 
            // lblFT2
            // 
            this.lblFT2.AutoSize = true;
            this.lblFT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFT2.ForeColor = System.Drawing.Color.White;
            this.lblFT2.Location = new System.Drawing.Point(289, 111);
            this.lblFT2.Name = "lblFT2";
            this.lblFT2.Size = new System.Drawing.Size(64, 16);
            this.lblFT2.TabIndex = 44;
            this.lblFT2.Text = "Finger 2";
            // 
            // lblFT1
            // 
            this.lblFT1.AutoSize = true;
            this.lblFT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFT1.ForeColor = System.Drawing.Color.White;
            this.lblFT1.Location = new System.Drawing.Point(178, 111);
            this.lblFT1.Name = "lblFT1";
            this.lblFT1.Size = new System.Drawing.Size(64, 16);
            this.lblFT1.TabIndex = 37;
            this.lblFT1.Text = "Finger 1";
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.ForeColor = System.Drawing.Color.White;
            this.btnCapture.Location = new System.Drawing.Point(22, 43);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(116, 39);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "&Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(392, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(177, 22);
            this.tbName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(333, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 16);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::UpastitiCS.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(211, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 42);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbStaffNumber
            // 
            this.tbStaffNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStaffNumber.Location = new System.Drawing.Point(117, 19);
            this.tbStaffNumber.Name = "tbStaffNumber";
            this.tbStaffNumber.Size = new System.Drawing.Size(211, 22);
            this.tbStaffNumber.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::UpastitiCS.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(84, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 41);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStaffNumber
            // 
            this.lblStaffNumber.AutoSize = true;
            this.lblStaffNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffNumber.ForeColor = System.Drawing.Color.White;
            this.lblStaffNumber.Location = new System.Drawing.Point(14, 22);
            this.lblStaffNumber.Name = "lblStaffNumber";
            this.lblStaffNumber.Size = new System.Drawing.Size(101, 16);
            this.lblStaffNumber.TabIndex = 32;
            this.lblStaffNumber.Text = "Staff Number:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::UpastitiCS.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(348, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 54);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnModify.Enabled = false;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Image = global::UpastitiCS.Properties.Resources.modify;
            this.btnModify.Location = new System.Drawing.Point(178, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(150, 54);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "&Modify";
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(10, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 54);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.Transparent;
            this.panelActions.Controls.Add(this.btnUpdateFT);
            this.panelActions.Controls.Add(this.btnDelete);
            this.panelActions.Controls.Add(this.btnModify);
            this.panelActions.Controls.Add(this.btnAdd);
            this.panelActions.Location = new System.Drawing.Point(12, 5);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(766, 60);
            this.panelActions.TabIndex = 0;
            // 
            // btnUpdateFT
            // 
            this.btnUpdateFT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdateFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFT.ForeColor = System.Drawing.Color.White;
            this.btnUpdateFT.Image = global::UpastitiCS.Properties.Resources.modify;
            this.btnUpdateFT.Location = new System.Drawing.Point(513, 3);
            this.btnUpdateFT.Name = "btnUpdateFT";
            this.btnUpdateFT.Size = new System.Drawing.Size(248, 54);
            this.btnUpdateFT.TabIndex = 3;
            this.btnUpdateFT.Text = "&Update Fingerprint Templates";
            this.btnUpdateFT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateFT.UseVisualStyleBackColor = false;
            this.btnUpdateFT.Click += new System.EventHandler(this.btnUpdateFT_Click);
            // 
            // colSlNo
            // 
            this.colSlNo.HeaderText = "Sl.No";
            this.colSlNo.Name = "colSlNo";
            this.colSlNo.ReadOnly = true;
            this.colSlNo.Width = 50;
            // 
            // dgcUnit
            // 
            this.dgcUnit.HeaderText = "Staff Number";
            this.dgcUnit.Name = "dgcUnit";
            this.dgcUnit.ReadOnly = true;
            this.dgcUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgcBoxAsm
            // 
            this.dgcBoxAsm.HeaderText = "Name";
            this.dgcBoxAsm.MaxInputLength = 10;
            this.dgcBoxAsm.MinimumWidth = 150;
            this.dgcBoxAsm.Name = "dgcBoxAsm";
            this.dgcBoxAsm.ReadOnly = true;
            this.dgcBoxAsm.Width = 150;
            // 
            // FathersName
            // 
            this.FathersName.HeaderText = "Father\'s Name";
            this.FathersName.Name = "FathersName";
            this.FathersName.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.HeaderText = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            this.colGender.Width = 60;
            // 
            // ContractorsName
            // 
            this.ContractorsName.HeaderText = "Contractor\'s Name";
            this.ContractorsName.Name = "ContractorsName";
            this.ContractorsName.ReadOnly = true;
            // 
            // dgcMCUNo
            // 
            this.dgcMCUNo.HeaderText = "Plant";
            this.dgcMCUNo.Name = "dgcMCUNo";
            this.dgcMCUNo.ReadOnly = true;
            // 
            // colSkill
            // 
            this.colSkill.HeaderText = "Skill";
            this.colSkill.Name = "colSkill";
            this.colSkill.ReadOnly = true;
            // 
            // colSamiti
            // 
            this.colSamiti.HeaderText = "Samiti Name";
            this.colSamiti.Name = "colSamiti";
            this.colSamiti.ReadOnly = true;
            this.colSamiti.Width = 150;
            // 
            // MasterRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpastitiCS.Properties.Resources.gray3;
            this.ClientSize = new System.Drawing.Size(791, 662);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.gbStaffDetails);
            this.Controls.Add(this.dgvAttendance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterRecord";
            this.Text = "MasterRecord";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterRecord_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.gbStaffDetails.ResumeLayout(false);
            this.gbStaffDetails.PerformLayout();
            this.gbFT.ResumeLayout(false);
            this.gbFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger1)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.GroupBox gbStaffDetails;
        private System.Windows.Forms.TextBox tbStaffNumber;
        private System.Windows.Forms.Label lblStaffNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbFT;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblFT1;
        private System.Windows.Forms.Label lblFT2;
        private System.Windows.Forms.PictureBox pbFinger1;
        private System.Windows.Forms.PictureBox pbFinger2;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cbSamiti;
        private System.Windows.Forms.Label lblSamiti;
        private System.Windows.Forms.ComboBox cbSkill;
        private System.Windows.Forms.Label lblSkill;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnUpdateFT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBoxAsm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FathersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractorsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMCUNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSkill;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSamiti;
    }
}