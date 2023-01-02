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
using MySql.Data;



namespace KargoTakip
{
    public partial class bilgilerim : Form
    {
        Form1 form1 = new Form1();

        Baglanti baglan = new Baglanti();


        public bilgilerim()
        {
            InitializeComponent();
        }
        #region Sayfa yüklendiğinde yapılacak işlemler
        private void bilgilerim_Load(object sender, EventArgs e)
        {
            baglan.uyegetir(txtname.Text, txtsname.Text, txttc.Text, txtdy.Text, txtsfre.Text);
        }
        #endregion

        #region Güncelle Butonu
        private void Güncelle_Click(object sender, EventArgs e)
        {
            baglan.uyeguncelle(txtname.Text,txtsname.Text,txttc.Text,txtdy.Text,txtsfre.Text);
        }
        #endregion

        #region Geri dönüş butonu
        private void button1_Click(object sender, EventArgs e)
        {   musterii mstr = new musterii();
            this.Close();
            mstr.Show();
        }
        #endregion
    }
}
