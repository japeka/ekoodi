using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using BankDBFormApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BankDBFormApp.View
{
    /// <summary>
    ///  CustomerUtility for handling customer related db actions
    /// </summary>
    class CustomerUtility
    {
        public CustomerUtility() {}


        //Add Customer to Bank
        public Tuple<int,string,string> AddCustomerToBank(
            string firstname,string lastname,
                string iban, string accountname, 
                    decimal balance, int bankId) {
            using (var db = new BankdbContext())
            {
            using (var transaction = db.Database.BeginTransaction()) {
            try
            {
                //check if there is a person with the given iban in db
                var bankAcc = db.BankAccount.Where(b => b.Iban.Trim().ToLower() == iban.Trim().ToLower()).FirstOrDefault();

                if (bankAcc != null && bankAcc.Iban.Length > 0) { //given iban is use just return error
                    transaction.Rollback();
                    return new Tuple<int,string, string>(2,"Duplicate iban accounts not allowed!","Failure");
                }

                //check if user already exists in db by firstname, lastname, bankId
                //  yes => do not add new user -> use user's id to create account for her/him
                //  no  => add new user   
                var cust = db.Customer.Where(c => (c.FirstName.Trim().ToLower() == firstname.Trim().ToLower()) 
                    && (c.LastName.Trim().ToLower() == lastname.Trim().ToLower()) 
                        && (c.BankId == bankId)).FirstOrDefault();

                int custId = 0;
                string msg = "";
                if (cust == null) {
                    var customer = new Customer() {
                        FirstName = firstname,
                        LastName = lastname,
                        BankId = bankId
                    };
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    custId = customer.Id;
                    msg = "Customer & bank account created successfully";
                } else {
                    msg = "Bank account added successfully to an existing customer";
                    custId = cust.Id;
                }
                var bankAccount = new BankAccount() {
                    Iban = iban,
                    Name = accountname,
                    BankId = bankId,
                    CustomerId = custId,
                    Balance = balance
                };
                db.BankAccount.Add(bankAccount);
                int n = db.SaveChanges();
                if (n > 0) {
                    transaction.Commit();
                    return new Tuple<int, string, string>(1, msg, "Success");
                 }  else {
                    transaction.Rollback();
                    return new Tuple<int, string, string>(3, "User not created successfully", "Failure");
                 }
            } catch (Exception e) {
                transaction.Rollback();
                return new Tuple<int, string, string>(4, "Error occurred in insertion operation!", "Failure"); 
             }
          }
        }
        }

        //Remove Customer 
        public Tuple<int, string, string> RemoveCustomer(int custId) {
            using (var db = new BankdbContext()) {
                try {
                    var customer = db.Customer.Where(c => c.Id == custId).FirstOrDefault();
                    db.Customer.Remove(customer);
                    int _c = db.SaveChanges();

                    if (_c > 0 ) {
                        return new Tuple<int, string, string>(1,"Customer removed successfully","Success");
                    }  else {
                        return new Tuple<int, string, string>(2, "Customer not removed successfully", "Failure");
                    }
                } catch (Exception e) {
                    return new Tuple<int, string, string>(3, "Error occurred in deletion operation!", "Failure");
                }
            }
        }

        //Remove Account
        public Tuple<int, string, string> RemoveAccount(int custId, string iban, int bankId) {
            using (var db = new BankdbContext()) {
                try {
                    var bankAccount = db.BankAccount
                    .Where(ba => (ba.CustomerId == custId) 
                        && (ba.Iban == iban) 
                        && (ba.BankId == bankId))
                        .FirstOrDefault();

                    db.BankAccount.Remove(bankAccount);
                    int _ba = db.SaveChanges();
                    if (_ba > 0)  {
                      return new Tuple<int, string, string>(1, "Bank account removed successfully", "Success");
                    }
                    return new Tuple<int, string, string>(2, "Bank account not removed successfully", "Failure");
                } catch (Exception e) {
                    return new Tuple<int, string, string>(3, "Error occurred in deletion operation!", "Failure");
                }
            }
        }

        //Update Customer
        public Tuple<int, string, string> UpdateCustomer(int custId, string firstname, string lastname) {
            using (var db = new BankdbContext()) {
                var customer = db.Customer.Where(c => c.Id == custId).FirstOrDefault();
                customer.FirstName = firstname;
                customer.LastName = lastname;
                db.Customer.Update(customer);
                if (db.SaveChanges() > 0) {
                    return new Tuple<int, string, string>(1, "Customer updated successfully", "Success");
                } else {
                    return new Tuple<int, string, string>(2, "Customer not updated successfully", "Failure");
                }
            }
        }

        //Add New Transaction for Customer (iban)
        public Tuple<int, string, string> MakeATransaction(string iban, decimal _sum, decimal updatedTotal) {
            using (var db = new BankdbContext()) { 
                using (var transaction = db.Database.BeginTransaction()) {
                    try {
                        //add new transaction
                        var newTransaction = new BankAccountTransaction() {
                            Iban = iban,
                            Amount = _sum,
                            TimeStamp = DateTime.Now
                        };
                        db.BankAccountTransaction.Add(newTransaction);
                        int _t = db.SaveChanges();

                        //update balance of the account
                        var bankAcccount = db.BankAccount.Where(ba => ba.Iban == iban).FirstOrDefault();
                        bankAcccount.Balance = updatedTotal;
                        db.BankAccount.Update(bankAcccount);
                        int _ba = db.SaveChanges();
                        if (_t > 0 && _ba > 0)  {
                          transaction.Commit();
                          return new Tuple<int, string, string>(1, "Transaction made successfully!", "Success");
                        }  else  {
                          transaction.Rollback();
                          return new Tuple<int, string, string>(1, "Transaction not made successfully!", "Failure");
                        }
                    } catch (Exception e) {
                        Console.WriteLine(e.ToString());
                        transaction.Rollback();
                        return new Tuple<int, string, string>(3, "Error occurred in transaction creation!", "Failure");
                    }
                }
            }
        }


        //Update Customer's Account
        public Tuple<int, string, string> UpdateAccount(int custId, string iban, string accountName, decimal balance) {
            using (var db = new BankdbContext()) {
                try  {
                    var bankAccount = db.BankAccount
                        .Where(ba => (ba.CustomerId == custId) && (ba.Iban == iban))
                        .FirstOrDefault();

                    bankAccount.Name = accountName; 
                    bankAccount.Balance = balance; // >= 0 accepted
                    db.BankAccount.Update(bankAccount);

                    if (db.SaveChanges() > 0) {
                      return new Tuple<int, string, string>(1, "Bank account successfully updated!", "Success");
                    } else {
                      return new Tuple<int, string, string>(2, "Bank account not successfully updated!", "Failure");
                    }
                } catch (Exception e) {
                  return new Tuple<int, string, string>(3, "Error occurred in bank account updating operation!", "Failure");
                }
            }
        }
    
        //Update ListView component after db operation
        public void ReplaceTransactionAccoutInList(ListView lvIbansTransaction, string iban, decimal updatedTotal) {
            for (int i = 0; i < lvIbansTransaction.Items.Count; i++) {
                if (lvIbansTransaction.Items[i].SubItems[0].Text.Trim() == iban) {
                    lvIbansTransaction.Items[i].SubItems[3].Text = updatedTotal.ToString();
                    break;
                }
            }
        }

        //Update ListView component after db operation
        public void ReplaceAccountInList(ListView lvCustomerAccounts, string iban, string account, decimal balance) {
            for (int i = 0; i < lvCustomerAccounts.Items.Count; i++)  {
                if (lvCustomerAccounts.Items[i].SubItems[0].Text.Trim() == iban) {
                    lvCustomerAccounts.Items[i].SubItems[1].Text = account;
                    lvCustomerAccounts.Items[i].SubItems[3].Text = balance.ToString();
                    break;
                }
            }
        }

        //Update ListView component after db operation
        public void ReplaceCustomerInList(ListView lvCustomerData, int id, string firstname, string lastname) {
            for (int i = 0; i < lvCustomerData.Items.Count; i++) {
                if (lvCustomerData.Items[i].SubItems[0].Text.ToString() == id.ToString())  {
                    lvCustomerData.Items[i].SubItems[1].Text = firstname;
                    lvCustomerData.Items[i].SubItems[2].Text = lastname;
                    break;
                }
            }
        }

        //Get Customers
        public async void GetCustomers(ListView lvCustomerData) {
            using (var db = new BankdbContext())
            {
                lvCustomerData.Items.Clear();
                var customers = await db.Customer
                    .Include(c => c.Bank)
                    .OrderBy(c => c.LastName).ToArrayAsync();
                ListViewItem lvi;
                foreach (Customer customer in customers)
                {
                    lvi = new ListViewItem(customer.Id.ToString());
                    lvi.SubItems.Add(customer.FirstName.Trim());
                    lvi.SubItems.Add(customer.LastName.Trim());
                    lvi.SubItems.Add(customer.Bank.Name.Trim());
                    lvCustomerData.Items.Add(lvi);
                }
            }
        }

        //Get Customers eligible for transaction
        public async void GetCustomersForCreateTransaction(ListView lvIbansTransaction,ListView lvSearchCustomersTransactions) {
            using (var db = new BankdbContext())  {
                lvIbansTransaction.Items.Clear();
                var bankAccounts = await db.BankAccount
                    .Include(ba => ba.Bank)
                    .Include(ba => ba.Customer)
                    .OrderBy(ba => ba.Customer.LastName).ToArrayAsync();
                ListViewItem lvi,lviSearch;
                foreach (BankAccount bankAcc in bankAccounts) {
                    lvi = new ListViewItem(bankAcc.Iban.Trim());
                    lviSearch = new ListViewItem(bankAcc.Iban.Trim());
                    lvi.SubItems.Add(bankAcc.Customer.FirstName.Trim() + " " + bankAcc.Customer.LastName.Trim());
                    lviSearch.SubItems.Add(bankAcc.Customer.FirstName.Trim() + " " + bankAcc.Customer.LastName.Trim());

                    lvi.SubItems.Add(bankAcc.Bank.Name.Trim());
                    lvi.SubItems.Add(bankAcc.Balance.ToString());
                    lvIbansTransaction.Items.Add(lvi);
                    lvSearchCustomersTransactions.Items.Add(lviSearch);
                }
            }
        }

        //Get Customer's Accounts
        public async void GetAccountsForCustomer(ListView lvCustomerAccounts, int custId) {
            lvCustomerAccounts.Items.Clear();
            using (var db = new BankdbContext())
            {
                var bankaccounts = await db.BankAccount
                    .Include(ba => ba.Bank)
                    .Where(ba => ba.CustomerId == custId)
                    .OrderBy(ba => ba.Iban).ToArrayAsync();
                ListViewItem lvi;
                foreach (BankAccount account in bankaccounts)
                {
                    lvi = new ListViewItem(account.Iban.Trim());
                    lvi.SubItems.Add(account.Name.Trim());
                    lvi.SubItems.Add(account.BankId.ToString() + "-" +account.Bank.Name.Trim());
                    lvi.SubItems.Add(account.Balance.ToString());
                    lvCustomerAccounts.Items.Add(lvi);
                }
            }
        }

        public void GetCustomersAndAccountsOfBank(Label lblCustomersAndAccountsOfBank, int bankId) {
            lblCustomersAndAccountsOfBank.Text = "";
            string output = "";
            using(var db = new BankdbContext()) { 
            var customers = db.Customer.ToList()
                .Join(db.BankAccount,
                    c => c.Id,
                    b => b.CustomerId,
                    (customer, bankaccount) => new
                    {
                        BankId = customer.BankId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Iban = bankaccount.Iban,
                        AccountName = bankaccount.Name,
                        Balance = bankaccount.Balance
                    }).Where(c => c.BankId == bankId);
                string name = "";string prevName = "";
                foreach (var c in customers) {
                    name = c.FirstName.Trim() + " " + c.LastName.Trim();
                    if (name == prevName) {
                        output += "IBAN:  " + c.Iban.Trim() + "  Account Name: " + c.AccountName.Trim() + "  Balance: " + c.Balance + "\n";
                    } else {
                        output += "Name: " + c.FirstName.Trim() + " " + c.LastName.Trim() + "\nIBAN:  " + c.Iban.Trim() + "  Account Name: " + c.AccountName.Trim() + "  Balance: " + c.Balance + "\n";
                        prevName = name;
                    }
                }
            }
            lblCustomersAndAccountsOfBank.Text = output;
        }
    }
}
