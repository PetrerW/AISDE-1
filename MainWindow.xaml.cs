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
        //Do algorytmu Floyda
        TextBox TextBox1;
        TextBox TextBox2;
        Siec siec;
        int liczbaLaczy;
        int liczbaWezlow;
        List<Line> linie;
        List<Label> labele;

        public MainWindow()
        {
            InitializeComponent();




            // myGrid.Children.Add(myButton);
            string nazwa = @"E:\Piotr\Programowanie\C#\AISDE\Wejscie.txt";
            siec = new Siec();
            siec.wczytaj_dane(nazwa);
            //siec.zwroc_lacza.Sort((x, y) => x.Waga.CompareTo(y.Waga));

            linie = new List<Line>();
            labele = new List<Label>();
            liczbaLaczy = siec.zwroc_lacza.Count;
            liczbaWezlow = siec.zwroc_wezly.Count;

            //siec.algorytmPrima();

            rysuj(siec, liczbaLaczy, linie);

            rysuj_algorytm(siec, liczbaLaczy, linie);

    }





        private void rysuj(Siec siec, int size, List<Line> linie)
        {
            // List<Line> linie = new List<Line>();
            // int liczbaLaczy= siec.zwroc_lacza.Count;


            for (int i = 0; i < size; i++)
            {
                linie.Add(new Line());
                linie[i].Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                linie[i].X1 = siec.zwroc_lacza[i].Wezel1.wspX*10 ;
                linie[i].X2 = siec.zwroc_lacza[i].Wezel2.wspX*10 ;
                linie[i].Y1 = siec.zwroc_lacza[i].Wezel1.wspY*10;
                linie[i].Y2 = siec.zwroc_lacza[i].Wezel2.wspY*10 ;
                canvas.Children.Add(linie[i]);
            }
            for (int i = 0; i < liczbaWezlow; i++)
            {
                labele.Add(new Label());
                labele[i].Content = siec.zwroc_wezly[i].idWezla.ToString();
                canvas.Children.Add(labele[i]);
                Canvas.SetBottom(labele[i], siec.zwroc_wezly[i].wspY * 10);
                Canvas.SetLeft(labele[i], siec.zwroc_wezly[i].wspX * 10);
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
            else if (siec.Algorytm == "FLOYD")
            {
                //Algorytm Floyda odpalany jest przy wczytywaniu danych, wiec wszystko bedzie juz poustawiane
                //Okienka po lewej od góry
                TextBox1 = new TextBox(); 
                TextBox2 = new TextBox();
                canvas.Children.Add(TextBox1);
                canvas.Children.Add(TextBox2);
                TextBox1.Width = 60;
                TextBox2.Width = 60;
                Canvas.SetLeft(TextBox1, 130);
                Canvas.SetTop(TextBox1, 60);
                Canvas.SetLeft(TextBox2, 130);
                Canvas.SetTop(TextBox2, 80);

                Label Label1 = new Label();
                Label Label2 = new Label();
                canvas.Children.Add(Label1);
                canvas.Children.Add(Label2);
                Canvas.SetLeft(Label1, 10);
                Canvas.SetTop(Label1, 55);
                Canvas.SetLeft(Label2, 10);
                Canvas.SetTop(Label2, 75);
                Label1.Content = "Wezel poczatkowy: ";
                Label2.Content = "Wezel koncowy: ";

                Button RysujButton = new Button();
                RysujButton.Content = "Generuj sciezke";
                canvas.Children.Add(RysujButton);
                Canvas.SetTop(RysujButton, 100);
                Canvas.SetLeft(RysujButton, 130);

                RysujButton.Click += button_Click;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;

            int w1, w2;
            w1 = Int32.Parse(TextBox1.Text);
            w2 = Int32.Parse(TextBox2.Text);
            Wezel Pierwszy, Ostatni;
            Pierwszy = siec.zwroc_wezly[w1 - 1];
            Ostatni = siec.zwroc_wezly[w2 - 1];
            Sciezka S1 = new Sciezka(Pierwszy, Ostatni);
            S1.zwroc_ListaKrawedziSciezki = S1.wyznaczSciezke(Pierwszy, Ostatni, siec.zwrocTabliceKierowaniaLaczami, siec.zwrocTabliceKierowaniaWezlami);
            S1.wyznaczWezly(Pierwszy);

            foreach(Lacze lacze in S1.zwroc_ListaKrawedziSciezki)
            {
                for (int i = 0; i<liczbaLaczy; i++)
                {
                    if(lacze.idKrawedzi == siec.zwroc_lacza[i].idKrawedzi)
                    {
                        linie[i].StrokeThickness = 2;
                        linie[i].Stroke = redBrush;
                    }
                }
            }
        }




    }
}