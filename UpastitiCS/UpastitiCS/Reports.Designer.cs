namespace UpastitiCS
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbMonthReport = new System.Windows.Forms.GroupBox();
            this.cbOvertime = new System.Windows.Forms.CheckBox();
            this.lblFilters = new System.Windows.Forms.Label();
            this.cbSamiti = new System.Windows.Forms.ComboBox();
            this.lblSamiti = new System.Windows.Forms.Label();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.lblPlant = new System.Windows.Forms.Label();
            this.gbDayReport = new System.Windows.Forms.GroupBox();
            this.btnDayReport = new System.Windows.Forms.Button();
            this.dtpDRDate = new System.Windows.Forms.DateTimePicker();
            this.lblDRDate = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.lbMRStaff = new System.Windows.Forms.ListBox();
            this.lblMRStaff = new System.Windows.Forms.Label();
            this.btnMonthReport = new System.Windows.Forms.Button();
            this.dtpMRDate = new System.Windows.Forms.DateTimePicker();
            this.lblMRDate = new System.Windows.Forms.Label();
            this.gbIndividual = new System.Windows.Forms.GroupBox();
            this.dtpIRTo = new System.Windows.Forms.DateTimePicker();
            this.lblIRTo = new System.Windows.Forms.Label();
            this.lbIRStaff = new System.Windows.Forms.ListBox();
            this.lblIRStaff = new System.Windows.Forms.Label();
            this.btnIR = new System.Windows.Forms.Button();
            this.dtpIRFrom = new System.Windows.Forms.DateTimePicker();
            this.lblIRFrom = new System.Windows.Forms.Label();
            this.gbMonthReport.SuspendLayout();
            this.gbDayReport.SuspendLayout();
            this.gbIndividual.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(233, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 31);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Upastiti Report";
            // 
            // gbMonthReport
            // 
            this.gbMonthReport.BackColor = System.Drawing.Color.Transparent;
            this.gbMonthReport.Controls.Add(this.cbOvertime);
            this.gbMonthReport.Controls.Add(this.lblFilters);
            this.gbMonthReport.Controls.Add(this.cbSamiti);
            this.gbMonthReport.Controls.Add(this.lblSamiti);
            this.gbMonthReport.Controls.Add(this.cbPlant);
            this.gbMonthReport.Controls.Add(this.lblPlant);
            this.gbMonthReport.Controls.Add(this.gbDayReport);
            this.gbMonthReport.Controls.Add(this.cbSelectAll);
            this.gbMonthReport.Controls.Add(this.lbMRStaff);
            this.gbMonthReport.Controls.Add(this.lblMRStaff);
            this.gbMonthReport.Controls.Add(this.btnMonthReport);
            this.gbMonthReport.Controls.Add(this.dtpMRDate);
            this.gbMonthReport.Controls.Add(this.lblMRDate);
            this.gbMonthReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMonthReport.ForeColor = System.Drawing.Color.White;
            this.gbMonthReport.Location = new System.Drawing.Point(15, 36);
            this.gbMonthReport.Name = "gbMonthReport";
            this.gbMonthReport.Size = new System.Drawing.Size(642, 372);
            this.gbMonthReport.TabIndex = 0;
            this.gbMonthReport.TabStop = false;
            this.gbMonthReport.Text = "Month Report";
            // 
            // cbOvertime
            // 
            this.cbOvertime.AutoSize = true;
            this.cbOvertime.Location = new System.Drawing.Point(86, 95);
            this.cbOvertime.Name = "cbOvertime";
            this.cbOvertime.Size = new System.Drawing.Size(139, 24);
            this.cbOvertime.TabIndex = 3;
            this.cbOvertime.Text = "Only Overtime";
            this.cbOvertime.UseVisualStyleBackColor = true;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilters.Location = new System.Drawing.Point(469, 15);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(59, 20);
            this.lblFilters.TabIndex = 47;
            this.lblFilters.Text = "Filters";
            // 
            // cbSamiti
            // 
            this.cbSamiti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSamiti.FormattingEnabled = true;
            this.cbSamiti.Location = new System.Drawing.Point(411, 71);
            this.cbSamiti.Name = "cbSamiti";
            this.cbSamiti.Size = new System.Drawing.Size(211, 23);
            this.cbSamiti.TabIndex = 2;
            this.cbSamiti.SelectedIndexChanged += new System.EventHandler(this.cbSamiti_SelectedIndexChanged);
            // 
            // lblSamiti
            // 
            this.lblSamiti.AutoSize = true;
            this.lblSamiti.BackColor = System.Drawing.Color.Transparent;
            this.lblSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamiti.ForeColor = System.Drawing.Color.White;
            this.lblSamiti.Location = new System.Drawing.Point(345, 72);
            this.lblSamiti.Name = "lblSamiti";
            this.lblSamiti.Size = new System.Drawing.Size(60, 18);
            this.lblSamiti.TabIndex = 46;
            this.lblSamiti.Tag = "";
            this.lblSamiti.Text = "Samiti:";
            this.lblSamiti.UseMnemonic = false;
            // 
            // cbPlant
            // 
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(411, 38);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(211, 23);
            this.cbPlant.TabIndex = 1;
            this.cbPlant.SelectedIndexChanged += new System.EventHandler(this.cbPlant_SelectedIndexChanged);
            // 
            // lblPlant
            // 
            this.lblPlant.AutoSize = true;
            this.lblPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlant.ForeColor = System.Drawing.Color.White;
            this.lblPlant.Location = new System.Drawing.Point(345, 39);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(51, 18);
            this.lblPlant.TabIndex = 45;
            this.lblPlant.Tag = "";
            this.lblPlant.Text = "Plant:";
            this.lblPlant.UseMnemonic = false;
            // 
            // gbDayReport
            // 
            this.gbDayReport.BackColor = System.Drawing.Color.Transparent;
            this.gbDayReport.Controls.Add(this.btnDayReport);
            this.gbDayReport.Controls.Add(this.dtpDRDate);
            this.gbDayReport.Controls.Add(this.lblDRDate);
            this.gbDayReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDayReport.ForeColor = System.Drawing.Color.White;
            this.gbDayReport.Location = new System.Drawing.Point(6, 187);
            this.gbDayReport.Name = "gbDayReport";
            this.gbDayReport.Size = new System.Drawing.Size(325, 150);
            this.gbDayReport.TabIndex = 5;
            this.gbDayReport.TabStop = false;
            this.gbDayReport.Text = "Day Report";
            // 
            // btnDayReport
            // 
            this.btnDayReport.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDayReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayReport.ForeColor = System.Drawing.Color.White;
            this.btnDayReport.Image = global::UpastitiCS.Properties.Resources.history;
            this.btnDayReport.Location = new System.Drawing.Point(27, 70);
            this.btnDayReport.Name = "btnDayReport";
            this.btnDayReport.Size = new System.Drawing.Size(273, 70);
            this.btnDayReport.TabIndex = 1;
            this.btnDayReport.Text = "Generate Report";
            this.btnDayReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDayReport.UseVisualStyleBackColor = false;
            this.btnDayReport.Click += new System.EventHandler(this.btnDayReport_Click);
            // 
            // dtpDRDate
            // 
            this.dtpDRDate.CustomFormat = "dd MMMM yyyy";
            this.dtpDRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDRDate.Location = new System.Drawing.Point(76, 30);
            this.dtpDRDate.Name = "dtpDRDate";
            this.dtpDRDate.Size = new System.Drawing.Size(239, 26);
            this.dtpDRDate.TabIndex = 0;
            // 
            // lblDRDate
            // 
            this.lblDRDate.AutoSize = true;
            this.lblDRDate.Location = new System.Drawing.Point(12, 31);
            this.lblDRDate.Name = "lblDRDate";
            this.lblDRDate.Size = new System.Drawing.Size(58, 20);
            this.lblDRDate.TabIndex = 0;
            this.lblDRDate.Text = "Date: ";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(348, 348);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(104, 24);
            this.cbSelectAll.TabIndex = 24;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // lbMRStaff
            // 
            this.lbMRStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMRStaff.FormattingEnabled = true;
            this.lbMRStaff.ItemHeight = 16;
            this.lbMRStaff.Location = new System.Drawing.Point(337, 119);
            this.lbMRStaff.Name = "lbMRStaff";
            this.lbMRStaff.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMRStaff.Size = new System.Drawing.Size(294, 228);
            this.lbMRStaff.TabIndex = 23;
            // 
            // lblMRStaff
            // 
            this.lblMRStaff.AutoSize = true;
            this.lblMRStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRStaff.Location = new System.Drawing.Point(434, 98);
            this.lblMRStaff.Name = "lblMRStaff";
            this.lblMRStaff.Size = new System.Drawing.Size(105, 20);
            this.lblMRStaff.TabIndex = 22;
            this.lblMRStaff.Text = "Select Staff";
            // 
            // btnMonthReport
            // 
            this.btnMonthReport.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMonthReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthReport.ForeColor = System.Drawing.Color.White;
            this.btnMonthReport.Image = global::UpastitiCS.Properties.Resources.history;
            this.btnMonthReport.Location = new System.Drawing.Point(17, 120);
            this.btnMonthReport.Name = "btnMonthReport";
            this.btnMonthReport.Size = new System.Drawing.Size(301, 69);
            this.btnMonthReport.TabIndex = 4;
            this.btnMonthReport.Text = "Generate Report";
            this.btnMonthReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMonthReport.UseVisualStyleBackColor = false;
            this.btnMonthReport.Click += new System.EventHandler(this.btnMonthReport_Click);
            // 
            // dtpMRDate
            // 
            this.dtpMRDate.CustomFormat = "MMMM yyyy";
            this.dtpMRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMRDate.Location = new System.Drawing.Point(86, 42);
            this.dtpMRDate.Name = "dtpMRDate";
            this.dtpMRDate.Size = new System.Drawing.Size(235, 26);
            this.dtpMRDate.TabIndex = 0;
            // 
            // lblMRDate
            // 
            this.lblMRDate.AutoSize = true;
            this.lblMRDate.Location = new System.Drawing.Point(13, 44);
            this.lblMRDate.Name = "lblMRDate";
            this.lblMRDate.Size = new System.Drawing.Size(58, 20);
            this.lblMRDate.TabIndex = 0;
            this.lblMRDate.Text = "Date: ";
            // 
            // gbIndividual
            // 
            this.gbIndividual.BackColor = System.Drawing.Color.Transparent;
            this.gbIndividual.Controls.Add(this.dtpIRTo);
            this.gbIndividual.Controls.Add(this.lblIRTo);
            this.gbIndividual.Controls.Add(this.lbIRStaff);
            this.gbIndividual.Controls.Add(this.lblIRStaff);
            this.gbIndividual.Controls.Add(this.btnIR);
            this.gbIndividual.Controls.Add(this.dtpIRFrom);
            this.gbIndividual.Controls.Add(this.lblIRFrom);
            this.gbIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIndividual.ForeColor = System.Drawing.Color.White;
            this.gbIndividual.Location = new System.Drawing.Point(15, 409);
            this.gbIndividual.Name = "gbIndividual";
            this.gbIndividual.Size = new System.Drawing.Size(642, 255);
            this.gbIndividual.TabIndex = 1;
            this.gbIndividual.TabStop = false;
            this.gbIndividual.Text = "Individual Report";
            // 
            // dtpIRTo
            // 
            this.dtpIRTo.CustomFormat = "dd MMMM yyyy";
            this.dtpIRTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIRTo.Location = new System.Drawing.Point(86, 98);
            this.dtpIRTo.Name = "dtpIRTo";
            this.dtpIRTo.Size = new System.Drawing.Size(235, 26);
            this.dtpIRTo.TabIndex = 1;
            // 
            // lblIRTo
            // 
            this.lblIRTo.AutoSize = true;
            this.lblIRTo.Location = new System.Drawing.Point(36, 102);
            this.lblIRTo.Name = "lblIRTo";
            this.lblIRTo.Size = new System.Drawing.Size(34, 20);
            this.lblIRTo.TabIndex = 24;
            this.lblIRTo.Text = "To:";
            // 
            // lbIRStaff
            // 
            this.lbIRStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIRStaff.FormattingEnabled = true;
            this.lbIRStaff.ItemHeight = 16;
            this.lbIRStaff.Location = new System.Drawing.Point(337, 40);
            this.lbIRStaff.Name = "lbIRStaff";
            this.lbIRStaff.Size = new System.Drawing.Size(294, 212);
            this.lbIRStaff.TabIndex = 2;
            // 
            // lblIRStaff
            // 
            this.lblIRStaff.AutoSize = true;
            this.lblIRStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIRStaff.Location = new System.Drawing.Point(421, 19);
            this.lblIRStaff.Name = "lblIRStaff";
            this.lblIRStaff.Size = new System.Drawing.Size(105, 20);
            this.lblIRStaff.TabIndex = 22;
            this.lblIRStaff.Text = "Select Staff";
            // 
            // btnIR
            // 
            this.btnIR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIR.ForeColor = System.Drawing.Color.White;
            this.btnIR.Image = global::UpastitiCS.Properties.Resources.history;
            this.btnIR.Location = new System.Drawing.Point(23, 149);
            this.btnIR.Name = "btnIR";
            this.btnIR.Size = new System.Drawing.Size(301, 74);
            this.btnIR.TabIndex = 3;
            this.btnIR.Text = "Generate Report";
            this.btnIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIR.UseVisualStyleBackColor = false;
            this.btnIR.Click += new System.EventHandler(this.btnIR_Click);
            // 
            // dtpIRFrom
            // 
            this.dtpIRFrom.CustomFormat = "dd MMMM yyyy";
            this.dtpIRFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIRFrom.Location = new System.Drawing.Point(86, 43);
            this.dtpIRFrom.Name = "dtpIRFrom";
            this.dtpIRFrom.Size = new System.Drawing.Size(235, 26);
            this.dtpIRFrom.TabIndex = 0;
            // 
            // lblIRFrom
            // 
            this.lblIRFrom.AutoSize = true;
            this.lblIRFrom.Location = new System.Drawing.Point(13, 45);
            this.lblIRFrom.Name = "lblIRFrom";
            this.lblIRFrom.Size = new System.Drawing.Size(55, 20);
            this.lblIRFrom.TabIndex = 0;
            this.lblIRFrom.Text = "From:";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpastitiCS.Properties.Resources.gray3;
            this.ClientSize = new System.Drawing.Size(682, 669);
            this.Controls.Add(this.gbIndividual);
            this.Controls.Add(this.gbMonthReport);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.gbMonthReport.ResumeLayout(false);
            this.gbMonthReport.PerformLayout();
            this.gbDayReport.ResumeLayout(false);
            this.gbDayReport.PerformLayout();
            this.gbIndividual.ResumeLayout(false);
            this.gbIndividual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbMonthReport;
        private System.Windows.Forms.Button btnMonthReport;
        private System.Windows.Forms.DateTimePicker dtpMRDate;
        private System.Windows.Forms.Label lblMRDate;
        private System.Windows.Forms.Label lblMRStaff;
        private System.Windows.Forms.ListBox lbMRStaff;
        private System.Windows.Forms.GroupBox gbIndividual;
        private System.Windows.Forms.ListBox lbIRStaff;
        private System.Windows.Forms.Label lblIRStaff;
        private System.Windows.Forms.Button btnIR;
        private System.Windows.Forms.DateTimePicker dtpIRFrom;
        private System.Windows.Forms.Label lblIRFrom;
        private System.Windows.Forms.DateTimePicker dtpIRTo;
        private System.Windows.Forms.Label lblIRTo;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.GroupBox gbDayReport;
        private System.Windows.Forms.Button btnDayReport;
        private System.Windows.Forms.DateTimePicker dtpDRDate;
        private System.Windows.Forms.Label lblDRDate;
        private System.Windows.Forms.ComboBox cbSamiti;
        private System.Windows.Forms.Label lblSamiti;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.CheckBox cbOvertime;
    }
}