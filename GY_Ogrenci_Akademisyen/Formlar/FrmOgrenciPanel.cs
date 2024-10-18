using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GY_Ogrenci_Akademisyen.Entity;


namespace GY_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }

        public string numara1;
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        int ogrenciid;
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            txtNumara.Text = numara1;
            txtOgrenciAd.Text = db.TblOgrencis.Where(x => x.OgrNumara == numara1).Select(y => y.OgrAd).FirstOrDefault();
            txtOgrenciSoyad.Text = db.TblOgrencis.Where(x => x.OgrNumara == numara1).Select(y => y.OgrSoyad).FirstOrDefault();
            txtMail.Text = db.TblOgrencis.Where(x => x.OgrNumara == numara1).Select(y => y.OgrMail).FirstOrDefault();
            txtSifre.Text = db.TblOgrencis.Where(x => x.OgrNumara == numara1).Select(y => y.OgrSifre).FirstOrDefault();

            ogrenciid = db.TblOgrencis.Where(x => x.OgrNumara == numara1).Select(y => y.OgrID).FirstOrDefault();
            var sinavnotlari = (from x in db.TblNotlars
                                select new
                                {
                                    x.TblDersler.DersAd,
                                    x.Sinav1,
                                    x.Sinav2,
                                    x.Sinav3,
                                    x.Quiz1,
                                    x.Quiz2,
                                    x.Proje,
                                    x.Ortalama,
                                    x.Ogrenci
                                }).Where(y => y.Ogrenci == ogrenciid).ToList();
            dataGridView1.DataSource = sinavnotlari;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (txtSifreTekrar1.Text == txtYeniSifre2.Text)
            {
                var deger = db.TblOgrencis.Find(ogrenciid);
                deger.OgrSifre = txtSifreTekrar1.Text;
                db.SaveChanges();
                MessageBox.Show("Şifreniz Güncellendi.");
            }
            else { MessageBox.Show("Yeni şifreler aynı değil."); }
                
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
