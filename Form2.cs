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
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection("Data Source = localhost; UserId = root; database =bdproiect");

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             con.Open();
                MySqlCommand sel = new MySqlCommand("Select * from medici_date where User='" + textBox1.Text + "' and Pass='" + textBox2.Text + "';", con);
                MySqlDataReader mr = sel.ExecuteReader();

                if (mr.Read())
                {   
                    sel.CommandText = "Select * from medici where Id=" + mr.GetString(0) + ";";
                    mr.Close();
                    mr = sel.ExecuteReader();
                    mr.Read();
                    String name = mr.GetString(1) + " " + mr.GetString(2);
                    mr.Close();
                    this.Close();
                    Form4 F4 = new Form4(name);
                    F4.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect user or password!\nIf you dont have an account please sign-up first!");
                }
                
               con.Close();
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
