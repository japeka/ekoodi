using System;
/*
 Task 3

 Kirjoita funktio, joka pyytää käyttäjältä luvun annetulta väliltä
 ja tarkastaa luvun kelpoisuuden.  Mikäli luku ei ole annetulta 
 väliltä tai se ei ole numeraalinen, sitä pyydetään funktiossa uudelleen.
 Funktio palauttaa käyttäjän syöttämän luvun. Funktiota kutsutaan seuraavasti:
 luku=pyyda_luku_valilta(alaraja,ylaraja);
 */

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int lowerBound = rnd.Next(1,51);
            int upperBound = rnd.Next(51, 101);
            int number = getNumber(lowerBound, upperBound);
            if (number != -1)
            {
                Console.WriteLine("The Number: {0} is between {1} and {2}!", number, lowerBound, upperBound);
            }
            else {
                Console.WriteLine("The Number: {0} is not between {1} and {2}!", number, lowerBound, upperBound);
            }
            Console.ReadKey();
        }

        static int getNumber(int lowerBound,int upperBound) {
            bool bCorrect = true;
            String userInput;
            int number=-1;
            while (bCorrect) {
                Console.Write("Please enter a number between {0} and {1}: ", lowerBound, upperBound);
                userInput = Console.ReadLine();
                bool evalTest = int.TryParse(userInput, out number);
                if (evalTest && (number >= lowerBound && number <= upperBound))
                {
                    return number; 
                }
            }
            return number;
        }
    }
}
