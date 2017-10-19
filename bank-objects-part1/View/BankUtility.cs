using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BankDBFormApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

   
namespace BankDBFormApp.View
{
    /// <summary>
    ///  BankUtility responsible for handling customer related db-actions
    /// </summary>
    class BankUtility  {
        private string validIbanString;
        private string validIbanCountryString;

        public BankUtility() {}

        // Get Banks
        public async void GetBanks(ListView lvBanks) {
            lvBanks.Items.Clear();
            using (var db = new BankdbContext())
            {
                var banks = await db.Bank.OrderBy(b => b.Name).ToArrayAsync();
                ListViewItem lvi;
                foreach (Bank bank in banks)
                {
                    lvi = new ListViewItem(bank.Id.ToString());
                    lvi.SubItems.Add(bank.Name);
                    lvi.SubItems.Add(bank.Bic);
                    lvBanks.Items.Add(lvi);
                }
            }
        }

        //Fill in the listbox with banks
        public async void PopulateListWithBanks(ListBox lbBank, string bankStr) {
            string[] str = bankStr.Split('-');
            using (var db = new BankdbContext())  {
                var banks = await db.Bank.OrderBy(b => b.Name).ToArrayAsync();
                int counter = 0;
                int selectedInd = 0;
                foreach (Bank bank in banks) {
                    if (str[0] == bank.Id.ToString()) {
                      selectedInd = counter;
                    }
                    lbBank.Items.Add(bank.Id.ToString()+"-"+bank.Name);
                    counter++;
                }
                lbBank.SelectedIndex = selectedInd;
            }
        }

        //iban validation checker
        public bool isIBANValidRegex(string regex) {
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

        public void setIban(string iban,string country="FI") {
            this.validIbanString = iban;
            this.validIbanCountryString = country;
        }

        public bool validateIBAN(string code) {
            if (isIBANValidRegex(code)) {
                string output = this.validIbanString.Substring(2) + this.validIbanCountryString + this.validIbanString.Substring(0, 2);
                string tmp = "";
                for (int i = 0; i < output.Length; i++) {
                    tmp += getNumberForALetter(output[i]);
                }
                BigInteger big = new BigInteger();
                bool evalTest = BigInteger.TryParse(tmp, out big);
                return evalTest && (big % 97 == 1);
            }
            return false;
        }

        private int getNumberForALetter(char letter)  {
            int nNum;
            int.TryParse(letter.ToString(), out nNum);
            return char.IsLetter(letter) ? ((int)letter - 55) : nNum;
        }

        //Create New Bank
        public Tuple<int,string,string> CreateBank(string bank, string bic) {
            using (var db = new BankdbContext()) {
                var newBank = new Bank() {Name = bank, Bic = bic};
                db.Bank.Add(newBank);
                db.SaveChanges();
                return new Tuple<int,string,string>(newBank.Id, newBank.Name, newBank.Bic);
            }
        }

        //Remove Bank
        public Tuple<int, string, string> RemoveBank(int id) {
            using (var db = new BankdbContext()) {
                using (var transaction = db.Database.BeginTransaction())  {
                    try
                    {
                        var customer = db.Customer.Where(c => c.BankId == id).FirstOrDefault();
                        if (customer != null)
                        {
                            db.Customer.Remove(customer);
                            db.SaveChanges();
                        }
                        var bankAccount = db.BankAccount.Where(ba => ba.BankId == id).FirstOrDefault();
                        if (bankAccount != null)
                        {
                            db.BankAccount.Remove(bankAccount);
                            db.SaveChanges();
                        }
                        var bank = db.Bank.Where(b => b.Id == id).FirstOrDefault();
                        db.Bank.Remove(bank);
                        int _b = db.SaveChanges();
                        if (_b > 0)
                        {
                            transaction.Commit();
                            return new Tuple<int, string, string>(1, "Bank removed successfully", "Success");
                        }
                        else
                        {
                            transaction.Rollback();
                            return new Tuple<int, string, string>(2, "Bank not removed successfully", "Failure");
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new Tuple<int, string, string>(3, "Error occurred in deletion operation!", "Failure");
                    }
                }
            }
        }

        //Update Bank
        public bool UpdateBank(int id, string txtBankName, string txtBiccode) {
            using (var db = new BankdbContext()) {
                var bank = db.Bank.Where(b => b.Id == id).FirstOrDefault();
                bank.Name = txtBankName;
                bank.Bic = txtBiccode;
                db.Bank.Update(bank);
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        //Search for Customer's transactions
        public async void SearchForCustomerTransactions(ListView lvCustomersTransactions, string iban) {
            using (var db = new BankdbContext()) {
                var transactions = db.BankAccountTransaction
                        .Where(bat => bat.Iban == iban)
                        .OrderBy(bat => bat.TimeStamp)
                        .ToList();
                if (transactions.Count > 0)  {
                    lvCustomersTransactions.Items.Clear();
                    ListViewItem lvi;
                    foreach (BankAccountTransaction bat in transactions) {
                        lvi = new ListViewItem(string.Format("{0}.{1}.{2}", bat.TimeStamp.Day, bat.TimeStamp.Month,
                            bat.TimeStamp.Year));
                        lvi.SubItems.Add(bat.Amount.ToString());
                        lvCustomersTransactions.Items.Add(lvi);
                    }
                } else {
                    lvCustomersTransactions.Items.Clear();
                }
            }
        }

        //Add bank to ListView
        public void AddBankToList(ListView lvBanks, Tuple<int,string,string> newBank) {
            ListViewItem lvi = new ListViewItem(newBank.Item1.ToString());
            lvi.SubItems.Add(newBank.Item2);
            lvi.SubItems.Add(newBank.Item3);
            lvBanks.Items.Add(lvi);
        }

        //Update ListView component after the db operation
        public void ReplaceBankInList(ListView lvBanks, int id, string bank, string bic) {
            for (int i = 0; i < lvBanks.Items.Count; i++) {
                if (lvBanks.Items[i].SubItems[0].Text.ToString() == id.ToString()) {
                    lvBanks.Items[i].SubItems[1].Text = bank;
                    lvBanks.Items[i].SubItems[2].Text = bic;
                    break;
                }
            }
        }
    }
}
