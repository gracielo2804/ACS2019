using System;
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
    public partial class Inventory : Form
    {
        public awal form_awal;
        public Pilih form_pilih;
        public int id_jabatan;
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            if (id_jabatan==1)
            {
                button2.Visible = false;
                button3.Text = "Logout";
            }
            else if (id_jabatan==2)
            {
                button2.Visible = true;
                button3.Text = "Logout";
            }
            else if (id_jabatan == 3)
            {
                button2.Visible = true;
                button3.Text = "Back";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text=="Logout")
            {
                form_awal.Show();
                this.Close();                
            }
            else
            {
                form_pilih.Show();
                this.Close();
            }
        }
    }
}
