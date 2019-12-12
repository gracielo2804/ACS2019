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
    public partial class add_contact : Form
    {
        public static OracleConnection conn;
        public add_contact()
        {
            InitializeComponent();            
        }

        private void add_contact_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
            }
            catch (Exception)
            {

                throw;
            }
            label11.Text = "";
        }

        private void txt_nama_TextChanged(object sender, EventArgs e)
        {
            string tmp_kode = "SU";
            
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT LPAD((COUNT(*)+1),3,'0') FROM HSUPPLIER", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tmp_kode += dt.Rows[0].ItemArray[0].ToString();

            label11.Text = tmp_kode;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string id = label11.Text;
            string nama = txt_nama.Text;
            string alamat = txt_alamat.Text;
            OracleCommand temp_comm = new OracleCommand("INSERT INTO HSUPPLIER VALUES('"+id+"','"+nama+"','"+alamat+"') ", conn);
            temp_comm.ExecuteNonQuery();
            MessageBox.Show("Success!!");
            label11.Text = "";
            txt_nama.Text = "";
            txt_alamat.Text = "";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
