namespace UpastitiCS
{
    partial class MissIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissIN));
            this.lblSelectStaff = new System.Windows.Forms.Label();
            this.lbIRStaff = new System.Windows.Forms.ListBox();
            this.cbSamiti = new System.Windows.Forms.ComboBox();
            this.lblSamiti = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSelectDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShiftCode = new System.Windows.Forms.ComboBox();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectStaff
            // 
            this.lblSelectStaff.AutoSize = true;
            this.lblSelectStaff.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectStaff.ForeColor = System.Drawing.Color.White;
            this.lblSelectStaff.Location = new System.Drawing.Point(152, 5);
            this.lblSelectStaff.Name = "lblSelectStaff";
            this.lblSelectStaff.Size = new System.Drawing.Size(107, 16);
            this.lblSelectStaff.TabIndex = 4;
            this.lblSelectStaff.Text = "1. Select Staff:";
            // 
            // lbIRStaff
            // 
            this.lbIRStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIRStaff.FormattingEnabled = true;
            this.lbIRStaff.ItemHeight = 16;
            this.lbIRStaff.Location = new System.Drawing.Point(65, 55);
            this.lbIRStaff.Name = "lbIRStaff";
            this.lbIRStaff.Size = new System.Drawing.Size(280, 212);
            this.lbIRStaff.TabIndex = 1;
            // 
            // cbSamiti
            // 
            this.cbSamiti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSamiti.FormattingEnabled = true;
            this.cbSamiti.Location = new System.Drawing.Point(137, 25);
            this.cbSamiti.Name = "cbSamiti";
            this.cbSamiti.Size = new System.Drawing.Size(211, 23);
            this.cbSamiti.TabIndex = 0;
            this.cbSamiti.SelectedIndexChanged += new System.EventHandler(this.cbSamiti_SelectedIndexChanged);
            // 
            // lblSamiti
            // 
            this.lblSamiti.AutoSize = true;
            this.lblSamiti.BackColor = System.Drawing.Color.Transparent;
            this.lblSamiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamiti.ForeColor = System.Drawing.Color.White;
            this.lblSamiti.Location = new System.Drawing.Point(12, 27);
            this.lblSamiti.Name = "lblSamiti";
            this.lblSamiti.Size = new System.Drawing.Size(125, 18);
            this.lblSamiti.TabIndex = 49;
            this.lblSamiti.Tag = "";
            this.lblSamiti.Text = "Filter by Samiti:";
            this.lblSamiti.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "2. Select Date:";
            // 
            // dtpSelectDate
            // 
            this.dtpSelectDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSelectDate.Location = new System.Drawing.Point(163, 279);
            this.dtpSelectDate.Name = "dtpSelectDate";
            this.dtpSelectDate.Size = new System.Drawing.Size(200, 21);
            this.dtpSelectDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "3. Select Shift :";
            // 
            // cbShiftCode
            // 
            this.cbShiftCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShiftCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShiftCode.FormattingEnabled = true;
            this.cbShiftCode.Items.AddRange(new object[] {
            "1stShift",
            "2ndShift",
            "3rdShift",
            "GS"});
            this.cbShiftCode.Location = new System.Drawing.Point(162, 315);
            this.cbShiftCode.Name = "cbShiftCode";
            this.cbShiftCode.Size = new System.Drawing.Size(201, 24);
            this.cbShiftCode.TabIndex = 3;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.Transparent;
            this.panelActions.Controls.Add(this.btnCancel);
            this.panelActions.Controls.Add(this.btnUpdate);
            this.panelActions.Location = new System.Drawing.Point(12, 352);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(359, 47);
            this.panelActions.TabIndex = 55;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(182, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(70, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 35);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MissIN
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpastitiCS.Properties.Resources.gray3;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(381, 408);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.cbShiftCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpSelectDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSamiti);
            this.Controls.Add(this.lblSamiti);
            this.Controls.Add(this.lbIRStaff);
            this.Controls.Add(this.lblSelectStaff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MissIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Missing IN Punch";
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectStaff;
        private System.Windows.Forms.ListBox lbIRStaff;
        private System.Windows.Forms.ComboBox cbSamiti;
        private System.Windows.Forms.Label lblSamiti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSelectDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbShiftCode;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}