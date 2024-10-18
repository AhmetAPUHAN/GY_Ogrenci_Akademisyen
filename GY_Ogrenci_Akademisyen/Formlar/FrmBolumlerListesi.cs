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
    public partial class FrmBolumlerListesi : Form
    {
        public FrmBolumlerListesi()
        {
            InitializeComponent();
        }
        
        OgrenciSinavEntities db=new OgrenciSinavEntities(); 

        private void FrmBolumlerListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TblBolums select new { x.BolumID, x.BolumAd };
            dataGridView1.DataSource = degerler.ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }
    }
}
