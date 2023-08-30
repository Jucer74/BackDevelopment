public static class Bank
{
    private static readonly List<IBankAccount> accounts = new List<IBankAccount>();

    public static bool CreateAccount(IBankAccount bankAccount)
    {
        if (bankAccount == null) throw new ArgumentNullException(nameof(bankAccount));

        if (AccountExists(bankAccount.AccountNumber))
        {
            return false; // La cuenta ya existe.
        }

        accounts.Add(bankAccount);
        return true; // Cuenta creada exitosamente.
    }

    public static decimal? GetBalance(string accountNumber)
    {
        var account = FindAccount(accountNumber);
        if (account != null)
        {
            return account.BalanceAmount;
        }
        return null; // Cuenta no encontrada.
    }

    public static bool Deposit(string accountNumber, decimal amount)
    {
        var account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Deposit(amount);
            return true; // Depósito realizado.
        }
        return false; // Cuenta no encontrada.
    }

    public static bool Withdraw(string accountNumber, decimal amount)
    {
        var account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Withdrawal(amount);
            return true; // Retiro realizado.
        }
        return false; // Cuenta no encontrada.
    }

    public static IBankAccount FindAccount(string accountNumber)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }

    public static bool AccountExists(string accountNumber)
    {
        return FindAccount(accountNumber) != null;
    }
}
