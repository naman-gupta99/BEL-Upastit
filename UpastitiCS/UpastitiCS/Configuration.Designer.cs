namespace UpastitiCS
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.lblPlant = new System.Windows.Forms.Label();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.btnPlantAdd = new System.Windows.Forms.Button();
            this.btnPlantRemove = new System.Windows.Forms.Button();
            this.gbPlant = new System.Windows.Forms.GroupBox();
            this.tbPlantTitle = new System.Windows.Forms.TextBox();
            this.lblPlantTitle = new System.Windows.Forms.Label();
            this.gbSamiti = new System.Windows.Forms.GroupBox();
            this.tbSamitiTitle = new System.Windows.Forms.TextBox();
            this.lblSamitiTitle = new System.Windows.Forms.Label();
            this.btnSamitiAdd = new System.Windows.Forms.Button();
            this.btnSamitiRemove = new System.Windows.Forms.Button();
            this.cbSamiti = new System.Windows.Forms.ComboBox();
            this.lblSamiti = new System.Windows.Forms.Label();
            this.gbDBParams = new System.Windows.Forms.GroupBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbDBPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbResetPass = new System.Windows.Forms.GroupBox();
            this.tbMasterPass = new System.Windows.Forms.TextBox();
            this.lblMasterPass = new System.Windows.Forms.Label();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.gbDefaultPlant = new System.Windows.Forms.GroupBox();
            this.cbSelectPlant = new System.Windows.Forms.ComboBox();
            this.lblSelectPlant = new System.Windows.Forms.Label();
            this.btnUpdatePlant = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbContractorTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContractorAdd = new System.Windows.Forms.Button();
            this.btnContractorRemove = new System.Windows.Forms.Button();
            this.cbContractor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPlant.SuspendLayout();
            this.gbSamiti.SuspendLayout();
            this.gbDBParams.SuspendLayout();
            this.gbResetPass.SuspendLayout();
            this.gbDefaultPlant.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlant
            // 
            this.lblPlant.AutoSize = true;
            this.lblPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlant.ForeColor = System.Drawing.Color.White;
            this.lblPlant.Location = new System.Drawing.Point(42, 29);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(55, 20);
            this.lblPlant.TabIndex = 28;
            this.lblPlant.Tag = "";
            this.lblPlant.Text = "Plant:";
            this.lblPlant.UseMnemonic = false;
            // 
            // cbPlant
            // 
            this.cbPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(99, 28);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(252, 24);
            this.cbPlant.TabIndex = 0;
            this.cbPlant.SelectedIndexChanged += new System.EventHandler(this.cbPlant_SelectedIndexChanged);
            // 
            // btnPlantAdd
            // 
            this.btnPlantAdd.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlantAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlantAdd.ForeColor = System.Drawing.Color.White;
            this.btnPlantAdd.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnPlantAdd.Location = new System.Drawing.Point(91, 100);
            this.btnPlantAdd.Name = "btnPlantAdd";
            this.btnPlantAdd.Size = new System.Drawing.Size(103, 40);
            this.btnPlantAdd.TabIndex = 2;
            this.btnPlantAdd.Text = "&Add";
            this.btnPlantAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlantAdd.UseVisualStyleBackColor = false;
            this.btnPlantAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPlantRemove
            // 
            this.btnPlantRemove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlantRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlantRemove.ForeColor = System.Drawing.Color.White;
            this.btnPlantRemove.Image = global::UpastitiCS.Properties.Resources.cancel;
            this.btnPlantRemove.Location = new System.Drawing.Point(214, 100);
            this.btnPlantRemove.Name = "btnPlantRemove";
            this.btnPlantRemove.Size = new System.Drawing.Size(105, 40);
            this.btnPlantRemove.TabIndex = 3;
            this.btnPlantRemove.Text = "&Remove";
            this.btnPlantRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlantRemove.UseVisualStyleBackColor = false;
            this.btnPlantRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gbPlant
            // 
            this.gbPlant.BackColor = System.Drawing.Color.Transparent;
            this.gbPlant.Controls.Add(this.tbPlantTitle);
            this.gbPlant.Controls.Add(this.lblPlantTitle);
            this.gbPlant.Controls.Add(this.btnPlantAdd);
            this.gbPlant.Controls.Add(this.btnPlantRemove);
            this.gbPlant.Controls.Add(this.cbPlant);
            this.gbPlant.Controls.Add(this.lblPlant);
            this.gbPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlant.ForeColor = System.Drawing.Color.White;
            this.gbPlant.Location = new System.Drawing.Point(14, 8);
            this.gbPlant.Name = "gbPlant";
            this.gbPlant.Size = new System.Drawing.Size(400, 148);
            this.gbPlant.TabIndex = 0;
            this.gbPlant.TabStop = false;
            this.gbPlant.Text = "Manage Plant";
            // 
            // tbPlantTitle
            // 
            this.tbPlantTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlantTitle.Location = new System.Drawing.Point(99, 63);
            this.tbPlantTitle.MaxLength = 249;
            this.tbPlantTitle.Name = "tbPlantTitle";
            this.tbPlantTitle.Size = new System.Drawing.Size(276, 21);
            this.tbPlantTitle.TabIndex = 1;
            this.tbPlantTitle.Leave += new System.EventHandler(this.tbPlantTitle_Leave);
            // 
            // lblPlantTitle
            // 
            this.lblPlantTitle.AutoSize = true;
            this.lblPlantTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPlantTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantTitle.ForeColor = System.Drawing.Color.White;
            this.lblPlantTitle.Location = new System.Drawing.Point(49, 61);
            this.lblPlantTitle.Name = "lblPlantTitle";
            this.lblPlantTitle.Size = new System.Drawing.Size(48, 20);
            this.lblPlantTitle.TabIndex = 29;
            this.lblPlantTitle.Tag = "";
            this.lblPlantTitle.Text = "Title:";
            this.lblPlantTitle.UseMnemonic = false;
            // 
            // gbSamiti
            // 
            this.gbSamiti.BackColor = System.Drawing.Color.Transparent;
            this.gbSamiti.Controls.Add(this.tbSamitiTitle);
            this.gbSamiti.Controls.Add(this.lblSamitiTitle);
            this.gbSamiti.Controls.Add(this.btnSamitiAdd);
            this.gbSamiti.Controls.Add(this.btnSamitiRemove);
            this.gbSamiti.Controls.Add(this.cbSamiti);
            this.gbSamiti.Controls.Add(this.lblSamiti);
            this.gbSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSamiti.ForeColor = System.Drawing.Color.White;
            this.gbSamiti.Location = new System.Drawing.Point(423, 9);
            this.gbSamiti.Name = "gbSamiti";
            this.gbSamiti.Size = new System.Drawing.Size(400, 148);
            this.gbSamiti.TabIndex = 1;
            this.gbSamiti.TabStop = false;
            this.gbSamiti.Text = "Manage Samiti";
            // 
            // tbSamitiTitle
            // 
            this.tbSamitiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSamitiTitle.Location = new System.Drawing.Point(96, 61);
            this.tbSamitiTitle.MaxLength = 249;
            this.tbSamitiTitle.Name = "tbSamitiTitle";
            this.tbSamitiTitle.Size = new System.Drawing.Size(282, 21);
            this.tbSamitiTitle.TabIndex = 1;
            this.tbSamitiTitle.Leave += new System.EventHandler(this.tbSamitiTitle_Leave);
            // 
            // lblSamitiTitle
            // 
            this.lblSamitiTitle.AutoSize = true;
            this.lblSamitiTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSamitiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamitiTitle.ForeColor = System.Drawing.Color.White;
            this.lblSamitiTitle.Location = new System.Drawing.Point(45, 60);
            this.lblSamitiTitle.Name = "lblSamitiTitle";
            this.lblSamitiTitle.Size = new System.Drawing.Size(48, 20);
            this.lblSamitiTitle.TabIndex = 30;
            this.lblSamitiTitle.Tag = "";
            this.lblSamitiTitle.Text = "Title:";
            this.lblSamitiTitle.UseMnemonic = false;
            // 
            // btnSamitiAdd
            // 
            this.btnSamitiAdd.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSamitiAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSamitiAdd.ForeColor = System.Drawing.Color.White;
            this.btnSamitiAdd.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnSamitiAdd.Location = new System.Drawing.Point(93, 100);
            this.btnSamitiAdd.Name = "btnSamitiAdd";
            this.btnSamitiAdd.Size = new System.Drawing.Size(103, 40);
            this.btnSamitiAdd.TabIndex = 2;
            this.btnSamitiAdd.Text = "A&dd";
            this.btnSamitiAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSamitiAdd.UseVisualStyleBackColor = false;
            this.btnSamitiAdd.Click += new System.EventHandler(this.btnSamitiAdd_Click);
            // 
            // btnSamitiRemove
            // 
            this.btnSamitiRemove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSamitiRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSamitiRemove.ForeColor = System.Drawing.Color.White;
            this.btnSamitiRemove.Image = global::UpastitiCS.Properties.Resources.cancel;
            this.btnSamitiRemove.Location = new System.Drawing.Point(216, 100);
            this.btnSamitiRemove.Name = "btnSamitiRemove";
            this.btnSamitiRemove.Size = new System.Drawing.Size(105, 40);
            this.btnSamitiRemove.TabIndex = 3;
            this.btnSamitiRemove.Text = "Re&move";
            this.btnSamitiRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSamitiRemove.UseVisualStyleBackColor = false;
            this.btnSamitiRemove.Click += new System.EventHandler(this.btnSamitiRemove_Click);
            // 
            // cbSamiti
            // 
            this.cbSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSamiti.FormattingEnabled = true;
            this.cbSamiti.Location = new System.Drawing.Point(96, 26);
            this.cbSamiti.Name = "cbSamiti";
            this.cbSamiti.Size = new System.Drawing.Size(258, 24);
            this.cbSamiti.TabIndex = 0;
            this.cbSamiti.SelectedIndexChanged += new System.EventHandler(this.cbSamiti_SelectedIndexChanged);
            // 
            // lblSamiti
            // 
            this.lblSamiti.AutoSize = true;
            this.lblSamiti.BackColor = System.Drawing.Color.Transparent;
            this.lblSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamiti.ForeColor = System.Drawing.Color.White;
            this.lblSamiti.Location = new System.Drawing.Point(30, 27);
            this.lblSamiti.Name = "lblSamiti";
            this.lblSamiti.Size = new System.Drawing.Size(69, 20);
            this.lblSamiti.TabIndex = 28;
            this.lblSamiti.Tag = "";
            this.lblSamiti.Text = "Samiti: ";
            this.lblSamiti.UseMnemonic = false;
            // 
            // gbDBParams
            // 
            this.gbDBParams.BackColor = System.Drawing.Color.Transparent;
            this.gbDBParams.Controls.Add(this.tbPassword);
            this.gbDBParams.Controls.Add(this.tbUserName);
            this.gbDBParams.Controls.Add(this.tbDBPort);
            this.gbDBParams.Controls.Add(this.tbHost);
            this.gbDBParams.Controls.Add(this.lblPassword);
            this.gbDBParams.Controls.Add(this.lblUserName);
            this.gbDBParams.Controls.Add(this.lblDBName);
            this.gbDBParams.Controls.Add(this.lblHost);
            this.gbDBParams.Controls.Add(this.btnApply);
            this.gbDBParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDBParams.ForeColor = System.Drawing.Color.White;
            this.gbDBParams.Location = new System.Drawing.Point(12, 157);
            this.gbDBParams.Name = "gbDBParams";
            this.gbDBParams.Size = new System.Drawing.Size(406, 198);
            this.gbDBParams.TabIndex = 2;
            this.gbDBParams.TabStop = false;
            this.gbDBParams.Text = "Database Parameters";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(160, 115);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(203, 21);
            this.tbPassword.TabIndex = 3;
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(160, 83);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(203, 21);
            this.tbUserName.TabIndex = 2;
            this.tbUserName.Text = "root";
            // 
            // tbDBPort
            // 
            this.tbDBPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBPort.Location = new System.Drawing.Point(160, 52);
            this.tbDBPort.Name = "tbDBPort";
            this.tbDBPort.Size = new System.Drawing.Size(203, 21);
            this.tbDBPort.TabIndex = 1;
            this.tbDBPort.Text = "upastiti";
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(160, 21);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(203, 21);
            this.tbHost.TabIndex = 0;
            this.tbHost.Text = "localhost";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPassword.Location = new System.Drawing.Point(28, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 18);
            this.lblPassword.TabIndex = 51;
            this.lblPassword.Tag = "";
            this.lblPassword.Text = "Password:";
            this.lblPassword.UseMnemonic = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUserName.Location = new System.Drawing.Point(26, 83);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(98, 18);
            this.lblUserName.TabIndex = 50;
            this.lblUserName.Tag = "";
            this.lblUserName.Text = "User Name:";
            this.lblUserName.UseMnemonic = false;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.BackColor = System.Drawing.Color.Transparent;
            this.lblDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDBName.Location = new System.Drawing.Point(24, 51);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(133, 18);
            this.lblDBName.TabIndex = 49;
            this.lblDBName.Tag = "";
            this.lblDBName.Text = "Database Name:";
            this.lblDBName.UseMnemonic = false;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHost.Location = new System.Drawing.Point(25, 20);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(49, 18);
            this.lblHost.TabIndex = 48;
            this.lblHost.Tag = "";
            this.lblHost.Text = "Host:";
            this.lblHost.UseMnemonic = false;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnApply.Location = new System.Drawing.Point(62, 142);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(241, 50);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply &Changes";
            this.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gbResetPass
            // 
            this.gbResetPass.BackColor = System.Drawing.Color.Transparent;
            this.gbResetPass.Controls.Add(this.tbMasterPass);
            this.gbResetPass.Controls.Add(this.lblMasterPass);
            this.gbResetPass.Controls.Add(this.btnResetPass);
            this.gbResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResetPass.ForeColor = System.Drawing.Color.White;
            this.gbResetPass.Location = new System.Drawing.Point(14, 515);
            this.gbResetPass.Name = "gbResetPass";
            this.gbResetPass.Size = new System.Drawing.Size(812, 74);
            this.gbResetPass.TabIndex = 4;
            this.gbResetPass.TabStop = false;
            this.gbResetPass.Text = "Master Password";
            // 
            // tbMasterPass
            // 
            this.tbMasterPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMasterPass.Location = new System.Drawing.Point(169, 33);
            this.tbMasterPass.Name = "tbMasterPass";
            this.tbMasterPass.PasswordChar = '*';
            this.tbMasterPass.Size = new System.Drawing.Size(196, 21);
            this.tbMasterPass.TabIndex = 0;
            this.tbMasterPass.Text = "allowme";
            // 
            // lblMasterPass
            // 
            this.lblMasterPass.AutoSize = true;
            this.lblMasterPass.BackColor = System.Drawing.Color.Transparent;
            this.lblMasterPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMasterPass.Location = new System.Drawing.Point(71, 34);
            this.lblMasterPass.Name = "lblMasterPass";
            this.lblMasterPass.Size = new System.Drawing.Size(88, 18);
            this.lblMasterPass.TabIndex = 48;
            this.lblMasterPass.Tag = "";
            this.lblMasterPass.Text = "Password:";
            this.lblMasterPass.UseMnemonic = false;
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPass.ForeColor = System.Drawing.Color.White;
            this.btnResetPass.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnResetPass.Location = new System.Drawing.Point(421, 18);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(223, 50);
            this.btnResetPass.TabIndex = 1;
            this.btnResetPass.Text = "Update &Password";
            this.btnResetPass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetPass.UseVisualStyleBackColor = false;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // gbDefaultPlant
            // 
            this.gbDefaultPlant.BackColor = System.Drawing.Color.Transparent;
            this.gbDefaultPlant.Controls.Add(this.cbSelectPlant);
            this.gbDefaultPlant.Controls.Add(this.lblSelectPlant);
            this.gbDefaultPlant.Controls.Add(this.btnUpdatePlant);
            this.gbDefaultPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefaultPlant.ForeColor = System.Drawing.Color.White;
            this.gbDefaultPlant.Location = new System.Drawing.Point(423, 157);
            this.gbDefaultPlant.Name = "gbDefaultPlant";
            this.gbDefaultPlant.Size = new System.Drawing.Size(400, 198);
            this.gbDefaultPlant.TabIndex = 3;
            this.gbDefaultPlant.TabStop = false;
            this.gbDefaultPlant.Text = "Default Plant";
            // 
            // cbSelectPlant
            // 
            this.cbSelectPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectPlant.FormattingEnabled = true;
            this.cbSelectPlant.Location = new System.Drawing.Point(126, 46);
            this.cbSelectPlant.Name = "cbSelectPlant";
            this.cbSelectPlant.Size = new System.Drawing.Size(252, 24);
            this.cbSelectPlant.TabIndex = 0;
            // 
            // lblSelectPlant
            // 
            this.lblSelectPlant.AutoSize = true;
            this.lblSelectPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPlant.ForeColor = System.Drawing.Color.White;
            this.lblSelectPlant.Location = new System.Drawing.Point(9, 50);
            this.lblSelectPlant.Name = "lblSelectPlant";
            this.lblSelectPlant.Size = new System.Drawing.Size(111, 20);
            this.lblSelectPlant.TabIndex = 32;
            this.lblSelectPlant.Tag = "";
            this.lblSelectPlant.Text = "Select Plant:";
            this.lblSelectPlant.UseMnemonic = false;
            // 
            // btnUpdatePlant
            // 
            this.btnUpdatePlant.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdatePlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePlant.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePlant.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnUpdatePlant.Location = new System.Drawing.Point(93, 94);
            this.btnUpdatePlant.Name = "btnUpdatePlant";
            this.btnUpdatePlant.Size = new System.Drawing.Size(241, 50);
            this.btnUpdatePlant.TabIndex = 1;
            this.btnUpdatePlant.Text = "&Update Plant";
            this.btnUpdatePlant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdatePlant.UseVisualStyleBackColor = false;
            this.btnUpdatePlant.Click += new System.EventHandler(this.btnUpdatePlant_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbContractorTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnContractorAdd);
            this.groupBox1.Controls.Add(this.btnContractorRemove);
            this.groupBox1.Controls.Add(this.cbContractor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(183, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 148);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Contractor";
            // 
            // tbContractorTitle
            // 
            this.tbContractorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContractorTitle.Location = new System.Drawing.Point(96, 61);
            this.tbContractorTitle.MaxLength = 249;
            this.tbContractorTitle.Name = "tbContractorTitle";
            this.tbContractorTitle.Size = new System.Drawing.Size(282, 21);
            this.tbContractorTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 30;
            this.label1.Tag = "";
            this.label1.Text = "Title:";
            this.label1.UseMnemonic = false;
            // 
            // btnContractorAdd
            // 
            this.btnContractorAdd.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnContractorAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContractorAdd.ForeColor = System.Drawing.Color.White;
            this.btnContractorAdd.Image = global::UpastitiCS.Properties.Resources.add;
            this.btnContractorAdd.Location = new System.Drawing.Point(93, 100);
            this.btnContractorAdd.Name = "btnContractorAdd";
            this.btnContractorAdd.Size = new System.Drawing.Size(103, 40);
            this.btnContractorAdd.TabIndex = 2;
            this.btnContractorAdd.Text = "A&dd";
            this.btnContractorAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContractorAdd.UseVisualStyleBackColor = false;
            // 
            // btnContractorRemove
            // 
            this.btnContractorRemove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnContractorRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContractorRemove.ForeColor = System.Drawing.Color.White;
            this.btnContractorRemove.Image = global::UpastitiCS.Properties.Resources.cancel;
            this.btnContractorRemove.Location = new System.Drawing.Point(216, 100);
            this.btnContractorRemove.Name = "btnContractorRemove";
            this.btnContractorRemove.Size = new System.Drawing.Size(105, 40);
            this.btnContractorRemove.TabIndex = 3;
            this.btnContractorRemove.Text = "Re&move";
            this.btnContractorRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContractorRemove.UseVisualStyleBackColor = false;
            // 
            // cbContractor
            // 
            this.cbContractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContractor.FormattingEnabled = true;
            this.cbContractor.Location = new System.Drawing.Point(129, 26);
            this.cbContractor.Name = "cbContractor";
            this.cbContractor.Size = new System.Drawing.Size(225, 24);
            this.cbContractor.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 28;
            this.label2.Tag = "";
            this.label2.Text = "Contractor: ";
            this.label2.UseMnemonic = false;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpastitiCS.Properties.Resources.gray3;
            this.ClientSize = new System.Drawing.Size(853, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDefaultPlant);
            this.Controls.Add(this.gbResetPass);
            this.Controls.Add(this.gbDBParams);
            this.Controls.Add(this.gbSamiti);
            this.Controls.Add(this.gbPlant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.gbPlant.ResumeLayout(false);
            this.gbPlant.PerformLayout();
            this.gbSamiti.ResumeLayout(false);
            this.gbSamiti.PerformLayout();
            this.gbDBParams.ResumeLayout(false);
            this.gbDBParams.PerformLayout();
            this.gbResetPass.ResumeLayout(false);
            this.gbResetPass.PerformLayout();
            this.gbDefaultPlant.ResumeLayout(false);
            this.gbDefaultPlant.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.Button btnPlantAdd;
        private System.Windows.Forms.Button btnPlantRemove;
        private System.Windows.Forms.GroupBox gbPlant;
        private System.Windows.Forms.GroupBox gbSamiti;
        private System.Windows.Forms.Button btnSamitiAdd;
        private System.Windows.Forms.Button btnSamitiRemove;
        private System.Windows.Forms.ComboBox cbSamiti;
        private System.Windows.Forms.Label lblSamiti;
        private System.Windows.Forms.GroupBox gbDBParams;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbDBPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.GroupBox gbResetPass;
        private System.Windows.Forms.Label lblMasterPass;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.TextBox tbMasterPass;
        private System.Windows.Forms.Label lblPlantTitle;
        private System.Windows.Forms.Label lblSamitiTitle;
        private System.Windows.Forms.TextBox tbPlantTitle;
        private System.Windows.Forms.TextBox tbSamitiTitle;
        private System.Windows.Forms.GroupBox gbDefaultPlant;
        private System.Windows.Forms.Button btnUpdatePlant;
        private System.Windows.Forms.ComboBox cbSelectPlant;
        private System.Windows.Forms.Label lblSelectPlant;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbContractorTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContractorAdd;
        private System.Windows.Forms.Button btnContractorRemove;
        private System.Windows.Forms.ComboBox cbContractor;
        private System.Windows.Forms.Label label2;
    }
}