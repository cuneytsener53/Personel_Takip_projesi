﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PersonelKayitProjesi
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=KOMET34DC;Initial Catalog=PersonelVeriTabani;Persist Security Info=True;User ID=sa;Password=Sentez452*");

        void temizle ()
        {
            Txtİd.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMeslek.Text = "";
            MskdMaas.Text = "";
            CmbSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtAd.Focus();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskdMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) 
            {
                label8.Text = "true";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "true";
            }
        }


        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskdMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True") 
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False") 
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtİd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silinmiştir");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", MskdMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", Txtİd.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi Başarılı bir şekilde gerçekleşmiştir");
        }

        private void Btnistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr = new Frmİstatistik();
            fr.Show();
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafik fr = new FrmGrafik();
            fr.Show();
        }
    }
}