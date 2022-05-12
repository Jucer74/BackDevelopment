using System;

namespace BankApp
{
    public class SavingAccount: BankAccount
    {
        //Properties
        
        //Constructor
        public SavingAccount(): base()
        {
        
        }

        public SavingAccount(int accountNumber, string placeHolder, double balanceAmount):
            base(accountNumber, placeHolder, balanceAmount)
        {

        }   

        //Methods
        public override void Deposit(double amount)
        {
            this.BalanceAmount = BalanceAmount + amount;
        }

        public override void Withdrawal(double amount)
        {
            this.BalanceAmount = BalanceAmount - amount;
        }
    }
}