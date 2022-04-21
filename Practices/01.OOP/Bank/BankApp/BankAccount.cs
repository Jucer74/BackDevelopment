using System;

namespace BankApp
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public decimal BalanceAmount { get; set; }
        public int AccountType { get; private set; }
        public BankAccount()
        {
            
        }
        public BankAccount(int accountNumber, string placeHolder, decimal balanceAmount, int accountType)
        {
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
            this.AccountType = accountNumber;
        }

        public void Deposit(decimal despositValue);
        public void Balance();
        public void WithDrawal(decimal withdrawalValue);
    }
    
}