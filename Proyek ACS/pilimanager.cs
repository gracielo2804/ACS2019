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
    public partial class pilimanager : Form
    {
        public string user;
        public string id_user;
        public int id_jabatan;
        public awal form_awal;
        public pilimanager()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.form_pilih_manager = this;
            i.id_jabatan = this.id_jabatan;
            i.id_user = id_user;
            i.parent = "pilimanager";
            i.lbl_nama.Text = this.user;
            i.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
