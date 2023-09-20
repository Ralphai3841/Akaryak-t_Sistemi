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

namespace Akaryakıt_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=LAPTOP-FB9086OP;Initial Catalog=DbNotKayıt;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-FB9086OP;Initial Catalog=AKARYAKIT;Integrated Security=True");

        void listele()
        {
            //Kurşunsuz 95
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Kurşunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                LblKursunsuz95litre.Text = dr[4].ToString();
            }
            baglanti.Close();

            //Kurşunsuz 97
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Kurşunsuz97'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKursunsuz97.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                LblKursunsuz97litre.Text = dr2[4].ToString();
            }
            baglanti.Close();

            //EuroDizel10
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='EuroDizel10'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblEuroDizel10.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                LblEuroDizel10litre.Text = dr3[4].ToString();
            }
            baglanti.Close();

            //YeniProDizel 97
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='YeniProDizel'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblYeniProDizel.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                LblYeniProDizellitre.Text = dr4[4].ToString();
            }
            baglanti.Close();

            //Gaz 
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Gaz'", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblGaz.Text = dr5[3].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString());
                LblGazlitre.Text = dr5[4].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from TBLKASA", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblKasa.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuz95Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDizel10.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * litre;
            TxtEuroDizel10Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniprodizel, litre, tutar;
            yeniprodizel = Convert.ToDouble(LblYeniProDizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniprodizel * litre;
            TxtYeniProDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGazFiyat.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtPlaka.Text);
            komut.Parameters.AddWithValue("@P2", "Kurşunsuz 95");
            komut.Parameters.AddWithValue("@P3", numericUpDown1.Value);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(TxtKursunsuz95Fiyat.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", baglanti);
            komut1.Parameters.AddWithValue("@P1", TxtPlaka.Text);
            komut1.Parameters.AddWithValue("@P2", "Kurşunsuz 97");
            komut1.Parameters.AddWithValue("@P3", numericUpDown2.Value);
            komut1.Parameters.AddWithValue("@P4", decimal.Parse(TxtKursunsuz97Fiyat.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", baglanti);
            komut2.Parameters.AddWithValue("@P1", decimal.Parse(TxtKursunsuz97Fiyat.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", baglanti);
            komut4.Parameters.AddWithValue("@P1", decimal.Parse(TxtKursunsuz97Fiyat.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='kurşunsuz95'", baglanti);
            komut3.Parameters.AddWithValue("@P1", numericUpDown1.Value);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış Yapıldı");
            listele();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='kurşunsuz95'", baglanti);
            komut5.Parameters.AddWithValue("@P1", numericUpDown2.Value);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış Yapıldı");
            listele();
        }
    }
}
