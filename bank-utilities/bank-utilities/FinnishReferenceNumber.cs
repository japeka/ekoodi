using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace bank_utilities
{
    class FinnishReferenceNumber {
        private string referenceNumber;
        private int noOfBase;
        private int refSubtraction;

        public FinnishReferenceNumber(string rfNumber,int noOfBase=0) {
            if (!isValid(rfNumber,noOfBase))
                throw new ArgumentException("Illegal reference number");

            this.noOfBase = noOfBase;
            this.referenceNumber = rfNumber;
        }

        public string unFormatRefNum(string s) {
            return Regex.Replace(s, "[^0-9a-zA-Z]+", "");
        }

        public string formatRefNum() {
            string noZerosStart = this.referenceNumber.TrimStart('0');
            int sub = noZerosStart.Length - (5 * ((int)(noZerosStart.Length / 5)));
            string output = ""; int j = 0;
            for (int i = 0; i < noZerosStart.Length; i++)  {
                if (i < sub)  {
                    output += noZerosStart[i];
                } else  {
                    if (j % 5 == 0)  {
                        output += " " + noZerosStart[i];
                    } else  {
                        output += noZerosStart[i];
                    }
                    j++;
                }
            }
            return output;
        }

        public void generateAndDisplayRefNumbers() {
            int counter = 1;
            int refCode = -1;
            string tmp = "";
            Console.WriteLine("\nGenerated referencenumbers:");
            while (counter < (this.noOfBase + 1)) {
                tmp = this.referenceNumber;
                this.referenceNumber = this.referenceNumber + counter; 
                refCode = this.getRefCode();
                refCode = refCode == 10 ? 0 : refCode;
                if(refCode != -1) {
                 this.referenceNumber = this.referenceNumber + refCode;
                 Console.WriteLine("{0}.\t{1}", counter, this.formatRefNum());
                 counter++;
                }
                this.referenceNumber = tmp;
            }
        }

        public string getReferenceCode() {
            return this.referenceNumber;
        }

        public int getRefCode() {
          int sum = 0;
          int[] mults = new int[3] { 7, 3, 1 };
          bool evalTest1 = false; bool evalTest2 = false;
          int num1, num2;
          for (int i = referenceNumber.Length - 1, j = 0; i >= 0; i--, j++) {
            evalTest1 = int.TryParse(mults[j].ToString(), out num1);
            evalTest2 = int.TryParse(referenceNumber[i].ToString(), out num2);
            if (evalTest1 && evalTest2)  {
              sum = (sum + (num1 * num2));
            } else {
              return -1;
            }
            j = (j == 2) ? -1 : j;
          }
          int subtraction = (((int)(sum / 10)) + 1) * 10 - sum;
          return subtraction;
        }

        public bool checkRefCode() {
            if (referenceNumber.Length > 3) {
                char lastNumber = referenceNumber[referenceNumber.Length-1];
                string refNumber = referenceNumber.TrimEnd(lastNumber);
                int sum = 0;
                int[] mults = new int[3] {7,3,1};
                bool evalTest1 = false; bool evalTest2 = false;
                int num1, num2;
                for (int i = refNumber.Length-1, j=0; i >=0; i--,j++) {
                    evalTest1 = int.TryParse(mults[j].ToString(), out num1);
                    evalTest2 = int.TryParse(refNumber[i].ToString(), out num2);
                    if (evalTest1 && evalTest2) {
                       sum = (sum +(num1 * num2));
                    } else {
                      return false;
                    }
                    j = (j == 2) ? -1 : j;
                }
                int subtraction = (((int)(sum / 10)) + 1) * 10 - sum;
                this.refSubtraction = subtraction;
                evalTest1 = int.TryParse(lastNumber.ToString(), out num1);
                return evalTest1 && num1 == this.refSubtraction;
            }
            return false;
        }

        private bool isValid(string rfNumber,long noOfBase) {
            if (noOfBase == 0) { 
              return Regex.IsMatch(rfNumber, @"^\d{4,20}$");
            } else {
                string s = rfNumber + noOfBase.ToString();
                return Regex.IsMatch(s, @"^\d{3,19}$");
            }
        }
    }
}
