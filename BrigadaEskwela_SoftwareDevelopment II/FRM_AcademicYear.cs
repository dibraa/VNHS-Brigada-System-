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
    public partial class FRM_AcademicYear : Form
    {
        public FRM_AcademicYear()
        {
            InitializeComponent();

            AddYear_panel.Visible = false;
            gridview1();

            //YearFromtxt.Text = Global.YearTo;
            //int yearTo = int.Parse(Global.YearTo);
            //int year_To = yearTo + 1;
            //YearTotxt.Text = year_To.ToString();
        }

        string cs = Global.Connection;


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddYear_panel.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Global.AccountType.Trim().Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            { 
                AddYear_panel.Visible = true;

                YearFromtxt.Text = Global.YearTo;

                int yearTo = int.Parse(Global.YearTo);
                int year_To = yearTo + 1;
                YearTotxt.Text = year_To.ToString();

            }
            else
            {
                MessageBox.Show("User is not an Administrator", "Could not Add Year", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            AddYear_panel.Visible = false;
        }


            public void UpdateSchoolYearStatus()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand updateCmd = new SqlCommand("UPDATE TBL_09_SchoolYear SET SY_Status = 0", con);
            con.Open();
            updateCmd.ExecuteNonQuery();
            con.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSchoolYearStatus();

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_09_SchoolYear (YearFrom, YearTo, SY_Status) VALUES (@YearFrom, @YearTo, @SY_Status)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@YearFrom", YearFromtxt.Text);
                cmd.Parameters.AddWithValue("@YearTo", YearTotxt.Text);

                string status = "1";
                cmd.Parameters.AddWithValue("@SY_Status", status);



                MessageBox.Show(" School Year" + " " + YearFromtxt.Text + " " + YearTotxt.Text + " Successfully Added!", "Update School Year", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddYear_panel.Visible = false;
                cmd.ExecuteNonQuery();
                con.Close();

                //SY_ListView();
                gridview1();
                YearFromtxt.Text = "";
                YearTotxt.Text = "";
                SY_ID.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Updating School Year error " + ex.Message);
            }
        }






        //public void SY_ListView()
        //{
        //    try
        //    {
        //        string cs = Global.Connection;
        //        SqlConnection con = new SqlConnection(cs);
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        SqlCommand cmd = new SqlCommand();
        //        DataTable dt = new DataTable();

        //        con.ConnectionString = cs;
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "SELECT * FROM TBL_09_SchoolYear";
        //        da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        dt = new DataTable();
        //        da.Fill(dt);
        //        listView1.Items.Clear();

        //        foreach (DataRow r in dt.Rows)
        //        {
        //            var list = listView1.Items.Add(r.Field<Int32>(0).ToString());
        //            list.SubItems.Add(r.Field<string>(1).ToString() + "-" + r.Field<string>(2).ToString());
        //            list.SubItems.Add(r.Field<string>(1).ToString());
        //            list.SubItems.Add(r.Field<string>(2).ToString());
        //            list.SubItems.Add(r.Field<string>(3).ToString());

        //        }

        //        da.Dispose();
        //        con.Close();


        //    }
        //    catch (Exception ih)
        //    {
        //        MessageBox.Show("error" + ih.Message);
        //    }
        //}


        public void gridview1()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();

                con.ConnectionString = cs;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT SchoolYear_ID, YearFrom, YearTo, SY_Status FROM TBL_09_SchoolYear ORDER BY SchoolYear_ID DESC";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("StatusText", typeof(string), "IIF(SY_Status = 1, 'Active', 'Inactive')");

                GridViewSY.Rows.Clear();
                GridViewSY.ClearSelection();

                foreach (DataRow r in dt.Rows)
                {
                    int rowIndex = GridViewSY.Rows.Add();

                    GridViewSY.Rows[rowIndex].Cells["SchoolYearID1"].Value = r.Field<int>(0);
                    GridViewSY.Rows[rowIndex].Cells["SchoolYear"].Value = $"{r.Field<string>(1)}-{r.Field<string>(2)}";
                    GridViewSY.Rows[rowIndex].Cells["YearFrom"].Value = r.Field<string>(1);
                    GridViewSY.Rows[rowIndex].Cells["YearTo"].Value = r.Field<string>(2);
                    GridViewSY.Rows[rowIndex].Cells["Status"].Value = r.Field<string>("StatusText");

                    if (r.Field<string>("StatusText") == "Active")
                    {
                        GridViewSY.Rows[rowIndex].Cells["Icon1"].Value = Properties.Resources.checked__4_;
                    }
                    else
                    {
                        GridViewSY.Rows[rowIndex].Cells["Icon1"].Value = Properties.Resources.rec__2_;
                    }
                }

                GridViewSY.ClearSelection();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridViewSY_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string cs = Global.Connection;
            //    SqlConnection con = new SqlConnection(cs);
            //    if (e.ColumnIndex == GridViewSY.Columns["Updatebtn"].Index && e.RowIndex >= 0)
            //    {
            //        string statusCellValue = GridViewSY.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

            //        int currentStatus = 0;

            //        int newStatus = (currentStatus == 1) ? 0 : 1;

            //        string updateQuery = "UPDATE TBL_09_SchoolYear SET SY_Status = CASE WHEN SchoolYear_ID = @SchoolYearID1 THEN @NewStatus ELSE 0 END";
            //        SqlCommand cmd = new SqlCommand(updateQuery, con);
            //        cmd.Parameters.AddWithValue("@NewStatus", newStatus);
            //        cmd.Parameters.AddWithValue("@SchoolYearID1", GridViewSY.Rows[e.RowIndex].Cells["SchoolYearID1"].Value);


            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //    gridview1();
            //}

            //catch (Exception ih)
            //{
            //    MessageBox.Show("Error: " + ih.Message);
            //}

            try
            {
                string cs = Global.Connection;
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                // Set all SY_Status to 0
                string resetQuery = "UPDATE TBL_09_SchoolYear SET SY_Status = 0";
                SqlCommand resetCmd = new SqlCommand(resetQuery, con);
                resetCmd.ExecuteNonQuery();

                // Set SY_Status of clicked row to 1
                string updateQuery = "UPDATE TBL_09_SchoolYear SET SY_Status = 1 WHERE SchoolYear_ID = @SchoolYearID";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@SchoolYearID", GridViewSY.Rows[e.RowIndex].Cells["SchoolYearID1"].Value);
                cmd.ExecuteNonQuery();

                con.Close();

                gridview1();
            }
            catch (Exception ih)
            {
                MessageBox.Show("Error: " + ih.Message);
            }

        }
    }
}
