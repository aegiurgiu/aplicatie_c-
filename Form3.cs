using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BlueMed
{
    public partial class Form3 : Form
    {
        MySqlConnection con=new MySqlConnection("Data Source = localhost; UserId = root; database =bdproiect");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//buton sign up
        {

            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals(""))
            {

                con.Open();

                MySqlCommand ins2 = new MySqlCommand("Insert into medici_date (User,Pass) values('" + textBox5.Text + "', '" + textBox6.Text + "');", con);
                MySqlTransaction trans1 = con.BeginTransaction();
                MySqlCommand ins1 = new MySqlCommand("Insert into medici (Nume, Prenume, Specializare, Functie) values('" + textBox2.Text + "', '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "');", con);


                ins1.Transaction = trans1;
                ins1.ExecuteNonQuery();
                trans1.Commit();

                trans1 = con.BeginTransaction();
                ins2.Transaction = trans1;
                ins2.ExecuteNonQuery();
                trans1.Commit();
                con.Close();
                this.Close();
                Form2 F2 = new Form2();
                F2.ShowDialog();
                MessageBox.Show("Congratulations you are now signed up!");



            }
            else
            {
                MessageBox.Show("Invalid field(s)!");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }
    }
}
