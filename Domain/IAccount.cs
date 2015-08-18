namespace Domain
{
    public interface IAccount 
    {
        long GetAccountNumber();
        Customer GetAccountOwner();
        double GetAmount();
        void SetAmount(double amount);
    }
}