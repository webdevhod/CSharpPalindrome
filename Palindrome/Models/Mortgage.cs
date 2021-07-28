using System;
using System.Collections.Generic;

namespace Palindrome.Models
{
    public class Mortgage
    {
        public string DownPayment { set; get; }
        public string Principal { set; get; }
        public string TotalInterest { set; get; }
        public string TotalCost { set; get; }
        public double HousePriceValue { set; get; }
        public double DownPaymentRateValue { set; get; }
        public double InterestRateValue { set; get; }
        public int YearsValue { set; get; }
        public List<List<string>> Result { set; get; } = new();
    }
}
