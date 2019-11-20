using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Sub_contact : Form
    {
        OracleConnection conn;
        public string id_supplier;

        public Sub_contact()
        {
            InitializeComponent();

            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void Sub_contact_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                dataGridView1.DataSource = null;
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT NAMA_SALES AS \"NAMA SALES\", '0'||TELP AS \"NOMOR TELPON\",EMAIL FROM DSUPPLIER WHERE ID_SUPPLIER='"+id_supplier+"'", conn);
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
            Add_sub asb = new Add_sub();
            asb.id_supplier = id_supplier;
            //this.Hide();
            asb.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deletesub dsub = new deletesub();
            this.Hide();
            dsub.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            Edit_Sub es = new Edit_Sub();
            es.sales_name = dataGridView1.Rows[row].Cells[0].Value.ToString();
            es.id_supplier = id_supplier;
            es.ShowDialog();
            //this.Hide();
        }
    }
}
