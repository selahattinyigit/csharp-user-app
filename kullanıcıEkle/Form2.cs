using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kullanıcıEkle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

                label3.Text = "TC Kimlik No     " + Form1.tc;
                label1.Text = "Ad              " + Form1.ad;
                label2.Text = "Soyad           " + Form1.soyad;
            
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void bilgileriniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
               {
                DialogResult cevap;

                cevap = MessageBox.Show("Bilgilerinizi düzenlemek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                  if (cevap == DialogResult.Yes)
                  {
                      Form5 frm = new Form5();
                             frm.Show();
                    frm.textBox1.Text = Form1.k_ad;
                     frm.textBox2.Text = Form1.parola;
                       frm.textBox3.Text = Form1.tc;
                      frm.textBox4.Text = Form1.ad;
                     frm.textBox5.Text = Form1.soyad;
                     }
               }


              catch (Exception hata)
              {

                  MessageBox.Show(hata.Message);

              }
            }

        }
    }

