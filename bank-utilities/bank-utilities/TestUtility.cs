using System;
using bank_utilities;
namespace Ekoodi.Utilities.Test {
    public static class TestUtility {

        public static void TestBankBarcode() {

            Console.WriteLine("Bank Bar Code Generator calculates the bar code\nusing either national (Finnish) or international reference number.\n");
            Console.WriteLine("To calculate the bar code\nuse 1) national or 2) international reference number of the invoice as basis");
            Console.Write("Enter your selection: ");
            string userSelection = Console.ReadLine();
            int nSelection;
            bool evalTest = int.TryParse(userSelection, out nSelection);
            BankBarcode bankBarcode = new BankBarcode();
            bankBarcode.handleUserInputs(evalTest, nSelection);
        }

        public static void TestInternationalReferenceNumber() {
            //string internReferenceNum = "RF332348236";
            Console.Write("Enter international reference number: ");
            string internReferenceNum = Console.ReadLine();
            //viitenumeron tarkistaminen
            InternationalReferenceNumber internRefNum = new InternationalReferenceNumber(internReferenceNum);
            if (internRefNum.isValidReferenceNumber()) {
              Console.WriteLine("{0} is a valid reference number", internReferenceNum);
            } else {
              Console.WriteLine("{0} is not valid reference number", internReferenceNum);
            }

            //viitenumeron generointi suomalaisen viitenumeron pohjalta
            Console.WriteLine("In order to generate international ref.number\nfinnish ref.number must be given");
            Console.Write("Enter finnish reference number: ");
            string rfNumber = Console.ReadLine();
            FinnishReferenceNumber finRefNum = new FinnishReferenceNumber(rfNumber);
            if (finRefNum.checkRefCode()) {
                string s = finRefNum.formatRefNum();
                InternationalReferenceNumber generateNewRefNum = new InternationalReferenceNumber();
                generateNewRefNum.setRefBase(finRefNum.unFormatRefNum(s));
                if (generateNewRefNum.generateInternRefNumber()) {
                   Console.WriteLine("International Reference Number: {0}", generateNewRefNum.formatRefNumber());
                } else {
                   Console.WriteLine("\nGeneration failed!");
                }
            } else {
               Console.WriteLine("{0} is not a valid Finnish reference number", rfNumber);
            }
            Console.ReadKey();
        }

        public static void TestFinnishReferenceNumber() {
            int selection = 0;
            int noOfBase = 0;
            string sNoOfBase;
            bool evalTest = false;
            string rfNumber;
            Console.WriteLine("Reference Number Checker & Generator");
            while (selection != 3) {
                Console.WriteLine("1) Check the validity of your reference number");
                Console.WriteLine("2) Generate some reference numbers");
                Console.WriteLine("3) Exit");
                Console.Write("Your selection: ");
                string sel = Console.ReadLine();
                evalTest = int.TryParse(sel,out selection);
                if (evalTest && selection == 1) {
                  Console.Write("Please enter reference number: ");
                  rfNumber = Console.ReadLine();
                  try {
                    FinnishReferenceNumber rfGenerator = new FinnishReferenceNumber(rfNumber);
                    if (rfGenerator.checkRefCode()) {
                     Console.WriteLine("\n{0} - OK\n", rfGenerator.formatRefNum());
                    } else {
                      Console.WriteLine("\nReferencenumber Incorrect\n");
                    }
                  } catch (ArgumentException) {
                     Console.WriteLine("\nReferencenumber Incorrect\n");
                  }
                } else if (evalTest && selection == 2) {
                    Console.Write("Please enter reference number base: ");
                    rfNumber = Console.ReadLine();
                    Console.Write("Please enter amount of referencenumbers (max = 100): ");
                    sNoOfBase = Console.ReadLine();
                    if (int.TryParse(sNoOfBase, out noOfBase) && noOfBase > 0 && noOfBase <= 100) {
                        try {
                            FinnishReferenceNumber rfGenerator = new FinnishReferenceNumber(rfNumber, noOfBase);
                            rfGenerator.generateAndDisplayRefNumbers();
                        } catch (ArgumentException) {
                            Console.WriteLine("\nReferencenumber Incorrect\n");
                        }
                    }
                    else {
                        Console.WriteLine("\nReferencenumber Incorrect. Max amount = 100\n");
                    }
                }
            }
            Console.WriteLine("Program terminated");
            Console.ReadKey();
        }

        public static void TestIBANCalculator() {
            Console.Write("Please enter your BBAN number: ");
            string userInput = Console.ReadLine();
            Console.Write("Please enter your country code (FI supported only): ");
            string userInputCountry = Console.ReadLine();
            userInputCountry = userInputCountry.Equals("FI") ? userInputCountry : "FI";
            BBanValidator accountNumber;
            try
            {
                accountNumber = new BBanValidator(userInput);
                if (accountNumber.examineAccountNumber() && accountNumber.copyNumbersToOutputArray() && accountNumber.hasValidCheckerSum()) {
                    string output = new string(accountNumber.getOutputCharArray());
                    IBANCalculator ibanCalculator = new IBANCalculator(output);
                    if (ibanCalculator.addCountryCode(userInputCountry,"00"))  {
                        if (ibanCalculator.replaceLettersWithNumbers()) {
                            if (ibanCalculator.validateCheckSum()) {
                              Console.WriteLine("IBAN Formatted Number: {0}\nBIC Code: {1}", ibanCalculator.getIbanNumber(), ibanCalculator.getBICCode());           
                            } else {
                              Console.WriteLine("Invalid Bank Account Number!");
                            }
                        }  else {
                            Console.WriteLine("Invalid Bank Account Number!");
                        }
                    } else {
                        Console.WriteLine("Invalid Bank Account Number!");
                    }
                } else {
                    Console.WriteLine("Invalid Bank Account Number!");
                }
            } catch (System.ArgumentException) {
                Console.WriteLine("Invalid Bank Account Number!");
            }
            Console.ReadKey();
        }

        public static void TestBBANValidator() {
            Console.Write("Please enter a valid bank account number: ");
            string userInput = Console.ReadLine();
            BBanValidator accountNumber;
            try {
              accountNumber = new BBanValidator(userInput);
              if (accountNumber.examineAccountNumber()) {
                 if (accountNumber.copyNumbersToOutputArray()) {
                    if (accountNumber.hasValidCheckerSum()) {
                      Tuple<int,string> tuple = accountNumber.returnBankGroup();
                      Console.WriteLine("\nResult:\nBank Account Number {0} is valid.\nIt is owned by {1}", accountNumber, tuple.Item2);
                    } else {
                      Console.WriteLine("Invalid Bank Account Number!");
                    }
                  } else {
                    Console.WriteLine("Invalid Bank Account Number!");
                  }
                } else {
                   Console.WriteLine("Invalid Bank Account Number!");
                }
            } catch (System.ArgumentException) {
              Console.WriteLine("Invalid Bank Account Number!");
            }
        }
    }
}