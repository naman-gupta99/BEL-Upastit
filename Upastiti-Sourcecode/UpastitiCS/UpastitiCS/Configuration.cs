using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace UpastitiCS
{
    public partial class Configuration : Form
    {
        private MsSQL mssql = null;
        public string DBHost
        {
            get { return tbHost.Text; }
            set { tbHost.Text = value; }
        }
        public string DBName
        {
            get { return tbDBPort.Text; }
            set { tbDBPort.Text = value; }
        }
        public string DBUserName
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }
        public string DBPassword
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }
        private string MasterPassword = "allowme"; //Default Password
        private string DefaultPlant = "";   //Default Plant
        
        public Configuration()
        {
            InitializeComponent();
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
            {
                readXMLData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
            }
            initDB();
            LoadDBValues();
        }
        private void initDB()
        {
            if (mssql != null)
                mssql = null;   //Think Better Way to Dispose
            mssql = new MsSQL();
            mssql.initMsSQL(DBHost, DBName, DBUserName, DBPassword);
            mssql.connect();
        }
        private void LoadDBValues()
        {
            try
            {
                if (mssql != null && mssql.isConnected())
                {
                    cbPlant.Items.Clear();
                    cbSelectPlant.Items.Clear();
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM plant order by plantname;"), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbPlant.Items.Add(reader.GetString(0));
                        cbSelectPlant.Items.Add(reader.GetString(0));
                    }
                    reader.Close();

                    if (DefaultPlant != "")
                    {
                        //Select Default Plant
                        cbSelectPlant.Text = DefaultPlant;
                    }


                    cbSamiti.Items.Clear();
                    cmd.CommandText = string.Format("SELECT * FROM samiti order by samitiname;");
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbSamiti.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Conf_LoadDBValues):" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbPlant.Text != null && cbPlant.Text.Trim() != "")
                {
                    if (mssql != null && mssql.isConnected())
                    {
                        SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM plant where plantname='{0}';", cbPlant.Text.ToString().Trim().ToUpper()), mssql.getConnection());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            if (mssql.executeNonQuery(string.Format("INSERT INTO plant VALUES('{0}','{1}')", cbPlant.Text.ToString().Trim().ToUpper(),tbPlantTitle.Text.Trim().ToUpper())) == 1)
                            {
                                MessageBox.Show(this, "Successfully Added a new Plant", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbPlant.Text = "";
                                LoadDBValues();
                            }
                            else
                            {
                                MessageBox.Show(this, "Failed to Add a New Item", "Failed to Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "This Plant is already Exists", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this,"Empty Plant Name...!!\nKindly Provide a non-empty plant name to be added...", "Empty Plant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Conf_btnAdd_Click):" + ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
              
                    if (cbPlant.Text != null && cbPlant.Text.Trim() != "")
                    {
                        if (MessageBox.Show(this, "You're about to remove a Plant, Are you Sure to Continue?", "Are you Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                        if (mssql != null && mssql.isConnected())
                        {
                            if (mssql.executeNonQuery(string.Format("DELETE FROM plant where plantname='{0}'", cbPlant.Text.ToString().Trim().ToUpper())) == 1)
                            {
                                MessageBox.Show(this, "Plant removed Successfully", "Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbPlant.Text = "";
                                LoadDBValues();
                            }
                            else
                            {
                                MessageBox.Show(this, "Plant Not Found\nFailed to remove the plant", "Failed to Remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        
                        else
                        {
                            MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Empty Plant Name...!!\nKindly Provide a non-empty plant name to be removed...", "Empty Plant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Conf_btnRemove_Click):" + ex.Message);
            }
        }
        // ************************** XML Operations ************************** //
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
                    xmlWriter.WriteElementString("host", tbHost.Text);
                    xmlWriter.WriteElementString("dbname", tbDBPort.Text);
                    xmlWriter.WriteElementString("username", tbUserName.Text);
                    xmlWriter.WriteElementString("password", tbPassword.Text);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("master");
                    xmlWriter.WriteElementString("password", MasterPassword);
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
                Logger.log("Exception(Conf_writeData):" + ex.Message);
            }
            return false;
        }

        public bool readXMLData(string xmlFile)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                string thost, tport, tusername, tpassword,tmasterpass,tdefaultplant;
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
                        tbHost.Text = thost;

                    tport = reader.ReadElementString("dbname");
                    if (tport != "")
                        tbDBPort.Text = tport;

                    tusername = reader.ReadElementString("username");
                    if (tusername != "")
                        tbUserName.Text = tusername;

                    tpassword = reader.ReadElementString("password");
                    if (tpassword != "")
                        tbPassword.Text = tpassword;

                    reader.ReadEndElement();


                    reader.ReadStartElement("master");
                    tmasterpass  = reader.ReadElementString("password");
                    if (tmasterpass != "")
                    {
                        tbMasterPass.Text = tmasterpass;
                        MasterPassword = tmasterpass;
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
                Logger.log("Exception(Conf_readXMLData):" + e.Message);
            }
            return false;
        }

        private void btnApply_Click(object sender, EventArgs e)
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
                MessageBox.Show(this, "Database Parameters are saved successfully.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Conf_btnApply_Click):" + ex.Message);
            }
        }

        private void btnSamitiAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbSamiti.Text != null && cbSamiti.Text.Trim() != "")
                {
                    if (mssql != null && mssql.isConnected())
                    {
                        SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM samiti where samitiname='{0}';", cbSamiti.Text.ToString().Trim().ToUpper()), mssql.getConnection());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            if (mssql.executeNonQuery(string.Format("INSERT INTO samiti VALUES('{0}','{1}')", cbSamiti.Text.ToString().Trim().ToUpper(),tbSamitiTitle.Text.Trim().ToUpper())) == 1)
                            {
                                MessageBox.Show(this, "Successfully Added a new Samiti", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbSamiti.Text = "";
                                LoadDBValues();
                            }
                            else
                            {
                                MessageBox.Show(this, "Failed to Add a New Item", "Failed to Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "This Samiti is already Exists", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Empty Samiti Name...!!\nKindly Provide a non-empty samiti name to be added...", "Empty Samiti", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(btnSamitiAdd_Click):" + ex.Message);
            }
        }

        private void btnSamitiRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSamiti.Text != null && cbSamiti.Text.Trim() != "")
                {
                    if (MessageBox.Show(this, "You're about to remove a Samiti, Are you Sure to Continue?", "Are you Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (mssql != null && mssql.isConnected())
                        {
                            if (mssql.executeNonQuery(string.Format("DELETE FROM samiti where samitiname='{0}'", cbSamiti.Text.ToString().Trim().ToUpper())) == 1)
                            {
                                MessageBox.Show(this, "Samiti removed Successfully", "Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbSamiti.Text = "";
                                LoadDBValues();
                            }
                            else
                            {
                                MessageBox.Show(this, "Samiti Not Found\nFailed to remove the Samiti", "Failed to Remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Unable to reach Database Server. Ensure Network Connectivity and Double-check Database Parameters under Settings.", "Unable to Connect Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Empty Samiti Name...!!\nKindly Provide a non-empty samiti name to be removed...", "Empty Samiti", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(btnSamitiRemove_Click):" + ex.Message);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (tbMasterPass.Text.Trim() == "")
            {
                MessageBox.Show(this, "Empty Password...!!\nKindly Provide a non-empty Password...", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Auth
            Auth auth = new Auth();
            DialogResult adr = auth.ShowDialog(this);
            if (adr == DialogResult.OK)
            {
                MasterPassword = tbMasterPass.Text.Trim();
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                {
                    using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                    {
                        //Nothing to Be Done... Just Creates the File 
                    }
                }
                writeData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
                MessageBox.Show(this, "Master Password is updated Successfully", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            auth.Dispose();
        }
        
        /// <summary>
        ///  When Edit is Completed Update Plant title to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tbPlantTitle_Leave(object sender, EventArgs e)
        {
            //Confirm Plant & its Title is Not Empty
            if (cbPlant.SelectedIndex!=-1 && tbPlantTitle.Text.Trim() != "")
            {
                if (mssql != null && mssql.isConnected())
                {
                    mssql.executeNonQuery(string.Format("UPDATE plant SET title='{0}' where plantname='{1}'", tbPlantTitle.Text.Trim().ToUpper(), cbPlant.Text.ToString().Trim().ToUpper()));
                }
            }
        }
        /// <summary>
        /// Update Samiti title to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSamitiTitle_Leave(object sender, EventArgs e)
        {
            //Confirm Samiti & its Title is Not Empty
            if (cbSamiti.SelectedIndex != -1 && tbSamitiTitle.Text.Trim() != "")
            {
                if (mssql != null && mssql.isConnected())
                {
                    mssql.executeNonQuery(string.Format("UPDATE samiti SET title='{0}' where samitiname='{1}'", tbSamitiTitle.Text.Trim().ToUpper(), cbSamiti.Text.ToString().Trim().ToUpper()));
                }
            }
        }
        /// <summary>
        /// Show Plant Title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbPlant.SelectedIndex != -1)
            {
                if (mssql != null && mssql.isConnected())
                {
                    string check = string.Format("SELECT title FROM plant where plantname='{0}';", cbPlant.Text.ToString().Trim().ToUpper());
                    SqlCommand cmd = new SqlCommand(check, mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            tbPlantTitle.Text = reader.GetString(0);
                        else
                            tbPlantTitle.Text = "";
                    }
                    reader.Close();
                }
            }
        }
        /// <summary>
        /// Show Samiti Title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSamiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSamiti.SelectedIndex != -1)
            {
                if (mssql != null && mssql.isConnected())
                {
                    string check = string.Format("SELECT title FROM samiti where samitiname='{0}';", cbSamiti.Text.ToString().Trim().ToUpper());
                    SqlCommand cmd = new SqlCommand(check, mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            tbSamitiTitle.Text = reader.GetString(0);
                        else
                            tbSamitiTitle.Text = "";
                    }
                    reader.Close();
                }
            }
        }

        private void btnUpdatePlant_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectPlant.SelectedIndex != -1)
                {
                    DefaultPlant = cbSelectPlant.Text;
                }
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                {
                    using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                    {
                        //Nothing to Be Done... Just Creates the File
                    }
                }
                writeData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
                MessageBox.Show(this, "Default Plant is Set successfully.", "Plant Set Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Conf_btnUpdatePlant_Click):" + ex.Message);
            }
        }

       


     
       

     
       

       

        



        //Master Password Encrypt With MD5

        //private string getMd5Hash(string input)
        //{
        //    // Create a new instance of the MD5CryptoServiceProvider object.
        //    System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

        //    // Convert the input string to a byte array and compute the hash.
        //    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

        //    // Create a new Stringbuilder to collect the bytes
        //    // and create a string.
        //    StringBuilder sBuilder = new StringBuilder();

        //    // Loop through each byte of the hashed data 
        //    // and format each one as a hexadecimal string.
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }

        //    // Return the hexadecimal string.
        //    return sBuilder.ToString();
        //}

        //// Verify a hash against a string.
        //private bool verifyMd5Hash(string input, string hash)
        //{
        //    // Hash the input.
        //    string hashOfInput = getMd5Hash(input);

        //    // Create a StringComparer an comare the hashes.
        //    StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        //    if (0 == comparer.Compare(hashOfInput, hash))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


       
        // ////////////////////////////////////////////////////////////////////

    }
}
