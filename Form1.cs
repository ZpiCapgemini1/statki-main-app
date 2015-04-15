using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool[] flagablokady = new bool[5];
        public Form1()
        {
            InitializeComponent();
            pictureBox2.Load("icons\\3.png");
            pictureBox4.Load("icons\\3.png");
            pictureBox5.Load("icons\\3.png");
            pictureBox6.Load("icons\\4s.png");
            pictureBox7.Load("icons\\4s.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<5;i++)
            {
                flagablokady[i] = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flagablokady[0] == false)
            {
                Log.Items.Add("A1 trafiony!");
                Bitmap bm = new Bitmap("icons\\strzall.png");
                button1.Image=bm;
                flagablokady[0] = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flagablokady[1] == false)
            {
                Log.Items.Add("B1 trafiony!");
                Bitmap bm = new Bitmap("icons\\strzall.png");
                button2.Image = bm;
                flagablokady[1] = true;
            }
        }

        private void wyslij_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                Czat.Items.Add("Ja: " + textBox1.Text);
            }
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flagablokady[2] == false)
            {
                Log.Items.Add("B5 woda!");
                Bitmap bm = new Bitmap("icons\\kropa.png");
                button4.Image = bm;
                flagablokady[2] = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flagablokady[3] == false)
            {
                Log.Items.Add("B4 trafiony zatopiony!");
                Bitmap bm = new Bitmap("icons\\zatopiony.png");
                button3.Image = bm;
                flagablokady[3] = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}
