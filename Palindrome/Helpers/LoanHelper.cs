using System;
using Palindrome.Models;

namespace Palindrome.Helpers
{
    public class LoanHelper
    {
        public void CalculatePayments(Mortgage mortgage)
        {
            int months = calculateTotalMonths(mortgage.YearsValue);
            double downPayment = calculateDownPayment(mortgage.HousePriceValue, mortgage.DownPaymentRateValue);
            double balance = mortgage.HousePriceValue - downPayment;
            double totalPrincipal = balance;
            double interestRateValueMonths = calculateMonthlyInterest(mortgage.InterestRateValue);
            double principal, interest, totalInterest = 0;
            double payment = calculateMonthlyPayment(balance, months, interestRateValueMonths);

            for(int i = 1; i <= months; ++i) {
                interest = balance * interestRateValueMonths;
                totalInterest += interest;
                principal = payment - interest;

                if(principal > balance) {
                    principal = balance;
                }

                balance -= principal;
    
                LoanPayment loanpayment = new();

                loanpayment.Month = i;
                loanpayment.Payment = payment;
                loanpayment.Principal = principal;
                loanpayment.Interest = interest;
                loanpayment.TotalInterest = totalInterest;
                loanpayment.Balance = balance;

                mortgage.Result.Add(loanpayment);
            }
            
            mortgage.DownPayment = downPayment;
            mortgage.Principal = totalPrincipal;
            mortgage.TotalInterest = totalInterest;
            mortgage.TotalCost = totalPrincipal + totalInterest;
        }

        private int calculateTotalMonths(int years) {
            return years * 12;
        }
        private double calculateDownPayment(double houseprice, double rate) {
            return houseprice * rate / 100;
        }

        private double calculateMonthlyInterest(double annualRate) {
            return annualRate / 100 / 12;
        }
        private double calculateMonthlyPayment(double balance, int months, double interestRateValueMonths) {
            return (balance * interestRateValueMonths) / (1 - Math.Pow(1 + interestRateValueMonths, -months));
        }
    }
}
