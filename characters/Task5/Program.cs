using System;
/*
Task 5 

Tee ohjelma, joka laskee käyttäjän
syöttämästä tiedosta vokaalien lukumäärän.
*/
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            String userInput = Console.ReadLine().ToLower();
            if (userInput.Length > 0)
            {
                int n = getNumberOfVowels(userInput);
                Console.WriteLine("There were {0} vowels in {1}", n, userInput);
            }
            else {
                Console.WriteLine("You didn't enter any text!");
            }
            Console.ReadKey();
        }

        static int getNumberOfVowels(string inputChArr) {
            string vowels = getVowels();
            int counter = 0;
            for (int i = 0; i < inputChArr.Length; i++) {
                counter = vowels.IndexOf(inputChArr[i]) != -1 ? counter+1 : counter;
            }
            return counter;
        }

        static string getVowels() {
            return "aeiouyäöå";
        }
    }
}
