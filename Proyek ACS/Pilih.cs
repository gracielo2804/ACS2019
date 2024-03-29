﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Pilih : Form
    {
        public Pilih()
        {
            InitializeComponent();
        }
        public string user;
        public string namauser;
        public string id_user;
        public int id_jabatan;
        public awal form_awal;        

        private void button1_Click(object sender, EventArgs e)
        {            
            Master_Login m = new Master_Login();
            m.form_pilih = this;
            m.lbl_nama.Text = this.namauser;
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void Pilih_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.form_pilih = this;
            i.id_jabatan = this.id_jabatan;
            i.id_user = id_user;
            i.parent = "pilih";
            i.lbl_nama.Text = this.namauser;
            this.Hide();
            i.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }

        private void Pilih_FormClosing(object sender, FormClosingEventArgs e)
        {
            //form_awal.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Show();

        }
    }
}
