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
    public partial class personelekle : Form
    {
        public personelekle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void göster()
        {
            string sec = "select * from calisanlar ";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
            ds.Clear();
            da.Fill(ds, "calisanlar");
            bs.DataSource = ds.Tables["calisanlar"];
            dataGridView1.DataSource = bs;
        }
        private void btnpersonelekle_Click(object sender, EventArgs e)
        {
            if (tbadi.Text == "" || tbsoyadi.Text == "" || dtdogumtarihi.Text == "" ||  cbegitimdurumu.Text == "" || dtbaslangic.Text=="" ||  tbkullaniciadi.Text=="" || tbsifre.Text=="")
            {
                MessageBox.Show("Lütfen girilecek alanları boş bırakmayınız","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                string eklekomutu = "insert into calisanlar (adi,soyadi,dogumtarihi,egitimdurumu,baslangıctarihi,kullaniciadi,sifre) values (@adi,@soyadi,@dogumtarihi,@egitimdurumu,@baslangıctarihi,@kullaniciadi,@sifre)";
                OleDbCommand komut = new OleDbCommand(eklekomutu, baglanti);
                komut.Parameters.AddWithValue("@adi", tbadi.Text);
                komut.Parameters.AddWithValue("@soyadi", tbsoyadi.Text);
                komut.Parameters.AddWithValue("@dogumtarihi", dtdogumtarihi.Text);
                komut.Parameters.AddWithValue("@egitimdurumu", cbegitimdurumu.Text);
                komut.Parameters.AddWithValue("@baslangıctarihi", dtbaslangic.Text);
                komut.Parameters.AddWithValue("@kullaniciadi", tbkullaniciadi.Text);
                komut.Parameters.AddWithValue("@sifre", tbsifre.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Personel Eklendi ","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                göster();
            }

            
        }

        private void personelekle_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            ds.Clear();
            göster();
        }

        private void btnpersonelsil_Click(object sender, EventArgs e)
        {
            if (personelara.Text == "")
            {
                MessageBox.Show("Siliceğiniz kişinin ismini  arayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult c = MessageBox.Show("Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    OleDbCommand komut = new OleDbCommand("delete from calisanlar where id=@id  ", baglanti);
                    komut.Parameters.AddWithValue("@id", int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel silindi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // ds.Tables["calisanlar"].Clear();
                    göster();



                }



            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbadi.Text = dataGridView1.CurrentRow.Cells["adi"].Value.ToString();
            tbsoyadi.Text = dataGridView1.CurrentRow.Cells["soyadi"].Value.ToString();
            dtdogumtarihi.Text = dataGridView1.CurrentRow.Cells["dogumtarihi"].Value.ToString();
            cbegitimdurumu.Text = dataGridView1.CurrentRow.Cells["egitimdurumu"].Value.ToString();
            dtbaslangic.Text = dataGridView1.CurrentRow.Cells["baslangıctarihi"].Value.ToString();
            tbkullaniciadi.Text = dataGridView1.CurrentRow.Cells["kullaniciadi"].Value.ToString();
            tbsifre.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
        }

        private void personelara_TextChanged(object sender, EventArgs e)
        {
            string arakomutu = "select *from calisanlar where adi like '%" + personelara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(arakomutu, baglanti);    //
            ds.Clear();
            da.Fill(ds, "calisanlar");
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
