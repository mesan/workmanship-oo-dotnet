using System;
using Utils;

namespace Domain
{
    public class SavingsAccount : IAccount 
    {
        private long accountNumber;
        private double amount;
        private Customer accountOwner;

        public SavingsAccount(long accountNumber, double initialAmount, Customer accountOwner) 
        {
            if (!AccountUtil.ValidAccountNumber(accountNumber)) 
            {
                throw new ArgumentException("AccountNumber");
            }

            this.accountNumber = accountNumber;
            this.amount = initialAmount;
            this.accountOwner = accountOwner;
        }

        
        public long GetAccountNumber() 
        {
            return accountNumber;
        }

        
        public Double GetAmount() 
        {
            return amount;
        }

        
        public void SetAmount(double amount) 
        {
            this.amount = amount;
        }

        
        public Customer GetAccountOwner() 
        {
            return accountOwner;
        }
    }
}
