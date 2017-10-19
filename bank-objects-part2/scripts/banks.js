ekoodi.banks = function(){
    var banks = [];

    function addBank(bank) {
        banks.push(bank);
    }

    function getBanks(){
        return banks;
    }

    function removeBank(ind) {
      banks.splice(ind,1);
    }

    return {
        addBank: addBank,
        getBanks: getBanks,
        removeBank: removeBank
    }
};
