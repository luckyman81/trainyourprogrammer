using System;

namespace CS_Aufgabe_258_Eulerzahl
{
    /*
     * Wir betrachten folgendes Zufallsexperiment: Aus einer Menge reeller und gleichverteilter Zahlen {X} mit 0 <= x < 1.0
       ziehen wir solange Zahlen x1, x2 ... xn bis deren Summe >= 1.0 ist. n ist dann das Ergebnis eines Zufallsexperimentes.
       Wir müssen mindestens zweimal ziehen, den ein einzelnes Zufalls-x ist ja immer kleiner als 1.0.

       Die Frage lautet: Wie groß ist n im Mittel?

       Hinweis: Laut Theorie ist n = 2.718281828459045... (= e). Nun gut, grau ist alle Theorie, wir wollen sehen, ob der Computer
       (in etwa) der gleichen Meinung ist.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double rndNumber, sum = 0.0, sumN = 0;
            int n = 0;

            for (int i = 0; i < 1e8; i++)
            {

                while (true)
                {
                    rndNumber = rnd.NextDouble();
                    sum += rndNumber;
                    n++;
                    if (sum > 1.0) break;
                }
                sumN += n;
                n = 0;
                sum = 0.0;
            }
            Console.WriteLine($"Abweichung = {sumN / 1e8 - Math.E}");
            Console.ReadKey();
        }
    }
}
