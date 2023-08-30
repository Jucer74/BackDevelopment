
namespace BankApp;

public abstract class Creator
{
    public abstract BankAccount FactoryAccount(String accountNumber, String accountOwner, decimal balanceAmount, int accountType);
}
