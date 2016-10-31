using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Sciezka
    {
        List<Lacze> krawedzieSciezki = new List<Lacze>();
        List<Wezel> wezlySciezki = new List<Wezel>();
        //krawedzieSciezki[0] to krawedz wychodzaca z wezlySciezki[0] i dochodzaca do wezlySciezki[1]

        //~Piotrek 
        protected Wezel WezelPierwszy;
        protected Wezel WezelDrugi;
        //

        protected int wezelpierwszy;
        protected int wezeldrugi;

        public Sciezka wyznaczSciezke(Wezel Skad, Wezel Dokad, Lacze[,] tablicaKierowaniaLaczami, Wezel[,] tablicaKierowaniaWezlami)
        {
            wezlySciezki.Add(Skad);
            if (Skad == Dokad)
                return this;
            else
            {
                krawedzieSciezki.Add(tablicaKierowaniaLaczami[Skad.idWezla - 1, Dokad.idWezla - 1]); //Pierwsza krawedz wychodzi z Skad
                if (tablicaKierowaniaWezlami[Skad.idWezla - 1, Dokad.idWezla - 1] == Dokad) //Sciezka z jedna krawedzia
                    return this;
            }

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
        //
    }
}
