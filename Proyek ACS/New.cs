using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class New : Form
    {
        string path;
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

                    conn.Close();
                    conn.Open();


                    //autogen Kode
                    string tmp_kode = "SP";

                    OracleDataAdapter adapter = new OracleDataAdapter("SELECT LPAD((COUNT(*)+1),3,'0') FROM SEPATU", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    tmp_kode += dt.Rows[0].ItemArray[0].ToString();


                    ////autogen path file secara dinamis
                    //string newPath = AppDomain.CurrentDomain.BaseDirectory + "picture";

                    ////copy image ke dalam folder picture di dalam bin debug dengan nama 'tmp_kode'.jpg 
                    //string destFile = Path.Combine(newPath, tmp_kode + ".jpg");
                    //File.Copy(path, destFile, true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terdapat Kesalahan Data,insert dibatalkan");

                    MessageBox.Show(ex.Message);
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
