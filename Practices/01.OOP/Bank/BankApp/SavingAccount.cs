using System;

namespace BankApp
{
    public class SavingAccount: BankAccount
    {
        //Properties
        
        //Constructor
        public SavingAccount(): base()
        {
        
        }

        public SavingAccount(int accountNumber, string placeHolder, double balanceAmount):
            base(accountNumber, placeHolder, balanceAmount)
        {

        }   

        //Methods
    }
}