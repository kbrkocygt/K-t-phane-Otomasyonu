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
    public partial class emanetver : Form
    {
        public emanetver()
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
            string sec = "select * from kitapsepeti ";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
            ds.Clear();
            da.Fill(ds, "kitapsepeti");


        }
        void kitapsayisi()
        {
            OleDbCommand komut=new OleDbCommand( "select sum(kitapsayisi) from kitapsepeti ",baglanti);
            lbsepetteki.Text = komut.ExecuteScalar().ToString();
            
            
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand();   //baglantı sayesinde veri tabanına baglanır
            komut.Connection = baglanti;      //baglantı ve komutu ilişkilendir.
            try
            {
                if (tbkitapadi.Text == "" || tbisbnno.Text == "" || tbkitapsayisi.Text == "" || tbstoksayisi.Text == "" || tbkitapsayisi.Text == "" || tbkitapno.Text == "" || bitistarihi.Text == "" || baslangıctarihi.Text == "" || tbrafno.Text == "" || tbyazaradi.Text == "")
                {
                    MessageBox.Show("Lütfen boş alanları doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    komut.CommandText = "insert into  kitapsepeti (kitap_id,kitap_adi,isbn,yazaradisoyadi,rafno,kitapsayisi,kitapverme_tarihi,kitapalma_tarihi,Stok) values (@kitap_id,@kitap_adi,@isbn,@yazaradisoyadi,@rafno,@kitapsayisi,@kitapverme_tarihi,@kitapalma_tarihi,@stok)";
                    //ekleme işlemi yaptık. hangi fildi  kullanıcaksan ona ekle 
                    komut.Parameters.AddWithValue("@kitap_id", int.Parse(tbkitapno.Text));
                    komut.Parameters.AddWithValue("@kitap_adi", tbkitapadi.Text);
                    komut.Parameters.AddWithValue("@isbn", tbisbnno.Text);
                    komut.Parameters.AddWithValue("@yazaradisoyadi", tbyazaradi.Text);
                    komut.Parameters.AddWithValue("@rafno", tbrafno.Text);
                    komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(tbkitapsayisi.Text));
                    komut.Parameters.AddWithValue("@kitapverme_tarihi", baslangıctarihi.Text);
                    komut.Parameters.AddWithValue("@kitapalma_tarihi", bitistarihi.Text);
                    komut.Parameters.AddWithValue("@Stok", int.Parse(tbstoksayisi.Text));


                }
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap Sepete Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                göster();
                lbsepetteki.Text = "";
                kitapsayisi();
            }
            catch (Exception)
            {

                
            }
               
            
          
        }

        private void emanetver_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            göster();
            bs.DataSource = ds.Tables["kitapsepeti"];
            dataGridView1.DataSource = bs;
        }

       

        private void tbisbnno_TextChanged(object sender, EventArgs e)
        {
            OleDbCommand komut=new OleDbCommand( "select * from Kitaplar  where isbn like '%" + tbisbnno.Text + "%'",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tbkitapno.Text = oku["Kitap_id"].ToString();
                tbkitapadi.Text = oku["Kitap_adi"].ToString();
                tbyazaradi.Text = oku["Yazaradisoyadi"].ToString();
                tbrafno.Text = oku["Raf_no"].ToString();
                tbstoksayisi.Text = oku["Stok"].ToString();
               
            }
            OleDbCommand komut2 = new OleDbCommand("select sum(kitapsayisi) from emanetler",baglanti);
            lbkisiokuma.Text = komut2.ExecuteScalar().ToString();

            if (tbisbnno.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item!=tbkitapsayisi)
                        {
                            item.Text = "";
                           // lbsepetteki.Text == "";

                        }


                    }

                }
            }



        }

        private void tbtcno_TextChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("select * from Uyeler  where tcno like '" + tbtcno.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tbuyeno.Text = oku["Uye_id"].ToString();
                tbtelno.Text = oku["Gsm"].ToString();
                tbadi.Text = oku["Ad"].ToString();
                tbsoyadi.Text = oku["Soyad"].ToString();
                tbadres.Text = oku["Adres"].ToString();

            }
            if (tbtcno.Text=="")
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                       lbkisiokuma.Text = "";
                    }
                    
                }
            }
        }

        private void btnSİL_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult c = MessageBox.Show("Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    OleDbCommand komut = new OleDbCommand("delete from kitapsepeti where isbn= '" + dataGridView1.CurrentRow.Cells["isbn"].Value + "'", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kitap Sepetten  silindi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    göster();
                    lbsepetteki.Text = "";
                    kitapsayisi();
                }
            }
            catch (Exception)
            {

               
            }
            
           
        }

        private void btnteslimet_Click(object sender, EventArgs e)
        {
            
                if (lbsepetteki.Text != "")
                {
                    if (lbkisiokuma.Text=="" && int.Parse(lbsepetteki.Text)<= 3 || lbkisiokuma.Text!="" && int.Parse(lbkisiokuma.Text)+int.Parse(lbsepetteki.Text) <= 3)
                    {
                        if (tbtcno.Text != "" && tbadi.Text != "" && tbsoyadi.Text != "" && tbtelno.Text != "" && tbuyeno.Text != "" && tbadres.Text != "")
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                OleDbCommand komut = new OleDbCommand("insert into emanetler (Kitap_id,uye_id,tcno,Ad,Soyad,tel,adres,Kitap_adi,isbn,yazaradisoyadi,rafno,kitapsayisi,kitapverme_tarihi,kitapalma_tarihi,stok ) values (Kitap_id,@uye_id,@tcno,@Ad,@Soyad,@tel,@adres,@Kitap_adi,@isbn,@yazaradisoyadi,@rafno,@kitapsayisi,@kitapverme_tarihi,@kitapalma_tarihi,@stok) ", baglanti);
                                komut.Parameters.AddWithValue("@Kitap_id", int.Parse(dataGridView1.Rows[i].Cells["Kitap_id"].Value.ToString()));
                                komut.Parameters.AddWithValue("@uye_id", int.Parse(tbuyeno.Text));
                                komut.Parameters.AddWithValue("@tcno", tbtcno.Text);
                                komut.Parameters.AddWithValue("@Ad", tbadi.Text);
                                komut.Parameters.AddWithValue("@Soyad", tbsoyadi.Text);
                                komut.Parameters.AddWithValue("@tel", tbtelno.Text);
                                komut.Parameters.AddWithValue("@adres", tbadres.Text);
                                komut.Parameters.AddWithValue("@Kitap_adi", dataGridView1.Rows[i].Cells["Kitap_adi"].Value.ToString());
                                komut.Parameters.AddWithValue("@isbn", dataGridView1.Rows[i].Cells["isbn"].Value.ToString());
                                komut.Parameters.AddWithValue("@yazaradisoyadi", dataGridView1.Rows[i].Cells["yazaradisoyadi"].Value.ToString());
                                komut.Parameters.AddWithValue("@rafno", dataGridView1.Rows[i].Cells["rafno"].Value.ToString());
                                komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                                komut.Parameters.AddWithValue("@kitapverme_tarihi", dataGridView1.Rows[i].Cells["kitapverme_tarihi"].Value.ToString());
                                komut.Parameters.AddWithValue("@kitapalma_tarihi", dataGridView1.Rows[i].Cells["kitapalma_tarihi"].Value.ToString());
                                komut.Parameters.AddWithValue("@stok", int.Parse(dataGridView1.Rows[i].Cells["stok"].Value.ToString()));
                            komut.ExecuteNonQuery();
                            OleDbCommand komut2 = new OleDbCommand("update Uyeler set okudugukitapsayisi=okudugukitapsayisi+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where tcn='" + tbtcno.Text + "'", baglanti);
                            komut2.ExecuteNonQuery();
                            OleDbCommand komut3 = new OleDbCommand("update Kitaplar set Stok=Stok-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where Stok=@Stok'", baglanti);
                            komut3.Parameters.AddWithValue("Stok", int.Parse(tbstoksayisi.Text));
                            komut3.ExecuteNonQuery();

                        }
                            OleDbCommand komut4 = new OleDbCommand("delete from kitapsepeti ", baglanti);
                            komut4.ExecuteNonQuery();
                            MessageBox.Show("Kitaplar Teslim edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            göster();
                            tbtcno.Text = "";
                            lbsepetteki.Text = "";
                            kitapsayisi();
                            lbkisiokuma.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Önce Üye ismi seçmeniz gerekir ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Emanet Kitap Sayısı 3 den fazla olamaz ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Önce sepete kitap eklenmelidir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
           
          
        }

        private void AnaMenüToolStripMenuItem_Click(object sender, EventArgs e)
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
