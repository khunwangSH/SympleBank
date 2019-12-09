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
            if (ModelState.IsValid)
            {
                if (model.Amount > 0)
                {
                    var charge = _configuration.GetValue<float>("DepositeCharge");
                    var depositePercent = Math.Round((100.0 - charge) / 100.0, 3);
                    var newDeposite = _mapper.Map<TransactionViewModel, Transaction>(model);
                    var customerAccount = _repository.GetBankAccountById(model.SenderAccId);

                    newDeposite.Amount = model.Amount * depositePercent;
                    newDeposite.Type = TransactionType.Deposite;
                    newDeposite.Status = TransactionStatus.Completed;
                    newDeposite.SenderAcc = customerAccount;
                    newDeposite.RecieverAcc = customerAccount;
                    newDeposite.TransferDate = DateTime.UtcNow;

                    customerAccount.Balance = Math.Round(customerAccount.Balance + newDeposite.Amount,2);

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
                else
                {
                    ModelState.AddModelError(String.Empty,"Amount should > 0");
                }
                
            }

            ViewBag.Accounts = _repository.GetAllBankAccountOpened();
            return View(model);
        }
        public IActionResult Transfer()
        {
            ViewBag.Accounts = _repository.GetAllBankAccountOpened();

            return View();
        }
        [HttpPost]
        public IActionResult Transfer(TransactionViewModel model)
        {
            var isValid = true;
            if (ModelState.IsValid)
            {
                if(model.SenderAccId == model.RecieverAccId)
                {
                    ModelState.AddModelError(String.Empty, "'From' account should be different from 'To' account");

                    isValid = false;
                }

                var senderAccount = _repository.GetBankAccountById(model.SenderAccId);

                if (model.Amount > senderAccount.Balance && isValid)
                {

                    ModelState.AddModelError(String.Empty, "The transfer amount should less than the balance of 'From' account");
                    isValid = false;
                }

                if (model.Amount > 0 && isValid)
                {
                    var newDeposite = _mapper.Map<TransactionViewModel, Transaction>(model);
                    var recieverAccount = _repository.GetBankAccountById(model.RecieverAccId);

                    newDeposite.Type = TransactionType.Transfer;
                    newDeposite.Status = TransactionStatus.Completed;
                    newDeposite.SenderAcc = senderAccount;
                    newDeposite.RecieverAcc = recieverAccount;
                    newDeposite.TransferDate = DateTime.UtcNow;

                    senderAccount.Balance = Math.Round(senderAccount.Balance - newDeposite.Amount,3);
                    recieverAccount.Balance = Math.Round(recieverAccount.Balance+newDeposite.Amount,3);

                    _repository.AddEntity(newDeposite);
                    _repository.UpdateEntity(senderAccount);
                    _repository.UpdateEntity(recieverAccount);
                    try
                    {
                        if (_repository.SaveAll())
                        {
                            ViewBag.Msg = "Tranfered!";
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
                else
                {
                    if(isValid)
                        ModelState.AddModelError(String.Empty, "Amount should > 0");

                    isValid = false;
                }

            }

            ViewBag.Accounts = _repository.GetAllBankAccountOpened();
            return View(model);
        }
    }
}