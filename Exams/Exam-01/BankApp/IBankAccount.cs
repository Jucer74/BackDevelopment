public enum AccountType
{
    Saving, 
    Checking 
}

public interface IBankAccount
{
    string AccountNumber { get; }
    string AccountOwner { get; }
    decimal BalanceAmount { get; }
    AccountType AccountType { get; }

    void Deposit(decimal amount);
    void Withdrawal(decimal amount);
}