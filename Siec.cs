﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISDE
{
   public class Siec
    {

        protected int liczbaWezlow;
        protected int liczbaLaczy;
        string algorytm;
        List<Wezel> wezly=new List<Wezel>();
        List<Lacze> krawedzie = new List<Lacze>();
        List<Sciezka> sciezki = new List<Sciezka>();
        List<int> tablicaMST = new List<int>();
        int temp;
        string plik;
        bool brakPowodzenia = false;

        public List<Lacze> zwroc_lacza
            {
            get      { return krawedzie; }
            set { krawedzie = value; }
        }
        public List<int> zwroc_tablicaMST
        {
            get { return tablicaMST; }
        }

        public string Algorytm
        {
            get { return algorytm; }
            
        }

        public bool fail
        {
            get { return brakPowodzenia; }
        }

        public void ustawWagiLaczy()
        {
            krawedzie[0].Waga = 9;
            krawedzie[1].Waga = 8;
            krawedzie[2].Waga = 2;
            krawedzie[3].Waga = 2;
            krawedzie[4].Waga = 1;
            krawedzie[5].Waga = 10;
            krawedzie[6].Waga = 2;
            krawedzie[7].Waga = 3;
            krawedzie[8].Waga = 10;
            krawedzie[9].Waga = 5;

        }


        public int algorytmPrima()
        {
            //Bedziemy szukac najtanszych krawedzi, ktore spelniaja zalozenia algorytmu Prima, czyli: jeden wierzcholek krawedzi nalezy do drzewa, a drugi nie.
            //
            //Najtansza krawedź jest pierwsza bo Lista będzie posortowana 
            try {
                krawedzie[0].Waga = 10;
                krawedzie[1].Waga = 7;
                krawedzie[2].Waga = 6;
                krawedzie[3].Waga = 3;
                krawedzie[4].Waga = 5;
                krawedzie[5].Waga = 3;
                krawedzie[6].Waga = 2;
                krawedzie[7].Waga = 7;
                krawedzie[8].Waga = 3;
                krawedzie[9].Waga = 5;
                krawedzie.Sort((x, y) => x.Waga.CompareTo(y.Waga));


                //Dwa konce lacza o najtanszej wadze oznaczamy jako odwiedzone
                krawedzie[0].Wezel1.Odwiedzony = true;
                krawedzie[0].Wezel2.Odwiedzony = true;
                tablicaMST.Add(krawedzie[0].idKrawedzi);

                //Sa to dwa konce najtanszej krawedzi
                int liczbaOdwiedzonychWezlow = 2;
                int najlepszeLacze = 0;
                int wykorzystaneKrawedzie = 1;
                int koniec = 0;

                Lacze pomocnicze = new Lacze(0, 0, 0);





                do
                {

                    //Petla do-While nie bedzie sprawdzala wykorzystanych juz krawedzi.
                    int k = wykorzystaneKrawedzie;
                    //za kazdym razem szukam najlepszego wierzcholka ktory pasuje do warunkow algorytmu 
                    do
                    {

                        //Jeden z wierzcholkow musi byc nalezec do drzewa drugi-nie. Sprawdzam czy ten warunek zachodzi. 
                        //Odwoluje sie do wlasnosci klasy Wezel "Odwiedzony". Numer indeksu pomniejszony o 1 gdyz ID zaczyna sie od 1 a indeksowanie od 0
                        //Pierwsze poloczenie ktore spelnia warunki algorytmu zapisuje jako najlepsze po przez zapisanie indeksu do tego poloczenia.
                        if (krawedzie[k].Wezel1.Odwiedzony == true ^ krawedzie[k].Wezel2.Odwiedzony == true)
                        {
                            najlepszeLacze = k;
                            koniec = 1;
                        }
                        k++;

                    } while (koniec == 0);
                    //Petla nie sprawdza juz wykorzystanych Krawedzi
                    for (int i = wykorzystaneKrawedzie; i < liczbaLaczy; i++)
                    {

                        //jeden z wierzcholkow musi byc nalezec do drzewa drugi-nie
                        //Przeszukuje liste krawedzi w poszukiwaniu takich, ktore spelniaja warunki i maja mniejsza wage niz dotychczas najlepsze lacze
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
                    krawedzie[najlepszeLacze].Wezel2.Odwiedzony = true;


                    tablicaMST.Add(krawedzie[najlepszeLacze].idKrawedzi);

                    //Tu jest to usprawnienie
                    //Po sprawdzeniu krawedzi przesuwam ja na miejsce zalezace od ilosci sprawdzonych krawedzi
                    //Gdy kolejny raz wchodzi do petli for to nie sprawdza juz tej krawedzi, mniej razy chodzi petla.   
                    if (najlepszeLacze != wykorzystaneKrawedzie)
                    {
                        pomocnicze = krawedzie[najlepszeLacze];
                        krawedzie.RemoveAt(najlepszeLacze);
                        krawedzie.Insert(wykorzystaneKrawedzie, pomocnicze);

                    }
                    wykorzystaneKrawedzie++;
                    liczbaOdwiedzonychWezlow++;


                    //no wiadomo krazy do czasu az wszystkie wierzcholki beda nalezaly do drzewa 
                }
                while (liczbaOdwiedzonychWezlow != liczbaWezlow);


            }
            catch(Exception)
            {
                brakPowodzenia = true;
            }

            return 0;
        }

 public int algorytmDijkstry()
        {
            int liczbaOdwiedzonychWezlow = 0;
            int INF = int.MaxValue;
            int najtanszyWezel = 0;
            int koniec=0;
            int k=0;
            Wezel pomocniczy = new Wezel();
            krawedzie[0].Waga = 20;
            krawedzie[1].Waga = 7;
            krawedzie[2].Waga = 2;
            krawedzie[3].Waga = 3;
            krawedzie[4].Waga = 6;
            krawedzie[5].Waga = 4;
            krawedzie[6].Waga = 10;
            krawedzie[7].Waga = 7;
            krawedzie[8].Waga = 3;
            krawedzie[9].Waga = 5;
           // krawedzie.Sort((x, y) => x.Waga.CompareTo(y.Waga));
            /*
            Dla potrzeb algorytmu dodalem w kasie Wezel trzy 2 nowe zmienne i liste przechowujaca indeksy krawedzi, ktore sa doprowadzone do konkretnego Wezla.
            Dwie zmienne to : etykieta, czyli najtanszy koszt dotarcia do wierzcholka oraz zmienna dzieki ktorej wiem przez ktory wierzcholek nalezy do tego punktu isc.

            Pierwszy wierzcholek sciezki ma etykiete 0 a pozostale na nieskonczonosc, ktora zdefiniowalem jako 1000.
            */
            for (int i=0; i<liczbaWezlow; i++)
            {
                wezly[i].Etykieta = INF;
            }
            sciezki[0].Wezel1.Etykieta = 0;

            do
            {
                //wybieram pierwszy dowolny wezel, ktory posluzy mi jako odnosnik do wyszukiwania najkorzystniejszego wezla.
                do
                {

                    if (wezly[k].Odwiedzony == false)
                    {
                        najtanszyWezel = k;
                        koniec = 1;
                    }
                    k++;

                } while (koniec == 0);

                //Poszukiwanie najtanszego
                for(int i=liczbaOdwiedzonychWezlow; i<liczbaWezlow; i++)
                {
                    if (wezly[i].Odwiedzony == false)
                    {
                        if (wezly[i].Etykieta < wezly[najtanszyWezel].Etykieta)
                        {
                            najtanszyWezel = i;
                        }
                    }
                }
                //Tu wykorzystuje liste ktora stworzylem w klasie wezel po to, aby nie szukac wsrod wszystkich krawedzi. Wiem z gory ktore krawedzie musze przegladnac.
                //Wiem jakich mam sasiadow
                foreach (Lacze krawedz in wezly[najtanszyWezel].listaKrawedzi  )
                {
                    //Jezeli wybrany jest najtanszy wezel to sprawdzam, ktory jest to wezel w krawedzi. WezelPierwszy, czy WezelDrugi
                    if(wezly[najtanszyWezel].idWezla==krawedz.Wezel1.idWezla)
                    {
                        //Jezeli ten sasiad byl juz przegladany to nie bedzie dla niego lepszego polonczenia, jest "skreslony"
                        if(krawedz.Wezel2.Odwiedzony==false)
                        {
                            if (krawedz.Wezel2.Etykieta > (krawedz.Waga + krawedz.Wezel1.Etykieta))
                            {
                                krawedz.Wezel2.Etykieta = krawedz.Waga + krawedz.Wezel1.Etykieta;
                                //Jezeli to polonczenie okazuje sie byc najkorzystniejsze to zmieniam Wezel przez ktory droga jest najtansza
                                krawedz.Wezel2.NajlepiejPrzez = wezly[najtanszyWezel];
                               // temp = krawedz.idKrawedzi;
                            }
                        }
                    }
                    else
                    {
                        if (krawedz.Wezel1.Odwiedzony == false)
                        {
                            if (krawedz.Wezel1.Etykieta > (krawedz.Waga + krawedz.Wezel2.Etykieta))
                            {
                                krawedz.Wezel1.Etykieta = krawedz.Waga + krawedz.Wezel2.Etykieta;
                                krawedz.Wezel1.NajlepiejPrzez = wezly[najtanszyWezel];
                               // temp = krawedz.idKrawedzi;
                            }
                        }
                    }

                }

                wezly[najtanszyWezel].Odwiedzony = true;
                //tablicaMST.Add(temp);
               
                // Przejmuje referencje do obiektu, usuwam najkorzystniejszy wezel z jego miejsca w liscie i umieszczam na miejscach, gdzie nie bede juz sprawdzal
                //Pętle for beze zaczynal dla i= liczbieOdwiedzonychWezlow czyli petla ich już nie obejmuje, czyli petla krazy mniejszą ilosc razy.
                if (najtanszyWezel != liczbaOdwiedzonychWezlow)
                {
                    pomocniczy = wezly[najtanszyWezel];
                    //usuwanie z listy
                    wezly.RemoveAt(najtanszyWezel);
                    //dodawanie do listy na miejscu wskazanym 
                    wezly.Insert(liczbaOdwiedzonychWezlow, pomocniczy);

                }

                liczbaOdwiedzonychWezlow++;



            } while (liczbaOdwiedzonychWezlow != (liczbaWezlow-1));

            //Tutaj sprawdzalem czy wypisuje jak trzeba sciezke

            Console.WriteLine(sciezki[0].Wezel2.idWezla);
            Wezel zmienna1 = sciezki[0].Wezel2;
            Wezel zmienna = sciezki[0].Wezel2.NajlepiejPrzez;
       
            Console.WriteLine(zmienna.idWezla);
            do
            {
for(int i=0; i<liczbaLaczy ;i++ )
                {
if ((krawedzie[i].Wezel1.idWezla == zmienna1.idWezla && krawedzie[i].Wezel2.idWezla == zmienna.idWezla) || (krawedzie[i].Wezel2.idWezla == zmienna1.idWezla && krawedzie[i].Wezel1.idWezla == zmienna.idWezla))
                    {
                        tablicaMST.Add(krawedzie[i].idKrawedzi);
                    }
                    
                            
                 }
                zmienna1 = zmienna;
                zmienna = zmienna.NajlepiejPrzez;

            } while (zmienna1!=sciezki[0].Wezel1);
            //Lacze result = krawedzie.Find(x => x.Wezel1.idWezla == sciezki[0].Wezel2.idWezla , x => x.Wezel2.idWezla == zmienna.idWezla);
           /* while (zmienna.NajlepiejPrzez != sciezki[0].Wezel1) 
            {

                zmienna = zmienna.NajlepiejPrzez;
                    Console.WriteLine(zmienna.idWezla);             

            }
            Console.WriteLine(sciezki[0].Wezel1.idWezla);*/


            return 0;
        }

        public void algorytmFloyda()
        {
            ustawWagiLaczy();

            float INFINITY = float.MaxValue; //Nieskonoczonosc
            //tablica kosztow - zawiera koszt z wezla o identyfikatorze nr a do wezla nr b
            //Koszt dostania się z a do b to tablicaKosztow[a,b] przechowuje koszt dostania się z węzła a do węzła b
            float[,] tablicaKosztow = new float[liczbaWezlow, liczbaWezlow];
            // tablica kierowania wezlami - zawiera referencje do Wezla, do ktorego nalezy sie udac w drodze z a do b
            Wezel[,] tablicaKierowaniaWezlami = new Wezel[liczbaWezlow, liczbaWezlow];
            // tablica kierowania krawedziami - zawiera indeks krawedzi ktora prowadzi z wzezla a do b, gdzie a i b sa sasiadami
            Lacze[,] tablicaKierowaniaLaczami = new Lacze[liczbaWezlow, liczbaWezlow];
            foreach (Lacze lacze in krawedzie)
            {
                if (tablicaKierowaniaLaczami[lacze.wezel1 - 1, lacze.wezel2 - 1] == null) //Jezeli jeszcze nic nie bylo tutaj, to przypisujemy wartosci
                {
                    tablicaKierowaniaLaczami[lacze.wezel1 - 1, lacze.wezel2 - 1] = lacze; //przypisanie wartosci do tablicy. Odejmuje 1, bo na wejsciu numeracja wezlow zaczyna sie od 1
                    tablicaKierowaniaLaczami[lacze.wezel2 - 1, lacze.wezel1 - 1] = lacze; //Z b do a tez idziemy przez dane lacze

                    tablicaKierowaniaWezlami[lacze.wezel1 - 1, lacze.wezel2 - 1] = lacze.Wezel2; //Idac z wezla1 do wezla2 dostaniemy sie do wezla2
                    tablicaKierowaniaWezlami[lacze.wezel2 - 1, lacze.wezel1 - 1] = lacze.Wezel1; //I vice versa
                }
                else
                {
                    Lacze temp = tablicaKierowaniaLaczami[lacze.wezel1 - 1, lacze.wezel2 - 1];
                    if (temp.Waga > lacze.Waga) //Jesli dotychczasowa waga byla wieksza, podmieniamy. Jesli nie - nic nie robimy.
                    {
                        tablicaKierowaniaLaczami[lacze.wezel1 - 1, lacze.wezel2 - 1] = lacze; //przypisanie wartosci do tablicy. Odejmuje 1, bo na wejsciu numeracja wezlow zaczyna sie od 1
                        tablicaKierowaniaLaczami[lacze.wezel2 - 1, lacze.wezel1 - 1] = lacze; //Z b do a tez idziemy przez dane lacze

                        tablicaKierowaniaWezlami[lacze.wezel1 - 1, lacze.wezel2 - 1] = lacze.Wezel2; //Idac z wezla1 do wezla2 dostaniemy sie do wezla2
                        tablicaKierowaniaWezlami[lacze.wezel2 - 1, lacze.wezel1 - 1] = lacze.Wezel1; //I vice versa
                    }
                }
            }

            //Potrzebujemy niby polowy z tego zakresu, ale nie wiem czy nie bedzie wprowadzonych lacz skierowanych. W tym przypadku trzeba by znowu wykorzystac 
            // [liczbaWezlow, liczbaWezlow]
            // tablicaKierowaniaWezlami[a, b] zwroci Wezel, przez ktory mamy przejsc idac z a do b
            // tablicakierowaniaLaczami[a, b] zwroci Lacze, ktore laczy bezposrednio a i b
            // jesli zawartosc komorki [a,b] to null, to znaczy, ze nie ma bezposredniego lacza z a do b
            // jesli zawartosc tablicaKierowaniaWelzami[a, b] = b, to istnieje bezposrednie polaczenie miedzy nimi
            // W przypadku bezposredniego polaczenia miedzy wezlami,tablica kierowania laczami [a, b] bedzie zawierala krawedz
            // o najmniejszym koszcie

            //Ustawiamy poczatkowe wartosci


            for (int i = 0; i < liczbaWezlow; i++)
                for (int j = 0; j < liczbaWezlow; j++)
                {
                    if (i == j)
                        tablicaKosztow[i, j] = 0; //Koszt dojscia do samego siebie to 0
                    else if (tablicaKierowaniaLaczami[i, j] != null) //Czyli istnieje pojedyncze lacze pomiedzy wezlem i a wezlem j
                        tablicaKosztow[i, j] = tablicaKierowaniaLaczami[i, j].Waga;
                    else
                        tablicaKosztow[i, j] = INFINITY;
                }

            Console.WriteLine("Tablica poczatkowych kosztow:");
            for (int i = 0; i < liczbaWezlow; i++) //Wyswietlanie tablic: kosztow i kierowania wezlami
            {
                Console.WriteLine();
                for (int j = 0; j < liczbaWezlow; j++)
                {
                    Console.Write($"{ tablicaKosztow[i, j]}\t\t");
                }
            }

            for (int k = 0; k < liczbaWezlow; k++) //Tak jak na slajdzie wykladowym
                for (int i = 0; i < liczbaWezlow; i++)
                    for (int j = 0; j < liczbaWezlow; j++)
                        if (tablicaKosztow[i, j] > tablicaKosztow[i, k] + tablicaKosztow[k, j])
                        {
                            tablicaKosztow[i, j] = tablicaKosztow[i, k] + tablicaKosztow[k, j];
                            tablicaKosztow[j, i] = tablicaKosztow[i, k] + tablicaKosztow[k, j];
                            tablicaKierowaniaWezlami[i, j] = wezly[k]; //k-ty Wezel
                            tablicaKierowaniaWezlami[j, i] = wezly[k];
                        }

            tabliceFloyd(ref tablicaKierowaniaLaczami, ref tablicaKierowaniaWezlami, ref tablicaKosztow);
            testFloyd(ref tablicaKierowaniaLaczami, ref tablicaKierowaniaWezlami);
        }
        public void tabliceFloyd(ref Lacze[,] tablicaKierowaniaLaczami, ref Wezel[,] tablicaKierowaniaWezlami, ref float[,] tablicaKosztow)
        {
            Console.WriteLine("\n\nTablica Kierowania Laczami:");
            for (int i = 0; i < liczbaWezlow; i++)
            {
                for (int j = 0; j < liczbaWezlow; j++)
                {
                    if (tablicaKierowaniaLaczami[i, j] == null)
                        Console.Write($"[{i},{j}]: null\t");
                    else
                        Console.Write($"[{i},{j}]: {tablicaKierowaniaLaczami[i, j].idKrawedzi}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Tablica najmniejszych kosztow:");
            for (int i = 0; i < liczbaWezlow; i++) //Wyswietlanie tablic: kosztow i kierowania wezlami
            {
                Console.WriteLine();
                for (int j = 0; j < liczbaWezlow; j++)
                {
                    Console.Write($"{ tablicaKosztow[i, j]}\t\t");
                }
            }

            Console.WriteLine("\n\nTablica kierowania wezlami: ");
            for (int i = 0; i < liczbaWezlow; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < liczbaWezlow; j++)
                {
                    if (tablicaKierowaniaWezlami[i, j] == null)
                        Console.Write("null\t");
                    else if (tablicaKierowaniaWezlami[i, j].idWezla == j + 1)
                        Console.Write($"SA ({tablicaKierowaniaWezlami[i, j].idWezla})\t");
                    else
                        Console.Write($"{tablicaKierowaniaWezlami[i, j].idWezla}\t");
                }
            }

        }
        public void testFloyd(ref Lacze[,] tablicaKierowaniaLaczami, ref Wezel[,] tablicaKierowaniaWezlami)
        {
            Console.WriteLine();
            Console.WriteLine();
            Sciezka S1 = new Sciezka();
            Console.WriteLine($"Podaj nr wierzcholka(od 1 do {wezly.Count}), z ktorego wyruszamy");
            int nr1 = 0, nr2 = 0;
            try
            {
                nr1 = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Podaj liczby od 1 do  {wezly.Count} ");
            }

            Console.WriteLine($"Podaj nr wierzcholka (od 1 do  {wezly.Count}), do ktorego chcesz sie udac:");

            try
            {
                nr2 = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Podaj liczby od 1 do  {wezly.Count} ");
            }

            S1.Wezel1 = wezly[nr1 - 1]; //Ustawiamy poczatek i koniec Sciezki
            S1.Wezel2 = wezly[nr2 - 1];

            S1.KrawedzieSciezki = S1.wyznaczSciezke(wezly[nr1 - 1], wezly[nr2 - 1], ref tablicaKierowaniaLaczami, ref tablicaKierowaniaWezlami);
            S1.wyznaczWezly(wezly[nr1 - 1]);
            S1.pokazSciezke();
        }

        //Odczytuje plik z miejsca wskazanego przez uzytkownika
        public void wczytaj_dane(string plik)
        {
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

            //Zapisuje do tablicy caly plik.
            //Jeden wiersz to jedna komorka tablicy.
            
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

                }
            }

                liczbyDane = dane[liczbaWezlow+1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                liczbaLaczy = Int32.Parse(liczbyDane[2]);

                for (int j = 0; j < liczbaLaczy; j++)
                {

                try
                {
                    //Analogicznie jak wezly jednak do indekcowania uzywam wiadomosci o liczbie wersow ktore byly wyzej, aby zapisywac kolejne dane

                    liczbyDane = dane[(liczbaWezlow + 2 + j)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    krawedzie.Add(new Lacze(Int32.Parse(liczbyDane[0]),
                        wezly[Int32.Parse(liczbyDane[1]) - 1], wezly[Int32.Parse(liczbyDane[2]) - 1]));
                    //Podaje dla obiektow klasy wezel nr ID krawedzi, ktore zostaly do niego doprowadzone
                    wezly[Int32.Parse(liczbyDane[1])-1].wprowadzenieIndeksowKrawedzi(krawedzie[Int32.Parse(liczbyDane[0])-1]);
                    wezly[Int32.Parse(liczbyDane[2])-1].wprowadzenieIndeksowKrawedzi(krawedzie[Int32.Parse(liczbyDane[0])-1]);

                    




                }
                    catch (Exception)
                    {

                    }
                }
           
            //Kolejny dziwny indeks w nastepnej lini, ale takze wynika z ilosci danych wczesniej zapisanych

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
                sciezki.Add(new Sciezka() { Wezel1 = wezly[Int32.Parse(liczbyDane[0])-1], Wezel2 = wezly[Int32.Parse(liczbyDane[1]) - 1] });
                algorytmDijkstry();
            }
            else
            {
                int obecneMiejsce = liczbaWezlow + liczbaLaczy + 3;
                for (; obecneMiejsce < dane.Length; obecneMiejsce++)
                {
                    liczbyDane = dane[(obecneMiejsce)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    sciezki.Add(new Sciezka() { Wezel1 = wezly[Int32.Parse(liczbyDane[0]) - 1], Wezel2 = wezly[Int32.Parse(liczbyDane[1]) - 1] });
                }
                algorytmFloyda();
            }

        }
           
        }
    }

