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
        void UpdateEntity(object model);
         void AddEntity(object model);

        void CreateAccount(BankAccount newAccount);

         void CreateTransaction(Transaction newTransaction);

         IEnumerable<Transaction> GetTransactionsByAccountId(int id);


         BankAccount GetBankAccountById(int id);

         BankAccount GetBankAccountById(string username, int id);

        IEnumerable<BankAccount> GetAllBankAccountOpened();
        IEnumerable<BankUserViewModel> GetAllBankUser();
        BankUser GetBankUserById(string id);
        bool IsIBANNumberExist(string IBAN);
        bool SaveAll();
    }
}
