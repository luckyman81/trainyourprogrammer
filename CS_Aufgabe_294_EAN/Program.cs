using System;

namespace EAN
{
    /*
     * Schreibe ein Programm mit dem man sowohl die Prüfziffer einer EAN- Nummer (Europäische Artikel- Nummerierung) berechnen als auch überprüfen kann.

    Die EAN- Nummer besteht aus 13 Ziffern, wobei es sich bei der letzten Ziffer um die Prüfziffer handelt.

    Beispiel für eine EAN: 978381582086[?]

    Die Prüfziffer wird berechnet, indem man die ersten 12 Ziffern von links beginnend abwechselnd mit 1 und 3 multipliziert und anschließend die Produkte summiert.

    Die Differenz zum nächsten Vielfachen von 10 ist die Prüfziffer.

    Ist die Summe durch 10 teilbar, ist die Prüfziffer die Ziffer 0.

    9·1 + 7·3 + 8·1 + 3·3 + 8·1 + 1·3 + 5·1 + 8·3 + 2·1 + 0·3 + 8·1 + 6·3
    = 9 + 21 + 8 + 9 + 8 + 3 + 5 + 24 + 2 + 0 + 8 + 18 = 115
    115 + 5 = 120 ⇒ Prüfziffer: 5
    */
    class Program
    {
        static void Main(string[] args)
        {
            string ean = "9783815820865";
            
            bool b = ValidateEAN(ean);

            if (b)
                Console.WriteLine("EAN "  + ean + " ist gültig.");
            else
                Console.WriteLine("EAN " + ean + " ist ungültig.");

            Console.ReadKey();
        }

        private static bool ValidateEAN(string ean)
        {
            string noEan = ean.Substring(0, ean.Length - 2);
            short checkDigit = Convert.ToInt16(ean.ToCharArray().GetValue(ean.Length-1).ToString());

            int calcDigit = CalculateCheckDigitEAN(ean);
            return (calcDigit == checkDigit);
        }

        private static int CalculateCheckDigitEAN(string ean)
        {
            int checksum = 0;
            for (int i = 0; i < 12; i++)
            {
                short number = Convert.ToInt16(ean.ToCharArray().GetValue(i).ToString());
                if (i % 2 == 0)
                    number *= 1;
                else if (i % 2 == 1)
                    number *= 3;

                checksum += number;
            }

            return (10 - checksum % 10);
            
        }
    }
}
