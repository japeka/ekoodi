using System;
/*
Task 2

Kirjoita funktio minimi(), joka palauttaa arvonaan
kahdesta annetusta luvusta pienemmän.
Luvut välitetään funktiolle parametrina. 
*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            String userInputFirst;
            userInputFirst = Console.ReadLine();
            int numFirst;
            bool evalnumFirstTest = int.TryParse(userInputFirst, out numFirst);

            Console.Write("Enter the second number: ");
            String userInputSecond;
            userInputSecond = Console.ReadLine();
            int numSecond;
            bool evalnumSecondTest = int.TryParse(userInputSecond, out numSecond);

            if (evalnumFirstTest && evalnumSecondTest)
            {
                Console.WriteLine("The minimum value: {0}", getMin(numFirst, numSecond));
            }
            else {
                Console.Write("Both numbers has to be given as numbers!");
            }
            Console.ReadKey();
        }

        static int getMin(int first,int second) {
            return Math.Min(first, second);
            //return first >= second ? second : first;
        }

    }
}
