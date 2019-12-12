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
    public partial class New_User : Form
    {
        public Master_Login form_MasterLogin;
        OracleDataAdapter adapter;
        public static OracleConnection conn;
        OracleCommand cmd = new OracleCommand();
        OracleDataReader reader;
        public New_User()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            bool cekinput = true;
            if (txt_nama.Text == "")
            {
                cekinput = false;
            }
            if (txt_password.Text == "")
            {
                cekinput = false;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                cekinput = false;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                cekinput = false;
            }
            if (txtUser.Text=="")
            {
                cekinput = false;
            }
            if (cekinput == true)
            {
                bool cekmanager = true;
                if (comboBox1.SelectedValue.ToString()=="2")
                {
                    cmd = new OracleCommand("select * from user_ where id_cabang='" + comboBox2.SelectedValue.ToString() + "'", conn);
                    cekmanager = true;
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetValue(3).ToString() == "2")
                        {
                            cekmanager = false;
                            break;
                        }
                    }
                }
                if (cekmanager==true)
                {
                    try
                    {
                        cmd = new OracleCommand("Select * from user_", conn);
                        reader = cmd.ExecuteReader();
                        bool cekuser = true;
                        while (reader.Read())
                        {
                            if (reader.GetValue(0).ToString() == txtUser.Text)
                            {
                                cekuser = false;
                                break;
                            }
                        }
                        if (cekuser == true)
                        {
                            cmd = new OracleCommand("insert into user_ values('" + txtUser.Text + "','" + txt_nama.Text + "','" + txt_password.Text + "'," + comboBox1.SelectedValue.ToString() + ",'" + comboBox2.SelectedValue.ToString() + "')", conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Berhasil Add User Baru");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username Sudah Digunakan");
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Sudah Ada Manager di cabang ini");
                }
                
            }
            else 
            {
                MessageBox.Show("Data tidak Lengkap");
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void New_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_MasterLogin.Show();
        }

        private void New_User_Load(object sender, EventArgs e)
        {
            adapter = new OracleDataAdapter("Select * from cabang", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.ValueMember = "ID_cabang";
            comboBox2.DisplayMember = "Nama_Cabang";
            adapter = new OracleDataAdapter("Select * from jabatan where id_jabatan<3", conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.ValueMember = "ID_Jabatan";
            comboBox1.DisplayMember = "Nama_Jabatan";
        }
    }
}
