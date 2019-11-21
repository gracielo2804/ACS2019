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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
            //this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2)); Menengahkan
            this.CenterToScreen();
        }
        OracleConnection conn;
        CrystalReport1 cry;
        private void Btn_buat_Click(object sender, EventArgs e)
        {
            Main.Visible = true;
            LoadData();
        }
        public void LoadData()
        {
            conn.Open();
            try
            {
                cry = new CrystalReport1();
                cry.SetDatabaseLogon("proyek","proyek");
                Main.ReportSource = cry;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}
