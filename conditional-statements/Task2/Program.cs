using System;
/*
Task 2 / Janne Kalliokulju

Käyttäjää pyydetään kirjoittamaan ohjelmalle 1 luku.
Ohjelma tulostaa parillinen tai pariton.
Esim. Input: 3 Vastaus: Numero 3 on pariton
Input: 2 Vastaus: Numero 2 on parillinen     

*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for even or odd input
            Console.Write("Please enter a number: ");

            // Read user input
            String userInput;
            userInput = Console.ReadLine();

            //Evaluate user input
            int number;

            //use TryParse to check if input is valid
            bool evalTest = int.TryParse(userInput, out number);
            if (evalTest)
            {
                Console.WriteLine(number % 2 == 0 ? "Number {0} is even" : "Number {0} is odd", number);
            }
            else {
                Console.WriteLine("{0} is not a valid number input", userInput);
            }
            Console.ReadKey();
        }
    }
}