using System;
/*
Task 3

Tee ohjelma, joka laskee käyttäjän syöttämästä
syötteestä vaikkapa L kirjainten lukumäärän
*/
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Your input: ");
            String userInput = Console.ReadLine();
            if (userInput.Length > 0)
            {
                string userInputTmp = userInput.ToLower();
                int counter = 0;
                char letter = 'l';
                for (int i = 0; i < userInputTmp.Length; i++) {
                    counter = userInputTmp[i].Equals(letter) ? counter+1 : counter;
                }
                Console.WriteLine("There were {0} l or L letter(s) in {1}",counter,userInput);
            }
            else {
                Console.WriteLine("You didn't enter any text!");
            }
            Console.ReadKey();
        }
    }
}
