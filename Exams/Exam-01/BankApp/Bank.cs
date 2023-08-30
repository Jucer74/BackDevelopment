using System;
using System.Collections.Generic;

public class Bank
{
    private List<IBankAccount> AccountList = new List<IBankAccount>();

    public void CreateAccount(IBankAccount account)
    {
        if (ExistsAccount(account.AccountNumber))
        {
            throw new InvalidOperationException($"Account {account.AccountNumber} already exists");
        }

        AccountList.Add(account);
        Console.WriteLine("Account Created");
    }

    public void GetBalance(string accountNumber)
    {
        IBankAccount account = GetAccountByNumber(accountNumber);
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Account Type: {account.AccountType}");
        Console.WriteLine($"Account Owner: {account.AccountOwner}");
        Console.WriteLine($"Balance Amount: {account.BalanceAmount}");
    }

    public void DepositAccount(string accountNumber, decimal amount)
    {
        IBankAccount account = GetAccountByNumber(accountNumber);
        account.Deposit(amount);
        Console.WriteLine("Deposit Success");
    }

    public void WithdrawalAccount(string accountNumber, decimal amount)
    {
        IBankAccount account = GetAccountByNumber(accountNumber);
        account.Withdrawal(amount);
        Console.WriteLine("Withdrawal Success");
    }

    public bool ExistsAccount(string accountNumber)
    {
        return AccountList.Exists(acc => acc.AccountNumber == accountNumber);
    }

    private IBankAccount GetAccountByNumber(string accountNumber)
    {
        IBankAccount account = AccountList.Find(acc => acc.AccountNumber == accountNumber);
        if (account == null)
        {
            throw new InvalidOperationException($"Account {accountNumber} doesn't exist");
        }
        return account;
    }
}
