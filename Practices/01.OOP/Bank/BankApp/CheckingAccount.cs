using System;

namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        public bool OverdraftAmount { get; set; }

        public CheckingAccount(): base(){

        }

        public CheckingAccount(string accountNumber, string placeHolder, double balanceAmount, int accountType) : base(accountNumber, placeHolder, balanceAmount, accountType)
        {
            this.OverdraftAmount = false;
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

        public bool checkOverdrafAmount()
        {
            return this.BalanceAmount <= 0;
        } 
        
    }
}