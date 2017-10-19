using System;

/*
 Tee ohjelma, joka tulostaa N! kertoman arvon eli
 5! = 1*2*3*4*5
 10! = 1*2*3*4*5*6*7*8*9*10
jne.
Ohjelman tulee tarkistaa, että N on vähintään 1 N:n arvo kysytään käyttäjältä.

Esim.
Input: 5
Vastaus: 120

Input: 0
Vastaus: 1

Input: -5
Vastaus: Määrittelemätön
     */

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Factorial calculator");
            Console.WriteLine("The program keeps asking numbers for calculating");
            Console.WriteLine("factorials until invalid input (such as a character) is\n entered as input!");
            Console.WriteLine("********************************************************");
            bool bTrue = true;
            String userInput;
            int number;
            bool evalTest;
            while (bTrue) {
                Console.Write("Enter number input: ");
                userInput = Console.ReadLine();
                evalTest = int.TryParse(userInput, out number);
                if (evalTest)
                {
                    if (number == 1)
                    {
                        Console.WriteLine("Response: {0}", number);
                    }
                    else if (number > 1)
                    {
                        long sum = 1;
                        for (int i = 1; i <= number; i++) {
                            sum =+ (sum * i);
                        }
                        Console.WriteLine("Response: {0}", sum);
                    }
                    else {
                        Console.WriteLine("Response: Undefined");
                    }
                }
                else {
                    Console.WriteLine("Response: Undefined");
                    bTrue = false;
                }
            }
            Console.WriteLine("End of the program!");
            Console.ReadKey();

        }
    }
}
