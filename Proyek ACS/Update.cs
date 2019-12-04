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
        OracleConnection conn;
        public int temp;
        public Update()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
            conn.Close();
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand($"UPDATE Sepatu SET NAMA_SEPATU ='{txx_nama.Text}', harga_jual='{txt_hargajual.Text}', harga_beli='{txt_hargajual.Text}' where ID_Sepatu ='{label11.Text}'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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
            conn.Close();
        }
    }
}
