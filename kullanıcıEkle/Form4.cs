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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Form1.baglanti);
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            try
               {
                DialogResult cevap;

                cevap = MessageBox.Show("Kullanıcıyı Eklemek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                  if (cevap == DialogResult.Yes)
                  {
                       cmd = new SqlCommand();      
                     con.Open();
                       cmd.Connection = con;
                     string ad = textBox1.Text;
                        if (comboBox1.Text == "Yönetici")
                        {
                           cmd.CommandText = "insert into kullanıcılar(k_ad,parola,seviye) values (@k_ad,@parola,@seviye)";
                           cmd.Parameters.AddWithValue("@k_ad", textBox1.Text);
                           cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                           cmd.Parameters.AddWithValue("@seviye", comboBox1.Text);
                           cmd.ExecuteNonQuery();             
                         }
                         else
                         {
                            cmd.CommandText = "insert into kullanıcılar(k_ad,parola,tc,ad,soyad,seviye) values (@k_ad,@parola,@tc,@ad,@soyad,@seviye)";
                            cmd.Parameters.AddWithValue("@k_ad", textBox1.Text);
                            cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                            cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                            cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                            cmd.Parameters.AddWithValue("@soyad", textBox5.Text);
                            cmd.Parameters.AddWithValue("@seviye", comboBox1.Text);
                            cmd.ExecuteNonQuery();
                           }
                          con.Close();
                          textBox1.Clear();
                          textBox2.Clear();
                          textBox3.Clear();
                          textBox4.Clear();
                          textBox5.Clear();
                          Form3 frm = new Form3();
                          frm.Show();
                          this.Hide();
                      MessageBox.Show("kullanıcı kaydedildi");
            
        
                    } 
               }


              catch (Exception hata)
              {

                  MessageBox.Show(hata.Message);

              }
            

        }
                  


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yönetici")
            {
                groupBox2.Visible = false;
                groupBox1.Visible = true;

                this.Height = 301;
                this.Width = 405;
                button1.Location = new Point(12, 210);
                button2.Location = new Point(200, 210);
                button1.Visible = true;
                button2.Visible = true;
            }
            else if(comboBox1.Text=="Kullanıcı")
            {
                this.Height = 516;
                this.Width = 405;
                groupBox2.Visible = true;
                groupBox1.Visible = true;
                button1.Location = new Point(12, 423);
                button2.Location = new Point(200, 423);
                button1.Visible = true;
                button2.Visible = true;

            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 f1 = (Form3)Application.OpenForms["Form3"];
            f1.griddoldur();
        }
    }
}
