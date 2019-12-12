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
    public partial class EditContact : Form
    {
        public static OracleConnection conn;
        List<string> list_nama = new List<string>();
        List<string> list_alamat = new List<string>();
        List<string> list_id = new List<string>();

        public EditContact()
        {
            InitializeComponent();
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                comboBox1.DataSource = null;
                OracleDataAdapter adapt = new OracleDataAdapter("SELECT * FROM HSUPPLIER", conn);
                DataTable dtb = new DataTable();
                adapt.Fill(dtb);
                comboBox1.DataSource=dtb;
                comboBox1.DisplayMember = "ID_SUPPLIER";
                for(int i = 0; i < dtb.Rows.Count; i++)
                {
                    list_id.Add(dtb.Rows[i].ItemArray[0].ToString());
                    list_nama.Add(dtb.Rows[i].ItemArray[1].ToString());
                    list_alamat.Add(dtb.Rows[i].ItemArray[2].ToString());
                }

                txt_nama.Text = "";
                txt_alamat.Text = "";
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_nama.Count > 0)
            {
                txt_nama.Text = list_nama[comboBox1.SelectedIndex];
                txt_alamat.Text = list_alamat[comboBox1.SelectedIndex];
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string id = list_id[comboBox1.SelectedIndex];
            string nama = txt_nama.Text;
            string alamat = txt_alamat.Text;
            OracleCommand temp_comm = new OracleCommand("UPDATE HSUPPLIER SET NAMA_PERUSAHAAN='" + nama + "' , ALAMAT='" + alamat + "' WHERE ID_SUPPLIER = '" + id + "' ", conn);
            temp_comm.ExecuteNonQuery();
            MessageBox.Show("Success!!");
            comboBox1.SelectedIndex = 0;
            txt_nama.Text = "";
            txt_alamat.Text = "";

            reload();
        }

        private void reload()
        {
            try
            {
                list_id.Clear();
                list_nama.Clear();
                list_alamat.Clear();
                conn.Close();
                conn.Open();
                comboBox1.DataSource = null;
                OracleDataAdapter adapt = new OracleDataAdapter("SELECT * FROM HSUPPLIER", conn);
                DataTable dtb = new DataTable();
                adapt.Fill(dtb);
                comboBox1.DataSource = dtb;
                comboBox1.DisplayMember = "ID_SUPPLIER";
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    list_id.Add(dtb.Rows[i].ItemArray[0].ToString());
                    list_nama.Add(dtb.Rows[i].ItemArray[1].ToString());
                    list_alamat.Add(dtb.Rows[i].ItemArray[2].ToString());
                }

                txt_nama.Text = "";
                txt_alamat.Text = "";
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
