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
    public partial class FRM_TestDock : Form
    {
        public FRM_TestDock()
        {
            InitializeComponent();
            Show1.Visible = false;

            add();
            View_EditRecord.Visible = false;


        }

        string cs = Global.Connection;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        //public void overview1()
        //{

         
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(cs);
        //        con.ConnectionString = cs;
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "SELECT Lname,Fname,Mname,Suffix,Gender,GradeLevel,LearnerStatus,FullName,Relationship,BrigadaType,ContactNo, VerifiedBy,DateVerified FROM VIEW_02_BrigadaVOLUNTEERS2 UNION SELECT Lname, Fname, Mname, Suffix, Gender, GradeLevel, LearnerStatus, FullName, Relationship, BrigadaType, ContactNo,VerifiedBy, DateVerified FROM VIEW_03_BrigadaDONATIONS2";
        //        da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        dt = new DataTable();
        //        da.Fill(dt);

        //        GenGv.Rows.Clear();
        //        GenGv.ClearSelection();

        //        foreach (DataRow r in dt.Rows)
        //        {
        //            int rowIndex = GenGv.Rows.Add();
        //            GenGv.Rows[rowIndex].Cells["Students_FullName"].Value = $"{r.Field<string>(0)} {r.Field<string>(1)} {r.Field<string>(2)} {r.Field<string>(3)}";
        //            GenGv.Rows[rowIndex].Cells["Gender"].Value = r.Field<string>(4);
        //            GenGv.Rows[rowIndex].Cells["Grade"].Value = r.Field<string>(5);
        //            GenGv.Rows[rowIndex].Cells["Learners_Status"].Value = r.Field<string>(6);
        //            GenGv.Rows[rowIndex].Cells["Brigada"].Value = r.Field<string>(7);
        //            GenGv.Rows[rowIndex].Cells["Relationship"].Value = r.Field<string>(8);
        //            GenGv.Rows[rowIndex].Cells["Contact"].Value = r.Field<string>(9);
        //            GenGv.Rows[rowIndex].Cells["Brigada_Type"].Value = r.Field<string>(10);
        //            GenGv.Rows[rowIndex].Cells["Verified_By"].Value = r.Field<string>(11);
        //            GenGv.Rows[rowIndex].Cells["Date"].Value = r.Field<string>(12);



        //            GenGv.ClearSelection();
        //        }
        //    }
        //    catch (Exception ih)
        //    {
        //        MessageBox.Show("Error: " + ih.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}



        public void add()

        {
            string[] organizationNames = {
    "Department of Education",
    "Red Cross",
    "United Way",
    "Habitat for Humanity",
    "Salvation Army",
    "Doctors Without Borders",
    "UNICEF",
    "World Wildlife Fund",
    "Amnesty International",
    "Greenpeace",
    "Oxfam",
    "Feeding America",
    "The Nature Conservancy",
    "American Cancer Society",
    "American Heart Association",
    "National Parks Conservation Association",
    "Planned Parenthood",
    "American Red Cross",
    "The Humane Society",
    "St. Jude Children's Research Hospital",
    "American Diabetes Association",
    "Susan G. Komen for the Cure",
    "World Vision",
    "American Lung Association",
    "Médecins Sans Frontières"
};

            // Add 25 rows with specific organization names
            Random rnd = new Random();
            foreach (string orgName in organizationNames)
            {
                dataGridView2.Rows.Add(
                    orgName,
                    (rnd.Next(2) == 0) ? "Public" : "Private",
                    (rnd.Next(2) == 0) ? "Donation" : "Volunteer",
                    (rnd.Next(2) == 0) ? "$" + rnd.Next(100, 1000).ToString() : "N/A",
                    (rnd.Next(2) == 0) ? "N/A" : "Shovels",
                    (rnd.Next(2) == 0) ? "N/A" : rnd.Next(1, 20).ToString(),
                    "Verifier",
                    DateTime.Now.ToString("yyyy-MM-dd")
                );
            };
        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            TopPannel.Visible = false;
            Show1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopPannel.Visible = true;
            Show1.Visible = false;
        }

        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderBy.Text = Orderbycmb.SelectedItem.ToString();
        }

        private void SelectedItem_Paint(object sender, PaintEventArgs e)
        {
            //Orderbycmb.DroppedDown = true;
        }

        private void FRM_TestDock_Activated(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell = null;
        }

        private void Searchtxt_Enter(object sender, EventArgs e)
        {
            if (Searchtxt.Text == "  Search")
            {
                Searchtxt.Text = "";
            }
        }

        private void Searchtxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Searchtxt.Text))
            {
                Searchtxt.Text = "  Search";
            }
        }

        private void Searchtxt_Click(object sender, EventArgs e)
        {
            Searchtxt.Text = "";
        }

        private void SelectedItem_Click(object sender, EventArgs e)
        {
            Orderbycmb.DroppedDown = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            View_EditRecord.Visible = true;
        }
    }
}
