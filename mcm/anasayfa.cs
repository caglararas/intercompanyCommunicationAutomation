using mcmAutomation;
using mcmAutomation.user;

namespace mcm
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminGiris obj = new adminGiris();
            obj.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userGiris obj = new userGiris();
            obj.Show();
            this.Hide();

        }
    }
}