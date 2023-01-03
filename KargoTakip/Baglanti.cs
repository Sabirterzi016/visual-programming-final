using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;
using System.Data;
using System.Xml;

namespace KargoTakip
{

    internal class Baglanti
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;

        public void uyeguncelle(string ad, string sad, string tc, string dy, string sfre)
        {
            con.Open();
            MySqlCommand gun = new MySqlCommand("update uyeler set uyeAdi='" + ad + "',uyeSoyadi='" + sad + "',tcno='" + tc + "',dogum_yili='" + dy + "',uyeSifre='" + sfre + "' where mail = '" + Settings1.Default.kadi + "'", con);
            gun.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            con.Close();
        }
        public void uyegetir(string ad, string sad, string tc, string dy, string sfre)
        {   /*
            con.Open();
           // MySqlCommand gun = new MySqlCommand("SELECT uyeAdi,uyeSoyadi,mail,dogum_yili,uyeSifre FROM gonderi_takip where mail = '" + Settings1.Default.kadi + "'", con);
            MySqlCommand uye = new MySqlCommand("SELECT uyeAdi='" + ad + "',uyeSoyadi='" + sad + "',tcno='" + tc + "',dogum_yili='" + dy + "',uyeSifre='" + sfre + "' ,where mail = '"+" ',from uyeler where mail = '" + Settings1.Default.kadi + "'", con);
            DataTable dt = new DataTable();
            uye.ExecuteNonQuery();
            con.Close();*/
        }
        public void uyeg_uncelle(string ad, string sad, string mail, string tc, string dy, string sfre, string rol)
        {
            con.Open();
            MySqlCommand gun = new MySqlCommand("update uyeler set uyeAdi='" + ad + "',uyeSoyadi='" + sad + "',mail='" + mail + "',tcno='" + tc + "',dogum_yili='" + dy + "',uyeSifre='" + sfre + "',rol='" + rol + "' where mail = '" + Settings1.Default.kadi + "'", con);
            gun.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            con.Close();
        }
        public void msj_uncelle(string msj)
        {
            con.Open();
            MySqlCommand gun = new MySqlCommand("update destek_mesaj set mesaj='" + msj + "' where mail = '" + Settings1.Default.kadi + "'", con);
            gun.ExecuteNonQuery();
            MessageBox.Show("Mesaj Başarıyla Yanıtlandı.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            con.Close();
        }

    }
}
