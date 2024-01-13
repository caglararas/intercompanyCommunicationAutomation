using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mcmAutomation.user
{
    public partial class suppliersKayit : Form
    {
        public suppliersKayit()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlDataAdapter da;
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=mcmDb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            userGiris obj = new userGiris();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (textBox1.Text == " " || textBox2.Text == "" || textBox3.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("Kayıt olmak için boş alanları doldurunuz !");
            }
            else
            {

                SqlCommand komut = new SqlCommand("INSERT INTO Users (username,mailadress,password) VALUES ('" + textBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "', '" + textBox3.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydınız başarıyla oluşturulmuştur.");
            }
            baglanti.Close();
        }

        private void suppliersKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
