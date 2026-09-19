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
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
            this.Hide();

        }

        string cs = Global.Connection;

        public void Status()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string sql = "UPDATE TBL_10_Users SET Status = 1 WHERE UserID = @userID";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Login_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Please Enter Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    // First query for user login
                    string query = "SELECT UserID, UserFname, UserMname, UserLname, AccountRole, Username, Password FROM View_09_Users WHERE Username COLLATE Latin1_General_CS_AS = @username AND Password COLLATE Latin1_General_CS_AS = @password";

                    using (SqlCommand cmdLogin = new SqlCommand(query, con))
                    {
                        cmdLogin.Parameters.AddWithValue("@username", Username.Text);
                        cmdLogin.Parameters.AddWithValue("@password", Password.Text);

                        using (SqlDataAdapter adapt = new SqlDataAdapter(cmdLogin))
                        {
                            DataSet ds = new DataSet();
                            adapt.Fill(ds);

                            int count = ds.Tables[0].Rows.Count;
                            if (count == 1)
                            {
                                using (SqlDataReader reader = cmdLogin.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        Global.Fname = reader["UserFname"].ToString();
                                        Global.Mname = reader["UserMname"].ToString();
                                        Global.Lname = reader["UserLname"].ToString();
                                        Global.Username = reader["Username"].ToString();
                                        Global.UserID = reader["UserID"].ToString();
                                        Global.AccountType = reader["AccountRole"].ToString();
                                    }
                                }

                                // Second query to get the active school year
                                string query2 = "SELECT YearFrom, YearTo, SchoolYear_ID FROM TBL_09_SchoolYear WHERE SY_Status = 1";
                                using (SqlCommand cmdSchoolYear = new SqlCommand(query2, con))
                                {
                                    using (SqlDataReader reader = cmdSchoolYear.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            Global.YearFrom = reader["YearFrom"].ToString();
                                            Global.YearTo = reader["YearTo"].ToString();
                                            Global.SchoolYearID = reader["SchoolYear_ID"].ToString();
                                        }
                                    }
                                }

                                MessageBox.Show("Login is Successful", "Success Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //success login
                                Status();
                                FRM_Dashboard dash = new FRM_Dashboard();
                                dash.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Information", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Username.Text = "";
                                Password.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        private void pictureBox13_Click(object sender, EventArgs e)
        {
            FRM_Dashboard dash = new FRM_Dashboard();
            dash.ShowDialog();
            this.Hide();
        }

        private void Show_CheckedChanged(object sender, EventArgs e)
        {
            if (Show.Checked)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }

       

        private void ResolutionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedText.Text = ResolutionType.SelectedItem.ToString();
        }

       
        private void SelectedItem_Click(object sender, EventArgs e)
        {
            ResolutionType.DroppedDown = true;
        }

        private void SelectedText_Click(object sender, EventArgs e)
        {
            ResolutionType.DroppedDown = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FRM_TestDock frm = new FRM_TestDock();
            frm.ShowDialog();
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Please Enter Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    // First query for user login
                    string query = "SELECT UserID, UserFname, UserMname, UserLname, AccountRole, Username, Password FROM View_09_Users WHERE Username COLLATE Latin1_General_CS_AS = @username AND Password COLLATE Latin1_General_CS_AS = @password";

                    using (SqlCommand cmdLogin = new SqlCommand(query, con))
                    {
                        cmdLogin.Parameters.AddWithValue("@username", Username.Text);
                        cmdLogin.Parameters.AddWithValue("@password", Password.Text);

                        using (SqlDataAdapter adapt = new SqlDataAdapter(cmdLogin))
                        {
                            DataSet ds = new DataSet();
                            adapt.Fill(ds);

                            int count = ds.Tables[0].Rows.Count;
                            if (count == 1)
                            {
                                using (SqlDataReader reader = cmdLogin.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        Global.Fname = reader["UserFname"].ToString();
                                        Global.Mname = reader["UserMname"].ToString();
                                        Global.Lname = reader["UserLname"].ToString();
                                        Global.Username = reader["Username"].ToString();
                                        Global.UserID = reader["UserID"].ToString();
                                        Global.AccountType = reader["AccountRole"].ToString();
                                    }
                                }

                                // Second query to get the active school year
                                string query2 = "SELECT YearFrom, YearTo, SchoolYear_ID FROM TBL_09_SchoolYear WHERE SY_Status = 1";
                                using (SqlCommand cmdSchoolYear = new SqlCommand(query2, con))
                                {
                                    using (SqlDataReader reader = cmdSchoolYear.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            Global.YearFrom = reader["YearFrom"].ToString();
                                            Global.YearTo = reader["YearTo"].ToString();
                                            Global.SchoolYearID = reader["SchoolYear_ID"].ToString();
                                        }
                                    }
                                }

                                MessageBox.Show("Login is Successful", "Success Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //success login
                                Status();
                                FRM_Dashboard dash = new FRM_Dashboard();
                                dash.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Information", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Username.Text = "";
                                Password.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}


