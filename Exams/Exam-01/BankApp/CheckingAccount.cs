public class CheckingAccount : IBankAccount
{
    public const decimal MIN_OVERDRAFT_AMOUNT = 1000000;

   public CheckingAccount()
    {
        AccountNumber = "";
        AccountOwner = "";
        OverdraftAmount = MIN_OVERDRAFT_AMOUNT;
    }


    public string AccountNumber { get; set; }
    public string AccountOwner { get; set; }
    public decimal BalanceAmount { get; set; }
    public AccountType AccountType { get; set; } = AccountType.Checking;
    public decimal OverdraftAmount { get; set; } = MIN_OVERDRAFT_AMOUNT;

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

        decimal availableFunds = BalanceAmount + OverdraftAmount;
        if (amount > availableFunds)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        BalanceAmount -= amount;
    }
}
