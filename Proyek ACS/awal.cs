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
        DataSet ds;

        private void btn_login_Click(object sender, EventArgs e)
        {
            datalogin();
            bool cek = false;
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["name"].ToString()==txt_uname.Text && row["pass"].ToString()==txt_password.Text)
                    {
                        cek = true;
                        MessageBox.Show("Berhasil Login");
                        if (row["Jabatan"].ToString() == "3")
                        {
                            this.Hide();
                            Pilih p = new Pilih();
                            p.form_awal = this;
                            p.id_jabatan = int.Parse(row["Jabatan"].ToString());
                            p.id_user=row["name"].ToString();
                            p.user = this.user;
                            p.namauser= row["nama"].ToString();
                            this.Hide();
                            p.ShowDialog();
                            this.Show();
                        }
                        else if (row["Jabatan"].ToString()=="2")
                        {
                            this.Hide();
                            pilimanager pm = new pilimanager();
                            pm.form_awal = this;
                            pm.id_jabatan = int.Parse(row["Jabatan"].ToString());
                            pm.id_user = row["name"].ToString();
                            pm.user = this.user;
                            pm.namauser= row["nama"].ToString();
                            this.Hide();
                            pm.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            this.Hide();
                            Inventory i = new Inventory();
                            i.id_jabatan = int.Parse(row["Jabatan"].ToString());
                            i.id_user = row["name"].ToString();
                            i.form_awal = this;
                            i.parent = "awal";
                            i.lbl_nama.Text=row["nama"].ToString();
                            i.Show();
                        }
                    }
                }
            }
            if (cek==false)
            {
                MessageBox.Show("Password / Username Salah");
            }
        }

        private void awal_Load(object sender, EventArgs e)
        {
            datalogin();
        }
        public void datalogin()
        {
            dbconn.Open();
            string query = "select USERNAME as name,PASSWORD as pass, ID_Jabatan as jabatan,Nama_user as nama from user_";
            OracleCommand cmd = new OracleCommand(query, dbconn);
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            dbconn.Close();
        }
    }
}
