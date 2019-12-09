using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBank.Controllers
{
    public class BankAccountController : Controller
    {
        public IActionResult Deposit()
        {
            return View();
        }
        public IActionResult Transfer()
        {
            return View();
        }
    }
}