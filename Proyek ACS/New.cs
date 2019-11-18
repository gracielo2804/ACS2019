using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class New : Form
    {
        public New()
        {
            InitializeComponent();
        }
        public Inventory form_inventory;
        OracleConnection conn = new OracleConnection("Data Source=xe;User ID=proyek;Password=proyek");
        OracleDataAdapter adapter;
        OracleCommand cmd = new OracleCommand();

        private void New_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose Picture";
            openFileDialog1.Filter = "png files(*.png)|*.png";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool cekinput = true;
            if (txt_id.Text=="")
            {
                cekinput = false;
            }
            if (txt_nama.Text == "")
            {
                cekinput = false;
            }
            if (txt_warna.Text == "")
            {
                cekinput = false;
            }
            if (txt_hargabeli.Text == "")
            {
                cekinput = false;
            }
            if (txt_hargajual.Text == "")
            {
                cekinput = false;
            }
            if (cmb_kategori.SelectedIndex!=-1)
            {
                cekinput = false;
            }
            if (nud_jumlah.Value == 0)
            {
                cekinput = false;
            }
            if (nud_ukuran.Value == 0)
            {
                cekinput = false;
            }
            if (cekinput==true)
            {
                try
                {
                    //koding untuk insert kedalam database disini
                }
                catch (Exception)
                {
                    MessageBox.Show("Terdapat Kesalahan Data,insert dibatalkan");
                }
            }
            else
            {
                MessageBox.Show("Data Tidak Lengkap");
            }
        }

        private void New_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_inventory.Show();
        }
    }
}
