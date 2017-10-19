using System;
/*
     TASK 1 / Janne Kalliokulju
     1. Käyttäjää pyydetään kirjoittamaan ohjelmalle 1 luku.
     Ohjelma tulostaa positiivinen, negatiivinen tai nolla.
     Esim. Input: 3 Vastaus: Numero 3 on positiivinen.
        Input: -2 Vastaus: Numero -2 on negatiivinen.
        Input: 0 Vastaus: Numero 0 on nolla.
     Muuttujat kaikki englannin kielellä
*/
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Prompt user
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
                if (number < 0) // IF < 0
                {
                    Console.WriteLine("Number {0} is negative " , number);
                }
                else if (number == 0) // IF == 0
                {
                    Console.WriteLine("Number {0} is zero ", number);
                }
                else // IF < 0
                {
                    Console.WriteLine("Number {0} is positive ", number);
                }
            }
            else
            { // User input not entered as a number
                Console.WriteLine("{0} is not accepted. Number format is expected", userInput);
            }

            //Wait for user input
            Console.ReadKey();
        }
    }
}
