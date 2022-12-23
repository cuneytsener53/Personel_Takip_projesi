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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=KOMET34DC;Initial Catalog=PersonelVeriTabani;Persist Security Info=True;User ID=sa;Password=Sentez452*");

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())

            {

                FrmAnaForm frm = new FrmAnaForm();
                frm.ShowDialog();
                this.Hide();
            }

            else

            {

                MessageBox.Show("Hatalı Kullanıcı Adı Ve Şifre Girdiniz Lütfen Tekrar Deneyiniz ! ! !");
            }

            baglanti.Close();
        }
    }
}
