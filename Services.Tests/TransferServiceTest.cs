using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace Services.Tests
{
    [TestClass]
    public class TransferServiceTest 
    {

        [TestMethod]
        public void TransferWithdrawsAndDeposits() 
        {
            double initialFromAmount = 1000;
            double initialToAmount = 500;
            double amount = 10;

            IAccount fromAccount = new SavingsAccount(36241604394L, initialFromAmount, new Customer());
            IAccount toAccount = new SavingsAccount(36241604394L, initialToAmount, new Customer());

            TransferService service = new TransferService(fromAccount, toAccount);

            try 
            {
                service.Transfer(amount);
            } 
            catch (InnsufficientFundsException e) 
            {
                Assert.Fail("Should not throw an exception");
            }

            Assert.AreEqual(initialFromAmount - amount, fromAccount.GetAmount());
            Assert.AreEqual(initialToAmount + amount, toAccount.GetAmount());
        }
    }
}
