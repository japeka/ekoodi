function getMaxIdForCustomer(customersSelect) {
    var options = customersSelect.options;
    var max = -1;
    for(var i= 1; i<options.length; i++) {
        if(parseInt(options[i].attributes['data-customer-id'].value) > max) {
            max = parseInt(options[i].attributes['data-customer-id'].value);
        }
    }
    return ++max;
}

//Case: Add New Customer
var btnAddNewCustomer = document.getElementById("addCustomer");
btnAddNewCustomer.addEventListener("click", function(event) {
    var newFirstName = document.getElementById("customer-firstname");
    var newLastName = document.getElementById("customer-lastname");
    var customersSelect = document.getElementById("customers");
    var banksSelect = document.getElementById("banks");
    var bankId = banksSelect.options[banksSelect.selectedIndex].attributes['data-bank-id'].value;
    if(bankId ==-1) return;
    if(newFirstName.value.length > 3 && newLastName.value.length > 3) {
        var id = getMaxIdForCustomer(customersSelect);
        for(var i=0;i<banks.length;i++) {
            if(banks[i].id == bankId) {
                var customer = ekoodi.customer(id,newFirstName.value,newLastName.value);
                banks[i].addCustomer(customer);
                var newCustomerOption = '<option data-bank-id="'+bankId+'" data-customer-id="'+id+'" value="'+id+'">'+newFirstName.value + ' ' + newLastName.value+'</option>';
                customersSelect.innerHTML = customersSelect.innerHTML + newCustomerOption;
                customersSelect.options[0].selected = true;
                newFirstName.value = '';newLastName.value = '';
                clearFields();
                return;
            }
        }
    } else {
        alert("Please provide valid input for first and last name!");
    }
});

function updateCustomerInSelectList(customersSelect,customerId,newFirstName,newLastName){
    var options = customersSelect.options;
    for(var i= 1; i<options.length; i++) {
        if(options[i].attributes['data-customer-id'].value == customerId) {
            options[i].attributes['value'].value = customerId;
            options[i].attributes['data-customer-id'].value = customerId;
            options[i].textContent = newFirstName + ' ' + newLastName;
            break;
        }
    }
}

//Case: Edit Customer
var btnEditCustomer = document.getElementById("editCustomer");
btnEditCustomer.addEventListener("click", function(event) {
    var newFirstName = document.getElementById("customer-firstname");
    var newLastName = document.getElementById("customer-lastname");
    var customersSelect = document.getElementById("customers");
    var customerId = customersSelect.options[customersSelect.selectedIndex].attributes['data-customer-id'].value;
    var bankId = customersSelect.options[customersSelect.selectedIndex].attributes['data-bank-id'].value;
    if(customerId==-1) return;
    if(newFirstName.value.length > 1 && newLastName.value.length > 2) {
        for(var i=0;i<banks.length;i++) {
            if(banks[i].id == bankId) {
                var customers = banks[i].getCustomers();
                for(var j=0;j<customers.length; j++) {
                    if(customers[j].id == customerId) {
                        customers[j] = ekoodi.customer(customerId,newFirstName.value,newLastName.value);
                        updateCustomerInSelectList(customersSelect,customerId,newFirstName.value,newLastName.value);
                        return;
                    }
                }
            }
        }
    } else {
        alert("Please provide valid input for first and last name!");
    }
});

var btnRemoveCustomer = document.getElementById("removeCustomer");
btnRemoveCustomer.addEventListener("click", function(event) {
    var customersSelect = document.getElementById("customers");
    var customerId = customersSelect.options[customersSelect.selectedIndex].attributes['data-customer-id'].value;
    var bankId = customersSelect.options[customersSelect.selectedIndex].attributes['data-bank-id'].value;
    if(customerId==-1) return;
    for(var i=0;i<banks.length;i++) {
        if(banks[i].id == bankId) {
            var customers = banks[i].getCustomers();
            var ind = 0;
            for(;ind<customers.length; ind++) {
                if(customers[ind].id == customerId) {
                    banks[i].removeCustomer(ind);
                    customersSelect.remove(customersSelect.selectedIndex);
                    customersSelect.options[0].selected = true;
                    var firstName = document.getElementById("customer-firstname");
                    var lastName = document.getElementById("customer-lastname");
                    firstName.value ='';lastName.value = '';
                    clearFields();
                    return;
                }
            }
        }
    }
});

