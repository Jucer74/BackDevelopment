namespace BankApp;

public abstract class BankAccount
{
    public BankAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType)
    {
        this.accountNumber = accountNumber;
        this.accountOwner = accountOwner;
        this.balanceAmount = balanceAmount;
        this.accountType = accountType;
    }

    public string accountNumber { get; set; }
    public string accountOwner { get; set; }
    public decimal balanceAmount { get; set; }
    public int accountType { get; set; }

    public virtual void Deposit(decimal amount)
    {
        this.balanceAmount += (int) amount;
        Console.WriteLine("\nDeposit Success");
        Console.WriteLine("New Balance: " + this.balanceAmount);
    }

    public virtual void Withdrawal(decimal amount)
    {
        if ((balanceAmount - amount) < 0)
        {
            Console.WriteLine("\nInsufficient funds");
        }
        else
        {
            balanceAmount -= (int)amount;
            Console.WriteLine("\nWithdrawal Success");
            Console.WriteLine("New Balance: " + this.balanceAmount);
        }
    }

    public abstract String getBalance();

}


