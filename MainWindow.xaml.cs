using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AISDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();




            // myGrid.Children.Add(myButton);
            string nazwa = @"C:\Users\Daniel\Documents\Visual Studio 2015\Projects\ConsoleApplication8\ConsoleApplication8\read.txt";
            Siec siec = new Siec();
            siec.wczytaj_dane(nazwa);
            //siec.zwroc_lacza.Sort((x, y) => x.Waga.CompareTo(y.Waga));

            List<Line> linie = new List<Line>();
            int size = siec.zwroc_lacza.Count;

            //siec.algorytmPrima();

            rysuj(siec, size, linie);

            rysuj_algorytm(siec, size, linie);


        }




        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void rysuj(Siec siec, int size, List<Line> linie)
        {
            // List<Line> linie = new List<Line>();
            // int size= siec.zwroc_lacza.Count;


            for (int i = 0; i < size; i++)
            {
                linie.Add(new Line());
                linie[i].Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                linie[i].X1 = siec.zwroc_lacza[i].Wezel1.wspX*10 ;
                linie[i].X2 = siec.zwroc_lacza[i].Wezel2.wspX*10 ;
                linie[i].Y1 = siec.zwroc_lacza[i].Wezel1.wspY*10;
                linie[i].Y2 = siec.zwroc_lacza[i].Wezel2.wspY*10 ;
                myGrid.Children.Add(linie[i]);
            }



        }

        private void rysuj_algorytm(Siec siec, int size, List<Line> linie)
        {
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            size = siec.zwroc_lacza.Count;


            if (siec.Algorytm == "MST")
            {

                // Lacze result = siec.zwroc_lacza.Find(x => x.idKrawedzi==3 );
                foreach (int wartosc in siec.zwroc_tablicaMST)
                    for (int i = 0; i < size; i++)
                    {
                        if (wartosc == siec.zwroc_lacza[i].idKrawedzi)
                        {
                            try
                            {
                                linie[i].StrokeThickness = 2;
                                linie[i].Stroke = redBrush;
                            }
                            catch
                            {
                                MessageBox.Show("W programie uzyto niewlasciwych danych ");

                            }
                        }


                    }
            }
            else if (siec.Algorytm == "SCIEZKA")
            {


                foreach (int wartosc in siec.zwroc_tablicaMST)

                    for (int i = 0; i < size; i++)
                    {
                        if (wartosc == siec.zwroc_lacza[i].idKrawedzi)
                        {
                            try
                            {
                                linie[i].StrokeThickness = 2;
                                linie[i].Stroke = redBrush;
                            }
                            catch
                            {
                                MessageBox.Show("W programie uzyto niewlasciwych danych ");

                            }
                        }
                    }

                    }
        }


private void wczytaj_wagi()
        {
           // List<Line


        }





    }
}