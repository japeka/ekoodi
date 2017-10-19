ekoodi.account = function(_id,_account,_iban) {
    var id = _id;
    var accountName = _account;
    var iban = _iban;
    var transactions = [];

    function addTransaction(transaction) {
        transactions.push(transaction);
    }

    function getTransactions(){
        return transactions;
    }

    return {
        id: id,
        accountName: accountName,
        iban: iban,
        addTransaction: addTransaction,
        getTransactions: getTransactions
    }
};

