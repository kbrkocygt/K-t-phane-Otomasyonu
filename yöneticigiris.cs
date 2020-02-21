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
    public partial class yöneticigiris : Form
    {
        public yöneticigiris()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader oku;
        private void btngiris_Click(object sender, EventArgs e)
        {

            if (kullniciadi.Text == "" && sifre.Text == "")
            {
                MessageBox.Show("Giriş bilgilerini doldurunuz");
            }
            else if (kullniciadi.Text == "")
            {
                MessageBox.Show("Kullanıcı adını boş bırakmayınız");
            }
            else if (sifre.Text == "")
            {
                MessageBox.Show("Şifreyi boş bırakmayınız");
            }
            else
            {
               
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM yönetici where k_ad='" + kullniciadi.Text + "' AND k_sifre='" + sifre.Text + "'";
                oku = komut.ExecuteReader();
                if (oku.Read())  //kontrol et dogruysa  form2ye gec
                {

                    personelekle ac = new personelekle();
                    ac.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                }
                baglanti.Close();
            }
        }

        private void yöneticigiris_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            girispaneli ac = new girispaneli();
            ac.Show();
            this.Hide();
             
        }
    }
}
