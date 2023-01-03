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
    public partial class kargo_gnc : Form
    {
        #region MySql bağlantısı yaptım
        admin admn = new admin();
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        #endregion
        public kargo_gnc()
        {
            InitializeComponent();
        }

        #region geri dön işlemi atadım
        private void button1_Click(object sender, EventArgs e)
        {
            admn.Show();
            this.Hide();
        }
        #endregion

        #region sayfa yüklendiğinde yapılcak işlemi tanımladım
        private void kargo_gnc_Load(object sender, EventArgs e)
        {
            conn.Open();
            string kayit = "SELECT * from gonderi_takip	";
            MySqlCommand komut = new MySqlCommand(kayit, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        #endregion

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmtn.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmkd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtkt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
