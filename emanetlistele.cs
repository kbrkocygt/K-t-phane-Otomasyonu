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
    public partial class emanetlistele : Form
    {
        public emanetlistele()
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

        private void emanetlistele_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            emanetler();
            cbsec.SelectedIndex = 0;
        }

        private void cbsec_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbsec.SelectedIndex == 0)
            {
                emanetler();
            }
            else if (cbsec.SelectedIndex == 1)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * from emanetler where '" + DateTime.Now.ToShortDateString() + "'> kitapalma_tarihi", baglanti);
                da.Fill(ds, "emanetler");
                bs.DataSource = ds.Tables["emanetler"];
                dataGridView1.DataSource = bs;
            }
            else if (cbsec.SelectedIndex == 2)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * from emanetler where '" + DateTime.Now.ToShortDateString() + "'<= kitapalma_tarihi", baglanti);
                da.Fill(ds, "emanetler");
                bs.DataSource = ds.Tables["emanetler"];
                dataGridView1.DataSource = bs;
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
