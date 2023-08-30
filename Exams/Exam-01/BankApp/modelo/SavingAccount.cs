namespace BankApp;

public class SavingAccount : BankAccount
{
    public SavingAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType)
        : base(accountNumber, accountOwner, balanceAmount, accountType)
    {
           
    }

    public override String getBalance()
    {
        String balanceMessage = "Acount Type = Saving" +
            "\nAccountOwner = " + base.accountOwner +
            "\nBalance Amount = " + base.balanceAmount;

        return balanceMessage;
    }
}


