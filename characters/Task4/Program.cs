using System;
using System.Text.RegularExpressions;

/*
Task 4

Tee ohjelma, joka tarkastaa onko käyttäjältä
kysytty sana tai lause palintromi. 

*/
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a word: ");
            String userInput = Console.ReadLine();
            if (userInput.Length > 0)
            {
                //make input as lower case & replace all control spaces with ""
                string userInputTmp = userInput.ToLower().Trim();
                userInputTmp = Regex.Replace(userInputTmp, "[^0-9a-zA-Z]+", "");
                char[] letters = userInputTmp.ToCharArray(); //convert string into char array
                Array.Reverse(letters);  //make use of Array's Reverse
                string wordReversed = new string(letters); //convert char[] back to string
                if (wordReversed.Equals(userInputTmp)) { //just compare the two strings
                  Console.WriteLine("Word {0} is a palindrome", userInput.Trim());            
                } else {
                  Console.WriteLine("Word {0} is not a palindrome", userInput);
                }
            }
            else {
                Console.WriteLine("You didn't enter any text!");
            }
            Console.ReadKey();
        }
    }
}
