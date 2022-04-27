using System;

namespace BankApp
{
    public class BankAccount
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
            this.AccountType = accountNumber;
        }

        public void Deposit(double despositValue)
        {

        }
        public double Balance()
        {
            return 0.0;
        }
        public void WithDrawal(double withdrawalValue)
        {

        }
    }
    
}