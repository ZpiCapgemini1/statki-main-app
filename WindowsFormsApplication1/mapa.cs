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

        public bool Zatopiony(int x,int y)
        {
            int licznik = 1;
            int pion = 2;
            int y_poczatkowe = y;
            int x_poczatkowe = x;

            if (plansza[y, x] == 1)             //jeśli to jedynka to
            {                                   //instant zatapiamy
                obramowanie(x, y, 1, true);
                return true;
            }

            else
            {
                if(y>0 && y<9)
                {
                    if (plansza[y, x] == plansza[y + 1, x] || plansza[y, x] == plansza[y - 1, x])
                        pion = 1;
                }
                else if(y == 0)          
                {
                    if (plansza[y, x] == plansza[y + 1, x])
                        pion = 1;
                }
                else if(y == 9)
                {
                    if (plansza[y, x] == plansza[y - 1, x])
                        pion = 1;
                }

                if(pion==2)     //jeśli juz wcześniej wyszło że statek pionowy to nie sprawdzamy czy poziomy
                {
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

                if(pion==2)         //wszystkie poprzednie warunki nie zostaly
                {                   //spelnione, wartosc pionu bez zmian
                    return false;   //statek nie jest zatopiony
                }
              
                else if(pion == 1)
                {

                    if(y==0)
                    {
                        
                        while(plansza[y, x] == plansza[y + 1, x])
                        {
                            licznik++;
                            y++;
                            if (y == 9)
                                break;
                        }
                        if (licznik == plansza[x, y])
                        {
                            obramowanie(x, y_poczatkowe, licznik, true);
                            return true;
                        }
                        else
                            return false;      
                    }

                    else if (y == 9)
                    {

                        while (plansza[y, x] == plansza[y - 1, x])
                        {
                            licznik++;
                            y--;
                            if (y == 0)
                                break;
                        }
                        if (licznik == plansza[x, y])
                        {
                            obramowanie(x, y, licznik, true);
                            return true;
                        }
                        else
                            return false;
                    }

                    else
                    {
                        //////////////
                    }
                }

                else if(pion == 0)
                {

                    if (x == 0)
                    {

                        while (plansza[y, x] == plansza[y, x + 1])
                        {
                            licznik++;
                            x++;
                            if (x == 9)
                                break;
                        }
                        if (licznik == plansza[x, y])
                        {
                            obramowanie(x_poczatkowe, y, licznik, false);
                            return true;
                        }
                        else
                            return false;
                    }

                    else if (x == 9)
                    {

                        while (plansza[y, x] == plansza[y, x - 1])
                        {
                            licznik++;
                            x--;
                            if (x == 0)
                                break;
                        }
                        if (licznik == plansza[x, y])
                        {
                            obramowanie(x, y, licznik, false);
                            return true;
                        }
                        else
                            return false;
                    }

                    else
                    {
                        /////////////////////
                    }

                }
                return true;
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
