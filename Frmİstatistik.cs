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

namespace PersonelKayitProjesi
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=KOMET34DC;Initial Catalog=PersonelVeriTabani;Persist Security Info=True;User ID=sa;Password=Sentez452*");

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI İSTATİSTİĞİ
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //EVLİ PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {

                LblEvliPeronelSayisi.Text = dr2[0].ToString();
            }


                baglanti.Close();

            //BEKAR PERSONEL SAYİSİ

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                BekarPersonelSayisi.Text = dr3[0].ToString();
            }

            baglanti.Close();


            //ŞEHİR SAYISI 
            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("select count (distinct(PerSehir))  From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                SehirSayisi.Text = dr4[0].ToString();
            }

            baglanti.Close();

            //TOPLAM MAAŞ SAYISI

            baglanti.Open();

            SqlCommand komut5 = new SqlCommand("select Sum (distinct(PerMaas))  From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                ToplamMaas.Text = dr5[0].ToString();
            }

            baglanti.Close();


            //Ortalama Maas

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select Avg (distinct(PerMaas))  From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                OrtalamMaas.Text = dr6[0].ToString();
            }

            baglanti.Close();

        }
    }
}
