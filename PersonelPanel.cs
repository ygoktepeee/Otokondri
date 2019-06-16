using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otokondri
{
    public partial class PersonelPanel : Form
    {
        public PersonelPanel()
        {
            InitializeComponent();
        }
       public string personelid;
        private void PersonelPanel_Load(object sender, EventArgs e)
        {
           string islem = "select Yetki from tbl_Personel where Email='"+personelid+"'";
            DataTable tbl = SqlConn.goster(islem);
            if (tbl.Rows[0]["Yetki"].ToString() == "AD" || tbl.Rows[0]["Yetki"].ToString() == "SD")
            {
                button_PersonelIslemleri.Visible = false;
            }
        }

        private void button_AracEkleSil_Click(object sender, EventArgs e)
        {
            AracEkleSil AracEkleSil = new AracEkleSil();
            AracEkleSil.Show();
        }

        private void button_PersonelIslemleri_Click(object sender, EventArgs e)
        {
            PersonelEkleSil PersonelEkleSil = new PersonelEkleSil();
            PersonelEkleSil.Show();
        }

        private void button_AracDetayDuzenle_Click(object sender, EventArgs e)
        {
            AracDetayDuzenle AracDetayDuzenle = new AracDetayDuzenle();
            AracDetayDuzenle.Show();
        }

        private void button_AracDetayGoster_Click(object sender, EventArgs e)
        {
            AracDetayGoster AracDetayGoster = new AracDetayGoster();
            AracDetayGoster.Show();
        }

        private void button_LogoutPanel_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Çıkmak istediğinizden emin misiniz ?", "Uyarı",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
