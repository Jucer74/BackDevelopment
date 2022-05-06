using System;
using System.Collections.Generic;

public class SavingAccount : BankAccount
{
    public SavingAccount()
    {
        
    }

    public SavingAccount(int accountNumber, 
                        string placeHolder, 
                        int balanceAccount, 
                        int accountType):
    base(accountNumber, placeHolder, balanceAccount, accountType)
    {

    }

    public override double Balance()
    {
        return this.BalanceAccount;
    }

    public override void Deposit(double amountAccount)
    {
        this.BalanceAccount = BalanceAccount + amountAccount;
    }

    public override void Withdrawal(double amountWithDrawal)
    {
        this.BalanceAccount = this.BalanceAccount - amountWithDrawal;
    }
}