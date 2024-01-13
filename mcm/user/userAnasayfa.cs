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
    public partial class userAnasayfa : Form
    {
        public userAnasayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=mcmDb;Integrated Security=True");
        SqlDataAdapter da;


        void talepGoster()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT  Userr AS 'KULLANICI' , DemandDef AS 'TALEP TANIMI',DemandDate AS 'TALEP TARİHİ',DueDate as 'BİTİŞ TARİHİ' FROM Demands,DemandItems WHERE Userr=@username", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@username", textBox5.Text.ToString());
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void userAnasayfa_Load(object sender, EventArgs e)
        {
            kullaniciGoster();
            talepGoster();
            genelTalepGoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userGiris obj = new userGiris();
            obj.Show();
            this.Hide();
        }

        void genelTalepGoster()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT Userr AS 'TALEP SAHİBİ' , idDemands AS 'TALEP NO',DemandDate AS 'TALEP TARİHİ',DemandDef AS 'TALEP TANIMI',DueDate as 'BİTİŞ TARİHİ' FROM Demands", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Demands(Userr,DemandDef,DemandDate,DueDate) values('" + textBox1.Text.ToString() + "' ,'" + textBox4.Text.ToString() + "' , '" + textBox7.Text + "', '" + textBox8.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Talep Başarıyla Oluşturuldu.Tedarikçilerin sizinle iletişime geçmesini bekleyiniz.");
            baglanti.Close();
            talepGoster();
            dataGridView3.Update();
            dataGridView3.Refresh();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Demands where Userr =@Userr ", baglanti);
            komut.Parameters.AddWithValue("@Userr", textBox5.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            talepGoster();
            MessageBox.Show("Talebiniz başarıyla silinmiştir.Eğer tedarik ettiyseniz veri kaydı yapmanız rica olunur.");
            dataGridView3.Update();
            dataGridView3.Refresh();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
           textBox4.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
           textBox7.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
           textBox8.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Suppliers(id,name,address,phone,mail,fax) values('" + textBox13.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox11.Text.ToString() + "' ,'" + textBox10.Text.ToString() + "' , '" + textBox9.Text + "', '" + textBox12.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Tedarikçi kaydı başarıyla oluşturulmuştur.İlgili olduğunuz taleplere tedarik isteği gönderebilirsiniz.");
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tedarik etme isteği başarıyla gönderilmiştir.İlgili birimlerin sizinle iletişime geçmesini bekleyiniz.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void kullaniciGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select username,mailadress,password,mailpassword from Users where Users.username=@username", baglanti);
            komut.Parameters.AddWithValue("@username", textBox5.Text.ToString());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox5.Text = dr["username"].ToString();
                textBox2.Text = dr["mailadress"].ToString();
                textBox3.Text = dr["password"].ToString();

            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Users SET mailadress ='" + textBox2.Text + "',password ='" + textBox3.Text.ToString() + "' WHERE username=@username", baglanti);
            komut.Parameters.AddWithValue("@username", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgileriniz Güncellendi.");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("DİKKAT ! " +
"Sadece mail adresi ve şifre güncellenebilir.");
        }

        private void textBox5_MouseUp(object sender, MouseEventArgs e)
        {


        }
    }

}
    

