using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MigraDoc.Rendering.Forms;
using System.Text.RegularExpressions;
namespace UpastitiCS
{
    public partial class Reports : Form
    {
        private MsSQL mssql=null;
        private string DefaultPlant = "";
        private Regex regShift = new Regex(@"([\w]+)-([\w]+)");
        public Reports()
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
                cbSelectAll.Checked = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@initDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:initialiseDatabase):" + e.Message);
            }
        }
        private void LoadDBValues()
        {
            try{
            SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,staffname FROM staff where plantname='{0}' order by staffno;",DefaultPlant), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            lbMRStaff.Items.Clear();
            lbIRStaff.Items.Clear();
            while (reader.Read())
            {
                lbIRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
                lbMRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
            }
            reader.Close();

            cbPlant.Items.Clear();
            cbPlant.Items.Add("NONE");  //First Item
            cmd.CommandText =string.Format("SELECT * FROM plant order by plantname;");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbPlant.Items.Add(reader.GetString(0));
            }
            reader.Close();

            cbPlant.Text = DefaultPlant;

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
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Exception@LoadDBValues", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:LoadDBValues):" + e.Message);
            }
            
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //Select All 
            if (cbSelectAll.Checked)
            {
                for (int i = 0; i < lbMRStaff.Items.Count; i++)
                    lbMRStaff.SetSelected(i, true);
            }
            else
            {
                for (int i = 0; i < lbMRStaff.Items.Count; i++)
                    lbMRStaff.SetSelected(i, false);
            }
        }

        private void btnDayReport_Click(object sender, EventArgs e)
        {
            btnDayReport.Enabled = false;
            generateDayReport(dtpDRDate.Value.Year.ToString("D4")+"-"+dtpDRDate.Value.Month.ToString("D2")+"-"+dtpDRDate.Value.Day.ToString("D2"));
            btnDayReport.Enabled = true;
        }
        private void btnIR_Click(object sender, EventArgs e)
        {
            btnIR.Enabled = false;
            if (lbIRStaff.Text == null || lbIRStaff.Text.Trim() == "")
            {
                MessageBox.Show(this,"Kindly Select the Staff","Staff?",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnIR.Enabled = true;
                return;
            }
            int index=lbIRStaff.Text.IndexOf('-');
            generateIndividualReport(lbIRStaff.Text.Substring(0, index),lbIRStaff.Text.Substring(index+1),dtpIRFrom.Value.Year.ToString("D4") + "-" + dtpIRFrom.Value.Month.ToString("D2") + "-" + dtpIRFrom.Value.Day.ToString("D2"), dtpIRTo.Value.Year.ToString("D4") + "-" + dtpIRTo.Value.Month.ToString("D2") + "-" + dtpIRTo.Value.Day.ToString("D2"));
            btnIR.Enabled = true;
        }
        private void btnMonthReport_Click(object sender, EventArgs e)
        {
            btnMonthReport.Enabled = false;
            
            if (lbMRStaff.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Kindly Select at-least one Staff", "Staff?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnMonthReport.Enabled = true;
                return;
            }
            if (cbOvertime.Checked)
            {
                generateOvertimeMonthReport(getStaffNoCSSet(), dtpMRDate.Value);
            }else
            generateMonthReport(getStaffNoCSSet(), dtpMRDate.Value);
            
            btnMonthReport.Enabled = true ;
        }
        //Staff No, Comma Separated Set
        private string getStaffNoCSSet()
        {
            string stafflist = "",staff="";
            for (int i = 0; i < lbMRStaff.SelectedItems.Count; i++)
            {
                staff=lbMRStaff.SelectedItems[i].ToString();
                if (i == 0)
                    stafflist = "'" + staff.Substring(0, staff.IndexOf('-')) + "'";
                else
                    stafflist += ", '"+staff.Substring(0, staff.IndexOf('-')) + "'";
            }
            return stafflist;
        }
        //*********************************************************** Generate Reports *************************************************************** //

        private void generateDayReport(string day)
        {
            try
            {

                Document document = getDocument("Day Report - Generated by Upastiti");
                Style style = getStyle(document);


                // Each MigraDoc document needs at least one section.
                Section section = document.AddSection();
                //Header and Footer Margin
                section.PageSetup.TopMargin = Unit.FromCentimeter(2.5);
                //section.PageSetup.BottomMargin = Unit.FromCentimeter(2.5);

                //Header
                MigraDoc.DocumentObjectModel.Shapes.Image image = section.Headers.Primary.AddImage("bellogo.png");
                image.Height = "1cm";
                image.LockAspectRatio = true;
                image.Top = ShapePosition.Top;
                image.WrapFormat.Style = WrapStyle.Through;

                Paragraph hparagraph = section.Headers.Primary.AddParagraph();
                hparagraph.Format.SpaceBefore = "0.7cm";
                hparagraph.Format.Alignment = ParagraphAlignment.Right;
                hparagraph.Format.Font.Size = 7;
                hparagraph.AddText("Day Attendance Report - Generated by Upastiti Software");
                hparagraph.Format.Borders.Bottom.Width = "0.5pt";


                // Add the print date field
                Paragraph paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.02cm";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Font.Bold = true;
                // paragraph.Format.Font.Underline = Underline.Single;
              
                    paragraph.AddText("Day Attendance Report");

                // Add the print date field
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceAfter = "0.3cm";
                paragraph.Format.SpaceBefore = "0.2cm";
                paragraph.Style = "Ref2";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.AddFormattedText("Attendance report for the day, " + DateTime.Parse(day).ToString("dd-MM-yyyy"), TextFormat.Italic);

                Table table = getDayTable(section);
                createDayHeader(table);
                table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                generateDayReportRows(table, day);
                table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);

                

                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

                // Set the MigraDoc document
                pdfRenderer.Document = document;

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...
                pdfRenderer.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DR.pdf");

                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DR.pdf");
                //DocumentPreview dp = new DocumentPreview();
                // dp.Ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
                //dp.Show(); 
                //dp.ShowPage = true;
                //dp.Show();

                //dp.Document = document;
                //dp.Visible = true;
                //dp.Show();

                // MigraDoc.Rendering.Printing.MigraDocPrintDocument pd = new MigraDocPrintDocument(pdfRenderer.DocumentRenderer);
                //pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }

        private void generateIndividualReport(string staffno,string staffname ,string fromdate, string todate)
        {
            try{
            Document document = getDocument("Staff Report - Generated by Upastiti");
            
            Style style = getStyle(document);
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();

            //Header and Footer Margin
            section.PageSetup.TopMargin = Unit.FromCentimeter(2.5);
            //section.PageSetup.BottomMargin = Unit.FromCentimeter(2.5);

            //Header
            MigraDoc.DocumentObjectModel.Shapes.Image image = section.Headers.Primary.AddImage("bellogo.png");
            image.Height = "1cm";
            image.LockAspectRatio = true;
            image.Top = ShapePosition.Top;
            image.WrapFormat.Style = WrapStyle.Through;

            Paragraph hparagraph = section.Headers.Primary.AddParagraph();
            hparagraph.Format.SpaceBefore = "0.7cm";
            hparagraph.Format.Alignment = ParagraphAlignment.Right;
            hparagraph.Format.Font.Size = 7;
            hparagraph.AddText("Staff Attendance Report - Generated by Upastiti Software");
            hparagraph.Format.Borders.Bottom.Width = "0.5pt";


            // Add the print date field
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0.02cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Bold = true;
            // paragraph.Format.Font.Underline = Underline.Single;

            paragraph.AddText("Staff Attendance Report");

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "0.3cm";
            paragraph.Format.SpaceBefore = "0.2cm";
            paragraph.Style = "Ref2";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddFormattedText(string.Format("Staff Attendance report for the period {0} to {1}", DateTime.Parse(fromdate).ToShortDateString(), DateTime.Parse(todate).ToShortDateString()), TextFormat.Italic);

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Style = "Ref2";
            paragraph.Format.SpaceAfter = "5pt";
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.AddFormattedText("Staff No: " + staffno, TextFormat.Bold);
            //paragraph.AddTab();
            //paragraph.AddTab();
            
            paragraph.AddFormattedText("\nName: " + staffname, TextFormat.Bold);
           // paragraph.Format.SpaceBefore = "9pt";

            if (mssql != null && mssql.isConnected())
            {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT fathername,plantname,gender,skilllevel,samitiname,contractorname FROM staff where staffno={0};", staffno), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       paragraph.AddFormattedText("\nFather's Name: " + reader.GetString(0), TextFormat.Bold);
                       paragraph.AddFormattedText("\nPlant: " + reader.GetString(1), TextFormat.Bold);
                       paragraph = section.AddParagraph();
                       paragraph.Style = "Ref2";
                       paragraph.Format.SpaceBefore = "-1.25cm";
                       paragraph.Format.Alignment = ParagraphAlignment.Right;
                       paragraph.AddFormattedText("Skill Level: " + reader.GetString(3), TextFormat.Bold);
                       paragraph.AddFormattedText("\nGender: " + reader.GetString(2), TextFormat.Bold);
                       paragraph.AddFormattedText("\nSamiti/Agency: " + reader.GetString(4), TextFormat.Bold);
                       paragraph.AddFormattedText("\nContractor's Name: " + reader.GetString(5), TextFormat.Bold);
                    }
                    reader.Close();
                
            }

            //// Add the print date field
            //Paragraph paragraph = section.AddParagraph();
            //paragraph.Format.SpaceBefore = "0.3cm";
            //paragraph.Format.Alignment = ParagraphAlignment.Center;
            //paragraph.Format.Font.Size = 13;
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Underline = Underline.Single;
            //paragraph.AddText("Staff Attendance Report");

            //paragraph = section.AddParagraph();
            //paragraph.Format.SpaceBefore = "0.5cm";
            //paragraph.Format.Alignment = ParagraphAlignment.Center;
            //paragraph.AddFormattedText(string.Format("Staff Attendance report for the period {0} to {1}", DateTime.Parse(fromdate).ToShortDateString(), DateTime.Parse(todate).ToShortDateString()), TextFormat.Italic);
            
            //// Add the print date field
            //paragraph = section.AddParagraph();
            //paragraph.Style = "Ref2";

            //paragraph.Format.Alignment = ParagraphAlignment.Center;
            //paragraph.AddFormattedText("Staff No: " + staffno, TextFormat.Bold);
            //paragraph.AddTab();
            //paragraph.AddTab();
            //paragraph.AddFormattedText("Name: " + staffname, TextFormat.Bold);
            //paragraph.Format.SpaceAfter = "0.5cm";
          
            Table table = getIRTable(section);
            createIRHeader(table);
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
            generateIRReportRows(table, staffno,fromdate,todate);
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);


            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            pdfRenderer.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SR.pdf");

            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SR.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string getSamitiTitle()
        {
            string samitititle = "";
            if (mssql != null && mssql.isConnected())
            {
                if (cbSamiti.Text != null && cbSamiti.Text != "NONE")
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT title FROM samiti where samitiname='{0}';", cbSamiti.Text.ToString().Trim().ToUpper()), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            samitititle = reader.GetString(0);
                        }
                    }
                    reader.Close();
                }
            }
            return samitititle;
        }

        private string getPlantTitle()
        {
            string planttitle = "";
            if (mssql != null && mssql.isConnected())
            {
                if (cbPlant.Text != null && cbPlant.Text != "NONE")
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT title FROM plant where plantname='{0}';", cbPlant.Text.ToString().Trim().ToUpper()), mssql.getConnection());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            planttitle = reader.GetString(0);
                        }
                    }
                    reader.Close();
                }
            }
            return planttitle;
        }
        private void generateMonthReport(string stafflist, DateTime forMonth)
        {
            try{
            Document document = getDocument("Month Report - Generated by Upastiti");
            Style style = getStyle(document);
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
            section.PageSetup.DifferentFirstPageHeaderFooter = false;
            //section.AddImage("bellogo.png");
            //Header and Footer Margin
            section.PageSetup.TopMargin = Unit.FromCentimeter(2.5);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(2.5);
            
            //Header
            MigraDoc.DocumentObjectModel.Shapes.Image image = section.Headers.Primary.AddImage("bellogo.png");
            image.Height = "1cm";
            image.LockAspectRatio = true;
            image.Top = ShapePosition.Top;
            image.WrapFormat.Style = WrapStyle.Through;

            Paragraph hparagraph = section.Headers.Primary.AddParagraph();
            hparagraph.Format.SpaceBefore = "0.7cm";
            hparagraph.Format.Alignment = ParagraphAlignment.Right;
            hparagraph.Format.Font.Size = 7;
            hparagraph.AddText("Monthly Attendance Report - Generated by Upastiti Software");
            hparagraph.Format.Borders.Bottom.Width = "0.5pt";
            

            // Add the print date field
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0.02cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Bold = true;
           // paragraph.Format.Font.Underline = Underline.Single;
            string samitiTitle = getSamitiTitle();
            if (samitiTitle != "")
                paragraph.AddText(string.Format("{0}", samitiTitle));
            else
                paragraph.AddText("Monthly Attendance Report");

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "0.1cm";
            paragraph.Format.SpaceBefore = "0.3cm";
            paragraph.Style = "Ref2";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddFormattedText("Attendance report for the Month of  " + forMonth.ToString("MMMM, yyyy"), TextFormat.Italic);

    
            Table table = getMRTable(section);
            createMRHeader(table,forMonth);

            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
            generateMRReportRows(table,stafflist, forMonth);
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
           
            //Footer    
            paragraph = section.Footers.Primary.AddParagraph();
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.Font.Bold = true;
            
            bool samitiAdded = false;
            if (samitiTitle!="")
            {
                paragraph.AddFormattedText(samitiTitle);
                samitiAdded = true;
            }
            paragraph = section.Footers.Primary.AddParagraph();
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph.Format.Font.Bold = true;
            if (samitiAdded)
            {
                paragraph.Format.SpaceBefore = "8pt";
            }
            //if (cbPlant.Text != null && cbPlant.Text != "NONE")
            paragraph.AddText(getPlantTitle());
            
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            pdfRenderer.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MR.pdf");

            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MR.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         private void generateOvertimeMonthReport(string stafflist, DateTime forMonth)
        {
            try{
                Document document = getDocument("Month Overtime Report - Generated by Upastiti");
                Style style = getStyle(document);
                // Each MigraDoc document needs at least one section.
                Section section = document.AddSection();
                section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
                //Header and Footer Margin
                section.PageSetup.TopMargin = Unit.FromCentimeter(2.5);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(2.5);

                //Header
                MigraDoc.DocumentObjectModel.Shapes.Image image = section.Headers.Primary.AddImage("bellogo.png");
                image.Height = "1cm";
                image.LockAspectRatio = true;
                image.Top = ShapePosition.Top;
                image.WrapFormat.Style = WrapStyle.Through;

                Paragraph hparagraph = section.Headers.Primary.AddParagraph();
                hparagraph.Format.SpaceBefore = "0.7cm";
                hparagraph.Format.Alignment = ParagraphAlignment.Right;
                hparagraph.Format.Font.Size = 7;
                hparagraph.AddText("Monthly Overtime Report - Generated by Upastiti Software");
                hparagraph.Format.Borders.Bottom.Width = "0.5pt";


                // Add the print date field
                Paragraph paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.02cm";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Font.Bold = true;
                // paragraph.Format.Font.Underline = Underline.Single;
                string samitiTitle = getSamitiTitle();
                if (samitiTitle != "")
                    paragraph.AddText(string.Format("{0}", samitiTitle));
                else
                    paragraph.AddText("Monthly Overtime Report");

                // Add the print date field
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceAfter = "0.3cm";
                paragraph.Format.SpaceBefore = "0.2cm";
                paragraph.Style = "Ref2";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.AddFormattedText("Overtime report for the Month of  " + forMonth.ToString("MMMM, yyyy"), TextFormat.Italic);

                Table table = getMRTable(section);
                createMRHeader(table, forMonth);

                table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                generateOvertimeMRReportRows(table, stafflist, forMonth);
                table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);

                //Footer    
                paragraph = section.Footers.Primary.AddParagraph();
                paragraph.Format.Font.Size = 8;
                paragraph.Format.Alignment = ParagraphAlignment.Left;
                paragraph.Format.Font.Bold = true;

                bool samitiAdded = false;
                if (samitiTitle != "")
                {
                    paragraph.AddFormattedText(samitiTitle);
                    samitiAdded = true;
                }
                paragraph = section.Footers.Primary.AddParagraph();
                paragraph.Format.Font.Size = 8;
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Bold = true;
                if (samitiAdded)
                {
                    paragraph.Format.SpaceBefore = "8pt";
                }
                //if (cbPlant.Text != null && cbPlant.Text != "NONE")
                paragraph.AddText(getPlantTitle());

                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

                // Set the MigraDoc document
                pdfRenderer.Document = document;

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...
                pdfRenderer.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/OR.pdf");

                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/OR.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         private void generateOvertimeMRReportRows(Table table, string stafflist, DateTime forMonth)
         {
             Row row = null;
             int i = 0, tillDay = 0, totalOT = 0;
             string prevStaffNo = "", prevShiftCode = "";
             int roundOff = 0;
             DateTime dt1 = DateTime.Now, dt2;
             string query = string.Format("select m.staffno,s.staffname,s.fathername,m.moveon,m.shiftcode,s.gender,s.skilllevel,s.contractorname from movement as m, staff as s where m.staffno=s.staffno "
                 + "and m.moveon BETWEEN DATEADD(m, DATEDIFF(m, 0, '{0}'), 0)  AND DATEADD(hour, 8, DATEADD(month, DATEDIFF(month, 0, '{0}') + 1, 0)) and m.staffno IN ({1}) order by m.staffno,m.moveon;", forMonth.ToString("yyyy-MM-dd HH:mm:ss"), stafflist);
             DateTime lastDate = getLastDateOfAttendance(forMonth);
             SqlCommand cmd = new SqlCommand(query, mssql.getConnection());
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 if (regShift.Match(reader.GetString(4)).Groups[2].Value == "IN")
                 {

                     if (prevStaffNo != reader.GetString(0))
                     {
                         if (i > 0 && row != null)
                         {
                             //To Fill A's till LASTDAY-1
                             while (tillDay + 1 <= lastDate.Day)
                             {

                                 if (DateTime.Parse(string.Format("{0}-{1}-{2}", lastDate.Year, lastDate.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                                     row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                                 else
                                     row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                             }
                             //Previous Staff Total 
                             row.Cells[36].AddParagraph(totalOT.ToString("D2"));
                             totalOT = 0;
                             tillDay = 0;
                         }

                         i++;
                         prevStaffNo = reader.GetString(0);
                         row = table.AddRow();
                         row.Format.Alignment = ParagraphAlignment.Center;
                         //row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
                         row.Cells[0].AddParagraph((i).ToString());
                         row.Cells[1].AddParagraph(prevStaffNo);
                         row.Cells[2].AddParagraph(reader.GetString(1));
                         row.Cells[3].AddParagraph(reader.GetString(5));
                         row.Cells[4].AddParagraph(reader.GetString(6));
                         row.Cells[5].AddParagraph(reader.GetString(7));
                     }
                     prevShiftCode = regShift.Match(reader.GetString(4)).Groups[1].Value;
                     dt1 = reader.GetDateTime(3);
                 }
                 else if (prevStaffNo == reader.GetString(0) && prevShiftCode == regShift.Match(reader.GetString(4)).Groups[1].Value && row != null)
                 {

                     dt2 = reader.GetDateTime(3);
                     TimeSpan ts = dt2.Subtract(dt1);
                     //To Fill A's If there are no records in between
                     while (tillDay + 1 < dt1.Day)
                     {

                         if (DateTime.Parse(string.Format("{0}-{1}-{2}", dt1.Year, dt1.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                             row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                         else
                             row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                     }
                     tillDay = dt1.Day;
                     if (dt1.DayOfWeek == DayOfWeek.Sunday){
                         //Round Off Operation
                         if (ts.Minutes >= 30)
                             roundOff = 1;
                         else
                             roundOff = 0;
                        row.Cells[4 + dt1.Day].AddParagraph((ts.Hours+roundOff).ToString("D2"));
                        row.Cells[4 + dt1.Day].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                        totalOT+=ts.Hours+roundOff;
                     }
                     else if (ts.Hours > 8){
                         //Round Off Operation
                         if (ts.Minutes >= 30)
                             roundOff = 1;
                         else
                             roundOff = 0;

                         totalOT+=ts.Hours-8+roundOff;
                         Paragraph p=row.Cells[4 + dt1.Day].AddParagraph(((ts.Hours+roundOff)-8).ToString("D2"));
                         if(prevShiftCode[0]=='U')
                             p.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(255, 0, 0);
                     }else
                         row.Cells[4 + dt1.Day].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);
                     
                 }
             }
             reader.Close();
             //For Last Row
             if (i > 0 && row != null)
             {
                 //To Fill A's till LASTDAY-1
                 while (tillDay + 1 <= lastDate.Day)
                 {

                     if (DateTime.Parse(string.Format("{0}-{1}-{2}", lastDate.Year, lastDate.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                         row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                     else
                         row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                 }
                 //Previous Staff Total 
                 row.Cells[36].AddParagraph(totalOT.ToString("D2"));
                 totalOT = 0;
                 tillDay = 0;
             }
         }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// //

        // ********************************************* Generate and Render PDF ******************************************************************** //
        private void generateDayReportRows(Table table, string day)
        {
            Row row = null;
            int i = 0;
            string prevStaffNo="", prevShiftCode="";
            DateTime dt1=DateTime.Now,dt2;
            SqlCommand cmd = new SqlCommand(string.Format("SELECT s.staffno,s.staffname,s.fathername,s.plantname,m.moveon,m.shiftcode,s.gender,s.skilllevel,s.samitiname, s.contractorname FROM staff as s, movement as m where m.staffno=s.staffno and s.plantname='{1}' and m.moveon BETWEEN '{0} 00:00:00' AND DATEADD(hour,7,'{0} 23:59:59') order by m.staffno,m.moveon;", day,DefaultPlant), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (regShift.Match(reader.GetString(5)).Groups[2].Value == "IN")
                {
                    i++;
                    dt1 = reader.GetDateTime(4);
                    //Skip Next Day IN Punches, if any
                    if (dt1.ToString("yyyy-MM-dd")!=day)
                        continue;
                    prevStaffNo = reader.GetInt32(0).ToString();
                    prevShiftCode = regShift.Match(reader.GetString(5)).Groups[1].Value;
                    row = table.AddRow();
                    row.Format.Alignment = ParagraphAlignment.Center;
                    //row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
                    row.Cells[0].AddParagraph((i).ToString());
                    //row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                    //row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row.Cells[1].AddParagraph(prevStaffNo);
                    //row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[2].AddParagraph(reader.GetString(1));
                    row.Cells[3].AddParagraph(reader.GetString(2));
                    row.Cells[6].AddParagraph(reader.GetString(3));
                    row.Cells[4].AddParagraph(reader.GetString(6));
                    row.Cells[5].AddParagraph(reader.GetString(7));
                    row.Cells[7].AddParagraph(reader.GetString(8));
                    row.Cells[8].AddParagraph(reader.GetString(9));
                    
                    
                    row.Cells[9].AddParagraph(dt1.Hour.ToString("D2")+":"+dt1.Minute.ToString("D2"));

                    //Update Color if Regularisation is Found
                    Paragraph p=row.Cells[14].AddParagraph();
                    if (prevShiftCode[0] == 'U')
                    {
                        p.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(255, 0, 0);
                        p.AddText(prevShiftCode.Substring(1));
                    }
                    else
                    {
                        p.AddText(prevShiftCode);
                    }
                    
                }else if(prevStaffNo==reader.GetInt32(0).ToString() && prevShiftCode== regShift.Match(reader.GetString(4)).Groups[1].Value && row!=null){

                    dt2 = reader.GetDateTime(3);
                    row.Cells[7].AddParagraph(dt2.Hour.ToString("D2") + ":" + dt2.Minute.ToString("D2"));
                    TimeSpan ts = dt2.Subtract(dt1);
                    row.Cells[8].AddParagraph(ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2"));
                    if (ts.Hours >= 8)
                    {
                        row.Cells[9].AddParagraph((ts.Hours - 8).ToString("D2") + ":" + ts.Minutes.ToString("D2"));
                    }
                    else
                    {
                        row.Cells[9].AddParagraph("00:00");
                    }
                    
                }
            }
            reader.Close();
        }
        private Document getDocument(string title)
        {
            Document document = new Document();
            document.UseCmykColor = true;
            //Document  Creation
            document.Info.Author = "Bharat Electronics Limited";
            document.Info.Title = title;
            document.Info.Subject = title;
            document.DefaultPageSetup.TopMargin = "0.5cm";
            document.DefaultPageSetup.BottomMargin = "0.5cm";

            return document;
        }

        private Style getStyle(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table2", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 7;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            style = document.Styles.AddStyle("Ref2", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("4cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            return style;
        }

        private Table getDayTable(Section section)
        {
            Table table = section.AddTable();

            table.Style = "Table2";
            //table.Borders.Color = new MigraDoc.DocumentObjectModel.Color(81, 125, 192);
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Rows.LeftIndent = "-2cm";
            
            // Before you can add a row, you must define the columns
            //Sl.No
            Column column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Staff No
            column = table.AddColumn("1.7cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Staff Name
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Gender
            column = table.AddColumn("1.3cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Skill Level
            column = table.AddColumn("2.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Plant Name
            column = table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //IN Time
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //OUT Time
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Working Hours
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //OverTime
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Shift-Code
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            return table;
        }
        private void createDayHeader(Table table)
        {
            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
            row.Cells[0].AddParagraph("Sl.No");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].AddParagraph("Staff No");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("Staff Name");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("Gender");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("Skill Level");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[5].AddParagraph("Plant");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[6].AddParagraph("IN");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[7].AddParagraph("OUT");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("WHrs");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[9].AddParagraph("OT");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[10].AddParagraph("Shift");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Center;            
        }

        private Table getIRTable(Section section)
        {
            Table table = section.AddTable();

            table.Style = "Table";
            //table.Borders.Color = new MigraDoc.DocumentObjectModel.Color(81, 125, 192);
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Rows.LeftIndent = "2.5cm";

            // Before you can add a row, you must define the columns
            //Sl.No
            Column column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Date
            column = table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //IN Time
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //OUT Time
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Working Hours
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //OverTime
            column = table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Shift-Code
            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            return table;
        }

        private void createIRHeader(Table table)
        {
            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
            row.Cells[0].AddParagraph("Sl.No");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].AddParagraph("Date");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("IN");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("OUT");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("WHrs");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[5].AddParagraph("OT");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[6].AddParagraph("Shift");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
        }
        private void generateIRReportRows(Table table, string staffno,string fromdate,string todate)
        {
            Row row = null;
            int i = 0;
            string  prevShiftCode = "";
            DateTime dt1 = DateTime.Now, dt2;
            SqlCommand cmd = new SqlCommand(string.Format("SELECT moveon,shiftcode FROM movement where staffno={0} and cast(moveon as date) BETWEEN '{1}' AND '{2}' order by moveon;", staffno, fromdate, todate), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (regShift.Match(reader.GetString(1)).Groups[2].Value == "IN")
                {
                    i++;
                    prevShiftCode = regShift.Match(reader.GetString(1)).Groups[1].Value;
                    row = table.AddRow();
                    row.Format.Alignment = ParagraphAlignment.Center;
                    //row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
                    row.Cells[0].AddParagraph((i).ToString());
                    dt1 = reader.GetDateTime(0);
                    row.Cells[1].AddParagraph(dt1.Day.ToString("D2") + "-" + dt1.Month.ToString("D2") + "-" + dt1.Year.ToString("D4"));
                    row.Cells[2].AddParagraph(dt1.Hour.ToString("D2") + ":" + dt1.Minute.ToString("D2"));

                    //Update Color if Regularisation is Found
                    Paragraph p = row.Cells[6].AddParagraph();
                    if (prevShiftCode[0] == 'U')
                    {
                        p.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(255, 0, 0);
                        p.AddText(prevShiftCode.Substring(1));
                    }
                    else
                    {
                        p.AddText(prevShiftCode);
                    }

                   // row.Cells[6].AddParagraph(prevShiftCode);

                }
                else if (prevShiftCode == regShift.Match(reader.GetString(1)).Groups[1].Value && row != null)
                {

                    dt2 = reader.GetDateTime(0);
                    row.Cells[3].AddParagraph(dt2.Hour.ToString("D2") + ":" + dt2.Minute.ToString("D2"));
                    TimeSpan ts = dt2.Subtract(dt1);
                    row.Cells[4].AddParagraph(ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2"));
                    if (ts.Hours >= 8)
                    {
                        row.Cells[5].AddParagraph((ts.Hours - 8).ToString("D2") + ":" + ts.Minutes.ToString("D2"));
                    }
                    else
                    {
                        row.Cells[5].AddParagraph("00:00");
                    }

                }
            }
            reader.Close();
        }
        private Table getMRTable(Section section)
        {
            Table table = section.AddTable();

            table.Style = "Table";
            //table.Borders.Color = new MigraDoc.DocumentObjectModel.Color(81, 125, 192);
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Rows.LeftIndent = "-2cm";

            // Before you can add a row, you must define the columns
            //Sl.No
            Column column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Staff No
            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Staff Name
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Gender
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Skill Level
            column = table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            //Days
            for (int i = 0; i < 31; i++)
            {
                column = table.AddColumn("0.5cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }
            //Total
            column = table.AddColumn("1.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            
            return table;
        }
        private void createMRHeader(Table table,DateTime forMonth)
        {
            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
            row.Cells[0].AddParagraph("Sl.No");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].AddParagraph("Staff No");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("Staff Name");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("Gender");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("Skill Level");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;

            DateTime firstDayOfMonth=DateTime.Parse(string.Format("{0}-{1}-01",forMonth.Year,forMonth.Month));
            //31 Days
            for (int i = 0; i < DateTime.DaysInMonth(forMonth.Year, forMonth.Month); i++)
            {
                if (firstDayOfMonth.DayOfWeek==DayOfWeek.Sunday)
                {
                    row.Cells[5 + i].AddParagraph((i + 1).ToString("D2"));
                    row.Cells[5 + i].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[5 + i].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                }
                else
                {
                    row.Cells[5 + i].AddParagraph((i + 1).ToString("D2"));
                    row.Cells[5 + i].Format.Alignment = ParagraphAlignment.Center;
                }
                firstDayOfMonth = firstDayOfMonth.AddDays(1);
            }
            
            row.Cells[36].AddParagraph("Total");
            row.Cells[36].Format.Alignment = ParagraphAlignment.Center;           
        }
        private DateTime getLastDateOfAttendance(DateTime fm)
        {
            DateTime dt = fm;
            dt=DateTime.Parse(string.Format("{0}-{1}-{2}",dt.Year,dt.Month,DateTime.DaysInMonth(dt.Year,dt.Month)));
            SqlCommand cmd = new SqlCommand(string.Format("SELECT CURRENT_TIMESTAMP"), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                if (dt.CompareTo(reader.GetDateTime(0)) > 0)
                {
                    //Means, End of month is Greater than CURRENT TIMESTAMP of Server therefore, Upper Limit is TIMESTAMP-1 i.e till Previous Day
                    dt = reader.GetDateTime(0).Subtract(TimeSpan.FromDays(1));
                }

            }
            reader.Close();
            return dt;
        }
        private void generateMRReportRows(Table table, string stafflist, DateTime forMonth)
        {
            Row row = null;
            int i = 0,tillDay=0,presentDayCount=0;
            string prevStaffNo="",prevShiftCode = "";
            DateTime dt1 = DateTime.Now, dt2;
            string query = string.Format("select m.staffno,s.staffname,m.moveon,m.shiftcode,s.gender,s.skilllevel from movement as m, staff as s where m.staffno=s.staffno "
                + "and m.moveon BETWEEN DATEADD(m, DATEDIFF(m, 0, '{0}'), 0)  AND DATEADD(hour, 8, DATEADD(month, DATEDIFF(month, 0, '{0}') + 1, 0)) and m.staffno IN ({1}) order by m.staffno,m.moveon;", forMonth.ToString("yyyy-MM-dd HH:mm:ss"), stafflist);
            DateTime lastDate = getLastDateOfAttendance(forMonth);
            SqlCommand cmd = new SqlCommand(query, mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (regShift.Match(reader.GetString(3)).Groups[2].Value == "IN")
                {
                   
                    if (prevStaffNo != reader.GetInt32(0).ToString())
                    {
                        if (i > 0 && row != null)
                        {
                            //Fill A's if TillDay<=(TIMESTAMP-1Day)
                            while (tillDay + 1 <= lastDate.Day)
                            {

                                if (DateTime.Parse(string.Format("{0}-{1}-{2}", lastDate.Year, lastDate.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                                    row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                                else
                                {
                                    row.Cells[4 + (++tillDay)].AddParagraph("A");
                                    row.Cells[4 + (tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                                }
                            }

                            //Previous Staff Total 
                            row.Cells[36].AddParagraph(presentDayCount.ToString("D2"));
                            presentDayCount = 0;
                            tillDay = 0;
                        }
                           
                        i++;
                        prevStaffNo = reader.GetInt32(0).ToString();
                        row = table.AddRow();
                        row.Format.Alignment = ParagraphAlignment.Center;
                        //row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(235, 240, 249);
                        row.Cells[0].AddParagraph((i).ToString());
                        row.Cells[1].AddParagraph(prevStaffNo);
                        row.Cells[2].AddParagraph(reader.GetString(1));
                        row.Cells[3].AddParagraph(reader.GetString(4));
                        row.Cells[4].AddParagraph(reader.GetString(5));
                    }
                    prevShiftCode = regShift.Match(reader.GetString(3)).Groups[1].Value;
                    dt1 = reader.GetDateTime(2);       
                }
                else if (prevStaffNo == reader.GetInt32(0).ToString() && prevShiftCode == regShift.Match(reader.GetString(3)).Groups[1].Value && row != null)
                {

                    dt2 = reader.GetDateTime(2);  
                    TimeSpan ts = dt2.Subtract(dt1);
                    //To Fill A's If there are no records in between
                    while (tillDay + 1 < dt1.Day)
                    {

                        if (DateTime.Parse(string.Format("{0}-{1}-{2}", dt1.Year, dt1.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                            row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                        else
                        {
                            row.Cells[4 + (++tillDay)].AddParagraph("A");
                            row.Cells[4 + (tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                        }
                    }
                    tillDay = dt1.Day;
                    if (ts.Hours >= 4)
                    {
                        if (dt1.DayOfWeek == DayOfWeek.Sunday)
                            row.Cells[4 + dt1.Day].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                        else
                        {

                            Paragraph p=row.Cells[4 + dt1.Day].AddParagraph("P");
                            if(prevShiftCode[0]=='U')
                            p.Format.Font.Color = new MigraDoc.DocumentObjectModel.Color(255, 0, 0); 
                            presentDayCount++;
                        }
                    }
                    else
                    {
                        if (dt1.DayOfWeek == DayOfWeek.Sunday)
                            row.Cells[4 + dt1.Day].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                        else
                        {
                            row.Cells[4 + dt1.Day].AddParagraph("A");
                            row.Cells[4 + dt1.Day].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);       //Absent
                        }
                    }

                }
            }
            reader.Close();
            //For Last Row

           


            if (i > 0 && row != null)
            {
                //Fill A's if TillDay<=(TIMESTAMP-1Day)
                while (tillDay + 1 <= lastDate.Day)
                {

                    if (DateTime.Parse(string.Format("{0}-{1}-{2}", lastDate.Year, lastDate.Month, (tillDay + 1).ToString("D2"))).DayOfWeek == DayOfWeek.Sunday)
                        row.Cells[4 + (++tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(250, 250, 150);
                    else
                    {
                        row.Cells[4 + (++tillDay)].AddParagraph("A");
                        row.Cells[4 + (tillDay)].Shading.Color = new MigraDoc.DocumentObjectModel.Color(150, 150, 150);   //Absent
                    }
                }
                //Previous Staff Total 
                row.Cells[36].AddParagraph(presentDayCount.ToString("D2"));
                presentDayCount = 0;
                tillDay = 0;
            }
        }

        private string getFilterCondition()
        {
            string condition = "";
            if ((cbPlant.Text == "" || cbPlant.Text == "NONE") && (cbSamiti.Text == "" || cbSamiti.Text == "NONE"))
                condition = "";
            else if (cbSamiti.Text == "" || cbSamiti.Text == "NONE")
                condition = string.Format("where plantname='{0}'", cbPlant.Text);
            else if (cbPlant.Text == "" || cbPlant.Text == "NONE")
                condition = string.Format("where samitiname='{0}'", cbSamiti.Text);
            else
                condition = string.Format("where plantname='{0}' and samitiname='{1}'", cbPlant.Text, cbSamiti.Text);
            return condition;
        }

        private void toggleSelectAll()
        {
            cbSelectAll.Checked = !cbSelectAll.Checked; //Toggle and Remain in same State
            cbSelectAll.Checked = !cbSelectAll.Checked;
        }

        private void loadStaff()
        {
            SqlCommand cmd = new SqlCommand(string.Format("SELECT staffno,staffname FROM staff {0} order by staffno;", getFilterCondition()), mssql.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            lbMRStaff.Items.Clear();
            while (reader.Read())
            {
                lbMRStaff.Items.Add(reader.GetInt32(0).ToString() + "-" + reader.GetString(1));
            }
            reader.Close();
            toggleSelectAll();
        }
        private void cbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                loadStaff();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@cbPlant_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:cbPlant_SelectedIndexChanged):" + ex.Message);
            }
        }

        private void cbSamiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadStaff();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception@cbPlant_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("Exception(Rep:cbPlant_SelectedIndexChanged):" + ex.Message);
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

      
      

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// //
    }
}
