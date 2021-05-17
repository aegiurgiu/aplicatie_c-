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
    public partial class Form4 : Form
    {
        MySqlConnection con = new MySqlConnection("Data Source = localhost; UserId = root; database =bdproiect");

        DataSet ds;
        String Drname;
        public Form4(String name)
        {
            InitializeComponent();
            Drname = name;
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            label3.Text = "Dr. " + Drname;
            con.Open();
            ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter("Select NumePacient,CNP,Ora from programari_medici where NumeDoctor='" + Drname + "' and Ziua='"+DateTime.Now.ToString("yyyy-MM-dd")+"';",con);
            da.Fill(ds,"programari_medici");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int index = dataGridView1.SelectedRows[0].Index;
                con.Open();
                MySqlCommand com = new MySqlCommand("Delete from programari_medici where  CNP='" + dataGridView1[1, index].Value.ToString() + "';", con);
                MySqlTransaction trans = con.BeginTransaction();
                com.Transaction = trans;
                com.ExecuteNonQuery();
                trans.Commit();

                ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("Select NumePacient,CNP,Ora from programari_medici where NumeDoctor='" + Drname + "' and Ziua='" + DateTime.Now.ToString("yyyy-MM-dd") + "';", con);
                da.Fill(ds, "programari_medici");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();



            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 F6 = new Form6(Drname);
            F6.ShowDialog();
        }
    }
}
