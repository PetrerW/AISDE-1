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
        protected Wezel doMniePrzez;
        protected float etykieta;
        protected bool odwiedzony;
        protected List<Lacze> doprowadzoneKrawedzie = new List<Lacze>();
       

        public Wezel()
        {
            identyfikatorWezla = 0;
            wspolrzednaX = 0;
            wspolrzednaY = 0;
            doMniePrzez = null;
            etykieta = 0;
            odwiedzony = false;
        }

        public Wezel(int identyfikatorWezla, int wspolrzednaX, int wspolrzednaY)
        {
            this.identyfikatorWezla = identyfikatorWezla;
            this.wspolrzednaX = wspolrzednaX;
            this.wspolrzednaY = wspolrzednaY;
           
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
    

    
        public Wezel NajlepiejPrzez
        {
            get { return doMniePrzez; }
            set { doMniePrzez = value; }
        }

        public float Etykieta
        {
            get { return etykieta; }
            set { etykieta = value; }
        }

        public void wprowadzenieIndeksowKrawedzi(Lacze ktore)
        {
            doprowadzoneKrawedzie.Add(ktore);
        }
        public List<Lacze> listaKrawedzi
        {
            get { return doprowadzoneKrawedzie; }
        }
       
    }
}
