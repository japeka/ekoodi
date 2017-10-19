using System;
/*
Task 8

Tee ohjelma, joka tulostaa 20 satunnaista kokonaislukua väliltä [0-50].
Tulosta luvut siten, että jokaisella rivillä on 5 lukua pilkulla erotettuna. 
Vastaus:
Rivi 1: 25, 0, 32, 11, 15
Rivi 2: 10, 20, 17, 35, 22
...
*/
namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Response:");
            Console.WriteLine("========================");

            Random rnd = new Random();
            for (int i = 1; i <= 4; i++) {
                Console.Write("Row {0}: ",i);
                for (int j = 1; j <= 5; j++) {
                    if (j == 5)
                    {
                      Console.Write("{0}", rnd.Next(51));
                    }
                    else {
                      Console.Write("{0}, ", rnd.Next(51));
                    }
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
