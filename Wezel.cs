using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class Wezel
    {
        protected int identyfikatorWezla;
        protected int wspolrzednaX;
        protected int wspolrzednaY;
        protected int doMniePrzez;
        protected float etykieta;
        protected bool odwiedzony;
        protected List<int> doprowadzoneKrawedzie = new List<int>();
       

        public Wezel()
        {
            identyfikatorWezla = 0;
            wspolrzednaX = 0;
            wspolrzednaY = 0;
            doMniePrzez = identyfikatorWezla;
            etykieta = 0;
            odwiedzony = false;
        }

        public Wezel(int identyfikatorWezla, int wspolrzednaX, int wspolrzednaY)
        {
            this.identyfikatorWezla = identyfikatorWezla;
            this.wspolrzednaX = wspolrzednaX;
            this.wspolrzednaY = wspolrzednaY;
            doMniePrzez = identyfikatorWezla;
        }

        public int idWezla
        {
            get { return identyfikatorWezla; }
            set { identyfikatorWezla = value; }
        }

        public int wspX
        {
            get { return wspolrzednaX; }
            set { wspolrzednaX = value; }
        }

        public int wspY
        {
            get { return wspolrzednaY; }
            set { wspolrzednaY = value; }
        }

        public bool Odwiedzony
        {
            get { return odwiedzony; }
            set { odwiedzony = value; }
        }
    

    
        public int NajlepiejPrzez
        {
            get { return doMniePrzez; }
            set { doMniePrzez = value; }
        }

        public float Etykieta
        {
            get { return etykieta; }
            set { etykieta = value; }
        }

        public void wprowadzenieIndeksowKrawedzi(int indeks)
        {
            doprowadzoneKrawedzie.Add(indeks);
        }
        public List<int> listaKrawedzi
        {
            get { return doprowadzoneKrawedzie; }
        }
       
    }
}
