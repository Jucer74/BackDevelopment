using System;

namespace BankApp
{
    public abstract class BankAccount
    {
        //Atributos & Properties
        public int AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public double BalanceAmount { get; set; }
        

        //Constructor
        public BankAccount()
        {
            
        }

        public BankAccount(int accountNumber, string placeHolder, double balanceAmount)
        {
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
        }

        //Methods
        public abstract void Deposit(double amount);

        public abstract void Withdrawal(double amount);
    }
}
