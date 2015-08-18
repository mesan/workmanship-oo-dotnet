using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class CheckingAccountTest 
    {
        private const long ValidAccountNumber = 36241604394L;
        private const long InvalidAccountNumber = 36241604393L;

        private Customer customer = new Customer();
    
        [TestMethod]
        public void NewAccountShouldBeCorrect() 
        {
            var account = new CheckingAccount(ValidAccountNumber, 100.0, 50.0 ,customer);

            Assert.AreEqual(36241604394L, account.GetAccountNumber());
            Assert.AreEqual(100.0, account.GetAmount());
            Assert.AreEqual(50.0, account.GetCreditLimit());
            Assert.AreSame(customer, account.GetAccountOwner());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void NewAccountShouldNotAcceptInvalidAccountNumber() 
        {
            new CheckingAccount(InvalidAccountNumber, 0.0, 100.0, customer);
        }
    }
}
