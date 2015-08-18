using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

public class AccountUtilTest 
{

    [TestMethod]
    public void TestValidAccountNumber() 
    {
        Assert.IsTrue(AccountUtil.ValidAccountNumber(36241604394L));
        Assert.IsFalse(AccountUtil.ValidAccountNumber(36241604393L));
    }

    [TestMethod]
    public void TestGyldigFnr() 
    {
        Assert.IsTrue(AccountUtil.GyldigFnr("17050355543"));
        Assert.IsFalse(AccountUtil.GyldigFnr("45114304788"));
    }
}
