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
           /*  if(checkOverdrafAmount()) 
            {
                OverdrafAmount = true;
            } */
        } 

         public override void Withdrawal(double secondValue)
        {
            this.BalanceAmount = this.BalanceAmount - secondValue;
           /*  if(checkOverdrafAmount()) 
            {
                OverdrafAmount = true;
            } */
        } 

        public bool checkOverdrafAmount()
        {
            return this.BalanceAmount <= 0;
        } 
    }
}