using mcm;

namespace mcmAutomation
{
    public partial class adminGiris : Form
    {
        public adminGiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik Veri");
            }
            else if(textBox1.Text == "admin" && textBox2.Text == "123")
            {
                adminAnasayfa Obj = new adminAnasayfa();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlýþ kullanýcý adý veya þifre");
            }
     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
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
    }
}