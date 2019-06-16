using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Otokondri
{
    class SqlConn
    {
       

      
        
        public static void Islemler(string  komut)
        {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
                con.Open();
                SqlCommand cmd = new SqlCommand(komut, con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
        }

        public static string Id_Deger(string sql, string isNullStr = null)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;

            string result;
            if (isNullStr != null)
            {
                try
                {
                    result = command.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    result = isNullStr;
                }
            }
            else
            {
                result = command.ExecuteScalar().ToString();
            }

            conn.Close();
            return result;
        }

        public static DataTable goster(string kod)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kod, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable select(string kod)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7L6TOHU;Initial Catalog=OtokondriOtomasyon;Persist Security Info=True;User ID=sa;Password=123456789");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kod, conn);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("Hata!!");
            }
            
            conn.Close();
            return dt;
        }



    }



}
