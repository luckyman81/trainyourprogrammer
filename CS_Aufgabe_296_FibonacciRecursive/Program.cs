using System;
using System.Collections.Generic;

namespace FibonacciRecursive
{
    /*
     * Berechne die ersten 100 Zahlen der Fibonacci-Folge (0, 1, 1, 2, 3, 5, 8, 13, ... vgl.: Fibonacci-Folge (Wikipedia))

Die Fibonacci-Folge beginnt mit den Zahen 0 und 1. Jede weitere Zahl der Folge wird durch Addition der beiden Vorhergehenden gebildet.

0
1
1 (=0+1)
2 (=1+1)
3 (=1+2)
5 (=2+3)
8 (=3+5)
13 (=5+8)
...

Die Aufgabe lässt sich mit einer relativ einfachen Schleife lösen.
Fortgeschrittene können sie auch mit einer rekursiven Funktion lösen.*/
    class Program
    {
        static void Main(string[] args)
        {
            ulong start1 = 0;
            ulong start2 = 1;
            List<ulong> fibo = new List<ulong>
            {
                start1,
                start2
            };

            Fibonacci(ref start1, ref start2, fibo, 99);

            int j = 0;
            foreach (ulong f in fibo)
            {
                Console.WriteLine(j++ + ": " + f);
            }
            Console.ReadKey();
        }

        private static void Fibonacci(ref ulong start1, ref ulong start2, List<ulong> fibo, int n)
        {
            if (n < 0)
                return;
            ulong next = start1 + start2;
            fibo.Add(next);
            Fibonacci(ref start2, ref next, fibo, n - 1);
        }
    }
}
