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
        public override void Deposit(double amount)
        {
            this.BalanceAmount = BalanceAmount + amount;
        }

        public override void Withdrawal(double amount)
        {
            this.BalanceAmount = this.BalanceAmount - amount;
            if(this.BalanceAmount <= 0){
                this.BalanceAmount = this.BalanceAmount - 500;
            }
        }
    }
}

