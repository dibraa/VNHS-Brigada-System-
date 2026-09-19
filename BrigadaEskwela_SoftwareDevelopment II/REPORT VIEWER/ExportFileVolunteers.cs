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
    public partial class ExportFileVolunteers : Form
    {
        private FormWindowState previousWindowState;
        private Size previousSize;
        public ExportFileVolunteers()
        {
            InitializeComponent();
            previousWindowState = this.WindowState;
            previousSize = this.Size;
        }

        private void ExportFileVolunteers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS2' table. You can move, or remove it, as needed.
            this.VIEW_02_BrigadaVOLUNTEERS2TableAdapter.Fill(this._01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS2);
            this.reportViewer1.RefreshReport();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                // Otherwise, set it to normal size
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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
