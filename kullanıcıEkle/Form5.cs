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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Form1.baglanti);
       
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                {
                    DialogResult cevap;

                    cevap = MessageBox.Show("Kullanıcıyı düzenlemek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {
                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = con;
                      con.Open();
                      cmd.CommandText = "Update kullanıcılar Set parola=@parola,tc=@tc,ad=@ad,soyad=@soyad Where k_ad=@k_ad";
                      cmd.Parameters.AddWithValue("@k_ad", textBox1.Text);
                      cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                      cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                      cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                      cmd.Parameters.AddWithValue("@soyad", textBox5.Text);
            
                      cmd.ExecuteNonQuery();
                      con.Close();

                      if (Form1.seviye == "Kullanıcı ")
                      {
                        MessageBox.Show("kayıt güncellendi \n Tekrar giriş yapmanız gerekiyor");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                      }
                      else
                      {
                        MessageBox.Show("kayıt Güncellendi");
                        Close();

                      }

                    }
                }


            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Form1.seviye == "Yönetici")
            {
                Form3 f1 = (Form3)Application.OpenForms["Form3"];
                f1.griddoldur();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
