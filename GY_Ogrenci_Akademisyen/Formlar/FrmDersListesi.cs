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
    public partial class FrmDersListesi : Form
    {  OgrenciSinavEntities db=new OgrenciSinavEntities(); 
        public FrmDersListesi()
        {
            InitializeComponent();
        }
            
        private void FrmDersListesi_Load(object sender, EventArgs e)
        {
             var derslistesi = from x in db.TblDerslers
                              select new
                              {
                                  x.DersID,
                                  x.DersAd
                              };
            dataGridView1.DataSource = derslistesi.ToList(); ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
