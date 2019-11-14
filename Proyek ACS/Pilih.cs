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
    public partial class Pilih : Form
    {
        public Pilih()
        {
            InitializeComponent();
        }
        public string user;
        public int id_jabatan;
        public awal form_awal;        

        private void button1_Click(object sender, EventArgs e)
        {            
            Master_Login m = new Master_Login();
            m.form_pilih = this;
            m.lbl_nama.Text = this.user;
            m.Show();
            this.Hide();
        }

        private void Pilih_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_awal.Show();
            this.Close();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.form_pilih = this;
            i.id_jabatan = this.id_jabatan;
            i.lbl_nama.Text = this.user;
            i.Show();
            this.Hide();
        }
    }
}
