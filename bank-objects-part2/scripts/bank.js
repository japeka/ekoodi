ekoodi.bank = function(_id,_name,_bic){

    var id = _id;
    var name = _name;
    var bic = _bic;
    var customers = [];

    function addCustomerToBank(customer){
        customers.push(customer);
    }

    function getCustomers(){
      return customers;
    }

    function removeCustomer(ind){
      customers.splice(ind,1);
    }

    return {
        id: id,
        name: name,
        bic: bic,
        addCustomer: addCustomerToBank,
        getCustomers: getCustomers,
        removeCustomer: removeCustomer
    }

};

