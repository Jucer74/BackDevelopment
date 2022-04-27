using System;

namespace BankApp
{
    public class CheckingAccount: BankAccount
    {
        //Properties

        //Constructor
        public CheckingAccount(): base()
        {
            
        }

        public CheckingAccount(int accountNumber, string placeHolder, double balanceAmount):
            base(accountNumber, placeHolder, balanceAmount)
        {

        }

        //Methods
    }
}

