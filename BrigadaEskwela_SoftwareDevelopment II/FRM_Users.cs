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
    public partial class FRM_Users : Form
    {
        public FRM_Users()
        {
            InitializeComponent();

            UserListView();

            SchoolYear.Text = Global.YearFrom + "-" + Global.YearTo;

            VisibleFalse_Panel();
            TeacherGradeLevelCMBS();
            SchoolYearTXT.Text = Global.YearFrom + "-" + Global.YearTo;
            SY_TASKS.Text = Global.YearFrom + "-" + Global.YearTo;
            CoordinatorGV();


            gridview();
            BrigadaTASKS();

        }
        string cs = Global.Connection;


        public void VisibleFalse_Panel()
        {
            AddUserPanel.Visible = false;
            AssignedTeacher.Visible = false;
            BrigadaTaskPanel.Visible = false;
            AddTeacherPanel.Visible = false;
            AddBrigadaTasks.Visible = false;
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
            cmd.CommandText = "SELECT UserID, UserLname, UserFname, UserMname, Gender, ContactNumber, AccountRole, YearFrom, YearTo, Username, Password, Status FROM View_09_Users";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("StatusText", typeof(string), "IIF(Status = 1, 'Online', 'Offline')");

            dataGridView.Rows.Clear();
            dataGridView.ClearSelection();

            foreach (DataRow r in dt.Rows)
            {
                int rowIndex = dataGridView.Rows.Add();

                // Set the values for each cell in the DataGridView
                dataGridView.Rows[rowIndex].Cells["UserID"].Value = r.Field<int>(0);
                dataGridView.Rows[rowIndex].Cells["UserLname"].Value = r.Field<string>(1);
                dataGridView.Rows[rowIndex].Cells["UserFname"].Value = r.Field<string>(2);
                dataGridView.Rows[rowIndex].Cells["UserMname"].Value = r.Field<string>(3);
                dataGridView.Rows[rowIndex].Cells["Gender1"].Value = r.Field<string>(4);
                dataGridView.Rows[rowIndex].Cells["ContactNum"].Value = r.Field<string>(5);
                dataGridView.Rows[rowIndex].Cells["Account"].Value = r.Field<string>(6);
                dataGridView.Rows[rowIndex].Cells["School"].Value = $"{r.Field<string>(7)} - {r.Field<string>(8)}";
                dataGridView.Rows[rowIndex].Cells["User"].Value = r.Field<string>(9);
                dataGridView.Rows[rowIndex].Cells["Pass"].Value = r.Field<string>(10);
                dataGridView.Rows[rowIndex].Cells["Status"].Value = r.Field<string>("StatusText");
            }

            dataGridView.ClearSelection();
        }


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            AddUserPanel.Visible = true;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            AddUserPanel.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddUserPanel.Visible = false;

            try
            {
                SchoolYear.Text = Global.YearFrom + "-" + Global.YearTo;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_10_Users (UserLname, UserFname, UserMname, AccountRole, Username, Password, Gender, ContactNumber, SchoolYear_ID, Status) VALUES (@Lname, @Fname, @Mname, @AccountRole12, @Username12, @Password12, @Gender12, @Contact,@SchoolYear_ID, @Status)");
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@Lname", Lname.Text);
                cmd.Parameters.AddWithValue("@Fname", Fname.Text);
                cmd.Parameters.AddWithValue("@Mname", Mname.Text);
                cmd.Parameters.AddWithValue("@AccountRole12", AccountRole12.Text);
                cmd.Parameters.AddWithValue("@Username12", Username12.Text);
                cmd.Parameters.AddWithValue("@Password12", Password12.Text);
                cmd.Parameters.AddWithValue("@Gender12", Gender12.Text);
                cmd.Parameters.AddWithValue("@Contact", Contact.Text);
                cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);
                cmd.Parameters.AddWithValue("Status", "0");


                cmd.ExecuteNonQuery();
                con.Close();
                gridview();
                MessageBox.Show(Lname.Text + "" + Fname.Text + " Successfully Added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Lname.Text = "";

                UserListView();
                gridview();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }
        }



        public void UserListView()
        {


            //string cs = Global.Connection;
            //SqlConnection con = new SqlConnection(cs);
            //SqlDataAdapter da = new SqlDataAdapter();
            //SqlCommand cmd = new SqlCommand();
            //DataTable dt = new DataTable();

            //con.ConnectionString = cs;
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "SELECT UserID, UserLname, UserFname, UserMname, Gender, ContactNumber, AccountRole, YearFrom, YearTo, Username, Password from View_09_Users ";
            //da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //dt = new DataTable();
            //da.Fill(dt);
            //listView1.Items.Clear();

            //foreach (DataRow r in dt.Rows)
            //{
            //    var list = listView1.Items.Add(r.Field<Int32>(0).ToString());

            //    list.SubItems.Add(r.Field<string>(1).ToString());
            //    list.SubItems.Add(r.Field<string>(2).ToString());
            //    list.SubItems.Add(r.Field<string>(3).ToString());
            //    list.SubItems.Add(r.Field<string>(4).ToString());
            //    list.SubItems.Add(r.Field<string>(5));
            //    list.SubItems.Add(r.Field<string>(6));
            //    list.SubItems.Add(r.Field<string>(7).ToString() + " - " + r.Field<string>(8).ToString());
            //    list.SubItems.Add(r.Field<string>(9));
            //    list.SubItems.Add(r.Field<string>(10));




            //}

            //da.Dispose();
            //con.Close();

            AddUserPanel.Visible = false;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            AddUserPanel.Visible = false;
        }



        private void button16_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = true;
            BrigadaTASKS();
            AssignedTeacher.Visible = false;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = false;
            AssignedTeacher.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = false;
            AssignedTeacher.Visible = true;
            Teacher();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = false;
            AssignedTeacher.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = false;
            AssignedTeacher.Visible = true;
            Teacher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = true;
            AssignedTeacher.Visible = false;
            BrigadaTASKS();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            AddTeacherPanel.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AddTeacherPanel.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddBrigadaTasks.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddBrigadaTasks.Visible = false;
        }

        public void TeacherGradeLevelCMBS()
        {
            string cs = Global.Connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT Level_ID, GradeLevel FROM TBL_13_TeacherGradeLevel", con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            DataRow itemrow = dt.NewRow();
            dt.Rows.InsertAt(itemrow, 0);


            GradeLevelCMBS.DataSource = dt;

            GradeLevelCMBS.DisplayMember = "GradeLevel";
            GradeLevelCMBS.ValueMember = "Level_ID";
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GradeLevelID.Text = GradeLevelCMBS.SelectedValue.ToString();
        }


        public void BrigadaTASKS()
        {
            string cs = Global.Connection;

            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT BrigadaTASKS_ID, WorkDone, YearFrom, YearTo FROM VIEW_10_BrigadaTasks";

                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                BrigadaTaskGV.Rows.Clear();
                BrigadaTaskGV.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = BrigadaTaskGV.Rows.Add();

                    // Set the values for each cell in the DataGridView
                    BrigadaTaskGV.Rows[rowIndex].Cells["TaskID"].Value = r.Field<int>(0);
                    BrigadaTaskGV.Rows[rowIndex].Cells["TaskName"].Value = r.Field<string>(1);

                    BrigadaTaskGV.Rows[rowIndex].Cells["SchoolYearAdded"].Value = $"{r.Field<string>(2)} - {r.Field<string>(3)}";
                }
                BrigadaTaskGV.ClearSelection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void Teacher()
        {
            try

            {
                string cs = Global.Connection;
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT TeacherID, Lname, Fname, Mname, Gender, ContactNumber, YearFrom, YearTo FROM VIEW_07_AssignedTeacher";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                dataGridView2.Rows.Clear();
                dataGridView2.ClearSelection();
                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = dataGridView2.Rows.Add();

                    // Set the values for each cell in the DataGridView
                    dataGridView2.Rows[rowIndex].Cells["IDnumber"].Value = r.Field<Int32>(0);
                    dataGridView2.Rows[rowIndex].Cells["Lname2"].Value = r.Field<string>(1);
                    dataGridView2.Rows[rowIndex].Cells["Fname2"].Value = r.Field<string>(2);
                    dataGridView2.Rows[rowIndex].Cells["Mname2"].Value = r.Field<string>(3);
                    dataGridView2.Rows[rowIndex].Cells["Gender2"].Value = r.Field<string>(4);
                    dataGridView2.Rows[rowIndex].Cells["ContactNumber"].Value = r.Field<string>(5);
                    dataGridView2.Rows[rowIndex].Cells["SY_Added"].Value = $"{r.Field<string>(6)} {r.Field<string>(7)}";


                }
                dataGridView2.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_BrigadaTASKS (WorkDone, SchoolYear_ID) VALUES (@TaskName1");
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@TaskName1", TaskName1.Text);


                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(TaskName1.Text + " " + SY_TASKS.Text + " Successfully Added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BrigadaTASKS();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            



        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_04_BrigadaTASKS (WorkDone) VALUES (@TaskName1)");
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@TaskName1", TaskName1.Text);


                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Task " + TaskName1.Text + " Successfully Added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BrigadaTASKS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting Record" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click_1(object sender, EventArgs e)
        {

        }

        private void button22_click(object sender, EventArgs e)
        {
            CoordinatorPanel.Visible = true;
        }

        private void button23_click(object sender, EventArgs e)
        {
            CoordinatorPanel.Visible = true;
        }

        private void button24_click(object sender, EventArgs e)
        {
            CoordinatorPanel.Visible = true;
            AssignedTeacher.Visible = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            AssignedTeacher.Visible = true;
            CoordinatorPanel.Visible = false;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            BrigadaTaskPanel.Visible = true;
            CoordinatorPanel.Visible = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            CoordinatorPanel.Visible = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            InsertCoordinator.Visible = true;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            InsertCoordinator.Visible = false;
        }


        public void CoordinatorGV()
        {
            try
            {
                string cs = Global.Connection;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("SELECT CoordinatorID, Lname, Fname, Mname, Suffix, Gender, ContactNumber, YearFrom, YearTo FROM VIEW_06_BrigadaCoordinator", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                CoordinatorGrdVw.Rows.Clear();
                CoordinatorGrdVw.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = CoordinatorGrdVw.Rows.Add();

                    // Set the values for each cell in the DataGridView
                    CoordinatorGrdVw.Rows[rowIndex].Cells["CoordinatorID2"].Value = r.Field<int>("CoordinatorID");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["LastName"].Value = r.Field<string>("Lname");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["FirstName"].Value = r.Field<string>("Fname");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["MiddleName"].Value = r.Field<string>("Mname");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["SuffixC"].Value = r.Field<string>("Suffix");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["Gender"].Value = r.Field<string>("Gender");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["ContactNumberC"].Value = r.Field<string>("ContactNumber");
                    CoordinatorGrdVw.Rows[rowIndex].Cells["SchoolYearC"].Value = $"{r.Field<string>("YearFrom")} - {r.Field<string>("YearTo")}";
                }
                CoordinatorGrdVw.ClearSelection();
                con.Close();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void button27_Click(object sender, EventArgs e)
        {
            CSchoolYear.Text = $"{Global.YearFrom} - {Global.YearTo}";

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_11_BrigadaCoordinator (Lname, Fname, Mname, Suffix, Gender, ContactNumber, SchoolYear_ID) VALUES (@Lname, @Fname, @Mname, @Suffix, @Gender, @ContactNumber, @SchoolYear_ID)", con);
                    cmd.Parameters.AddWithValue("@Lname", CLname.Text);
                    cmd.Parameters.AddWithValue("@Fname", CFname.Text);
                    cmd.Parameters.AddWithValue("@Mname", CMname.Text);
                    cmd.Parameters.AddWithValue("@Suffix", Csuffix.Text);
                    cmd.Parameters.AddWithValue("@Gender", CGender.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", CContact.Text);
                    cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID); // Replace with appropriate value

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Coordinator added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CoordinatorGV();
                InsertCoordinator.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting coordinator record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CSchoolYear_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
      
