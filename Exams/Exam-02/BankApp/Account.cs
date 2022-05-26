namespace Bank
{

    using System;
    using System.Globalization;

    public class Account
  {
    public virtual void ShowDetails(AccountDto account)
    {
        Console.WriteLine($"Placeholder      : {account.PlaceHolder}");
        Console.WriteLine($"Account number   : {account.AccountNumber}");
        Console.WriteLine($"TypeAccount      : {account.AccountType}");
        Console.WriteLine($"Balance amount   : {account.BalanceAmount}");
        Console.WriteLine($"overdraftamounnt : {account.OverdraftAmount}");
    }

 

  }

}  