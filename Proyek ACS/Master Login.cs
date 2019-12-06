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
    public partial class Master_Login : Form
    {
        public Pilih form_pilih;
        OracleConnection conn = new OracleConnection("Data Source= xe;User ID=proyek;Password=proyek");
        OracleDataAdapter adapter;
        OracleCommand cmd;
        string iduser;
        public Master_Login()
        {
            InitializeComponent();
        }

        private void Master_Login_Load(object sender, EventArgs e)
        {
            adapter = new OracleDataAdapter("select u.USERNAME,u.NAMA_USER,j.Nama_Jabatan from user_ u,JABATAN j where u.ID_Jabatan=j.ID_Jabatan and j.id_jabatan<3", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            adapter = new OracleDataAdapter("select * from user_ where id_jabatan<3", conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iduser = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (DialogResult.Yes == MessageBox.Show( "Apakah Anda ingin mengeditnya?? ", "Confirmation", MessageBoxButtons.YesNo))
                {
                    Edit_User eu = new Edit_User();
                    eu.form_mLogin = this;
                    eu.lbl_id.Text= iduser;
                    this.Hide();
                    eu.ShowDialog();
                    this.Master_Login_Load(this,e);
                }
            }
            
        }

        private void Master_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_pilih.Show();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            New_User nw = new New_User();
            nw.form_MasterLogin = this;            
            this.Hide();
            nw.ShowDialog();
            this.Master_Login_Load(this, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
