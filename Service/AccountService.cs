using Domain;
using Exceptions;

namespace Service
{
    public class AccountService
    {

        public void Withdraw(IAccount account, double amount)
        {
            if (account is CheckingAccount)
            {
                var checkingAccount = (CheckingAccount) account;

                if (checkingAccount.GetAmount() + checkingAccount.GetCreditLimit() < amount)
                {
                    throw new InnsufficientFundsException();
                }
            }
            else
            {
                if (account.GetAmount() < amount)
                {
                    throw new InnsufficientFundsException();
                }
            }

            double oldAmount = account.GetAmount();
            account.SetAmount(oldAmount - amount);
        }

        public void Deposit(IAccount account, double amount)
        {
            double oldAmount = account.GetAmount();
            account.SetAmount(oldAmount + amount);
        }
    }
}
