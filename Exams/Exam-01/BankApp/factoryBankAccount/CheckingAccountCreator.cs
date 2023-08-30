namespace BankApp;

public class CheckingAccountCreator:Creator
{
    private static decimal overdraftAmount = 1_000_000;

    public override BankAccount FactoryAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType)
    {
        return new CheckingAccount(accountNumber, accountOwner, balanceAmount, accountType, overdraftAmount);
    }
}


