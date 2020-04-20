using System;

namespace CS_Aufgabe_90_Kreiszahl
{
    /*
     *  Man kann die Kreiszahl Pi näherungsweise bestimmen, indem man Zufallszahlen generiert:
        Man stelle sich einen Kreis mit Mittelpunkt (0/0) und Radius 1 vor. Es werden zufällig Punkte erzeugt, bei denen sowohl x als auch y im Intervall [0;1[ liegen. Dann wird die Entfernung dieser Punkte zum Ursprung ermittelt. Ist diese Entfernung kleiner als 1, so liegt der Punkt innerhalb des Kreises.
        Setzt man bei einer ausreichenden Zahl von Zufallspunkten die Zahl der Treffer in das richtigen Verhältnis zur Gesamtzahl der Punkte, so erhält man einen Näherungswert für Pi (Pi = 4 * AnzahlTreffer / AnzahlGesamt).

        Schreibe ein Programm, das auf oben beschriebene Weise Pi berechnet.*/
    class Program
    {
        static void Main(string[] args)
        {
            int AnzahlTreffer = 0; 
            int AnzahlGesamt = 0;
            Random rnd = new Random();

            for (int i = 0; i < 1e5; i++)
            {
                double dist = Math.Sqrt(Math.Pow(rnd.NextDouble(), 2.0) + Math.Pow(rnd.NextDouble(), 2.0));
                if (dist < 1e0) { AnzahlTreffer++; }
                AnzahlGesamt++;
            }

            double Pi = 4.0 * AnzahlTreffer / AnzahlGesamt;

            Console.WriteLine($"Abweichung nach {AnzahlGesamt} Versuchen: {Pi-Math.PI}");

            Console.ReadKey();
        }
    }
}
