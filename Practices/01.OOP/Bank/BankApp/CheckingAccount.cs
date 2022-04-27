using System;

namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        public bool OverdraftAmount { get; set; }

        public CheckingAccount(){

        }

        public CheckingAccount(string accountNumber, string placeHolder, int balanceAmount, int accountType) : base(accountNumber, placeHolder, balanceAmount, accountType)
        {
            this.OverdraftAmount = false;
        }


        /* public void Deposit(decimal despositValue)
        {
         this.BalanceAmount = this.BalanceAmount + despositValue;
            if(isOverdrafAmount()) {
             OverdrafAmount = true;
            }
        } */


    }
}