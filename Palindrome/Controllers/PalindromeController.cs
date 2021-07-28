using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Models;
using System.Text.RegularExpressions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Palindrome.Controllers
{
    public class PalindromeController : Controller
    {
        private Regex regex = new Regex(@"[a-zA-z0-9]");
        [HttpGet]
        public IActionResult Index()
        {
            TacoCat model = new();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
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

        private bool checkValidChar(string c) {
        return regex.IsMatch(c);
    }
    }
}
