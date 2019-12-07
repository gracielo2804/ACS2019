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
    public partial class delete_user : Form
    {
        public delete_user()
        {
            InitializeComponent();
        }
        OracleConnection conn = new OracleConnection("Data Source= xe;User ID=proyek;Password=proyek");
        OracleDataAdapter adapter;
        OracleCommand cmd;

        private void delete_user_Load(object sender, EventArgs e)
        {
            load_data();
        }

        public void load_data() {
            conn.Close();
            conn.Open();
            adapter = new OracleDataAdapter("select u.username , u.nama_user , u.password , jab.nama_jabatan from user_ u , jabatan jab where u.id_jabatan=jab.id_jabatan", conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
            adapter = new OracleDataAdapter("select nama_user from user_", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "nama_user";
           
            conn.Close();
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == " ")
            {
                MessageBox.Show("Pilih Terlebih Dahulu");
            }
            else
            {
                groupBox2.Enabled = true;
                if (dataGridView1.RowCount > 0)
                {
                    bool cekuser = true;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (comboBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("User sudah ada didalam list");
                            cekuser = false;

                        }                        
                    }
                    if (cekuser)
                    {
                        dataGridView1.Rows.Add(comboBox1.Text, label3.Text, label4.Text, label6.Text);
                    }
                }
                else if (dataGridView1.RowCount==0)
                {
                    dataGridView1.Rows.Add(comboBox1.Text, label3.Text, label4.Text, label6.Text);
                }                                                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index>-1)
            {
                label3.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
                label4.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
                label6.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirmation", "Are you sure to delete all the data ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                conn.Close();
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string username = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        cmd = new OracleCommand("update user_ set status_user=0 where username='" + username + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    MessageBox.Show("Berhasil Delete user yang telah dipilih");
                    this.Close();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    MessageBox.Show("Terjadi Kesalahan Delete Dibatalkan");
                }                
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Make sure your choices was right");
            }
        }
        int indexhapus = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexhapus = e.RowIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(indexhapus);
        }
    }
}
