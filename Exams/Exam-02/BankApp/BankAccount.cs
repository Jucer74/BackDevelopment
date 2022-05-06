using System;

namespace BankApp
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public double BalanceAmount { get; set; }
        public int AccountType { get; private set; }
        public BankAccount()
        {
            
        }
        public BankAccount(int accountNumber, string placeHolder, double balanceAmount, int accountType)
        {
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
            this.AccountType = accountType;
        }

        public abstract void Deposit(double despositValue);
        public abstract double Balance();
        public abstract void WithDrawal(double withdrawalValue);
    }
    
}