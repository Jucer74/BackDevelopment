using System;
using System.Collections.Generic;

namespace BankApp
{
    public class BankAccount
    {   
      
        public string AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public int BalanceAmount { get; set; }
        public int AccountType { get; set; }
        
        
        
        public BankAccount(){
           
        }

        
        public BankAccount(string accountNumber, string placeHolder, int balanceAmount, int accountType){
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
            this.AccountType = accountType;
        }

        
    }
}