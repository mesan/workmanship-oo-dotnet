using System;
using Domain;
using Exceptions;

namespace Service
{
    public class TransferService {

        private IAccount fromAccount;
        private IAccount toAccount;

        public TransferService(IAccount fromAccount, IAccount toAccount) 
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
        }

        /**
     * Ikke pen, med vilje :-)
     * 
     * @param amount
     * @throws InnsufficientFundsException
     */
        public void Transfer(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }

            if (fromAccount is CheckingAccount)
            {
                CheckingAccount checkingAccount = (CheckingAccount) fromAccount;

                if (checkingAccount.GetAmount() + checkingAccount.GetCreditLimit() < amount)
                {
                    throw new InnsufficientFundsException();
                }
            } 
            else
            {
                if (fromAccount.GetAmount() < amount)
                {
                    throw new InnsufficientFundsException();
                }
            }

            fromAccount.SetAmount(fromAccount.GetAmount() - amount);
            toAccount.SetAmount(toAccount.GetAmount() + amount);
        }
    }
}
