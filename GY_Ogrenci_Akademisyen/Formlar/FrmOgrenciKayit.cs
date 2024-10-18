using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GY_Ogrenci_Akademisyen.Entity;


namespace GY_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {  OgrenciSinavEntities db=new OgrenciSinavEntities();  
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GSF8MQK\\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False");
        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("select*from TblBolum",baglanti);   
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == txtSSifreTekrar.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = txtOgrenciAd.Text;
                t.OgrSoyad = txtOgrenciSoyad.Text;
                t.OgrSifre = txtSifre.Text;
                t.OgrSifre = txtSSifreTekrar.Text;
                t.OgrMail = txtMail.Text;
                t.OgrResim = txtResim.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
                db.TblOgrencis.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Şifre aynı değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

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
