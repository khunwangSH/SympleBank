using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data.Entities
{
    public enum AccountStatus { 
        Closed,
        Open,
        Suspended
    }
    public class BankAccount : BaseEntity
    {
        public int Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }

        [ConcurrencyCheck]
        public double Balance { get; set; }
        public AccountStatus Status { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public BankUser User { get; set; }
    }
}
