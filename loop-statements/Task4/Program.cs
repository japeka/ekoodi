using System;
/*
Task 4 / loop-statements

Muokkaa ohjelmaa 2 niin, että se laskee myös negatiivisilla numeroilla.
Esim.
Input: 10 (N=10 : 1+2+3+4+5+6+7+8+9+10=55)
Vastaus: 55
Input -10 [N=-10 : (-1)+(-2)+(-3)+(-4)+(-5)+(-6)+(-7)+(-8)+(-9)+(-10)=-55]
Vastaus: -55
*/
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            bool bTrue = true;
            string userInput;
            int number;
            bool evalTest;
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Sum of numbers including negative numbers. Invalid input terminates the program flow!");
            Console.WriteLine("*************************************************************************************");
            while (bTrue)
            {
                Console.Write("Enter number input: ");
                userInput = Console.ReadLine();
                evalTest = int.TryParse(userInput, out number);
                if (evalTest)
                {
                    int multiplier = number < 0 ?  -1 : 1;
                    int counter = number < 0 ? -1 * number : number;
                    long sum = 0;
                    for (int i = 1; i <= counter; i++)
                    {
                        sum =  sum + (multiplier * i);
                    }
                    Console.WriteLine("Result: {0}", sum);
                }
                else {
                    Console.WriteLine("Invalid number input!");
                    bTrue = false;
                }
            }
            }
        }
}
