using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otokondri
{
    public partial class AracDetayDuzenle : Form
    {
        public AracDetayDuzenle()
        {
            InitializeComponent();
        }

        

        private void AracDetayDuzenle_geri_Click(object sender, EventArgs e)
        {
            PersonelPanel PersonelPanel = new PersonelPanel();
            //PersonelPanel.Show();
            this.Hide();
        }

        private void AracDetayDuzenle_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from tbl_Arac", con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView1.DataSource = dtable;
            con.Close();
            //dataGridView1.Rows[0].Visible = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AracGuncelle aracgnc = new AracGuncelle();

            aracgnc.marka = dataGridView1["Marka", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.model = dataGridView1["Model", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.detay = dataGridView1["Detay_Ozellik", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.alisfiyati = dataGridView1["Alis_Fiyati", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.satisfiyati = dataGridView1["Satis_Fiyati", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.plaka = dataGridView1["Plaka", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.id = dataGridView1["Id", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.alistarihi = dataGridView1["Alis_Tarihi", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.satistarihi = dataGridView1["Satis_Tarihi", dataGridView1.CurrentCell.RowIndex].Value.ToString();

            string sorgu= "select * from tbl_Fotograf where Arac_Id="+ dataGridView1["Id", dataGridView1.CurrentCell.RowIndex].Value.ToString();
            aracgnc.resimtable= SqlConn.goster(sorgu);



            aracgnc.Show();
            this.Hide();
        }
    }
}
