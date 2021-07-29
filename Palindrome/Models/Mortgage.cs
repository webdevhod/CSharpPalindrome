using System;
using System.Collections.Generic;

namespace Palindrome.Models
{
    public class Mortgage
    {
        public double DownPayment { set; get; }
        public double Principal { set; get; }
        public double TotalInterest { set; get; }
        public double TotalCost { set; get; }
        public double HousePriceValue { set; get; }
        public double DownPaymentRateValue { set; get; }
        public double InterestRateValue { set; get; }
        public int YearsValue { set; get; }
        public List<LoanPayment> Result { set; get; } = new List<LoanPayment>();
    }
}
