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
    public partial class FRM_StudentRegistration : Form
    {
        public FRM_StudentRegistration()
        {
            InitializeComponent();

            string cs = Global.Connection;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT StudentinformationID, LRN_No, Lname, Fname, Mname, Gender, Age, ContactNo, LearnerStatus, GradeLevel, YearFrom, YearTo from View_01_StudentInformation ";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            listView1.Items.Clear();

            foreach (DataRow r in dt.Rows)
            {
                var list = listView1.Items.Add(r.Field<Int32>(0).ToString());

                list.SubItems.Add(r.Field<string>(1));
                list.SubItems.Add(r.Field<string>(2).ToString());
                list.SubItems.Add(r.Field<string>(3).ToString());
                list.SubItems.Add(r.Field<string>(4).ToString());
                list.SubItems.Add(r.Field<string>(5));
                list.SubItems.Add(r.Field<string>(6));
                list.SubItems.Add(r.Field<string>(7));
                list.SubItems.Add(r.Field<string>(8));
                list.SubItems.Add(r.Field<string>(9));
                list.SubItems.Add(r.Field<string>(10).ToString() + "-" + r.Field<string>(11).ToString());


            }

            da.Dispose();
            con.Close();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegBTN_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            add.ShowDialog();
            this.Close();
        }

        private void Searchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Brigadatypcmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Sycmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
