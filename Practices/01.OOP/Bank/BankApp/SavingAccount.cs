using System;

namespace BankApp
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount(){
            
        }
        public SavingAccount(string numberAccount, string placeHolder, double balanceAmount, int accountType) : base (numberAccount, placeHolder,balanceAmount,accountType)
        {
            
        }

    }
}