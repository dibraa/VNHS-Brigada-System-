using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BrigadaEskwela_SoftwareDevelopment_II
{
    public partial class FRM_ViewReports : Form
    {
        public FRM_ViewReports()
        {
            InitializeComponent();
            countRecords();

            Searchtxt.Text = "";
            overview1();

            SchoolYearDrop();
            //YearCMBS();

            SchoolYearTXT.Text = "School Year";
            YearFrom.Text = "";
            YearTo.Text = "";
            SelectBrigada.Text = "All Records";

            SchoolYear.Text = "";


        }

        string cs = Global.Connection;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();


        public void LoadSY()
        {
            DONATION_Load_Filter();
            Donation();
        }

        // FILTER ORDER BY
        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderBy.Text = Orderbycmb.SelectedItem.ToString().ToUpper();

            if (Orderbycmb.Text.Trim().Equals("NAME - ASCENDING", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY Lname ASC";
            }
            else if (Orderbycmb.Text.Trim().Equals("NAME - DESCENDING", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY Lname DESC";
            }
            else if (Orderbycmb.Text.Trim().Equals("DATE - ASCENDING", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY DateVerified ASC";
            }
            else if (Orderbycmb.Text.Trim().Equals("DATE - DESCENDING", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY DateVerified DESC";
            }

            if (DonationGv.Visible)
            {
                DONATION_Load_Filter();
            }
            else if (VolunteerGv.Visible)
            {
                VOLUNTEER_Load_Filter();
            }
            else if (GenGv.Visible)
            {
                AllRecords();
                overview1();
            }
            else if (BrigadaOrgDonation.Visible)
            {
                if (Orderbycmb.Text.Trim().Equals("") || Orderbycmb.Text.Trim().Equals("NAME - ASCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName ASC";
                }
                else if (Orderbycmb.Text.Trim().Equals("NAME - DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName DESC";
                }
                else if (Orderbycmb.Text.Trim().Equals("DATE - ASCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified ASC";
                }
                else if (Orderbycmb.Text.Trim().Equals("DATE - DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified DESC";
                }

                BrigadaOrganizationDonation_Load_Filter();


            }
            else if (OrgVolunteer.Visible)
            {
                if (Orderbycmb.Text.Trim().Equals("NAME - ASCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName ASC";
                }
                else if (Orderbycmb.Text.Trim().Equals("NAME - DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName DESC";
                }
                else if (Orderbycmb.Text.Trim().Equals("DATE - ASCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified ASC";
                }
                else if (Orderbycmb.Text.Trim().Equals("DATE - DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified DESC";
                }

                BrigadaOrgVolunteer_Load_Filter();
            }




        }

        // FILTER ORDER BY ==========================================
        // FILTER ORDER BY ==========================================






        public void Donation()
        {


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd.Connection = con;

                    string sqlQuery = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2" +
                        " WHERE Lname LIKE '" + Searchtxt.Text + "%'";

                    // Add condition for YearFrom and YearTo if they have values
                    if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                    {
                        sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                    }

                    sqlQuery += GlobalFilter.OrderBy;
                    cmd.CommandText = sqlQuery;

                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    DonationGv.Rows.Clear();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = DonationGv.Rows.Add();

                        // Set cell values...
                        DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r["Lname"]} {r["Fname"]} {r["Mname"]} {r["Suffix"]}";
                        DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r["Gender"];
                        DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r["GradeLevel"];
                        DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r["LearnerStatus"];
                        DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r["FullName"];
                        DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r["Relationship"];
                        DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r["BrigadaType"];
                        DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r["ContactNo"];
                        DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = r["TotalAmount"];
                        DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r["Tools_Materials"];
                        DonationGv.Rows[rowIndex].Cells["Date2"].Value = r["DateVerified"];
                        DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r["VerifiedBy"];
                        DonationGv.Rows[rowIndex].Cells["DonationTYPE"].Value = r["DonationTYPE"];

                        DonationGv.Rows[rowIndex].Cells["YearFromD"].Value = r["YearFrom"];
                        DonationGv.Rows[rowIndex].Cells["YearToD"].Value = r["YearTo"];
                        DonationGv.Rows[rowIndex].Cells["SchoolYearD"].Value = $"{r["YearFrom"]} - {r["YearTo"]}";

                        DonationGv.Rows[rowIndex].Cells["DLname"].Value = r["Lname"];
                        DonationGv.Rows[rowIndex].Cells["DFname"].Value = r["Fname"];
                        DonationGv.Rows[rowIndex].Cells["DMname"].Value = r["Mname"];
                    }

                    DonationGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{


            //    SqlConnection con = new SqlConnection(cs);
            //    con.ConnectionString = cs;
            //    con.Open();
            //    cmd.Connection = con;
            //    //cmd.CommandText = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2"
            //    //    + " WHERE Lname LIKE '" + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;


            //    cmd.CommandText = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2"
            //               + " WHERE Lname LIKE '" + Searchtxt.Text + "%' AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'" + GlobalFilter.OrderBy;



            //    da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    dt = new DataTable();
            //    da.Fill(dt); 

            //    DonationGv.Rows.Clear();
            //    DonationGv.ClearSelection();

            //    foreach (DataRow r in dt.Rows)
            //    {
            //        int rowIndex = DonationGv.Rows.Add();
            //        DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
            //        DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r.Field<string>(4);
            //        DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r.Field<string>(5);
            //        DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r.Field<string>(6);
            //        DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r.Field<string>(7);
            //        DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r.Field<string>(8);
            //        DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r.Field<string>(9);
            //        DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r.Field<string>(10);
            //        DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = r.Field<Int32>(11);
            //        DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r.Field<string>(12);
            //        DonationGv.Rows[rowIndex].Cells["Date2"].Value = r.Field<string>(13);
            //        DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r.Field<string>(14);
            //        DonationGv.Rows[rowIndex].Cells["DonationTYPE"].Value = r.Field<string>(15);


            //        DonationGv.Rows[rowIndex].Cells["YearFromD"].Value = r.Field<string>(16);
            //        DonationGv.Rows[rowIndex].Cells["YearToD"].Value = r.Field<string>(17);
            //        DonationGv.Rows[rowIndex].Cells["SchoolYearD"].Value = $"{r.Field<string>(16)} - {r.Field<string>(17)}";



            //        DonationGv.Rows[rowIndex].Cells["DLname"].Value = r.Field<string>(0);
            //        DonationGv.Rows[rowIndex].Cells["DFname"].Value = r.Field<string>(1);
            //        DonationGv.Rows[rowIndex].Cells["DMname"].Value = r.Field<string>(2);


            //        DonationGv.ClearSelection();
            //    }



            //}
            //catch (Exception ih)
            //{
            //    MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }

        //DONATION_Load_Filter()


        private void DONATION_Load_Filter()
        {


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd.Connection = con;

                    string sqlQuery = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2" +
                        " WHERE Lname LIKE '" + Searchtxt.Text + "%'";

                    // Add condition for YearFrom and YearTo if they have values
                    if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                    {
                        sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                    }

                    sqlQuery += GlobalFilter.OrderBy;
                    cmd.CommandText = sqlQuery;

                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    DonationGv.Rows.Clear();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = DonationGv.Rows.Add();

                        // Set cell values...
                        DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r["Lname"]} {r["Fname"]} {r["Mname"]} {r["Suffix"]}";
                        DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r["Gender"];
                        DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r["GradeLevel"];
                        DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r["LearnerStatus"];
                        DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r["FullName"];
                        DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r["Relationship"];
                        DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r["BrigadaType"];
                        DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r["ContactNo"];
                        DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = r["TotalAmount"];
                        DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r["Tools_Materials"];
                        DonationGv.Rows[rowIndex].Cells["Date2"].Value = r["DateVerified"];
                        DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r["VerifiedBy"];
                        DonationGv.Rows[rowIndex].Cells["DonationTYPE"].Value = r["DonationTYPE"];

                        DonationGv.Rows[rowIndex].Cells["YearFromD"].Value = r["YearFrom"];
                        DonationGv.Rows[rowIndex].Cells["YearToD"].Value = r["YearTo"];
                        DonationGv.Rows[rowIndex].Cells["SchoolYearD"].Value = $"{r["YearFrom"]} - {r["YearTo"]}";

                        DonationGv.Rows[rowIndex].Cells["DLname"].Value = r["Lname"];
                        DonationGv.Rows[rowIndex].Cells["DFname"].Value = r["Fname"];
                        DonationGv.Rows[rowIndex].Cells["DMname"].Value = r["Mname"];
                    }

                    DonationGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        //DONATION_Load_Filter()=====================================
        //DONATION_Load_Filter()=====================================



        public void Volunteer()
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_02_BrigadaVOLUNTEERS2"
                                   + " WHERE Lname LIKE '" + Searchtxt.Text + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    //sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                VolunteerGv.Rows.Clear();
                VolunteerGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = VolunteerGv.Rows.Add();
                    VolunteerGv.Rows[rowIndex].Cells["Students_FullName1"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    VolunteerGv.Rows[rowIndex].Cells["Gender1"].Value = r.Field<string>(4);
                    VolunteerGv.Rows[rowIndex].Cells["Grade1"].Value = r.Field<string>(5);
                    VolunteerGv.Rows[rowIndex].Cells["Learners_Status1"].Value = r.Field<string>(6);
                    VolunteerGv.Rows[rowIndex].Cells["Brigada1"].Value = r.Field<string>(7);
                    VolunteerGv.Rows[rowIndex].Cells["Relationship1"].Value = r.Field<string>(8);
                    VolunteerGv.Rows[rowIndex].Cells["Brigada_Type1"].Value = r.Field<string>(9);
                    VolunteerGv.Rows[rowIndex].Cells["Contact1"].Value = r.Field<string>(10);
                    VolunteerGv.Rows[rowIndex].Cells["Task_Done1"].Value = r.Field<string>(11);
                    VolunteerGv.Rows[rowIndex].Cells["Work_Duration1"].Value = r.Field<string>(12);
                    VolunteerGv.Rows[rowIndex].Cells["Date1"].Value = r.Field<string>(14);
                    VolunteerGv.Rows[rowIndex].Cells["Verified_By1"].Value = r.Field<string>(13);

                    VolunteerGv.Rows[rowIndex].Cells["YearFromV"].Value = r.Field<string>(15);
                    VolunteerGv.Rows[rowIndex].Cells["YearToV"].Value = r.Field<string>(16);
                    VolunteerGv.Rows[rowIndex].Cells["SchoolYearV"].Value = $"{r.Field<string>(15)} - {r.Field<string>(16)}";


                    VolunteerGv.Rows[rowIndex].Cells["VLname"].Value = r.Field<string>(0);
                    VolunteerGv.Rows[rowIndex].Cells["VFname"].Value = r.Field<string>(1);
                    VolunteerGv.Rows[rowIndex].Cells["VMname"].Value = r.Field<string>(2);

                    VolunteerGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //VOLUNTEER_Load_Filter()========================
        private void VOLUNTEER_Load_Filter()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_02_BrigadaVOLUNTEERS2"
                                   + " WHERE Lname LIKE '" + Searchtxt.Text + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                VolunteerGv.Rows.Clear();
                VolunteerGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = VolunteerGv.Rows.Add();
                    VolunteerGv.Rows[rowIndex].Cells["Students_FullName1"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    VolunteerGv.Rows[rowIndex].Cells["Gender1"].Value = r.Field<string>(4);
                    VolunteerGv.Rows[rowIndex].Cells["Grade1"].Value = r.Field<string>(5);
                    VolunteerGv.Rows[rowIndex].Cells["Learners_Status1"].Value = r.Field<string>(6);
                    VolunteerGv.Rows[rowIndex].Cells["Brigada1"].Value = r.Field<string>(7);
                    VolunteerGv.Rows[rowIndex].Cells["Relationship1"].Value = r.Field<string>(8);
                    VolunteerGv.Rows[rowIndex].Cells["Brigada_Type1"].Value = r.Field<string>(9);
                    VolunteerGv.Rows[rowIndex].Cells["Contact1"].Value = r.Field<string>(10);
                    VolunteerGv.Rows[rowIndex].Cells["Task_Done1"].Value = r.Field<string>(11);
                    VolunteerGv.Rows[rowIndex].Cells["Work_Duration1"].Value = r.Field<string>(12);
                    VolunteerGv.Rows[rowIndex].Cells["Date1"].Value = r.Field<string>(14);
                    VolunteerGv.Rows[rowIndex].Cells["Verified_By1"].Value = r.Field<string>(13);

                    VolunteerGv.Rows[rowIndex].Cells["YearFromV"].Value = r.Field<string>(15);
                    VolunteerGv.Rows[rowIndex].Cells["YearToV"].Value = r.Field<string>(16);
                    VolunteerGv.Rows[rowIndex].Cells["SchoolYearV"].Value = $"{r.Field<string>(15)} - {r.Field<string>(16)}";


                    VolunteerGv.Rows[rowIndex].Cells["VLname"].Value = r.Field<string>(0);
                    VolunteerGv.Rows[rowIndex].Cells["VFname"].Value = r.Field<string>(1);
                    VolunteerGv.Rows[rowIndex].Cells["VMname"].Value = r.Field<string>(2);

                    VolunteerGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        //VOLUNTEER_Load_Filter()========================
        //VOLUNTEER_Load_Filter()========================


        //OVERVIEW RECORDS ==============================================================
        //OVERVIEW RECORDS ==============================================================

        public void overview1()
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname LIKE '" + Searchtxt.Text.ToUpper() + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += ") UNION ";

                sqlQuery += "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE '" + Searchtxt.Text.ToUpper() + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += ")" + GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                GenGv.Rows.Clear();
                GenGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = GenGv.Rows.Add();
                    GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    GenGv.Rows[rowIndex].Cells["Gender"].Value = r.Field<string>(4);
                    GenGv.Rows[rowIndex].Cells["Grade"].Value = r.Field<string>(5);
                    GenGv.Rows[rowIndex].Cells["Learners_Status"].Value = r.Field<string>(6);
                    GenGv.Rows[rowIndex].Cells["Brigada"].Value = r.Field<string>(7);
                    GenGv.Rows[rowIndex].Cells["Relationship"].Value = r.Field<string>(8);
                    GenGv.Rows[rowIndex].Cells["Brigada_Type"].Value = r.Field<string>(9);
                    GenGv.Rows[rowIndex].Cells["Contact"].Value = r.Field<string>(10);
                    GenGv.Rows[rowIndex].Cells["Verified_By"].Value = r.Field<string>(11);
                    GenGv.Rows[rowIndex].Cells["Date"].Value = r.Field<string>(12);

                    GenGv.Rows[rowIndex].Cells["YearFromO"].Value = r.Field<string>(13);
                    GenGv.Rows[rowIndex].Cells["YearToO"].Value = r.Field<string>(14);
                    GenGv.Rows[rowIndex].Cells["SchoolYearO"].Value = $"{ r.Field<string>(13)} - {r.Field<string>(14)}";

                    GenGv.Rows[rowIndex].Cells["GLname"].Value = r.Field<string>(0);
                    GenGv.Rows[rowIndex].Cells["GFname"].Value = r.Field<string>(1);
                    GenGv.Rows[rowIndex].Cells["GMname"].Value = r.Field<string>(2);

                    GenGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //OVERVIEW_Load_Filter()======================================
        public void AllRecords()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname LIKE '" + Searchtxt.Text.ToUpper() + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += ") UNION ";

                sqlQuery += "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE '" + Searchtxt.Text.ToUpper() + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += ")" + GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                GenGv.Rows.Clear();
                GenGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = GenGv.Rows.Add();
                    GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    GenGv.Rows[rowIndex].Cells["Gender"].Value = r.Field<string>(4);
                    GenGv.Rows[rowIndex].Cells["Grade"].Value = r.Field<string>(5);
                    GenGv.Rows[rowIndex].Cells["Learners_Status"].Value = r.Field<string>(6);
                    GenGv.Rows[rowIndex].Cells["Brigada"].Value = r.Field<string>(7);
                    GenGv.Rows[rowIndex].Cells["Relationship"].Value = r.Field<string>(8);
                    GenGv.Rows[rowIndex].Cells["Brigada_Type"].Value = r.Field<string>(9);
                    GenGv.Rows[rowIndex].Cells["Contact"].Value = r.Field<string>(10);
                    GenGv.Rows[rowIndex].Cells["Verified_By"].Value = r.Field<string>(11);
                    GenGv.Rows[rowIndex].Cells["Date"].Value = r.Field<string>(12);

                    GenGv.Rows[rowIndex].Cells["YearFromO"].Value = r.Field<string>(13);
                    GenGv.Rows[rowIndex].Cells["YearToO"].Value = r.Field<string>(14);
                    GenGv.Rows[rowIndex].Cells["SchoolYearO"].Value = $"{ r.Field<string>(13)} - {r.Field<string>(14)}";

                    GenGv.Rows[rowIndex].Cells["GLname"].Value = r.Field<string>(0);
                    GenGv.Rows[rowIndex].Cells["GFname"].Value = r.Field<string>(1);
                    GenGv.Rows[rowIndex].Cells["GMname"].Value = r.Field<string>(2);

                    GenGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        //OVERVIEW_Load_Filter()======================================
        //OVERVIEW_Load_Filter()======================================




        public void BrigadaOrganizationDonation()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified, YearFrom, YearTo FROM View_08_OrganizationDONATIONS" +
                                  " WHERE OrganizationName LIKE '%" + Searchtxt.Text + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                BrigadaOrgDonation.Rows.Clear();
                BrigadaOrgDonation.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = BrigadaOrgDonation.Rows.Add();
                    // Set cell values
                    BrigadaOrgDonation.Rows[rowIndex].Cells["OrgName1"].Value = r.Field<string>(0);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["OrgType"].Value = r.Field<string>(1);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["BrigadaType"].Value = r.Field<string>(2);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["DonType"].Value = r.Field<string>(3);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["TotalAmount"].Value = r.Field<Int32>(4);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Tools"].Value = r.Field<string>(5);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Quant"].Value = r.Field<Int32>(6);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Verify"].Value = r.Field<string>(7);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["DateVerify"].Value = r.Field<string>(8);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["YearFromOD"].Value = r.Field<string>(9);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["YearToOD"].Value = r.Field<string>(10);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["SchoolYearOD"].Value = $"{r.Field<string>(9)} - {r.Field<string>(10)}";
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Org_DONATIONS Filter ==================================
        //Org_DONATIONS Filter ==================================
        private void BrigadaOrganizationDonation_Load_Filter()
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified, YearFrom, YearTo FROM View_08_OrganizationDONATIONS" +
                                  " WHERE OrganizationName LIKE '%" + Searchtxt.Text + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                sqlQuery += GlobalFilter.OrderBy;
                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                BrigadaOrgDonation.Rows.Clear();
                BrigadaOrgDonation.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = BrigadaOrgDonation.Rows.Add();
                    // Set cell values
                    BrigadaOrgDonation.Rows[rowIndex].Cells["OrgName1"].Value = r.Field<string>(0);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["OrgType"].Value = r.Field<string>(1);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["BrigadaType"].Value = r.Field<string>(2);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["DonType"].Value = r.Field<string>(3);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["TotalAmount"].Value = r.Field<Int32>(4);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Tools"].Value = r.Field<string>(5);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Quant"].Value = r.Field<Int32>(6);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["Verify"].Value = r.Field<string>(7);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["DateVerify"].Value = r.Field<string>(8);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["YearFromOD"].Value = r.Field<string>(9);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["YearToOD"].Value = r.Field<string>(10);
                    BrigadaOrgDonation.Rows[rowIndex].Cells["SchoolYearOD"].Value = $"{r.Field<string>(9)} - {r.Field<string>(10)}";
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Org_DONATIONS_Filter==============================
        //Org_DONATIONS_Filter==============================


        //Org_VOLUNTEERS====================================

        public void BrigadaOrgVolunteer()
        {
            try{ 
            SqlConnection con = new SqlConnection(cs);
            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;

            string sqlQuery = "SELECT OrganizationName, OrganizationType, BrigadaType, WorkDone, NumberofHours, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_08_OrganizationVOLUNTEER" +
                              " WHERE OrganizationName LIKE '%" + Searchtxt.Text + "%'";

            // Add condition for YearFrom and YearTo if they have values
            if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
            {
                sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
            }

            // Add GlobalFilter.OrderBy
            sqlQuery += GlobalFilter.OrderBy;

            cmd.CommandText = sqlQuery;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);

            OrgVolunteer.Rows.Clear();
            OrgVolunteer.ClearSelection();


            foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = OrgVolunteer.Rows.Add();

                    OrgVolunteer.Rows[rowIndex].Cells["OrgName"].Value = r.Field<string>("OrganizationName");
                    OrgVolunteer.Rows[rowIndex].Cells["OrgeType"].Value = r.Field<string>("OrganizationType");
                    OrgVolunteer.Rows[rowIndex].Cells["BrigType"].Value = r.Field<string>("BrigadaType");
                    OrgVolunteer.Rows[rowIndex].Cells["WorkDone"].Value = r.Field<string>("WorkDone");
                    OrgVolunteer.Rows[rowIndex].Cells["NumofHours"].Value = r.Field<string>("NumberofHours");
                    OrgVolunteer.Rows[rowIndex].Cells["Verified"].Value = r.Field<string>("VerifiedBy");
                    OrgVolunteer.Rows[rowIndex].Cells["DateVerified"].Value = r.Field<string>("DateVerified");

                    // Assuming YearFrom and YearTo are valid column names in the DataTable
                    OrgVolunteer.Rows[rowIndex].Cells["YearFromOV"].Value = r.Field<string>("YearFrom");
                    OrgVolunteer.Rows[rowIndex].Cells["YearToOV"].Value = r.Field<string>("YearTo");

                    // Assuming you want to display SchoolYearOV as a concatenation of YearFrom and YearTo
                    OrgVolunteer.Rows[rowIndex].Cells["SchoolYearOV"].Value = $"{r.Field<string>("YearFrom")} - {r.Field<string>("YearTo")}";
                }

            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        //Org_VOLUNTEERS FILTER====================================



        private void BrigadaOrgVolunteer_Load_Filter()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                string sqlQuery = "SELECT OrganizationName, OrganizationType, BrigadaType, WorkDone, NumberofHours, VerifiedBy, DateVerified, YearFrom, YearTo FROM VIEW_08_OrganizationVOLUNTEER" +
                                  " WHERE OrganizationName LIKE '%" + Searchtxt.Text + "%'";

                // Add condition for YearFrom and YearTo if they have values
                if (!string.IsNullOrWhiteSpace(YearFrom.Text) && !string.IsNullOrWhiteSpace(YearTo.Text))
                {
                    sqlQuery += " AND YearFrom = '" + YearFrom.Text + "' AND YearTo = '" + YearTo.Text + "'";
                }

                // Add GlobalFilter.OrderBy
                sqlQuery += GlobalFilter.OrderBy;

                cmd.CommandText = sqlQuery;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                OrgVolunteer.Rows.Clear();
                OrgVolunteer.ClearSelection();


                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = OrgVolunteer.Rows.Add();

                    OrgVolunteer.Rows[rowIndex].Cells["OrgName"].Value = r.Field<string>("OrganizationName");
                    OrgVolunteer.Rows[rowIndex].Cells["OrgeType"].Value = r.Field<string>("OrganizationType");
                    OrgVolunteer.Rows[rowIndex].Cells["BrigType"].Value = r.Field<string>("BrigadaType");
                    OrgVolunteer.Rows[rowIndex].Cells["WorkDone"].Value = r.Field<string>("WorkDone");
                    OrgVolunteer.Rows[rowIndex].Cells["NumofHours"].Value = r.Field<string>("NumberofHours");
                    OrgVolunteer.Rows[rowIndex].Cells["Verified"].Value = r.Field<string>("VerifiedBy");
                    OrgVolunteer.Rows[rowIndex].Cells["DateVerified"].Value = r.Field<string>("DateVerified");

                    // Assuming YearFrom and YearTo are valid column names in the DataTable
                    OrgVolunteer.Rows[rowIndex].Cells["YearFromOV"].Value = r.Field<string>("YearFrom");
                    OrgVolunteer.Rows[rowIndex].Cells["YearToOV"].Value = r.Field<string>("YearTo");

                    // Assuming you want to display SchoolYearOV as a concatenation of YearFrom and YearTo
                    OrgVolunteer.Rows[rowIndex].Cells["SchoolYearOV"].Value = $"{r.Field<string>("YearFrom")} - {r.Field<string>("YearTo")}";
                }

            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Org_VOLUNTEERS FILTER====================================
        //Org_VOLUNTEERS FILTER====================================



        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Brigadatypcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBrigada.Text = Brigadatypcmb.SelectedItem.ToString();

            int selectedIndex = Brigadatypcmb.SelectedIndex;

        
            VolunteerGv.Hide();
            DonationGv.Hide();
            OrgVolunteer.Hide();
            GenGv.Hide();
            BrigadaOrgDonation.Hide();

         
            switch (selectedIndex)
            {
                case 0:
                    VolunteerGv.Show();
                    Volunteer();
                    break;
                case 1:
                    DonationGv.Show();
                    Donation();
                    break;
                case 2:
                    GenGv.Show();
                    overview1();
                    break;
                case 3: 
                    OrgVolunteer.Show();
                    BrigadaOrgVolunteer();
                    break;
                case 4:
                    BrigadaOrgDonation.Show();
                    BrigadaOrganizationDonation();
                    break;
                default: 
                    GenGv.Show();
                    break;
            }

           
            Searchtxt.Text = "";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FRM_AddRecords add = new FRM_AddRecords();
            add.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (DonationGv.Visible)
            {
                ExportRecord_Donations export1 = new ExportRecord_Donations();
                export1.ShowDialog();
            }
            else if (VolunteerGv.Visible)
            {
                ExportFileVolunteers export2 = new ExportFileVolunteers();
                export2.ShowDialog();
            }
            else if (GenGv.Visible)
            {
                ExportRecord_AllRecords export3 = new ExportRecord_AllRecords();
                export3.ShowDialog();
            }
            //else if (OrgVolunteer.Visible)
            //{
            //    ExportFile_OrgVolunteers export4 = new ExportFile_OrgVolunteers();
            //    export4.ShowDialog();
            //}
            else if (BrigadaOrgDonation.Visible)
            {
                ExportFile_OrgDonations export5 = new ExportFile_OrgDonations();
                export5.ShowDialog();
            }
        }


        public void countRecords()
        {
            //Count REGISTERD STUDENTS

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(StudentInformationID) FROM View_01_StudentInformation  WHERE Student_Status = 1 AND SY_Status = 1", con);
                var count1 = cmd.ExecuteScalar();
                RegisteredStudents.Text = count1.ToString();
                con.Close();
            }


            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_STATUS = 1", con);
                var count1 = cmd.ExecuteScalar();
                TotalDonors.Text = count1.ToString();
                con.Close();

            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE SY_STATUS = 1", con);
                var count1 = cmd.ExecuteScalar();
                TotalVolunteers.Text = count1.ToString();
                con.Close();
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(StudentInformationID) FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE SY_STATUS = 1 UNION SELECT COUNT(StudentInformationID) FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_STATUS = 1", con);
                var count1 = cmd.ExecuteScalar();
                TotalBrigada.Text = count1.ToString();
                con.Close();
            }

        }



        private void Sycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sycmb.Text = Sycmb.SelectedValue.ToString();
            // SelectSY.Text = Sycmb.SelectedItem.ToString();
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            if (DonationGv.Visible == true)
            {
                DONATION_Load_Filter();
            }
            else if (VolunteerGv.Visible == true)
            {
                VOLUNTEER_Load_Filter();
            }
            else if (GenGv.Visible == true)
            {
                AllRecords();
            }
            else if (OrgVolunteer.Visible == true)
            {
                BrigadaOrgVolunteer_Load_Filter();
            }

            else if (BrigadaOrgDonation.Visible == true)
            {
                BrigadaOrganizationDonation_Load_Filter();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            SchoolYear.SelectedItem = "";
            SchoolYearTXT.Text = $"{Global.YearFrom} - {Global.YearTo}";

            YearFrom.Text = "";
            YearTo.Text = "";
            Searchtxt.Text = "";
            clear();
        }

        public void clear()
        {
            if (DonationGv.Visible == true)
            {
                Donation();
            }

            else if (VolunteerGv.Visible == true)
            {
                Volunteer();
            }

            else if (GenGv.Visible == true)
            {
                overview1();
            }

            else if (DonationGv.Visible == true)
            {
                Donation();

            }

            else if (BrigadaOrgDonation.Visible == true)
            {
                BrigadaOrganizationDonation();

            }

            else if (OrgVolunteer.Visible == true)
            {
                BrigadaOrgVolunteer();

            }
        }

        private void SelectedItem_Click(object sender, EventArgs e)
        {
            Orderbycmb.DroppedDown = true;
        }

        private void OrderBy_Click(object sender, EventArgs e)
        {
            Orderbycmb.DroppedDown = true;
        }


        private void panel11_Click(object sender, EventArgs e)
        {
            Brigadatypcmb.DroppedDown = true;
        }

        private void SelectBrigada_Click(object sender, EventArgs e)
        {
            Brigadatypcmb.DroppedDown = true;
        }



        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            TopPannel.Visible = false;
            Show1.Visible = true;
        }

        private void Show1_Click(object sender, EventArgs e)
        {
            TopPannel.Visible = true;
            Show1.Visible = false;
        }

        private void Searchtxt_Enter(object sender, EventArgs e)
        {

        }

        private void Searchtxt_Leave(object sender, EventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {


            ClearContent();
        }

        //Clear Content Textbox
        public void ClearContent()
        {

        }



        // CELL DOUBLE CLICK===================

        private void DonationGv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        //================================================================================


        // UPDATE EDIT RECORDS
        // UPDATE EDIT RECORDS
        private void button3_Click(object sender, EventArgs e)
        {




        }

        public void UnEditable()
        {

        }

        //Cancel Button
        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void EditRecords()
        {

        }

        //Gen DoubleClick
        private void GenGv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //OrgDonation DoubleClick
        private void BrigadaOrgDonation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //OrgVolunteer DoubleClick
        private void OrgVolunteer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BrigadaTypeEOV2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DurationOV2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BrigadaRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DonationType2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TotalAmountEOD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            TextBox text = (TextBox)sender;
            if (text.Text.Length > +4 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TotalAmount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            TextBox text = (TextBox)sender;
            if (text.Text.Length > +4 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel21_Click(object sender, EventArgs e)
        {

        }

        private void panel36_Click(object sender, EventArgs e)
        {

        }

        private void panel42_Click(object sender, EventArgs e)
        {

        }

        private void panel43_Click(object sender, EventArgs e)
        {

        }

        private void Duration2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel45_Click(object sender, EventArgs e)
        {
        }

        private void DurationTXT_Click(object sender, EventArgs e)
        {
        }

        private void panel33_Click(object sender, EventArgs e)
        {
        }

        private void panel40_Click(object sender, EventArgs e)
        {
        }

        private void panel41_Click(object sender, EventArgs e)
        {
        }




        private void SchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (DonationGv.Visible == true)
            {
                DONATION_Load_Filter();
            }
            else if (VolunteerGv.Visible == true)
            {
                VOLUNTEER_Load_Filter();
            }
            else if (GenGv.Visible == true)
            {
                AllRecords();
            }
            else if (OrgVolunteer.Visible == true)
            {
                BrigadaOrgVolunteer_Load_Filter();
            }

            else if (BrigadaOrgDonation.Visible == true)
            {
                BrigadaOrganizationDonation_Load_Filter();
            }


            //LoadSY();

            if (SchoolYear.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)SchoolYear.SelectedItem;
                SchoolYearTXT.Text = selectedRow["SchoolYear"].ToString();
            }
            else
            {
                SchoolYearTXT.Text = "School Year";
            }

        }

        private void panel12_Click(object sender, EventArgs e)
        {
            SchoolYear.DroppedDown = true;
        }

        private void SchoolYearTXT_Click(object sender, EventArgs e)
        {
            SchoolYear.DroppedDown = true;
        }


        // SY Drop down Database
        public void SchoolYearDrop()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT YearFrom, YearTo FROM TBL_09_SchoolYear", con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            dt.Columns.Add("SchoolYear", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["SchoolYear"] = $"{row["YearFrom"]} - {row["YearTo"]}";
            }

            SchoolYear.DataSource = dt;
            SchoolYear.DisplayMember = "SchoolYear";
            SchoolYear.ValueMember = "SchoolYear";

            SchoolYear.SelectedValueChanged += SchoolYear_SelectedValueChanged;

        }

        private void SchoolYear_SelectedValueChanged(object sender, EventArgs e)
        {

            string selectedSchoolYear = SchoolYear.SelectedValue.ToString();

            string[] years = selectedSchoolYear.Split('-');

            YearFrom.Text = years[0].Trim();
            YearTo.Text = years[1].Trim();
        }



        public void YearCMBS()
        {
            //string cs = Global.Connection;
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlConnection con = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("SELECT DISTINCT YearFrom, YearTo FROM TBL_09_SchoolYear", con);
            //da.SelectCommand = cmd;
            //da.Fill(dt);

            //YearFrom.DataSource = dt;
            //YearTo.DataSource = dt;
            //YearFrom.ValueMember = "YearFrom";
            //YearTo.ValueMember = "YearTo";
        }

        // YearFrom CMBS
        private void YearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataRowView selectedRow = (DataRowView)YearFrom.SelectedItem;
            //YearFrom.Text = selectedRow["YearFrom"].ToString();
        }

        // YearTo CMBS
        private void YearTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataRowView selectedRow = (DataRowView)YearFrom.SelectedItem;
            //YearTo.Text = selectedRow["YearFrom"].ToString();
        }

        private void SchoolYear_SelectedValueChanged_1(object sender, EventArgs e)
        {
           // DONATION_Load_Filter();
        }

        private void BrigadaOrgDonation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectReportTXT.Text = comboBox1.SelectedItem.ToString();
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectReportTXT_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void panel23_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
