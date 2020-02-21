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
    public partial class emanetteslimal : Form
    {
        public emanetteslimal()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kutuphane_otomasyonu.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void emanetler()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from emanetler", baglanti);
            ds.Clear();
            da.Fill(ds, "emanetler");
            bs.DataSource = ds.Tables["emanetler"];
            dataGridView1.DataSource = bs;
        }
        private void tbtcara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from emanetler  where tcno like '%" + tbtcara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
           
            da.Fill(ds, "emanetler");
            if (tbtcara.Text=="")
            {
                ds.Tables["emanetler"].Clear();
                emanetler();
            }
        }

        private void emanetteslimal_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            emanetler();
        }

        private void tbisbnara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from emanetler  where isbn like '%" + tbisbnara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            da.Fill(ds, "emanetler");
            if (tbisbnara.Text == "") 
            {
                ds.Tables["emanetler"].Clear();
                emanetler();
            }
        }

        private void btnteslimal_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("delete from emanetler where tcno=@tcno and isbn=@isbn", baglanti);
                komut.Parameters.AddWithValue("@tcno", dataGridView1.CurrentRow.Cells["tcno"].Value.ToString());
                komut.Parameters.AddWithValue("@isbn", dataGridView1.CurrentRow.Cells["isbn"].Value.ToString());
                komut.ExecuteNonQuery();
                OleDbCommand komut2 = new OleDbCommand("update from Kitaplar set Stok=Stok+ '" + dataGridView1.CurrentRow.Cells["kitapsayisi"].Value.ToString() + "' where  isbn=@isbn", baglanti);
                komut2.Parameters.AddWithValue("@isbn", dataGridView1.CurrentRow.Cells["isbn"].Value.ToString());
                komut2.ExecuteNonQuery();
                MessageBox.Show("Kitap Teslim Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emanetler();
            }
            catch (Exception)
            {

               
            }
           
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
