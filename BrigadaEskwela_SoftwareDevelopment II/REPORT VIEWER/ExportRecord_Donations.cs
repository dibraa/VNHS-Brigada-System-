using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrigadaEskwela_SoftwareDevelopment_II
{
    public partial class ExportRecord_Donations : Form
    {
        private FormWindowState previousWindowState;
        private Size previousSize;
        public ExportRecord_Donations()
        {
            InitializeComponent();
            previousWindowState = this.WindowState;
            previousSize = this.Size;
        }

        private void ExportRecord_Donations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_01_BrigadaEskwelaDBDataSet.View_03_BrigadaDONATIONS2' table. You can move, or remove it, as needed.
            this.View_03_BrigadaDONATIONS2TableAdapter.Fill(this._01_BrigadaEskwelaDBDataSet.View_03_BrigadaDONATIONS2);
            this.reportViewerDONATIONS.RefreshReport();

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "❏")
            {
                this.WindowState = FormWindowState.Maximized;
                button1.Text = "❒";
            }
            else
            {
                if (previousWindowState == FormWindowState.Maximized)
                {
                    this.WindowState = previousWindowState;
                    this.Size = previousSize;
                }
         
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    button1.Text = "❏";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (previousWindowState == FormWindowState.Maximized)
            {
                this.WindowState = previousWindowState;
                this.Size = previousSize;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
                button1.Text = "❒";
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button11_Click(object sender, EventArgs e)
        {
         
        }

        private void reportViewerDONATIONS_Load(object sender, EventArgs e)
        {

        }

        private void SchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchoolYearTXT.Text = SchoolYear.SelectedItem.ToString();
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            SchoolYear.DroppedDown = true;

        }

        private void SchoolYearTXT_Click(object sender, EventArgs e)
        {
            SchoolYear.DroppedDown = true;
        }

        private void Orderbycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderBy.Text = Orderbycmb.SelectedItem.ToString();
        }

        private void OrderBy_Click(object sender, EventArgs e)
        {
            Orderbycmb.DroppedDown = true;
        }

        private void SelectedItem_Click(object sender, EventArgs e)
        {
            Orderbycmb.DroppedDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DonationType.Text = comboBox1.SelectedItem.ToString();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void DonationType_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
