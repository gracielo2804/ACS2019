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
    public partial class Inventory : Form
    {
        OracleConnection conn;
        public awal form_awal;
        public Pilih form_pilih;
        public int id_jabatan;
        OracleDataAdapter adapter;
        
        public Inventory()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            if (id_jabatan==1)
            {
                button2.Visible = false;
                button3.Text = "Logout";
            }
            else if (id_jabatan==2)
            {
                button2.Visible = true;
                button3.Text = "Logout";
            }
            else if (id_jabatan == 3)
            {
                button2.Visible = true;
                button3.Text = "Back";
            }
            adapter = new OracleDataAdapter("select * from cabang", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "ID_cabang";
            comboBox1.DisplayMember = "Nama_cabang";

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text=="Logout")
            {
                form_awal.Show();
                this.Close();                
            }
            else
            {
                form_pilih.Show();
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                adapter = new OracleDataAdapter("select st.id_sepatu as \"ID Sepatu\",s.nama_sepatu \"Nama Sepatu\" ,st.jumlah_sepatu as Jumlah,st.warna_sepatu as \"Warna Sepatu\" from stok st,sepatu s,cabang c where c.id_cabang=st.id_cabang and st.id_sepatu=s.id_sepatu and c.id_cabang='" + comboBox1.SelectedValue+"'", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
