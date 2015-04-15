////////////////////////////////////
// Spaghetti code at it finest... //
// Dawid Bieniek		  //
// Cpp				  //
////////////////////////////////////

#include <iostream>
#include <cstdlib>
#include <ctime>
#include <conio.h>
#include <windows.h>
#include <boost/random/mersenne_twister.hpp>
#include <boost/random/uniform_int_distribution.hpp>

using namespace std;
boost::random::mt19937 generator(time(0));

int strzal(int**,int*,bool);
void rysowanie(int**);
void ustawianie(int**);
void obramowanie(int,int,int,int**,bool,bool);
bool pionowy();
int los(int);

int main()
{
    int **strzaly = new int *[10];
    int **statki = new int *[10];
    int *ostatni = new int [4];
  	int licznik = 0;
	  int maszty = 0;
    bool gonimy = false;
    int x,y;
    
    for(int i=0;i<10;i++)
    {
     strzaly[i] = new int [10];
     statki[i] = new int [10];
    }
    
    
	for(int i=0;i<10;i++)   //inicjacja tablicy
	{
	 for(int j=0;j<10;j++)
	 {
		strzaly[i][j]=0; // 0 = woda/brak strzalu, 1,2,3,4 = statek, 5 = woda "wokol" statku,
		statki[i][j]=0; // 6 = strzal woda, 7 = trafiony;
	 }
	}
	ustawianie(statki); // funkcja ustawiajaca statki na pozycjach
	cout<<"po ustawianie";
   
	do{
	//system("CLS");
	strzal(strzaly,ostatni,gonimy);
	x=ostatni[0];
	y=ostatni[1];
	cout<<"Strzal na x: "<<y+1<<" y: "<<x+1<<endl;
   
	if(statki[x][y]==0 || statki[x][y]==5) 
	{
		cout<<"WODA!"<<endl;
		strzaly[x][y]=6; 
	} 
    
	if(statki[x][y]>=1 && statki[x][y]<=4 )
	{
		if(!gonimy)
		{
			ostatni[2]=x;
			ostatni[3]=y;
		}
		gonimy=true;
		cout<<"TRAFIONY!"<<endl;
		strzaly[x][y]=7;
		licznik++;
		maszty++;
		cout<<"Licznik: "<<licznik<<" Maszty: "<<maszty<<" Kontrol: "<<statki[x][y]<<endl;
		if(maszty == statki[x][y])
		{
			cout<<"ZATOPIONY! "<<maszty<<" masztowiec"<<endl;
			
			if(statki[x][y] == 1)
			 obramowanie(y,x,maszty,strzaly,true,true);
			 
			if(statki[x][y] != 1)
			{
				if(x==0)		//lewa krawędź
				{
					cout<<"lewa krawedz"<<endl;
					if(statki[x+1][y]==statki[x][y])
					 obramowanie(y,x,maszty,strzaly,false,true);
					
					else if(y==0)
					 obramowanie(y,x,maszty,strzaly,false,true);
					 
					else if(y!=0)
					{
						int i=0;
						bool flaga=true;
						do
						{
							i++;
							
							if(y-i==0)
							 flaga=false;
							 
							if(statki[x][y]!=statki[x][y-i])
							{
								flaga=false;
								i--;
							}
							
						}while(flaga);
						obramowanie(y-i,x,maszty,strzaly,false,true);
					} 
				}
				
				else if(y==0)	//górna krawędź
				{
					cout<<"gorna krawedz"<<endl;
					if(statki[x][y+1]==statki[x][y])
					 obramowanie(y,x,maszty,strzaly,true,true);
					
					else if(x==0)
					 obramowanie(y,x,maszty,strzaly,true,true);
					 
					else if(x!=0)
					{
						int i=0;
						bool flaga=true;
						do
						{
							i++;
							
							if(x-i==0)
							 flaga=false;
							 
							if(statki[x][y]!=statki[x-i][y])
							{
								flaga=false;
								i--;
							}
							
						}while(flaga);
						obramowanie(y,x-i,maszty,strzaly,true,true);
					}
				}
				
				else		//srodek pola
				{
					cout<<"insajd dzob mejt"<<endl;
					if(strzaly[x-1][y]==strzaly[x][y] || strzaly[x+1][y]==strzaly[x][y])	//statek pionowo?
					{
						cout<<"PION!"<<endl;
						//cout<<"strzaly [x-1][y]= "<<strzaly[x-1][y]<<" strzaly [x][y]= "<<strzaly[x][y]<<" strzaly [x+1][y]= "<<strzaly[x+1][y]<<endl;
						int i=0;
						bool flaga=true;
						do
						{
							i++;
							
							if(x-i==0)
							 flaga=false;
							 
							if(strzaly[x][y]!=strzaly[x-i][y])
							{
								flaga=false;
								i--;
							}
							
						}while(flaga);
						cout<<"obramowanie: "<<y<<" "<<x<<" i: "<<i;
						obramowanie(y,x-i,maszty,strzaly,true,true);
					}
					
					else if(strzaly[x][y-1]==strzaly[x][y] || strzaly[x][y+1]==strzaly[x][y])	//statek poziomo?
					{
						cout<<"POZIOM!"<<endl;
						//cout<<"strzaly [x][y-1]= "<<strzaly[x][y-1]<<" strzaly [x][y]= "<<strzaly[x][y]<<" strzaly [x][y+1]= "<<strzaly[x][y+1]<<endl;
						int i=0;
						bool flaga=true;
						do
						{
							i++;
							
							if(y-i==0)
							 flaga=false;
							 
							if(strzaly[x][y]!=strzaly[x][y-i])
							{
								flaga=false;
								i--;
							}
							
						}while(flaga);
						cout<<"obramowanie: "<<y<<" "<<x<<" i: "<<i;
						obramowanie(y-i,x,maszty,strzaly,false,true);
					}
				}	
			}
			
			maszty=0;
			gonimy=false;
		}
		
	}
	rysowanie(statki);
	rysowanie(strzaly);
	getch();
	}while(licznik<20);
   
	system("PAUSE");
}


int strzal(int **strzaly,int *ostatni,bool gonimy)
{
	bool flaga=false;
	int x,y;
	int xbaz,ybaz;
	
	if(!gonimy)
	{
		do
		{
		flaga=true;
		x=los(10);
	    y=los(10);
	     if(strzaly[x][y]==0)
		 flaga=false;      
	 	}while(flaga);
 	}
 	
 	if(gonimy)
 	{
 		x=ostatni[0];
 		y=ostatni[1];
 		xbaz=ostatni[2];
 		ybaz=ostatni[3];
 		cout<<"gonimy";
		if(strzaly[x][y]==6)
 		{
 			x=xbaz;
 			y=ybaz;
 			cout<<"costam"<<endl;
		}
		
 		if(strzaly[x][y]==7)
 		{
 			cout<<"\n Ustawiamy flagi: x="<<x<<" y="<<y<<endl;
 			bool gora,dol,lewo,prawo; //czy nie wychodzimy za tablice
 			bool pierwszy=true;
 			//ustawiamy flagi gdzie mozemy "strzelac" zeby nie wyjsc za tablice
 			if(y==0 && x==0)
 			{	gora=false; dol=true; lewo=false; prawo=true;	}
			
			else if(y==9 && x==0)
 			{	gora=false; dol=true; lewo=true; prawo=false;	}
			
			else if(y==0 && x==9)
 			{	gora=true; dol=false; lewo=false; prawo=true;	}
			
			else if(y==9 && x==9)
 			{	gora=true; dol=false; lewo=true; prawo=false;	}
 		
		 	else if(y==0 && x!=0 && x!=9)
 			{	gora=true; dol=true; lewo=false; prawo=true;	}
			
			else if(y==9 && x!=0 && x!=9)
 			{	gora=true; dol=true; lewo=true; prawo=false;	}
			
			else if(y!=0 && y!=9 && x==0)
 			{	gora=false; dol=true; lewo=true; prawo=true;	}
			
			else if(y!=0 && y!=9 && x==9)
 			{	gora=true; dol=false; lewo=true; prawo=true;	}
 			
 			else
 			{	gora=true; dol=true; lewo=true; prawo=true;	}
 			//koniec ustawiania flag
 			cout<<"Gora:"<<gora<<" Dol:"<<dol<<" Lewo:"<<lewo<<" prawo:"<<prawo<<endl;
 			
 			if(gora)
	 			if(strzaly[x-1][y]==7)
	 			{	x++; pierwszy=false;	}
 			
 			if(dol)
			 	if(strzaly[x+1][y]==7)
				{	x--; pierwszy=false;	}
 			
 			if(lewo)
 				if(strzaly[x][y+1]==7)
 				{	y--; pierwszy=false;	}
 		
		 	if(prawo)
			 	if(strzaly[x][y-1]==7)
 				{	y++; pierwszy=false;	}	
			 
			 
 			if(pierwszy)
 			{
 				cout<<"jestesmy w else i los"<<endl;
 				int l;
 				bool flaga=true;
 				do
 				{
	 				l=los(1000)%4;
	 				if(l==0)
	 				{
	 					if(dol)
	 					if(strzaly[x+1][y]==0)
	 					{ x++; flaga=false;}
					}
					
					if(l==1)
					{
						if(gora)
						if(strzaly[x-1][y]==0)
						{ x--; flaga=false;}
					}
					
					if(l==2)
					{
						if(prawo)
						if(strzaly[x][y+1]==0)
						{ y++; flaga=false;}
					}
					
					if(l==3)
					{
						if(lewo)
						if(strzaly[x][y-1]==0)
						{ y--; flaga=false;}
					}
 				}while(flaga);
			}
			
		}
		
		
	}
	
 	//cout<<"Strzal na x: "<<ostatni[0]<<" y: "<<ostatni[1];
 	ostatni[0]=x;
 	ostatni[1]=y;
 	return *ostatni;
}


void rysowanie(int **tab)
{
     //system("CLS");
     cout<<"\n    A  B  C  D  E  F  G  H  I  J\n";
     for(int i=0;i<10;i++)
     {
     cout<<i+1<<" ";
     if(i<9) cout<<" ";
      for(int j=0;j<10;j++)
      {
       cout<<"[";
       if(tab[i][j]==0) cout<<" ";
       else if(tab[i][j]==5) cout<<" ";
       else if(tab[i][j]==6) cout<<"*";
       else if(tab[i][j]==7) cout<<"X";
       else cout<<tab[i][j];
       cout<<"]";
      }
      cout<<"\n";
     }
     cout<<"\n";
}

void ustawianie(int **tab)
{
   int x,y;
   bool flaga;
   
   for(int n=4;n>=1;n--)  // glowna petla - maszty statkow
   {
    for(int j=5-n;j>=1;j--)
    {
     
        if(pionowy())
        {
         do
         {
          flaga=false;
          x=los(10);
          y=los(7);
          //cout<<" pion x = "<<x<<" y = "<<y<<" ";
           for(int i=y;i<y+n;i++)
           {
            if(tab[i][x]!=0) flaga=true;
           }
         }while(flaga);
         for(int i=y;i<y+n;i++)
         tab[i][x]=n;
         obramowanie(x,y,n,tab,true,false);
        }  
        else  
        {
         do
         {
          flaga=false;
          x=los(7);
          y=los(10);
          //cout<<" poziom x = "<<x<<" y = "<<y<<" ";
           for(int i=x;i<x+n;i++)
           {
            if(tab[y][i]!=0) flaga=true;
           }
         }while(flaga);
         for(int i=x;i<x+n;i++)
         tab[y][i]=n; 
         obramowanie(x,y,n,tab,false,false);  
        }
     //rysowanie(tab); //testowe rysowanie
     //getch();        //po kazdymstatku getch
    }
   } 
}

void obramowanie(int x,int y,int n,int **tab,bool pion,bool strzaly)
{
	if(strzaly)
	cout<<"Zatapiam x: "<<x+1<<" y: "<<y+1<<" maszty: "<<n<<" pion: "<<pion<<endl;
	
   for(int i=0;i<n;i++)
   {
   //cout<<" i wynosi: "<<i<<" x wynosi: "<<x<<" y wynosi: "<<y;
        for(int j=-1;j<2;j++)
        {
         for(int k=1;k>-2;k--)
         {
         //cout<<"\n\nczo tu sie dzieje";
          if( (y+k)>=0 && (y+k)<=9 && (x+j)>= 0 &&(x+j) <=9)
          {
           if(tab[y+k][x+j]==0)
		   {
		   	if(strzaly)
		    tab[y+k][x+j]=6;
		    if(!strzaly)
		    tab[y+k][x+j]=5;
           }
       	  }
         }
        } 
        if(pion)
        y++;
        else
        x++; 
   //cout<<"\npo ifach";
   }  
}

bool pionowy()
{
  if((rand())%2==0){return true;}
  else{return false;}  
}

int los(int n)
{
 boost::random::uniform_int_distribution<> dist(0, n-1);
 return dist(generator);
}
