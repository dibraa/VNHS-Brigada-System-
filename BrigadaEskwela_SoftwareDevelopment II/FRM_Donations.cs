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
    public partial class FRM_Donations : Form
    {
        public FRM_Donations()
        {
            InitializeComponent();
            ToolsGridVIEW();
            UseDonationPanel.Visible = false;
            MaterialsPanel.Visible = false;
            ReportsPanel.Visible = false;
            ToolsMaterialsPanel.Visible = false;

            count();

            ToolsDonation();
            MoneyDonation();

            Gikuhakay.Text = Global.Fname + " " + Global.Mname + " " + Global.Lname;

            DonationGv.ClearSelection();
            ToolsGV.ClearSelection();
            dataGridView4.ClearSelection();
            dataGridView3.ClearSelection();

        }

        string cs = Global.Connection;
        public void count()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(StudentInformationID) FROM View_01_StudentInformation  WHERE Student_Status = 1 AND SY_Status = 1", con);
                var count1 = cmd.ExecuteScalar();
                Total_Brigada.Text = count1.ToString();
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
                SqlCommand cmd = new SqlCommand("SELECT SUM(Quantity) FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_STATUS = 1", con);
                var count1 = cmd.ExecuteScalar();
                ToolsDonated.Text = count1.ToString();
                con.Close();
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(TotalAmount) FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_STATUS = 1", con);
                var count1 = cmd.ExecuteScalar();
                TotalAmount.Text = "₱ " + count1.ToString();
                con.Close();
            }

        }


        public void ToolsDonation()
        {

            string cs = Global.Connection;         
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,ContactNo,Tools_Materials,DateVerified,VerifiedBy FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_Status=1 and Tools_Materials >'' ";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                ToolsGV.Rows.Clear();
                ToolsGV.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = ToolsGV.Rows.Add();
                    ToolsGV.Rows[rowIndex].Cells["Students_FullName2"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    ToolsGV.Rows[rowIndex].Cells["Gender3"].Value = r.Field<string>(4);
                    ToolsGV.Rows[rowIndex].Cells["Grade2"].Value = r.Field<string>(5);
                    ToolsGV.Rows[rowIndex].Cells["Learners_Status2"].Value = r.Field<string>(6);
                    ToolsGV.Rows[rowIndex].Cells["Brigada2"].Value = r.Field<string>(7);
                    ToolsGV.Rows[rowIndex].Cells["Relationship2"].Value = r.Field<string>(8);
                    
                    ToolsGV.Rows[rowIndex].Cells["Contact2"].Value = r.Field<string>(9);
                    
                    ToolsGV.Rows[rowIndex].Cells["Materials2"].Value = r.Field<string>(10);
                    ToolsGV.Rows[rowIndex].Cells["Date2"].Value = r.Field<string>(11);
                    ToolsGV.Rows[rowIndex].Cells["Verified_By2"].Value = r.Field<string>(12);
                }

                ToolsGV.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MoneyDonation()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,ContactNo,TotalAmount,DateVerified,VerifiedBy FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_Status=1 and TotalAmount > 0";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                DonationGv.Rows.Clear();
                DonationGv.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = DonationGv.Rows.Add();
                    DonationGv.Rows[rowIndex].Cells["StudentsFullname"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
                    DonationGv.Rows[rowIndex].Cells["GenderM"].Value = r.Field<string>(4);
                    DonationGv.Rows[rowIndex].Cells["GradeM"].Value = r.Field<string>(5);
                    DonationGv.Rows[rowIndex].Cells["StatusM"].Value = r.Field<string>(6);
                    DonationGv.Rows[rowIndex].Cells["RepresentativeM"].Value = r.Field<string>(7);
                    DonationGv.Rows[rowIndex].Cells["RelationshipM"].Value = r.Field<string>(8);
                    DonationGv.Rows[rowIndex].Cells["ContactM"].Value = r.Field<string>(9);
                    DonationGv.Rows[rowIndex].Cells["TotalM"].Value = r.Field<Int32>(10);
                    DonationGv.Rows[rowIndex].Cells["DateM"].Value = r.Field<string>(11);
                    DonationGv.Rows[rowIndex].Cells["VerifiedM"].Value = r.Field<string>(12);
                }

                DonationGv.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Volunteerlv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterialsPanel.Visible = true;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FRM_AddRecords add = new FRM_AddRecords();
            add.ShowDialog();
            this.Close();
        }

        

        private void button5_Click_1(object sender, EventArgs e)
        {
           UseDonationPanel.Visible=false;
        }

    
        private void button14_Click_1(object sender, EventArgs e)
        {
            MaterialsPanel.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MaterialsPanel.Visible = true;
            ReportsPanel.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MoneyDonationsPanel.Visible = true;
            ReportsPanel.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ReportsPanel.Visible = true;
            MaterialsPanel.Visible = false;
        }

       

        private void button10_Click_1(object sender, EventArgs e)
        {
            if(MaterialsPanel.Visible==false && ReportsPanel.Visible==false)
            {
                UseDonationPanel.Visible = true;
            }
            else if(MaterialsPanel.Visible == true && ReportsPanel.Visible == false)
                {
                ToolsMaterialsPanel.Visible = true;
                }
        }


        // MoneyDonations GridView
        public void MoneyDonationsGV()
        {
            
                string cs = Global.Connection;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT TotalAmount, Purpose, TakenBy, TakenFrom, DateTaken, Proof FROM TBL_07_MoneyDonationsReport";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dataGridView4.Rows.Clear();
                dataGridView4.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int RowIndex = dataGridView4.Rows.Add();


                    {
                        if (RowIndex >= 0)

                            // Set the values for each cell in the DataGridView
                            dataGridView4.Rows[RowIndex].Cells["TotalAmount2"].Value = r.Field<string>(0);
                        dataGridView4.Rows[RowIndex].Cells["Purpose3"].Value = r.Field<string>(1);
                        dataGridView4.Rows[RowIndex].Cells["TakenBy3"].Value = r.Field<string>(2);
                        dataGridView4.Rows[RowIndex].Cells["TakenFrom2"].Value = r.Field<string>(3);
                        dataGridView4.Rows[RowIndex].Cells["DateTaken2"].Value = r.Field<string>(4);
                        dataGridView4.Rows[RowIndex].Cells["Proof3"].Value = r.Field<string>(5);



                    }
                

                dataGridView4.ClearSelection();
             }
            

        }

        public void ToolsGridVIEW()
        {
                          
                string cs = Global.Connection;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Tool_MaterialName, Quantity, Purpose, TakenBy, TakenFrom, Date, Proof FROM TBL_08_ToolsDonationsReport";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.Rows.Clear();
                dataGridView3.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int RowIndex = dataGridView3.Rows.Add();


                    {
                        if (RowIndex >= 0)

                        // Set the values for each cell in the DataGridView
                        dataGridView3.Rows[RowIndex].Cells["Tool_MaterialName"].Value = r.Field<string>(0);
                        dataGridView3.Rows[RowIndex].Cells["Quantity1"].Value = r.Field<string>(1);
                        dataGridView3.Rows[RowIndex].Cells["Purpose1"].Value = r.Field<string>(2);
                        dataGridView3.Rows[RowIndex].Cells["TakenBy1"].Value = r.Field<string>(3);
                        dataGridView3.Rows[RowIndex].Cells["TakenFrom1"].Value = r.Field<string>(4);
                        dataGridView3.Rows[RowIndex].Cells["Date1"].Value = r.Field<string>(5);
                        dataGridView3.Rows[RowIndex].Cells["Proof1"].Value = r.Field<string>(6);
  
                   }

                dataGridView3.ClearSelection();

                }
            
        }


        private void button9_Click_1(object sender, EventArgs e)
        {
            UseDonationPanel.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }


        //INSERT TOOL MONEY RECORD
        private void Login_Click(object sender, EventArgs e)
        {
            string cs = Global.Connection;
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_07_MoneyDonationsReport (UserID,SchoolYear_ID,TotalAmount, Purpose,TakenBy,TakenFrom,DateTaken) VALUES (@UserID,@SchoolYear_ID,@Amount, @Purpose21, @TakenBy,@TakenFrom,@DateTaken)");
                cmd.Connection = con;
                con.Open();

                
                cmd.Parameters.AddWithValue("@Amount", Amount.Text);
                cmd.Parameters.AddWithValue("@Purpose21", Purpose21.Text);
                cmd.Parameters.AddWithValue("@TakenBy", Gikuha.Text);
                cmd.Parameters.AddWithValue("@TakenFrom", Gikuhakay.Text);
                cmd.Parameters.AddWithValue("@DateTaken", DateGikawat.Text);
                cmd.Parameters.AddWithValue("@UserID", Global.UserID); 
                cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Successfully Added!", "Use Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MoneyDonationsGV();
                UseDonationPanel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        //INSERT TOOL RECORD
        private void button18_Click(object sender, EventArgs e)
        {
            string cs = Global.Connection;
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_08_ToolsDonationsReport (SchoolYear_ID,UserID,Tool_MaterialName,Quantity,Purpose,TakenBy,TakenFrom,Date) VALUES (@SchoolYear_ID,@UserID,@Tool_MaterialName,@Quantity,@Purpose,@TakenBy,@TakenFrom,@Date)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Tool_MaterialName", ToolName.Text);
                cmd.Parameters.AddWithValue("@Purpose", ToolPurpose.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);
                cmd.Parameters.AddWithValue("@Date", ToolDate.Text);
                cmd.Parameters.AddWithValue("@TakenBy", TakenBy2.Text);
                cmd.Parameters.AddWithValue("@TakenFrom", Taken2.Text); 
                cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);
                cmd.Parameters.AddWithValue("@UserID", Global.UserID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Successfully Added!", "Use Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ToolsGridVIEW();
                ToolsMaterialsPanel.Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ToolsMaterialsPanel.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ToolsMaterialsPanel.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DonationsPanel.Visible = true;
            MaterialsPanel.Visible = false;
        }

        private void MaterialsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            ReportsPanel.Visible = true;
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportsPanel.Visible = true;
            ToolsMaterialsPanel.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           MaterialsPanel.Visible = true;
            ReportsPanel.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MoneyDonationsPanel.Visible = true;
            ReportsPanel.Visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            if (MaterialsPanel.Visible == false && ReportsPanel.Visible == false)
            {
                UseDonationPanel.Visible = true;
            }
            else if (MaterialsPanel.Visible == true && ReportsPanel.Visible == false)
            {
                ToolsMaterialsPanel.Visible = true;
            }
        }

        private void Taken2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void Brigadatypcmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedIndex = Brigadatypcmb.SelectedIndex;

            if (selectedIndex == 0)
            {
                dataGridView4.Show();
                dataGridView3.Hide();
                MoneyDonationsGV();
            }
            else
            {
                dataGridView4.Hide();
                dataGridView3.Show();
                ToolsGridVIEW();
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            MaterialsPanel.Visible = true;
            ReportsPanel.Visible = false;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            ReportsPanel.Visible = false;
            MaterialsPanel.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ReportsPanel.Visible = true;
            MaterialsPanel.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MaterialsPanel.Visible = false;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            ToolsMaterialsPanel.Visible = false;
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            ToolsMaterialsPanel.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UseDonationPanel.Visible = false;
        }

        private void TotalDonors_Click(object sender, EventArgs e)
        {

        }
    }
}
