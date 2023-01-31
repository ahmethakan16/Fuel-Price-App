using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkaryakitProjesi
{
    public partial class Hareketler : Form
    {
        public Hareketler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RVCRK4G\\SQLEXPRESS;Initial Catalog=AkaryakitProjesi;Integrated Security=True");
        private void Hareketler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'akaryakitProjesiDataSet.Tbl_HAREKET' table. You can move, or remove it, as needed.
            this.tbl_HAREKETTableAdapter.Fill(this.akaryakitProjesiDataSet.Tbl_HAREKET);

        }

        private void buttonAlisGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult petrol = new DialogResult();
            petrol=MessageBox.Show("Fiyat Güncellensin Mi?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (petrol == DialogResult.Yes)
            {
                //Kurşunsuz95 Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Update Tbl_BENZIN set ALISFIYAT=@p1 where PETROLTUR='Kurşunsuz95'", baglanti);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(textBoxKursunsuz95Alis.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                //Max Diesel Alış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Update Tbl_BENZIN set ALISFIYAT=@p2 where PETROLTUR='Max Diesel'", baglanti);
                komut2.Parameters.AddWithValue("@p2",decimal.Parse(textBoxMaxDieselAlis.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                //Pro Diesel Alış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update Tbl_BENZIN set ALISFIYAT=@p3 where PETROLTUR='Pro Diesel'", baglanti);
                komut3.Parameters.AddWithValue("@p3", decimal.Parse(textBoxProDieselAlis.Text));
                komut3.ExecuteNonQuery();
                baglanti.Close();
                //Gaz LPG Alış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("Update Tbl_BENZIN set ALISFIYAT=@p4 where PETROLTUR='Gaz LPG'", baglanti);
                komut4.Parameters.AddWithValue("@p4", decimal.Parse(textBoxGazLPGAlis.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Fiyat Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         else
            {
                MessageBox.Show("Fiyat Güncellenmedi", "Bilgi");
            }

        }

        private void buttonSatisGuncelle_Click(object sender, EventArgs e)
        {
            //Petrol Satış Fiyat Güncellemesi
            DialogResult satis = new DialogResult();
            satis=MessageBox.Show("Satış Fiyat Güncellensin Mi?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(satis== DialogResult.Yes)
            {
                //Kurşunsuz 95 Satış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Update Tbl_BENZIN set SATISFIYAT=@p1 where PETROLTUR='Kurşunsuz95'", baglanti);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(textBoxKursunsuzSatis.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                //Max Diesel Satış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Update Tbl_BENZIN set SATISFIYAT=@p2 where PETROLTUR='Max Diesel'", baglanti);
                komut2.Parameters.AddWithValue("@p2", decimal.Parse(textBoxMaxDieselSatis.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                //Pro Diesel Satış Fiyat Güncellemesi 
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update Tbl_BENZIN set SATISFIYAT=@p3 where PETROLTUR='Pro Diesel'", baglanti);
                komut3.Parameters.AddWithValue("@p3", decimal.Parse(textBoxProDieselSatis.Text));
                komut3.ExecuteNonQuery();
                baglanti.Close();
                //Gaz LPG Satış Fiyat Güncellemesi
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("Update Tbl_BENZIN set SATISFIYAT=@p4 where PETROLTUR='Gaz LPG'", baglanti);
                komut4.Parameters.AddWithValue("@p4", decimal.Parse(textBoxLPGSatis.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Fiyat Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fiyat Güncellenmedi", "Bilgi");
            }
        }
    }
}
