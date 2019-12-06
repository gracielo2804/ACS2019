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
            conn.Open();
            adapter = new OracleDataAdapter("select nama_user from user_", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "nama_user";
            conn.Close();
            conn.Open();
            adapter = new OracleDataAdapter("select u.username , u.nama_user , u.password , jab.nama_jabatan from user_ u , jabatan jab", conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
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
                dataGridView2.Rows.Add(comboBox1.SelectedItem , label3.Text , label4.Text , label6.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            label3.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            label4.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
            label6.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
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
                //do something
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
