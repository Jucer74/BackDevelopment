using System;
namespace BankApp
{
public class CheckingAccount : BankAccount
{
    private double  OverdraftAmount { get; set; }

    public CheckingAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType, bool overdraftAmount) : base(accountNumber, placeHolder, balanceAccount, accountType, overdraftAmount)
    {
        this.OverdraftAmount = overdraftAmount;
    }
}
}