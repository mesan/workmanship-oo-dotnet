using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

[TestClass]
public class AccountServiceTest
{
    AccountService service = new AccountService();

    [TestMethod]
    public void DepositAddsMoney()
    {
        IAccount account = new SavingsAccount(36241604394L, 100.0, new Customer());
        service.Deposit(account, 100.0);
        
        Assert.AreEqual(200.0, account.GetAmount());
    }
    
    [TestMethod]
    public void WithdrawRemovesMoney() 
    {
        IAccount account = new SavingsAccount(36241604394L, 100.0, new Customer());
        service.Withdraw(account, 50.0);
        
        Assert.AreEqual(50.0, account.GetAmount());
    }
    
    [TestMethod, ExpectedException(typeof(InnsufficientFundsException))]
    public void WithdrawDoesNotOwerdraw() 
    {
        IAccount account = new SavingsAccount(36241604394L, 100.0, new Customer());
        service.Withdraw(account, 150.0);
    }
    
    [TestMethod]
    public void WithdrawAllowsMoreThanCurrentAmountForCheckingAccount() 
    {
        IAccount account = new CheckingAccount(36241604394L, 100.0, 70.0, new Customer());
        service.Withdraw(account, 150.0);
        Assert.AreEqual(-50.0, account.GetAmount());
    }
    
    [TestMethod, ExpectedException(typeof(InnsufficientFundsException))]
    public void WithdrawDoesNotOwerdrawAmountPlusCredit() 
    {
        IAccount account = new CheckingAccount(36241604394L, 100.0, 70.0, new Customer());
        service.Withdraw(account, 180.0);
    }
}
