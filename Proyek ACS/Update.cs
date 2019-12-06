﻿using System;
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
        OracleConnection conn;
        public int Awal;
        public string warna,nama,Username;
        public int ukuran;
        string kodelog;
        public Update()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
            conn.Close();
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                cmd = new OracleCommand($"UPDATE Sepatu SET NAMA_SEPATU ='{txx_nama.Text}', harga_jual='{txt_hargajual.Text}', harga_beli='{txt_hargajual.Text}', ID_Tipe ='{cmb_kategori.SelectedValue.ToString()}' where ID_Sepatu ='{label11.Text}'", conn);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand($"Update Stok set UKURAN_SEPATU ='{nud_ukuran.Value}', JUMLAH_SEPATU ='{nud_jumlah.Value}', WARNA_SEPATU = '{txt_warna.Text}' where ID_SEPATU ='{label11.Text}'and WARNA_SEPATU ='{warna}'and UKURAN_SEPATU = '{ukuran}' ", conn);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand($"Update LOG_SEPATU set ukuran_sepatu ='{nud_ukuran.Value}', warna_sepatu ='{txt_warna.Text}' where id_sepatu = '{label11.Text}'", conn);
                cmd.ExecuteNonQuery();
                if (this.Awal > nud_jumlah.Value)
                {
                    int Kurang = Awal - Convert.ToInt32(nud_jumlah.Value);
                    cmd = new OracleCommand($"Insert into log_Sepatu values ('{kodelog}',1,0,'{label11.Text}',{Kurang}','{nud_ukuran.Value}','{txt_warna.Text}',To_Date(sysdate,'DD/MM/YYYY'),'{this.Username}')", conn);
                    cmd.ExecuteNonQuery();
                }
                else if (this.Awal < nud_jumlah.Value)
                {
                    int tambah = Convert.ToInt32(nud_jumlah.Value) - Awal;
                    cmd = new OracleCommand($"Insert into log_Sepatu values ('{kodelog}',1,1,'{label11.Text}',{tambah}','{nud_ukuran.Value}','{txt_warna.Text}',To_Date(sysdate,'DD/MM/YYYY'),'{this.Username}')", conn);
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
