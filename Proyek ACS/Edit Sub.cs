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


    public partial class Edit_Sub : Form
    {
        OracleConnection conn;
        public string id_supplier;
        public string sales_name;
        public string comp_name;

        public Edit_Sub()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void Edit_Sub_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                label7.Text = sales_name;
                label11.Text = id_supplier;
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT '0'||TELP AS \"NOMOR TELPON\",EMAIL FROM DSUPPLIER WHERE ID_SUPPLIER='" + id_supplier + "' AND NAMA_SALES = '"+sales_name+"'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT NAMA_PERUSAHAAN FROM HSUPPLIER WHERE ID_SUPPLIER='"+id_supplier+"'", conn);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                comp_name = dt1.Rows[0].ItemArray[0].ToString();
                label5.Text = comp_name;

                txt_email.Text = dt.Rows[0].ItemArray[1].ToString();
                txt_telp.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {

                throw;
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string email = txt_email.Text;
            string no_telp = txt_telp.Text;
            OracleCommand temp_comm = new OracleCommand("UPDATE DSUPPLIER SET EMAIL='" + email + "' , TELP='" + no_telp + "' WHERE ID_SUPPLIER = '" + id_supplier + "' AND NAMA_SALES ='"+sales_name+"'", conn);
            temp_comm.ExecuteNonQuery();
            MessageBox.Show("Success!!");

            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
