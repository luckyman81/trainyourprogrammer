using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace CS_Aufgabe_239_LiouvilleSerie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Width = 700;
            Height = 700;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int LiouX = 0;
            int LiouY = 0;

            int startX = 100;
            int startY = 100;
            List<Point> points = new List<Point>();

            using (StreamWriter stream = new StreamWriter(@"C:\Users\Stefan\Desktop\liouville.txt"))
            {
                for (int n = 1; n < 10000; n++)
                {
                    short liou = Liouville(n, stream);
                    if (n % 2 == 0)
                    {
                        LiouY = LiouY + liou;
                    }
                    else
                    {
                        LiouX = LiouX + liou;
                    }
                    points.Add(new Point(startX-LiouX,startY+ LiouY));
                }
            }


            g.DrawCurve(Pens.Red, points.ToArray());


        }


        private static short Liouville(int n, StreamWriter stream)
        {
            if (n == 1)
            {
                stream.WriteLine(1);
                return 1;
            }

            List<int> primes = SieveEratosthenes(n + 1);

            List<int> primefactors = PrimeDecomp(n, primes);

            if (primefactors.Count % 2 == 0)
            {
                stream.WriteLine(1);
                return 1;
            }
            else
            {
                stream.WriteLine(-1);
                return -1;
            }

        }

        private static List<int> PrimeDecomp(int m, List<int> primes)
        {
            List<int> factors = new List<int>();

            foreach (int i in primes)
            {
                while (m % i == 0)
                {
                    factors.Add(i);
                    m /= i;
                }
            }

            return factors;
        }

        private static List<int> SieveEratosthenes(int n)
        {
            List<int> primes = new List<int>();
            bool[] prime = new bool[n];
            //Zuerst alle Zahlen von 2 bis n als Primzahl markieren
            for (int i = 2; i < n; i++)
            {
                prime[i] = true;
            }

            //Einzelner Abschnitt
            {
                //Wir wollen bei 2 anfangen
                int i = 2;

                //Alle Produkte des Teilers i
                //angefangen bei 2, bis kleiner n durchlaufen
                //Wenn n = 50, dann ist bei i = 7 Schluss, weil das Produkt = 49 ist
                for (; i * i < n; i++)
                {
                    //Wenn die Zahl im Array als Primzahl markiert ist
                    //Was bei den ersten beiden 2 und 3 definitiv der Fall ist
                    if (prime[i])
                    {
                        //Primzahl bis Wurzel(n) ausgeben
                        Console.WriteLine(i);
                        primes.Add(i);
                        //Alle weiteren Produkte des Teilers i
                        //angefangen beim Produkt i * i bis kleiner n durchlaufen
                        //j wird mit i beim nächsten Durchlauf (Vielfaches) addiert
                        for (int j = i * i; j < n; j += i)
                        {
                            //Dies kann unmöglich eine Primzahl sein
                            //weil es ein Vielfaches von i ist.
                            prime[j] = false;
                        }
                    }
                }

                //Alle Primzahlen ausgebene
                for (; i < n; i++)
                {
                    if (prime[i])
                    {
                        Console.WriteLine(i);
                        primes.Add(i);
                    }
                }
            }
            return primes;
        }


    }
}


