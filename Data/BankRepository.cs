using Microsoft.Extensions.Logging;
using SimpleBank.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public class BankRepository : IBankRepository
    {
        private ApplicationDbContext _ctx { get; set; }
        public ILogger<BankRepository> _logger { get; set; }

        public BankRepository(ApplicationDbContext ctx, ILogger<BankRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void CreateAccount(BankAccount newAccount)
        {
            AddEntity(newAccount);
        }

        public void CreateTransaction(Transaction newTransaction)
        {
            AddEntity(newTransaction);
        }

        public IEnumerable<Transaction> GetTransactionsByAccountId(int id)
        {
            return _ctx.Transactions
                        .Where(w => w.SenderAcc.Id == id || w.RecieverAcc.Id == id)
                        .ToList();
        }


        public BankAccount GetBankAccountById(int id)
        {
            return _ctx.BankAccounts.Where(w => w.Id == id).FirstOrDefault();
        }

        public BankAccount GetBankAccountById(string username, int id)
        {
            return _ctx.BankAccounts.Where(w => w.Id == id && w.User.UserName == username).FirstOrDefault();
        }
    }
}
