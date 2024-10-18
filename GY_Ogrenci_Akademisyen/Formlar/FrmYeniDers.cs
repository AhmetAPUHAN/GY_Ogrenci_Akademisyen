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
    public partial class FrmYeniDers : Form
    {
        public FrmYeniDers()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db=new OgrenciSinavEntities(); 
        private void button1_Click(object sender, EventArgs e)
        {
            TblDersler t=new TblDersler();
            t.DersAd = txtDersAd.Text;
            db.TblDerslers.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni ders kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void FrmYeniDers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
