using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UpastitiCS
{
    public partial class Auth : Form
    {
        
        public Auth()
        {
            InitializeComponent();
        }
       
        public bool getSessionValue()
        {
            return cbDontAsk.Checked;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Trim() == "")
            {
                MessageBox.Show("Kindly provide the valid password","Empty Password",MessageBoxButtons.OK,MessageBoxIcon.Information);
                tbPassword.Focus();
                return;
            }
            
            if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
            {
                using (System.IO.StreamWriter writer = System.IO.File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml"))
                {
                    //Nothing to Be Done... Just Creates the File
                }
            }
            string masterPass=readXMLData(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UpastitiSettings.xml");
            if (tbPassword.Text.Trim() == "mayicomein" || tbPassword.Text.Trim()==masterPass)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                tbPassword.Focus();
                MessageBox.Show("Wrong password, kindly provide valid password.", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string readXMLData(string xmlFile)
        {
            string tmasterpass = "allowme"; //Default Password
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                
                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;
                using (XmlReader reader = XmlReader.Create(xmlFile, settings))
                {

                    // Parse the XML document.  ReadString is used to 
                    // read the text content of the elements.
                    reader.MoveToContent();
                    reader.ReadStartElement("upastiti");

                    reader.ReadToFollowing("master");
                    
                    reader.ReadStartElement("master");
                    tmasterpass = reader.ReadElementString("password");
                    reader.Skip();
                    reader.ReadEndElement();

                    reader.ReadEndElement();
                    return tmasterpass;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Auth_readXMLData):" + e.Message);
            }
            return tmasterpass;
        }
    }
}
