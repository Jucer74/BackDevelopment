public class SavingAccount : IBankAccount
{
    public string AccountNumber { get; set; }
    public string AccountOwner { get; set; }
    public decimal BalanceAmount { get; set; }
    public AccountType AccountType { get; set; } = AccountType.Saving;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        BalanceAmount += amount;
    }

    public void Withdrawal(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (amount > BalanceAmount)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        BalanceAmount -= amount;
    }
}
