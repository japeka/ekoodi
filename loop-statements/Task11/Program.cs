using System;
/*
Task 11

Tee ohjelma, joka simuloi nopanheittoa 1000 kertaa
ja tulostaa lisäksi kuutosen esiintymiskertojen lukumäärän
*/
namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int countSixes = 0;
            int rndNum;
            Console.WriteLine("Response: ");
            Console.WriteLine("===========");
            for (int i = 1; i <= 1000; i++) {
              rndNum = rnd.Next(1, 7);
              countSixes = rndNum == 6 ? countSixes + 1 : countSixes;
              Console.WriteLine("{0}.\t{1}",i,rndNum);
            }
            Console.WriteLine("Number 6 thrown {0} times", countSixes);
            Console.ReadKey();
        }
    }
}
