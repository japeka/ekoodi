using System;

/*
TASK 2 / loop-statements
Tee ohjelma, joka laskee N ensimmäistä lukua yhteen.

N:n arvo kysytään käyttäjältä.
Ohjelman tulee tarkistaa, että N on vähintään 1
Esim.
Input: 10 (N=10 : 1+2+3+4+5+6+7+8+9+10=55)
Vastaus: 55
*/

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bTrue = true;
            string userInput;
            int number;
            bool evalTest;
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Sum of numbers. Invalid input terminates the program flow!");
            Console.WriteLine("**********************************************************");
            while (bTrue)
            {
                Console.Write("Enter number input: ");
                userInput = Console.ReadLine();
                evalTest = int.TryParse(userInput, out number);
                if (evalTest)
                {
                    if (number > 0)
                    {
                        long sum = 0;
                        for (int i = 1; i <= number; i++)
                        {
                            sum = sum + i;
                        }
                        Console.WriteLine("Response: {0}", sum);
                    }
                    else
                    {
                        Console.WriteLine("Number needs to greater than 0!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number input!");
                    bTrue = false;
                }
            }
            Console.WriteLine("End of program!");
            Console.ReadKey();

        }
    }
}
