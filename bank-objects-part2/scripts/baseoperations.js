//populates bank selection with data
var banks = _banks.getBanks();

var banksSelect = document.getElementById("banks");
var optionsBanks = '<option data-bank-id="-1" value="" selected="">Select bank</option>';
banks.forEach(function(bank) {optionsBanks+='<option data-bank-id="'+bank.id+'" value="'+bank.bic+'">'+bank.name+'</option>';});
banksSelect.innerHTML = optionsBanks;

///when bank gets changed -> find customers for the bank and display them in customers select box
var bankSelect = document.getElementById("banks");
bankSelect.addEventListener("change", function(event) {
    var that = this;
    var bankId = that.options[that.selectedIndex].getAttribute('data-bank-id');
    populateCustomers(bankId);
    copyBankInfoToFields(bankId,that);
});

//fills in the customers based on which bank chosen
function populateCustomers(bankId) {
    clearFields();
    var customersSelection = document.getElementById("customers");
    bankId = parseInt(bankId);
    var optionsCustomers = '<option data-bank-id="-1" data-customer-id="-1" value="" selected="">Select customer</option>';
    banks.forEach(function(bank) {
        if(parseInt(bank.id) === parseInt(bankId)) {
            bank.getCustomers().forEach(function(customer) {
             optionsCustomers += '<option data-bank-id="'+bankId+'" data-customer-id="'+customer.id+'" value="'+customer.id+'">'+customer.firstname + ' ' + customer.lastname+'</option>';
           });
            return;
        }
    });
    customersSelection.innerHTML = optionsCustomers;
}

//in case bank is edited copy banks info to input fields
function copyBankInfoToFields(bankId,that) {
    var bankName = document.getElementById('bank-name');
    var bankBIC = document.getElementById('bank-bic');
    var accountsSelect = document.getElementById('accounts');
    disableTransactions();
    if(parseInt(bankId)!==-1) {
        bankName.value = that.options[that.selectedIndex].textContent;
        bankBIC.value = that.value;
    } else {
        bankName.value = '';
        bankBIC.value = '';
    }
}

///when customer id gets changed -> populate accounts for the customer
var customersSelect = document.getElementById("customers");
customersSelect.addEventListener("change", function(event) {
    var that = this;
    var customerId = that.options[that.selectedIndex].getAttribute('data-customer-id');
    var bankId = that.options[that.selectedIndex].getAttribute('data-bank-id');
    populateAccounts(bankId,customerId);
    copyCustomerInfoToFields(customerId,that);
});

///fill in accounts to select box
function populateAccounts(_bankId,_customerId) {
    clearFields();
    var accountsSelect = document.getElementById("accounts");
    var bankId = parseInt(_bankId);
    var customerId = parseInt(_customerId);
    var optionsAccounts = '<option data-bank-id="-1" data-customer-id="-1" data-account-id="-1" value="" selected="">Select IBAN</option>';
    banks.forEach(function(bank) {
        if(bank.id == bankId) {
            bank.getCustomers().forEach(function(customer) {
                if(customer.id === customerId) {
                    customer.getAccounts().forEach(function(account){
                      optionsAccounts += '<option data-bank-id="'+bankId+'" data-customer-id="'+customerId+'" data-account-id="'+account.id+'" value="'+account.accountName+'">'+account.iban+'</option>';
                    });
                    return;
                }
           });
        }
    });
    accountsSelect.innerHTML = optionsAccounts;
}

///in case customer is edited
function copyCustomerInfoToFields(customerId,that){
    var firstName = document.getElementById('customer-firstname');
    var lastName = document.getElementById('customer-lastname');
    disableTransactions();
    var names = that.options[that.selectedIndex].textContent.split(' ');
    if(parseInt(customerId)!==-1) {
        firstName.value = names[0];
        lastName.value = names[1];
    } else {
        firstName.value = '';
        lastName.value = '';
    }
}

function disableTransactions() {
    var transactionDate = document.getElementById('transaction-date');
    var transactionAmount = document.getElementById('transaction-amount');
    var addNewTransaction = document.getElementById('addNewTransaction');
    transactionDate.value = ''; transactionAmount.value= '';
    transactionDate.disabled = true;
    transactionAmount.disabled = true;
    addNewTransaction.disabled = true;
}

function enableTransactions() {
    var transactionDate = document.getElementById('transaction-date');
    var transactionAmount = document.getElementById('transaction-amount');
    var addNewTransaction = document.getElementById('addNewTransaction');
    transactionDate.disabled = false;
    transactionAmount.disabled = false;
    addNewTransaction.disabled = false;
}

//when accountid gets changed
var accountsSelect = document.getElementById("accounts");
accountsSelect.addEventListener("change", function(event) {
    var that = this;
    var customerId = that.options[that.selectedIndex].getAttribute('data-customer-id');
    var bankId = that.options[that.selectedIndex].getAttribute('data-bank-id');
    var accountId = that.options[that.selectedIndex].getAttribute('data-account-id');
    copyAccountInfoToFields(accountId,that);
    displayTransactions(bankId,customerId,accountId);
});

function copyAccountInfoToFields(accountId,that) {
    var accountName = document.getElementById('account-name');
    var accountIban = document.getElementById('account-iban');
    if(parseInt(accountId)!==-1) {
        accountName.value = that.value;
        accountIban.value = that.options[that.selectedIndex].textContent;
        enableTransactions();
    } else {
        accountName.value = '';
        accountIban.value = '';
        disableTransactions();
    }
}

//finally display the transactions for chosen accountid (bankid, customerid helping in the operation)
function displayTransactions(bankId,customerId,accountId) {
    var transactionsUl = document.getElementById("transactions");
    bankId = parseInt(bankId);customerId = parseInt(customerId);accountId = parseInt(accountId);
    var lisTransactions = '';
    banks.forEach(function(bank) {
        if(bank.id == bankId) {
            bank.getCustomers().forEach(function(customer) {
                if(customer.id === customerId) {
                    customer.getAccounts().forEach(function(account){
                        if(parseInt(account.id) === accountId) {
                          account.getTransactions().forEach(function(transaction){
                            lisTransactions+='<li class="mdc-list-item">'+transaction.date+'<span class="amount">'+transaction.amount+'&euro;</span></li>';
                          });
                         return;
                        }
                    });
                }
            });
        }
    });
    transactionsUl.innerHTML = lisTransactions;
}

function clearFields() {
    var accountsSelect = document.getElementById('accounts');
    accountsSelect.innerHTML = '<option data-bank-id="-1" data-customer-id="-1" data-account-id="-1" value="" selected>Select IBAN</option>';
    var firstName = document.getElementById('customer-firstname');
    var lastName = document.getElementById('customer-lastname');
    var accountName = document.getElementById('account-name');
    var accountIban = document.getElementById('account-iban');
    firstName.value = "";
    lastName.value = "";
    accountName.value = "";
    accountIban.value = "";
    var transactionsUl = document.getElementById("transactions");
    transactionsUl.innerHTML = "";
    var transactionDate = document.getElementById('transaction-date');
    var transactionAmount = document.getElementById('transaction-amount');
    transactionDate.value='';transactionAmount.value='';
}