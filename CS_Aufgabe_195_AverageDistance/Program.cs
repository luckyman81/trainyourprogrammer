using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Aufgabe_195_AverageDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<double> dist = new List<double>();
            const double a = 1e0; // Seiten des Rechtecks bzw große und kleine Halbachse
            double b = rnd.NextDouble();
            double iter = 1e6;

            // Straight line
            for (int i = 0; i < iter; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();
                dist.Add(Math.Abs(x - y));
            }
            Console.WriteLine($"Line:   {dist.Average()}");
            dist.Clear();

            // Square
            for (int i = 0; i < iter; i++)
            {
                double x1 = rnd.NextDouble();
                double x2 = rnd.NextDouble();
                double y1 = rnd.NextDouble();
                double y2 = rnd.NextDouble();
                dist.Add(Math.Sqrt(Math.Pow(x1 - x2, 2e0) + Math.Pow(y1 - y2, 2e0)));
            }
            Console.WriteLine($"Square:   {dist.Average()}");
            dist.Clear();

            // Rectangle
            for (int i = 0; i < iter; i++)
            {
                double x1 = rnd.NextDouble() * a;
                double x2 = rnd.NextDouble() * a;
                double y1 = rnd.NextDouble() * b;
                double y2 = rnd.NextDouble() * b;
                dist.Add(Math.Sqrt(Math.Pow(x1 - x2, 2e0) + Math.Pow(y1 - y2, 2e0)));
            }
            Console.WriteLine($"Rectangle:   {dist.Average()}");
            dist.Clear();

            // Circle
            for (int i = 0; i < iter; i++)
            {
                double ra = rnd.NextDouble();
                double rb = rnd.NextDouble();
                double thetaa = rnd.NextDouble() * Math.PI;
                double thetab = rnd.NextDouble() * Math.PI;
                dist.Add(Math.Sqrt(Math.Pow(ra, 2e0) + Math.Pow(rb, 2e0) - 2e0 * ra * rb * Math.Cos(Math.Abs(thetaa-thetab))));

            }
            Console.WriteLine($"Circle:   {dist.Average()}");
            dist.Clear();

            // Ellipse
            for (int i = 0; i < iter; i++)
            {
                double thetaa = rnd.NextDouble() * Math.PI;
                double rthetaa = a * b / Math.Sqrt(a * a * Math.Pow(Math.Sin(thetaa), 2e0) + b * b * Math.Pow(Math.Cos(thetaa), 2e0));

                double thetab = rnd.NextDouble() * Math.PI;
                double rthetab = a * b / Math.Sqrt(a * a * Math.Pow(Math.Sin(thetab), 2e0) + b * b * Math.Pow(Math.Cos(thetab), 2e0));
                
                dist.Add(Math.Sqrt(Math.Pow(rthetaa, 2e0) + Math.Pow(rthetab, 2e0) - 2e0 * rthetaa * rthetab * Math.Cos(Math.Abs(thetaa-thetab))));

            }
            Console.WriteLine($"Ellipse:   {dist.Average()}");
            dist.Clear();

            Console.ReadKey();
        }
    }
}
