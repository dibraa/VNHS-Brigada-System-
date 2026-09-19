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
    public partial class FRM_AboutUs : Form
    {
        public FRM_AboutUs()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
