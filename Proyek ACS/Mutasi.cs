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
    public partial class Mutasi : Form
    {
        public static OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        public string kodeCabang;
        int masuk = 0, keluar = 0;
        
        public Mutasi()
        {
            InitializeComponent();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else
            {
                conn.Open();
                conn.Close();
            }
            this.CenterToScreen();
        }

        private void Mutasi_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select * from SEPATU", conn);
            adapter = new OracleDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row["ID_SEPATU"].ToString() == ID.Text)
                {
                    Nama_Lbl.Text = row["NAMA_SEPATU"].ToString();
                    Market_Lbl.Text = row["HARGA_JUAL"].ToString();
                    if (row["STATUS_SEPATU"].ToString() == "1")
                    {
                        Status_Lbl.Text = "Ada";
                    }
                    else
                    {
                        Status_Lbl.Text = "Terhapus";
                    }

                }
            }
            masuk = 0;
            keluar = 0;
            cmd = new OracleCommand($"Select * from log_sepatu where ID_SEPATU = '{ID.Text}' and ID_CABANG ='{kodeCabang}'", conn);
            adapter = new OracleDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            Main.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string jenis = "";
                if (row["JENIS_AKTIFITAS"].ToString() == "1")
                {
                    masuk += Convert.ToInt32(row["JUMLAH_SEPATU"].ToString());
                    jenis = "Pertambahan";
                }
                else
                {
                    keluar += Convert.ToInt32(row["JUMLAH_SEPATU"].ToString());
                    jenis = "Pengurangan";
                }
                Main.Rows.Add(Convert.ToDateTime(row["TANGGAL_LOG"].ToString()).ToShortDateString(), row["USERNAME"].ToString(), jenis, row["JUMLAH_SEPATU"].ToString(), row["Catatan"].ToString());
            }
            In_Lbl.Text = masuk.ToString();
            Out_lbl.Text = keluar.ToString();
            cmd = new OracleCommand($"Select JUMLAH_SEPATU from STOK where id_Sepatu = '{ID.Text}' and warna_sepatu ='{Warna.Text}' and ukuran_Sepatu = '{Convert.ToInt32(Ukuran.Text)}'", conn);
            adapter = new OracleDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds);
            Left_Lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            conn.Close();
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
