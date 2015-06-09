using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class mapa
    {
        private int[,] plansza;
        private Random rand;

        public mapa()
        {
            plansza = new int[10, 10];
            rand = new Random();
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    plansza[y, x] = 0;
        }

        public int get(int x,int y)
        {
            return plansza[y, x];
        }

        public void set(int x, int y, int z)
        {
            plansza[y, x]=z;
        }

        public bool strzal(int x,int y)
        {
            if (plansza[y, x] == 0)
                return false;
            else
                return true;
        }

        public int[] Zatopiony(int x,int y)
        {
            int licznik = 1;
            int pion = 2;
            int y_poczatkowe = y;
            int x_poczatkowe = x;
            
            if (plansza[y, x] == 1)             //jeśli to jedynka to
            {                                   //instant zatapiamy
                //obramowanie(x, y, 1, true);
                return new int[4] {x, y, 1, 0};
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("wchodze tuuu");
                if(y>0 && y<9)
                {
                    //System.Diagnostics.Debug.WriteLine("y><y");
                    if (plansza[y, x] == plansza[y + 1, x] || plansza[y, x] == plansza[y - 1, x])
                        pion = 1;

                    if (x > 0 && x < 9)
                    {
                        if (plansza[y, x] == plansza[y, x + 1] || plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                    else if (x == 0)
                    {
                        if (plansza[y, x] == plansza[y, x + 1])
                            pion = 0;
                    }
                    else if (x == 9)
                    {
                        if (plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                }
                else if(y == 0)          
                {
                    //System.Diagnostics.Debug.WriteLine("y==0");
                    if (plansza[y, x] == plansza[y + 1, x])
                        pion = 1;

                    if (x > 0 && x < 9)
                    {
                        if (plansza[y, x] == plansza[y, x + 1] || plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                    else if (x == 0)
                    {
                        if (plansza[y, x] == plansza[y, x + 1])
                            pion = 0;
                    }
                    else if (x == 9)
                    {
                        if (plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                }
                else if(y == 9)
                {
                    //System.Diagnostics.Debug.WriteLine("y==9");
                    if (plansza[y, x] == plansza[y - 1, x])
                        pion = 1;

                    if (x > 0 && x < 9)
                    {
                        if (plansza[y, x] == plansza[y, x + 1] || plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                    else if (x == 0)
                    {
                        if (plansza[y, x] == plansza[y, x + 1])
                            pion = 0;
                    }
                    else if (x == 9)
                    {
                        if (plansza[y, x] == plansza[y, x - 1])
                            pion = 0;
                    }
                }
                //System.Diagnostics.Debug.WriteLine("po pionach, pion:" + pion);
                if(pion==2)                                 //wszystkie poprzednie warunki nie zostaly
                {                                           //spelnione, wartosc pionu bez zmian
                    return new int[4] {0,0,0,0};            //statek nie jest zatopiony
                }
                else if(pion==1)
                {
                    System.Diagnostics.Debug.WriteLine("wchodze pion x:" + x + " y:" + y);
                    int k = -1;
                    while (y<9 && plansza[y,x]==plansza[y+1, x])
                    {
                        y++;
                    }
                    System.Diagnostics.Debug.WriteLine("po pierwszej y:" + y);
                    while (y + k >= 0 && plansza[y, x] == plansza[y + k, x])
                    {
                        licznik++;
                        if (licznik == plansza[y + k, x])
                        {
                            System.Diagnostics.Debug.WriteLine("zwracam x:" + x + " y:" + y + " k:" + k + " licznik:" + licznik);
                            return new int[4] { x, y + k, licznik, pion };
                        }
                        k--;
                        System.Diagnostics.Debug.WriteLine("w drugiej k:" + k + " licz:" + licznik);
                    }
                    System.Diagnostics.Debug.WriteLine("licznik:"+ licznik +" plansz z k:" + plansza[y + k, x] + " plansza:"+plansza[y,x]); 
                    
                        
                    return new int[4] { 0, 0, 0, 0 };
                }
                else if(pion==0)
                {
                    System.Diagnostics.Debug.WriteLine("wchodze poziom x:"+x+" y:"+y);
                    int k = -1;
                    while (x<9 && plansza[y, x] == plansza[y, x + 1])
                    {
                        x++;
                    }
                    System.Diagnostics.Debug.WriteLine("po pierwszej x:" + x);
                    while (x + k >= 0 && plansza[y, x] == plansza[y, x + k])
                    {
                        licznik++;
                        if (licznik == plansza[y, x + k])
                        {
                            System.Diagnostics.Debug.WriteLine("zwracam x:" + x + " y:" + y + " k:" + k + " licznik:" + licznik);
                            return new int[4] { x + k, y, licznik, pion };
                        }
                        k--;
                        System.Diagnostics.Debug.WriteLine("w drugiej k:" + k + " licz:" + licznik);
                    }
                    System.Diagnostics.Debug.WriteLine("licznik:"+ licznik +" plansz z k:" + plansza[y, x+k] + " plansza:"+plansza[y,x]); 
                    
                        
                    return new int[4] { 0, 0, 0, 0 };
                }
                else
                    return new int[4] {0,0,0,0};
            }
        }

        public void randomRozstaw()
        {
            bool flaga;
            int x, y;
            for(int maszty=4;maszty>=1;maszty--)
            {
                for(int statki=5-maszty;statki>=1;statki--)
                {
                    if (czyPionowy())
                    {
                        do
                        {
                            flaga = false;
                            x = rand.Next(10);
                            y = rand.Next(7);
                            for (int i = y; i < y + maszty; i++)
                            {
                                if (plansza[i,x] != 0) 
                                    flaga = true;
                            }
                        } while (flaga);
                        for (int i = y; i < y + maszty; i++)
                            plansza[i,x] = maszty;
                        obramowanie(x, y, maszty, true);
                    }
                    else
                    {
                        do
                        {
                            flaga = false;
                            x = rand.Next(7);
                            y = rand.Next(10);
                            for (int i = x; i < x + maszty; i++)
                            {
                                if (plansza[y,i] != 0) 
                                    flaga = true;
                            }
                        } while (flaga);
                        for (int i = x; i < x + maszty; i++)
                            plansza[y,i] = maszty;
                        obramowanie(x, y, maszty, false);
                    }
                }
            }
            //usuwanie kropek ala obramowan
            //zakomentowac kod = debug mode on
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (plansza[j, i] == 5)
                        plansza[j, i] = 0;
        }


        private bool czyPionowy()
        {
            if (rand.Next(1000) % 2 == 0)
                return true;
            else
                return false;
        }

        public void obramowanie(int x, int y, int maszty, bool pion)
        {
            for (int i = 0; i < maszty; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    for (int k = 1; k > -2; k--)
                    {
                        if ((y + k) >= 0 && (y + k) <= 9 && (x + j) >= 0 && (x + j) <= 9)
                        {
                            if (plansza[y + k,x + j] == 0)
                                plansza[y + k,x + j] = 5;
                        }
                    }
                }
                if (pion)
                    y++;
                if (!pion)
                    x++;
            }  
        }
    }
}
