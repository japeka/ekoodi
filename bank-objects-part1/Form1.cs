using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDBFormApp.View;
using BankDBFormApp.Model;

/// <summary>
///  Bank Object Part 1 implemented as WinForm app  
/// </summary>

namespace BankDBFormApp {
    public partial class Form1 : Form
    {
        private BankUtility bankUtility;
        private CustomerUtility customerUtility;

        public Form1() {
            InitializeComponent();
            bankUtility = new BankUtility();
            customerUtility = new CustomerUtility();
            loadBanks(); //banks for tab #1 
        }

        //load banks for tab 1
        private void loadBanks() {
          bankUtility.GetBanks(lvBanks);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        //remove bank
        private void btnRemoveBank_Click(object sender, EventArgs e) {
            if (lvBanks.SelectedItems.Count > 0) {
                ListViewItem item = lvBanks.SelectedItems[0];
                int id; bool evalTest = int.TryParse(item.SubItems[0].Text, out id);
                if (evalTest) {
                    Tuple<int, string, string> ret = bankUtility.RemoveBank(id);
                    switch (ret.Item1) {
                        case 1:
                            lvBanks.SelectedItems[0].Remove();
                            txtBankNameUpdate.Text = ""; txtBiccodeUpdate.Text = "";
                            MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                            break;
                        case 2:
                        case 3:
                            MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            break;
                    }
                } else {
                   MessageBox.Show("Bank id not converted properly!", "Conversion Error",MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            } else {
                MessageBox.Show("No bank item was selected!", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e) {
            if (txtBankName.Text.Length > 3 && txtBiccode.Text.Length > 4) {
                Tuple<int,string, string> newBank = bankUtility.CreateBank(txtBankName.Text, txtBiccode.Text);
                if (newBank != null) {
                    bankUtility.AddBankToList(lvBanks, newBank);
                    txtBankName.Text = ""; txtBiccode.Text = ""; txtBankName.Focus();
                } else {
                    MessageBox.Show("Bank creation failed. Try again!", "Bank Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtBankName.Text = ""; txtBiccode.Text = ""; txtBankName.Focus();
                }
            } else {
                MessageBox.Show("Please provide input for bankname and biccode!","Missing Input",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                txtBankName.Text = ""; txtBiccode.Text = "";txtBankName.Focus();
            }
        }

        //method gets triggered when tab panel is changed
        private void changeTab(object sender, EventArgs e) {
            clearListViews();  //clear fields from old inputs
            switch (tabControl1.SelectedIndex) {
                case 1:
                    EmptifyCustToBankFields();
                    bankUtility.GetBanks(lvCustToBank);
                    break;
                case 2:
                    EmptifyAccsCustField();
                    bankUtility.GetBanks(lvAccsCustOfBank);
                    break;
                case 3:
                    EmptifyCustomerDataFields();
                    customerUtility.GetCustomers(lvCustomerData);
                    break;
                case 4:
                    EmptifyCreateTransactionFields();
                    customerUtility.GetCustomersForCreateTransaction(lvIbansTransaction, lvSearchCustomersTransactions);
                    break;
                default:
                    break;
            }
        }

        //selection of a bank in Listview
        private void lvBanks_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvBanks.SelectedItems.Count > 0) {
                ListViewItem item = lvBanks.SelectedItems[0];
                txtBankNameUpdate.Text = item.SubItems[1].Text.Trim();
                txtBiccodeUpdate.Text = item.SubItems[2].Text.Trim();
            }
        }

        //selection of a customer in ListView
        private void lvCustomerData_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvCustomerData.SelectedItems.Count > 0) {
                ListViewItem item = lvCustomerData.SelectedItems[0];
                txtCustomerDataFirstName.Text = item.SubItems[1].Text.Trim();
                txtCustomerDataLastName.Text = item.SubItems[2].Text.Trim();
                populateAccountListView(item.SubItems[0].Text.Trim());

                //clear old selections for account
                txtCustomerDataIban.Text = "";
                txtCustomerDataAccountName.Text = "";
                lbBank.Items.Clear();
                txtCustomerDataBalance.Text = "";
            }
        }

        //selection of a bank for displaying bank's customers & accounts
        private void lvAccsCustOfBank_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvAccsCustOfBank.SelectedItems.Count > 0) {
                ListViewItem item = lvAccsCustOfBank.SelectedItems[0];
                int bankId;
                bool evalTest = int.TryParse(item.SubItems[0].Text.Trim(), out bankId);
                customerUtility.GetCustomersAndAccountsOfBank(lblCustomersAndAccountsOfBank, bankId);
            }
        }

        //get accounts for a customer
        private void populateAccountListView(string custIdStr) {
            int custId;
            bool evalTest = int.TryParse(custIdStr, out custId);
            if (evalTest) {
                customerUtility.GetAccountsForCustomer(lvCustomerAccounts, custId);
            }
        }

        //methods for clearing old input
        private void EmptifyCreateTransactionFields() {
            txtTransactionSum.Text = "";
            lvCustomersTransactions.Items.Clear();
            lvSearchCustomersTransactions.Items.Clear();
        }

        private void clearListViews() {
            lvCustomerData.Items.Clear();
            lvCustomerAccounts.Items.Clear();
            lvCustomerAccounts.Items.Clear();
            lvCustomersTransactions.Items.Clear();
            lbBank.Items.Clear();
        }

        private void EmptifyCustToBankFields() {
            txtCustomerFirstName.Text = "";
            txtCustomerLastName.Text = "";
            txtIban.Text = "";
            txtAccountName.Text = "";
            txtAccountBalance.Text = "";
        }

        private void EmptifyAccsCustField() {
            lblCustomersAndAccountsOfBank.Text = "";
        }

        private void EmptifyCustomerDataFields() {
            txtCustomerDataFirstName.Text = "";
            txtCustomerDataLastName.Text = "";
            txtCustomerDataIban.Text = "";
            txtCustomerDataAccountName.Text = "";
            txtCustomerDataBalance.Text = "";
        }

        //create new customer and connect her/him to a selected bank
        private void btnAddCustomerToBank_Click(object sender, EventArgs e) {
            if (lvCustToBank.SelectedItems.Count > 0) {
                ListViewItem item = lvCustToBank.SelectedItems[0];
                int bankId;
                bool evalTest = int.TryParse(item.SubItems[0].Text, out bankId);
                decimal balance;
                bool evalTest2 = decimal.TryParse(txtAccountBalance.Text.Trim(), out balance);
                if (evalTest && evalTest2  
                        && txtCustomerFirstName.Text.Trim().Length > 2 && txtCustomerLastName.Text.Trim().Length > 2 
                            && txtIban.Text.Trim().Length > 5 && txtAccountName.Text.Trim().Length > 2 ) {
                        bankUtility.setIban(txtIban.Text.Trim());
                        //if (bankUtility.validateIBAN(txtIban.Text.Trim())) {
                            Tuple<int,string,string> ret = customerUtility.AddCustomerToBank(txtCustomerFirstName.Text.Trim(), txtCustomerLastName.Text.Trim(),
                                txtIban.Text.Trim(), txtAccountName.Text.Trim(), balance, bankId);
                                switch (ret.Item1) {
                                    case 1:
                                      txtCustomerFirstName.Text = ""; txtCustomerLastName.Text = ""; txtAccountName.Text = ""; txtAccountBalance.Text = "";txtIban.Text = "";
                                      MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                                      break;
                                    case 2: case 3: case 4:
                                      MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                      break;
                                }
                                lblCustomersAndAccountsOfBank.Text = "";
                        //} else {
                          //  txtIban.Focus();
                          //  MessageBox.Show("Please provide valid input for iban!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        //}
                    } else {
                        MessageBox.Show("Please provide valid input for firstname, lastname, iban, account name and numeric input for balance!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
            } else {
                MessageBox.Show("No bank was selected!", "No bank selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //update bank
        private void btnBankUpdate_Click(object sender, EventArgs e) {
            if (lvBanks.SelectedItems.Count > 0) {
                if (txtBankNameUpdate.Text.Length > 3 && txtBiccodeUpdate.Text.Length > 4)  {
                    ListViewItem item = lvBanks.SelectedItems[0];
                    int id;
                    bool evalTest = int.TryParse(item.SubItems[0].Text, out id);
                    if (bankUtility.UpdateBank(id, txtBankNameUpdate.Text.Trim(), txtBiccodeUpdate.Text.Trim())) {
                        bankUtility.ReplaceBankInList(lvBanks, id, txtBankNameUpdate.Text.Trim(), txtBiccodeUpdate.Text.Trim());
                    } else  {
                        MessageBox.Show("Bank updation failed. Try again!", "Bank Updatation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtBankNameUpdate.Text = ""; txtBiccodeUpdate.Text = ""; txtBankNameUpdate.Focus();
                    }
                }  else {
                    MessageBox.Show("Please provide input for bankname and biccode!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtBankNameUpdate.Text = ""; txtBiccodeUpdate.Text = ""; txtBankNameUpdate.Focus();
                }
            }  else  {
                MessageBox.Show("No bank was selected!", "No bank selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //add new bank
        private void btnAddNewBank_Click(object sender, EventArgs e)  {
            if (txtBankName.Text.Length > 3 && txtBiccode.Text.Length > 4) {
                Tuple<int, string, string> newBank = bankUtility.CreateBank(txtBankName.Text, txtBiccode.Text);
                if (newBank != null)  {
                    bankUtility.AddBankToList(lvBanks, newBank);
                    txtBankName.Text = ""; txtBiccode.Text = ""; txtBankName.Focus();
                } else  {
                    MessageBox.Show("Bank creation failed. Try again!", "Bank Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtBankName.Text = ""; txtBiccode.Text = ""; txtBankName.Focus();
                }
            }  else {
                MessageBox.Show("Please provide input for bankname and biccode!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtBankName.Text = ""; txtBiccode.Text = ""; txtBankName.Focus();
            }
        }
        
        //remove customer
        private void btnRemoveCustomerData_Click(object sender, EventArgs e) {
            if (lvCustomerData.SelectedItems.Count > 0)  {
                ListViewItem item = lvCustomerData.SelectedItems[0];
                int id;
                bool evalTest = int.TryParse(item.SubItems[0].Text, out id);
                if (evalTest) {
                    Tuple<int, string, string> ret = customerUtility.RemoveCustomer(id);
                    switch (ret.Item1) {
                        case 1:
                            lvCustomerData.SelectedItems[0].Remove();
                            txtCustomerDataFirstName.Text = ""; txtCustomerDataLastName.Text = "";
                            MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                            break;
                        case 2:
                        case 3:
                            MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            break;
                    }
                }  else {
                    MessageBox.Show("Bank id not converted properly!", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            } else {
                MessageBox.Show("No customer was selected!", "No Customer selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //update customer
        private void btnUpdateCustomer_Click(object sender, EventArgs e)  {
            if (lvCustomerData.SelectedItems.Count > 0) {
                ListViewItem item = lvCustomerData.SelectedItems[0];
                int id;
                bool evalTest = int.TryParse(item.SubItems[0].Text, out id);
                if (evalTest) {
                    if (txtCustomerDataFirstName.Text.Trim().Length > 2 &&
                        txtCustomerDataLastName.Text.Trim().Length > 2)
                    {
                        Tuple<int,string,string> ret = customerUtility.UpdateCustomer(id, txtCustomerDataFirstName.Text.Trim(), txtCustomerDataLastName.Text.Trim());
                        if (ret.Item1 == 1)  {
                            customerUtility.ReplaceCustomerInList(lvCustomerData, id, txtCustomerDataFirstName.Text.Trim(), txtCustomerDataLastName.Text.Trim());
                        } else {
                            MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    } else  {
                        MessageBox.Show("Please provide input for customer first name and last name!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                } else  {
                    MessageBox.Show("Customer id not converted properly!", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            } else {
                MessageBox.Show("No customer was selected!", "No Customer selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }


        //selection of customer's account
        private void lvCustomerAccounts_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvCustomerAccounts.SelectedItems.Count > 0) {
                ListViewItem item = lvCustomerAccounts.SelectedItems[0];
                txtCustomerDataIban.Text = item.SubItems[0].Text.Trim(); //iban
                txtCustomerDataAccountName.Text = item.SubItems[1].Text.Trim();
                bankUtility.PopulateListWithBanks(lbBank, item.SubItems[2].Text.Trim());
                txtCustomerDataBalance.Text = item.SubItems[3].Text.Trim(); ;
            }
        }

        //remove customer's account
        private void btnRemoveCustAccount_Click(object sender, EventArgs e){
            string custId = "";string iban = "";string[] bank;
            if (lvCustomerData.SelectedItems.Count > 0 && lvCustomerAccounts.SelectedItems.Count > 0) {
                ListViewItem custItem = lvCustomerData.SelectedItems[0];
                custId = custItem.SubItems[0].Text.Trim();
                int cId;
                bool evalCust = int.TryParse(custId, out cId);
                ListViewItem accountItem = lvCustomerAccounts.SelectedItems[0];
                iban = accountItem.SubItems[0].Text.Trim();
                bank = accountItem.SubItems[2].Text.Trim().Split('-');
                int bankId;
                bool evalBank = int.TryParse(bank[0], out bankId);
                if (evalCust && evalBank) {
                    Tuple<int, string,string> ret = customerUtility.RemoveAccount(cId, iban, bankId);
                    if (ret.Item1 == 1)  {
                        txtCustomerDataIban.Text = "";txtCustomerDataAccountName.Text = "";
                        txtCustomerDataBalance.Text = "";lbBank.Items.Clear();
                        lvCustomerAccounts.SelectedItems[0].Remove();
                        MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    } else {
                      MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                } else {
                    MessageBox.Show("Conversion was not successful!", "Conversion problem", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            } else {
                MessageBox.Show("No customer and account was selected!", "No Customer & Account selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //update customer's account
        private void btnUpdateCustAccount_Click(object sender, EventArgs e) {
            string custId = ""; string iban = "";
            if (lvCustomerData.SelectedItems.Count > 0 && lvCustomerAccounts.SelectedItems.Count > 0) {
                //where clauses data, current state of the user
                ListViewItem custItem = lvCustomerData.SelectedItems[0];
                custId = custItem.SubItems[0].Text.Trim();
                int cId;
                bool evalCust = int.TryParse(custId, out cId);
                ListViewItem accountItem = lvCustomerAccounts.SelectedItems[0];
                iban = accountItem.SubItems[0].Text.Trim();

                string strBalance = txtCustomerDataBalance.Text.Trim();
                decimal balance;
                bool evalBalance = decimal.TryParse(strBalance, out balance);
                if (txtCustomerDataAccountName.Text.Trim().Length > 2
                        && lbBank.SelectedIndex >= 0 && evalBalance && balance > 0) {
                    Tuple<int,string,string> ret = customerUtility.UpdateAccount(cId,iban,txtCustomerDataAccountName.Text.Trim(),balance);
                    if (ret.Item1 == 1) {
                       customerUtility.ReplaceAccountInList(lvCustomerAccounts,iban, txtCustomerDataAccountName.Text.Trim(), balance);
                       MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    } else {
                       MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                } else {
                    MessageBox.Show("Please provide valid input for account name, bank and positive, decimal input for balance!", "Invalid input fields", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            } else {
                MessageBox.Show("No customer and account was selected!", "No Customer & Account selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //add new transaction
        private void btnAddTransaction_Click(object sender, EventArgs e) {
            if (lvIbansTransaction.SelectedItems.Count > 0) {
                ListViewItem item = lvIbansTransaction.SelectedItems[0];
                string iban = item.SubItems[0].Text.Trim();
                decimal sum;
                bool evalSum = decimal.TryParse(txtTransactionSum.Text.Trim(), out sum);

                string currentBalanceStr = item.SubItems[3].Text.Trim();
                decimal currentBalance;
                bool evalCurrentBalance = decimal.TryParse(currentBalanceStr, out currentBalance);

                //both negative and positive allowed, negative = draws out money from account, positive = deposits to account
                if (evalSum && evalCurrentBalance) {
                    if (sum < 0 && (currentBalance + sum) < 0) {
                      MessageBox.Show("You are trying to draw out too much. The current balance is " + currentBalance,"Attempt to draw out too much", MessageBoxButtons.OK, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                    } else {
                      decimal updatedTotal = currentBalance + sum;
                      Tuple<int,string,string> ret = customerUtility.MakeATransaction(iban, sum, updatedTotal);
                        if (ret.Item1 == 1) {
                          customerUtility.ReplaceTransactionAccoutInList(lvIbansTransaction,iban, updatedTotal);
                          txtTransactionSum.Text = "";
                          lvCustomersTransactions.Items.Clear();
                          lvSearchCustomersTransactions.SelectedItems.Clear();
                          MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                        } else  {
                          txtTransactionSum.Focus();
                          MessageBox.Show(ret.Item2, ret.Item3, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                } else {
                  MessageBox.Show("Only non-empty and numeric decimal input for sum is allowed!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                  txtTransactionSum.Focus();
                }
            } else {
              MessageBox.Show("No iban was selected!", "No Iban selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void lvSearchCustomersTransactions_SelectedIndexChanged(object sender, EventArgs e){
            if (lvSearchCustomersTransactions.SelectedItems.Count > 0)  {
                ListViewItem item = lvSearchCustomersTransactions.SelectedItems[0];
                string iban = item.SubItems[0].Text.Trim();
                bankUtility.SearchForCustomerTransactions(lvCustomersTransactions,iban);
            }
        }

        private void label18_Click(object sender, EventArgs e) { }
        private void txtCustomerDataFirstName_TextChanged(object sender, EventArgs e) { }
        private void txtCustomerDataLastName_TextChanged(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }

    }
}
