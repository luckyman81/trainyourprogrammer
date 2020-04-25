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
    /*
     *  Die Liouville Serie ist eine Zahlenfolge, die nur aus den Zahlen +1 und -1 besteht.

        Sie beginnt mit {1, -1, -1, 1, -1, 1, -1, -1, 1, 1, -1, -1 ...}. Die ersten 10.000
        Glieder sind in der Datei liouville_folge.txt gespeicher und könnten meinetwegen eingelesen werden.

        Wer die Glieder der Folge L(n) selber berechnen will, muss wie folgt vorgehen:

        1.) Per Definition wird L(1) => +1 gesetzt.
        2.) Man zerlege n in all seine Primfaktoren (z. B. 14 = 2 * 7 oder 32 = 2 * 2 * 2 * 2 * 2).
        3.) L(n) => +1, falls die Anzahl der Primfaktoren eine gerade Zahl ist, ansonsten L(n) => -1
        (also L(14) => +1; L(32) => -1).

        Man fasse nun L(n) als eine Schrittfolge auf, die eine Weg in der x-y-Ebene beschreibt.
        Ausgehend von der Koordinate (x = 0, y = 0) wird zunächt der x-Wert um Eins erhöht
        (entsprechend L(1) = 1), anschließend wird der y-Wert um Eins erniedrigt (entsprechend L(2) = -1)
        und immer so fort bis zu L(nmax) (nmax von mir aus 10.000 oder mehr).

        Der sich so ergebene Weg (siehe Bild 1 für nmax = 100.000, die Pixelfarbe wechselt zur besseren Illustration alle 10.000 Schritte)
        ist gefühlsmäßig ein Zufallsweg (Random Walk). Ob dem wirklich so ist, weiß man bis heute nicht.

        Die Programmieraufgabe bestehe nun darin, den Liouville-Weg graphisch darzustellen.

        Falls jemand fragt "Was soll der Unfug?": Nun, man geht davon aus, das die Liouville Serie ein Schlüssel
        zur Lösung der Riemann-Hypothese (RH) sein könnte. Bekanntlich sind zum Beweis bzw. zur Widerlegung der RH
        noch immer eine Million US-Dollar ausgeschrieben.

        Also, dann viel Erfolg! Ich drücke die Daumen für den Einemilliongewinn.*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Width = 1000;
            Height = 600;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int LiouX = 0;
            int LiouY = 0;
            Random rnd = new Random();
            int startX = Width/2;
            int startY = Height/2;
            List<Point> points = new List<Point>();

            List<int> primes = SieveEratosthenes(100000);
            

            Dictionary<Color, Point[]> dict = new Dictionary<Color, Point[]>();
            
            for (int n = 1; n < 100000; n++)
            {

                short liou = Liouville(n, primes);
                if (n % 2 == 0)
                {
                    LiouY = LiouY + liou;
                }
                else
                {
                    LiouX = LiouX + liou;
                }                

                points.Add(new Point(startX + LiouX, startY + LiouY));

                if (n % 10000 == 0)
                {
                    Point[] ptsArr = new Point[points.Count];
                    points.CopyTo(ptsArr);
                    
                     Color newColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

                    dict.Add(newColor, ptsArr);
                    points.Clear();
                    
                    ;
                }
            }
            
            DrawAxes(g);

            foreach (var di in dict)
            {
                g.DrawCurve(new Pen(di.Key), di.Value);
            }            
        }

        private void DrawAxes(Graphics g)
        {
            g.DrawLine(Pens.Black, Width / 2, 0, Width / 2, Height);
            g.DrawLine(Pens.Black, 0, Height / 2, Width, Height / 2);
        }

        private static short Liouville(int n, List<int> primes)
        {
            if (n == 1)
            {
                return 1;
            }

            //List<int> primes = SieveEratosthenes(n + 1);

            List<int> primefactors = PrimeDecomp(n, primes);

            if (primefactors.Count % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }

        private static List<int> PrimeDecomp(int m, List<int> primes)
        {
            List<int> factors = new List<int>();

            foreach (int i in primes.Where(x => x <= m).ToList())
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


