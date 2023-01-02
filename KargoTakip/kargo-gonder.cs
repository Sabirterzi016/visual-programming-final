using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace KargoTakip
{
    public partial class kargo_gonder : Form
    {
        #region MySql Baglantısı yazdım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        musterii mstr = new musterii();
        #endregion
        public kargo_gonder()
        {
            InitializeComponent();
        }
        #region Geri dön butonu tıklandığında
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mstr.Show();
        }
        #endregion

        #region textboxlar doğruysa veritabanna aktarıcak
        public void gonder()
        {
            string sql = "INSERT INTO gonderi_takip (aliciAdi,aliciSoyadi,takip_no,durum,teslim_tipi,teslim_tarih,gonderilen_tarih,odeme_tipi,gonderen_mail,alici_adres) " +
            "VALUES (@ad,@soyad,@tkno,@drm,@teslimt,@tth,@gnth,@otp,@gml,@aadr)";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ad", txtname.Text);
            cmd.Parameters.AddWithValue("@soyad", txtsname.Text);
            cmd.Parameters.AddWithValue("@tkno", textBox1.Text);
            cmd.Parameters.AddWithValue("@drm", textBox2.Text);
            cmd.Parameters.AddWithValue("@teslimt", cmbt.Text);
            cmd.Parameters.AddWithValue("@tth", textBox3.Text);
            cmd.Parameters.AddWithValue("@gnth", textBox4.Text);
            cmd.Parameters.AddWithValue("@otp", cmbo2.Text);
            cmd.Parameters.AddWithValue("@gml", txtgpst.Text);
            cmd.Parameters.AddWithValue("@aadr", aadrs.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kargo gönderildi.");
            mstr.Show();
            this.Close();
        }
        #endregion

        #region buton1 tıklandığı zaman textbox içlerini kontrol edicek
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtgpst.Text.Contains("@") && txtgpst.Text.Contains(".com"))
                {
                    gonder();
                }
                else
                {
                    MessageBox.Show("lütfen mail adresini doğru giriniz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show ("Lütfen bilgilerinizi eksiksiz ve doğru giriniz!");
            }
        }
        #endregion


    }
}
