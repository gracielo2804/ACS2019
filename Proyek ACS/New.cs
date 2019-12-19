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
        public string id_cabang;
        public string id_user;
        public string id_logs;
        OracleDataAdapter adapter;
        public New()
        {
            InitializeComponent();
        }
        public Inventory form_inventory;
        public static OracleConnection conn;  
        OracleCommand cmd = new OracleCommand();

        private void New_Load(object sender, EventArgs e)
        {
            adapter = new OracleDataAdapter("select * from tipe", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            cmb_kategori.DataSource = ds.Tables[0];
            cmb_kategori.ValueMember = "ID_TIPE";
            cmb_kategori.DisplayMember = "NAMA_TIPE";
            adapter = new OracleDataAdapter("select * from HSUPPLIER", conn);
            DataSet ds1  = new DataSet();
            adapter.Fill(ds1);
            cmb_supplier.DataSource = ds1.Tables[0];
            cmb_supplier.ValueMember = "ID_SUPPLIER";
            cmb_supplier.DisplayMember = "NAMA_PERUSAHAAN";
            string tmp_kode = "SP";

            adapter = new OracleDataAdapter("SELECT LPAD((COUNT(*)+1),3,'0') FROM SEPATU", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tmp_kode += dt.Rows[0].ItemArray[0].ToString();
            lbl_id.Text = tmp_kode;
            string tmp_kodelog = "LS";

            adapter = new OracleDataAdapter("SELECT LPAD((COUNT(*)+1),3,'0') FROM Log_Sepatu", conn);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);

            tmp_kodelog += dt.Rows[0].ItemArray[0].ToString();
            id_logs = tmp_kodelog;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool cekinput = true;
            if (lbl_id.Text=="-")
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
            if (cmb_kategori.SelectedIndex==-1)
            {
                cekinput = false;
            }
            if (cmb_supplier.SelectedIndex==-1)
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
                    cmd = new OracleCommand("insert into sepatu values('" + tmp_kode + "','" + txt_nama.Text + "','" + txt_hargabeli.Text + "','" + txt_hargajual.Text + "','1','" + cmb_kategori.SelectedValue.ToString() + "','"+id_cabang+"','"+cmb_supplier.SelectedValue.ToString()+"')", conn) ;
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand($"insert into stok values('{lbl_id.Text}','{nud_ukuran.Value.ToString()}','{nud_jumlah.Value.ToString()}','{txt_warna.Text}','{id_cabang}')", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand($"INSERT into Log_sepatu values('{id_logs}','0','1','{lbl_id.Text}','{nud_jumlah.Value.ToString()}', '{nud_ukuran.Value.ToString()}','{txt_warna.Text}',To_Date(sysdate,'DD/MM/YYYY'),'{id_user}','{id_cabang}','Barang Baru')",conn);
                    ////autogen path file secara dinamis
                    //string newPath = AppDomain.CurrentDomain.BaseDirectory + "picture";

                    ////copy image ke dalam folder picture di dalam bin debug dengan nama 'tmp_kode'.jpg 
                    //string destFile = Path.Combine(newPath, tmp_kode + ".jpg");
                    //File.Copy(path, destFile, true);
                    MessageBox.Show("Berhasil Insert Barang baru");
                    this.Close();

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
