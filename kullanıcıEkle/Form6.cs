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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Form1.baglanti);
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Şifreyi Değiştirmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "Update kullanıcılar Set parola=@parola Where k_ad=@k_ad";
                    cmd.Parameters.AddWithValue("@k_ad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("şifreniz değiştirildi \n Tekrar giriş yapmanız gerekiyor");
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();

                }
            }



            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}

