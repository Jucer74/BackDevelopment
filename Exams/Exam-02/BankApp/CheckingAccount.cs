using System;
namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        public double OverdraftAmount { get; set; }

        public CheckingAccount(): base()
        {

        }

        public CheckingAccount(int numberAccount, string placeHolder, double balanceAmount, int accountType) : base(numberAccount, placeHolder, balanceAmount, accountType)
        {
            this.OverdraftAmount = 0;
        }
    }
}