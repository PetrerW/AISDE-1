using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Sciezka
    {
        LinkedList<Lacze> krawedzieSciezki = new LinkedList<Lacze>();
        LinkedList<Wezel> wezlySciezki = new LinkedList<Wezel>();
        List<Lacze> ListaKrawedziSciezki = new List<Lacze>();
        List<Wezel> ListaWezlowSciezki = new List<Wezel>();
        //krawedzieSciezki[0] to krawedz wychodzaca z wezlySciezki[0] i dochodzaca do wezlySciezki[1]

        //~Piotrek 
        protected Wezel WezelPierwszy; //Skad idziemy
        protected Wezel WezelDrugi; //Dokad idziemy
        //

        protected int wezelpierwszy;
        protected int wezeldrugi;

        public List<Lacze> KrawedzieSciezki
        {
            get { return this.ListaKrawedziSciezki; }
            set { this.ListaKrawedziSciezki = value; }
        }

        public int wezel1
        {
            get { return wezelpierwszy; }
            set { wezelpierwszy = value; }
        }

        public int wezel2
        {
            get { return wezeldrugi; }
            set { wezeldrugi = value; }
        }

        //~Piotrek
        public Wezel Wezel1
        {
            get { return WezelPierwszy; }
            set { WezelPierwszy = value; }
        }

        public Wezel Wezel2
        {
            get { return WezelDrugi; }
            set { WezelDrugi = value; }
        }

        public List<Lacze> wyznaczSciezke(Wezel Skad, Wezel Dokad, ref Lacze[,] tablicaKierowaniaLaczami, ref Wezel[,] tablicaKierowaniaWezlami)
        {
            List<Lacze> tempList = new List<Lacze>();
            if(tablicaKierowaniaWezlami[Skad.idWezla - 1, Dokad.idWezla - 1] == Dokad)
            {
                tempList.Add(tablicaKierowaniaLaczami[Skad.idWezla - 1, Dokad.idWezla - 1]);
            }
            else
            {
                //Dodajemy sciezke z Skad do punktu posredniego, wskazanego przez tablice kierowania Wezlami
                tempList.AddRange(wyznaczSciezke(Skad, tablicaKierowaniaWezlami[Skad.idWezla - 1, Dokad.idWezla - 1], ref tablicaKierowaniaLaczami, ref tablicaKierowaniaWezlami));
                //Potem doklejamy drugi koniec listy, liste krawedzi z posredniego do koncowego
                tempList.AddRange(wyznaczSciezke(tablicaKierowaniaWezlami[Skad.idWezla - 1, Dokad.idWezla - 1], Dokad, ref tablicaKierowaniaLaczami, ref tablicaKierowaniaWezlami));
            }
            return tempList;
        }

        public void wyznaczWezly(Wezel Skad)
        {
            ListaWezlowSciezki.Add(Skad);
            foreach(Lacze lacze in ListaKrawedziSciezki)
            {
                if (!ListaWezlowSciezki.Contains(lacze.Wezel1))
                    ListaWezlowSciezki.Add(lacze.Wezel1);
                if (!ListaWezlowSciezki.Contains(lacze.Wezel2))
                    ListaWezlowSciezki.Add(lacze.Wezel2);
                else
                    continue;
            }
        }

        public void pokazSciezke()
        {
            int i = 0;
            Wezel temp = new Wezel();
            temp = ListaWezlowSciezki[ListaWezlowSciezki.Count-1];
            Console.WriteLine($"Sciezka z wezla nr {ListaWezlowSciezki[0].idWezla} do wezla nr {temp.idWezla}");
            while (ListaKrawedziSciezki.ElementAtOrDefault(i) != null)
            { 
                Console.WriteLine($"Od wezla : {ListaWezlowSciezki[i].idWezla}");
                Console.WriteLine($"przejdz krawedzia: {ListaKrawedziSciezki[i].idKrawedzi}");
                i++;
            }
            Console.WriteLine("Jestes na miejscu!");
        }
    }
}