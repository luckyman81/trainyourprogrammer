using System;
using System.Collections.Generic;

namespace CS_Aufgabe_311_EratosthenesSieb
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;

            Console.WriteLine($"{SieveEratosthenes(n)}");
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
