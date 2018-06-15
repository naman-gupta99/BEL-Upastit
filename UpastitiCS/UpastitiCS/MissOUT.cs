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
    public partial class MissOUT : Form
    {
        private MsSQL mssql = null;
        private string DefaultPlant = "";
        private DateTime selectedDate = DateTime.Now;
        public MissOUT()
        {
            InitializeComponent();
        }
        public void initialiseDatabase(string DBHost, string DBName, string DBUser, string DBPassword, string DP)
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
        private void dtpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            if (selectedDate.ToShortDateString() != dtpSelectDate.Value.ToShortDateString())
            {
                selectedDate = dtpSelectDate.Value;
                LoadDBValues();
                cbSelectAll.Checked = false;
            }
        }
        private bool isValidDate()
        {
            //Allow Regularisation upto Prevoius Day
            //i.e For Same Day, Regularisation is not allowed             
                SqlCommand cmd = new SqlCommand(string.Format("SELECT CURRENT_TIMESTAMP"), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (dtpSelectDate.Value.AddDays(1).CompareTo(reader.GetDateTime(0))<0)
                    {
                        reader.Close();
                        return true;
                    }
                    
                }
                reader.Close();
            return false;
        }
        private void LoadDBValues()
        {
            Regex regShift = new Regex(@"([\w]+)-([\w]+)");
            string prevStaffNo = "", prevShiftCode = "",prevStaffName="";
            if (isValidDate())
            {
                DateTime dt1 = dtpSelectDate.Value;
                if (DefaultPlant != "")
                {
                    string query = string.Format("select m.staffno,s.staffname,m.shiftcode,m.moveon from movement as m, staff as s where m.staffno=s.staffno "
                   + "and s.plantname='{1}' and m.moveon BETWEEN DATEADD(hour, 6,'{0}') AND DATEADD(hour, 31, '{0}')  order by m.staffno,m.moveon;", selectedDate.ToString("yyyy-MM-dd"), DefaultPlant);

                    SqlCommand cmd = new SqlCommand(query, mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    lbMOStaff.Items.Clear();
                    while (reader.Read())
                    {
                        dt1 = reader.GetDateTime(3);
                        if (regShift.Match(reader.GetString(2)).Groups[2].Value == "IN")
                        {
                            //Skip Next Day IN Punches, if any
                            if (dt1.Day != selectedDate.Day)
                                continue;
                            if (prevStaffNo != "" && prevStaffNo != reader.GetInt32(0).ToString())
                            {
                                lbMOStaff.Items.Add(prevStaffNo + "-" + prevStaffName + "-" + prevShiftCode);
                            }
                            prevStaffNo = reader.GetInt32(0).ToString();
                            prevStaffName = reader.GetString(1);
                            prevShiftCode = regShift.Match(reader.GetString(2)).Groups[1].Value;
                        }
                        else if (prevStaffNo == reader.GetInt32(0).ToString() && prevShiftCode == regShift.Match(reader.GetString(2)).Groups[1].Value)
                        {
                            prevStaffNo = "";
                        }

                    }
                    reader.Close();
                }
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //Select All 
            if (cbSelectAll.Checked)
            {
                for (int i = 0; i < lbMOStaff.Items.Count; i++)
                    lbMOStaff.SetSelected(i, true);
            }
            else
            {
                for (int i = 0; i < lbMOStaff.Items.Count; i++)
                    lbMOStaff.SetSelected(i, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbMOStaff.SelectedItems.Count > 0)
            {
                Regex regShift = new Regex(@"([\w\s]+)-([\w\s._]+)-([\w\s]+)");
                int affectedRows = 0;
                for (int i = 0; i < lbMOStaff.SelectedItems.Count; i++)
                {
                    if (mssql != null && mssql.isConnected())
                    {
                        if (getShiftTime(regShift.Match(lbMOStaff.SelectedItems[i].ToString()).Groups[3].Value) != "")
                            if (mssql.executeNonQuery(string.Format("INSERT INTO movement VALUES({0},'{1}','{2}')", regShift.Match(lbMOStaff.SelectedItems[i].ToString()).Groups[1].Value, getShiftTime(regShift.Match(lbMOStaff.SelectedItems[i].ToString()).Groups[3].Value), regShift.Match(lbMOStaff.SelectedItems[i].ToString()).Groups[3].Value + "-OUT")) == 1)
                            {
                                affectedRows++;
                            }
                    }
                }
                if (affectedRows > 0)
                {
                    LoadDBValues();
                    MessageBox.Show(this, string.Format("Successfully Updated {0} OUT Punch/es.", affectedRows), "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Kindly select at-least one staff to Update!", "Staff?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private string getShiftTime(string shiftcode)
        {
            if (shiftcode == "1stShift")
                return string.Format("{0} 14:30:00", selectedDate.ToString("yyyy-MM-dd"));
            else if (shiftcode == "2ndShift")
                return string.Format("{0} 22:30:00", selectedDate.ToString("yyyy-MM-dd"));
            else if (shiftcode == "3rdShift")
                return string.Format("{0} 06:30:00", selectedDate.AddDays(1).ToString("yyyy-MM-dd"));
            else if (shiftcode == "GS")
                return string.Format("{0} 16:00:00", selectedDate.ToString("yyyy-MM-dd"));
            else
                return "";
        }

     
    }
}
