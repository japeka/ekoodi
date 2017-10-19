using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Collections;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace bank_utilities
{
    class IBANCalculator
    {
        private string bbanAccountNumber;
        private string bbanAccountNumberOriginal;
        private string countryCode;
        private string validCheckSum;
        private List<int> ibanAsList = new List<int>();
        private string validIbanString;
        private string validIbanCountryString;

        public IBANCalculator() { }
        public IBANCalculator(string bbanAccountNumber) {
          this.bbanAccountNumber = bbanAccountNumber;
          this.bbanAccountNumberOriginal = bbanAccountNumber;
        }

        private string returnBICCode(string sNum) {
            List<BicCode> bicCodes = new List<BicCode>();
              try {
                using (var fs = new FileStream(@"C:/devi/ECODE/BankUtilities/bank-utilities/bic-codes.json", FileMode.Open, FileAccess.Read))
                    using (var sr = new System.IO.StreamReader(fs))
                    {
                      string json = sr.ReadToEnd();
                      bicCodes = JsonConvert.DeserializeObject<List<BicCode>>(json);
                    }
                return bicCodes.Count != 0 ? bicCodes.Find(c => c.Id == sNum).Name : "BIC Code not found";
            }
            catch (System.IO.FileNotFoundException e) {
                return "BIC Code not found";
            }
        }

        public List<int> getIBANAsList() {
            return this.ibanAsList;
        }

        public bool addCountryCode(string countryCode,string prefix) {
            this.countryCode = countryCode;
            this.bbanAccountNumber += countryCode+prefix.ToUpper();
            if (this.bbanAccountNumber.Length > 14)
                return true;
            else
                return false;
        }

        public string getIbanNumber() {
            string ibanNoStr = this.countryCode + this.validCheckSum + this.bbanAccountNumberOriginal;
            string output="";
            for (int i = 0, j=1; i < ibanNoStr.Length; i++,j++) {
                if (j % 4 == 0) {
                  output += ibanNoStr[i].ToString() + " ";
                } else {
                  output+=ibanNoStr[i].ToString();
                }
            }
            return output;
        }

        public string getBICCode() {
            string firstThree = this.bbanAccountNumberOriginal.Substring(0, 3);
            string sBankNum;
            if (firstThree[0] == '3') { //2 digits
                sBankNum = firstThree.Substring(0, 2);
            }
            else if (firstThree[0] == '4' || firstThree[0] == '7')  { //3 digits
                sBankNum = firstThree;
            }
            else { //1 digit
                sBankNum = firstThree[0].ToString();
            }

            if (sBankNum.Length > 0) {
                return returnBICCode(sBankNum);
            }
            else
                return "BIC Code not found!";
        }


        public bool validateCheckSum() {
            string str = string.Join("", this.ibanAsList.ToArray());
            BigInteger num = new BigInteger();
            bool evalTest = BigInteger.TryParse(str, out num);
            if (evalTest) {
                BigInteger subtraction = (98 - (num % 97));
                if (subtraction < 10) {
                    this.validCheckSum = "0" + subtraction;
                } else {
                    this.validCheckSum = subtraction.ToString();
                }
                return true;
            } else {
                return false;
            }
        }

        public bool isIBANValidRegex(string regex)
        {
            Regex expression = new Regex(@"(?<country>FI)(?<iban>\d{16})");
            Match match = expression.Match(regex);
            if (match.Success)
            {
                this.validIbanString = match.Groups["iban"].Value;
                this.validIbanCountryString = match.Groups["country"].Value;
                return true;
            }
            return false;
        }

        public string getValidIbanString() {
            return this.validIbanString;
        }

        public bool validateIBAN(string code) {
            if (isIBANValidRegex(code)) {
                string output = this.validIbanString.Substring(2) + this.validIbanCountryString + this.validIbanString.Substring(0, 2);
                string tmp = "";
                for (int i = 0; i < output.Length; i++) {
                    tmp += getNumberForALetter(output[i]);
                }
                BigInteger big = new BigInteger();
                bool evalTest = BigInteger.TryParse(tmp,out big);
                return evalTest && (big % 97 == 1);             
            }
            return false;
        }

        public bool replaceLettersWithNumbers() {
            bool isChar = false;
            bool evalTest=false; int value;
            for (int i = 0; i < this.bbanAccountNumber.Length; i++) {
                isChar = char.IsLetter(this.bbanAccountNumber[i]);
                if (isChar) {
                    int numForLetter = getNumberForALetter(this.bbanAccountNumber[i]);
                    this.ibanAsList.Add(numForLetter);
                }  else {
                    evalTest = int.TryParse(this.bbanAccountNumber[i].ToString(), out value);
                    if (evalTest) {
                      this.ibanAsList.Add(value);
                    } else {
                      return false;
                    }
                }
            }

            if (this.ibanAsList.Capacity != 0) {
                return true;
            }
            return false;
        }

        private int getNumberForALetter(char letter) {
            int nNum;
            int.TryParse(letter.ToString(),out nNum);
            return char.IsLetter(letter) ? ((int)letter - 55) : nNum;
        }
    }
}
