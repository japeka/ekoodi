using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDBFormApp.Model
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            BankAccountTransaction = new HashSet<BankAccountTransaction>();
        }

        [Key]
        [Column("IBAN", TypeName = "nchar(50)")]
        public string Iban { get; set; }
        [Column(TypeName = "nchar(50)")]
        public string Name { get; set; }
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("BankAccount")]
        public Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("BankAccount")]
        public Customer Customer { get; set; }
        [InverseProperty("IbanNavigation")]
        public ICollection<BankAccountTransaction> BankAccountTransaction { get; set; }
    }
}
