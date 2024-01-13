using mcmAutomation.user;
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

namespace mcmAutomation
{
    public partial class adminAnasayfa : Form
    {
        public adminAnasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=mcmDb;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand komut;

        private void button1_Click(object sender, EventArgs e)
        {
            adminGiris obj = new adminGiris();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void talepGoster()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT Userr AS 'TALEP SAHİBİ' , idDemands AS 'TALEP NO',DemandDate AS 'TALEP TARİHİ',DemandDef AS 'TALEP TANIMI',DueDate as 'BİTİŞ TARİHİ' FROM Demands", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

            dataGridView1.Update();
            dataGridView1.Refresh()s;
        }

        void tedarikGoster()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT idProcurements AS 'TEDARİK NUMARASI', name AS 'TEDARİKÇİ', ProcurementDate AS 'TEDARİK TARİHİ',price as 'FİYAT',currency AS 'PARA BİRİMİ' , approval AS 'ONAY' FROM Procurements,ProcurementItems, Suppliers WHERE Procurements.Supplier_fk=Suppliers.id and Procurements.idProcurements=ProcurementItems.fk_Procurement", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
            dataGridView2.Update();
            dataGridView2.Refresh();
        }
        void userGoster()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT username AS 'KULLANICI ADI', mailadress AS 'MAİL ADRESİ', RoleDef AS 'KULLANICI ROLÜ' FROM Users,Roles WHERE Users.username=Roles.username_fk", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();
        }
        void tedarikciGetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT id AS 'TEDARİKÇİ NUMARASI', name AS 'İSİM', address AS 'ADRES',phone as 'TELEFON',mail AS 'MAİL ADRES' , fax AS 'FAX' FROM Suppliers ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView5.DataSource = tablo;
            baglanti.Close();
            dataGridView5.Update();
            dataGridView5.Refresh();

        }
        void qa()
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT qagroupsname AS 'KALİTE GÜVENCE GRUP İSİM', qadef AS 'KALİTE GÜVENCE TANIMI' FROM qagroups,qarelation,qa WHERE qagroups.idqagroups=qarelation.qagroups_idqagroups and qa.idqa=qarelation.qa_idqa ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            baglanti.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // textBox4.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            // textBox3.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            // textBox10.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
        }

        private void adminAnasayfa_Load(object sender, EventArgs e)
        {
            talepGoster();
            tedarikGoster();
            userGoster();
            qa();
            tedarikciGetir();

        }
    }
}
