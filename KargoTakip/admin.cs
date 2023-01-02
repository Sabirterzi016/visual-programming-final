using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


namespace KargoTakip
{
    public partial class admin : Form
    {
        Form1 frm = new Form1();
        
        public admin()
        {
            InitializeComponent();
        }
        
        #region destek yanıtlama sayfasına yönlendirdim
        private void button1_Click_1(object sender, EventArgs e)
        {
            destek_yanit dstky = new destek_yanit();

            dstky.Show();
            this.Hide();
        }
        #endregion

        #region buton3 tıklandığı zaman var olan kargoları listeledim
        private void button3_Click_1(object sender, EventArgs e)
        {
            kargo_gnc krgn = new kargo_gnc();

            krgn.Show();
            this.Hide();
        }
        #endregion

        #region Musteri guncelleme sayfasına yönlendirdim
        private void button4_Click_1(object sender, EventArgs e)
        {
            musterignc mstrgn = new musterignc();

            mstrgn.Show();
            this.Hide();
        }
        #endregion

        #region çıkış yap butonu ayarladım
        private void button8_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Hide();
        }
        #endregion


    }
}
