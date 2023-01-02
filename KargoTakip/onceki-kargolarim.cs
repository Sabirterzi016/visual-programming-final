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
    public partial class onceki_kargolarim : Form
    {

        #region MySql Baglantısı yazdım
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=kargotakip;Uid=root;Pwd='root';");
        MySqlCommand cmd;
        MySqlDataReader adapter;
        DataTable dt;
        musterii mstr = new musterii();
        #endregion

        public onceki_kargolarim()
        {
            InitializeComponent();
        }
        #region buton1 e geri çıkış işlemi tanımladım
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mstr.Show();
        }
        #endregion

        #region resime tıklandığı zaman yapılacak işlemi belirttim
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from gonderi_takip where takip_no='" + comboBox2.Text + "' ";
            adapter = cmd.ExecuteReader();
            while (adapter.Read())
            {
                label7.Text = adapter["durum"].ToString();
            }

            conn.Close();
        }
        #endregion
    }
}
