using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;



namespace KargoTakip
{
    public partial class Form1 : Form
    {
        string hava_drm_lnk = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

        Baglanti baglan = new Baglanti();

        public Form1()
        {
            InitializeComponent();
        }
        public static string girismail;
        string girisifre;
        public string roll;

        #region btnoyeol' a tıklandığında üye olsayfasına yönlendirdim
        private void btnuyeol_Click_1(object sender, EventArgs e)
        {
            kayit frm2 = new kayit();
            frm2.Show();
            this.Hide();
            this.Height = 274;
        }
        #endregion

        #region Sayfa yüklendiğinde hava durumu getirdim
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(hava_drm_lnk);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");
            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string max_scaklk = node["Mak"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = ili;
                row.Cells[1].Value = durum;
                row.Cells[2].Value = max_scaklk;
                dataGridView1.Rows.Add(row);

            }

        }

        #endregion

        #region grs butonu tıklandığında
        private void btngrs_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();

            string kontrolmail = txtemail.Text;
            string kontrolsifre = txtsifre.Text;
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
            conn.Open();
            MySqlCommand okuma = new MySqlCommand();
            okuma.Connection = conn;
            okuma.CommandText = "SELECT * FROM uyeler WHERE mail= '" + txtemail.Text + "'";
            MySqlDataReader adapter = okuma.ExecuteReader();
            while (adapter.Read())
            {
                girismail = adapter["mail"].ToString();
                girisifre = adapter["uyeSifre"].ToString();
                roll = adapter["rol"].ToString();
            }
            conn.Close();
            if (girismail == kontrolmail && girisifre == kontrolsifre && roll == "u")
            {
                this.Hide();
                musterii mstr = new musterii();
                mstr.Show();
                Settings1.Default.kadi = txtemail.Text;
                Settings1.Default.Save();
            }
            else if (girismail == kontrolmail && girisifre == kontrolsifre && roll == "a")
            {
                this.Hide();
                admin adm = new admin();
                adm.Show();
            }
            else
            {
                label5.Visible = true;
                label5.Text = "lütfen üye olunuz!";
            }
        }
        #endregion

    }
}
