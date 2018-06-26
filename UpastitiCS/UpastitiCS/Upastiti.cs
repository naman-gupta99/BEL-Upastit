using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MANTRA;
using System.IO;


namespace UpastitiCS
{
    public partial class Upastiti : Form
    {
        private MsSQL mssql = null;
        private Thread attendanceThread;
        //Timer Count to Stop Device after 10 Minutes of Idle Time
        private int minTimeCount = 0;

        //Related to Biometric Module
        private MFS100 mfs100 = null;
        private int quality = 70;   //Allowed Value Range 1 to 1000
        private int timeout = -1; // -1 for Infinite, Only a successful finger capture or StopCapture Can stop.
        //private byte[] ANSITemplate1 = null;
        //private byte[] ANSITemplate2 = null;
        private byte[] ANSIAttendance = null;
        private int matchThreshold = 14000;
        private ManualResetEvent readyForNext = new ManualResetEvent(false);
        private bool exitThread = false;
        private Regex regShift = new Regex(@"([\w]+)-([\w]+)");

        //Database Parameters
        private string DBHost = @"TESTINGMMF\SQLEXPRESS";
        private string DBName = "";
        private string DBUName = "sa";
        private string DBPassword = "";
        private string MasterPass = "allowme"; //Default Pass
        private string DefaultPlant = ""; //Default Plant

        //Don't ask again
        private bool sessionAuthenticated = false;

        public Upastiti()
        {
            System.Diagnostics.Process[] processNames = System.Diagnostics.Process.GetProcessesByName("Upastiti");
            if (processNames.Length > 1)
            {
                MessageBox.Show(this, "You're trying to run multiple instances.\nKindly close the already running Upastiti from Task Manager", "Multiple Instances!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                Application.ExitThread();
                processNames[0].Kill();
            }
            Logger.open();
            InitializeComponent();
            initialiseDatabase();
            if (isDefaultPlantSet())
            {
                updateStaffCount();
                loadDGVAttendance();
            }
            else
            {
                MessageBox.Show(this, "Default Plant Not Set! Kindly Set the Default Plant in Settings.", "Default Plant!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            initialiseMFS100();
            
        }
        private void updateStaffCount()
        {
             try
            {
                if (mssql != null && mssql.isConnected())
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT m.shiftcode, Count(m.shiftcode) FROM movement as m, staff as s where m.staffno=s.staffno and s.plantname='{0}' and CAST(m.moveon as date)=CAST(CURRENT_TIMESTAMP as date) GROUP BY shiftcode;",DefaultPlant), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    lbl1stShiftCount.Text="1stShift: 0";
                    lbl2ndShiftCount.Text = "2ndShift: 0";
                    lbl3rdShiftCount.Text = "3rdShift: 0";
                    lblGSCount.Text = "GS: 0";
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "1stShift-IN")
                            lbl1stShiftCount.Text = "1stShift: " + reader.GetInt32(1).ToString();
                        else if (reader.GetString(0) == "2ndShift-IN")
                            lbl2ndShiftCount.Text = "2ndShift: " + reader.GetInt32(1).ToString();
                        else if (reader.GetString(0) == "3rdShift-IN")
                            lbl3rdShiftCount.Text = "3rdShift: " + reader.GetInt32(1).ToString();
                        else if (reader.GetString(0) == "GS-IN")
                            lblGSCount.Text = "GS: " + reader.GetInt32(1).ToString();
                    }
                    reader.Close();
                    lbl1stShiftCount.Refresh();
                    lbl2ndShiftCount.Refresh();
                    lbl3rdShiftCount.Refresh();
                    lblGSCount.Refresh();
                }
            }
             catch (Exception ex)
             {
                 MessageBox.Show(this, ex.Message, "Exception@updateStaffCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 Logger.log("Exception(updateStaffCount):" + ex.Message);
             }
        }
        private void callConf()
        {
            Configuration conf = new Configuration();
            conf.ShowDialog();
            initialiseDatabase();     //To read changes in database parameters, if any.
            this.BringToFront();
            conf.Dispose();
        }
        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sessionAuthenticated)
                {
                    Auth auth = new Auth();
                    DialogResult adr = auth.ShowDialog(this);
                    if (adr == DialogResult.OK)
                    {
                        sessionAuthenticated = auth.getSessionValue();
                        callConf();
                    }
                    auth.Dispose();
                }
                else
                {
                    callConf();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnConfiguration_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(btnConfiguration_Click):" + ex.Message);
            }
        }

        // ************************************** XML Operations ******************************* //
        private void readSettings()
        {
            try
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                {
                    readXMLData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
                }
                else
                {
                    writeSettings();
                }

                //Find right place for following code
                if (DefaultPlant != "" && DefaultPlant!=lblPlant.Text.Substring(0,lblPlant.Text.Length-2))
                {
                    lblPlant.Text = DefaultPlant + ": ";
                    updateStaffCount();
                    loadDGVAttendance();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(readSettings):" + ex.Message);
            }
        }

        private void writeSettings()
        {
            try
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                {
                    using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                    {
                        //Nothing to Be Done... Just Creates the File
                    }
                }
                writeData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
            }
            catch (Exception ex)
            {
                Logger.log("Exception(writeSettings):" + ex.Message);
            }
        }
        public bool readXMLData(string xmlFile)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                string thost, tport, tusername, tpassword, tmasterpass, tdefaultplant;
                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;
                using (XmlReader reader = XmlReader.Create(xmlFile, settings))
                {

                    // Parse the XML document.  ReadString is used to 
                    // read the text content of the elements.
                    reader.MoveToContent();
                    reader.ReadStartElement("upastiti");

                    reader.ReadStartElement("database");
                    thost = reader.ReadElementString("host");
                    if (thost != "")
                        DBHost = thost;

                    tport = reader.ReadElementString("dbname");
                    if (tport != "")
                        DBName = tport;

                    tusername = reader.ReadElementString("username");
                    if (tusername != "")
                        DBUName = tusername;

                    tpassword = reader.ReadElementString("password");
                    if (tpassword != "")
                        DBPassword = tpassword;

                    reader.ReadEndElement();


                    reader.ReadStartElement("master");
                    tmasterpass = reader.ReadElementString("password");
                    if (tmasterpass != "")
                    {
                        MasterPass = tmasterpass;
                    }
                    tdefaultplant = reader.ReadElementString("plant");
                    if (tdefaultplant != "")
                    {
                        DefaultPlant = tdefaultplant;
                    }
                    reader.ReadEndElement();

                    reader.ReadEndElement();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(readXMLData):" + e.Message);
            }
            return false;
        }
        public bool writeData(string xmlFile)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(xmlFile, settings))
                {
                    xmlWriter.WriteStartDocument();

                    xmlWriter.WriteStartElement("upastiti");

                    xmlWriter.WriteStartElement("database");
                    xmlWriter.WriteElementString("host", DBHost);
                    xmlWriter.WriteElementString("dbname", DBName);
                    xmlWriter.WriteElementString("username", DBUName);
                    xmlWriter.WriteElementString("password", DBPassword);
                    xmlWriter.WriteEndElement();


                    xmlWriter.WriteStartElement("master");
                    xmlWriter.WriteElementString("password", MasterPass);
                    xmlWriter.WriteElementString("plant", DefaultPlant);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndDocument();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(writeData):" + ex.Message);
            }
            return false;
        }
        // //////////////////////////////////////////////////////////////////////////////// //

        //***************************** MsSQL Database Modules ************************************************//

        private void initialiseDatabase()
        {
            try
            {
                readSettings();
                if (mssql != null)
                    mssql = null;   //TODO: Think How to Dispose
                mssql = new MsSQL();
                mssql.initMsSQL(DBHost, DBName, DBUName, DBPassword);
                mssql.connect();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@initDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(initialiseDatabase):" + e.Message);
            }
        }
        private string getStringFromByteArray(byte[] ba)
        {
            string bs = "";
            for (int i = 0; i < ba.Length; i++)
                bs += ba[i].ToString("X2");
            return bs;

        }
        byte[] GetBytes(SqlDataReader reader, int fi)
        {

            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead = 0;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    while ((bytesRead = reader.GetBytes(fi, fieldOffset, buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, (int)bytesRead);
                        fieldOffset += bytesRead;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message, "Exception@GetBytes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.log("Exception(GetBytes):" + e.Message);
                }
                return stream.ToArray();

            }

        }
        private byte[] getByteArrayFromString(string bs)
        {
            byte[] ba = new byte[512];
            ba.Initialize();
            for (int i = 0; i + 1 < bs.Length; i = i + 2)
            {
                ba[i] = Convert.ToByte(bs[i].ToString() + bs[i + 1].ToString());
            }
            return ba;
        }

        private void putAttendance()
        {
            bool matchFound = false;
            int score = 0;
            string staffno = "0";
            try
            {
                if (mssql != null && mssql.isConnected())
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,finger1,finger2 FROM staff where plantname='{0}';",DefaultPlant), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] finger1 = GetBytes(reader, 1);
                        mfs100.MatchANSI(finger1, ANSIAttendance, ref score);
                        if (score >= matchThreshold)
                        {
                            matchFound = true;
                            staffno = reader.GetInt32(0).ToString();
                            break;
                        }
                        else
                        {
                            byte[] finger2 = GetBytes(reader, 2);
                            mfs100.MatchANSI(finger2, ANSIAttendance, ref score);
                            if (score >= matchThreshold)
                            {
                                matchFound = true;
                                staffno = reader.GetInt32(0).ToString();
                                break;
                            }
                        }
                    }
                    reader.Close();
                    if (matchFound)
                    {
                        if (isDuplicateRecord(staffno))
                        {
                            lblStaffNo.Text = "Duplicate Record";
                            lblStaffName.Text = "Record Already Exists";
                            lblStaffNo.Refresh();
                            lblStaffName.Refresh();
                        }
                        else if (regShift.Match(cbShiftCode.Text.Trim()).Groups[2].Value == "OUT" && !isInPunchExists(staffno))
                        {
                            lblStaffNo.Text = "IN Punch Doesn't Exist";
                            lblStaffName.Text = "Trying OUT Punch without IN";
                            lblStaffNo.Refresh();
                            lblStaffName.Refresh();
                        }
                        else if (!saveDetailsToDatabase(staffno))
                        {
                            lblStaffNo.Text = "Please Try Once Again";
                            lblStaffName.Text = "Failed while saving to database";
                            lblStaffNo.Refresh();
                            lblStaffName.Refresh();
                        }
                        else
                        {
                            //Update DataGrid
                            new Thread(() =>
                            {
                                //Update Count
                                updateStaffCount();
                                updateDGVAttendance();
                            }).Start();

                           
                        }
                    }
                    else
                    {
                        lblStaffNo.Text = "Please Try Once Again";
                        lblStaffName.Text = "Finger Did Not Match";
                        lblStaffNo.Refresh();
                        lblStaffName.Refresh();
                    }

                }
                else
                {
                    MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnStop_Click(null, null);
                }
                //Get Ready For Next Finger Capture
                Thread.Sleep(1000);  //TODO Think
                readyForNext.Set();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@putAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(putAttendance):" + e.Message);
            }
        }
         private void loadDGVAttendance()
        {
            //dgvAttendance.Rows.Clear();
            //SQLiteCommand cmd = new SQLiteCommand(string.Format("SELECT m.staffno,s.staffname,s.plantname,time(m.moveon,'localtime') from movement as m,staff as s where m.staffno=s.staffno and m.moveon BETWEEN CURRENT_TIMESTAMP and datetime(CURRENT_TIMESTAMP,'-24 hour');"), sqlite.getConnection());
            //SQLiteDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //
            //}
            try
            {
                if (mssql != null && mssql.isConnected())
                {
                    dgvAttendance.Rows.Clear();
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT m.staffno,s.staffname,s.fathername,s.samitiname,s.contractorname,m.moveon,m.shiftcode from movement as m,staff as s where m.staffno=s.staffno AND s.plantname='{0}' AND CAST(m.moveon as DATE)=CAST(CURRENT_TIMESTAMP as DATE) order by m.moveon ;", DefaultPlant), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvAttendance.Rows.Insert(0, 1);
                        dgvAttendance.Rows[0].Cells[0].Value = reader.GetString(0); //staffno
                        dgvAttendance.Rows[0].Cells[1].Value = reader.GetString(1); //staffname
                        dgvAttendance.Rows[0].Cells[2].Value = reader.GetString(2); //fathername
                        dgvAttendance.Rows[0].Cells[3].Value = reader.GetString(3); //samitiname
                        dgvAttendance.Rows[0].Cells[4].Value = reader.GetString(4); //contractorname
                        dgvAttendance.Rows[0].Cells[5].Value = reader.GetDateTime(5).ToString("dd-MM-yyyy hh:mm:ss"); //moveon
                        dgvAttendance.Rows[0].Cells[6].Value = reader.GetString(6); //shiftcode

                        if (regShift.Match(reader.GetString(6)).Groups[2].Value == "IN")
                        {
                            dgvAttendance.Rows[0].Cells[6].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            dgvAttendance.Rows[0].Cells[6].Style.ForeColor = Color.Red;
                        }
                        dgvAttendance.Refresh();
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@loadDGVAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(loadDGVAttendance):" + e.Message);
            }

        }

        private void updateDGVAttendance()
        {
            //dgvAttendance.Rows.Clear();
            //SQLiteCommand cmd = new SQLiteCommand(string.Format("SELECT m.staffno,s.staffname,s.plantname,time(m.moveon,'localtime') from movement as m,staff as s where m.staffno=s.staffno and m.moveon BETWEEN CURRENT_TIMESTAMP and datetime(CURRENT_TIMESTAMP,'-24 hour');"), sqlite.getConnection());
            //SQLiteDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //
            //}
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 1 m.staffno,s.staffname,s.fathername,s.samitiname,s.contractorname,m.moveon,m.shiftcode from movement as m,staff as s where m.staffno=s.staffno AND s.plantname='{0}' AND CAST(m.moveon as DATE)=CAST(CURRENT_TIMESTAMP as DATE) order by m.moveon desc;", DefaultPlant), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dgvAttendance.Rows.Insert(0, 1);
                    dgvAttendance.Rows[0].Cells[0].Value = reader.GetString(0); //staffno
                    dgvAttendance.Rows[0].Cells[1].Value = reader.GetString(1); //staffname
                    dgvAttendance.Rows[0].Cells[2].Value = reader.GetString(2); //fathername
                    dgvAttendance.Rows[0].Cells[3].Value = reader.GetString(3); //samitiname
                    dgvAttendance.Rows[0].Cells[4].Value = reader.GetString(4); //contractorname
                    dgvAttendance.Rows[0].Cells[5].Value = reader.GetDateTime(5).ToString("dd-MM-yyyy hh:mm:ss"); //moveon
                    dgvAttendance.Rows[0].Cells[6].Value = reader.GetString(6); //shiftcode

                    if (regShift.Match(reader.GetString(6)).Groups[2].Value == "IN")
                    {
                        dgvAttendance.Rows[0].Cells[6].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dgvAttendance.Rows[0].Cells[6].Style.ForeColor = Color.Red;
                    }

                    lblStaffNo.Text = reader.GetString(0);
                    lblStaffName.Text = reader.GetString(1);
                    lblStaffNo.Refresh();
                    lblStaffName.Refresh();
                    dgvAttendance.Refresh();
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@updateDGVAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(updateDGVAttendance):" + e.Message);
            }

        }
        private bool isDuplicateRecord(string staffno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT * from movement where staffno={0} and shiftcode='{1}' and CAST(moveon as DATE)=CAST(CURRENT_TIMESTAMP as DATE);", staffno, getDBShiftCode(lblShiftSelected.Text)), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@isDuplicateRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(isDuplicateRecord):" + e.Message);
            }
            return false;
        }
        private bool isInPunchExists(string staffno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 1 shiftcode from movement where staffno={0} order by moveon desc;", staffno, getDBShiftCode(lblShiftSelected.Text)), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string sc = reader.GetString(0);
                    if (regShift.Match(sc).Groups[1].Value == regShift.Match(cbShiftCode.Text.Trim()).Groups[1].Value && regShift.Match(sc).Groups[2].Value == "IN")
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@isInPunchExists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(isInPunchExists):" + e.Message);
            }
            return false;
        }

        private bool saveDetailsToDatabase(string staffno)
        {
            try
            {
                if (mssql.executeNonQuery(string.Format("INSERT INTO movement VALUES({0},CURRENT_TIMESTAMP,'{1}')", staffno, getDBShiftCode(lblShiftSelected.Text))) != 1)
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@saveDetailsToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(saveDetailsToDatabase):" + e.Message);
            }
            //To avoid NIGHT Shift Double attendance 00-05 Hours Not Considered for
            //SQLiteCommand cmd = new SQLiteCommand(string.Format("SELECT * from attendance where staffno='{0}' and attendeddate=CURRENT_DATE;",staffno), sqlite.getConnection());
            //SQLiteDataReader reader = cmd.ExecuteReader();

            //cmd = new SQLiteCommand(string.Format("SELECT * from attendance where staffno='{0}' and attendeddate=CURRENT_DATE;", staffno), sqlite.getConnection());
            //reader = cmd.ExecuteReader();
            //if (!reader.Read())
            //{
            //    if (sqlite.executeNonQuery(string.Format("INSERT INTO attendance VALUES('{0}',CURRENT_DATE)", staffno)) != 1)
            //        return false;
            //}
            return true;
        }

        //TO Isolate, if Any Modifications made in Future to Front-end GUI Labels
        private string getDBShiftCode(string labelShiftCode)
        {
            switch (labelShiftCode)
            {
                case "1stShift-IN": return "1stShift-IN";
                case "1stShift-OUT": return "1stShift-OUT";
                case "2ndShift-IN": return "2ndShift-IN";
                case "2ndShift-OUT": return "2ndShift-OUT";
                case "3rdShift-IN": return "3rdShift-IN";
                case "3rdShift-OUT": return "3rdShift-OUT";
                case "GS-IN": return "GS-IN";
                case "GS-OUT": return "GS-OUT";
            }
            return labelShiftCode;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void callMasterRecord()
        {
            MasterRecord mr = new MasterRecord();
            mr.initialiseDatabase(DBHost, DBName, DBUName, DBPassword, DefaultPlant);
            mr.ShowDialog();
            this.BringToFront();
            mr.Dispose();
        }
        private void btnMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDefaultPlantSet())
                {
                    if (!sessionAuthenticated)
                    {
                        Auth auth = new Auth();
                        DialogResult adr = auth.ShowDialog(this);
                        if (adr == DialogResult.OK)
                        {
                            sessionAuthenticated = auth.getSessionValue();
                            callMasterRecord();
                        }
                        auth.Dispose();
                    }
                    else
                    {
                        callMasterRecord();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Default Plant Not Set! Kindly Set the Default Plant in Settings.", "Default Plant!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnMaster_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(btnMaster_Click):" + ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isDefaultPlantSet())
            {
                if (cbShiftCode.Text == null || cbShiftCode.Text == "")
                {
                    MessageBox.Show(this, "Kindly Select the Shift-Code", "Shift-Code?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Compare Server time and Shift-Selected
                if (!isValidShiftTime(cbShiftCode.Text.Trim()))
                {
                    MessageBox.Show(this, string.Format("This Shift-Code is not allowed for this time period.\nFor {0} Valid Time is: {1}", cbShiftCode.Text, getValidShiftTime(cbShiftCode.Text)), "Shift-Code in Wrong-Time?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show(this, string.Format("Selected Shift-Code is {0}.\n Are you sure to proceed?", cbShiftCode.Text), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnMaster.Enabled = false;
                btnHistory.Enabled = false;
                btnConfiguration.Enabled = false;
                cbShiftCode.Enabled = false;
                //Start Timer
                minTimer.Start();
                exitThread = false;
                attendanceThread = new Thread(new ThreadStart(captureFinger));
                attendanceThread.Start();
            }
            else
            {
                MessageBox.Show(this, "Default Plant Not Set! Kindly Set the Default Plant in Settings.", "Default Plant!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private string getValidShiftTime(string sc)
        {
            switch (sc)
            {
                case "1stShift-IN": return "6AM to 7:59AM";
                case "2ndShift-IN": return "1PM to 2:59PM";
                case "3rdShift-IN": return "9PM to 10:59PM";
                case "GS-IN": return "7AM to 8:59AM";
                default: return "";
            }

        }
        private bool isValidShiftTime(string sc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT CURRENT_TIMESTAMP"), mssql.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DateTime dt = reader.GetDateTime(0);
                    reader.Close();
                    switch (sc)
                    {
                        case "1stShift-IN": if (dt.Hour >= 6 && dt.Hour < 8)
                                return true;
                            else
                                return false;
                        case "2ndShift-IN": if (dt.Hour >= 13 && dt.Hour < 15)
                                return true;
                            else
                                return false;
                        case "3rdShift-IN": if (dt.Hour >= 21 && dt.Hour < 23)
                                return true;
                            else
                                return false;

                        case "GS-IN": if (dt.Hour >= 7 && dt.Hour < 9)
                                return true;
                            else
                                return false;
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@isValidShiftTime", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(isValidShiftTime):" + e.Message);
            }

            return true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(1000);     //Think for a Guaranteed Stop
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnMaster.Enabled = true;
                btnHistory.Enabled = true;
                btnConfiguration.Enabled = true;
                cbShiftCode.Enabled = true;
                lblStaffName.Text = "";
                lblStaffNo.Text = "";
                pbFinger.Image = null;
                //Stop Timer
                minTimer.Stop();
                int ret = mfs100.StopCapture();
                exitThread = true;
                readyForNext.Set();     //if Thread Struck at Reading

                //showMessage(mfs100.GetErrorMsg(ret), false);
            }
            catch (Exception ex)
            {
                showMessage(ex.Message, true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void captureFinger()
        {
            while (!exitThread)
            {
                readyForNext.Reset();
                //Reset Timer
                minTimeCount = 0;
                int ret = mfs100.StartCapture(quality, timeout, false);
                if (ret != 0)
                {
                    showMessage(mfs100.GetErrorMsg(ret), true);
                }
                readyForNext.WaitOne();
            }

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        //*********************************************  Biometric Section  ********************************************//
        private void initialiseMFS100()
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                mfs100 = new MFS100();
                //mfs100.OnPreview += onPreview;
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


        private void onCaptureCompleted(bool statusl, int errorCode, string errorMsg, FingerData fingerData)
        {
            try
            {
                if (statusl)
                {
                    ANSIAttendance = new byte[fingerData.ANSITemplate.Length];
                    fingerData.ANSITemplate.CopyTo(ANSIAttendance, 0);
                    pbFinger.Image = fingerData.FingerImage;
                    putAttendance();
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

        private void Upastiti_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Exit Thread
                readyForNext.Set();
                exitThread = true;
                mssql.close();

                if (mfs100 != null)
                    mfs100.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@FormClosing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void callReports()
        {
            Reports reports = new Reports();
            reports.initialiseDatabase(DBHost, DBName, DBUName, DBPassword, DefaultPlant);
            reports.ShowDialog();
            this.BringToFront();
            reports.Dispose();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDefaultPlantSet())
                {
                    if (!sessionAuthenticated)
                    {
                        Auth auth = new Auth();
                        DialogResult adr = auth.ShowDialog(this);
                        if (adr == DialogResult.OK)
                        {
                            sessionAuthenticated = auth.getSessionValue();
                            callReports();
                        }
                        auth.Dispose();
                    }
                    else
                    {
                        callReports();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Default Plant Not Set! Kindly Set the Default Plant in Settings.", "Default Plant!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@btnHistory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(btnHistory_Click):" + ex.Message);
            }
        }

        private void cbShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblShiftSelected.Text = cbShiftCode.Text;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void staffEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMaster_Click(sender, e);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnConfiguration_Click(sender, e);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(sender, e);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
            this.BringToFront();
            about.Dispose();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHistory_Click(sender, e);
        }
        //private void callDiscrepancy()
        //{
        //    FirstOptions options = new FirstOptions();
        //    //reports.initialiseDatabase(DBHost, DBName, DBUName, DBPassword);
        //    options.ShowDialog();
        //    this.BringToFront();
        //    options.Dispose();
        //}
        private void discrepancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!sessionAuthenticated)
            //    {
            //        Auth auth = new Auth();
            //        DialogResult adr = auth.ShowDialog(this);
            //        if (adr == DialogResult.OK)
            //        {
            //            sessionAuthenticated = auth.getSessionValue();
            //            callDiscrepancy();
            //        }
            //        auth.Dispose();
            //    }
            //    else
            //    {
            //        callDiscrepancy();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Exception@discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Logger.log("Exception(discrepancy):" + ex.Message);
            //}
        }

        private bool isDefaultPlantSet()
        {
            if (DefaultPlant != "")
                return true;
            else
                return false;
        }
        private void callMissIN()
        {
            MissIN missin = new MissIN();
            missin.initialiseDatabase(DBHost, DBName, DBUName, DBPassword, DefaultPlant);
            missin.ShowDialog();
            this.BringToFront();
            missin.Dispose();
        }
        private void iNPunchMissingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDefaultPlantSet())
                {
                    if (!sessionAuthenticated)
                    {
                        Auth auth = new Auth();
                        DialogResult adr = auth.ShowDialog(this);
                        if (adr == DialogResult.OK)
                        {
                            sessionAuthenticated = auth.getSessionValue();
                            callMissIN();
                        }
                        auth.Dispose();
                    }
                    else
                    {
                        callMissIN();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Default Plant Not Set! Kindly Set the Default Plant in Settings.", "Default Plant!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@callMissIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(callMissIN):" + ex.Message);
            }
        }

        private void callMissOUT()
        {
            MissOUT missout = new MissOUT();
            missout.initialiseDatabase(DBHost, DBName, DBUName, DBPassword, DefaultPlant);
            missout.ShowDialog();
            this.BringToFront();
            missout.Dispose();
        }

        private void oUTPunchMissingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDefaultPlantSet())
                {
                    if (!sessionAuthenticated)
                    {
                        Auth auth = new Auth();
                        DialogResult adr = auth.ShowDialog(this);
                        if (adr == DialogResult.OK)
                        {
                            sessionAuthenticated = auth.getSessionValue();
                            callMissOUT();
                        }
                        auth.Dispose();
                    }
                    else
                    {
                        callMissOUT();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@callMissOUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(callMissOUT):" + ex.Message);
            }
        }

        private void btnStart_EnabledChanged(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = btnStart.Enabled;
        }

        private void btnStop_EnabledChanged(object sender, EventArgs e)
        {
            stopToolStripMenuItem.Enabled = btnStop.Enabled;
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("UserManual.pdf");
        }

        private void minTimer_Tick(object sender, EventArgs e)
        {
            minTimeCount++;
            if (minTimeCount >= 10)
            {
                btnStop_Click(sender, e);
            }
        }

        private void lblShiftSelected_Click(object sender, EventArgs e)
        {

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
