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
         const  int INF = 1000;
            Siec moja = new Siec();
            //string plik = Console.ReadLine();
            Wezel w = new Wezel();
            // sciezka Daniela "C:\Users\Daniel\Documents\Visual Studio 2015\Projects\ConsoleApplication8\ConsoleApplication8\read.txt";
            moja.wczytaj_dane(@"E:\Piotr\Programowanie\C#\AISDE\Wejscie.txt");
            Console.ReadKey();
        }
    }
}
