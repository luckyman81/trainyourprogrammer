using System;

namespace CS_Aufgabe_258_Eulerzahl
{
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
