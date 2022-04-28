using System;

public class CheckingAccount : BankAccount
{
    public bool OverdraftAmount { get; set; }

    public CheckingAccount()
    {

    }

    public CheckingAccount(int accountNumber,
                            string placeHolder,
                            int balanceAccount,
                            int accountType,
                            bool overdraftAmount) :
    base(accountNumber, placeHolder, balanceAccount, accountType)
    {
        this.OverdraftAmount = overdraftAmount;
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
        this.BalanceAccount = BalanceAccount - amountWithDrawal;
        if (this.BalanceAccount <= 0)
        {
            this.BalanceAccount = this.BalanceAccount - 1000;
        }
    }
}