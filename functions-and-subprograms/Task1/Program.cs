using System;
/*
Task 1

Käyttäjää pyydetään kirjoittamaan ohjelmalle 1 luku.
Funktio palauttaa annetun määrän tähtiä, jotka pääohjelma tulostaa näytölle.

Esim.
Input: 3
Vastaus: ***
Input: -2
Vastaus: Numero -2 ei ole salittu luku. 
*/
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(displayStars());
            Console.ReadKey();
        }

        static string displayStars() {
            string output;
            Console.Write("Please enter the number of stars: ");
            String userInput;
            userInput = Console.ReadLine();
            int number;
            bool evalRole = int.TryParse(userInput, out number);
            if (evalRole)
            {
                if (number > 0)
                {
                    output = "Response: ";
                    for (int i = 0; i < number; i++) {
                        output += "*";
                    }
                }
                else if (number == 0) {
                    output = "No stars wanted";
                }
                else {
                    output = string.Format("Response: Number {0} is not allowed.", number);
                }
            }
            else {
              output = "Response: Invalid number format. Enter a number!";
            }
            return output;
        }
    }
}
