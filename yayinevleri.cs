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
    public partial class yayinevleri : Form
    {
        public yayinevleri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        Boolean yenikayitmi;
        int kacincikayit;
        void yayievleri()
        {

            string sec = "select yaev.*,Kitaplar.Kitap_adi from YayinEvleri as yaev, Kitaplar as Kitaplar where yaev.Kitap_id=Kitaplar.Kitap_id";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);   //dataadapteri olusturduk.
            if (ds.Tables["YayinEvleri"] != null)
                ds.Tables["YayinEvleri"].Clear();

            da.Fill(ds, "YayinEvleri");
        }
        void kayitlarisil()
        {
            string silkomutu = "delete from YayinEvleri where Yayinevi_id=@Yayinevi_id ";
            OleDbCommand komut = new OleDbCommand(silkomutu, baglanti);
            komut.Parameters.AddWithValue("@Kitap_id", int.Parse(yayineviid.Text));
            komut.ExecuteNonQuery();
        }

        private void yayinevleri_Load(object sender, EventArgs e)
        {
            ekle.Visible = false;
            yayievleri();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            bs.DataSource = ds.Tables["YayinEvleri"];  //data setin bölümler tablesinden verileri alsın.
            dataGridView1.DataSource = bs;  //forma bagladık.
            yayineviid.DataBindings.Add("Text", bs, "yayinevi_id"); //textboxun baglantısına text özelliğine bagla
            tbyayineviadi.DataBindings.Add("Text", bs, "yayinevi_ad");
            tbtelno.DataBindings.Add("Text", bs, "telefon");
            tbadres.DataBindings.Add("Text", bs, "Adres");
            kadi.DataBindings.Add("SelectedValue", bs, "Kitap_id");


            string seckomutu = "select * from Kitaplar";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            da.Fill(ds, "Kitaplar");  //  da datasetin bolumler tablosunu dolduruyo
            kadi.DataSource = ds.Tables["Kitaplar"];
            kadi.ValueMember = "Kitap_id";  //arka planda tutucagı kısım
            kadi.DisplayMember = "Kitap_adi"; //ön pland tutar yani bizim gordugumuz.

        }

        private void ekle_Click(object sender, EventArgs e)
        {
            ekle.Visible = false;
            tbadres.ReadOnly = true;
            tbtelno.ReadOnly = true;
            tbyayineviadi.ReadOnly = true;
            yayineviid.ReadOnly = true;
            if (yenikayitmi)
            {
                string eklekomutu = "insert into YayinEvleri (Kitap_id,Yayinevi_ad,telefon,Adres) values (@Kitap_id,@Yayinevi_ad,@telefon,@Adres)";
                OleDbCommand komut = new OleDbCommand(eklekomutu, baglanti);
                komut.Parameters.AddWithValue("@Kitap_id", kadi.SelectedValue);
                komut.Parameters.AddWithValue("@Yayinevi_ad", tbyayineviadi.Text);
                komut.Parameters.AddWithValue("@telefon", tbtelno.Text);
                komut.Parameters.AddWithValue("@Adres", tbadres.Text);
                komut.ExecuteNonQuery();

            }
            else
            // else düzenle kaydet
            {
                string duzenlekomutu = "update YayinEvleri set  Kitap_id=@Kitap_id ,Yayinevi_ad=@Yayinevi_ad ,telefon=@telefon,Adres=@Adres where Yayinevi_id=@Yayinevi_id";
                OleDbCommand komut = new OleDbCommand(duzenlekomutu, baglanti);
                komut.Parameters.AddWithValue("@Kitap_id", kadi.SelectedValue);
                komut.Parameters.AddWithValue("@Yayinevi_ad", tbyayineviadi.Text);
                komut.Parameters.AddWithValue("@telefon", tbtelno.Text);
                komut.Parameters.AddWithValue("@Adres", tbadres.Text);
                komut.Parameters.AddWithValue("@Yayinevi_id", int.Parse(yayineviid.Text));
                komut.ExecuteNonQuery();



            }
            MessageBox.Show("Kayıt Tamamlandı");
            yeni.Visible = true;
            yayievleri();
            kacincikayit = bs.Position;  //en kaldıgı kayıt
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            tbyayineviadi.Clear();
            tbtelno.Clear();
            tbadres.Clear();
            tbyayineviadi.Focus();
            //imleci  içine  getir.

            tbadres.ReadOnly = false;
            tbtelno.ReadOnly = false;
            tbyayineviadi.ReadOnly = false;
            yayineviid.ReadOnly = true;
            ekle.Visible = true;
            yenikayitmi = true;
            kacincikayit = ds.Tables["YayinEvleri"].Rows.Count;  //
        }

        private void düzenle_Click(object sender, EventArgs e)
        {
            tbyayineviadi.Focus();    //imleci  içine  getir.
            ekle.Visible = true;
            yenikayitmi = false;
            kacincikayit = bs.Position;    //bs posisonunu sakla.
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (yayineviid.Text != "")
            {
                DialogResult c = MessageBox.Show("Silmek istediğinize emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                    {
                        Convert.ToInt32(drow.Cells[0].Value);  //seçili olan satıra çift tıklandıgında silme işlemi yap
                        kayitlarisil();
                    }
                    yayievleri();
                }
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (c == DialogResult.Yes)
            {
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "delete from YayinEvleri where Yayinevi_id=@Yayinevi_id";
                komut.Parameters.AddWithValue("@Kitap_id", int.Parse(yayineviid.Text));  //veri tabanında int oldugu için çevirdik
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydınız silindi");
                yayievleri();
            }
        }

        private void tbara_TextChanged(object sender, EventArgs e)
        {

            string arakomutu = "select *from YayinEvleri where Yayinevi_ad like '%" + tbara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(arakomutu, baglanti);    //
            ds.Clear();
            da.Fill(ds, "YayinEvleri");
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
