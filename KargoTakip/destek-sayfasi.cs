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
    public partial class destek_sayfasi : Form
    {
        #region MySql Baglantısı yazdım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        musterii mstr = new musterii();
        #endregion
        public destek_sayfasi()
        {
            InitializeComponent();
        }
        #region Geri dön butonu tıklandığında
        private void button1_Click(object sender, EventArgs e)
        { 
            this.Close();
            mstr.Show();
        }
        #endregion

        #region buton2 tıklandığı zaman mesaj göndere işlemi tanımladım
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO destek_mesaj (konu,mesaj) " +
             "VALUES (@kno,@msj)";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kno", txtdstknu.Text);
            cmd.Parameters.AddWithValue("@msj", txtdstkms.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Mesaj gönderildi.");
            mstr.Show();
            this.Close();
        }
        #endregion
    }
}
