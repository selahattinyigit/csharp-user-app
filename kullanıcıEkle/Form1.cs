using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kullanıcıEkle
{
    
    
    public partial class Form1 : Form
    {
        
        
            
      public static  string baglanti = "Data Source=DESKTOP-THJMUGL\\HASAN; Initial Catalog=giriş; Integrated Security=True;";
    
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlDataReader dr;
        public static string k_ad;
        public static string parola;
        public static string seviye;
        public static string ad;
        public static string soyad;
        public static string tc;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();            
       
        

            
            SqlConnection con = new SqlConnection(baglanti);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM kullanıcılar where k_ad='" + textBox1.Text + "' AND parola='" + textBox2.Text +"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                seviye = dr["seviye"].ToString();
                ad = dr["ad"].ToString();
                tc = dr["tc"].ToString();
                soyad = dr["soyad"].ToString();
                k_ad = dr["k_ad"].ToString();
                parola=dr["parola"].ToString();
                if (seviye == "Kullanıcı ")
                {

                    Form2 frm = new Form2();

                    frm.Show();
                    this.Hide();
                }
                else
                {

                    Form3 frm = new Form3();

                    frm.Show();
                    this.Hide();
                }
               
              
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();
        }
    }
}
