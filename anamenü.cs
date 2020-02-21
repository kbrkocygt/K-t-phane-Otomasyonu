using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class anamenü : Form
    {
        public anamenü()
        {
            InitializeComponent();
        }

        private void btnkitapislemleri_Click(object sender, EventArgs e)
        {
            kitapıslemleri ac = new kitapıslemleri();
            ac.Show();
            this.Hide();
        }

        private void btnuyeislemi_Click(object sender, EventArgs e)
        {
            uyeislemleri ac = new uyeislemleri();
            ac.Show();
            this.Hide();
        }

        private void btnteslimver_Click(object sender, EventArgs e)
        {
            emanetver ac = new emanetver();
            ac.Show();
            this.Hide();
        }

       

        private void anamenü_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToString();
           
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnteslimal_Click(object sender, EventArgs e)
        {
            emanetteslimal ac = new emanetteslimal();
            ac.Show();
            this.Hide();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            emanetlistele ac = new emanetlistele();
            ac.Show();
            this.Hide();
        }

        private void btnyayinevleri_Click(object sender, EventArgs e)
        {
            yayinevleri ac = new yayinevleri();
            ac.Show();
            this.Hide();
        }
    }
}
