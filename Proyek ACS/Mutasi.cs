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
            cmd = new OracleCommand("Select * from sepatu",conn);
            adapter = new OracleDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds);
            cmb_id.DataSource = ds.Tables[0];
            cmb_id.DisplayMember = "ID_SEPATU";
            cmb_id.ValueMember = "ID_SEPATU";
            conn.Close();
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailBtn_Click(object sender, EventArgs e)
        {

        }

        private void LookBtn_Click(object sender, EventArgs e)
        {
            if (cmb_id.SelectedIndex>-1)
            {
                conn.Open();
                cmd = new OracleCommand("Select * from SEPATU", conn);
                adapter = new OracleDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ID_SEPATU"].ToString() == cmb_id.SelectedValue.ToString())
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
                cmd = new OracleCommand($"Select * from log_sepatu where ID_SEPATU = '{cmb_id.SelectedValue}'",conn);
                adapter = new OracleDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                Main.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string jenis = "";
                    if (row["JENIS_AKTIFITAS"].ToString()=="1")
                    {
                        masuk += Convert.ToInt32(row["JUMLAH_SEPATU"].ToString());
                        jenis = "Pertambahan";
                    }
                    else
                    {
                        keluar+= Convert.ToInt32(row["JUMLAH_SEPATU"].ToString());
                        jenis = "Pengurangan";
                    }
                    Main.Rows.Add(Convert.ToDateTime(row["TANGGAL_LOG"].ToString()).ToShortDateString(), row["USERNAME"].ToString(), jenis, row["JUMLAH_SEPATU"].ToString());
                }
                In_Lbl.Text = masuk.ToString();
                Out_lbl.Text = keluar.ToString();
                cmd = new OracleCommand($"Select sum(jumlah_sepatu) as total from STOK where id_Sepatu = '{cmb_id.SelectedValue}'",conn);
                adapter = new OracleDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);
                Left_Lbl.Text = ds.Tables[0].Rows[0][0].ToString();
                conn.Close();
            }
        }
    }
}
