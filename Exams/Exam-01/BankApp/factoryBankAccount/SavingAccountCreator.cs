
namespace BankApp;

public class SavingAccountCreator : Creator
{
    public override BankAccount FactoryAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType)
    {
        return new SavingAccount(accountNumber,accountOwner,balanceAmount,accountType);
    }
}


