//Populates random data for banks, customers, accounts and transactions
var _banks = ekoodi.banks(); // initially _banks []

function getRandomName() {
    var vowels = ['a','e','i','u','y','o','ö','ä'];
    var consonants = ['q','w','r','t','p','s','d','f','g','h','j','k','z','x','c','v','b','n','m'];
    var lenFirstName = Math.floor(Math.random() * (9 - 2)) + 2;
    var lenLastName = Math.floor(Math.random() * (17 - 2)) + 2;
    var first = '';
    for(var i=0;i<lenFirstName; i++){
        if(i%2===0) {
          first+=consonants[Math.floor(Math.random() * 8)];
        } else {
          first+=vowels[Math.floor(Math.random() * 8)];
        }
    }
    var last = '';
    for(var i=0;i<lenLastName; i++) {
        if(i%2===0) {
          last+=consonants[Math.floor(Math.random() * 19)];
        } else {
          last+=vowels[Math.floor(Math.random() * 8)];
        }
    }
    var rnd = Math.floor(Math.random() * 20);
    return {first: first, last: last, rnd: rnd};
}

for(var i = 0; i < 5; i++) {
    var bank = ekoodi.bank(i+1,"Bank " + (i+1),"OKOFI1000" + (i+1));
    for(var j = 0; j < 5; j++) {
        var nameObj = getRandomName();
        var customer = ekoodi.customer((j+1), nameObj.first, nameObj.last);
        for(var k = 0; k < 4; k++) {
            var accountObj = getRandomName();
            account = ekoodi.account((k+1), 'Account ' + accountObj.first,"20920392039" + accountObj.rnd);
            for(var l = 0; l < 3; l++) {
                var rnd = Math.floor(Math.random() * 200);
                var amount = 0;
                if(l%2==0) { amount = rnd+1; } else {amount = -1*rnd-1;}
                var rndDays = Math.floor(Math.random() * 20);
                var d = new Date();d.setDate(d.getDate()-rndDays);
                var dates=d.toISOString().slice(0, 10).split('-');
                var newDate = dates[0] + '-' + dates[1] + '-' + dates[2];
                var transaction = ekoodi.transaction(newDate, amount);
                account.addTransaction(transaction);
            }
            customer.addAccount(account);
        }
        bank.addCustomer(customer);
    }
    _banks.addBank(bank);
}
