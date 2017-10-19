using System;

/*
Task 3

Yhdistä 1 ja 2.
Esim. Input: 3 Vastaus: Numero 3 on positiivinen ja pariton
Esim. Input: -2 Vastaus: Numero -2 on negatiivinen ja parillinen
Esim. Input: 0 Vastaus: Numero 0 on nolla ja parillinen

*/

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {

            // Prompt user
            Console.Write("Enter a number: ");

            // Read user input
            String userInput;
            userInput = Console.ReadLine();

            //Evaluate user input
            int number;

            //use TryParse to check if input is valid
            bool evalTest = int.TryParse(userInput, out number);

            if (evalTest)
            {
                Console.WriteLine("{0}{1}", checkNumberValue(number), isEven(number));
            }
            else
            { // User input not entered as a number
                Console.WriteLine("{0} is not accepted. Number format is expected", userInput);
            }

            Console.ReadKey();

        }

        static string isEven(int number) {
            return number % 2 == 0 ? " and even" : " and odd";
        }

        static string checkNumberValue(int number)
        {
            string output;
            if (number < 0) // IF < 0
            {
                output = "Number {0} is {1}";
                output = string.Format(output, number, "negative");
            }
            else if (number == 0) // IF == 0
            {
                output = "Number {0} is {1}";
                output = string.Format(output, number,"zero");
            }
            else // IF > 0
            {
                output = "Number {0} is {1}";
                output = string.Format(output, number, "positive");
            }
            return output;
        }

    }
}
