using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleBank.Data;
using SimpleBank.Data.Entities;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBankRepository _repository;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IBankRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            ViewBag.BankUsers = _repository.GetAllBankUser();
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(BankAccountViewModel model)
        {
            ViewBag.BankUsers = _repository.GetAllBankUser();
            if(ModelState.IsValid)
            {
                var newOrder = _mapper.Map<BankAccountViewModel, BankAccount>(model);

              

                _repository.AddEntity(newOrder);
                if (_repository.SaveAll())
                {
                    ViewBag.Msg = "Create Success!";
                }
            }
            
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
