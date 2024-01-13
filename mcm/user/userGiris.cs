using mcm;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace mcmAutomation.user
{
    public partial class userGiris : Form
    {
        public userGiris()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=mcmDb;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter reader ;


        void button1_Click(object sender, EventArgs e)
        {
             string username = textBox1.Text;
             string password = textBox2.Text;

            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM Users WHERE username ='" + username + "' AND password='" + password + "'";
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                userAnasayfa fr = new userAnasayfa();
                fr.textBox5.Text = textBox1.Text;
                fr.Show();
                this.Hide();       
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre");
            }
            baglanti.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            anasayfa obj = new anasayfa();
            obj.Show();
            this.Hide();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            suppliersKayit obj = new suppliersKayit();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userSifreYenile obj = new userSifreYenile();
            obj.Show();
            this.Hide();
        }

       // private void userGiris_Load(object sender, EventArgs e)
       //{
       //}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void userGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
