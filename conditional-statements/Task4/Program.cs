using System;
/*
Task 4
Käyttäjältä pyydetään 3 lukua.
Ohjelma lajittelee luvut nousevaan järjestykseen.
Esim. Input: 4, 8, 2 Vastaus: 2, 4, 8
*/
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = getUserInputs();
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("{0}", arr[i]);
                }
            }
            else {
                Console.WriteLine("Invalid number was entered. Only numbers are accepted!");
            }
            Console.ReadKey();
        }

        /* getUserInputs method */
        static int[] getUserInputs() {
            int[] arr = new int[3];
            String userInput;
            int number;
            bool evalTest;
            for (int i = 0; i < 3; i++) {
                Console.Write("Enter {0}. number: ", (i + 1));
                userInput = Console.ReadLine();
                evalTest = int.TryParse(userInput, out number);
                if (evalTest)
                {
                    arr[i] = number;
                }
                else {
                    return null;
                }
            }
            return sortArray(arr);
        }
        /* sortArray method */
        static int[] sortArray(int[] arr) {
            for (int i = 0; i < arr.Length; i++)
            {
                int j = i;
                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (arr[k] < arr[i])
                        j = k;
                    int t = arr[i]; arr[i] = arr[j]; arr[j] = t;
                    j = i;
                }
            }
            return arr;
        }
    }
}
