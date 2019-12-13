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
    public partial class Update : Form
    {
        OracleCommand cmd;
        OracleDataAdapter ad;
        DataTable dt;
        DataSet ds;
        public static OracleConnection conn;
        public int Awal;
        public string warna,nama,Username;
        public int ukuran;
        string kodelog;
        int temp;
        public Update()
        {
            InitializeComponent();
            conn = Form_Atur_Conn.conn;
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(jumlah.Text) < nud_jumlah.Value && rb_pengurangan.Checked==true)
            {
                MessageBox.Show("Jumlah stock yang ingin dikurangi lebih besar daripada jumlah stock yang ada");
            }
            else
            {
                if (rb_pengurangan.Checked==true || rb_penambahan.Checked==true)
                {
                    conn.Open();
                    try
                    {
                        temp = 0;
                        cmd = new OracleCommand($"UPDATE Sepatu SET NAMA_SEPATU ='{txx_nama.Text}', harga_jual='{txt_hargajual.Text}', harga_beli='{txt_hargajual.Text}', ID_Tipe ='{cmb_kategori.SelectedValue.ToString()}' where ID_Sepatu ='{label11.Text}'", conn);
                        cmd.ExecuteNonQuery();
                        if (rb_penambahan.Checked == true)
                        {
                            temp = Convert.ToInt32(jumlah.Text) + Convert.ToInt32(nud_jumlah.Value.ToString());
                            cmd = new OracleCommand($"Update Stok set JUMLAH_SEPATU ='{temp}', WARNA_SEPATU = '{txt_warna.Text}' where ID_SEPATU ='{label11.Text}'and WARNA_SEPATU ='{warna}'and UKURAN_SEPATU = '{Size.Text}' ", conn);
                            cmd.ExecuteNonQuery();
                            cmd = new OracleCommand($"insert into log_Sepatu values('{kodelog}',1,1,'{label11.Text}','{nud_jumlah.Value.ToString()}','{Size.Text}','{txt_warna.Text}',sysdate,'{Username}')",conn);
                            cmd.ExecuteNonQuery();
                        }
                        else if (rb_pengurangan.Checked == true)
                        {
                            temp = Convert.ToInt32(jumlah.Text) - Convert.ToInt32(nud_jumlah.Value.ToString());
                            cmd = new OracleCommand($"Update Stok set JUMLAH_SEPATU ='{temp}', WARNA_SEPATU = '{txt_warna.Text}' where ID_SEPATU ='{label11.Text}'and WARNA_SEPATU ='{warna}'and UKURAN_SEPATU = '{Size.Text}' ", conn);
                            cmd.ExecuteNonQuery();
                            cmd = new OracleCommand($"insert into log_Sepatu values('{kodelog}',1,0,'{label11.Text}','{nud_jumlah.Value.ToString()}','{Size.Text}','{txt_warna.Text}',sysdate,'{Username}')", conn);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Barang dengan code " + label11.Text + " Berhasil Di Edit");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Mohon memilih salah satu jenis perubahan Stock");
                }
               
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Update_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select * from tipe", conn);
            ad = new OracleDataAdapter(cmd);
            dt = new DataTable();
            ad.Fill(dt);
            cmb_kategori.DataSource = dt;
            cmb_kategori.DisplayMember = "Nama_Tipe";
            cmb_kategori.ValueMember = "ID_Tipe";
            cmd = new OracleCommand($"Select ID_Tipe from SEPATU where id_sepatu = '{label11.Text.ToString()}'", conn);
            ad = new OracleDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds);
            cmb_kategori.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
            ad = new OracleDataAdapter("SELECT LPAD((COUNT(*)+1),3,'0') FROM Log_Sepatu", conn);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            kodelog = dt1.Rows[0].ItemArray[0].ToString();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
