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
    public partial class FRM_AddRecords : Form
    {
        public FRM_AddRecords()
        {
            InitializeComponent();
            Donation.Visible = false;
            DonationPanel.Visible = false;
            OrganizationPanel.Visible = false;
            STask.Text= "Please Select";
            //listView();
            GridView();  // Student GridView
            Gridview2(); // Org GridView
            tasks();

           

        }
        public void listView()
        {
            {
            //    //ListView - Display Data
            //    string cs = Global.Connection;
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    SqlCommand cmd = new SqlCommand();
            //    DataTable dt = new DataTable();
            //    //string id = Global.teacherID;


            //    SqlConnection con = new SqlConnection(cs);
            //    con.ConnectionString = cs;
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "SELECT StudentInformationID,Lname, Fname, Mname, Gender from View_03_StudentInformation";
            //    da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    dt = new DataTable();
            //    da.Fill(dt);
            //   // StudentsListView.Items.Clear();
            //    foreach (DataRow r in dt.Rows)
            //    {
            ////        var list = StudentsListView.Items.Add(r.Field<Int32>(0).ToString());

            //        list.SubItems.Add(r.Field<string>(1)+ " " + r.Field<string>(2).ToString() + " " + r.Field<string>(3).ToString());
            //        list.SubItems.Add(r.Field<string>(4));


            //    }

            //    da.Dispose();
            //    con.Close();

            }

        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void OrgBrigadaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            {

                VolunteerPanel.Show();
                int selectedIndex = OrgBrigadaType.SelectedIndex;

                if (selectedIndex == 0)
                {
                    VolunteerPanel.Show();
                    DonationPanel.Visible = true;
                }
                else if (selectedIndex == 1)
                {
                    DonationPanel.Hide();
                    VolunteerPanel.Show();
                }
                else
                {
                    DonationPanel.Hide();
                    VolunteerPanel.Hide();
                }
            }
        }


        private void Donation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrganizationPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizationPanel.Visible = false;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            {
                VolunteerPanel.Visible = true;
                int selectedIndex = OrgBrigadaType.SelectedIndex;

                if (selectedIndex == 0)
                {
                   VolunteerPanel.Show();
                    DonationPanel.Visible = false;
                }
                else if (selectedIndex == 1)
                {
                    DonationPanel.Visible = true;
                    VolunteerPanel.Visible = false;
                }
                else
                {
                    DonationPanel.Visible = false;
                    VolunteerPanel.Visible = false;
                }
               
            }
          }

        private void button10_Click(object sender, EventArgs e)
        {
            OrganizationPanel.Visible = false;

        }

        public void AddRecord_Student()
        {
            //string cs = Global.Connection;

            //try
            //{
            //    SqlConnection con = new SqlConnection(cs);
            //    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_01_StudentInformation (Lname, Fname, Mname, Suffix, Gender) VALUES (@Lname, @Fname, @Mname, @Gender)");
            //    cmd.Connection = con;
            //    con.Open();
            //    cmd.Parameters.AddWithValue("@Lname", Lname.Text);
            //    cmd.Parameters.AddWithValue("@Fname", Fname.Text);
            //    cmd.Parameters.AddWithValue("@Mname", Mname.Text);
            //    cmd.Parameters.AddWithValue("@Gender", Gender.Text);
            //    cmd.Parameters.AddWithValue("@GradeLevel", GradeLevel.Text);


            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Saving new student in error " + ex.Message);
            //}

        }


        public void BrigadaRecords()
        {
            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (BrigadaType.Text.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
                {
                    Volunteer.Show();
                    Donation.Visible = false;



                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_03_BrigadaVOLUNTEERS2 (StudentInformationID,BrigadaTypeID,BrigadaTASKS_ID,FullName,Relationship,ContactNo,NumberofHours,VerifiedBy,DateVerified) VALUES (@StudentInformationID,@BrigadaTypeID,@BrigadaTASKS_ID,@FullName,@Relationship,@ContactNo,@NumberofHours,@VerifiedBy,@DateVerified)");
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@FullName", FullName.Text);
                    cmd.Parameters.AddWithValue("@Relationship", Relationship.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNo.Text);

                    int brigadaType1 = 1;

                    if (BrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
                    {
                        brigadaType1 = 1;

                    }
                    else
                    {
                        brigadaType1 = 1;
                    }


                    cmd.Parameters.AddWithValue("@BrigadaTASKS_ID", TaskID.Text);

                    cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                    cmd.Parameters.AddWithValue("@VerifiedBy", SVerifiedBy.Text);
                    cmd.Parameters.AddWithValue("@DateVerified", SDateVerified.Text);
                    cmd.Parameters.AddWithValue("@NumberofHours", WorkHours.Text);
                    cmd.Parameters.AddWithValue("@StudentInformationID", StudentID.Text);


                    cmd.ExecuteNonQuery();
                    con.Close();


                }

                else if (BrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_03_BrigadaVOLUNTEERS2 (StudentInformationID,BrigadaTypeID,BrigadaTASKS_ID,FullName,Relationship,ContactNo,NumberofHours,VerifiedBy,DateVerified) VALUES (@StudentInformationID,@BrigadaTypeID,@BrigadaTASKS_ID,@FullName,@Relationship,@ContactNo,@NumberofHours,@VerifiedBy,@DateVerified)");
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@FullName", FullName.Text);
                    cmd.Parameters.AddWithValue("@Relationship", Relationship.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNo.Text);

                    int brigadaType1 = 1;

                    if (BrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
                    {
                        brigadaType1 = 1;

                    }
                    else
                    {
                        brigadaType1 = 1;
                    }


                    cmd.Parameters.AddWithValue("@BrigadaTASKS_ID", TaskID.Text);

                    cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                    cmd.Parameters.AddWithValue("@VerifiedBy", SVerifiedBy.Text);
                    cmd.Parameters.AddWithValue("@DateVerified", SDateVerified.Text);
                    cmd.Parameters.AddWithValue("@NumberofHours", WorkHours.Text);
                    cmd.Parameters.AddWithValue("@StudentInformationID", StudentID.Text);


                    cmd.ExecuteNonQuery();
                    con.Close();


                }

                else if (BrigadaType.Text.Trim().Equals("Donation", StringComparison.OrdinalIgnoreCase))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_06_BrigadaDONATIONS2 (StudentInformationID,BrigadaTypeID,FullName,Relationship,ContactNo,TotalAmount,Tools_Materials,Quantity,VerifiedBy,DateVerified,DonationTypeID) VALUES (@StudentInformationID,@BrigadaTypeID,@FullName,@Relationship,@ContactNo,@TotalAmount,@Tools_Materials,@Quantity,@VerifiedBy,@DateVerified,@DonationTypeID)");
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@FullName", FullName.Text);
                    cmd.Parameters.AddWithValue("@Relationship", Relationship.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNo.Text);

                    int brigadaType1 = 2;
                    int brigadaDonationTYPE;
                    if (DonationType.Text.Trim().Equals("Money", StringComparison.OrdinalIgnoreCase))
                    {
                        brigadaDonationTYPE = 1;

                    }
                    else
                    {
                        brigadaDonationTYPE = 2;
                    }
                    cmd.Parameters.AddWithValue("@DonationTypeID", brigadaDonationTYPE);

                    cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                    cmd.Parameters.AddWithValue("@VerifiedBy", SVerifiedBy.Text);
                    cmd.Parameters.AddWithValue("@DateVerified", SDateVerified.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount.Text);
                    cmd.Parameters.AddWithValue("@Tools_Materials", MaterialName.Text);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);
                    cmd.Parameters.AddWithValue("@StudentInformationID", StudentID.Text);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }


                MessageBox.Show(Lname.Text + " " + Fname.Text + " Successfully Added!", "Add New Brigada Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //MessageBox.Show(Lname.Text + "" + Fname.Text + " Successfully Added! ", "Add New Brigada Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            catch (Exception ex)
            {
                MessageBox.Show("Adding New Record ERROR " + ex.Message);

            }


        }

        public void ORGBRIGADA()
        {
            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);

                if (OrgBrigadaType.Text.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
                {
                    VolunteerPanel.Show();
                    DonationPanel.Visible = false;

                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_Brigada_ORGANIZATION (OrganizationName, OrganizationType, BrigadaTypeID, BrigadaTASKS_ID, NumberofHours, VerifiedBy, DateVerified) VALUES (@OrganizationName, @OrganizationType, @BrigadaTypeID, @BrigadaTASKS_ID, @NumberofHours, @VerifiedBy, @DateVerified)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@OrganizationName", OrgName.Text);
                    cmd.Parameters.AddWithValue("@OrganizationType", OrgType.Text);

                    int brigadaType1 = 1; // Assuming default value is 1

                    cmd.Parameters.AddWithValue("@BrigadaTASKS_ID", TaskID.Text);
                    cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                    cmd.Parameters.AddWithValue("@NumberofHours", OrgHours.Text);
                    cmd.Parameters.AddWithValue("@VerifiedBy", OrgVerifiedBy.Text);
                    cmd.Parameters.AddWithValue("@DateVerified", OrgDateVerified.Text);
                    cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                else if (OrgBrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
                {
                    VolunteerPanel.Show();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_Brigada_ORGANIZATION (SchoolYear_ID, BrigadaTypeID, BrigadaTASKS_ID, OrganizationName, OrganizationType, NumberofHours, VerifiedBy, DateVerified) VALUES (@SchoolYear_ID, @BrigadaTypeID, @BrigadaTASKS_ID, @OrganizationName, @OrganizationType, @NumberofHours, @VerifiedBy, @DateVerified)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@OrganizationName", OrgName.Text);
                    cmd.Parameters.AddWithValue("@OrganizationType", OrgType.Text);

                    int brigadaType1 = 1; // Assuming default value is 1

                    cmd.Parameters.AddWithValue("@BrigadaTASKS_ID", TaskIDOrg.Text);
                    cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                    cmd.Parameters.AddWithValue("@VerifiedBy", OrgVerifiedBy.Text);
                    cmd.Parameters.AddWithValue("@DateVerified", OrgDateVerified.Text);
                    cmd.Parameters.AddWithValue("@NumberofHours", OrgHours.Text);
                    cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                else if (OrgBrigadaType.Text.Trim().Equals("Donation", StringComparison.OrdinalIgnoreCase))
                {
                    DonationPanel.Visible = true;


                    if (DonationType.Text.Trim().Equals("Money", StringComparison.OrdinalIgnoreCase))
                    {
                        MaterialName.ReadOnly = true;
                        Quantity.ReadOnly = true;

                        // Check if user entered data in Materials fields when Money is selected
                        if (!string.IsNullOrWhiteSpace(MaterialName.Text) || !string.IsNullOrWhiteSpace(Quantity.Text))
                        {
                            MessageBox.Show("Error! Enter only Total Amount for Money Donation Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the method to prevent further execution
                        }
                    }
                    else
                    {
                        TotalAmount.ReadOnly = true;
                    }

                    if ((!string.IsNullOrWhiteSpace(TotalAmount.Text) && !string.IsNullOrWhiteSpace(MaterialName.Text)) ||
                        (string.IsNullOrWhiteSpace(TotalAmount.Text) && string.IsNullOrWhiteSpace(MaterialName.Text)))
                    {
                        MessageBox.Show("Error! Enter only one entry for Donation Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Proceed with the insertion if only one entry for Donation Type is provided
                        SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_Brigada_ORGANIZATION (OrganizationName,OrganizationType,VerifiedBy,DateVerified,Tools_Materials,TotalAmount,Quantity,BrigadaTypeID,DonationTypeID) VALUES (@OrganizationName,@OrganizationType,@VerifiedBy,@DateVerified,@Tools_Materials,@TotalAmount,@Quantity,@BrigadaTypeID,@DonationTypeID)");
                        cmd.Connection = con;
                        con.Open();

                        // Set parameter values
                        cmd.Parameters.AddWithValue("@OrganizationName", OrgName.Text);
                        cmd.Parameters.AddWithValue("@OrganizationType", OrgType.Text);
                        cmd.Parameters.AddWithValue("@VerifiedBy", OrgVerifiedBy.Text);

                        int brigadaType1 = 2;
                        int brigadaDonationTYPE;
                        if (DonationType.Text.Trim().Equals("Money", StringComparison.OrdinalIgnoreCase))
                        {
                            brigadaDonationTYPE = 1;
                        }
                        else
                        {
                            brigadaDonationTYPE = 2;
                        }
                        cmd.Parameters.AddWithValue("@DonationTypeID", brigadaDonationTYPE);

                        cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaType1);
                        cmd.Parameters.AddWithValue("@VerifiedBy", OrgVerifiedBy.Text);
                        cmd.Parameters.AddWithValue("@DateVerified", OrgDateVerified.Text);
                        cmd.Parameters.AddWithValue("@TotalAmount", OrgTotalAmount.Text);
                        cmd.Parameters.AddWithValue("@Tools_Materials", OrgMaterialName.Text);
                        cmd.Parameters.AddWithValue("@Quantity", OrgQuantity.Text);
                    

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show(Lname.Text + " " + Fname.Text + " Successfully Added!", "Add New Brigada Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Re-enable disabled fields after the insertion
                    MaterialName.ReadOnly = false;
                    Quantity.ReadOnly = false;
                    TotalAmount.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adding New Record ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                }
        public void BrigadaVolunteers()
        {

            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_03_BrigadaVOLUNTEERS (StudentInformationID,BrigadaTypeID, BrigadaTASKS_ID) VALUES (@StudentInformationID,@BrigadaTypeID,@BrigadaTASKS_ID)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@StudentInformationID", StudentID.Text);
                int brigadaVolunteer;

                if (BrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
                {
                    brigadaVolunteer = 1;

                }
                else
                {
                    brigadaVolunteer = 1;
                }

                cmd.Parameters.AddWithValue("@BrigadaTypeID", brigadaVolunteer);
                cmd.Parameters.AddWithValue("@BrigadaTASKS_ID", TaskID.Text);


                cmd.ExecuteNonQuery();
                con.Close();




            }

            catch (Exception ex)
            {
                MessageBox.Show("Adding New Record ERROR " + ex.Message);

            }
        }

        public void BrigadaDonations()
        {

            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_06_BrigadaDONATIONS (BrigadaTypeID, StudentInformationID, TotalAmount, Material_ToolName, Quantity, DonationTypeID) VALUES (@BrigadaTypeID, @StudentInformationID, @TotalAmount, @Material_ToolName, @Quantity, @DonationTypeID)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@StudentInformationID", StudentID.Text);

                int brigadaDonationTYPE;

                if (DonationType.Text.Trim().Equals("Money", StringComparison.OrdinalIgnoreCase))
                {
                    brigadaDonationTYPE = 1;

                }
                else
                {
                    brigadaDonationTYPE = 2;
                }

                int BrigadaType = 2;
                cmd.Parameters.AddWithValue("@DonationTypeID", brigadaDonationTYPE);
                cmd.Parameters.AddWithValue("@BrigadaTypeID", BrigadaType);
                cmd.Parameters.AddWithValue("@Material_ToolName",MaterialName.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);


                cmd.ExecuteNonQuery();
                con.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show("Adding New Record ERROR " + ex.Message);

            }

        }

        public void ClearForms()
        {
            Lname.Text = "";
            Mname.Text = "";
            Fname.Text = "";
            Gender.Text = "";
            GradeLevel.Text = "";
            LearnerStatus.Text = "";
            BrigadaType.Text = " Please Select";
            TaskDoneCMB.Text = " Please Select";
            WorkHours.Text = " Please Select";
            DonationType.Text = " Please Select";
            MaterialName.Text = "";
            Quantity.Text = "";
            TotalAmount.Text = "";
            SVerifiedBy.Text = "";
            Relationship.Text = "Please Select";
            ContactNo.Text = "";



            OrgName.Text = "";
            OrgType.Text = "";
            OrgBrigadaType.Text = "";      
            OrgDonationType.Text ="";
            OrgQuantity.Text = "";
            OrgMaterialName.Text = "";
            OrgHours.Text = "";
            OrgTask.Text = "";
            OrgVerifiedBy.Text = "";


        }

        public void Gridview2()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(cs);
            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT BrigadaOrganizationID, OrganizationName, OrganizationType FROM View_08_OrganizationDONATIONS UNION SELECT BrigadaOrganizationID, OrganizationName, OrganizationType FROM VIEW_08_OrganizationVOLUNTEER "; //WHERE SY_STATUS = 1
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.Rows.Clear();
            dataGridView2.ClearSelection();

            foreach (DataRow r in dt.Rows)
            {
                int RowIndex = dataGridView2.Rows.Add();


                {
                    if (RowIndex >= 0)

                        // Set the values for each cell in the DataGridView
                        dataGridView2.Rows[RowIndex].Cells["OrgID"].Value = r.Field<Int32>(0);
                    dataGridView2.Rows[RowIndex].Cells["OrgName1"].Value = r.Field<string>(1);
                    dataGridView2.Rows[RowIndex].Cells["OrgType1"].Value = r.Field<string>(2);




                }
            }

            dataGridView1.ClearSelection();

        }

        private void DonationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            BrigadaRecords();
            AddRecord_Student();
            
            ClearForms();
        }


        public void BrigadaOrgRecords()
        {
            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_Brigada_ORGANIZATION (UserID,SchoolYear_ID,OrganizationName,OrganizationType,BrigadaType,VerifiedBy,DateVerified) VALUES(@UserID,@SchoolYear_ID,@OrganizationName,@OrganizationType,@BrigadaType,@VerifiedBy,@DateVerified)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@OrganizationName", OrgName.Text);
                cmd.Parameters.AddWithValue("@OrganizationType", OrgType.Text);
                cmd.Parameters.AddWithValue("@BrigadaType", OrgBrigadaType.Text);
                cmd.Parameters.AddWithValue("@VerifiedBy", OrgVerifiedBy.Text);
                cmd.Parameters.AddWithValue("@DateVerified", OrgDateVerified.Text);       

                cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);
                

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(OrgName.Text + " Successfully Added!", "Add New Brigada Record", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (Exception ex)
            {
                MessageBox.Show("Adding New Record ERROR" + ex.Message);

            }
        }

        public void GridView()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(cs);
            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT StudentInformationID, Lname, Fname, Mname, Gender, GradeLevel, LearnerStatus FROM VIEW_01_StudentInformation WHERE SY_STATUS = 1 ORDER BY StudentInformationID DESC;"; //WHERE SY_STATUS = 1
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();

            foreach (DataRow r in dt.Rows)
            {
                int RowIndex = dataGridView1.Rows.Add();


                {
                    if (RowIndex >= 0)

                        // Set the values for each cell in the DataGridView
                        dataGridView1.Rows[RowIndex].Cells["StudentInfo"].Value = r.Field<Int32>(0);
                    dataGridView1.Rows[RowIndex].Cells["FullName1"].Value = $"{r.Field<string>(1)}  {r.Field<string>(2)} {r.Field<string>(3)}";

                    dataGridView1.Rows[RowIndex].Cells["Lname1"].Value = r.Field<string>(1);
                    dataGridView1.Rows[RowIndex].Cells["Fname1"].Value = r.Field<string>(2);
                    dataGridView1.Rows[RowIndex].Cells["Mname1"].Value = r.Field<string>(3);

                    dataGridView1.Rows[RowIndex].Cells["Gender1"].Value = r.Field<string>(4);
                    dataGridView1.Rows[RowIndex].Cells["GradeLevel1"].Value = r.Field<string>(5);
                    dataGridView1.Rows[RowIndex].Cells["LearnerStatus1"].Value = r.Field<string>(6);



                }
            }

            dataGridView1.ClearSelection();

        }

        


        //Organization Submit Button
        private void button5_Click(object sender, EventArgs e)
        {
            BrigadaOrgRecords();
            ClearForms();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Rows = this.dataGridView1.Rows[e.RowIndex];

                StudentID.Text = Rows.Cells["StudentInfo"].Value.ToString();
                Lname.Text = Rows.Cells["Lname1"].Value.ToString();
                Fname.Text = Rows.Cells["Fname1"].Value.ToString();
                Mname.Text = Rows.Cells["Mname1"].Value.ToString();
                Gender.Text = Rows.Cells["Gender1"].Value.ToString();
                GradeLevel.Text = Rows.Cells["Gradelevel1"].Value.ToString();
                LearnerStatus.Text = Rows.Cells["LearnerStatus1"].Value.ToString();

            }
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

            TaskDoneCMB.DataSource = dt;
            TaskDoneCMB.DisplayMember = "WorkDone";
            TaskDoneCMB.ValueMember = "BrigadaTASKS_ID";

            // Display "Please Select" initially in the STask textbox
            STask.Text = "Please Select";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TaskDoneCMB.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)TaskDoneCMB.SelectedItem;
                TaskID.Text = selectedRow["BrigadaTASKS_ID"].ToString();
                STask.Text = selectedRow["WorkDone"].ToString(); // Display WorkDone in STask textbox
            }
            else
            {
                STask.Text = "Please Select";
            }
        }


        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrgTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TotalAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void OrgBrigadaType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (OrgBrigadaType.Text.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
            {
                VolunteerPanel.Show();
                DonationPanel.Visible = false;
            }
            else if (OrgBrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
            {
                VolunteerPanel.Show();
                DonationPanel.Visible = false;
            }

            else if (OrgBrigadaType.Text.Trim().Equals("Donation", StringComparison.OrdinalIgnoreCase))
            {
                VolunteerPanel.Hide();
                DonationPanel.Visible = true;             
            }

            TypeB.Text = OrgBrigadaType.SelectedItem.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            BrigadaOrgRecords();
            ORGBRIGADA();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrganizationPanel.Visible = false;
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void WorkHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            HDuration.Text = WorkHours.SelectedItem.ToString();
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            BrigadaType.DroppedDown = true;
        }

        private void DonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DType.Text = DonationType.SelectedItem.ToString();

            if(DonationType.Text == "Materials/Tools")
            {
                MaterialsPanel.Visible = true;
            }
            else
            {
                MaterialsPanel.Visible = false;
            }
        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {
            Relationship.DroppedDown = true;
        }


       
        private void panel27_Click(object sender, EventArgs e)
        {
            TaskDoneCMB.DroppedDown = true;
        }

        private void panel28_DoubleClick(object sender, EventArgs e)
        {
            WorkHours.DroppedDown = true;
        }

        private void OrgTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            TDone1.Text = OrgTask.SelectedItem.ToString();
        }

        private void panel29_Click(object sender, EventArgs e)
        {
            OrgTask.DroppedDown = true;
        }

        private void OrgHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            DurationOrg.Text = OrgHours.SelectedItem.ToString();
        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Click(object sender, EventArgs e)
        {
            OrgHours.DroppedDown = true;
        }

        private void OrgDonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DonationOrg.Text = OrgDonationType.SelectedItem.ToString();
            if(OrgDonationType.Text=="Materials/Tools")
            {
                MaterialsPanelORG.Visible = true;
            }
            else
            {
                MaterialsPanelORG.Visible = false;
            }
        }

        private void panel31_Click(object sender, EventArgs e)
        {
            OrgDonationType.DroppedDown = true;
        }

        private void panel26_Click(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DurationOrg_Click(object sender, EventArgs e)
        {
            OrgHours.DroppedDown = true;
        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectedItem_Click(object sender, EventArgs e)
        {
            OrgBrigadaType.DroppedDown = true;
        }

        private void OrgTotalAmount_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel28_DoubleClick_1(object sender, EventArgs e)
        {

        }

        private void panel28_Click(object sender, EventArgs e)
        {
            WorkHours.DroppedDown = true;
        }

        private void panel26_Click_1(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void RType_Click(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void STask_Click(object sender, EventArgs e)
        {
            TaskDoneCMB.DroppedDown = true;
        }

        private void HDuration_Click(object sender, EventArgs e)
        {
            WorkHours.DroppedDown = true;

        }

        private void RelationshipTEXT_Click(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void panel23_Click(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void DType_Click(object sender, EventArgs e)
        {
            DonationType.DroppedDown = true;
        }

        private void panel25_Click(object sender, EventArgs e)
        {
            DonationType.DroppedDown = true;
        }


        private void Relationship_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RelationshipTXT.Text = Relationship.SelectedItem.ToString();
        }

        private void RelationshipTXT_Click(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private void panel23_Click_1(object sender, EventArgs e)
        {
            Relationship.DroppedDown = true;
        }

        private bool brigadaTypeEventProcessing = false;

        private void BrigadaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            brigadaTypeEventProcessing = true;
           
            SelectBrigada.Text = BrigadaType.SelectedItem.ToString();

            if (BrigadaType.Text.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
            {
                Volunteer.Show();
                Donation.Visible = false;
            }
            else if (BrigadaType.Text.Trim().Equals("Volunteer", StringComparison.OrdinalIgnoreCase))
            {
                Volunteer.Show();
                Donation.Visible = false;
            }
            else if (BrigadaType.Text.Trim().Equals("Donation", StringComparison.OrdinalIgnoreCase))
            {
                Volunteer.Hide();
                Donation.Visible = true;
            }

            brigadaTypeEventProcessing = false;

        }

       
    }
}
