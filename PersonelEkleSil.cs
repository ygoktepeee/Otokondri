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
    public partial class PersonelEkleSil : Form
    {
        public PersonelEkleSil()
        {
            InitializeComponent();
        }

        private void PersonelEkleSil_geri_Click(object sender, EventArgs e)
        {
            PersonelPanel PersonelPanel = new PersonelPanel();
            this.Hide();
        }

        private void PersonelEkleSil_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Id,Ad,Soyad,TCKN,Parola,Cinsiyet,Yetki,Email from tbl_Personel", con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView_PersonelSil.DataSource = dtable;
            con.Close();
        }

        private void btn_PersonelEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_PersonelParola.Text == textBox_ParolaTekrar.Text)
                {
                    string cinsiyett = "";
                    string yetki = "";
                    if (checkBox_Erkek.Checked == (true))
                    {
                        cinsiyett = "E";
                    }
                    else if (checkBox_Kadin.Checked == (true))
                    {
                        cinsiyett = "K";
                    }
                    if (checkBox_SatisDep.Checked == (true))
                    {
                        yetki = "SD";
                    }
                    else if (checkBox_AlisDep.Checked == (true))
                    {
                        yetki = "AD";
                    }
                    else if (checkBox_Yonetici.Checked == (true))
                    {
                        yetki = "Y";
                    }
                    

                    string sql = "insert into tbl_Personel(Ad,Soyad,TCKN,Parola,Yetki,Cinsiyet,Email) values('" + textBox_PersonelAd.Text + "','" + textBox_PersonelSoyad.Text + "','" + textBox_TCKN.Text + "','" + textBox_PersonelParola.Text + "','" + yetki + "','" + cinsiyett + "','"+textBox_Email.Text+"')";
                    SqlConn.Islemler(sql);

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from tbl_Personel", con);
                    DataTable dtable = new DataTable();
                    adapter.Fill(dtable);
                    dataGridView_PersonelSil.DataSource = dtable;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Parolalar Uyuşmuyor!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!");
            }
        }
        

        private void dataGridView_PersonelSil_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PersonelGuncelle prsgnc = new PersonelGuncelle();


            prsgnc.id = dataGridView_PersonelSil["Id", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.ad = dataGridView_PersonelSil["Ad",dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.soyad = dataGridView_PersonelSil["Soyad", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.tc= dataGridView_PersonelSil["TCKN", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.parola= dataGridView_PersonelSil["Parola", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.yetki= dataGridView_PersonelSil["Yetki", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.cinsiyet = dataGridView_PersonelSil["Cinsiyet", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();
            prsgnc.email = dataGridView_PersonelSil["Email", dataGridView_PersonelSil.CurrentCell.RowIndex].Value.ToString();

            prsgnc.Show();
            this.Hide();
        }

        private void checkBox_Erkek_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Kadin.Checked = false;
        }

        private void checkBox_Kadin_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Erkek.Checked = false;
        }

        private void checkBox_Yonetici_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_SatisDep.Checked = false;
            checkBox_AlisDep.Checked = false;
        }

        private void checkBox_AlisDep_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Yonetici.Checked = false;
            checkBox_SatisDep.Checked = false;
        }

        private void checkBox_SatisDep_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_AlisDep.Checked = false;
            checkBox_Yonetici.Checked = false;
        }
    }
}
