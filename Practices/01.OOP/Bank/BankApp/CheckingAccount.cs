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
        

    }
}