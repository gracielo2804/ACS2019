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
    public partial class Edit_User : Form
    {
        public Master_Login form_mLogin;
        OracleDataAdapter adapter;
        OracleConnection conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        OracleCommand cmd = new OracleCommand();
        public Edit_User()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_mLogin.Show();
        }

        private void Edit_User_Load(object sender, EventArgs e)
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool cekinput = true;
            if (txt_nama.Text=="")
            {
                cekinput = false;
            }
            if (txt_password.Text=="")
            {
                cekinput = false;
            }
            if (comboBox1.SelectedIndex==-1)
            {
                cekinput = false;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                cekinput = false;
            }
            if (cekinput==true)
            {
                conn.Close(); conn.Open();
                try
                {
                    if (comboBox1.SelectedValue.ToString() == "2")
                    {
                        string id_cabang = comboBox2.SelectedValue.ToString();
                        cmd = new OracleCommand("select * from user_ where id_cabang='" + id_cabang + "'", conn);
                        bool cekmanager = true;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetValue(3).ToString() == "2")
                            {
                                cekmanager = false;
                                break;
                            }
                        }
                        if (cekmanager == true)
                        {
                            cmd = new OracleCommand("update user_ set nama_user='" + txt_nama.Text + "',password='" + txt_password.Text + "',id_cabang='" + comboBox2.SelectedValue.ToString() + "',id_jabatan='" + comboBox1.SelectedValue.ToString() + "' where username='" + lbl_id.Text + "'", conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Berhasil update data user");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sudah ada manager di cabang ini");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan,Update dibatalkan");
                }
            }
            else
            {
                MessageBox.Show("Data tidak Lengkap");
            }
        }
    }
}
