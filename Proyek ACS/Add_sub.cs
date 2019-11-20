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
    public partial class Add_sub : Form
    {

        OracleConnection conn;
        public string id_supplier;
        public string comp_name;

        public Add_sub()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string email = txt_email.Text;
            string telp = txt_telp.Text;
            OracleCommand temp_comm = new OracleCommand("INSERT INTO DSUPPLIER VALUES('" + id_supplier + "','" + nama + "','" + telp + "','"+email+"') ", conn);
            temp_comm.ExecuteNonQuery();
            MessageBox.Show("Success!!");
            textBox1.Text = "";
            txt_email.Text = "";
            txt_telp.Text = "";
            this.Close();
        }

        private void Add_sub_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                label11.Text = id_supplier;

                OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT NAMA_PERUSAHAAN FROM HSUPPLIER WHERE ID_SUPPLIER='" + id_supplier + "'", conn);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                comp_name = dt1.Rows[0].ItemArray[0].ToString();
                label5.Text = comp_name;

                txt_email.Text = "";
                txt_telp.Text = "";
            }
            catch (Exception ex)
            {

                throw;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
