using System;

public class CheckingAccount : BankAccount
{
    public bool OverdraftAmount { get; set; }

    public CheckingAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType, bool overdraftAmount) : base(accountNumber, placeHolder, balanceAccount, accountType, overdraftAmount)
    {
        this.OverdraftAmount = overdraftAmount;
    }
}