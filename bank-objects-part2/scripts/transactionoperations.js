
//Case : Add New Transaction
var btnAddNewTranstion = document.getElementById("addNewTransaction");
btnAddNewTranstion.addEventListener("click", function(event) {
    var transactionDate = document.getElementById("transaction-date");
    var transactionAmount = document.getElementById("transaction-amount");
    if(transactionDate.value.length > 9 && !isNaN(transactionAmount.value)) {
        var accountsSelect = document.getElementById("accounts");
        var bankId = accountsSelect.options[accountsSelect.selectedIndex].getAttribute('data-bank-id');
        var customerId = accountsSelect.options[accountsSelect.selectedIndex].getAttribute('data-customer-id');
        var accountId = accountsSelect.options[accountsSelect.selectedIndex].getAttribute('data-account-id');
        var transactions = document.getElementById("transactions");
        for(var i=0;i<banks.length;i++) {
            if(banks[i].id == bankId) {
                var customers = banks[i].getCustomers();
                for(var j=0;j<customers.length;j++) {
                    if(customers[j].id == customerId) {
                        var accounts = customers[j].getAccounts();
                        for(var k = 0; k < accounts.length; k++) {
                            if(accounts[k].id == accountId) {
                                var transaction = ekoodi.transaction(transactionDate.value,transactionAmount.value);
                                accounts[k].addTransaction(transaction);
                                var li = '<li class="mdc-list-item">'+transactionDate.value+'<span class="amount">'+transactionAmount.value+'€</span></li>';
                                transactions.innerHTML = transactions.innerHTML + li;
                                transactionDate.value = ''; transactionAmount.value = '';
                                return;
                            }
                        }
                    }
                }
            }
        }
    } else {
        alert("Please provide valid input for transaction date and amount!");
    }
});
