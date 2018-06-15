using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace UpastitiCS
{
    public partial class MissIN : Form
    {
        private MsSQL mssql = null;
        private string DefaultPlant="";
        public MissIN()
        {
            InitializeComponent();
        }

        public void initialiseDatabase(string DBHost, string DBName, string DBUser, string DBPassword,string DP)
        {
            try
            {
                if (mssql != null)
                    mssql = null;   //TODO: Think How to Dispose
                mssql = new MsSQL();
                mssql.initMsSQL(DBHost, DBName, DBUser, DBPassword);
                mssql.connect();
                DefaultPlant = DP;
                LoadDBValues();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@initDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:initialiseDatabase):" + e.Message);
            }
        }
        private void LoadDBValues()
        {
            try
            {
                if (DefaultPlant != "")
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,staffname FROM staff where plantname='{0}' order by staffno;", DefaultPlant), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    lbIRStaff.Items.Clear();
                    //lbIRStaff.Items.Clear();
                    while (reader.Read())
                    {
                        lbIRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
                        // lbMRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
                    }
                    reader.Close();


                    cbSamiti.Items.Clear();
                    cbSamiti.Items.Add("NONE");  //First Item
                    cmd.CommandText = string.Format("SELECT * FROM samiti order by samitiname;");
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbSamiti.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@LoadDBValues", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:LoadDBValues):" + e.Message);
            }

        }

        private void cbSamiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadStaff();
        }
        private void loadStaff()
        {
            if (cbSamiti.Text == "" || cbSamiti.Text == "NONE")
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,staffname FROM staff where plantname='{0}' order by staffno;", DefaultPlant), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                lbIRStaff.Items.Clear();
                while (reader.Read())
                {
                    lbIRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
                }
                reader.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,staffname FROM staff where plantname='{0}' AND samitiname='{1}' order by staffno;", DefaultPlant,cbSamiti.Text), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                lbIRStaff.Items.Clear();
                while (reader.Read())
                {
                    lbIRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
                }
                reader.Close();
            }
        }
        private string getINTime()
        {
            if (cbShiftCode.Text == "1stShift")
                return "06:30:00";
            else if (cbShiftCode.Text == "2ndShift")
                return "14:30:00";
            else if (cbShiftCode.Text == "3rdShift")
                return "22:30:00";
            else if (cbShiftCode.Text == "GS")
                return "08:00:00";
            return "";
        }
        private string getOUTTime()
        {
            if (cbShiftCode.Text == "1stShift")
                return "14:30:00";
            else if (cbShiftCode.Text == "2ndShift")
                return "22:30:00";
            else if (cbShiftCode.Text == "3rdShift")
                return "06:30:00";
            else if (cbShiftCode.Text == "GS")
                return "16:00:00";
            return "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string InTime = "", OutTime = "";
            Regex regShift = new Regex(@"([\w\s]+)-([\w\s._]+)");
            if (isMandatoryDataProvided())
            {
                if (isValidDate())
                {
                    if (!isDuplicateRecordExists())
                    {
                        InTime = getINTime();
                        OutTime = getOUTTime();
                        if (InTime != "" && OutTime != "")
                        {
                            if (MessageBox.Show(this, String.Format("Following Record will be inserted:\nStaffNo: {0}   Name: {1}\n IN: {2}   OUT: {3}\nAre you sure to proceed?", regShift.Match(lbIRStaff.SelectedItem.ToString()).Groups[1].Value, regShift.Match(lbIRStaff.SelectedItem.ToString()).Groups[2].Value, dtpSelectDate.Value.ToString("dd-MM-yyyy") + " " + InTime, (OutTime == "06:30:00") ? (dtpSelectDate.Value.AddDays(1).ToString("dd-MM-yyyy") + " " + OutTime) : (dtpSelectDate.Value.ToString("dd-MM-yyyy") + " " + OutTime)), "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (mssql.executeNonQuery(string.Format("INSERT INTO movement VALUES({0},'{1}','{2}')", regShift.Match(lbIRStaff.SelectedItem.ToString()).Groups[1].Value, dtpSelectDate.Value.ToString("yyyy-MM-dd") + " " + InTime,"U"+cbShiftCode.Text+"-IN")) == 1 &&
                                    mssql.executeNonQuery(string.Format("INSERT INTO movement VALUES({0},'{1}','{2}')", regShift.Match(lbIRStaff.SelectedItem.ToString()).Groups[1].Value, (OutTime == "06:30:00") ? (dtpSelectDate.Value.AddDays(1).ToString("yyyy-MM-dd") + " " + OutTime) : (dtpSelectDate.Value.ToString("yyyy-MM-dd") + " " + OutTime), "U" + cbShiftCode.Text + "-OUT")) == 1)
                                {
                                    MessageBox.Show(this, "Successfully Updated the New Record.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Shift-IN Record already exists!", "Shift-IN Record exists!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "You Can only Update Missing-IN and Missing-OUT records, one day prior to Current Date.", "Same Day Update Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Some required data is Missing!\nKindly provide data for all the 3 fields", "Missing Data?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool isMandatoryDataProvided()
        {
            if (lbIRStaff.SelectedItems.Count > 0 && cbShiftCode.SelectedIndex != -1)
                return true;
            return false;
        }
        private bool isDuplicateRecordExists()
        {
            Regex regShift = new Regex(@"([\w\s]+)-([\w\s._]+)");
            SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno from movement where staffno={0} and cast(moveon as date)='{1}'", regShift.Match(lbIRStaff.SelectedItem.ToString()).Groups[1].Value,dtpSelectDate.Value.ToString("yyyy-MM-dd")), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                    reader.Close();
                    return true;
            }
            reader.Close();
            return false;
        }
        private bool isValidDate()
        {
            //Allow Regularisation upto Prevoius Day
            //i.e For Same Day, Regularisation is not allowed             
            SqlCommand cmd = new SqlCommand(string.Format("SELECT CURRENT_TIMESTAMP"), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                if (dtpSelectDate.Value.AddDays(1).CompareTo(reader.GetDateTime(0)) < 0)
                {
                    reader.Close();
                    return true;
                }

            }
            reader.Close();
            return false;
        }
    }
}
