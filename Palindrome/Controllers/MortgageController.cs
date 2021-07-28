using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            List<List<string>> result = mortgage.Result;
            int months = mortgage.YearsValue * 12;
            double downPayment = mortgage.HousePriceValue * mortgage.DownPaymentRateValue / 100;
            double balance = mortgage.HousePriceValue - downPayment;
            double totalPrincipal = balance;
            double interestRateValueMonths = mortgage.InterestRateValue / 100 / 12;
            double principal, interest, totalInterest = 0;
            double payment = (balance * interestRateValueMonths) / (1 - Math.Pow(1 + interestRateValueMonths, -months));

            for(int i = 0; i < months; ++i) {
                interest = balance * interestRateValueMonths;
                totalInterest += interest;
                principal = payment - interest;

                if(principal > balance) {
                principal = balance;
                }

                balance -= principal;
    
                result.Add(new List<string> {DoubleToString(payment), DoubleToString(principal), DoubleToString(interest), DoubleToString(totalInterest), DoubleToString(balance)});
            }
            
            mortgage.DownPayment = DoubleToString(downPayment);
            mortgage.Principal = DoubleToString(totalPrincipal);
            mortgage.TotalInterest = DoubleToString(totalInterest);
            mortgage.TotalCost = DoubleToString(totalPrincipal + totalInterest);

            return View(mortgage);
        }

        private string DoubleToString(double d) {
            return Math.Round(d, 2, MidpointRounding.AwayFromZero).ToString("C", new CultureInfo("en-US"));
        }
    }
}
