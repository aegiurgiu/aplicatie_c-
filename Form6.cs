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
    public partial class Form6 : Form
    {
        MySqlConnection con = new MySqlConnection("Data Source = localhost; UserId = root; database =bdproiect");
        string drname;
        DataSet ds;
        public Form6( String name)
        {
            InitializeComponent();
            drname = name;
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            label3.Text = name;
            con.Open();
            ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter("Select NumePacient,CNP,Ora from programari_medici where NumeDoctor='" + name + "' and Ziua='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and Modificari='';", con);
            da.Fill(ds, "programari_medici");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                con.Open();
                int index = dataGridView1.SelectedRows[0].Index;
                MySqlCommand com = new MySqlCommand("Update programari_medici set Modificari='Programarea a fost stearsa' where CNP='" + dataGridView1[1, index].Value.ToString() + "';", con);
                MySqlTransaction trans = con.BeginTransaction();
                try
                {
                    com.Transaction = trans;
                    com.ExecuteNonQuery();
                    trans.Commit();
                    con.Close();
                }
                catch
                {
                    trans.Rollback();

                }
            }
            else MessageBox.Show("Select the disered row!");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4(drname);
            f4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            con.Open();
            ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter("Select NumePacient,CNP,Ora from programari_medici where NumeDoctor='" + drname + "' and Ziua='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and Modificari='';", con);
            da.Fill(ds, "programari_medici");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
