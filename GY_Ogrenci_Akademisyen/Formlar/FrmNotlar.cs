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
    public partial class FrmNotlar : Form
    {
        OgrenciSinavEntities db= new OgrenciSinavEntities();
        public FrmNotlar()
        {
            InitializeComponent();
        }

        

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersID";
            cmbDers.DataSource = db.TblDerslers.ToList();
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "DersID";
            comboBox1.DataSource = db.TblDerslers.ToList();


        }
        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TblNotlar t= new TblNotlar();
            t.Sinav1 = byte.Parse(txtSınav1.Text);
            t.Sinav2 = byte.Parse(txtSınav2.Text);
            t.Sinav3 = byte.Parse(txtSınav3.Text);
            t.Proje=byte.Parse(txtProje.Text);
            t.Quiz1=byte.Parse(txtQuiz1.Text);
            t.Quiz2=byte.Parse(txtQuiz2.Text);
            t.Ders=int.Parse(cmbDers.SelectedValue.ToString());
            t.Ogrenci = int.Parse(txtOgrenci.Text);
            db.TblNotlars.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Bilgisi Kaydedildi");
        }

        private void txtOrtalama_TextChanged(object sender, EventArgs e)
        {
            byte s1, s2, s3, p, q1, q2;
            double ort;
            s1 =Convert.ToByte(txtSınav1.Text);
            s2=Convert.ToByte(txtSınav2.Text) ;
            s3=Convert.ToByte(txtSınav3.Text) ;
            p=Convert.ToByte(txtProje.Text) ;
            q1=Convert.ToByte(txtQuiz1.Text) ;
            q2=Convert.ToByte(txtQuiz2.Text) ;
           ort=(s1+s2+s3+p+q1+q2)/6 ;
            txtOrtalama.Text = ort.ToString();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Notlar4();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlars
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı=x.TblOgrenci.OgrAd+" "+x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1, 
                               x.Quiz2 ,
                               x.Proje,
                               x.Ortalama,
                               x.Ders
                               
                           };
            int d=int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.Ders == d).ToList();
            dataGridView1.Columns["Ders"].Visible=false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlars
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ogrenci

                           };
            int i = int.Parse(txtNumara.Text);
            dataGridView1.DataSource = degerler.Where(y => y.Ogrenci == i).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnAra2_Click(object sender, EventArgs e)
        {
            string numara=txtNumara.Text;
            var deger = db.TblOgrencis.Where(x => x.OgrNumara == numara).Select(y=>y.OgrID).FirstOrDefault();
           // txtId.Text = deger.ToString();
            var notlar = from x in db.TblNotlars
                         select new
                         {
                             x.NotID,
                             x.TblDersler.DersAd,
                             Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                             x.Sinav1,
                             x.Sinav2,
                             x.Sinav3,
                             x.Quiz1,
                             x.Quiz2,
                             x.Proje,
                             x.Ortalama,
                             x.Ogrenci

                         };
            dataGridView1.DataSource = notlar.Where(z => z.Ogrenci == deger).ToList(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TblNotlars.Find(id);
            x.Sinav1 = int.Parse(txtSınav1.Text);
            x.Sinav2=int.Parse(txtSınav2.Text);
            x.Sinav3=int.Parse(txtSınav3.Text);
            x.Quiz1 = int.Parse(txtQuiz1.Text);
            x.Quiz2 = int.Parse(txtQuiz2.Text);
            x.Proje=int.Parse(txtProje.Text);
            x.Ortalama=int.Parse(txtOrtalama.Text);
            db.SaveChanges();
            MessageBox.Show("Notlar Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();    
        }
    }
}
