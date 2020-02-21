using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PROJE
{
    public partial class girispaneli : Form
    {
        public girispaneli()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        private void btnyoneticigiris_Click(object sender, EventArgs e)
        {
            yöneticigiris ac = new yöneticigiris();
            ac.Show();
            this.Hide();
        }

        private void girispaneli_Load(object sender, EventArgs e)
        {

        }

        private void btpersonelgiris_Click(object sender, EventArgs e)
        {
            personelgirisi ac = new personelgirisi();
            ac.Show();
            this.Hide();
        }

        private void cikis_Click(object sender, EventArgs e)
        {

            DialogResult c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
