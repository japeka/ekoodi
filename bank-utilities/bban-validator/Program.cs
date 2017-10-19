using System;
using Ekoodi.Utilities.Test;

namespace bban_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestUtility.TestBBANValidator();
            TestUtility.TestIBANCalculator();
            //TestUtility.TestFinnishReferenceNumber();
            //TestUtility.TestInternationalReferenceNumber();
            //TestUtility.TestBankBarcode();
            Console.ReadKey();
        }
    }
}
