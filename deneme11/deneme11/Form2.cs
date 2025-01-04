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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection yeni = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=deneme11.mdb");
        public void goruntule() 
        {
            yeni.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Bilgiler", yeni);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            yeni.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Insert into Bilgiler(OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciCinsiyet)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            goruntule();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Update Bilgiler Set OgrenciAd='" + textBox2.Text + "',OgrenciSoyad='" + textBox3.Text + "',OgrenciCinsiyet='" + textBox4.Text + "'Where OgrenciNo='" + textBox1.Text + "'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            goruntule();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Delete From Bilgiler Where OgrenciNo='" + textBox1.Text + "'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            goruntule();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
