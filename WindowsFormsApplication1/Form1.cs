using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.AspNet.SignalR.Client;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //==importy
        public String UserName { get; set; }
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://zpicapgemini2.azurewebsites.net/";
        public HubConnection Connection { get; set; }
        public static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        //==importy
        
        private mapa MojaPlansza;// = new mapa();
        private PictureBox[,] PBPrzeciwnika;// = new PictureBox[10, 10];
        private PictureBox[,] PBMoje;// = new PictureBox[10, 10];
        private PictureBox PrawaStrona;// = new PictureBox();
        private PictureBox LewaStrona;// = new PictureBox();
        private Thread th;
        private string NickPrzeciwnika;

        public Form1()
        {
            InitializeComponent();
            MojaPlansza = new mapa();
            PBPrzeciwnika = new PictureBox[10, 10];
            PBMoje = new PictureBox[10, 10];
            PrawaStrona = new PictureBox();
            LewaStrona = new PictureBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparentPanel.MouseClick += Mouse_Click;
            MojaPlansza.randomRozstaw();
            generowanie_grafiki();
            updateMapy();
            tb_Czat.Enabled = false;
            b_Wyslij.Enabled = false;
        }

        //========== funkcje związane z widocznymi obiektami (buttony, panel itp) ==========
        private void Mouse_Click(object sender, EventArgs e)
        {
            int x, y;
            MouseEventArgs eM = (MouseEventArgs)e;
            x = (eM.X - 43) / 34;
            y = (eM.Y - 44) / 34;

            if (eM.X > 40 && eM.Y > 40)
            {
                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    lb_Log.Items.Add("Ty strzelasz x: " + (x + 1).ToString() + " y: " + (y + 1).ToString());
                    lb_Log.SelectedIndex = lb_Log.Items.Count - 1;
                    lb_Log.SelectedIndex = -1;
                    HubProxy.Invoke("SendCoordinates", NickPrzeciwnika, y, x);
                    //PBPrzeciwnika[y, x].BackgroundImage = Image.FromFile("icons\\x.png");
                }
            }
        }

        private void b_Wyslij_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_Czat.Text))
            {
                HubProxy.Invoke("SendPrivateMessage", NickPrzeciwnika, tb_Czat.Text);
                lb_Czat.Items.Add(UserName + ": " + tb_Czat.Text);
            }
            tb_Czat.Clear();
        }

        private void b_Polacz_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_NickGracza.Text))
            {
                UserName = tb_NickGracza.Text;
                tb_NickGracza.Enabled = false;
                lb_Log.Items.Add("Connecting to server...");
                ConnectAsync();
                b_Polacz.Enabled = false;
                b_Polacz.Visible = false;
                b_Graj.Enabled = true;
                b_Graj.Visible = true;

            }
        }

        private void b_Graj_Click(object sender, EventArgs e)
        {
            if (lb_ListaGraczy.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz przeciwnika!");
            }
            else
            {
                NickPrzeciwnika = lb_ListaGraczy.GetItemText(lb_ListaGraczy.Items[lb_ListaGraczy.SelectedIndex]);
                lb_Log.Items.Add(NickPrzeciwnika);
                if (String.Equals(NickPrzeciwnika, UserName))
                {
                    MessageBox.Show("Nie możesz grać sam ze sobą!!!");
                }
                else if (!String.Equals(NickPrzeciwnika, UserName))
                {
                    gramy();
                }
            }

        }
        //========== funkcje związane z widocznymi obiektami (buttony, panel itp) ==========

        //========== funkcje moje ==========
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
                }
            }
        }

        private void gramy()
        {
            //========== logika ==========
            th.Abort();
            //========== logika ==========

            //========== zmiana UI ==========
            tb_NickGracza.Visible = false;
            lb_ListaGraczy.Enabled = false;
            lb_ListaGraczy.Visible = false;
            label_Czat.Visible = true;
            lb_Czat.Visible = true;
            tb_Czat.Visible = true;
            tb_Czat.Enabled = true;
            b_Wyslij.Visible = true;
            b_Wyslij.Enabled = true;
            b_Graj.Enabled = false;
            b_Graj.Visible = false;
            TransparentPanel.Visible = true;
            lb_Log.Items.Clear();
            //========== zmiana UI ==========
        }

       private void generowanie_grafiki()
        {
            int offsetX = 0;
            int offsetY = 0;
            for (int x = 0; x < 10; x++)
            {
                if (x > 6)
                    offsetX = 3;                    //magia, nie czytaj
                for (int y = 0; y < 10; y++)        //bo i tak nie zrozumiesz xD
                {
                    if (y >= 3)
                        offsetY = 4;
                    PBMoje[y, x] = new PictureBox();
                    PBMoje[y, x].Name = "PBMoje_" + x.ToString() + "_" + y.ToString();
                    PBMoje[y, x].Location = new Point(682 + ((x + 1) * 34) + offsetX, 14 + ((y + 1) * 34) + offsetY);
                    PBMoje[y, x].Size = new Size(25, 25);
                    PBMoje[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(PBMoje[y, x]);
                    PBPrzeciwnika[y, x] = new PictureBox();
                    PBPrzeciwnika[y, x].Name = "PBPrzeciwnika_" + x.ToString() + "_" + y.ToString();
                    PBPrzeciwnika[y, x].Location = new Point(12 + ((x + 1) * 34) + offsetX, 15 + ((y + 1) * 34) + offsetY);
                    PBPrzeciwnika[y, x].Size = new Size(25, 25);
                    PBPrzeciwnika[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(PBPrzeciwnika[y, x]);
                    offsetY = 0;
                }
                offsetX = 0;
            }

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

        //connect to server
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("ChatHub");
            
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                lb_Log.Items.Add("Unable to connect to server: Start server before connecting clients.");
                return;
            }

            lb_Log.Items.Add("Connected to server at " + ServerURI + "\r"); //połączenie z serwerem
            HubProxy.Invoke("AddUser", UserName);                           //i dodanie siebie jako gracza
            

            th = new Thread(odswiez);   //odpalamy watek ktory odswieza
            th.IsBackground = true;     //liste graczy co 8 sekund
            th.Start();

            HubProxy.On<int, int>("GetCoordinates", (y, x)=>     //funkcja wykonuje sie po strzale przeciwnika
                {
                    lb_Log.Items.Add("Przeciwnik strzela x: " + (x + 1) + " y: " + (y + 1));
                    if (!MojaPlansza.strzal(x,y))
                    {
                        PBMoje[y, x].BackgroundImage = Image.FromFile("icons\\kropa.png");
                        lb_Log.Items.Add("WODA!");
                        HubProxy.Invoke("SendSinkInfoToEnemy", NickPrzeciwnika, 0, y, x);
                    }
                    else
                    {
                        PBMoje[y, x].BackgroundImage = Image.FromFile("icons\\x.png");
                        lb_Log.Items.Add("TRAFIONY!");
                        HubProxy.Invoke("SendSinkInfoToEnemy", NickPrzeciwnika, 1, y, x);
                    }

                });

            HubProxy.On<int, int, int>("GetSinkInfo", (y, x, z) =>
                {
                    if(z==1)
                    {
                        PBPrzeciwnika[y, x].BackgroundImage = Image.FromFile("icons\\x.png");
                        lb_Log.Items.Add("TRAFIONY!");
                    }
                    if(z==0)
                    {
                        PBPrzeciwnika[y, x].BackgroundImage = Image.FromFile("icons\\kropa.png");
                        lb_Log.Items.Add("WODA!");
                    }
                });

            HubProxy.On<List<UserDetail>>("SetUsersList", (ConnectedUsers2) =>      //po zazadaniu aktualizacji listy aktywnych
                {                                                                   //userow serwer wywola na nas te funkcje
                    ConnectedUsers = ConnectedUsers2;
                    GetActiveUsers();
                });

            HubProxy.On<string, string>("addNewMessageToPage", (name, message) => //po napisaniu wiadomosci przez przeciwnika
                 lb_Czat.Items.Add(name + ": " + message));                       //serwer wywola te funkcje na nas
        }

        private void GetActiveUsers()
         {
            lb_Log.Items[lb_Log.Items.Count -1] = "Aktywnych: " + ConnectedUsers.Count + " graczy";
            lb_ListaGraczy.Items.Clear();
            for (int i = 0; i < ConnectedUsers.Count; i++)
                lb_ListaGraczy.Items.Add(ConnectedUsers[i].UserName);
        }

        private void odswiez()
        {
            while (true)                    //watek odswieza liste
            {                               //graczy co 8 sekund
                HubProxy.Invoke("GetUsersList");
                System.Threading.Thread.Sleep(8000);
            }
        }

        //po 30s z automatu sie wylaczy
        private void Connection_Closed()
        {
            lb_Log.Items.Add("Halo halo mamy problem z połączeniem!");
        }

        private void WPFClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

       
    }
}
