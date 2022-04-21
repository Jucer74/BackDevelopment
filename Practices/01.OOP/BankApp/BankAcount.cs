using System;
using System.Collections.Generic;

namespace Classes
{

public class BankAcount
{
    public double AcountNumber{get;set;}
    public string PlaceHolder{get;set;}
    public double BalanceAmount{get;set;}
    public int AccountType{get;set;}
    string[] Type = new string[]{"SavingAccount","CheckingAccount"};

    public double Overdraft = 0;
    /* public float Balance = 0; */
    list<string> Accounts = new list<string>();

    //Constructor

    public BankAcount(double accountNumber, string placeHolder, double balanceAmount,int accoutType, double overDraft)
    {
      AcountNumber = accountNumber;
      Accounts.Add(AcountNumber);
      
      PlaceHolder = placeHolder;

      BalanceAmount = balanceAmount;

      AccountType = accoutType;

      Overdraft = overDraft;  
      
    }

    public void Withdrawal( double accountNumber, float amount)
    {
        if (amount <=0)
        {
            
        }
    }

    public Balance()
    {
        
    }
}
}