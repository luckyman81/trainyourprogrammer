using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Aufgabe_136_LeastCommonMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 3528;
            int n = 3780;

            // Sieb des Eratosthenes
            List<int> mPrimes = SieveEratosthenes(m);
            List<int> nPrimes = SieveEratosthenes(n);


            // Primfaktorzerlegung ( prime decomposition )
            List<int> mFactors = PrimeDecomp(m, mPrimes);
            List<int> nFactors = PrimeDecomp(n, nPrimes);


            // Calculate LCM
            Console.WriteLine($"lcm({m},{n}) = {CalculateLCM(mFactors, nFactors)}");
            
        }

        private static int CalculateLCM(List<int> mFactors, List<int> nFactors)
        {
            var mValues = mFactors.GroupBy(x => x).Select(g => new PrimePow { Key = g.Key, Count = g.Count() }).ToList();
            var nValues = nFactors.GroupBy(x => x).Select(g => new PrimePow { Key = g.Key, Count = g.Count() }).ToList();

            int lcm = 1;
            foreach (var mval in mValues)
            {
                foreach (var nval in nValues)
                {
                    if (mval.Key == nval.Key)
                        if (mval.Count >= nval.Count)
                            lcm *= (int)Math.Pow(mval.Key, mval.Count);
                        else
                            lcm *= (int)Math.Pow(nval.Key, nval.Count);
                }
            }

            var comparer = new PrimePowEqualityComparer();

            List<PrimePow> diff = nValues.Except(mValues, comparer).ToList();

            foreach (PrimePow d in diff)
            {
                lcm *= (int)Math.Pow(d.Key, d.Count);
            }
            
            return lcm;
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
            //const int n = 10000;
            bool[] gestrichen = new bool[n - 1];
            List<int> primes = new List<int>();

            // Initialisierung des Primzahlfeldes
            // Alle Zahlen im Feld sind zu Beginn nicht gestrichen
            for (int i = 0; i < gestrichen.Length; i++)
            {
                gestrichen[i] = false;
            }

            // Siebe mit allen (Prim-) Zahlen i, wobei i der kleinste Primfaktor einer zusammengesetzten
            // Zahl j = i*k ist. Der kleinste Primfaktor einer zusammengesetzten Zahl j kann nicht größer
            // als die Wurzel von j <= n sein.
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (!gestrichen[i-2])
                {
                    // i ist prim, gib i aus...
                    Console.Write(i + ", ");
                    primes.Add(i);
                }
                // ...und streiche seine Vielfachen, beginnend mit i*i
                // (denn k*i mit k<i wurde schon als Vielfaches von k gestrichen)
                for (int j = i * i; j < n; j += i)
                {
                    gestrichen[j-2] = true;
                }
            }
            // Gib die Primzahlen größer als Wurzel(n) aus - also die, die noch nicht gestrichen wurden
            for (int i = (int)Math.Sqrt(n) + 1; i < n; i++)
            {
                if (!gestrichen[i-2])
                {
                    // i ist prim, gib i aus
                    Console.Write(i + ", ");
                    primes.Add(i);
                }
            }
            return primes;
        }
    }

    public class PrimePow
    {
        public int Key { get; set; }
        public int Count { get; set; }
    }
}
