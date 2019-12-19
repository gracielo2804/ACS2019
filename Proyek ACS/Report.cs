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
using CrystalDecisions.Shared;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public static OracleConnection conn;
        public static string IP;
        public static string ID,password;
        OracleDataAdapter ad;
        OracleCommand cmd;
        DataTable dt;
        CrystalReport2 cry;

        private void Btn_buat_Click(object sender, EventArgs e)
        {
            if (CabangCmb.SelectedIndex > -1)
            {
                if (cmb_pilihan.SelectedIndex == 0)
                {
                    LoadData("Daily");
                }
                else if (cmb_pilihan.SelectedIndex == 1)
                {
                    if (BulanCmb.SelectedIndex > -1 && TahunCmbBulanan.SelectedIndex > -1)
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
                    if (TahunCmbTahunan.SelectedIndex > -1)
                    {
                        LoadData("Yearly");
                    }
                    else
                    {
                        MessageBox.Show("mohom memilih tahun terlebih dahulu");
                    }
                }
                else if (cmb_pilihan.SelectedIndex == 3)
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
            else
            {
                MessageBox.Show("Harap Memilih Cabang");
            }

        }
        public void LoadData(string jenis)
        {
            conn.Open();
            try
            {
                cry = new CrystalReport2();
                cry.SetParameterValue("ID", "SP");
                cry.SetDatabaseLogon(ID, password);
                TextObject txt;
                TextObject Cabang;
                Cabang = cry.ReportDefinition.ReportObjects["Cabang"] as TextObject;
                txt = cry.ReportDefinition.ReportObjects["BulanTxt"] as TextObject;
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in cry.Database.Tables)
                {
                    TableLogOnInfo ci = new TableLogOnInfo();
                    ci.ConnectionInfo.DatabaseName = "";
                    ci.ConnectionInfo.ServerName = IP;
                    ci.ConnectionInfo.UserID = ID;
                    ci.ConnectionInfo.Password = password;
                    table.ApplyLogOnInfo(ci);
                }
                if (jenis == "Custom")
                {
                    cry.SetParameterValue("Tgl_Awal", TglAwal.Value.ToString("dd/MM/yyyy"));
                    cry.SetParameterValue("Tgl_Akhir", TglAkhir.Value.ToString("dd/MM/yyyy"));
                    cry.SetParameterValue("Jenis", "Custom");
                    txt.Text = TglAwal.Value.ToString("dd/MM/yyyy") + " - " + TglAkhir.Value.ToString("dd/MM/yyyy");
                }
                else if (jenis == "Monthly")
                {
                    string a = "1/" + BulanCmb.SelectedItem.ToString() + "/" + TahunCmbBulanan.SelectedItem.ToString().Substring(2, 2);
                    cry.SetParameterValue("Tgl_awal", Convert.ToDateTime(a).ToString("dd/MM/yyyy"));
                    cmd = new OracleCommand($"Select last_day('{a}') from dual", conn);
                    ad = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    cry.SetParameterValue("Tgl_Akhir", Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString()));
                    cry.SetParameterValue("Jenis", "Bulan");
                    txt.Text = BulanCmb.SelectedItem.ToString() + " - " + TahunCmbBulanan.SelectedItem.ToString();
                }
                else if (jenis == "Yearly")
                {
                    cry.SetParameterValue("Tgl_Awal", Convert.ToDateTime("01/January/" + TahunCmbTahunan.SelectedItem.ToString()));
                    cry.SetParameterValue("Tgl_Akhir", Convert.ToDateTime("31/December/" + TahunCmbTahunan.SelectedItem.ToString()));
                    cry.SetParameterValue("Jenis", "Tahun");
                    txt.Text = TahunCmbTahunan.SelectedItem.ToString();
                }
                else if (jenis == "Daily")
                {
                    cry.SetParameterValue("Tgl_Awal", Date.Value.ToString("dd/MM/yyyy"));
                    cry.SetParameterValue("Tgl_Akhir", Date.Value.ToString("dd/MM/yyyy"));
                    cry.SetParameterValue("ID", "SP");
                    cry.SetParameterValue("Jenis", "Daily");
                    txt.Text = Date.Value.ToString("dd/MM/yyyy");
                }
                cry.SetParameterValue("IDCabang",CabangCmb.SelectedValue);
                Cabang.Text = "Nama Cabang : " + namaCabang();
                Main.ReportSource = cry;
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
            if (cmb_pilihan.SelectedIndex > -1)
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
                Main.Visible = false;
                if (cmb_pilihan.SelectedIndex == 0)
                {
                    Date.Visible = true;
                    DailyLbl.Visible = true;
                }
                else if (cmb_pilihan.SelectedIndex == 1)
                {
                    BulanCmb.Visible = true;
                    BulanLbl.Visible = true;
                    TahunCmbBulanan.Visible = true;
                    TahunLblBulanan.Visible = true;
                }
                else if (cmb_pilihan.SelectedIndex == 2)
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
            cmd = new OracleCommand("Select * from cabang", conn);
            ad = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            CabangCmb.DataSource = ds.Tables[0];
            CabangCmb.DisplayMember = "NAMA_CABANG";
            CabangCmb.ValueMember = "ID_CABANG";
            conn.Close();
        }
        private void Btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string namaCabang()
        {
            cmd = new OracleCommand($"Select initcap(NAMA_CABANG) from cabang where id_cabang ='{CabangCmb.SelectedValue}'", conn);
            ad = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
