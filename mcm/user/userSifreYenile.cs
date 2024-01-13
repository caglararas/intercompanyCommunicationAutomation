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
    public partial class userSifreYenile : Form
    {
        public userSifreYenile()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlDataAdapter da;
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=mcmDb;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            userGiris obj = new userGiris();
            obj.Show();
            this.Hide();
        }

        private void userSifreYenile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz !");
            }
            else
            {
                SqlCommand komut = new SqlCommand("UPDATE Users SET password = '" + textBox3.Text.ToString() + "' WHERE username=@username", baglanti);
                komut.Parameters.AddWithValue("@username", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Şifreniz Yenilendi.");
            }
            baglanti.Close();
        }
    }
}
