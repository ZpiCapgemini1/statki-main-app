using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
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

        public int czytaj(int x,int y)
        {
            return plansza[y, x];
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

        public void strzal()
        {

        }

        private bool czyPionowy()
        {
            if (rand.Next(1000) % 2 == 0)
                return true;
            else
                return false;
        }

        private void obramowanie(int x, int y, int maszty, bool pion)
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
