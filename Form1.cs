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
        int x,y;
        mapa MojaPlansza = new mapa();
        PictureBox[,] PBPrzeciwnika = new PictureBox[11,11];
        PictureBox[,] PBMoje = new PictureBox[11, 11];	


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            transparentMessagePanel1.MouseClick += klik_myszki;
            MojaPlansza.randomRozstaw();
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    PBMoje[y, x] = new PictureBox();
                    PBMoje[y, x].Name = "PBMoje_" + x.ToString() + "_" + y.ToString();
                    PBMoje[y, x].Location = new Point(713 + (x * 32), 44 + (y * 28));
                    PBMoje[y, x].Size = new Size(32, 28);
                    //PBMoje[y, x].BackColor = Color.Transparent;
                    this.Controls.Add(PBMoje[y, x]);
                }
            }
            updateMapy();
            //pictureBox3.Parent = PBMoje[0, 0]; 
        }

        private void updateMapy()
        {
            string temp;
            
            for(int x=0;x<10;x++)
            {
                for(int y=0;y<10;y++)
                {
                    temp = MojaPlansza.czytaj(x, y).ToString();
                    //PBMoje[y,x].Load("icons\\" + temp.ToString() + ".png");
                    PBMoje[y, x].BackgroundImage = Image.FromFile("icons\\" + temp.ToString() + ".png");
                    PBMoje[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    temp = "x: " + x.ToString() + " y: " + y.ToString();
                    Log.Items.Add(temp);
                    textBox1.Text = "x: "+x.ToString()+" y: "+y.ToString();
                }
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
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           /* MouseEventArgs eM = (MouseEventArgs)e;
            x = (eM.X - 45) / 35;
            y = (eM.Y - 45) / 34;
            x++; y++;
            Log.Items.Add("Stzal na   x: " + x + " y: " + y);
            textBox1.Text = eM.X.ToString() + ":" + eM.Y.ToString();
            textBox1.Text = x.ToString() + ":" +y.ToString();*/
        }

        private void klik_myszki(object sender, EventArgs e)
        {
            MouseEventArgs eM = (MouseEventArgs)e;
            x = (eM.X - 45) / 35;
            y = (eM.Y - 45) / 34;
            x++; y++;
            Log.Items.Add("Stzal na   x: " + x + " y: " + y);
            textBox1.Text = eM.X.ToString() + ":" + eM.Y.ToString();
            textBox1.Text = x.ToString() + ":" + y.ToString();
        }
       
    }
}
