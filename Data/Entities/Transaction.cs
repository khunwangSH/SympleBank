using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data.Entities
{
    public enum TransactionStatus
    {
        Canceled,
        Completed,
        Pendding,
        Suspended,
    }

    public enum TransactionType
    {
        Deposite,
        Withdraw,
        Transfer
    }
    public class Transaction : BaseEntity
    {
        public int Id { get; set; }
        public BankAccount SenderAcc { get; set; }
        public BankAccount RecieverAcc { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
