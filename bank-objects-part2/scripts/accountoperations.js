function getMaxIdForAccount(accountsSelect){
    var options = accountsSelect.options;
    var max = -1;
    for(var i= 1; i<options.length; i++) {
        if(parseInt(options[i].attributes['data-account-id'].value) > max) {
            max = parseInt(options[i].attributes['data-account-id'].value);
        }
    }
    return ++max;
}

//Case: Add New Account
var btnAddAccount = document.getElementById("addAccount");
btnAddAccount.addEventListener("click", function(event) {
    var newAccountName = document.getElementById("account-name");
    var newIBAN = document.getElementById("account-iban");
    var customersSelect = document.getElementById("customers");
    var customerId = customersSelect.options[customersSelect.selectedIndex].attributes['data-customer-id'].value;
    var bankId = customersSelect.options[customersSelect.selectedIndex].attributes['data-bank-id'].value;
    var accountsSelect = document.getElementById("accounts");
    if(customerId==-1) return;
    if(newAccountName.value.length > 2&& newIBAN.value.length > 4) {
        var id = getMaxIdForAccount(accountsSelect);
        for(var i=0;i<banks.length;i++) {
            if(banks[i].id == bankId) {
                var customers = banks[i].getCustomers();
                for(var j=0; j < customers.length; j++){
                    if(customers[j].id==customerId){
                        var account = ekoodi.account(id,newAccountName.value,newIBAN.value);
                        customers[j].addAccount(account);
                        var newAccountOption = '<option data-bank-id="'+bankId+'" data-customer-id="'+customerId+'" data-account-id="'+id+'" value="'+newAccountName.value+'">'+newIBAN.value+'</option>';
                        accountsSelect.innerHTML = accountsSelect.innerHTML + newAccountOption;
                        accountsSelect.options[0].selected = true;
                        newAccountName.value = '';newIBAN.value = '';
                        return;
                    }
                }
            }
        }
    } else {
        alert("Please provide valid input for account name and iban!");
    }
});

function updateAccountInSelectList(accountsSelect,accountId,newAccountName,newIBAN){
    var options = accountsSelect.options;
    for(var i= 1; i<options.length; i++) {
        if(options[i].attributes['data-account-id'].value == accountId) {
            options[i].attributes['value'].value = newAccountName;
            options[i].textContent = newIBAN;
            break;
        }
    }
}

//Case: Edit Account
var btnEditAccount = document.getElementById("editAccount");
btnEditAccount.addEventListener("click", function(event) {
    var newAccountName = document.getElementById("account-name");
    var newIBAN = document.getElementById("account-iban");
    var accountsSelect = document.getElementById("accounts");
    var bankId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-bank-id'].value;
    var customerId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-customer-id'].value;
    var accountId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-account-id'].value;
    if(accountId==-1) return;
    for(var i=0;i<banks.length;i++) {
        if(banks[i].id == bankId) {
            var customers = banks[i].getCustomers();
            for(var j=0; j < customers.length; j++){
                if(customers[j].id==customerId) {
                    var accounts = customers[j].getAccounts();
                    for(var k=0;k < accounts.length; k++){
                        if(accounts[k].id==accountId) {
                            accounts[k] = ekoodi.account(accountId,newAccountName.value,newIBAN.value);
                            updateAccountInSelectList(accountsSelect,accountId,newAccountName.value,newIBAN.value);
                            return;
                        }
                    }
                }
            }
        }
    }
});

//Case: Remove Account
var btnRemoveAccount = document.getElementById("removeAccount");
btnRemoveAccount.addEventListener("click", function(event) {
    var accountsSelect = document.getElementById("accounts");
    var customerId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-customer-id'].value;
    var bankId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-bank-id'].value;
    var accountId = accountsSelect.options[accountsSelect.selectedIndex].attributes['data-account-id'].value;
    var transactions = document.getElementById("transactions");
    if(accountId==-1) return;

    for(var i=0;i<banks.length;i++) {
        if(banks[i].id == bankId) {
            var customers = banks[i].getCustomers();
            for(var j=0; j < customers.length; j++){
                if(customers[j].id==customerId) {
                    var accounts = customers[j].getAccounts();
                    var ind = 0;
                    for(;ind < accounts.length; ind++) {
                        if(accounts[ind].id==accountId) {
                            customers[j].removeAccount(ind);
                            accountsSelect.remove(accountsSelect.selectedIndex);
                            accountsSelect.options[0].selected = true;
                            var accountName = document.getElementById("account-name");
                            var accountIban = document.getElementById("account-iban");
                            accountName.value ='';accountIban.value = '';
                            transactions.innerHTML='';
                            return;
                        }
                    }

                }
            }
        }
    }
});