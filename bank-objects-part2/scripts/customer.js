ekoodi.customer = function(_id,_firstname,_lastname) {
    var id = _id;
    var firstname = _firstname;
    var lastname = _lastname;
    var accounts = [];
    function addAccount(account){
        accounts.push(account);
    }
    function getAccounts(){
        return accounts;
    }

    function removeAccount(ind) {
        accounts.splice(ind,1);
    }

    return {
        id: id,
        firstname: firstname,
        lastname: lastname,
        addAccount: addAccount,
        getAccounts: getAccounts,
        removeAccount: removeAccount
    }
};

