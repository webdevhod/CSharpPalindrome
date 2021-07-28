using System;
using System.Collections.Generic;

namespace Palindrome.Models
{
    public class FizzBuzzMVC
    {
        public int FizzValue  { set; get; }
        public int BuzzValue  { set; get; }
        public List<string> Result { set; get; } = new();
    }
}
