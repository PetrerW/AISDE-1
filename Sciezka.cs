﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Sciezka
    {
        //~Piotrek 
        protected Wezel WezelPierwszy;
        protected Wezel WezelDrugi;
        //

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