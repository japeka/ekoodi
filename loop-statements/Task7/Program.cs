using System;
/*
Task 7

Tee ohjelma, joka tulostaa kertotaulun luvuille 1-9.
Vastaus:
1 x 1 = 1
1 x 2 = 2
...
9 x 9 = 81
*/
namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiplication Table");
            Console.WriteLine("====================");
            for (int i=0;i<=9;i++) {
                Console.WriteLine("{0} X {1} = {2}", i,i,(i*i));
            }
            Console.ReadKey();
        }
    }
}
