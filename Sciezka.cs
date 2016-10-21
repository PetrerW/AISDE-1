using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Sciezka
    {
        protected int wezelpierwszy;
        protected int wezeldrugi;

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
    }
}
