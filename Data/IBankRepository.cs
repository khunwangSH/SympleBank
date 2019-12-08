using SimpleBank.Data.Entities;
using SimpleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public interface IBankRepository
    {

         void AddEntity(object model);

        void CreateAccount(BankAccount newAccount);

         void CreateTransaction(Transaction newTransaction);

         IEnumerable<Transaction> GetTransactionsByAccountId(int id);


         BankAccount GetBankAccountById(int id);

         BankAccount GetBankAccountById(string username, int id);

        IEnumerable<BankUserViewModel> GetAllBankUser();
        bool SaveAll();
    }
}
