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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=KOMET34DC;Initial Catalog=PersonelVeriTabani;Persist Security Info=True;User ID=sa;Password=Sentez452*");

        private void FrmGrafik_Load(object sender, EventArgs e)
        {

            // ŞEHİRLER GRAFİK TABLOSU KODLARI

            baglanti.Open();

            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {

                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }

            baglanti.Close();

            //MAAŞLAR GRAFİK TABLOSU KODLARI

            baglanti.Open();

            SqlCommand komutg2 = new SqlCommand("Select PerMaas,Count(*) From Tbl_Personel Group By PerMaas", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())

            {

                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0],dr2[1]);
            }

            baglanti.Close();
        }
    }
}
