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


        #region MySql Baglantısı yaptım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        Baglanti baglan = new Baglanti();
        admin admn = new admin();
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
            baglan.uyeg_uncelle(txtname.Text, txtsname.Text, txtmail.Text, txttc.Text, txtdy.Text, txtsfre.Text, txtsfre.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from uyeler where uyeId=@id", conn);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.ExecuteNonQuery();
            verigoster("SELECT * FROM admin");
            conn.Close();
            txtId.Clear();

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtdy.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtsfre.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtrol.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


        }
    }
}
