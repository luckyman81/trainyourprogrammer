using System;

namespace CS_Aufgabe_261_Dreiecksberechnung
{
    /*
     * Gegeben sind alle Koordinaten. Die Punkte A und B gibt der Benutzer ein und die C Koordinate ist der Koordinaten Ursprung (0, 0).
       Anhand der Seiten soll der Flächeninhalt und alle Winkel berechnet werden.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("xA eingeben: ");
            double xA = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("yA eingeben: ");
            double yA = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("xB eingeben: ");
            double xB = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("yB eingeben: ");
            double yB = Convert.ToDouble(Console.ReadLine());

            Triangle tri = new Triangle(xA, yA, xB, yB, 0.0, 0.0);
            var sides = tri.CalculateSidesFromCoordinates();
            Console.WriteLine($"Seitenlaengen a={sides.Item1:0.0000}, b={sides.Item2:0.0000}, c={sides.Item3:0.0000}");

            var angles = tri.CalculateAnglesFromCosineRule();
            Console.WriteLine($"Winkel alp={angles.Item1 * 180.0 / Math.PI:0.0000}, bet={angles.Item2 * 180.0 / Math.PI:0.0000}, gam={angles.Item3 * 180.0 / Math.PI:0.0000}");

            Console.WriteLine($"Winkelsumme: {(angles.Item1+ angles.Item2 + angles.Item3) *180.0 / Math.PI}");


            Console.WriteLine($"Flaeche A={tri.CalculateArea():0.0000}");
        }
    }
    
    internal class Triangle
    {
        public double XA { get; private set; }
        public double YA { get; private set; }
        public double XB { get; private set; }
        public double YB { get; private set; }
        public double XC { get; private set; }
        public double YC { get; private set; }
        public int Sides { get; private set; }

        public Triangle(double xA, double yA, double xB, double yB, double xC, double yC)
        {
            XA = xA;
            YA = yA;
            XB = xB;
            YB = yB;
            XC = xC;
            YC = yC;
        }

        public (double,double,double) CalculateSidesFromCoordinates()
        {
            
            double sideA = Math.Sqrt(Math.Pow(YC - YB, 2.0) + Math.Pow(XC - XB, 2.0));
            double sideB = Math.Sqrt(Math.Pow(YC - YA, 2.0) + Math.Pow(XC - XA, 2.0));
            double sideC = Math.Sqrt(Math.Pow(YB - YA, 2.0) + Math.Pow(XB - XA, 2.0));

            return (sideA, sideB, sideC);
         }

        public (double, double, double) CalculateAnglesFromCosineRule() {
            
            var sides = CalculateSidesFromCoordinates();

            double alpha = Math.Acos((
                Math.Pow(sides.Item2, 2.0) + Math.Pow(sides.Item3, 2.0) - Math.Pow(sides.Item1, 2.0)) / (2.0 * sides.Item2 * sides.Item3));
            double beta = Math.Acos((
                Math.Pow(sides.Item1, 2.0) + Math.Pow(sides.Item3, 2.0) - Math.Pow(sides.Item2, 2.0)) / (2.0 * sides.Item1 * sides.Item3));
            double gamma = Math.Acos((
                Math.Pow(sides.Item1, 2.0) + Math.Pow(sides.Item2, 2.0) - Math.Pow(sides.Item3, 2.0)) / (2.0 * sides.Item1 * sides.Item2));

            return (alpha, beta, gamma);
        }

        public double CalculateArea() 
        {
            // ~Wikipedia/Trapezformel
            return 0.5 * (XA * (YB - YC) + XB * (YC - YA) + XC * (YA - YB));

        }
    }
}
