using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMed
{
    public partial class Form5 : Form
    {
        Size pbsize;
        int xpoz, ypoz;
        int progress = 0;
        bool state = false;
        public Form5()
        {
            InitializeComponent();
            label2.Text = "LOADING...";
            label1.Text = progress.ToString()+"%";
            pbsize = pictureBox1.Size;
            xpoz = pictureBox1.Bounds.X;
            ypoz = pictureBox1.Bounds.Y;
            timer1.Start();
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {if (!state && progress%3==0)
            {
                state = true;
                pbsize.Height += 4;
                pbsize.Width += 4;
                xpoz -= 1;
                ypoz -= 1;
                
                pictureBox1.SetBounds(xpoz, ypoz, pbsize.Width, pbsize.Height);
      
            }
            else if(progress%2==0)
            {
                state = false;
                pbsize.Height -= 4;
                pbsize.Width -= 4;
                xpoz += 1;
                ypoz += 1;
                pictureBox1.SetBounds(xpoz, ypoz, pbsize.Width, pbsize.Height);


            }
            label1.Text = progress.ToString() + "%";
            progress++;

            if (progress == 102)
            {
                timer1.Enabled = false;
                Form1 F1 = new Form1();
                F1.Show();
                this.Hide();
            
            
            }



        }
    }
}
