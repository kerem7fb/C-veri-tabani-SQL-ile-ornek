using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;
using System.Data.OleDb;
namespace deneme11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection yeni = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=deneme11.mdb");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yeni.Open();
            string kullanici=textBox1.Text;
            string sifre=textBox2.Text;
            OleDbCommand komut = new OleDbCommand("Select * From Kullanici Where KullaniciAdi='" + kullanici + "'AND Sifre='" + sifre + "'", yeni);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Kullanıcı Adı Ve Şifre Doğru,Giriş Başarılı");
                Form2 ileri = new Form2();
                ileri.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı,Lütfen Tekrar Deneyiniz");
            }
            yeni.Close();
        }
    }
}
