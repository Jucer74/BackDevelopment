namespace BankApp;

public class CheckingAccount : BankAccount
{
    public decimal overdraftAmount { get; set; }

    public CheckingAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType, decimal overdraftAmount)
        : base(accountNumber, accountOwner, balanceAmount, accountType)
    {
        this.overdraftAmount = overdraftAmount;
    }

    public override String getBalance()
    {
        String balanceMessage = "Acount Type = Checking" +
            "\nAccountOwner = " + base.accountOwner +
            "\nBalance Amount = " + (base.balanceAmount+overdraftAmount);

        return balanceMessage;
    }

    public override void Withdrawal(decimal amount)
    {
        if ((base.balanceAmount - amount) < (overdraftAmount*-1))
        {
            Console.WriteLine("\nInsufficient funds");
        }
        else
        {
            base.balanceAmount -= (int) amount;
            Console.WriteLine("\nWithdrawal Success");
            Console.WriteLine("New Balance: " + this.balanceAmount+overdraftAmount);
        }
    }
}

