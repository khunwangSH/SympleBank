using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public int SenderAccId { get; set; }
        public int RecieverAccId { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}
