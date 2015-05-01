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
        PictureBox[,] PBPrzeciwnika = new PictureBox[10,10];
        PictureBox[,] PBMoje = new PictureBox[10, 10];	
        PictureBox PrawaStrona = new PictureBox();
        PictureBox LewaStrona = new PictureBox();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            transparentMessagePanel1.MouseClick += klik_myszki;
            MojaPlansza.randomRozstaw();

            int offsetX = 0;
            int offsetY = 0;
            for (int x = 0; x < 10; x++)
            {
                if (x > 6)
                    offsetX = 3;
                for (int y = 0; y < 10; y++)
                {
                    if (y >= 3)
                        offsetY = 4;
                    PBMoje[y, x] = new PictureBox();
                    PBMoje[y, x].Name = "PBMoje_" + x.ToString() + "_" + y.ToString();
                    PBMoje[y, x].Location = new Point(682 + ((x+1) * 34) + offsetX, 14 + ((y+1) * 34)+offsetY);
                    PBMoje[y, x].Size = new Size(25, 25);
                    PBMoje[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(PBMoje[y, x]);
                    PBPrzeciwnika[y, x] = new PictureBox();
                    PBPrzeciwnika[y, x].Name = "PBPrzeciwnika_" + x.ToString() + "_" + y.ToString();
                    PBPrzeciwnika[y, x].Location = new Point(12 + ((x + 1) * 34) + offsetX, 15 + ((y + 1) * 34) + offsetY);
                    PBPrzeciwnika[y, x].Size = new Size(25, 25);
                    //PBPrzeciwnika[y, x].BackgroundImage = Image.FromFile("icons\\4.png");
                    PBPrzeciwnika[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(PBPrzeciwnika[y, x]);
                    offsetY = 0;
                }
                offsetX = 0;
            }
            updateMapy();

            PrawaStrona.Name = "PBPrawa_Strona";
            PrawaStrona.Location = new Point(670, 2);
            PrawaStrona.Size = new Size(400, 400);
            this.Controls.Add(PrawaStrona);
            PrawaStrona.BackgroundImage = Image.FromFile("icons\\statki ftw.png");
            PrawaStrona.BackgroundImageLayout = ImageLayout.Stretch;

            LewaStrona.Name = "PBLewa_Strona";
            LewaStrona.Location = new Point(0, 2);
            LewaStrona.Size = new Size(400, 400);
            this.Controls.Add(LewaStrona);
            LewaStrona.BackgroundImage = Image.FromFile("icons\\statki ftw.png");
            LewaStrona.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void updateMapy()
        {
            string temp;
            
            for(int x=0;x<10;x++)
            {
                for(int y=0;y<10;y++)
                {
                    temp = MojaPlansza.czytaj(x, y).ToString();
                    PBMoje[y,x].BackgroundImage = Image.FromFile("icons\\" + temp + ".png");
                    temp = "x: " + x.ToString() + " y: " + y.ToString();
                    //Log.Items.Add(temp);
                    //textBox1.Text = "x: "+x.ToString()+" y: "+y.ToString();
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
            x = (eM.X - 43) / 34;
            y = (eM.Y - 44) / 34;
           // Log.Items.Add("eM.X: " + eM.X + "eM.Y: " + eM.Y + " x: " + x + " y: " + y);

            if(eM.X>40 && eM.Y>40)
            {
                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    Log.Items.Add("Stzal na   x: " + (x+1).ToString() + " y: " + (y+1).ToString());
                    Log.SelectedIndex = Log.Items.Count - 1;
                    Log.SelectedIndex = -1;
                    PBPrzeciwnika[y, x].BackgroundImage = Image.FromFile("icons\\x.png");
                }
            }
        }
       
    }
}
