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
    public partial class ExportRecord_AllRecords : Form
    {
        private FormWindowState previousWindowState;
        private Size previousSize;
        public ExportRecord_AllRecords()
        {
            InitializeComponent();
            previousWindowState = this.WindowState;
            previousSize = this.Size;
        }
        private void ExportRecord_AllRecords_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS2' table. You can move, or remove it, as needed.
            this.VIEW_02_BrigadaVOLUNTEERS2TableAdapter.Fill(this._01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS2);
            // TODO: This line of code loads data into the '_01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS21' table. You can move, or remove it, as needed.
            this.VIEW_02_BrigadaVOLUNTEERS21TableAdapter.Fill(this._01_BrigadaEskwelaDBDataSet.VIEW_02_BrigadaVOLUNTEERS21);
            this.reportViewerAllRecords.RefreshReport();
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


        private void reportViewerDONATIONS_Load(object sender, EventArgs e)
        {

        }
    }
}
