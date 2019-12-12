using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
            //try
            //{
            //    conn = new OracleConnection("Data Source=" +
            //        "(DESCRIPTION=" +
            //        "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            //        "(HOST=LOCALHOST)(PORT=1521)))" +
            //        "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
            //        "user id=proyek;password=proyek");
            //    conn.Open();
            //    MessageBox.Show("Berhasil");
            //    conn.Close();
            //}
            //catch (OracleException e)
            //{
            //    MessageBox.Show(e.Message);
            //}
            this.CenterToScreen();
        }
        OracleConnection conn;
        OracleDataAdapter ad;
        OracleCommand cmd;
        DataTable dt;
        CrystalReport1 Daily;
        CrystalReport2 Custom;
        public string KodeBarang;
        
        private void Btn_buat_Click(object sender, EventArgs e)
        {
            if (cmb_pilihan.SelectedIndex == 0)
            {
                LoadData("Daily");
            }
            else if (cmb_pilihan.SelectedIndex == 1)
            {
                if (BulanCmb.SelectedIndex >-1 && TahunCmbBulanan.SelectedIndex > -1)
                {
                    LoadData("Monthly");
                }
                else
                {
                    MessageBox.Show("Mohon Memilih bulan dan tahun terlebih dahulu");
                }
            }
            else if (cmb_pilihan.SelectedIndex == 2)
            {
                if (TahunCmbTahunan.SelectedIndex>-1)
                {
                    LoadData("Yearly");
                }
                else
                {
                    MessageBox.Show("mohom memilih tahun terlebih dahulu");
                }
            }
            else if (cmb_pilihan.SelectedIndex==3)
            {
                if (TglAwal.Value < TglAkhir.Value)
                {
                    LoadData("Custom");
                }
                else
                {
                    MessageBox.Show("Input Tanggal Salah");
                }
            }
        }
        public void LoadData(string jenis)
        {
            conn.Open();
            try
            {
                if (jenis=="Daily")
                {
                    Daily = new CrystalReport1();
                    Daily.SetDatabaseLogon("proyek", "proyek");
                    Daily.SetParameterValue("Daily", Date.Value);
                    Daily.SetParameterValue("ID", this.KodeBarang);
                    Main.ReportSource = Daily;
                }
                else 
                {
                    Custom = new CrystalReport2();
                    Daily.SetParameterValue("ID", this.KodeBarang);
                    TextObject txt;
                    txt = Custom.ReportDefinition.ReportObjects["BulanTxt"] as TextObject;
                    Custom.SetDatabaseLogon("proyek", "proyek");
                    if (jenis == "Custom")
                    {
                        Custom.SetParameterValue("Tgl_Awal", TglAwal.Value.ToString("dd/MM/yyyy"));
                        Custom.SetParameterValue("Tgl_Akhir", TglAkhir.Value.ToString("dd/MM/yyyy"));
                        Custom.SetParameterValue("Jenis", "Custom");
                        txt.Text = "";
                    }
                    else if (jenis== "Monthly")
                    {
                        string a = "1/" + BulanCmb.SelectedItem.ToString()+"/"+ TahunCmbBulanan.SelectedItem.ToString().Substring(2, 2);
                        Custom.SetParameterValue("Tgl_awal", Convert.ToDateTime(a).ToString("dd/MM/yyyy"));
                        cmd = new OracleCommand($"Select last_day('{a}') from dual",conn);
                        ad = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ad.Fill(ds);
                        Custom.SetParameterValue("Tgl_Akhir", Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString()));
                        Custom.SetParameterValue("Jenis", "Bulan");
                        txt.Text = BulanCmb.SelectedItem.ToString()+" - "+ TahunCmbBulanan.SelectedItem.ToString();
                    }
                    else if (jenis== "Yearly")
                    {
                        Custom.SetParameterValue("Tgl_Awal", Convert.ToDateTime("01/January/"+TahunCmbTahunan.SelectedItem.ToString()));
                        Custom.SetParameterValue("Tgl_Akhir", Convert.ToDateTime("31/December/" + TahunCmbTahunan.SelectedItem.ToString()));
                        Custom.SetParameterValue("Jenis", "Tahun");
                        txt.Text = TahunCmbTahunan.SelectedItem.ToString();
                    }
                    Main.ReportSource = Custom;
                }
                Main.Visible = true;
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
                Date.Visible = false;
                DailyLbl.Visible = false;
                BulanCmb.Visible = false;
                BulanLbl.Visible = false;
                TahunCmbBulanan.Visible = false;
                TahunLblBulanan.Visible = false;
                TahunCmbTahunan.Visible = false;
                TahunLbl.Visible = false;
                TglAkhir.Visible = false;
                TglAwal.Visible = false;
                TglAwalLbl.Visible = false;
                TglAkhirLbl.Visible = false;
                if (cmb_pilihan.SelectedIndex == 0)
                {
                    Date.Visible = true;
                    DailyLbl.Visible = true;
                }
                else if (cmb_pilihan.SelectedIndex==1)
                {
                    BulanCmb.Visible = true;
                    BulanLbl.Visible = true;
                    TahunCmbBulanan.Visible = true;
                    TahunLblBulanan.Visible = true;
                }
                else if (cmb_pilihan.SelectedIndex==2)
                {
                    TahunCmbTahunan.Visible = true;
                    TahunLbl.Visible = true;
                }
                else if (cmb_pilihan.SelectedIndex == 3)
                {
                    TglAkhir.Visible = true;
                    TglAwal.Visible = true;
                    TglAwalLbl.Visible = true;
                    TglAkhirLbl.Visible = true;
                }
                btn_buat.Visible = true;
            }
            
        }

        private void Report_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select max(TANGGAL_LOG) as max, min(TANGGAL_LOG) as min from LOG_SEPATU", conn);
            ad = new OracleDataAdapter(cmd);
            dt = new DataTable();
            ad.Fill(dt);
            DataRow row = dt.Rows[0];
            int max = Convert.ToInt32(Convert.ToDateTime(row["max"]).ToString("yyyy"));
            int min = Convert.ToInt32(Convert.ToDateTime(row["min"]).ToString("yyyy"));
            for (int i = min; i <= max; i++)
            {
                TahunCmbBulanan.Items.Add(i);
                TahunCmbTahunan.Items.Add(i);
            }
            conn.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Mutasi m = new Mutasi();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
