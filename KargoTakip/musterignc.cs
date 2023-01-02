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
    public partial class musterignc : Form
    {
        admin admn = new admin();

        #region MySql Baglantısı yaptım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        Baglanti baglan = new Baglanti();
        #endregion
        public musterignc()
        {
            InitializeComponent();
        }

        #region buton1 tıklandığı zaman geri dön işlemi yaptım
        private void button1_Click(object sender, EventArgs e)
        {
            admn.Show();
            this.Hide();
        }
        #endregion

        public void verigoster(string veriler)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(veriler, conn);
                DataSet dtgrv = new DataSet();
                da.Fill(dtgrv);

                dataGridView1.DataSource = dtgrv.Tables[0];
            }
            catch (Exception)
            {
                this.Refresh();
            }


        }

        private void musterignc_Load(object sender, EventArgs e)
        {
            verigoster("SELECT * FROM uyeler");
            conn.Open();
            string kayit = "SELECT * from uyeler";
            MySqlCommand komut = new MySqlCommand(kayit, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           /* baglan.musterignc(txtname.Text, txtsname.Text, txtmail.Text, txttc.Text, txtdy.Text, txtsfre.Text, txtrol.Text);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from uyeler where uyeId=@id", conn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.ExecuteNonQuery();
            verigoster("SELECT * FROM admin");
            conn.Close();
            textBox1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            verigoster("SELECT * FROM uyeler");
            conn.Open();
            string kayit = "SELECT * from uyeler";
            MySqlCommand komut = new MySqlCommand(kayit, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
