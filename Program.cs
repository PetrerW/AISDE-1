using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            Siec moja = new Siec();
            //string plik = Console.ReadLine();
            Wezel w = new Wezel();

            moja.wczytaj_dane(@"C:\Users\Daniel\Documents\Visual Studio 2015\Projects\ConsoleApplication8\ConsoleApplication8\read.txt");
            Console.ReadKey();
        }
    }
}
