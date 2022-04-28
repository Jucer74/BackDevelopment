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


        public override void Deposit(double value)
        {
            this.BalanceAmount = this.BalanceAmount + value;
        }

        public override void Withdrawal(double secondValue)
        {
            this.BalanceAmount = this.BalanceAmount - secondValue;
        }

        

      

    }
}