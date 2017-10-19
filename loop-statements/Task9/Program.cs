using System;
/*
Task 9

Tee ohjelma, joka simuloi rahan heittoa seuraavasti:
Ohjelma kysyy ensin heittojen lukumäärän n ja simuloi
sitten rahan heittoa n kertaa (0=klaava, 1=kruuna). 
Lopuksi ohjelma tulostaa saatujen klaavojen ja kruunien määrän.

Vastaus:
Rahaa on heitetty 20 kertaa.
Klaavoja tuli 6 ja kruunuja 14. 
*/
namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Heads => 0 or Tails => 1
            Console.Write("How many throws there should be: ");
            string userInput = Console.ReadLine();
            int throws;
            bool evalTest = int.TryParse(userInput, out throws);
            if (evalTest)
            {
                if (throws > 0)
                {
                    Console.WriteLine("Response");
                    Console.WriteLine("==========================");
                    Random rnd = new Random();
                    int headsCount = 0;
                    for (int i = 0; i <= throws; i++) {
                        headsCount = rnd.Next(2) == 0 ? headsCount + 1 : headsCount;
                    }
                    Console.WriteLine("{0} times has been thrown.",throws);
                    Console.WriteLine("Heads: {0}, Tails: {1}", headsCount, (throws- headsCount));
                }
                else {
                    Console.WriteLine("Positive number input for throws should have been entered!");    
                }
            }
            else {
            }
            Console.ReadKey();
        }
    }
}
