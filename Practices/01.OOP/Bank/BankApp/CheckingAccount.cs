using System;

namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        public bool OverdraftAmount { get; set; }

        public CheckingAccount(int accountNumber, string placeHolder, int balanceAmount, string accountType) /* : base(accountNumber, placeHolder, balanceAmount, accountType, overdraftAmount) */
        {
           /*  this.OverdraftAmount = overdrafAmount; */
        }
    }
}