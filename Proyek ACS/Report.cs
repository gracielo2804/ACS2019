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
        CrystalReport1 Daily;
        CrystalReport2 Custom;
        
        private void Btn_buat_Click(object sender, EventArgs e)
        {
            TglAwal.Visible = true;
            if (cmb_pilihan.SelectedIndex == 0)
            {
                LoadData("Daily");
            }
        }
        public void LoadData(string jenis)
        {
            conn.Open();
            try
            {
                Daily.SetDatabaseLogon("proyek","proyek");
                if (jenis=="Daily")
                {
                    Daily = new CrystalReport1();
                    Daily.SetParameterValue("Daily", Date.Value.ToShortDateString());
                    TglAwal.ReportSource = Daily;
                }
                else if (jenis=="Custom")
                {
                    Custom = new CrystalReport2();
                    Custom.SetParameterValue("Tgl_Awal","");
                    Custom.SetParameterValue("Tgl_Akhir", "");
                    TglAwal.ReportSource = Custom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Cmb_pilihan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_pilihan.SelectedIndex>-1)
            {
                if (cmb_pilihan.SelectedIndex == 0)
                {
                    Date.Visible = true;
                    DailyLbl.Visible = true;
                    TglAkhir.Visible = false;
                    TglAwal.Visible = false;
                    TglAwalLbl.Visible = false;
                    TglAkhirLbl.Visible = false;
                }
                else if (cmb_pilihan.SelectedIndex == 3)
                {
                    Date.Visible = false;
                    DailyLbl.Visible = false;
                    TglAkhir.Visible = true;
                    TglAwal.Visible = true;
                    TglAwalLbl.Visible = true;
                    TglAkhirLbl.Visible = true;
                }
                btn_buat.Visible = true;
            }
            
        }
    }
}
