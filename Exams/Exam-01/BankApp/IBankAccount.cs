using System.Diagnostics.Contracts;

public interface IBankAccount
{
    string acccountNumber { get; }
    string accountOwner { get; }
    decimal balanceAmount { get; }
    AccountType accountType { get; }

    void Deposit(decimal amount);
    void Withdrawal(decimal amount);
}
public enum AccountType
{
    Saving = 1,
    Checking = 2
}

