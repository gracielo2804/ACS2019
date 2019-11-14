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
    public partial class awal : Form
    {
        public awal()
        {
            InitializeComponent();
            dbconn.ConnectionString = "Data Source=xe;User ID=proyek;Password=proyek";
        }
        public string user = "";
        public static OracleConnection dbconn = new OracleConnection();

        private void btn_login_Click(object sender, EventArgs e)
        {
            dbconn.Open();
            datalogin();
            dbconn.Close();
            int index = 0;
            bool LOGuser = false, LOGpass = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (txt_uname.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    user = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    LOGuser = true;
                    index = i;
                    i = 99;
                }
            }
            if (LOGuser==true)
            {
                if (dataGridView1.Rows[index].Cells[2].Value.ToString()==txt_password.Text)
                {
                    LOGpass = true;
                }
                else
                {
                    MessageBox.Show("Password Salah");
                }
            }
            else
            {
                MessageBox.Show("Username tidak Ditemukan");
            }
            if (LOGuser && LOGpass)
            {
                MessageBox.Show("Berhasil Login");
                if (dataGridView1.Rows[index].Cells[3].Value.ToString()=="3")
                {
                    this.Hide();
                    Pilih p = new Pilih();
                    p.form_awal = this;
                    p.id_jabatan= int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    p.user = this.user;
                    p.Show();
                }
                else
                {
                    this.Hide();
                    Inventory i = new Inventory();
                    i.id_jabatan = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    i.lbl_nama.Text = this.user;
                    i.form_awal = this;
                    i.Show();
                }
            }
            
            //if (LOGuser == true && LOGpass == true)
            //{
            //    MessageBox.Show("Berhasil Login");
            //    LOGpass = false;
            //    LOGuser = false;
            //}
            //else
            //{
            //    MessageBox.Show("Masih Ada Yang Salah");
            //    LOGpass = false;
            //    LOGuser = false;
            //}
        }

        private void awal_Load(object sender, EventArgs e)
        {
            dbconn.Open();
            datalogin();
            dbconn.Close();
        }
        public void datalogin()
        {
            string query = "select * from user_";
            OracleCommand cmd = new OracleCommand(query, dbconn);
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
