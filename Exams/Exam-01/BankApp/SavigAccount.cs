public class SavingAccount : IBankAccount
{
    public string acccountNumber => throw new NotImplementedException();

    public string accountOwner => throw new NotImplementedException();

    public decimal balanceAmount => throw new NotImplementedException();

    public AccountType accountType => throw new NotImplementedException();

    public void Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public void Withdrawal(decimal amount)
    {
        throw new NotImplementedException();
    }
}