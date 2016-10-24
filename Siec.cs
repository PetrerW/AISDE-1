using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication8
{
   public class Siec
    {

        protected int liczbaWezlow;
        protected int liczbaLaczy;
        string algorytm;
        List<Wezel> wezly=new List<Wezel>();
        List<Lacze> krawedzie = new List<Lacze>();
        List<Sciezka> sciezki = new List<Sciezka>();
        string plik;

public int algorytmPrima()
        {
            //Bedziemy szukac najtanszych krawedzi, ktore spelniaja zalozenia algorytmu Prima, czyli: jeden wierzcholek krawedzi nalezy do drzewa, a drugi nie.
            //
            //Najtansza krawedź jest pierwsza bo Lista będzie posortowana      

           //~Piotrek
            krawedzie[0].Wezel1.Odwiedzony = true;
            krawedzie[0].Wezel2.Odwiedzony = true;

            //Dwa konce lacza o najtanszej wadze oznaczamy jako odwiedzone
            //wezly[krawedzie[0].wezel1-1].Odwiedzony = true;
            //wezly[krawedzie[0].wezel2-1].Odwiedzony = true;

//Sa to dwa konce najtanszej krawedzi
            int liczbaOdwiedzonychWezlow = 2;
            int najlepszeLacze=0;
            int koniec = 0;
            int k = 1;

            
            /*krawedzie[1].Waga = 7;
            krawedzie[2].Waga = 1;
            krawedzie[3].Waga = 3;
            krawedzie[4].Waga = 5;
            krawedzie[5].Waga = 3;
            krawedzie[6].Waga = 2;
            krawedzie[7].Waga = 7;
            krawedzie[8].Waga = 3;
            krawedzie[9].Waga = 5;*/

            

            do
            {
                //za kazdym razem szukam najlepszego wierzcholka ktory pasuje do warunkow algorytmu 
                do
                {

                    //Jeden z wierzcholkow musi byc nalezec do drzewa drugi-nie. Sprawdzam czy ten warunek zachodzi. 
                    //Odwoluje sie do wlasnosci klasy Wezel "Odwiedzony". Numer indeksu pomniejszony o 1 gdyz ID zaczyna sie od 1 a indeksowanie od 0
                    //Pierwsze poloczenie ktore spelnia warunki algorytmu zapisuje jako najlepsze po przez zapisanie indeksu do tego poloczenia.
                    
                    /*if ((wezly[krawedzie[k].wezel1 - 1].Odwiedzony == true && wezly[krawedzie[k].wezel2 - 1].Odwiedzony == false) || (wezly[krawedzie[k].wezel1 - 1].Odwiedzony == false && wezly[krawedzie[k].wezel2 - 1].Odwiedzony == true))
                    {
                        najlepszeLacze = k;

                        koniec = 1;

                    }
                    k++; */

                    //'^' to XOR - albo jedno, albo drugie prawdziwe. https://pl.wikipedia.org/wiki/Alternatywa_wykluczaj%C4%85ca

                    if (krawedzie[k].Wezel1.Odwiedzony == true ^ krawedzie[k].Wezel2.Odwiedzony == true)
                    {
                        najlepszeLacze = k;
                        koniec = 1;
                    }
                    k++;

                } while (koniec == 0);

                for (int i=1; i<liczbaLaczy; i++)
                {

                    //jeden z wierzcholkow musi nalezec do drzewa drugi-nie
                    //Przeszukuje liste krawedzi w poszukiwaniu takich, ktore spelniaja warunki i maja mniejsza wage niz dotychczas najlepsze lacze
                    //if ((wezly[krawedzie[i].wezel1 - 1].Odwiedzony==true && wezly[krawedzie[i].wezel2 - 1].Odwiedzony == false) || (wezly[krawedzie[i].wezel1 - 1].Odwiedzony == false && wezly[krawedzie[i].wezel1 - 1].Odwiedzony == true))
                    if (krawedzie[i].Wezel1.Odwiedzony == true ^ krawedzie[i].Wezel2.Odwiedzony == true)
                    {
                        if (krawedzie[i].Waga < krawedzie[najlepszeLacze].Waga)
                        {
                            najlepszeLacze = i;
                        }
                    }
                     
                }
                //Wezly nalezace do krawedzi oznaczam jako odwiedzone
                krawedzie[najlepszeLacze].Wezel1.Odwiedzony = true;
                krawedzie[najlepszeLacze].Wezel1.Odwiedzony = true;
                /*
                wezly[krawedzie[najlepszeLacze].wezel1-1].Odwiedzony = true;
                wezly[krawedzie[najlepszeLacze].wezel2-1].Odwiedzony = true;
                */
                Console.WriteLine(krawedzie[najlepszeLacze].idKrawedzi);

                liczbaOdwiedzonychWezlow++;


//no wiadomo krazy do czasu az wszystkie wierzcholki beda nalezaly do drzewa 
            }
            while (liczbaOdwiedzonychWezlow != liczbaWezlow);




            return 0;
        }

 public int algorytmDijkstry()
        {
            return 0;
        }

public int algorytmFloyda()
        {
            return 0;
        }

        //Odczytuje plik z miejsca wskazanego przez uzytkownika
        public void wczytaj_dane(string plik)
        {


            //Zapisuje do tablicy caly plik.
            //Jeden wiersz to jedna komorka tablicy.
            //~Piotrek      - uzywam petli foreach i dodaje w niej warunek zignorowania wszystkich linii,
            //~Piotrek      ktore zaczynaja sie od "#"

            List<string> dane_z_pliku = new List<string>();

            foreach (var linia in File.ReadAllLines(plik))
            {
                if (linia.StartsWith("#"))
                    continue; //Pomijamy linie zaczynające się od "#"
                else
                    dane_z_pliku.Add(linia);
            }
            //~Piotrek          Konwersja do postaci tablicowej
            string[] dane = dane_z_pliku.ToArray();
            
            //~Piotrek      LICZBA WEZLOW
            //To co sie tu dzieje pozwala na podzial i zapis fragmentow tekstu ktory jest oddzielony spacja
                string[] liczbyDane = dane[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //wedlug wzorcowego pliku w pierwszej lini trzecim elementem bedzie liczba wezlow, ktore nalezy zapisac.
                liczbaWezlow = Int32.Parse(liczbyDane[2]);

            for (int i = 0; i < liczbaWezlow; i++)
            {

                try
                {
                    //Ponownie uzywam funkcji do wyluskania danych bedacych w jednym wierszu
                    //Do zmiennej "liczbyDane" zapisuje id wezla oraz jego wspolrzedne, ktore sa oddzielone spacja
                    liczbyDane = dane[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //Tworze kolejne obiekty klasy Wezel i za pomoca wlasnosci zapisuje dane z pliku.
                    wezly.Add(new Wezel() { idWezla = Int32.Parse(liczbyDane[0]), wspX = Int32.Parse(liczbyDane[1]), wspY = Int32.Parse(liczbyDane[2]) });
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem przy wczytywaniu danych (wezly)");
                }
            }

                //~Piotrek      LICZBA LACZY
                liczbyDane = dane[liczbaWezlow+1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                liczbaLaczy = Int32.Parse(liczbyDane[2]);

            for (int j = 0; j < liczbaLaczy; j++)
                {

                    try
                    {
                    //Analogicznie jak wezly jednak do indeksowania uzywam wiadomosci o liczbie wersow ktore byly wyzej, aby zapisywac kolejne dane

                        liczbyDane = dane[(liczbaWezlow+2+j)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //~Daniel       krawedzie.Add(new Lacze( Int32.Parse(liczbyDane[0]), Int32.Parse(liczbyDane[1]), Int32.Parse(liczbyDane[2]) ));
                    //~Piortek      - Dodaje juz teraz do danej krawedzi Wezly, korzystajac z tego, ze sa one w pliku wejsciowym podawane po kolei, wiec
                    //~Piotrek        ich numery indeksu w liscie 'wezly' sa rowne ich numerkowi na pliku wejsciowym minus 1 (zaczynamy od 0)
                    //~Piotrek      - Dzieki temu unikam wielokrotnych petli for! #profit

                    krawedzie.Add(new Lacze(Int32.Parse(liczbyDane[0]), 
                            wezly[Int32.Parse(liczbyDane[1])-1], wezly[Int32.Parse(liczbyDane[2]) - 1]));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Problem przy wczytywaniu danych (krawedzie)");
                    }
                }
            //Kolejny dziwny indeks w nastepnej lini, ale takze wynika z ilosci danych wczesniej zapisanych
            Console.WriteLine(krawedzie[0].idKrawedzi);

            string[] infoDane = dane[liczbaLaczy+liczbaWezlow+2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            algorytm = infoDane[2];

            //Informacja o tym jaki algorytm nalezy uruchomic.
            if(algorytm=="MST")
            {
                 algorytmPrima();
                //To co jest dalej nie ma glebszego sensu bo jeszcze nie mamy kolejnych algorytmow 
            }
            else if(algorytm=="SCIEZKA")
            {
                liczbyDane = dane[(dane.Length-1)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sciezki.Add(new Sciezka() { wezel1 = Int32.Parse(liczbyDane[0]), wezel2 = Int32.Parse(liczbyDane[1]) });
                algorytmDijkstry();
            }
            else
            {
                int obecneMiejsce = liczbaWezlow + liczbaLaczy + 3;
                for (; obecneMiejsce < dane.Length; obecneMiejsce++)
                {
                    liczbyDane = dane[obecneMiejsce].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    sciezki.Add(new Sciezka() { wezel1 = Int32.Parse(liczbyDane[0]), wezel2 = Int32.Parse(liczbyDane[1]) });
                }
                algorytmFloyda();
            }

        }
           
        }
    }

