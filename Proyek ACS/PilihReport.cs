using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class PilihReport : Form
    {
        public PilihReport()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }

        private void Btn_Stock_Click(object sender, EventArgs e)
        {
            Mutasi m = new Mutasi();
            this.Hide();
            m.Show();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
