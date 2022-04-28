using System;


namespace BankApp
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount() : base() {
            
        }
        
        public SavingAccount(string accountNumber, string placeHolder, double balanceAmount, int accountType) : base (accountNumber,placeHolder,balanceAmount,accountType)
        {
            
        }
        
        public override double Balance()
        {
            return this.BalanceAmount;
        } 


    }
}