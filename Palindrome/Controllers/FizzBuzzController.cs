using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Palindrome.Controllers
{
    public class FizzBuzzController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            FizzBuzzMVC fizzbuzz = new();
            fizzbuzz.FizzValue = 3;
            fizzbuzz.BuzzValue = 5;
            return View(fizzbuzz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FizzBuzzMVC fizzbuzz)
        {
            bool fizz, buzz;
            List<string> result = fizzbuzz.Result;

            for(int i = 1; i <= 100; ++i) {
                fizz = i % fizzbuzz.FizzValue == 0;
                buzz = i % fizzbuzz.BuzzValue == 0;
                if(fizz) {
                    if(buzz) {
                        result.Add("FizzBuzz");
                    } else {
                        result.Add("Fizz");
                    }
                } else if (buzz) {
                    result.Add("Buzz");
                } else {
                    result.Add(i.ToString());
                }
            }

            return View(fizzbuzz);
        }
    }
}
