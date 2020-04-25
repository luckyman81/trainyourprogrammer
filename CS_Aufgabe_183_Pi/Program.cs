using System;

namespace CS_Aufgabe_183_Pi
{
    /*
     Schreibe eine Methode um Pi zu berechnen. Versuche Pi auf so viele Stellen wie möglich zu berechnen.*/
    class Program
    {
        static void Main(string[] args)
        {
            double n = 1e8;
            int counter = 0;
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();

                if (Math.Sqrt(Math.Pow(x, 2e0) + Math.Pow(y, 2e0)) < 1e0) {
                    counter++;
                }
            }

            Console.WriteLine($"pi = {4e0 * counter / n}");
            Console.ReadKey();
        }
    }
}
