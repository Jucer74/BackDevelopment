public class CheckingAccount : IBankAccount
{
    public string acccountNumber {get;set;}

    public string accountOwner {get;set;}

    public decimal balanceAmount {get;set;} = 0;

    public AccountType accountType {get;set;}

    public decimal overdraftAmount {get;set;} = 0;

    public CheckingAccount(AccountType accountType, string acccountNumber, string accountOwner, decimal balanceAmount, decimal overdraftAmount)

    {
        this.accountType = accountType;
        this.accountOwner = accountOwner;
        this.balanceAmount = balanceAmount;
        this.acccountNumber = acccountNumber;
        this.overdraftAmount = overdraftAmount;

    }
    public void Deposit(decimal amount)
    {
        balanceAmount = balanceAmount + amount;
    }

    public void Withdrawal(decimal amount)
    {
        decimal totalAmount = balanceAmount + overdraftAmount;
        if (balanceAmount >= amount)
        {
            totalAmount = totalAmount - amount;
        }
        else
        {
            overdraftAmount = Math.Abs(balanceAmount);
        }
    }
}