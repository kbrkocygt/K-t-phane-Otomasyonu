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
    public partial class uyeislemleri : Form
    {
        public uyeislemleri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
       // OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        Boolean yenikayitmi;
        void göster()
        {
            string sec = "select * from Uyeler ";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
            ds.Clear();
            da.Fill(ds, "Uyeler");
           
            
        }
        private void uyeislemleri_Load(object sender, EventArgs e)
        {
            btnekle.Visible = false;
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            göster();
            bs.DataSource = ds.Tables["Uyeler"];
            dataGridView1.DataSource = bs;
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (tbadi.Text == "" || tbsoyadi.Text == "" || tbtcno.Text == "" || tbtel.Text == "" || tbadres.Text == "" || tbmail.Text == "" || cbcinsiyet.Text == "" || dtdogumtarihi.Text == "" || cbdogumyeri.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbCommand komut = new OleDbCommand();   //baglantı sayesinde veri tabanına baglanır
                komut.Connection = baglanti;      //baglantı ve komutu ilişkilendir.
                btnekle.Visible = false;
                if (yenikayitmi)    //yeni butanundan gelmişse ekle
                {

                    komut.CommandText = "insert into  Uyeler (Ad,Soyad,tcno,dogumT,dogumY,Cinsiyet,Gsm,Mail,Adres,okudugukitapsayisi) values (@Ad,@Soyad,@tcno,@dogumT,@dogumY,@Cinsiyet,@Gsm,@Mail,@Adres,@okudugukitapsayisi)";
                    //ekleme işlemi yaptık. hangi fildi  kullanıcaksan ona ekle 
                    komut.Parameters.AddWithValue("@Ad", tbadi.Text);
                    komut.Parameters.AddWithValue("@Soyad", tbsoyadi.Text);
                    komut.Parameters.AddWithValue("@tcno", tbtcno.Text);
                    komut.Parameters.AddWithValue("@dogumT", dtdogumtarihi.Text);
                    komut.Parameters.AddWithValue("@dogumY", cbdogumyeri.Text);
                    komut.Parameters.AddWithValue("@Cinsiyet", cbcinsiyet.Text);
                    komut.Parameters.AddWithValue("@Gsm", tbtel.Text);
                    komut.Parameters.AddWithValue("@Mail", tbmail.Text);
                    komut.Parameters.AddWithValue("@Adres", tbadres.Text);
                    komut.Parameters.AddWithValue("@okudugukitapsayisi", int.Parse(tbokudugukitapsayisi.Text));


                    //sorguyu çalıştırır

                }

                else //düzelt butonundan gelinmişse update yap
                {
                    komut.CommandText = "update Uyeler set Ad=@Ad,Soyad=@Soyad,tcno=@tcno,dogumT=@dogumT,dogumY=@dogumY,Cinsiyet=@Cinsiyet,Gsm=@Gsm,Mail=@Mail,Adres=@Adres,okudugukitapsayisi=@okudugukitapsayisi where Uye_id=@Uye_id";
                    komut.Parameters.AddWithValue("@Ad", tbadi.Text);
                    komut.Parameters.AddWithValue("@Soyad", tbsoyadi.Text);
                    komut.Parameters.AddWithValue("@tcno", tbtcno.Text);
                    komut.Parameters.AddWithValue("@dogumT", dtdogumtarihi.Text);
                    komut.Parameters.AddWithValue("@dogumY", cbdogumyeri.Text);
                    komut.Parameters.AddWithValue("@Cinsiyet", cbcinsiyet.Text);
                    komut.Parameters.AddWithValue("@Gsm", tbtel.Text);
                    komut.Parameters.AddWithValue("@Mail", tbmail.Text);
                    komut.Parameters.AddWithValue("@Adres", tbadres.Text);
                    komut.Parameters.AddWithValue("@okudugukitapsayisi", int.Parse(tbokudugukitapsayisi.Text));
                    komut.Parameters.AddWithValue("@Uye_id", int.Parse(tbuyeno.Text));

                }

                komut.ExecuteNonQuery();

                MessageBox.Show("Üye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                göster();
                // bs.Position = kacincikayit;  // en son kaydettiğin kayıtta kalsın.
            }






        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            tbuyeno.Clear();
            tbadi.Clear();
            tbtcno.Clear();
            dtdogumtarihi.Text = "";
            cbdogumyeri.Text = "";
            cbcinsiyet.Text = "";
            tbtel.Clear();
            tbmail.Clear();
            tbadres.Text = "";


            tbadi.Focus();    //imleci  içine  getir.
            btnekle.Visible = true;
            yenikayitmi = true;
        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {

            tbadi.Focus();    //imleci  içine  getir.
            btnekle.Visible = true;
            yenikayitmi = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbadi.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            tbsoyadi.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            tbtcno.Text = dataGridView1.CurrentRow.Cells["tcno"].Value.ToString();
            tbtel.Text = dataGridView1.CurrentRow.Cells["Gsm"].Value.ToString();
            dtdogumtarihi.Text = dataGridView1.CurrentRow.Cells["dogumT"].Value.ToString();
            cbdogumyeri.Text = dataGridView1.CurrentRow.Cells["dogumY"].Value.ToString();
            cbcinsiyet.Text = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            
            tbmail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            tbadres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            tbokudugukitapsayisi.Text = dataGridView1.CurrentRow.Cells["okudugukitapsayisi"].Value.ToString();
            tbuyeno.Text = dataGridView1.CurrentRow.Cells["Uye_id"].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (tbtcara.Text == "")
            {
                MessageBox.Show("Siliceğiniz kişinin tc numarasını  giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult c = MessageBox.Show("Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    OleDbCommand komut = new OleDbCommand("delete from Uyeler where Uye_id=@Uye_id  ", baglanti);
                    komut.Parameters.AddWithValue("@Uye_id", int.Parse(dataGridView1.CurrentRow.Cells["Uye_id"].Value.ToString()));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye silindi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    göster();
                    tbtcara.Clear();


                }

            }
        }

        private void tbtcara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from Uyeler  where tcno like '%" + tbtcno.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds.Clear();
            da.Fill(ds, "Uyeler");
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü ac = new anamenü();
            ac.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}