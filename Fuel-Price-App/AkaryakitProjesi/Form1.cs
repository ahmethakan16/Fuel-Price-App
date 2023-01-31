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
using System.Security.Cryptography.X509Certificates;

namespace AkaryakitProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RVCRK4G\\SQLEXPRESS;Initial Catalog=AkaryakitProjesi;Integrated Security=True");
        public void fiyatlistele()
        {
            // Kurşunsuz95 Fiyat
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Kurşunsuz95' ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelKursunsuz.Text = dr[3].ToString();
            }
            baglanti.Close();
            // Max Diesel Fiyat
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Max Diesel' ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                labelMaxDiesel.Text = dr2[3].ToString();
            }
            baglanti.Close();
            // Pro Diesel Fiyat
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Pro Diesel' ", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                labelProDiesel.Text = dr3[3].ToString();
            }
            baglanti.Close();
            // Gaz LPG Fiyat
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Gaz LPG' ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                labelLpg.Text = dr4[3].ToString();
            }
            baglanti.Close();
            //Kurşunsuz Progress Bar Değeri
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Kurşunsuz95' ", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                labelKursunsuzProgress.Text = dr5[4].ToString();
                progressBar1.Value = int.Parse(dr5[4].ToString());
            }
            baglanti.Close();
            //Max Diesel Progress Bar Değeri
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Max Diesel' ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                labelMaxDieselProgress.Text = dr6[4].ToString();
                progressBar2.Value = int.Parse(dr6[4].ToString());
            }
            baglanti.Close();
            //Pro Diesel Progress Bar Değeri
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Pro Diesel' ", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                labelProDieselProgress.Text = dr7[4].ToString();
                progressBar4.Value = int.Parse(dr7[4].ToString());
            }
            baglanti.Close();
            // Lpg Progress Bar Değeri
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("Select * from Tbl_BENZIN where PETROLTUR='Gaz LPG' ", baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                labelLPGprogress.Text = dr8[4].ToString();
                progressBar3.Value = int.Parse(dr8[4].ToString());
            }
            baglanti.Close();
            //Kasa Fiyat Artışı
            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("Select * From Tbl_KASA", baglanti);
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                labelKasaTL.Text = dr9[0].ToString();
            }
            baglanti.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fiyatlistele();
            alisfiyat();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(labelKursunsuz.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            textBoxTutarKursunsuz.Text = tutar.ToString();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double maxdiesel, litre, tutar;
            maxdiesel = Convert.ToDouble(labelMaxDiesel.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = maxdiesel * litre;
            textBoxTutarMaxDiesel.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double prodiesel, litre, tutar;
            prodiesel = Convert.ToDouble(labelProDiesel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = prodiesel * litre;
            textBoxTutarProDiesel.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double lpg, litre, tutar;
            lpg = Convert.ToDouble(labelLpg.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = lpg * litre;
            textBoxTutarLPG.Text = tutar.ToString();
        }

        private void buttonDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                //Hareket Tablosu Değer Girişi
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Insert into Tbl_HAREKET(PLAKA,BENZINTURU,LITRE,FIYAT) values(@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBoxPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textBoxTutarKursunsuz.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                //Kasa Fiyat Artışı
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(textBoxTutarKursunsuz.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                // Progress Bar Değeri Düşürme;
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update Tbl_BENZIN set STOK=STOK-@p1 where PETROLTUR='Kurşunsuz95'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Benzin Alımı Başarı İle Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fiyatlistele();
            }
            if (numericUpDown2.Value != 0)
            {
                //Hareket Tablosu Değer Girişi
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("Insert Into Tbl_HAREKET(PLAKA,BENZINTURU,LITRE,FIYAT) values(@p1,@p2,@p3,@p4)", baglanti);
                komut4.Parameters.AddWithValue("@p1", textBoxPlaka.Text);
                komut4.Parameters.AddWithValue("@p2", "Max Diesel");
                komut4.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut4.Parameters.AddWithValue("@p4", decimal.Parse(textBoxTutarMaxDiesel.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();
                //Kasa Fiyat Artışı
                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR+@p1", baglanti);
                komut5.Parameters.AddWithValue("@p1", decimal.Parse(textBoxTutarMaxDiesel.Text));
                komut5.ExecuteNonQuery();
                baglanti.Close();
                //ProgressBar Değeri Düşürme
                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("Update Tbl_BENZIN set STOK=STOK-@p1 where PETROLTUR='Max Diesel'", baglanti);
                komut6.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut6.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Benzin Alımı Başarı İle Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fiyatlistele();

            }
            if (numericUpDown3.Value != 0)
            {
                //Hareket Tablosu Değer Girişi
                baglanti.Open();
                SqlCommand komut7 = new SqlCommand("Insert into Tbl_HAREKET(PLAKA,BENZINTURU,LITRE,FIYAT) values(@p1,@p2,@p3,@p4)", baglanti);
                komut7.Parameters.AddWithValue("@p1", textBoxPlaka.Text);
                komut7.Parameters.AddWithValue("@p2", "Pro Diesel");
                komut7.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut7.Parameters.AddWithValue("@p4", decimal.Parse(textBoxTutarProDiesel.Text));
                komut7.ExecuteNonQuery();
                baglanti.Close();
                //Kasa Fiyat Artışı
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR+@p1", baglanti);
                komut8.Parameters.AddWithValue("@p1", decimal.Parse(textBoxTutarProDiesel.Text));
                komut8.ExecuteNonQuery();
                baglanti.Close();
                // Progress Bar Değeri Düşürme;
                baglanti.Open();
                SqlCommand komut9 = new SqlCommand("Update Tbl_BENZIN set STOK=STOK-@p1 where PETROLTUR='Pro Diesel'", baglanti);
                komut9.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut9.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Benzin Alımı Başarı İle Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fiyatlistele();
            }
            if (numericUpDown4.Value != 0)
            {
                //Hareket Tablosu Değer Girişi
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("Insert Into Tbl_HAREKET(PLAKA,BENZINTURU,LITRE,FIYAT) values(@p1,@p2,@p3,@p4)", baglanti);
                komut10.Parameters.AddWithValue("@p1", textBoxPlaka.Text);
                komut10.Parameters.AddWithValue("@p2", "Gaz LPG");
                komut10.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut10.Parameters.AddWithValue("@p4", decimal.Parse(textBoxTutarLPG.Text));
                komut10.ExecuteNonQuery();
                baglanti.Close();
                //Kasa Fiyat Artışı
                baglanti.Open();
                SqlCommand komut11 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR+@p1", baglanti);
                komut11.Parameters.AddWithValue("@p1", decimal.Parse(textBoxTutarLPG.Text));
                komut11.ExecuteNonQuery();
                baglanti.Close();
                //ProgressBar Değeri Düşürme
                baglanti.Open();
                SqlCommand komut12 = new SqlCommand("Update Tbl_BENZIN set STOK=STOK-@p1 where PETROLTUR='Gaz LPG'", baglanti);
                komut12.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut12.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Benzin Alımı Başarı İle Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fiyatlistele();

            }

        }
        public void alisfiyat()
        {
                //Kurşunsuz95 Alış
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From Tbl_BENZIN where PETROLTUR='Kurşunsuz95'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    labelKursunsuzAlis.Text = dr[2].ToString();
                }
                baglanti.Close();
                //Max Diesel Alış
                 baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Select * From Tbl_BENZIN where PETROLTUR='Max Diesel'", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    labelMaxDieselAlis.Text = dr2[2].ToString();
                }
                baglanti.Close();
                // Pro Diesel Alış
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Select * From Tbl_BENZIN where PETROLTUR='Pro Diesel'", baglanti);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    labelProDieselAlis.Text = dr3[2].ToString();
                }
                baglanti.Close();
                // Gaz LPG Alış
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("Select * From Tbl_BENZIN where PETROLTUR='Gaz LPG'", baglanti);
                SqlDataReader dr4 = komut4.ExecuteReader();
                while (dr4.Read())
                {
                    labelGazLpgAlis.Text = dr4[2].ToString();
                }
                baglanti.Close();
            }
        //Alış Fiyatını Tutara Girme:
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(labelKursunsuzAlis.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = kursunsuz95 * litre;
            textBoxKursunsuz95Alis.Text = tutar.ToString();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double maxdiesel, litre, tutar;
            maxdiesel = Convert.ToDouble(labelMaxDieselAlis.Text);
            litre = Convert.ToDouble(numericUpDown6.Value);
            tutar = maxdiesel * litre;
            textBoxMaxDieselAlis.Text = tutar.ToString();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            double prodiesel, litre, tutar;
            prodiesel = Convert.ToDouble(labelProDieselAlis.Text);
            litre= Convert.ToDouble(numericUpDown7.Value);
            tutar= prodiesel * litre;
            textBoxProDieselAlis.Text= tutar.ToString();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            double lpg, litre, tutar;
            lpg= Convert.ToDouble(labelGazLpgAlis.Text);
            litre= Convert.ToDouble(numericUpDown8.Value);
            tutar= lpg * litre;
            textBoxGazLPGAlis.Text= tutar.ToString();
        }

        private void buttonStokDoldur_Click(object sender, EventArgs e)
        {
            //Hareket Tablosuna Depoya Benzin Alımının İşlenmesi
            if (numericUpDown5.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Insert Into Tbl_HAREKET(BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3)", baglanti);
                komut.Parameters.AddWithValue("@p1", "Kurşunsuz95");
                komut.Parameters.AddWithValue("@p2", numericUpDown5.Value);
                komut.Parameters.AddWithValue("@p3", textBoxKursunsuz95Alis.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                //KASA Fiyat Azalışı;
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR-@p1", baglanti);
                komut3.Parameters.AddWithValue("@p1", decimal.Parse(textBoxKursunsuz95Alis.Text));
                komut3.ExecuteNonQuery();
                baglanti.Close();

                //Progress Bar Değeri Artışı
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update Tbl_BENZIN set STOK=STOK+@p1 where PETROLTUR='Kurşunsuz95'", baglanti);
                komut2.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                fiyatlistele();
            }

                //Max Diesel Depoya Benzin Alım İşlemi

                if(numericUpDown6.Value !=0)
                {
                    baglanti.Open();
                    SqlCommand komut4 = new SqlCommand("Insert Into Tbl_HAREKET(BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3)", baglanti);
                    komut4.Parameters.AddWithValue("@p1", "Max Diesel");
                    komut4.Parameters.AddWithValue("@p2", numericUpDown6.Value);
                    komut4.Parameters.AddWithValue("@p3", textBoxMaxDieselAlis.Text);
                    komut4.ExecuteNonQuery();
                    baglanti.Close();
                    //KASA Fiyat Azalışı;
                    baglanti.Open();
                    SqlCommand komut5 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR-@p1", baglanti);
                    komut5.Parameters.AddWithValue("@p1", decimal.Parse(textBoxMaxDieselAlis.Text));
                    komut5.ExecuteNonQuery();
                    baglanti.Close();

                    //Progress Bar Değeri Artışı
                    baglanti.Open();
                    SqlCommand komut6 = new SqlCommand("update Tbl_BENZIN set STOK=STOK+@p1 where PETROLTUR='Max Diesel'", baglanti);
                    komut6.Parameters.AddWithValue("@p1", numericUpDown6.Value);
                    komut6.ExecuteNonQuery();
                    baglanti.Close();
                fiyatlistele();
            }
                //PRO DİESEL DEPOYA ALIM İŞLEMİ
                if(numericUpDown7.Value !=0)
            {
                baglanti.Open();
                SqlCommand komut7 = new SqlCommand("Insert Into Tbl_HAREKET(BENZINTURU,LITRE,FIYAT) Values (@p1,@p2,@p3)", baglanti);
                komut7.Parameters.AddWithValue("@p1", "Pro Diesel");
                komut7.Parameters.AddWithValue("@p2", numericUpDown7.Value);
                komut7.Parameters.AddWithValue("@p3", textBoxProDieselAlis.Text);
                komut7.ExecuteNonQuery();
                baglanti.Close();

                // Kasa Fiyat Azalışı
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR-@p1", baglanti);
                komut8.Parameters.AddWithValue("@p1", decimal.Parse(textBoxProDieselAlis.Text));
                komut8.ExecuteNonQuery();
                baglanti.Close();

                // Progress Bar Değer Artışı
                baglanti.Open();
                SqlCommand komut9 = new SqlCommand("Update Tbl_BENZIN Set STOK=STOK+@p1 where PETROLTUR='Pro Diesel'", baglanti);
                komut9.Parameters.AddWithValue("@p1", numericUpDown7.Value);
                komut9.ExecuteNonQuery();
                baglanti.Close();
                fiyatlistele();
            }

                if(numericUpDown8.Value !=0)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("Insert Into Tbl_HAREKET(BENZINTURU,LITRE,FIYAT) Values (@p1,@p2,@p3)", baglanti);
                komut10.Parameters.AddWithValue("@p1", "Pro Diesel");
                komut10.Parameters.AddWithValue("@p2", numericUpDown8.Value);
                komut10.Parameters.AddWithValue("@p3", textBoxGazLPGAlis.Text);
                komut10.ExecuteNonQuery();
                baglanti.Close();

                // Kasa Fiyat Azalışı
                baglanti.Open();
                SqlCommand komut11 = new SqlCommand("Update TBL_KASA set MIKTAR=MIKTAR-@p1", baglanti);
                komut11.Parameters.AddWithValue("@p1", decimal.Parse(textBoxGazLPGAlis.Text));
                komut11.ExecuteNonQuery();
                baglanti.Close();

                // Progress Bar Değer Artışı
                baglanti.Open();
                SqlCommand komut12 = new SqlCommand("Update Tbl_BENZIN Set STOK=STOK+@p1 where PETROLTUR='Gaz LPG'", baglanti);
                komut12.Parameters.AddWithValue("@p1", numericUpDown8.Value);
                komut12.ExecuteNonQuery();
                baglanti.Close();
                fiyatlistele();
             }
                
            }

        private void buttonPetrolHakkında_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr.wikipedia.org/wiki/Petrol");
        }

        private void buttonHareketler_Click(object sender, EventArgs e)
        {
            Hareketler frm = new Hareketler();
            frm.Show();
            this.Hide();
        }
    }
    }
    



