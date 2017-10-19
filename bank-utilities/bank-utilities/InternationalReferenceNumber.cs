using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace bank_utilities
{
    class InternationalReferenceNumber
    {
        private string inputInternRefNumber;
        private string outputInternRefNumber;
        private string inputCheckSum;
        private string inputRefBase;

        public InternationalReferenceNumber() {}
        public InternationalReferenceNumber(string internRefNumber) {
            if (!isValid(internRefNumber))
                throw new ArgumentException("Illegal International Reference Number");

            this.inputInternRefNumber = internRefNumber;
        }

        public bool generateInternRefNumber() {
            string tmpinputRefBase = this.inputRefBase + "271500";
            BigInteger bigRefNum = new BigInteger();
            bool evalTest = BigInteger.TryParse(tmpinputRefBase, out bigRefNum);
            if (evalTest) {
                BigInteger subtraction = (98 - (bigRefNum % 97));
                if (subtraction < 10) {
                    this.inputCheckSum = "0" + subtraction;
                } else {
                    this.inputCheckSum = subtraction.ToString();
                }
                this.outputInternRefNumber = "RF" + this.inputCheckSum + this.inputRefBase;
                return true;
            } else {
                return false;
            }
        }

        public string formatRefNumber() {
            string output = "";
            for (int i = 0; i < this.outputInternRefNumber.Length; i++) {
                if (i % 4 == 0) {
                    output += " " + this.outputInternRefNumber[i];
                } else {
                    output += this.outputInternRefNumber[i];
                }
            }
            return output;
        }

        public string getInternRefNumber() {
            return this.outputInternRefNumber;
        }

        public void setRefBase(string inputRefBase) {
            this.inputRefBase = inputRefBase;
        }

        public bool isValidReferenceNumber() {
            string tmpRefNum = inputRefBase + getCharsNumber('R') + getCharsNumber('F') + inputCheckSum;
            BigInteger ntmpRefNum = new BigInteger();
            return BigInteger.TryParse(tmpRefNum, out ntmpRefNum) && (ntmpRefNum % 97 == 1);
        }
        
        private int getCharsNumber(char letter) {
            return (int)letter - 55;
        }

        private bool isValid(string internRefNumber) {
            Regex expression = new Regex(@"RF(?<checkSum>\d{2})(?<refBase>\d{4,20})");
            Match match = expression.Match(internRefNumber);
            if (match.Success) {
                this.inputCheckSum = match.Groups["checkSum"].Value; 
                this.inputRefBase = match.Groups["refBase"].Value;
                return true;
            }
            else {
                return false;
            }
        }
    }
}
