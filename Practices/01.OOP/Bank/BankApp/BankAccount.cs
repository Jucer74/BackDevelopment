using System;


namespace BankApp
{
    public abstract class BankAccount
    {   
      
        public string AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public double BalanceAmount { get; set; }
        public int AccountType { get; set; }
        
        
        
        public BankAccount(){
           
        }

        
        public BankAccount(string accountNumber, string placeHolder, double balanceAmount, int accountType){
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
            this.AccountType = accountType;
        }

        public abstract double Balance();   

        public abstract void Deposit(double value);

        public abstract void Withdrawal(double secondValue);
        
    }
}