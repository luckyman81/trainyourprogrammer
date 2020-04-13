using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Aufgabe_182_Multinacci
{
    /*
     * Die Fibonacci-Folge beginnt bekanntlich mit {1, 1}, also zwei Einsen
       und jedes Folgeglied ist die Summe seiner zwei Vorgänger. Wir wollen die Fibonacci-Folge wegen der zwei Starteinsen "fibo2" nennen.

       Unter einer Multinacci-Folge (fibok) sei eine Folge verstanden, die mit k Einsen beginnt
       und jedes Folgeglied die Summe der k Vorgängerglieder ist. Ist k = 1, so heiße der Spezialfall Mononacci.

       Die Glieder der Multinacci-Folgen werden ab Glied k immer größer und streben gegen unendlich.
       Allerdings strebt der Quotient zweier benachbarter Folgeglieder immer gegen einen endlichen Grenzwert, bei fibo2
       ist es bekanntlich der goldene Schnitt phi (phi = 1.618034).

       Wir wollen den entsprechenden Grenzwert der Multinacci-Folgen mit "phi_fibok" benennen.

       Schreibe ein Programm, das für k = 1, 2, 3 ... 100 die ersten 10 Glieder der Multinacci-Folgen ab Glied k und den Grenzwert phi_fibok ausgibt.

       Hinweis: Beider der Grenzwertbildung könnt ihr es mit sehr große Zahlen zu tun bekommen, deshalb Ergebnis auf Plausibilität testen!*/
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 1; j < 100; j++)
            {
                List<int> fibo = new List<int>();
                List<int> numbers = new List<int>();

                for (int i = 0; i < j; i++)
                {                    
                    numbers.Add(1);                
                } 
                Fibok(fibo, 10, numbers);
            }           

            Console.ReadKey();
        }

        private static void Fibok(List<int> fibo, int n, List<int> numbers)
        {
            int next = 0;
            if (n >= 0)
            {
                next = numbers.Sum();

                numbers.RemoveAt(0);
                numbers.Add(next);

                fibo.Add(next);
                Fibok(fibo, n - 1, numbers);
            }
            else
            {
                double phi_fibok = 0.0;
                if (numbers.Count < 2)
                    phi_fibok = 1.0;
                else
                    phi_fibok = (double)numbers[numbers.Count - 1] / 
                        (double)numbers[numbers.Count - 2];
                Console.WriteLine(phi_fibok);

                for (int i = 0; i < fibo.Count; i++)
                {
                    Console.Write(fibo[i] + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}
