using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KargoTakip
{
    public partial class kayit : Form
    {
        #region MySql Baglantısı yazdım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        Form1 form1 = new Form1();
        #endregion
        public kayit()
        {
            InitializeComponent();
        }
        #region Void ile kaydetme sorgusu yazdım
        public void kaydet()
        {
            string sql = "INSERT INTO uyeler (uyeAdi,uyeSoyadi,mail,tcno,dogum_yili,uyeSifre,rol) " +
                "VALUES (@ad,@soyad,@mail,@tc,@dyil,@usifre,@rol)";
            cmd = new MySqlCommand(sql,conn);
            cmd.Parameters.AddWithValue("@ad", txtad.Text);
            cmd.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@mail", txtmail.Text);
            cmd.Parameters.AddWithValue("@tc", txttcno.Text);
            cmd.Parameters.AddWithValue("@dyil", txtdyili.Text);
            cmd.Parameters.AddWithValue("@usifre", txtsifre.Text);
            cmd.Parameters.AddWithValue("@rol", txtu.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt eklendi.");
            form1.Show();
            this.Close();            
        }
        #endregion

        #region Kayıt ol sorgusu yaptım ve void(kaydet)'i çalıştırdım
        private void button1_Click_1(object sender, EventArgs e)
        {

                if (txtmail.Text.Contains("@") && txtmail.Text.Contains(".com"))
                {

                    if (txtmail.Text == txtmailtr.Text && txtsifre.Text == txtsifretr.Text)
                    {
                        kaydet();
                    }
                    else
                    {
                        MessageBox.Show("lütfen şifrelerinizi ve mail tekrarı alanlarını birbiriyle eşit yapınız!");
                    }
                }
                else
                {
                    MessageBox.Show("lütfen mail adresini doğru giriniz!");
                }
        
        }
        #endregion

        #region Giriş sayfasına yönlendirdim
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }
        #endregion
    }
}
