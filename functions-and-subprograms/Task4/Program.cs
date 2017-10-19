using System;
/*
Task 4

Kirjoita funktio, joka pyytää käyttäjältä 10 positiivista
kokonaislukua ja palauttaa niistä suurimman.

Funktiolle kelpaa syötteeksi vain positiiviset luvut.
Virheellisestä luvusta tulostetaan ilmoitus ja luku 
pyydetään uudestaan.
*/
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            long max = getValuesDisplayMax();
            Console.ReadKey();
        }

        static long getValuesDisplayMax() {
            int counter = 1;
            Console.WriteLine("Please enter 10 numbers. Only positive and numeric values are accepted!");
            string userInput;
            long number;
            string output = "";
            long maxValue=0;
            int position = 1;
            while (counter < 11) {
                Console.Write("{0}. ", counter);
                userInput = Console.ReadLine();
                bool evalTest = long.TryParse(userInput, out number);
                if (evalTest && number >= 0)
                {
                    if (counter == 1)
                    {
                        maxValue = number;
                        position = 1;
                    }
                    else {
                        if (number > maxValue) {
                            maxValue = number;
                            position = counter;
                        }     
                    }
                    output += (counter == 10) ? number.ToString() : number + " ";
                    counter++;
                }
                else {
                    Console.WriteLine("Incorrect input, please enter a positive number!");                    
                }
            }
            Console.WriteLine("You entered the following numbers");
            Console.WriteLine("{0}",output);
            Console.WriteLine("The max value {0} was at the {1}. position",maxValue,position);
            return maxValue;
        }
    }
}
