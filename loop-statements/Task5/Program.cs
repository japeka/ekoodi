using System;
/*
Task 5

Muokkaa ohjelmaa 3 niin, että se laskee myös negatiivisilla numeroilla.
Esim.
Input: 10
Vastaus: Parittomien summa = 25, Parillisten summa = 30
Input: -10
Vastaus: Parittomien summa = -25, Parillisten summa = -30
N=-10 : (-1)+(-3)+(-5)+(-7)+(-9)=-25 ja (-2)+(-4)+(-6)+(-8)+(-10)=-30      
Satunnaisgeneraattorilla arvotaan lukujen määrä sekä se, onko luku negatiivinen
tai positiivinen
*/
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //use Random generator
            Random rnd = new Random();
            //generate numbers till 100
            int N = rnd.Next(101);
            //generate whether number is neg. or positive
            //0 => negative and 1 => positive
            int op = rnd.Next(2);
            int multiplier = op == 0 ? -1 : 1;
            long sumOdd = 0; long sumEven = 0;
            for (int i = 1; i <= N; i++) {
                if (i % 2 == 0)
                {
                    sumEven = sumEven + (multiplier * i);
                }
                else {
                    sumOdd = sumOdd + (multiplier * i);
                }
            }
            Console.WriteLine("Response: N: {0}\nSum for even numbers: {1}\nSum for odd numbers: {2} ",(N* multiplier), sumEven,sumOdd);
            Console.ReadKey();
        }
    }
}
