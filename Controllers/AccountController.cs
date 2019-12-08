using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleBank.Data.Entities;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<BankUser> _signInManager;
        public AccountController(ILogger<AccountController> logger,
                                    SignInManager<BankUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }

            ModelState.AddModelError("","Failed to login");
            return View();
        }
    }
}