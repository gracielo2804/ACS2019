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
    
    public partial class Delete_Barang : Form
    {
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommand cmd;
        public string id_perusahaan;
        public Delete_Barang()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void Delete_Barang_Load(object sender, EventArgs e)
        {
            adapter = new OracleDataAdapter("select st.id_sepatu as \"ID Sepatu\",s.nama_sepatu \"Nama Sepatu\" ,st.jumlah_sepatu as Jumlah,st.warna_sepatu as \"Warna Sepatu\" from stok st,sepatu s,cabang c where c.id_cabang=st.id_cabang and st.id_sepatu=s.id_sepatu and c.id_cabang='" + id_perusahaan + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "ID Sepatu";
            comboBox1.DisplayMember = "ID Sepatu";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                lbl_nama.Text = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[1].Value.ToString();
                lbl_warna.Text = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[3].Value.ToString();                
            }
            else
            {
                lbl_nama.Text = "-";
                lbl_warna.Text = "-";
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes==MessageBox.Show("Apakah Anda Yakin","Confirmation",MessageBoxButtons.YesNo))
            {
                conn.Close();
                conn.Open();
                cmd = new OracleCommand("delete from stok where id_sepatu='" + comboBox1.SelectedValue.ToString() + "' and id_cabang='"+id_perusahaan+"'", conn) ;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Menghapus");
                Delete_Barang_Load(this, e);
            }
        }
    }
}
