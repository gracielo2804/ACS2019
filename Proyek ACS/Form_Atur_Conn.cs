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
    public partial class Form_Atur_Conn : Form
    {
        public static OracleConnection conn;
        string host, db = "XE", user, pass;
        public awal a;

        private void btn_login_Click(object sender, EventArgs e)
        {
            bool cek=true;
            if (textBox1.Text=="")
            {
                cek = false;
            }
            if (txt_uname.Text == "")
            {
                cek = false;
            }
            if (txt_password.Text == "")
            {
                cek = false;
            }
            if (cek)
            {
                host = textBox1.Text;
                user = txt_uname.Text;
                pass = txt_password.Text;
                conn = new OracleConnection("Data Source=" +
                   "(DESCRIPTION=" +
                   "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                   "(HOST=" + host + ")(PORT=1521)))" +
                   "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + db + ")));" +
                   "user id=" + user + ";password=" + pass);
                conn.Close();
                conn.Open();
                conn.Close();
                add_contact.conn = conn;
                awal.conn = conn;
                Delete_Barang.conn = conn;
                delete_user.conn = conn;
                deletecontact.conn = conn;
                deletesub.conn = conn;
                Edit_Sub.conn = conn;
                Edit_User.conn = conn;
                EditContact.conn = conn;
                Form2.conn = conn;
                Inventory.conn = conn;
                Master_Login.conn = conn;
                Mutasi.conn = conn;
                New.conn = conn;
                New_User.conn = conn;
                Report.conn = conn;
                Sub_contact.conn = conn;

                this.Close();
            }
            else
            {
                MessageBox.Show("Data Tidak Lengkap");
            }
        }

        public Form_Atur_Conn()
        {
            InitializeComponent();
           
        }
    }
}
