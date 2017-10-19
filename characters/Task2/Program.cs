using System;
/*
Task 2

Tee ohjelma, joka muuttaa käyttäjän
syöttämästä syötteestä e kirjaimet @ merkiksi. 
*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            String userInput = Console.ReadLine();
            if (userInput.Length > 0)
            {
                Console.WriteLine("Output: {0}",userInput.Replace("e","@"));
            }
            else {
                Console.WriteLine("You didn't enter any text!");
            }
            Console.ReadKey();
        }
    }
}
