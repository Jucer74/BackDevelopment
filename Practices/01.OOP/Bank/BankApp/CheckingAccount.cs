using System;

namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        public bool OverdraftAmount { get; set; }

        public CheckingAccount(): base()
        {

        }

        public CheckingAccount(string numberAccount, string placeHolder, double balanceAmount, int accountType) : base(numberAccount, placeHolder, balanceAmount, accountType)
        {
            this.OverdraftAmount = false;
        }
    }
}