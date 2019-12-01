﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class Inventory : Form
    {
        public string parent="";
        OracleConnection conn;
        public awal form_awal;
        public Pilih form_pilih;
        public pilimanager form_pilih_manager;
        public int id_jabatan;
        public string id_user;
        OracleDataAdapter adapter;
        
        public Inventory()
        {
            InitializeComponent();
            conn = new OracleConnection("Data source=xe;User ID=proyek;Password=proyek");
        }

        private void Inventory_Load(object sender, EventArgs e)
        { 
            bool cekkaryawan = true;
            if (id_jabatan==1)
            {
                cekkaryawan = true;
                button2.Visible = false;
                button3.Text = "Logout";
            }
            else if (id_jabatan==2)
            {
                cekkaryawan = false;
                button2.Visible = true;
                button3.Text = "Back";
            }
            else if (id_jabatan == 3)
            {
                cekkaryawan = false;
                button2.Visible = true;
                button3.Text = "Back";
            }
            if (cekkaryawan)
            {
                adapter = new OracleDataAdapter("select * from cabang where id_cabang in (select id_cabang from user_ where username='"+id_user+"')", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "ID_cabang";
                comboBox1.DisplayMember = "Nama_cabang";
            }
            else
            {
                adapter = new OracleDataAdapter("select * from cabang", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "ID_cabang";
                comboBox1.DisplayMember = "Nama_cabang";
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                adapter = new OracleDataAdapter("select st.id_sepatu as \"ID Sepatu\",s.nama_sepatu \"Nama Sepatu\" ,st.jumlah_sepatu as Jumlah,st.warna_sepatu as \"Warna Sepatu\" from stok st,sepatu s,cabang c where c.id_cabang=st.id_cabang and st.id_sepatu=s.id_sepatu and c.id_cabang='" + comboBox1.SelectedValue+"'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                

                //for(int i = 0; i < dt.Rows.Count; i++)
                //{
                //    try
                //    {
                //        //path gambar dari sepatu
                //        string newPath = AppDomain.CurrentDomain.BaseDirectory + "picture";
                //        string destFile = Path.Combine(newPath, dt.Rows[i].ItemArray[0].ToString() + ".jpg");

                //        if (destFile != null)
                //        {
                //            //ambil gambar
                //            Image img = Image.FromFile(destFile);

                //            //resize image yang di uploadd
                //            Bitmap objBitmap = new Bitmap(img, new Size(100, 100));

                //            //insert tiap row
                //            dataGridView1.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), (Image)objBitmap);
                //        }
                //    }
                //    catch(Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent=="awal")
            {
                form_awal.Show();
            }
            else if (parent=="pilih")
            {
                form_pilih.Show();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            New n = new New();
            n.form_inventory = this;
            this.Hide();
            n.ShowDialog();
            this.Inventory_Load(this,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete_Barang db = new Delete_Barang();
            db.id_perusahaan = comboBox1.SelectedValue.ToString();
            this.Hide();
            db.ShowDialog();
            this.Show();
            Inventory_Load(this, e);
        }
    }
}
