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
    public partial class personelgirisi : Form
    {
        public personelgirisi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        OleDbDataReader oku;
        BindingSource bs = new BindingSource();
        private void btngiris_Click(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("select * from calisanlar where kullaniciadi='" + kullniciadi.Text.ToString() + "' and sifre='" + sifre.Text.ToString() + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                anamenü ac = new anamenü();
                ac.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void personelgirisi_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            sifre.PasswordChar = '*';

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                sifre.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                sifre.PasswordChar = '*';
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
