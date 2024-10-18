using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GY_Ogrenci_Akademisyen.Entity;


namespace GY_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        OgrenciSinavEntities db = new OgrenciSinavEntities();
        void listele()
        {
            var degerler = from x in db.TblOgrencis
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrMail,
                               x.OgrResim,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrDurum
                            };
            dataGridView1.DataSource = degerler.Where( x=> x.OgrDurum==true).ToList();


        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GSF8MQK\\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible=false;    
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from TblBolum", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        
        
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var x =db.TblOgrencis.Find(id);
            x.OgrDurum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrenci silindi.Durumu false oldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TblOgrencis.Find(id);
            x.OgrAd = txtOgrenciAd.Text;
            x.OgrSoyad= txtOgrenciSoyad.Text;
            x.OgrNumara = txtNumara.Text;
            x.OgrMail = txtMail.Text;
            x.OgrResim = txtResim.Text;
            x.OgrSifre = txtSifre.Text;
            x.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            


        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
