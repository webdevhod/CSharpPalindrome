using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Palindrome.Models;

namespace Palindrome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Regex regex = new Regex(@"[a-zA-z0-9]");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TacoCat model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TacoCat tacocat)
        {
            string inputWord = tacocat.InputWord;
            int startIndex = 0;
            int endIndex = inputWord.Length - 1;
            bool isPalindrome = false;
            tacocat.Show = true;

            while (startIndex < endIndex) {
                if (!checkValidChar(tacocat.InputWord[startIndex].ToString())) {
                    startIndex += 1;
                } else if (!checkValidChar(tacocat.InputWord[endIndex].ToString())) {
                    endIndex -= 1;
                } else if (char.ToLower(tacocat.InputWord[startIndex]) == char.ToLower(tacocat.InputWord[endIndex])) {
                    startIndex += 1;
                    endIndex -= 1;
                } else {
                    break;
                }
            }

            isPalindrome = startIndex >= endIndex;
            tacocat.IsPalindrome = isPalindrome;
            // Console.WriteLine($"start: {startIndex} end: {endIndex} palindrome: {isPalindrome}");
            
            if(isPalindrome) {
                tacocat.Message = $"\"{tacocat.InputWord}\" is a palindrome!";
            } else {
                tacocat.Message = $"\"{tacocat.InputWord}\" is not a palindrome.";
            }

            return View(tacocat);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool checkValidChar(string c) {
            return regex.IsMatch(c);
        }
    }
}
