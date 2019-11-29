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
    public partial class deletesub : Form
    {
        public deletesub()
        {
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
            InitializeComponent();
        }
        OracleConnection conn;
        public string id_supplier;
        DataSet ds;
        OracleCommand cmd = new OracleCommand();
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                if (MessageBox.Show("Yakin Ingin Menghapus", "Confrim",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    conn.Close();
                    conn.Open();
                    try
                    {
                        cmd = new OracleCommand("delete from dsupplier where telp='" + label6.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Berhasil mengahpus");
                        deletesub_Load(this, e);
                        if (dataGridView1.Rows.Count == 0)
                        {
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Terjadi Kesalahan Dalam Proses Penghapusan");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Silahkan Pilih Subkontak yang ingin dihapus");
            }
        }

        private void deletesub_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            conn.Close();
            conn.Open();
            string command = "SELECT NAMA_SALES AS \"NAMA SALES\",'0'||TELP AS \"NOMOR TELPON\",EMAIL FROM DSUPPLIER WHERE ID_SUPPLIER='" + id_supplier + "'";
            OracleDataAdapter adapter = new OracleDataAdapter(command, conn);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cmd = new OracleCommand(command, conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0).ToString());
            }
            if (comboBox1.Items.Count>0)
            {
                comboBox1.SelectedIndex = 0;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                label3.Text = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[0].Value.ToString();
                label4.Text = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value.ToString();
                label6.Text = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[1].Value.ToString();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
