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
    public partial class ExportRecord_OrgVolunteers : Form
    {
        private FormWindowState previousWindowState;
        private Size previousSize;
        public ExportRecord_OrgVolunteers()
        {
            InitializeComponent();
            previousWindowState = this.WindowState;
            previousSize = this.Size;
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
    }
}
