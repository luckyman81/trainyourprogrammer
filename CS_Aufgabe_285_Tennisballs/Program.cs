using System;

namespace CS_Aufgabe_285_Tennisballs
{
    /*
     * Man habe N unterscheidbare Eimer, unterscheidbar bspw. durch Nummerierung der Eimer,
       und N Tennisbälle, die man nicht voneinanderder unterscheiden kann.

       Wie viele Möglichkeiten gibt es, die N Bälle in N Eimern aufzubewahren?

       Dies sei für N = 3 ... 10 anhand eines Computerprogramms zu berechnen.
       Bei N = 1, gibt es nur eine Möglichkeit. Bei N = 2 gibt es 3 Möglichkeiten: (2,0), (1,1) und (0,2).
     */
    class Program
    {
        static void Main(string[] args)
        {
            for (ulong n = 3; n <= 10; n++)
            {
                Console.WriteLine($"n = {n}: {fakultaet(2 * n - 1) / fakultaet(n) / fakultaet(n - 1)}");

            }
            Console.ReadKey();
        }

        private static ulong fakultaet(ulong n)
        {
            if (n == 0)
                return 1;
            else
                return (n * fakultaet(n - 1));
        }
    }
}
