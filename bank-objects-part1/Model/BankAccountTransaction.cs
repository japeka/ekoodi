using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDBFormApp.Model
{
    public partial class BankAccountTransaction
    {
        public int Id { get; set; }
        [Required]
        [Column("IBAN", TypeName = "nchar(50)")]
        public string Iban { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("BankAccountTransaction")]
        public BankAccount IbanNavigation { get; set; }
    }
}
