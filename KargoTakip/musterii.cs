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
    public partial class musterii : Form
    {
        string asd = Settings1.Default.kadi;

        #region MySql Baglantısı yaptım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        Form1 form1 = new Form1();
        #endregion
        public musterii()
        {
            InitializeComponent();
        }
        int kontrol = 0;
        #region pictureBox1 tıklandığında kargo sorgulattım
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Height = 492;
            panel2.Visible = true;

            conn.Open();
            string kayit = "SELECT takip_no, durum, teslim_tipi, teslim_tarih, gonderilen_tarih, odeme_tipi, alici_adres, gonderen_mail from gonderi_takip	where takip_no = @krgno";
            //musteriler tablosundaki tüm alanları isim parametresi
            MySqlCommand komut = new MySqlCommand(kayit, conn);
            komut.Parameters.AddWithValue("@krgno", txtsorgu.Text);
            //isim parametremize textbox'dan girilen değeri aktarıyoruz.
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        #endregion
        
        #region buton1 tıklandığında bilgilerim sayfasına yönlendirdim
        private void button1_Click(object sender, EventArgs e)
        {
            bilgilerim blgm = new bilgilerim();

            blgm.Show();
            this.Hide();
        }
        #endregion

        #region buton2 tıklandığında kargo gönder sayfasına yönlendirdim
        private void button2_Click(object sender, EventArgs e)
        {
            kargo_gonder kgndr = new kargo_gonder();

            kgndr.Show();
            this.Hide();
        }
        #endregion

        #region buton3 tıklandığında önceki kargolarıma yönlendirdim 
        private void button3_Click(object sender, EventArgs e)
        {
            onceki_kargolarim okrgo = new onceki_kargolarim();

            okrgo.Show();
            this.Hide();
        }
        #endregion

        #region buton4 tıklandığında destek sayfasına yönlendirdim
        private void button4_Click(object sender, EventArgs e)
        {
            destek_sayfasi dstks = new destek_sayfasi();

            dstks.Show();
            this.Hide();
        }
        #endregion

        #region sayfa yüklendiğinde
        private void musterii_Load(object sender, EventArgs e)
        {
            label4.Text = asd;
        }
        #endregion

        #region buton5 tıklandığı zaman çıkış işlemi tanımladım
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            frm.Show();
            this.Hide();
        }
        #endregion 
    }
}
