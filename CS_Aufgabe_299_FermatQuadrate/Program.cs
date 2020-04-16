using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Aufgabe_299_FermatQuadrate
{
    /*
     * 
    1. Schreibe eine Funktion bzw. Methode mit der es möglich ist zu überprüfen, ob es sich bei der eingegebenen Zahl um eine Primzahl handelt.

    2. Erweitere das Programm dahingehend, dass nur die ungeraden Primzahlen ausgegeben werden, welche dem Quadrate- Satz von
    Fermat entsprechen. Also der Summe zweier ganzzahliger Quadrate.

    Beispiele:
    5 = 1² + 2², 13 = 2² + 3², 17 = 1² + 4², …

    Gegenbeispiele:
    3, 7, 11, 19 funktionieren nicht, da sie durch 4 geteilt (Modulo 4) nicht den Wert 1 ergeben. Daher gibt es auch keine Lösung (4n+1).

    3. Erweitere das Programm wiederum, sodass die möglichen Lösungen aus als Zahlenpaare auf dem Bildschirm ausgegeben werden.
    z.B.: 13 (2,3)*/
    class Program
    {
        static void Main(string[] args)
        {
            int[] fermatPrimes = new int[] { 5, 13, 17, 29 };
            int[] nFermatPrimes = new int[] { 3, 7, 11, 19 };

            Console.WriteLine($"{fermatPrimes.All(x => x.IsFermatPrime())}");
            Console.WriteLine($"{nFermatPrimes.All(x => (!x.IsFermatPrime()))}");

            List<int> fermats = new List<int>();
            for (int i = 0; i < 1e3; i++)
            {
                if (i.IsFermatPrime())
                {
                    fermats.Add(i);
                }
            }

            foreach (var fermat in fermats)
            {
                for (int i = 0; i < Math.Sqrt(1e3); i++)
                {
                    double cand = Math.Sqrt(fermat - Math.Pow(i, 2.0));

                    if (Math.Abs(cand - Math.Truncate(cand)) < 1e-10)
                    {
                        Console.WriteLine($"{fermat} ({i}, {cand})");
                        break;
                    }
                }
            }

            Console.ReadKey();
        }
    }

    public static class Extensions {

        public static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n % x == 0).SequenceEqual(new[] { 1, n });
            }
            return false;
        }

        public static bool IsFermatPrime(this int n)
        {
            if (!IsPrime(n)) return false;
            else if (n % 4 == 1) return true;
            else
                return false;
        }
    }
}
