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
    public partial class FRM_ViewRecords : Form
    {
        public FRM_ViewRecords()
        {
            InitializeComponent();       
            countRecords();

            Searchtxt.Text = "";
            overview1();

            View_EditRecord.Visible = false;

            DonationPanelORG.Visible = false;
            DonatioPanelStudent.Visible = false;

            UpdatePanel.Visible = false;
            UnEditable();

            //Display Data from DB to CMBS
            tasks();
            tasksOrg();

            


            //TypeB.Text = BrigadaTypeE.Text;

            BrigadaTypeE.Text = TextBrigada.Text;
            BrigadaTypeE.Text = BrigadaType2.Text;


        }

        string cs = Global.Connection;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();


        public void Text_CMB()
        {
            //EditOrg
            BrigadaTypeORD.Text = BrigadaTypeEOV2.SelectedItem.ToString();
            DonationTypeORG.Text = DonationTypeEOD2.SelectedItem.ToString();
            VolunterTaskORG.Text = VolunteerTaskOV2.SelectedItem.ToString();
            DurationORG.Text = DurationOV2.SelectedItem.ToString();
            VolunterTask.Text = VolunteerTask22.SelectedItem.ToString();
        }
        // FILTER ORDER BY
        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderBy.Text = Orderbycmb.SelectedItem.ToString();

            if (Orderbycmb.Text.Trim().Equals("Name - Ascending", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY Lname ASC";
                
                
            }

            else if (Orderbycmb.Text.Trim().Equals("Name - Descending", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY Lname DESC";
             
            }

            else if (Orderbycmb.Text.Trim().Equals("DATE - Ascending", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY DateVerified ASC";
               

            }

            else if (Orderbycmb.Text.Trim().Equals("DATE - Descending", StringComparison.OrdinalIgnoreCase))
            {
                GlobalFilter.OrderBy = " ORDER BY DateVerified DESC";
               
            }


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
                overview1();
                
            }




            else if (BrigadaOrgDonation.Visible == true)
            {
                if (Orderbycmb.Text.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName ASC";
                }

                if (Orderbycmb.Text.Trim().Equals("Name - Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName ASC";
                }

                else if (Orderbycmb.Text.Trim().Equals("Name - Descending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName DESC";
                }

                BrigadaOrganizationDonation_Load_Filter();
               
            }

            else if (OrgVolunteer.Visible == true)
            {
                if (Orderbycmb.Text.Trim().Equals("Name - Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName ASC";
                }

                else if (Orderbycmb.Text.Trim().Equals("Name - Descending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY OrganizationName DESC";
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
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE @SearchText AND SY_Status = 1" + GlobalFilter.OrderBy;
                        cmd.Parameters.AddWithValue("@SearchText", Searchtxt.Text + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            DonationGv.Rows.Clear();
                            DonationGv.ClearSelection();

                            foreach (DataRow r in dt.Rows)
                            {
                                int rowIndex = DonationGv.Rows.Add();
                                DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r["Lname"]} {r["Fname"]} {r["Mname"]} {r["Suffix"]}";
                                DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r["Gender"];
                                DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r["GradeLevel"];
                                DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r["LearnerStatus"];
                                DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r["FullName"];
                                DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r["Relationship"];
                                DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r["BrigadaType"];
                                DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r["ContactNo"];
                                DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = Convert.ToInt32(r["TotalAmount"]);
                                DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r["Tools_Materials"];
                                DonationGv.Rows[rowIndex].Cells["Date2"].Value = r["DateVerified"];
                                DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r["VerifiedBy"];
                                DonationGv.Rows[rowIndex].Cells["DonationTYPE"].Value = r["DonationTYPE"];

                                DonationGv.Rows[rowIndex].Cells["DLname"].Value = r["Lname"];
                                DonationGv.Rows[rowIndex].Cells["DFname"].Value = r["Fname"];
                                DonationGv.Rows[rowIndex].Cells["DMname"].Value = r["Mname"];
                            }
                        }
                    }
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //DONATION_Load_Filter()


        private void DONATION_Load_Filter()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, TotalAmount, Tools_Materials, DateVerified, VerifiedBy, DonationTYPE FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE @SearchText AND SY_Status = 1" + GlobalFilter.OrderBy;
                        cmd.Parameters.AddWithValue("@SearchText", Searchtxt.Text + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            DonationGv.Rows.Clear();
                            DonationGv.ClearSelection();

                            foreach (DataRow r in dt.Rows)
                            {
                                int rowIndex = DonationGv.Rows.Add();
                                DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r["Lname"]} {r["Fname"]} {r["Mname"]} {r["Suffix"]}";
                                DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r["Gender"];
                                DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r["GradeLevel"];
                                DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r["LearnerStatus"];
                                DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r["FullName"];
                                DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r["Relationship"];
                                DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r["BrigadaType"];
                                DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r["ContactNo"];
                                DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = Convert.ToInt32(r["TotalAmount"]);
                                DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r["Tools_Materials"];
                                DonationGv.Rows[rowIndex].Cells["Date2"].Value = r["DateVerified"];
                                DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r["VerifiedBy"];
                                DonationGv.Rows[rowIndex].Cells["DonationTYPE"].Value = r["DonationTYPE"];

                                DonationGv.Rows[rowIndex].Cells["DLname"].Value = r["Lname"];
                                DonationGv.Rows[rowIndex].Cells["DFname"].Value = r["Fname"];
                                DonationGv.Rows[rowIndex].Cells["DMname"].Value = r["Mname"];
                            }
                        }
                    }
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
                    cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2"
                                       + " WHERE Lname LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1" + GlobalFilter.OrderBy;
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
                    cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2"
                        + " WHERE Lname LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1" + GlobalFilter.OrderBy;
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

                    VolunteerGv.Rows[rowIndex].Cells["VLname"].Value = r.Field<string>(0);
                    VolunteerGv.Rows[rowIndex].Cells["VFname"].Value = r.Field<string>(1);
                    VolunteerGv.Rows[rowIndex].Cells["VMname"].Value = r.Field<string>(2);
                }

                VolunteerGv.ClearSelection();
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
                    cmd.CommandText = "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname LIKE '"
                                   + Searchtxt.Text.ToUpper() + "%' AND SY_Status = 1)"
                                   + " UNION "
                                   + "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE '"
                                   + Searchtxt.Text.ToUpper() + "%' AND SY_Status = 1)" + GlobalFilter.OrderBy;
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
                    cmd.CommandText = "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname LIKE '"
                                       + Searchtxt.Text.ToUpper() + "%' AND SY_Status = 1)"
                                       + " UNION "
                                       + "(SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo, VerifiedBy, DateVerified FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname LIKE '"
                                       + Searchtxt.Text.ToUpper() + "%' AND SY_Status = 1)" + GlobalFilter.OrderBy;

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
                        GenGv.Rows[rowIndex].Cells["Contact"].Value = r.Field<string>(9);
                        GenGv.Rows[rowIndex].Cells["Brigada_Type"].Value = r.Field<string>(10);
                        GenGv.Rows[rowIndex].Cells["Verified_By"].Value = r.Field<string>(11);
                        GenGv.Rows[rowIndex].Cells["Date"].Value = r.Field<string>(12);

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
                    cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified FROM View_08_OrganizationDONATIONS"
                                    + " WHERE OrganizationName LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1"+ GlobalFilter.OrderBy;
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    BrigadaOrgDonation.Rows.Clear();
                    GenGv.ClearSelection();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = BrigadaOrgDonation.Rows.Add();
                        // GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                        BrigadaOrgDonation.Rows[rowIndex].Cells["OrgName1"].Value = r.Field<string>(0);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["OrgType"].Value = r.Field<string>(1);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["BrigadaType"].Value = r.Field<string>(2);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["DonType"].Value = r.Field<string>(3);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["TotalAmount"].Value = r.Field<Int32>(4);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Tools"].Value = r.Field<string>(5);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Quant"].Value = r.Field<Int32>(6);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Verify"].Value = r.Field<string>(7);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["DateVerify"].Value = r.Field<string>(8);
                        //BrigadaOrgDonation.Rows[rowIndex].Cells["SyYear"].Value = $"{r.Field<string>(9)} {r.Field<string>(10)}";

                        BrigadaOrgDonation.ClearSelection();
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
                    cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified FROM View_08_OrganizationDONATIONS"
                                        + " WHERE OrganizationName LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1" + GlobalFilter.OrderBy;
                da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    BrigadaOrgDonation.Rows.Clear();
                    GenGv.ClearSelection();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = BrigadaOrgDonation.Rows.Add();
                        // GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                        BrigadaOrgDonation.Rows[rowIndex].Cells["OrgName1"].Value = r.Field<string>(0);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["OrgType"].Value = r.Field<string>(1);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["BrigadaType"].Value = r.Field<string>(2);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["DonType"].Value = r.Field<string>(3);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["TotalAmount"].Value = r.Field<Int32>(4);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Tools"].Value = r.Field<string>(5);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Quant"].Value = r.Field<Int32>(6);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["Verify"].Value = r.Field<string>(7);
                        BrigadaOrgDonation.Rows[rowIndex].Cells["DateVerify"].Value = r.Field<string>(8);
                       // BrigadaOrgDonation.Rows[rowIndex].Cells["SyYear"].Value = $"{r.Field<string>(9)} {r.Field<string>(10)}";

                        BrigadaOrgDonation.ClearSelection();
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
              try
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.ConnectionString = cs;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_08_OrganizationVOLUNTEER"
                                + " WHERE OrganizationName LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1" + GlobalFilter.OrderBy;
                da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    OrgVolunteer.Rows.Clear();
                    GenGv.ClearSelection();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = OrgVolunteer.Rows.Add();
                        // GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                        OrgVolunteer.Rows[rowIndex].Cells["OrgName"].Value = r.Field<string>(0);
                        OrgVolunteer.Rows[rowIndex].Cells["OrgeType"].Value = r.Field<string>(1);
                        OrgVolunteer.Rows[rowIndex].Cells["BrigType"].Value = r.Field<string>(2);
                        OrgVolunteer.Rows[rowIndex].Cells["WorkDone"].Value = r.Field<string>(3);
                        OrgVolunteer.Rows[rowIndex].Cells["NumofHours"].Value = r.Field<string>(4);
                        OrgVolunteer.Rows[rowIndex].Cells["Verified"].Value = r.Field<string>(5);
                        OrgVolunteer.Rows[rowIndex].Cells["DateVerified"].Value = r.Field<string>(6);
                        OrgVolunteer.Rows[rowIndex].Cells["Year"].Value = $"{r.Field<string>(7)} {r.Field<string>(8)}";





                        OrgVolunteer.ClearSelection();
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
                    cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_08_OrganizationVOLUNTEER"
                                    + " WHERE OrganizationName LIKE '" + Searchtxt.Text + "%'" + " AND SY_Status = 1" + GlobalFilter.OrderBy;
                da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);

                    OrgVolunteer.Rows.Clear();
                    OrgVolunteer.ClearSelection();

                    foreach (DataRow r in dt.Rows)
                    {
                        int rowIndex = OrgVolunteer.Rows.Add();
                        // GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                        OrgVolunteer.Rows[rowIndex].Cells["OrgName"].Value = r.Field<string>(0);
                        OrgVolunteer.Rows[rowIndex].Cells["OrgeType"].Value = r.Field<string>(1);
                        OrgVolunteer.Rows[rowIndex].Cells["BrigType"].Value = r.Field<string>(2);
                        OrgVolunteer.Rows[rowIndex].Cells["WorkDone"].Value = r.Field<string>(3);
                        OrgVolunteer.Rows[rowIndex].Cells["NumofHours"].Value = r.Field<string>(4);
                        OrgVolunteer.Rows[rowIndex].Cells["Verified"].Value = r.Field<string>(5);
                        OrgVolunteer.Rows[rowIndex].Cells["DateVerified"].Value = r.Field<string>(6);
                        OrgVolunteer.Rows[rowIndex].Cells["Year"].Value = $"{r.Field<string>(7)} {r.Field<string>(8)}";

                        OrgVolunteer.ClearSelection();
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

            if (selectedIndex == 0)
            {
                VolunteerGv.Show();
                DonationGv.Hide();
                OrgVolunteer.Hide();
                GenGv.Hide();
                BrigadaOrgDonation.Hide();
                Volunteer();

                Searchtxt.Text = "";
            }
            else if (selectedIndex == 1)
            {
                DonationGv.Show();
                VolunteerGv.Hide();
                OrgVolunteer.Hide();
                GenGv.Hide();
                Donation();
                BrigadaOrgDonation.Hide();

                Searchtxt.Text = "";
            }
            else if (selectedIndex == 2)
            {
                DonationGv.Hide();
                VolunteerGv.Hide();
                OrgVolunteer.Hide();
                GenGv.Show();
                overview1();
                BrigadaOrgDonation.Hide();

                Searchtxt.Text = "";
            }
            else if (selectedIndex == 3)
            {
                OrgVolunteer.Show();
                DonationGv.Hide();
                VolunteerGv.Hide();
                GenGv.Hide();
                BrigadaOrgDonation.Hide();
                BrigadaOrgVolunteer();

                Searchtxt.Text = "";


            }
            else if (selectedIndex == 4)
            {
                OrgVolunteer.Hide();
                DonationGv.Hide();
                VolunteerGv.Hide();
                GenGv.Hide();
                BrigadaOrgDonation.Show();
                BrigadaOrganizationDonation();

                Searchtxt.Text = "";
            }

            else
            {
                OrgVolunteer.Hide();
                DonationGv.Hide();
                VolunteerGv.Hide();
                BrigadaOrgDonation.Hide();
                GenGv.Show();

                Searchtxt.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FRM_AddRecords add = new FRM_AddRecords();
            add.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FRM_Reports REPS = new FRM_Reports();
            REPS.ShowDialog();
            this.Close();
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
            if(DonationGv.Visible ==true)
            {
                DONATION_Load_Filter();
            }
           else if(VolunteerGv.Visible == true)
            {
                VOLUNTEER_Load_Filter();
            }
            else if (GenGv.Visible==true)
            {
                AllRecords();
            }
           else if(OrgVolunteer.Visible==true)
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
            View_EditRecord.Visible = false;
            UpdatePanel.Visible = false;


            OrdEditPanel.Visible = false;
            orginformation_panel.Visible = false;
            orginformation_panel.Height = 458;
            orginformation_panel.Width = 978;

            ClearContent();
        }

        //Clear Content Textbox
        public void ClearContent()
        {
            Organizationname2.Text = "";
            Organizationtype2.Text = "";
            TotalAmountEOD2.Text = "";
            DonatedToolOD2.Text = "";
            VerifiedByEOV2.Text = "";
            VerifyDateOV2.Text = "";

            Lname.Text = "";
            Fname.Text = "";
            Mname.Text = "";
            Gendertxt.Text = "";
            LearnerStatus.Text = "";
            GradeLevel.Text = "";
            FullName.Text = "";
            BrigadaTypeE.Text = "";
            DonationTypeE.Text = "";
            TotalAmountE.Text = "";
            ContactNo.Text = "";
            DonatedTool.Text = "";
            ToolsQuantity.Text = "";
            BrigadaRelationship.Text = "";
            VolunteerTask.Text = "";
            Duration.Text = "";
            VerifiedByE.Text = "";
            VerifyDate.Text = "";
            SchoolYear.Text = "";
        }



        // CELL DOUBLE CLICK===================

        private void DonationGv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                View_EditRecord.Visible = true;
                orginformation_panel.Visible = false;

            DataGridViewRow row = DonationGv.Rows[e.RowIndex];


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Lname.Text = row.Cells["DLname"].Value.ToString();
                Fname.Text = row.Cells["DFname"].Value.ToString();
                Mname.Text = row.Cells["DMname"].Value.ToString();

                Gendertxt.Text = row.Cells["Gender3"].Value.ToString();
                LearnerStatus.Text = row.Cells["Learners_Status2"].Value.ToString();
                GradeLevel.Text = row.Cells["Grade2"].Value.ToString();

                BrigadaTypeE.Text = row.Cells["Brigada_Type2"].Value.ToString();
                DonationTypeE.Text = row.Cells["DonationTYPE"].Value.ToString();

                TotalAmountE.Text = row.Cells["Total_Amount2"].Value.ToString();

                //VolunteerTask.Text = row.Cells["Volunteer_Task"].Value.ToString();
                //Duration.Text = row.Cells["Duration"].Value.ToString();
                ContactNo.Text = row.Cells["Contact2"].Value.ToString();
                DonatedTool.Text = row.Cells["Materials2"].Value.ToString();
                BrigadaRelationship.Text = row.Cells["Relationship2"].Value.ToString();
                VerifiedByE.Text = row.Cells["Verified_By2"].Value.ToString();

                SchoolYear.Text = Global.YearFrom +" - "+ Global.YearFrom;
                VerifyDate.Text = row.Cells["Date2"].Value.ToString();
            }
        }


        


        //================================================================================


        // UPDATE EDIT RECORDS
        // UPDATE EDIT RECORDS
        private void button3_Click(object sender, EventArgs e)
        {
            

            if (orginformation_panel.Visible==false)
            {
                UpdatePanel.Visible = true;
                EditRecords();
            }

           else if (orginformation_panel.Visible == true)
            {
                UpdatePanel.Visible = true;
                EditRecords();
                OrdEditPanel.Visible = true;
                orginformation_panel.Visible = false;
                //orginformation_panel.Height = 1;
                //orginformation_panel.Width = 1;

                Organizationname2.Text = Organizationname.Text;
                Organizationtype2.Text = Organizationtype.Text;
                BrigadaTypeEOV2.Text = BrigadaTypeEOV.Text;

                //BrigadaTypeEOV3.Text = DonationTypeEOD.Text;
                TotalAmountEOD2.Text = TotalAmountEOD.Text;
                DonatedToolOD2.Text = DonatedToolOD.Text;
                ToolsQuantityOD2.Text = ToolsQuantityOD.Text;
                DonationTypeEOD2.Text = DonationTypeEOD.Text;

                VolunteerTaskOV2.Text = VolunteerTaskOV.Text;
                DurationOV2.Text = DurationOV.Text;

                //d.Text = d.Text;

                VerifiedByEOV2.Text = VerifiedByEOV.Text;
                VerifyDateOV2.Text = VerifyDateOV.Text;
                SchoolYearOV2.Text = SchoolYearOV.Text;
            }

            else
            {
                UpdatePanel.Visible = true;
                EditRecords();
                OrdEditPanel.Visible = true;
                orginformation_panel.Visible = false;
                //orginformation_panel.Height = 1;
                //orginformation_panel.Width = 1;

                Organizationname2.Text = Organizationname.Text;
                Organizationtype2.Text = Organizationtype.Text;
                BrigadaTypeEOV2.Text = BrigadaTypeEOV.Text;

                //BrigadaTypeEOV3.Text = DonationTypeEOD.Text;
                TotalAmountEOD2.Text = TotalAmountEOD.Text;
                DonatedToolOD2.Text = DonatedToolOD.Text;
                ToolsQuantityOD2.Text = ToolsQuantityOD.Text;
                DonationTypeEOD2.Text = DonationTypeEOD.Text;

                VolunteerTaskOV2.Text = VolunteerTaskOV.Text;
                DurationOV2.Text = DurationOV.Text;

                //d.Text = d.Text;

                VerifiedByEOV2.Text = VerifiedByEOV.Text;
                VerifyDateOV2.Text = VerifyDateOV.Text;
                SchoolYearOV2.Text = SchoolYearOV.Text;
            }    
 
        }

        public void UnEditable()
        {
            //Read only Org Record:
            Organizationname.ReadOnly = true;
            Organizationtype.ReadOnly = true;
            ContactOrg.ReadOnly = true;
            BrigadaTypeEOV.ReadOnly = true;
            DonationTypeEOD.ReadOnly = true;
            TotalAmountEOD.ReadOnly = true;
            DonatedToolOD.ReadOnly = true;
            ToolsQuantityOD.ReadOnly = true;
            VolunteerTaskOV.ReadOnly = true;
            DurationOV.ReadOnly = true;
            VerifiedByEOV.ReadOnly = true;
            VerifyDateOV.ReadOnly = true;
            SchoolYearOV.ReadOnly = true;

            Organizationname.BackColor = Color.White;
            Organizationtype.BackColor = Color.White;
            ContactOrg.BackColor = Color.White;
            BrigadaTypeEOV.BackColor = Color.White;
            DonationTypeEOD.BackColor = Color.White;
            TotalAmountEOD.BackColor = Color.White;
            DonatedToolOD.BackColor = Color.White;
            ToolsQuantityOD.BackColor = Color.White;
            VolunteerTaskOV.BackColor = Color.White;
            DurationOV.BackColor = Color.White;
            VerifiedByEOV.BackColor = Color.White;
            VerifyDateOV.BackColor = Color.White;
            SchoolYearOV.BackColor = Color.White;


            EditRecords();
            //Read only Student Record
            Lname.ReadOnly = true;
            Fname.ReadOnly = true;
            Mname.ReadOnly = true;
            Gendertxt.ReadOnly = true;
            LearnerStatus.ReadOnly = true;
            GradeLevel.ReadOnly = true;
            FullName.ReadOnly = true;
            BrigadaTypeE.ReadOnly = true;           
            ContactNo.ReadOnly = true;
            DonationTypeE.ReadOnly = true;
            DonationTypeE.ReadOnly = true;
            TotalAmountE.ReadOnly = true;
            DonatedTool.ReadOnly = true;
            ToolsQuantity.ReadOnly = true;
            VolunteerTask.ReadOnly = true;
            Duration.ReadOnly = true;

            BrigadaRelationship.ReadOnly = true;           
            
            VerifiedByE.ReadOnly = true;
            VerifyDate.ReadOnly = true;
            SchoolYear.ReadOnly = true;

            // Set background color to white for each control
            Lname.BackColor = Color.White;
            Fname.BackColor = Color.White;
            Mname.BackColor = Color.White;
            Gendertxt.BackColor = Color.White;
            LearnerStatus.BackColor = Color.White;
            GradeLevel.BackColor = Color.White;
            FullName.BackColor = Color.White;
            BrigadaTypeE.BackColor = Color.White;
            DonationTypeE.BackColor = Color.White;
            TotalAmountE.BackColor = Color.White;
            ContactNo.BackColor = Color.White;
            DonatedTool.BackColor = Color.White;
            ToolsQuantity.BackColor = Color.White;
            BrigadaRelationship.BackColor = Color.White;
            VolunteerTask.BackColor = Color.White;
            Duration.BackColor = Color.White;
            VerifiedByE.BackColor = Color.White;
            VerifyDate.BackColor = Color.White;
            SchoolYear.BackColor = Color.White;

        }

        //Cancel Button
        private void button5_Click(object sender, EventArgs e)
        {
            if (OrdEditPanel.Visible == true)
            {
                orginformation_panel.Visible = true;
                //orginformation_panel.Height = 458;
                //orginformation_panel.Width = 978;
            }

            UpdatePanel.Visible = false;

            Lname.ReadOnly = true;
            Fname.ReadOnly = true;
            Mname.ReadOnly = true;
            Gendertxt.ReadOnly = true;
            LearnerStatus.ReadOnly = true;
            GradeLevel.ReadOnly = true;
            FullName.ReadOnly = true;
            BrigadaTypeE.ReadOnly = false;
            DonationTypeE.ReadOnly = false;
            TotalAmountE.ReadOnly = true;
            ContactNo.ReadOnly = true;
            DonatedTool.ReadOnly = true;
            ToolsQuantity.ReadOnly = true;

            BrigadaRelationship.ReadOnly = true;

            VolunteerTask.ReadOnly = true;
            Duration.ReadOnly = true;
            VerifiedByE.ReadOnly = true;
            VerifyDate.ReadOnly = true;
            SchoolYear.ReadOnly = true;

            // Set background color to white for each control
            Lname.BackColor = Color.White;
            Fname.BackColor = Color.White;
            Mname.BackColor = Color.White;
            Gendertxt.BackColor = Color.White;
            LearnerStatus.BackColor = Color.White;
            GradeLevel.BackColor = Color.White;
            FullName.BackColor = Color.White;
            BrigadaTypeE.BackColor = Color.White;
            DonationTypeE.BackColor = Color.White;
            TotalAmountE.BackColor = Color.White;
            ContactNo.BackColor = Color.White;
            DonatedTool.BackColor = Color.White;
            ToolsQuantity.BackColor = Color.White;
            BrigadaRelationship.BackColor = Color.White;
            VolunteerTask.BackColor = Color.White;
            Duration.BackColor = Color.White;
            VerifiedByE.BackColor = Color.White;
            VerifyDate.BackColor = Color.White;
            SchoolYear.BackColor = Color.White;         
        }

        //Volunteer DoubleClick
        private void VolunteerGv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            View_EditRecord.Visible = true;
            orginformation_panel.Visible = false;

            DataGridViewRow row = VolunteerGv.Rows[e.RowIndex];

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Lname.Text = row.Cells["VLname"].Value.ToString();
                Fname.Text = row.Cells["VFname"].Value.ToString();
                Mname.Text = row.Cells["VMname"].Value.ToString();

                Gendertxt.Text = row.Cells["Gender1"].Value.ToString();
                LearnerStatus.Text = row.Cells["Learners_Status1"].Value.ToString();
                GradeLevel.Text = row.Cells["Grade1"].Value.ToString();

                BrigadaTypeE.Text = row.Cells["Brigada_Type1"].Value.ToString();

                //DonationTypeE.Text = row.Cells["Materials2"].Value.ToString();
                //TotalAmountE.Text = row.Cells["Total_Amount2"].Value.ToString();
                //DonatedTool.Text = row.Cells["Materials2"].Value.ToString();


                VolunteerTask.Text = row.Cells["Task_Done1"].Value.ToString();
                Duration.Text = row.Cells["Work_Duration1"].Value.ToString();
                VolunteerTask.Text = row.Cells["Task_Done1"].Value.ToString();



                FullName.Text = row.Cells["Brigada1"].Value.ToString();
                BrigadaRelationship.Text = row.Cells["Relationship1"].Value.ToString();
                ContactNo.Text = row.Cells["Contact1"].Value.ToString();

                VerifiedByE.Text = row.Cells["Verified_By1"].Value.ToString();

                SchoolYear.Text = Global.YearFrom + " - " + Global.YearFrom;
                VerifyDate.Text = row.Cells["Date1"].Value.ToString();
            }
            else
            {

            }

        }

        public void EditRecords()
        {
            //if (BrigadaType2.Text == "Volunteer")
            //{
            //    DonationType2.DroppedDown = false;
            //    DonationType2.Text = "Please Select";
            //    DonationType2.BackColor = Color.WhiteSmoke;

            //    TotalAmount2.ReadOnly = true;
            //    TotalAmount2.Text = "Please Select";
            //    TotalAmount2.BackColor = Color.WhiteSmoke;

            //    DonatedTool2.ReadOnly = true;
            //    DonatedTool2.Text = "Please Select";
            //    DonatedTool2.BackColor = Color.WhiteSmoke;

            //    Quantity2.ReadOnly = true;
            //    Quantity2.Text = "Please Select";
            //    Quantity2.BackColor = Color.WhiteSmoke;

            //}

            //else if (BrigadaType2.Text == "Donation")
            //{
            //    VolunteerTask22.DroppedDown = false;
            //    VolunteerTask22.Text = "Please Select";
            //    VolunteerTask22.BackColor = Color.WhiteSmoke;

            //    Duration2.DroppedDown = false;
            //    Duration2.Text = "Please Select";
            //    Duration2.BackColor = Color.WhiteSmoke;
            //}


            Lname2.Text = Lname.Text;
            Fname2.Text = Fname.Text;
            Mname2.Text = Mname.Text;

            Gender22.Text = Gendertxt.Text;
            LearnerStatus2.Text = LearnerStatus.Text;
            GradeLevel2.Text =GradeLevel.Text;
            BrigadaRelationship2.Text = BrigadaRelationship.Text;

            BrigadaType2.Text = BrigadaTypeE.Text;

            DonationType2.Text =DonationTypeE.Text;
            TotalAmount2.Text = TotalAmountE.Text;
            DonatedTool2.Text = DonatedTool.Text;
            Quantity2.Text = ToolsQuantity.Text;

            VolunteerTask22.Text = VolunteerTask.Text;
            Duration2.Text = Duration.Text;
            VolunteerTask22.Text = VolunteerTask.Text;


            Fullname2.Text = FullName.Text;
            
            BrigadaRelationship2.Text = BrigadaRelationship.Text;
            ContactNo2.Text = ContactNo.Text;

            VerifiedByE2.Text = VerifiedByE.Text;

            SchoolYear2.Text = Global.YearFrom + " - " + Global.YearFrom;
            VerifyDate2.Text = VerifyDate.Text;      
        }

        public void tasks()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT BrigadaTASKS_ID, WorkDone FROM TBL_04_BrigadaTASKS", con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            DataRow itemrow = dt.NewRow();
            dt.Rows.InsertAt(itemrow, 0);


            VolunteerTask22.DataSource = dt;
            VolunteerTask22.DisplayMember = "WorkDone";
            VolunteerTask22.ValueMember = "BrigadaTASKS_ID";

        }

        public void tasksOrg()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT BrigadaTASKS_ID, WorkDone FROM TBL_04_BrigadaTASKS", con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            DataRow itemrow = dt.NewRow();
            dt.Rows.InsertAt(itemrow, 0);

            VolunteerTaskOV2.DataSource = dt;
            VolunteerTaskOV2.DisplayMember = "WorkDone";
            VolunteerTaskOV2.ValueMember = "BrigadaTASKS_ID";
        }

        private void VolunteerTask22_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (VolunteerTask22.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)VolunteerTask22.SelectedItem;
                VolunterTask.Text = selectedRow["WorkDone"].ToString();
                TaskID.Text = selectedRow["BrigadaTASKS_ID"].ToString();
            }
        }

        private void BrigadaType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(BrigadaType2.Text=="Volunteer")
            {
                DonatioPanelStudent.Visible = false;
            }
            else
            {
                DonatioPanelStudent.Visible = true;
            }

            TextBrigada.Text = BrigadaType2.Text;
            UpdatePanel.Visible = true;

            //if (BrigadaType2.Text == "Volunteer")
            //{
            //    // Disable donation-related textboxes
            //    DonationTypeE.ReadOnly = true;
            //    TotalAmountE.ReadOnly = true;
            //    DonatedTool.ReadOnly = true;
            //    ToolsQuantity.ReadOnly = true;

            //    // Change the background color to indicate they're disabled
            //    DonationTypeE.BackColor = Color.White;
            //    TotalAmountE.BackColor = Color.WhiteSmoke;
            //    DonatedTool.BackColor = Color.WhiteSmoke;
            //    ToolsQuantity.BackColor = Color.WhiteSmoke;

            //    // You might want to provide some visual cue to the user that these fields are disabled, like changing the background color or adding a tooltip
            //}

            //else if (BrigadaType2.Text == "Donation")
            //{
            //    // Disable volunteer-related textboxes
            //    VolunteerTask.ReadOnly = true;
            //    Duration.ReadOnly = true;

            //    // Change the background color to indicate they're disabled
            //    VolunteerTask.BackColor = Color.WhiteSmoke;
            //    Duration.BackColor = Color.WhiteSmoke;
            //}

        }

        //Gen DoubleClick
        private void GenGv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View_EditRecord.Visible = true;
            orginformation_panel.Visible = false;

            DataGridViewRow row = GenGv.Rows[e.RowIndex];


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Lname.Text = row.Cells["GLname"].Value.ToString();
                Fname.Text = row.Cells["GFname"].Value.ToString();
                Mname.Text = row.Cells["GMname"].Value.ToString();

                Gendertxt.Text = row.Cells["Gender"].Value.ToString();
                LearnerStatus.Text = row.Cells["Learners_Status"].Value.ToString();
                GradeLevel.Text = row.Cells["Grade"].Value.ToString();
                BrigadaTypeE.Text = row.Cells["Brigada_Type"].Value.ToString();
                //VolunteerTask.Text = row.Cells["Volunteer_Task"].Value.ToString();
                //Duration.Text = row.Cells["Duration"].Value.ToString();
                ContactNo.Text = row.Cells["Contact"].Value.ToString();
                BrigadaRelationship.Text = row.Cells["Relationship"].Value.ToString();
                VerifiedByE.Text = row.Cells["Verified_By"].Value.ToString();
                SchoolYear.Text = Global.YearFrom + " - " + Global.YearFrom;
                VerifyDate.Text = row.Cells["Date"].Value.ToString();
            }
        }

        //OrgDonation DoubleClick
        private void BrigadaOrgDonation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View_EditRecord.Visible = true;
            orginformation_panel.Visible = true;

          
           //Form Background = new Form();
           // FRM_AboutUs Model = new FRM_AboutUs();
           // using (Model)
           // {
           //     Background.StartPosition = FormStartPosition.Manual;
           //     Background.FormBorderStyle = FormBorderStyle.None;
           //     Background.Opacity = 0.7d;
           //     Background.Size = this.Size;
           //     Background.Location = this.Location;
           //     Background.ShowInTaskbar = false;
           //     Background.Show(this);
           //     Model.Owner = Background;
           //     Model.ShowDialog(Background);
           //     Background.Dispose();
           // }


             DataGridViewRow row = BrigadaOrgDonation.Rows[e.RowIndex];


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Organizationname.Text = row.Cells["OrgName1"].Value.ToString();
                Organizationtype.Text = row.Cells["OrgType"].Value.ToString();
                BrigadaTypeEOV.Text = row.Cells["BrigadaType"].Value.ToString();

                DonationTypeEOD.Text = row.Cells["DonType"].Value.ToString();
                TotalAmountEOD.Text = row.Cells["TotalAmount"].Value.ToString();
                DonatedToolOD.Text = row.Cells["Tools"].Value.ToString();
                ToolsQuantityOD.Text = row.Cells["Quant"].Value.ToString();


                VerifiedByEOV.Text = row.Cells["Verify"].Value.ToString();
                VerifyDateOV.Text = row.Cells["DateVerify"].Value.ToString();
                SchoolYearOV.Text = Global.YearFrom + " - " + Global.YearFrom;


            }
        }

        //OrgVolunteer DoubleClick
        private void OrgVolunteer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View_EditRecord.Visible = true;
            orginformation_panel.Visible = true;

            DataGridViewRow row = OrgVolunteer.Rows[e.RowIndex];


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Organizationname.Text = row.Cells["OrgName"].Value.ToString();
                Organizationtype.Text = row.Cells["OrgeType"].Value.ToString();
                BrigadaTypeEOV.Text = row.Cells["BrigType"].Value.ToString();
                VolunteerTaskOV.Text = row.Cells["WorkDone"].Value.ToString();
                DurationOV.Text = row.Cells["NumofHours"].Value.ToString();
                VerifiedByEOV.Text = row.Cells["Verified"].Value.ToString();
                VerifyDateOV.Text = row.Cells["DateVerified"].Value.ToString();

                SchoolYearOV.Text = Global.YearFrom + " - " + Global.YearFrom;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BrigadaTypeEOV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrigadaTypeORD.Text = BrigadaTypeEOV2.SelectedItem.ToString();

            if(BrigadaTypeEOV2.Text == "Volunteer")
            {
                DonationPanelORG.Visible = false;
            }

            else
            {
                DonationPanelORG.Visible = true;
            }
        }

        private void DonationTypeEOD2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DonationTypeORG.Text = DonationTypeEOD2.SelectedItem.ToString();
        }

        private void VolunteerTaskOV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VolunteerTaskOV2.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)VolunteerTaskOV2.SelectedItem;
                VolunterTaskORG.Text = selectedRow["WorkDone"].ToString();
                VtaskOrgID.Text = selectedRow["BrigadaTASKS_ID"].ToString();
            }
        }

        private void DurationOV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DurationORG.Text = DurationOV2.SelectedItem.ToString();
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
            BrigadaTypeEOV2.DroppedDown = true;
        }

        private void panel36_Click(object sender, EventArgs e)
        {
            DonationTypeEOD2.DroppedDown = true;
        }

        private void panel42_Click(object sender, EventArgs e)
        {
            VolunteerTaskOV2.DroppedDown = true;
        }

        private void panel43_Click(object sender, EventArgs e)
        {
            DurationOV2.DroppedDown = true;
        }

        private void Duration2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DurationTXT.Text = Duration2.SelectedItem.ToString();
        }

        private void panel45_Click(object sender, EventArgs e)
        {
            Duration2.DroppedDown = true;
        }

        private void DurationTXT_Click(object sender, EventArgs e)
        {
            Duration2.DroppedDown = true;
        }

        private void panel33_Click(object sender, EventArgs e)
        {
            BrigadaType2.DroppedDown = true;
        }

        private void panel40_Click(object sender, EventArgs e)
        {
            VolunteerTask22.DroppedDown = true;
        }

        private void panel41_Click(object sender, EventArgs e)
        {
            BrigadaRelationship2.DroppedDown = true;
        }

        private void BrigadaOrgDonation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }











        //public void SchoolYear_CMBS()
        //{

        //    string cs = Global.Connection;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("SELECT YearFrom, YearTo FROM TBL_09_SchoolYear", con);
        //    da.SelectCommand = cmd;
        //    da.Fill(dt);

        //    // Create a new column to hold the concatenated values
        //    dt.Columns.Add("YearRange", typeof(string));

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        // Concatenate YearFrom and YearTo and store in YearRange column
        //        row["YearRange"] = row["YearFrom"].ToString() + " - " + row["YearTo"].ToString();
        //    }

        //    // Insert an empty row at the beginning
        //    DataRow itemrow = dt.NewRow();
        //    dt.Rows.InsertAt(itemrow, 0);

        //    // Set the DataSource, DisplayMember, and ValueMember properties
        //    Sycmb.DataSource = dt;
        //    Sycmb.DisplayMember = "YearRange";
        //    Sycmb.ValueMember = "YearFrom"; // or you can set it to "YearRange" if needed


        //}
        //private void Sycmb_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    SchoolYear_CMBS();
        //}
    }
}
