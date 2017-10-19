using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace bank_utilities {

    class BankBarcode {
        private bool isRefNumNational = false;
        private string ibanString;
        private string versionNumber;
        private string inReservation="";

        private string amountInEuros;
        private string amountInCents;

        private string referenceNumber;
        private string dueDate;
        private string allCombined;
        private int checkSum;

        public BankBarcode() { }

        private string paddifyString(string str,int amount) {
            string output = "";
            for (int i = 0; i < amount; i++) {
                output += "0";
            }
            return output + str;
        }

        public bool amountRegValid(string str) {
            Regex expression = new Regex(@"^(?<euros>\d{0,6})[,.](?<cents>\d{0,2})$");
            Match match = expression.Match(str);
            if (match.Success) {
                this.amountInEuros = paddifyString(match.Groups["euros"].Value, (6 - match.Groups["euros"].Value.Length));
                this.amountInCents = paddifyString(match.Groups["cents"].Value, (2 - match.Groups["cents"].Value.Length));
                if (this.amountInEuros.Length == 6 && this.amountInCents.Length == 2) {
                    return true;
                }
            }
            return false;
        }

        private bool dueDateRegValid(string str) {
            Regex expression = new Regex(@"^(?<dd>\d{1,2})[.](?<mm>\d{1,2})[.](?<yy>\d{2})$");
            Match match = expression.Match(str);
            if (match.Success) {
                int dd, mm, yy;
                bool bDD, bMM, bYY;
                bDD = int.TryParse(match.Groups["dd"].Value, out dd);
                bMM = int.TryParse(match.Groups["mm"].Value, out mm);
                bYY = int.TryParse(match.Groups["yy"].Value, out yy);
                if (bDD && bMM && bYY) {
                    if (dd == 0 && mm == 0 && yy == 0) {
                      this.dueDate = "000000";
                      return true;
                    } else if (dd > 0 && dd <=31 && mm >= 1 && mm<=12 && yy >= 10) {
                        string sDD = match.Groups["dd"].Value;
                        if (dd < 10) { sDD ="0"+ sDD; }
                        string sMM = match.Groups["mm"].Value;
                        if (mm < 10) { sMM = "0" + sMM; }
                        this.dueDate = match.Groups["yy"].Value + sMM + sDD;
                        return true;
                    } 
                }
            }
            Console.WriteLine("Invalid Due Date");
            return false;
        }

        private bool combineInputs() {
            string output = this.versionNumber + ibanString + amountInEuros + amountInCents + inReservation + referenceNumber + dueDate;
            if (output.Length == 54) {
              this.allCombined = output;
              Console.WriteLine("Bar code: {0}", this.allCombined);
              return true;
            }
            return false;
        }
        
        public bool handleUserInputs(bool evalTest, int nSelection) {
            string sIbanNumber;
            if (evalTest && nSelection == 1) {
                this.isRefNumNational = true;
                this.versionNumber = "4";
                this.inReservation = "000";
                Console.Write("Please Enter IBAN formatted account number: ");
                sIbanNumber = Console.ReadLine(); //iban number FI
                IBANCalculator ibanCalc = new IBANCalculator();
                bool isValid = ibanCalc.validateIBAN(sIbanNumber);
                if (isValid) {
                    this.ibanString = ibanCalc.getValidIbanString();
                    Console.Write("Please enter invoice amount (ex. 1,20 or 1.20): ");
                    if (amountRegValid(Console.ReadLine())) {
                        Console.Write("Please enter national reference number: ");
                        string rfNumber = Console.ReadLine();
                        try {
                            FinnishReferenceNumber rfGenerator = new FinnishReferenceNumber(rfNumber);
                            if (rfGenerator.checkRefCode())
                            {
                                this.referenceNumber = rfGenerator.getReferenceCode();
                                this.referenceNumber = this.paddifyString(this.referenceNumber, (20 - this.referenceNumber.Length));
                                Console.Write("Please enter a due date (dd.mm.yy): ");
                                if (dueDateRegValid(Console.ReadLine())) {
                                  if (!this.combineInputs()) {
                                      Console.WriteLine("Length of the output barcode must be 54");
                                      return false;
                                  }
                                }
                            }
                            else  {
                                Console.WriteLine("\nReferencenumber Incorrect\n");
                                return false;
                            }
                        } catch (ArgumentException) {
                            Console.WriteLine("\nReferencenumber Incorrect\n");
                            return false;
                        }
                        return true;
                    } else {
                        Console.WriteLine("Amount not given correctly!");
                        return false;
                    }
                } else {
                    Console.WriteLine("Invalid Iban");
                    return false;
                }
            } else if (evalTest && nSelection == 2) {
                this.isRefNumNational = false;
                this.versionNumber = "5";
                Console.Write("Please Enter IBAN formatted account number: ");
                sIbanNumber = Console.ReadLine(); //iban number FI
                IBANCalculator ibanCalc = new IBANCalculator();
                bool isValid = ibanCalc.validateIBAN(sIbanNumber);
                if (isValid) {
                    this.ibanString = ibanCalc.getValidIbanString();
                    Console.Write("Please enter invoice amount: ");
                    if (amountRegValid(Console.ReadLine()))
                    {
                        Console.Write("Please enter international reference number: ");
                        string rfNumber = Console.ReadLine();
                        try {
                            InternationalReferenceNumber internRefNum = new InternationalReferenceNumber(rfNumber);
                            if (internRefNum.isValidReferenceNumber()) {
                                rfNumber = rfNumber.Substring(2);
                                string output = rfNumber.Substring(0, 2);
                                int nZeros = 23 - rfNumber.Length;
                                for (int i = 0; i < nZeros; i++) {
                                  output += "0";
                                }
                                output += rfNumber.Substring(2);
                                this.referenceNumber = output;
                                Console.Write("Please enter a due date (dd.mm.yy): ");
                                if (dueDateRegValid(Console.ReadLine())) {
                                  if (!this.combineInputs()) {
                                    Console.WriteLine("Length of the output barcode must be 54");
                                    return false;
                                  }
                                }
                            } else {
                              Console.WriteLine("\nReferencenumber Incorrect\n");
                              return false;
                            }
                        } catch (ArgumentException)  {
                          Console.WriteLine("\nReferencenumber Incorrect\n");
                          return false;
                        }
                        return true;
                    } else {
                        Console.WriteLine("Amount not given correctly!");
                    }
                    return false;
                } else {
                    Console.WriteLine("Invalid Iban");
                    return false;
                }
            } else {
                Console.WriteLine("Invalid selection entered");
                return false;
            }
        }
    }
}
