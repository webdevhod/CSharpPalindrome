using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Helpers;
using Palindrome.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Palindrome.Controllers
{
    public class MortgageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Mortgage model = new();
            model.HousePriceValue = 850000.00;
            model.DownPaymentRateValue = 20.00;
            model.InterestRateValue = 3.00;
            model.YearsValue = 30;
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Index(Mortgage mortgage)
        {
            LoanHelper loanhelp = new();
            loanhelp.CalculatePayments(mortgage);
            return View(mortgage);
        }
    }
}
