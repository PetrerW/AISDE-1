using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
 public   class Wezel
    {
        protected int identyfikatorWezla;
        protected int wspolrzednaX;
        protected int wspolrzednaY;
        protected bool odwiedzony ;

     public  Wezel()
        {
            identyfikatorWezla = 0;
            wspolrzednaX = 0;
            wspolrzednaY = 0;
            odwiedzony = false;
        }

    public    Wezel(int identyfikatorWezla, int wspolrzednaX, int wspolrzednaY)
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
    }
}
