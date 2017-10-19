using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
/*
BBAN-account number checker
Toteuta C#-ohjelmointikielellä .NET Core konsolisovellus, joka muuntaa käyttäjän
syöttämän BBAN-muotoisen tilinumeron konekieliseen muotoon ja tarkistaa syötetyn
tilinumeron tarkisteen. 
*/
namespace bank_utilities
{
    class BBanValidator
    {
        private string inputAccountNumber;
        private char[] inputAccountNumberArr;
        private char[] outputAccountNumberArr = new char[14] { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0'};
        private Tuple<int, string> bankGroup;

        public BBanValidator(string inputAccountNumber) {
            if (!isValidNumber(inputAccountNumber)) {
                throw new System.ArgumentException("Invalid backAccount number!");
            }
            this.inputAccountNumber = inputAccountNumber;
            this.inputAccountNumberArr = inputAccountNumber.ToCharArray();
        }

        public char[] getOutputCharArray() {
            return this.outputAccountNumberArr;
        }

        public bool examineAccountNumber() {
             return getBankGroup(this.inputAccountNumber.Substring(0,2));
        }

        public bool hasValidCheckerSum() {
            char currentChecker = this.outputAccountNumberArr[outputAccountNumberArr.Length-1];
            int multiplier = 2;
            int value = 0;
            int value1 = 0;
            bool bSuccess = false;
            bool bSuccess1 = false;
            int production = 0;
            string sProduction;
            int sum = 0; 
            for (int i = this.outputAccountNumberArr.Length - 2, j = 0; i >= 0; i--,j++) {
                multiplier = (j % 2 == 0) ? 2  : 1;
                bSuccess = int.TryParse(this.outputAccountNumberArr[i].ToString(), out value);
                if (bSuccess) {
                    production = value * multiplier;
                    if (production > 9) {
                       sProduction = production.ToString();
                       bSuccess = int.TryParse(sProduction[0].ToString(), out value);
                       bSuccess1 = int.TryParse(sProduction[1].ToString(), out value1);
                        if (bSuccess && bSuccess1) {
                            sum = (sum + (value + value1));
                        }
                        else {
                          return false;
                        }
                    } else {
                      sum = (sum + production);
                    }
                }
                else {
                   return false;
                }
            }

            int division = (sum / 10);
            bSuccess = int.TryParse(currentChecker.ToString(), out value);
            if (bSuccess) {
                int v = (((division + 1) * 10) - sum);
                if (v == value) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;    
        }

        public bool copyNumbersToOutputArray() {
            if (this.bankGroup.Item1 == 1 || this.bankGroup.Item1 == 2 || this.bankGroup.Item1 == 31 || this.bankGroup.Item1 == 33 || this.bankGroup.Item1 == 34 || this.bankGroup.Item1 == 36 || this.bankGroup.Item1 == 37 || this.bankGroup.Item1 == 38 ||  this.bankGroup.Item1 == 39 || this.bankGroup.Item1 == 6 || this.bankGroup.Item1 == 8)
            {
                for (int i = 0; i < 6; i++) {
                   outputAccountNumberArr[i] = inputAccountNumberArr[i];
                }
                int ind = this.inputAccountNumber.IndexOf('-');
                string secPart = ind != -1 ? inputAccountNumber.Substring((ind + 1)) : inputAccountNumber.Substring((6));
                int startPosition = 14 - secPart.Length; 
                for (int i = startPosition, j = 0; i < 14; i++,j++)
                {
                    outputAccountNumberArr[i] = secPart[j];
                }
                return true;
            }
            else if (this.bankGroup.Item1 == 4 || this.bankGroup.Item1 == 5)
            {
                for (int i = 0; i < 6; i++)
                {
                    outputAccountNumberArr[i] = inputAccountNumberArr[i];
                }
                int ind = this.inputAccountNumber.IndexOf('-');
                string secPart;
                if (ind != -1) 
                {
                    outputAccountNumberArr[6] = inputAccountNumberArr[7];
                    secPart = inputAccountNumber.Substring((ind + 2));
                }
                else
                { 
                    outputAccountNumberArr[6] = inputAccountNumberArr[6];
                    secPart = inputAccountNumber.Substring((7));
                }
                int startPosition = 14 - secPart.Length; 
                for (int i = startPosition, j = 0; i < 14; i++, j++)
                {
                    outputAccountNumberArr[i] = secPart[j];
                }
                return true;
            }
            return false;
        }

        public Tuple<int, string> returnBankGroup() {
            return this.bankGroup;
        }

        private bool getBankGroup(string firstTwo) {
            int nBank = 0;
            bool evalNum = firstTwo[0] == '3' ? int.TryParse(firstTwo, out nBank) : evalNum = int.TryParse(firstTwo[0].ToString(), out nBank);
            bool bReturn = false;
            if (evalNum && nBank != 0) { 
                switch (nBank) {
                    case 1:
                    case 2:
                        this.bankGroup = new Tuple<int, string>(nBank, "Nordea Pankki (Nordea)"); bReturn = true; break;
                    case 4:
                        this.bankGroup = new Tuple<int, string>(nBank, "Aktia Pankki, Säästöpankit (Sp) ja Paikallisosuuspankit (POP)"); bReturn = true; break;
                    case 5:
                        this.bankGroup = new Tuple<int, string>(nBank, "OP-Pohjola-ryhmä (Osuuspankit (OP), Helsingin OP Pankki ja Pohjola Pankki)"); bReturn = true; break;
                    case 6:
                        this.bankGroup = new Tuple<int, string>(nBank, "Ålandsbanken ÅAB"); bReturn = true; break;
                    case 8:
                        this.bankGroup = new Tuple<int, string>(nBank, "Sampo Pankki"); bReturn = true; break;
                    case 31:
                        this.bankGroup = new Tuple<int, string>(nBank, "Handelsbanken"); bReturn = true; break;
                    case 33:
                        this.bankGroup = new Tuple<int, string>(nBank, "Skandinaviska Enskilda Banken (SEB)"); bReturn = true;break;
                    case 34:
                        this.bankGroup = new Tuple<int, string>(nBank, "Danske Bank"); bReturn = true; break;
                    case 36:
                        this.bankGroup = new Tuple<int, string>(nBank, "Tapiola Pankki"); bReturn = true; break;
                    case 37:
                        this.bankGroup = new Tuple<int, string>(nBank, "DnB NOR Bank ASA (DnB NOR)"); bReturn = true; break;
                    case 38:
                        this.bankGroup = new Tuple<int, string>(nBank, "Swedbank"); bReturn = true; break;
                    case 39:
                        this.bankGroup = new Tuple<int, string>(nBank, "S-Pankki"); bReturn = true; break;
                    default:
                        bReturn = false;  break;
                }
            }
            return bReturn;
        }

        private bool isValidNumber(string accountNumber) {
            return Regex.IsMatch(accountNumber, @"^\d{6}-?\d{2,8}$"); 
        }

        public override string ToString() {
            return this.inputAccountNumber;
        }
    }
}
