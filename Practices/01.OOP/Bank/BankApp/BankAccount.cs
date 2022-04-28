using System;

public abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public string PlaceHolder { get; set; }
    public double BalanceAccount { get; set; }
    public int AccountType { get; set; }

    public BankAccount()
    {

    }

    public BankAccount(int accountNumber, string placeHolder, double balanceAccount, int accountType){
        this.AccountNumber = accountNumber;
        this.PlaceHolder = placeHolder;
        this.BalanceAccount = balanceAccount;
        this.AccountType = accountType;
    }

    public abstract double Balance();
    public abstract void Deposit(double amountAccount);
    public abstract void Withdrawal(double amountWithDrawal);
}