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
    public partial class FRM_CampusMap : Form
    {
        public FRM_CampusMap()
        {
            InitializeComponent();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pagcor_Click(object sender, EventArgs e)
        {
            FRM_Pagcor_Building view = new FRM_Pagcor_Building();
            view.ShowDialog();
          ;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Building_A_Click(object sender, EventArgs e)
        {

            FRM_Building_A view = new FRM_Building_A();
            view.ShowDialog();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FRM_Building_B view = new FRM_Building_B();
            view.ShowDialog();
           
        }
    }
}
