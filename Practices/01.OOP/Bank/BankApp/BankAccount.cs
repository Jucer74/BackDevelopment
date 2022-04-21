public class BankAccount
{
    public int AccountNumber { get; set; }
    public string PlaceHolder { get; set; }

    public double BalanceAmount { get; set; }

    public enum AccountType
  {
    SavingAccount='2',
    CheckingAccount='2'
  }

    public BankAccount(int accountNumber, string placeHolder, double balanceAmount, int accountType)
    {
        this.AccountNumber = accountNumber;
        this.PlaceHolder = placeHolder;
        this.BalanceAmount = balanceAmount;
        this.AccountType = accountType;
    }
    public BankAccount()
    {
    }

    //methods

    public void deposit(double value)
    {
        BalanceAmount = BalanceAmount+value;
    }
    public void Withdrawal(double value)
    {
        BalanceAmount = BalanceAmount-value;
    }
    public double checkBalance()
    {
        return BalanceAmount;
    }

}