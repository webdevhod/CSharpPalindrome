using System;
using System.Collections.Generic;

namespace Palindrome.Models
{
    public class LoanPayment
    {
        public int Month { set; get; }
        public double Payment { set; get; }
        public double Principal { set; get; }
        public double Interest { set; get; }
        public double TotalInterest { set; get; }
        public double Balance { set; get; }
    }
}
