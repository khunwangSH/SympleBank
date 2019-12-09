using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleBank.Data;
using SimpleBank.Data.Entities;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankRepository _repository;
        private readonly ILogger<BankAccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public BankAccountController(IBankRepository repository,
                                      ILogger<BankAccountController> logger,
                                      IMapper mapper,
                                      IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }
        public IActionResult Deposite()
        {
            var accounts = _repository.GetAllBankAccountOpened();
            ViewBag.Accounts = accounts;
            var firstAccount = accounts.FirstOrDefault();
            var model = new TransactionViewModel();
            if (firstAccount != null)
            {
                 model = new TransactionViewModel() { 
                                SenderAccId = firstAccount.Id,
                                Balance = firstAccount.Balance
                            };
            }
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Deposite(TransactionViewModel model)
        {
            ViewBag.Accounts = _repository.GetAllBankAccountOpened();
            if (ModelState.IsValid)
            {
                var charge = _configuration.GetValue<float>("DepositeCharge");
                var depositePercent = Math.Round((100.0 - charge) / 100.0, 5);
                var newDeposite = _mapper.Map<TransactionViewModel, Transaction>(model);
                var customerAccount = _repository.GetBankAccountById(model.SenderAccId);

                newDeposite.Amount = model.Amount * depositePercent;
                newDeposite.Type = TransactionType.Deposite;
                newDeposite.Status = TransactionStatus.Completed;
                newDeposite.SenderAcc = customerAccount;
                newDeposite.RecieverAcc = customerAccount;
                newDeposite.TransferDate = DateTime.UtcNow;

                customerAccount.Balance += newDeposite.Amount;

                _repository.AddEntity(newDeposite);
                _repository.UpdateEntity(customerAccount);
                try
                {
                    if (_repository.SaveAll())
                    {
                        ViewBag.Msg = "Deposite Success!";
                        model.Balance = customerAccount.Balance;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The balance was updated by another user.");
                    }
                }
            }
            return View(model);
        }
        public IActionResult Transfer()
        {
            return View();
        }
    }
}