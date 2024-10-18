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
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmHarita_Load(object sender, EventArgs e)
        {

        }

        private void pnlBölümListesi_Click(object sender, EventArgs e)
        {
            FrmBolumlerListesi fr = new FrmBolumlerListesi();
            fr.Show();
        }



        private void pnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void pnlNotlar_Click(object sender, EventArgs e)
        {
            FrmNotlar fr = new FrmNotlar();
            fr.Show();
        }

        private void pnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi fr = new FrmDersListesi();
            fr.Show();

        }

        private void pnlCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers fr = new FrmYeniDers(); 
            fr.Show();
        }
    }
}
