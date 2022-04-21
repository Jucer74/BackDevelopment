using System;

public class BankAccount
{
    public int AccountNumber { get; set; }
    public string PlaceHolder { get; set; }
    public int BalanceAccount { get; set; }
    public string AccountType { get; set; }

    public BankAccount(){
        this.AccountNumber = accountNumber;
        this.PlaceHolder = placeHolder;
        this.BalanceAccount = balanceAccount;
        this.AccountType = accountType;
    }
    public BankAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType){
        this.AccountNumber = accountNumber;
        this.PlaceHolder = placeHolder;
        this.BalanceAccount = balanceAccount;
        this.AccountType = accountType;
    }
}