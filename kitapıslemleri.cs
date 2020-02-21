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
    public partial class kitapıslemleri : Form
    {
        public kitapıslemleri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        Boolean yenikayitmi;
     
        
        void göster()
        {
            string sec = "select * from Kitaplar ";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
            ds.Clear();
            da.Fill(ds, "Kitaplar");
            bs.DataSource = ds.Tables["Kitaplar"];
            dataGridView1.DataSource = bs;
           
        }
        private void kitapıslemleri_Load(object sender, EventArgs e)
        {
            btnekle.Visible = false;
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            göster();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (kitapadi.Text=="" || tbyazaradi.Text=="" || dttemintarihi.Text=="" || tbbasimyili.Text=="" || tbyayimyili.Text=="" || tbrafno.Text=="" || cbturu.Text=="" || tbsayfasayisi.Text=="" )
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
                   
                    komut.CommandText = "insert into  Kitaplar (Kitap_adi,Yazaradisoyadi,temintarihi,Basim,Yayim_Yili,Raf_no,isbn,Tur,Sayfa_sayisi,Stok,resim) values (@Kitap_adi,@Yazaradisoyadi,@temintarihi,@Basim,@Yayim_Yili,@Raf_no,@isbn,@Tur,@Sayfa_sayisi,@Stok,@resim)";
                   
                    //ekleme işlemi yaptık. hangi fildi  kullanıcaksan ona ekle 
                    komut.Parameters.AddWithValue("@Kitap_adi", kitapadi.Text);
                    komut.Parameters.AddWithValue("@Yazaradisoyadi", tbyazaradi.Text);
                    komut.Parameters.AddWithValue("@temintarihi", dttemintarihi.Value);
                    komut.Parameters.AddWithValue("@Basim", tbbasimyili.Text);
                    komut.Parameters.AddWithValue("@Yayim_Yili", tbyayimyili.Text);
                    komut.Parameters.AddWithValue("@Raf_no", tbrafno.Text);
                    komut.Parameters.AddWithValue("@isbn", isbnno.Text);
                    komut.Parameters.AddWithValue("@Tur", cbturu.Text);
                    komut.Parameters.AddWithValue("@Sayfa_sayisi", tbsayfasayisi.Text);
                    komut.Parameters.AddWithValue("@Stok",int.Parse(tbstok.Text));
                    komut.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                

                }
                else //düzelt butonundan gelinmişse update yap
                {
                    komut.CommandText = "update Kitaplar set Kitap_adi=@Kitap_adi,Yazaradisoyadi=@Yazaradisoyadi,temintarihi=@temintarihi,Basim=@Basim,Yayim_Yili=@Yayim_Yili,Raf_no=@Raf_no,isbn=@isbn,Tur=@Tur,Sayfa_sayisi=@Sayfa_sayisi,Stok=@Stok,resim=@resim   where Kitap_id=@Kitap_id";
                    komut.Parameters.AddWithValue("@Kitap_adi", kitapadi.Text);
                    komut.Parameters.AddWithValue("@Yazaradisoyadi", tbyazaradi.Text);
                    komut.Parameters.AddWithValue("@temintarihi", dttemintarihi.Value);
                    komut.Parameters.AddWithValue("@Basim", tbbasimyili.Text);
                    komut.Parameters.AddWithValue("@Yayim_Yili", tbyayimyili.Text);
                    komut.Parameters.AddWithValue("@Raf_no", tbrafno.Text);
                    komut.Parameters.AddWithValue("@isbn", isbnno.Text);
                    komut.Parameters.AddWithValue("@Tur", cbturu.Text);
                    komut.Parameters.AddWithValue("@Sayfa_Sayisi", tbsayfasayisi.Text);
                    komut.Parameters.AddWithValue("@Stok",int.Parse(tbstok.Text));
                    komut.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                    komut.Parameters.AddWithValue("@Kitap_id", int.Parse(tbkitapno.Text));
               
                }
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                göster();
                // bs.Position = kacincikayit;  // en son kaydettiğin kayıtta kalsın.
            }
         



        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            tbkitapno.Clear();
            kitapadi.Clear();
            tbyazaradi.Clear();
            tbbasimyili.Clear();
            tbrafno.Clear();
            tbyayimyili.Clear();
            isbnno.Clear();
            tbstok.Clear();
            cbturu.Text = "";
            tbsayfasayisi.Clear();
            pictureBox1.ImageLocation = "";
            kitapadi.Focus();    //imleci  içine  getir.
            btnekle.Visible =true;
            yenikayitmi = true;
           // kacincikayit = ds.Tables["anabilimdali"].Rows.Count;  //
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {


            kitapadi.Focus();    //imleci  içine  getir.
            btnekle.Visible = true;
            yenikayitmi = false;
          //  kacincikayit = bs.Position;    //bs posisonunu sakla.
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            kitapadi.Text = dataGridView1.CurrentRow.Cells["kitap_adi"].Value.ToString();
            tbyazaradi.Text = dataGridView1.CurrentRow.Cells["Yazaradisoyadi"].Value.ToString();
            tbyayimyili.Text = dataGridView1.CurrentRow.Cells["Yayim_Yili"].Value.ToString();
            cbturu.Text = dataGridView1.CurrentRow.Cells["Tur"].Value.ToString();
            dttemintarihi.Text = dataGridView1.CurrentRow.Cells["temintarihi"].Value.ToString();
            tbstok.Text = dataGridView1.CurrentRow.Cells["Stok"].Value.ToString();
            tbrafno.Text = dataGridView1.CurrentRow.Cells["Raf_no"].Value.ToString();
            tbbasimyili.Text = dataGridView1.CurrentRow.Cells["Basim"].Value.ToString();
            tbkitapno.Text = dataGridView1.CurrentRow.Cells["Kitap_id"].Value.ToString();
           tbsayfasayisi.Text = dataGridView1.CurrentRow.Cells["Sayfa_sayisi"].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["resim"].Value.ToString();
            isbnno.Text = dataGridView1.CurrentRow.Cells["isbn"].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (tbkitapaara.Text == "")
            {
                MessageBox.Show("Siliceğiniz kitabın ismini  arayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult c = MessageBox.Show("Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    OleDbCommand komut = new OleDbCommand("delete from Kitaplar where Kitap_id=@Kitap_id  ", baglanti);
                    komut.Parameters.AddWithValue("@Kitap_id", int.Parse(dataGridView1.CurrentRow.Cells["Kitap_id"].Value.ToString()));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kitap silindi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                    göster();



                }
                tbkitapaara.Clear();



            }
        }

        private void tbkitapaara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from Kitaplar  where Kitap_adi like '%" + tbkitapaara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds.Clear();
            da.Fill(ds, "Kitaplar");
            
        }

        private void btnresimekle_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\resim\\";
            DialogResult sonuc = openFileDialog1.ShowDialog();
            // MessageBox.Show(openFileDialog1.FileName);
            pictureBox1.ImageLocation = openFileDialog1.FileName;
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

        private void btnkayitsayisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1!=null)
            {
                int kayitsayisi;
                kayitsayisi = dataGridView1.RowCount;
                MessageBox.Show(kayitsayisi.ToString());
            }
           
        }
    }
}
