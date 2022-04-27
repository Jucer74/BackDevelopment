using System;


namespace BankApp
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount(){
            
        }
        
        public SavingAccount(string accountNumber, string placeHolder, int balanceAmount, int accountType) : base       (accountNumber,placeHolder,balanceAmount,accountType)
        {
            
        }

        /* public void Deposit(decimal despositValue)
        {
            this.BalanceAmount = this.BalanceAmount + despositValue;
        }

        public decimal Balance()
        {
            return this.BalanceAmount;
        }

        public void WithDrawal(decimal withdrawalValue)
        {
            this.BalanceAmount = this.BalanceAmount - withdrawalValue;
        } */

    }
}