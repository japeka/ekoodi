using System;
/*
Task 1

Tee ohjelma, joka ilmoittaa käyttäjän syöttämästä syötteestä
merkkien lukumäärän. esim. Input: Hello World! 
Output: Syötteessä on 12 merkkiä. * 
*/
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            String userInput;
            userInput = Console.ReadLine();
            if (userInput.Length != 0)
            {
                Console.WriteLine("{0} contains {1} characters", userInput, userInput.Length);
            }
            else {
                Console.WriteLine("You didn't enter any text!");
            }
            Console.ReadKey();
        }
    }
}
