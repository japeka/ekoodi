function getMaxIdForBank(banksSelect) {
    var options = banksSelect.options;
    var max = -1;
    for(var i= 1; i<options.length; i++) {
        if(parseInt(options[i].attributes['data-bank-id'].value) > max) {
            max = parseInt(options[i].attributes['data-bank-id'].value);
        }
    }
    return ++max;
}

//Case: Add New Bank
var btnAddNewBank = document.getElementById("addBank");
btnAddNewBank.addEventListener("click", function(event) {
    var newBankName = document.getElementById("bank-name");
    var newBankBIC = document.getElementById("bank-bic");
    var banksSelect = document.getElementById("banks");
    if(newBankName.value.length > 3 && newBankBIC.value.length > 3) {
        var id = getMaxIdForBank(banksSelect);
        var bank = ekoodi.bank(id,newBankName.value, newBankBIC.value);
        _banks.addBank(bank);
        banks = _banks.getBanks();
        var newBankOption = '<option data-bank-id="'+bank.id+'" value="'+bank.bic+'">'+bank.name+'</option>';
        banksSelect.innerHTML = banksSelect.innerHTML + newBankOption;
        banksSelect.options[0].selected = true;
        newBankName.value = '';newBankBIC.value = '';
        clearFields();
    } else {
        alert("Please provide valid input for bank name and bic code!");
    }
});


function updateBankInSelectList(banksSelect,bankId,bankName,bic){
    var options = banksSelect.options;
    for(var i= 1; i<options.length; i++) {
        if(options[i].attributes['data-bank-id'].value == bankId) {
            options[i].attributes['value'].value = bic;
            options[i].textContent = bankName;
            break;
        }
    }
}

//Case: Edit Bank
var btnEditNewBank = document.getElementById("editBank");
btnEditNewBank.addEventListener("click", function(event) {
    var newBankName = document.getElementById("bank-name");
    var newBankBIC = document.getElementById("bank-bic");
    var banksSelect = document.getElementById("banks");
    var bankId = banksSelect.options[banksSelect.selectedIndex].attributes['data-bank-id'].value;
    if(newBankName.value.length > 3 && newBankBIC.value.length > 3) {
        for(var i=0;i<banks.length;i++) {
            if(banks[i].id == bankId) {
                banks[i] = ekoodi.bank(bankId,newBankName.value,newBankBIC.value);
                updateBankInSelectList(banksSelect,bankId,newBankName.value,newBankBIC.value);
                return;
            }
        }
    } else {
        alert("Please provide valid input for bank name and bic code!");
    }
});

//Case: Remove Bank
var btnRemoveBank = document.getElementById("removeBank");
btnRemoveBank.addEventListener("click", function(event) {
    var banksSelect = document.getElementById("banks");
    var bankId = banksSelect.options[banksSelect.selectedIndex].attributes['data-bank-id'].value;
    if(bankId==-1) return;
    var ind = 0;
    for(;ind<banks.length;ind++) {
        if(banks[ind].id == bankId) {break;}
    }
    _banks.removeBank(ind);banks = _banks.getBanks();
    banksSelect.remove(banksSelect.selectedIndex);
    var bankName = document.getElementById("bank-name");
    var bankBIC = document.getElementById("bank-bic");
    bankName.value ='';
    bankBIC.value = '';
    clearFields();
});

