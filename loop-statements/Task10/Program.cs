using System;
/*
Task 10

Tee ohjelma, joka tulostaa vakioveikkauksen rivin (13 kohdetta,
1 = kotivoitto, X = tasapeli ja 2 = vierasvoitto). Kotivoiton todennäköisyys on 0.4, tasapelin 0.2 ja vierasvoiton 0.4.
Ohjelmankulku
Aloitus
- Aloita silmukka
  - Arvo luku
  - Jos luku ]0-0.4[ =>Kotivoitto
    - Tulosta: Kotivoitto
  - muuten Jos luku ]0.4-0.6[ =>Tasapeli
    - Tulosta: Tasapeli
  - muuten =>Vierasvoitto
    - Tulosta: Vierasvoitto
- Silmukka päättyy
Lopetus
*/
namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Response:");
            Console.WriteLine("************");
            double rndSeed;
            for (int i = 1; i <= 13; i++) {
                rndSeed = rnd.NextDouble();
                if (rndSeed >= 0 && rndSeed <= 0.4)
                {
                    Console.WriteLine("{0}.\t1", i);                     
                }
                else if (rndSeed > 0.4 && rndSeed <= 0.6)
                {
                    Console.WriteLine("{0}.\tX", i, rndSeed);
                }
                else {
                    Console.WriteLine("{0}.\t2", i, rndSeed);
                }
            }
            Console.ReadKey();
        }
    }
}
