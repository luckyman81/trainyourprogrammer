using System;

namespace CS_Aufgabe_310_NonRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int num = p.DoSomething(99);
        }

        int DoSomething(int n)
        {
            return n / 2;
        }
    }
}
