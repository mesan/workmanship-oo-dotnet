using System;
using Utils;

namespace Domain
{
    public class CheckingAccount : IAccount 
    {
        private long accountNumber;
        private double amount;
        private double creditLimit;
        private Customer accountOwner;

        public CheckingAccount(long accountNumber,
                               double initialAmount,
                               double creditLimit,
                               Customer accountOwner) 
        {
            if (!AccountUtil.ValidAccountNumber(accountNumber)) 
            {
                throw new ArgumentException();
            }

            this.accountNumber = accountNumber;
            this.amount = initialAmount;
            this.creditLimit = creditLimit;
            this.accountOwner = accountOwner;
        }

        public Double GetCreditLimit() 
        {
            return creditLimit;
        }
        
        public long GetAccountNumber() 
        {
            return accountNumber;
        }
        
        public Customer GetAccountOwner() 
        {
            return accountOwner;
        }
        
        public double GetAmount() {
            return amount;
        }
        
        public void SetAmount(double amount) 
{
            this.amount = amount;
        }
    }
}
