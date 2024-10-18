using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GY_Ogrenci_Akademisyen.Entity;

namespace GY_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        OgrenciSinavEntities db = new OgrenciSinavEntities();
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBolumAdi.Text == "")
            {
                errorProvider1.SetError(txtBolumAdi, "Bölüm adı boş geçilemez.");
            }
            else 
            {TblBolum t=new TblBolum();
                t.BolumAd=txtBolumAdi.Text;
                db.TblBolums.Add(t);
                db.SaveChanges();

                MessageBox.Show("Bölüm eklme yapıldı.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information ); 
            }
        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
