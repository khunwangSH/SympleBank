using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SimpleBank.Data.Entities;
using SimpleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public class BankRepository : IBankRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ILogger<BankRepository> _logger;
        private readonly UserManager<BankUser> _userManager;

        public BankRepository(ApplicationDbContext ctx, ILogger<BankRepository> logger, UserManager<BankUser> userManager)
        {
            _ctx = ctx;
            _logger = logger;
            _userManager = userManager;
        }

        public void UpdateEntity(object model)
        {
            _ctx.Update(model);
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

        public bool IsIBANNumberExist(string IBAN)
        {
            return _ctx.BankAccounts
                        .Any(w => w.IBAN == IBAN);
        }


        public BankAccount GetBankAccountById(int id)
        {
            return _ctx.BankAccounts.Where(w => w.Id == id).FirstOrDefault();
        }

        public BankAccount GetBankAccountById(string username, int id)
        {
            return _ctx.BankAccounts.Where(w => w.Id == id && w.User.UserName == username).FirstOrDefault();
        }

        public IEnumerable<BankUserViewModel> GetAllBankUser()
        {
            return _userManager.Users
                    .Where(w => w.UserName != "admin" && w.IsActive == true)
                    .Select(s => new BankUserViewModel { 
                        UserId = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    })
                    .ToList();
        }
        public BankUser GetBankUserById(string id)
        {
            return _userManager.Users
                    .Where(w => w.Id == id)
                    .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<BankAccount> GetAllBankAccountOpened()
        {
            return _ctx.BankAccounts.Where(w => w.Status == AccountStatus.Open);
                    
        }
    }
}
