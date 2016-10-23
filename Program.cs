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

            //~Daniel:  
            //moja.wczytaj_dane(@"C:\Users\Daniel\Documents\Visual Studio 2015\Projects\ConsoleApplication8\ConsoleApplication8\read.txt");

            //~Piotrek:
            moja.wczytaj_dane(@"C:\Users\oem\Desktop\Programowanie\C#\AISDE\Wejscie.txt");

            Console.ReadKey();
        }
    }
}
