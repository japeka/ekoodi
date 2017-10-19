using System;
/*
Task 3 / loop-statements
Tee ohjelma, joka laskee N:n ensimmäisen parittoman ja parillisen lukujen summan.
N:n arvo kysytään käyttäjältä.
Esim.
Input: 10
Vastaus: Parittomien summa = 25, Parillisten summa = 30
N=10 : 1+3+5+7+9=25 ja 2+4+6+8+10=30 
*/

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bTrue = true;
            string userInput;
            int number;
            bool evalTest;
            Console.WriteLine("******************************************************************");
            Console.WriteLine("Sum of even, odd numbers. Invalid input terminates the program flow!");
            Console.WriteLine("******************************************************************");
            while (bTrue)
            {
                Console.Write("Enter number input: ");
                userInput = Console.ReadLine();
                evalTest = int.TryParse(userInput, out number);
                if (evalTest)
                {
                    if (number > 0)
                    {
                        long sumOdd = 0;
                        long sumEven = 0;
                        for (int i = 1; i <= number; i++)
                        {

                            if (i % 2 == 0)
                            {
                                sumEven = sumEven + i;
                            }
                            else
                            {
                                sumOdd = sumOdd + i;
                            }
                        }
                        Console.WriteLine("Response: Sum of odd numbers = {0}, sum of even numbers = {1}, ", sumOdd, sumEven);
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
