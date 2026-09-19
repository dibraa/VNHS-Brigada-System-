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
    public partial class FRM_Reports : Form
    {
        public FRM_Reports()
        {
            InitializeComponent();

            //BrigadaDonationsPanel.Visible = false;
            //BrigadaVolunteersPanel.Visible = false;
            //BrigadaOverviewPanel.Visible = true;
            //PARENTpanel.Visible = true;
            GenGv.Visible = true;
            VolunteerGv.Visible = true;
            DonationGv.Visible = true;
            overview1();
            Searchtxt.Text = "";
        }

        string cs = Global.Connection;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        private void Exitbtn_Click(object sender, EventArgs e)
        {
          
        }


        public void Volunteer()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                VolunteerGv.Rows.Clear();
                GenGv.ClearSelection();

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
                    VolunteerGv.Rows[rowIndex].Cells["Date1"].Value = r.Field<string>(13);
                    VolunteerGv.Rows[rowIndex].Cells["Verified_By1"].Value = r.Field<string>(14);
                }

                VolunteerGv.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Donation()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,TotalAmount,Tools_Materials,DateVerified,VerifiedBy FROM VIEW_03_BrigadaDONATIONS2";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                DonationGv.Rows.Clear();
                GenGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = DonationGv.Rows.Add();
                    DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r.Field<string>(4);
                    DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r.Field<string>(5);
                    DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r.Field<string>(6);
                    DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r.Field<string>(7);
                    DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r.Field<string>(8);
                    DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r.Field<string>(9);
                    DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r.Field<string>(10);
                    DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = r.Field<string>(11);
                    DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r.Field<string>(12);
                    DonationGv.Rows[rowIndex].Cells["Date2"].Value = r.Field<string>(13);
                    DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r.Field<string>(14);
                }

                DonationGv.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void overview1()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo, VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 UNION SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo,VerifiedBy, DateVerified FROM VIEW_03_BrigadaDONATIONS2";
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
                    GenGv.Rows[rowIndex].Cells["Date"].Value = r.Field<string>(11);
                    GenGv.Rows[rowIndex].Cells["Verified_By"].Value = r.Field<string>(12);


                    GenGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }









        //int selectedIndex = BrigadaTYPEcmbs2.SelectedIndex;

        //if (selectedIndex == 0)
        //{

        //    BrigadaDonationsPanel.Visible = false;
        //    BrigadaVolunteersPanel.Visible = false;
        //    BrigadaOverviewPanel.Visible = true;
        //    overview1();
        //}
        //if (selectedIndex == 1)
        //{

        //    BrigadaDonationsPanel.Visible = false;
        //    BrigadaVolunteersPanel.Visible = false;
        //    BrigadaOverviewPanel.Visible = true;
        //    overview1();
        //}
        //if (selectedIndex == 2)
        //{

        //    BrigadaDonationsPanel.Visible = false;
        //    BrigadaOverviewPanel.Visible = false;
        //    BrigadaVolunteersPanel.Visible = true;
        //    Volunteer();
        //}
        //else
        //{

        //    BrigadaVolunteersPanel.Visible = false;
        //    BrigadaOverviewPanel.Visible = false;
        //    BrigadaDonationsPanel.Visible = true;
        //    Donation();
        //}

        private void DONATION_Load_Filter()
        {



            try
            {

                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,TotalAmount,Tools_Materials,DateVerified,VerifiedBy FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname like '"
                   + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                DonationGv.Rows.Clear();


                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = DonationGv.Rows.Add();
                    DonationGv.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    DonationGv.Rows[rowIndex].Cells["Gender3"].Value = r.Field<string>(4);
                    DonationGv.Rows[rowIndex].Cells["Grade2"].Value = r.Field<string>(5);
                    DonationGv.Rows[rowIndex].Cells["Learners_Status2"].Value = r.Field<string>(6);
                    DonationGv.Rows[rowIndex].Cells["Brigada2"].Value = r.Field<string>(7);
                    DonationGv.Rows[rowIndex].Cells["Relationship2"].Value = r.Field<string>(8);
                    DonationGv.Rows[rowIndex].Cells["Brigada_Type2"].Value = r.Field<string>(9);
                    DonationGv.Rows[rowIndex].Cells["Contact2"].Value = r.Field<string>(10);
                    DonationGv.Rows[rowIndex].Cells["Total_Amount2"].Value = r.Field<Int32>(11);
                    DonationGv.Rows[rowIndex].Cells["Materials2"].Value = r.Field<string>(12);
                    DonationGv.Rows[rowIndex].Cells["Date2"].Value = r.Field<string>(14);
                    DonationGv.Rows[rowIndex].Cells["Verified_By2"].Value = r.Field<string>(13);
                }

                DonationGv.ClearSelection();

            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private void VOLUNTEER_Load_Filter()
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo,WorkDone,NumberofHours,VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname like '"
                   + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;

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
                }

                VolunteerGv.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AllRecords()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo, VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 WHERE Lname like '" + Searchtxt.Text + "%'" + "UNION SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo,VerifiedBy, DateVerified FROM VIEW_03_BrigadaDONATIONS2 WHERE Lname like '"
                   + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;

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



                    GenGv.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        public void BrigadaOrgVolunteer()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_08_OrganizationVOLUNTEER";
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
        private void BrigadaOrgVolunteer_Load_Filter()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,WorkDone,NumberofHours,VerifiedBy,DateVerified,YearFrom,YearTo FROM VIEW_08_OrganizationVOLUNTEER WHERE OrganizationName '"
                   + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;
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
        public void BrigadaOrganizationDonation()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified,YearFrom,YearTo FROM View_08_OrganizationDONATIONS";
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
                    BrigadaOrgDonation.Rows[rowIndex].Cells["SyYear"].Value = $"{r.Field<string>(9)} {r.Field<string>(10)}";

                    BrigadaOrgDonation.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BrigadaOrganizationDonation_Load_Filter()
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT OrganizationName,OrganizationType,BrigadaType,DonationTYPE,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified,YearFrom,YearTo FROM View_08_OrganizationDONATIONS WHERE OrganizationName like '"
                   + Searchtxt.Text + "%'" + GlobalFilter.OrderBy;
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
                    BrigadaOrgDonation.Rows[rowIndex].Cells["SyYear"].Value = $"{r.Field<string>(9)} {r.Field<string>(10)}";

                    BrigadaOrgDonation.ClearSelection();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                OrderBy.Text = Orderbycmb.SelectedItem.ToString();

                if (Orderbycmb.Text.Trim().Equals("Name - Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY Lname ASC";
                    DONATION_Load_Filter();
                    VOLUNTEER_Load_Filter();
                    AllRecords();
                }

                else if (Orderbycmb.Text.Trim().Equals("Name - Descending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY Lname DESC";
                    DONATION_Load_Filter();
                    VOLUNTEER_Load_Filter();
                    AllRecords();

                }

                else if (Orderbycmb.Text.Trim().Equals("DATE - Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified ASC";
                    DONATION_Load_Filter();
                    VOLUNTEER_Load_Filter();
                    AllRecords();

                }

                else if (Orderbycmb.Text.Trim().Equals("DATE - Descending", StringComparison.OrdinalIgnoreCase))
                {
                    GlobalFilter.OrderBy = " ORDER BY DateVerified DESC";


                }
            }
        }

        private void Brigadatypcmb_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                }
                else if (selectedIndex == 1)
                {
                    DonationGv.Show();
                    VolunteerGv.Hide();
                    OrgVolunteer.Hide();
                    GenGv.Hide();
                    Donation();
                    BrigadaOrgDonation.Hide();
                }
                else if (selectedIndex == 2)
                {
                    DonationGv.Hide();
                    VolunteerGv.Hide();
                    OrgVolunteer.Hide();
                    GenGv.Show();
                    overview1();
                    BrigadaOrgDonation.Hide();
                }
                else if (selectedIndex == 3)
                {
                    OrgVolunteer.Show();
                    DonationGv.Hide();
                    VolunteerGv.Hide();
                    GenGv.Hide();
                    BrigadaOrgDonation.Hide();
                    BrigadaOrgVolunteer();


                }
                else if (selectedIndex == 4)
                {
                    OrgVolunteer.Hide();
                    DonationGv.Hide();
                    VolunteerGv.Hide();
                    GenGv.Hide();
                    BrigadaOrgDonation.Show();
                    BrigadaOrganizationDonation();

                }

                else
                {
                    OrgVolunteer.Hide();
                    DonationGv.Hide();
                    VolunteerGv.Hide();
                    BrigadaOrgDonation.Hide();
                    GenGv.Show();
                }

            }
        }
    }
}

