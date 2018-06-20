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
using MANTRA;
using System.Threading;
using System.IO;
//using System.IO;

namespace UpastitiCS
{
    public partial class MasterRecord : Form
    {
        private MsSQL mssql = null;
        private string DefaultPlant = "";
        private int selectedRow;
        private string btnState;

        //Related to Biometric Module
        private MFS100 mfs100 = null;
        private int quality = 70;
        private int timeout = 60000;
        private byte[] ANSITemplate1 = null;
        private byte[] ANSITemplate2 = null;
        private int matchThreshold = 14000;
        private string previewState = "Finger1";
        private ASCIIEncoding encoding = new ASCIIEncoding();

        public MasterRecord()
        {
            InitializeComponent();


            selectedRow = -1;
            btnState = "ADD";

            initialiseMFS100();
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
                Logger.log("Exception(MR:initialiseDatabase):" + e.Message);
            }
        }
        //*********************************************  Biometric Section  ********************************************//
        private void initialiseMFS100()
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                mfs100 = new MFS100();
                mfs100.OnPreview += onPreview;
                mfs100.OnCaptureCompleted += onCaptureCompleted;
                int ret = mfs100.Init();
                if (ret != 0)
                {
                    showMessage(mfs100.GetErrorMsg(ret), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@initialiseMFS100", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void showMessage(string msg, bool isError)
        {
            MessageBox.Show(this, msg, "MFS100", MessageBoxButtons.OK, (isError ? MessageBoxIcon.Error : MessageBoxIcon.Information), MessageBoxDefaultButton.Button1);
        }

        private void onPreview(FingerData fingerData)
        {
            Thread trd = new Thread(() =>
            {
                try
                {
                    if (previewState == "Finger1")
                    {
                        if (fingerData != null)
                        {
                            pbFinger1.Image = fingerData.FingerImage;
                            pbFinger1.Refresh();
                        }
                    }
                    else if (previewState == "Finger2")
                    {
                        if (fingerData != null)
                        {
                            pbFinger2.Image = fingerData.FingerImage;
                            pbFinger2.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            });
            trd.Start();
        }

        private void onCaptureCompleted(bool statusl, int errorCode, string errorMsg, FingerData fingerData)
        {
            try
            {
                if (statusl)
                {
                    if (previewState == "Finger1")
                    {
                        pbFinger1.Image = fingerData.FingerImage;
                        pbFinger1.Refresh();
                        ANSITemplate1 = new byte[fingerData.ANSITemplate.Length];
                        fingerData.ISOTemplate.CopyTo(ANSITemplate1, 0);

                        showMessage("Fingerprint Captured Successfully.\n Now Place Another Finger and Press Capture", false);
                        previewState = "Finger2";
                    }
                    else if (previewState == "Finger2")
                    {
                        pbFinger2.Image = fingerData.FingerImage;
                        pbFinger2.Refresh();
                        ANSITemplate2 = new byte[fingerData.ANSITemplate.Length];
                        fingerData.ISOTemplate.CopyTo(ANSITemplate2, 0);

                        showMessage("Both Fingerprints Captured Successfully.", false);
                        previewState = "Finger1";
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture.Enabled = false;
            try
            {
                if (previewState == "Finger1")
                {
                    clearBioValues();
                }
                int ret = mfs100.StartCapture(quality, timeout, true);
                if (ret != 0)
                {
                    showMessage(mfs100.GetErrorMsg(ret), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnCapture_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnCapture.Enabled = true;
        }
        private void clearBioValues()
        {
            ANSITemplate1 = null;
            ANSITemplate2 = null;
            pbFinger1.Image = null;
            pbFinger2.Image = null;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void LoadDBValues()
        {
            try
            {
                if (mssql != null && mssql.isConnected())
                {
                    cbPlant.Items.Clear();
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM plant order by plantname;"), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbPlant.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                    cbPlant.Text = DefaultPlant;

                    cbSamiti.Items.Clear();
                    cmd.CommandText = string.Format("SELECT * FROM samiti order by samitiname;");
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbSamiti.Items.Add(reader.GetString(0));
                    }
                    reader.Close();

                    cmd = new SqlCommand(string.Format("SELECT staffno,staffname,gender,plantname,skilllevel,samitiname FROM staff where plantname='{0}' order by staffno;",DefaultPlant), mssql.getConnection());
                    reader = cmd.ExecuteReader();
                    dgvAttendance.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvAttendance.Rows.Add();
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[0].Value = dgvAttendance.Rows.Count;
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[1].Value = reader.GetInt32(0).ToString();
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[2].Value = reader.GetString(1);
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[3].Value = reader.GetString(2);
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[4].Value = reader.GetString(3);
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[5].Value = reader.GetString(4);
                        dgvAttendance.Rows[dgvAttendance.Rows.Count - 1].Cells[6].Value = reader.GetString(5);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@LoadDBValues", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                gbStaffDetails.Enabled = true;
                tbName.Text = "";
                tbStaffNumber.Text = "";
                tbStaffNumber.Focus();
                cbPlant.Text = DefaultPlant;
                panelActions.Enabled = false;
                dgvAttendance.Enabled = false;
                btnState = "ADD";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            windowDefaultState();
            clearBioValues();

        }
        private void windowDefaultState()
        {
            try
            {
                if (btnState == "MODIFY")
                    btnCapture.Enabled = true; //To Re-enable
                else if (btnState == "UPDATE")
                {
                    //To Re-enable
                    tbName.Enabled = true;
                    tbStaffNumber.Enabled = true;
                    cbGender.Enabled = true;
                    cbPlant.Enabled = true;
                    cbSamiti.Enabled = true;
                    cbSkill.Enabled = true;
                }
                gbStaffDetails.Enabled = false;
                panelActions.Enabled = true;
                dgvAttendance.Enabled = true;
                btnAdd.Enabled = true;
                btnModify.Enabled = false;
                btnUpdateFT.Enabled = false;
                btnDelete.Enabled = false;
                clearValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@windowDefaultState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearValues()
        {
            tbName.Text = "";
            tbStaffNumber.Text = "";
            cbPlant.SelectedIndex = -1;
            cbSamiti.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            cbSkill.SelectedIndex = -1;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnState == "UPDATE")
                {
                    //Only Save Updated Fingerprint Templates
                    if (isValidName(tbName.Text.Trim().ToUpper(), tbStaffNumber.Text.Trim()))
                    {
                        if (ANSITemplate1 != null && ANSITemplate1.Length > 0 && ANSITemplate2 != null && ANSITemplate2.Length > 0)
                        {
                            if (mssql != null && mssql.isConnected())
                            {
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = mssql.getConnection();
                                cmd.CommandText = string.Format("Update staff set finger1=@Finger1, finger2=@Finger2 where staffno={0}", tbStaffNumber.Text.Trim().ToUpper());
                                cmd.Parameters.Add("@Finger1", SqlDbType.VarBinary, 512).Value = ANSITemplate1;
                                cmd.Parameters.Add("@Finger2", SqlDbType.VarBinary, 512).Value = ANSITemplate2;
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show(this, "Staff Fingerprint Templates are Successfully Updated", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    windowDefaultState();                                    
                                    clearBioValues();
                                }
                                else
                                {
                                    MessageBox.Show(this, "Failed to update the Fingerprint Templates", "Failed to Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Kindly Capture Two Fingerprints", "Fingerprints are missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Kindly provide the valid Name(letters, Space, & Dot is Allowed) and Staff Number (0-9)", "Invalid Name or Staff Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (tbName.Text.Trim() != "" && tbStaffNumber.Text.Trim() != "" && cbPlant.SelectedIndex != -1 && cbGender.SelectedIndex != -1 && cbSkill.SelectedIndex != -1 && cbSamiti.SelectedIndex != -1)
                {
                    if (isValidName(tbName.Text.Trim().ToUpper(), tbStaffNumber.Text.Trim()))
                    {
                        if (btnState == "ADD")
                        {
                            if (mssql != null && mssql.isConnected())
                            {
                                if (ANSITemplate1 != null && ANSITemplate1.Length > 0 && ANSITemplate2 != null && ANSITemplate2.Length > 0)
                                {
                                    SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno FROM staff where staffno={0};", tbStaffNumber.Text.Trim().ToUpper()), mssql.getConnection());
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    if (!reader.Read())
                                    {
                                        reader.Close();
                                        cmd.CommandText = string.Format("INSERT INTO staff VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,@Finger1,@Finger2)", tbStaffNumber.Text.Trim().ToUpper(), tbName.Text.Trim().ToUpper(), cbPlant.Text.ToUpper(), cbGender.Text.ToUpper(), cbSkill.Text.ToUpper(), cbSamiti.Text.ToUpper(), "ENABLED");
                                        cmd.Parameters.Add("@Finger1", SqlDbType.VarBinary, 512).Value = ANSITemplate1;
                                        cmd.Parameters.Add("@Finger2", SqlDbType.VarBinary, 512).Value = ANSITemplate2;
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show(this, "Successfully Added a new Staff", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            windowDefaultState();
                                            LoadDBValues();
                                            clearBioValues();
                                        }
                                        else
                                        {
                                            MessageBox.Show(this, "Failed to Add a New Staff", "Failed to Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "This Staff Number is already Exists", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    reader.Close();
                                }
                                else
                                {
                                    MessageBox.Show(this, "Kindly Capture Two Fingerprints", "Fingerprints are missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (btnState == "MODIFY")
                        {
                            SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno FROM staff where staffno={0};", dgvAttendance.Rows[selectedRow].Cells[1].Value.ToString()), mssql.getConnection());
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                reader.Close();
                                if (mssql.executeNonQuery(string.Format("UPDATE staff set staffno={0},staffname='{1}',plantname='{2}',gender='{4}',skilllevel='{5}',samitiname='{6}',lastmodifiedon=CURRENT_TIMESTAMP where staffno={3}", tbStaffNumber.Text.Trim().ToUpper(), tbName.Text.Trim().ToUpper(), cbPlant.Text.ToString().ToUpper(), dgvAttendance.Rows[selectedRow].Cells[1].Value.ToString(), cbGender.Text.ToUpper(), cbSkill.Text.ToUpper(), cbSamiti.Text.ToUpper())) == 1)
                                {
                                    MessageBox.Show(this, "Successfully modified the Staff Details", "Successfully Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    windowDefaultState();
                                    LoadDBValues();
                                }
                                else
                                {
                                    MessageBox.Show(this, "Failed to Modify Staff details", "Failed to Modify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "This Staff Number Does not Exists", "Record Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            reader.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Kindly provide the valid Name(letters, Space, & Dot is Allowed) and Staff Number (0-9)", "Invalid Name or Staff Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Some of the required fields are empty", "Required Fields are Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string getStringFromByteArray(byte[] ba)
        {
            string bs = "";
            for (int i = 0; i < ba.Length; i++)
                bs += ba[i].ToString("X2");
            return bs;
        }



        private byte[] getByteArrayFromString(string bs)
        {
            byte[] ba = new byte[512];
            ba.Initialize();
            for (int i = 0; i < bs.Length; i++)
            {
                ba[i] = Convert.ToByte(bs[i]);
            }
            return ba;
        }


        private bool isValidName(string sname, string sno)
        {
            Regex validName = new Regex(@"^[a-zA-Z .]+$", RegexOptions.Multiline);
            Regex validNo = new Regex(@"^[0-9]+$", RegexOptions.Multiline);
            return (validName.IsMatch(sname) && validNo.IsMatch(sno));
        }

        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(dgvAttendance.SelectedRows[0].Index.ToString());
            btnModify.Enabled = true;
            btnUpdateFT.Enabled = true;
            btnDelete.Enabled = true;

            if (dgvAttendance.SelectedRows.Count != 0)
                selectedRow = dgvAttendance.SelectedRows[0].Index;
            else
                selectedRow = -1;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (selectedRow != -1)
            {
                if (MessageBox.Show(this, "Warning: Fingerprints cannot be modified. You can only Modify Staff Details\n(If you want to update fingerprints Click on, Update Fingerprint Templates). Are you sure to proceed?", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gbStaffDetails.Enabled = true;
                    btnCapture.Enabled = false;
                    tbStaffNumber.Text = dgvAttendance.Rows[selectedRow].Cells[1].Value.ToString();
                    tbName.Text = dgvAttendance.Rows[selectedRow].Cells[2].Value.ToString();
                    cbGender.SelectedIndex = cbGender.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[3].Value.ToString());
                    cbPlant.SelectedIndex = cbPlant.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[4].Value.ToString());
                    cbSkill.SelectedIndex = cbSkill.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[5].Value.ToString());
                    cbSamiti.SelectedIndex = cbSamiti.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[6].Value.ToString());
                    panelActions.Enabled = false;
                    dgvAttendance.Enabled = false;
                    btnState = "MODIFY";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRow != -1)
            {
                if (MessageBox.Show(this, "Selected Staff Details are permanently deleted. Are you sure to proceed?", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (mssql.executeNonQuery(string.Format("DELETE FROM staff where staffno='{0}'", dgvAttendance.Rows[selectedRow].Cells[1].Value.ToString())) == 1)
                    {
                        MessageBox.Show(this, "Staff Details are Deleted Successfully", "Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        windowDefaultState();
                        LoadDBValues();
                    }
                    else
                    {
                        MessageBox.Show(this, "Failed to Modify Staff details", "Failed to Modify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MasterRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mfs100.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@FormClosing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateFT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Warning: Staff Details cannot be modified. You can only Update Fingerprint Templates\n(If you want to modify Staff Details Click on, Modify). Are you sure to proceed?", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gbStaffDetails.Enabled = true;

                tbStaffNumber.Enabled = false;
                tbName.Enabled = false;
                cbGender.Enabled = false;
                cbPlant.Enabled = false;
                cbSamiti.Enabled = false;
                cbSkill.Enabled = false;
                tbStaffNumber.Text = dgvAttendance.Rows[selectedRow].Cells[1].Value.ToString();
                tbName.Text = dgvAttendance.Rows[selectedRow].Cells[2].Value.ToString();
                cbGender.SelectedIndex = cbGender.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[3].Value.ToString());
                cbPlant.SelectedIndex = cbPlant.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[4].Value.ToString());
                cbSkill.SelectedIndex = cbSkill.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[5].Value.ToString());
                cbSamiti.SelectedIndex = cbSamiti.Items.IndexOf(dgvAttendance.Rows[selectedRow].Cells[6].Value.ToString());

                panelActions.Enabled = false;
                dgvAttendance.Enabled = false;
                btnState = "UPDATE";
            }
        }



    }
}
