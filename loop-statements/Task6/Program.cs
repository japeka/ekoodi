using System;
/*
Task 6
Tee ohjelma, joka tulostaa kokonaisluvut 1-10 ja niiden neliöjuuret.
Luku     Neliöjuuri
 1          1.00
 2          1.41
 ...
 10         3.16
*/
namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number\tSquare Root");
            Console.WriteLine("===================");
            for (int i = 1; i <= 10; i++) {
                Console.WriteLine("{0}\t{1}",i, Math.Round(Math.Sqrt(i), 2).ToString().Replace(",", "."));
            }
            Console.ReadKey();
        }
    }
}
