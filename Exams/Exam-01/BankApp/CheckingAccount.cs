public class CheckingAccount : IBankAccount
{
    public string acccountNumber {get;set;}

    public string accountOwner {get;set;}

    public decimal balanceAmount {get;set;}

    public AccountType accountType {get;set;}

    public decimal overdraftAmount {get;set;}

    public CheckingAccount(AccountType accountType, string acccountNumber, string accountOwner, decimal balanceAmount)
    {
        this.accountType = accountType;
        this.accountOwner = accountOwner;
        this.balanceAmount = balanceAmount;
        this.acccountNumber = acccountNumber;
        overdraftAmount = 0;

    }
    public void Deposit(decimal amount)
    {
        balanceAmount += amount;
    }

    public void Withdrawal(decimal amount)
    {
        if (balanceAmount >= amount)
        {
            balanceAmount -= amount;
        }
        else
        {
            overdraftAmount = Math.Abs(balanceAmount);
        }
    }
}