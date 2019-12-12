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
    public partial class Form2 : Form
    {
        public static OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                int row = e.RowIndex;

                Sub_contact sc = new Sub_contact();
                sc.id_supplier = dataGridView1.Rows[row].Cells[0].Value.ToString();
                this.Hide();
                sc.ShowDialog();
                this.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                dataGridView1.DataSource = null;
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM HSUPPLIER", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw;
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add_contact ac= new add_contact();
            this.Hide();
            ac.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditContact ecc = new EditContact();
            this.Hide();
            ecc.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deletecontact dct = new deletecontact();
            this.Hide();
            dct.ShowDialog();
            this.Show();
        }
    }
}
