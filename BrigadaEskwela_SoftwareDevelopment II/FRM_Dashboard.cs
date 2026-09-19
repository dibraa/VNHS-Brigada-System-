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
using System.Runtime.InteropServices;

namespace BrigadaEskwela_SoftwareDevelopment_II
{
    public partial class FRM_Dashboard : Form
    {
      

        public FRM_Dashboard()
        {
            InitializeComponent();

            this.Load += (sender, e) =>
            {        
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            };
          
            // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;

            RecordsPanel.Visible = false;
            CoordinatorBE();
            gridview();

            //listView_Dashboard();
            countRecords();

            GlobalVariable();
            UserButtonVisible();
        


    }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;

        //        Add WS_EX_COMPOSITED style to reduce flickering
        //        cp.ExStyle |= 0x0200000;

        //        Add WS_CLIPCHILDREN style to reduce flickering
        //        cp.Style |= 0x0080000;

        //        return cp;
        //    }
        //}



        string cs = Global.Connection;

        public void Status()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sql = "UPDATE View_09_Users SET Status = 0 WHERE UserID = @userID";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", Global.UserID);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        //public void listView_Dashboard()
        //{
        //    string cs = Global.Connection;
        //    SqlConnection con = new SqlConnection(cs);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand cmd = new SqlCommand();
        //    DataTable dt = new DataTable();

        //    con.ConnectionString = cs;
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "SELECT StudentInformationID, Lname, Mname, Fname, Gender, GradeLevel, LearnerStatus, BrigadaType, DateVerified, VerifiedBy from View_05_BrigadaInfo_Students ";
        //    da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    listView1.Items.Clear();

        //    foreach (DataRow r in dt.Rows)
        //    {
        //        var list = listView1.Items.Add(r.Field<Int32>(0).ToString());

        //        list.SubItems.Add(r.Field<string>(1).ToString() + "  " + r.Field<string>(2).ToString() + "  " + r.Field<string>(3));
        //        list.SubItems.Add(r.Field<string>(4).ToString());
        //        list.SubItems.Add(r.Field<string>(5).ToString());
        //        list.SubItems.Add(r.Field<string>(6).ToString());
        //        list.SubItems.Add(r.Field<string>(7));
        //        list.SubItems.Add(r.Field<string>(8));
        //        list.SubItems.Add(r.Field<string>(9));
        //    }

        //    da.Dispose();
        //    con.Close();

        //}




        public void GlobalVariable()
        {
            Username.Text = Global.Username;
            UserID.Text = Global.UserID;
            Fullname.Text = Global.Fname.ToUpper() + " " + Global.Mname.ToUpper() + " " + Global.Lname.ToUpper();
            AccountType.Text = Global.AccountType;
            SchoolYear.Text = Global.YearFrom + " " + "-" + " " + Global.YearTo;
            SY_ID.Text = Global.SchoolYearID;
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
                TotalAmount.Text = "₱ "+count1.ToString();
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




        public void UserButtonVisible()
        {
            UsersButton.Visible = false;
            if (AccountType.Text.Trim().Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            {
                // Code for Administrator
                UsersButton.Visible = true;
            }
            else
            {
                // Code for User
                UsersButton.Visible = false;
            }
        }


        public void gridview()
        {

            string cs = Global.Connection;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT StudentInformationID,Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,BrigadaType,VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 UNION SELECT StudentInformationID,Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,BrigadaType,VerifiedBy,DateVerified FROM VIEW_03_BrigadaDONATIONS2 WHERE SY_Status = 1";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();

            foreach (DataRow r in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();

                // Set the values for each cell in the DataGridView
                dataGridView1.Rows[rowIndex].Cells["idno"].Value = r.Field<Int32>(0);
                dataGridView1.Rows[rowIndex].Cells["studentname"].Value = $"{r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)} {r.Field<string>(4)}";
                dataGridView1.Rows[rowIndex].Cells["sex"].Value = r.Field<string>(5);
                dataGridView1.Rows[rowIndex].Cells["grade1"].Value = r.Field<string>(6);
                dataGridView1.Rows[rowIndex].Cells["status"].Value = r.Field<string>(7);
                dataGridView1.Rows[rowIndex].Cells["type"].Value = r.Field<string>(8);
                dataGridView1.Rows[rowIndex].Cells["date1"].Value = r.Field<string>(10);
                dataGridView1.Rows[rowIndex].Cells["verify"].Value = r.Field<string>(9);
            }

            dataGridView1.ClearSelection();


        }


        private void button2_Click(object sender, EventArgs e)
        {
            FRM_Login log= new FRM_Login();
            Status();
            log.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordsPanel_Dropdown();
        }

        private void RecordsPanel_Dropdown()
        {
            if (RecordsPanel.Visible == false)
            {
                RecordsPanel.Visible = true;
            }
            else
            {
                RecordsPanel.Visible = false;
            }


        }


        private void button4_Click(object sender, EventArgs e)
        {
            FRM_ViewRecords view = new FRM_ViewRecords();
            view.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_AddRecords view = new FRM_AddRecords();
            view.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRM_CampusMap view = new FRM_CampusMap();
            view.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FRM_Donations view = new FRM_Donations();
            view.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRM_ViewReports report = new FRM_ViewReports();
            report.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRM_AboutUs view = new FRM_AboutUs();
            view.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRM_StudentRegistration view = new FRM_StudentRegistration();
            view.ShowDialog();
        }


        private void DonationsButton_Click(object sender, EventArgs e)
        {
            FRM_Donations view = new FRM_Donations();
            view.ShowDialog();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            FRM_Users user = new FRM_Users();
            user.ShowDialog();
        }


        private void AccountType_Click(object sender, EventArgs e)
        {
            AccountType.Text = Global.AccountType;
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            FRM_Dashboard dash = new FRM_Dashboard();
            dash.Show();

            this.Close();
            
            
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            FRM_Login log = new FRM_Login();
            Status();
            log.Show();
            this.Close();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            TextBox text = (TextBox)sender;
            if(text.Text.Length >+4 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AcademicYear_Click(object sender, EventArgs e)
        {
             FRM_AcademicYear Year = new FRM_AcademicYear();
            Year.ShowDialog();
        }

        private void RegisteredStudents_Click(object sender, EventArgs e)
        {

        }

        public void CoordinatorBE()
        {
            string cs = Global.Connection;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Lname,Fname,Mname,Suffix FROM VIEW_06_BrigadaCoordinator WHERE SY_Status=1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Fullname", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        row["Fullname"] = $"{row["Fname"]} {row["Mname"]} {row["Lname"]} {row["Suffix"]}";
                    }

                    CoordinatorCMB.DataSource = dt;
                    CoordinatorCMB.DisplayMember = "Fullname";
                    CoordinatorCMB.ValueMember = "Lname";

                    Coordinator.Text = CoordinatorCMB.Items.Count > 0 ? CoordinatorCMB.GetItemText(CoordinatorCMB.Items[0]).ToUpper() : "";

                    CoordinatorCMB.SelectedIndexChanged += CoordinatorCMB_SelectedIndexChanged;
                }
            }
        }

        private void CoordinatorCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CoordinatorCMB.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CoordinatorCMB.SelectedItem;
                Coordinator.Text = selectedRow["Fullname"].ToString();
            }
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            CoordinatorCMB.DroppedDown = true;
        }

        private void CoordinatorCMB_Click(object sender, EventArgs e)
        {

        }

        private void Coordinator_Click(object sender, EventArgs e)
        {
            CoordinatorCMB.DroppedDown = true;
        }




        //private void label14_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT COUNT(StudentInformationID) FROM TBL_01_StudentInformation", con);
        //        var count1 = cmd.ExecuteScalar();
        //        label14.Text = count1.ToString();
        //        con.Close();
        //    }
        //}


    }
}
