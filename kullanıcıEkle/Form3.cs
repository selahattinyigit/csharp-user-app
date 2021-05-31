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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(Form1.baglanti);
        SqlDataReader dr;
        public void griddoldur()
        {
            string a = "Kullanıcı ";
            listView1.Items.Clear();
            con.Open();
            cmd = new SqlCommand("Select * From kullanıcılar where seviye=@seviye", con);
            cmd.Parameters.AddWithValue("@seviye", a);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["k_ad"].ToString());
                item.SubItems.Add(dr["parola"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void kayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult cevap;

                    cevap = MessageBox.Show("Kullanıcıyı düzenlemek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {
                        Form5 frm = new Form5();
                        frm.Show();
                        ListViewItem item = listView1.SelectedItems[0];
                        frm.textBox1.Text = item.SubItems[0].Text;
                        frm.textBox2.Text = item.SubItems[1].Text;
                        frm.textBox3.Text = item.SubItems[2].Text;
                        frm.textBox4.Text = item.SubItems[3].Text;
                        frm.textBox5.Text = item.SubItems[4].Text;
                        frm.textBox1.Enabled = false;

                    }
                }


                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
            }

            else
                MessageBox.Show("Seçili Kayıt Yok");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult cevap;

                    cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {

                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE from kullanıcılar where k_ad=@k_ad";
                        cmd.Parameters.Add("@k_ad", SqlDbType.Char).Value = listView1.SelectedItems[0].Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        griddoldur();
                        MessageBox.Show("kullanıcı silindi");

                    }
                }


                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
            }
            else
                MessageBox.Show("seçili satır yok");

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult cevap;

                    cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {

                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE from kullanıcılar where k_ad=@k_ad";
                        cmd.Parameters.Add("@k_ad", SqlDbType.Char).Value = listView1.SelectedItems[0].Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        griddoldur();
                        MessageBox.Show("kullanıcı silindi");

                    }
                }


                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
            }
            else
                MessageBox.Show("seçili satır yok");

        }


        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult cevap;

                    cevap = MessageBox.Show("Kullanıcıyı düzenlemek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {
                        Form5 frm = new Form5();
                        frm.Show();
                        ListViewItem item = listView1.SelectedItems[0];
                        frm.textBox1.Text = item.SubItems[0].Text;
                        frm.textBox2.Text = item.SubItems[1].Text;
                        frm.textBox3.Text = item.SubItems[2].Text;
                        frm.textBox4.Text = item.SubItems[3].Text;
                        frm.textBox5.Text = item.SubItems[4].Text;
                        frm.textBox1.Enabled = false;

                    }
                }


                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
            }

            else
                MessageBox.Show("Seçili Kayıt Yok");
        }

        private void yöneticiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Şifreyi Değiştirmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    Form6 frm = new Form6();
                    frm.Show();
                    this.Hide();
                    frm.textBox1.Text = Form1.k_ad;
                    frm.textBox2.Text = Form1.parola;
                    frm.textBox1.Enabled = false;
                }


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }
    }

    }