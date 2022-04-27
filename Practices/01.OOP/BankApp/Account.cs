namespace BankApp
{
    using System;

    public class Account
    {
        public int accountNumber {get; set;}
        public bool accountType {get; set;}
        public string placeHolder {get; set;}
        public double balanceAmount{get; set;}
        
        public void MakeDeposit (int deposit)
        {
        balanceAmount = balanceAmount+deposit;

        }

        public void MakeWithdrawal(int Withdrawal)
        {
        if(balanceAmount>=Withdrawal)
        {
            balanceAmount = balanceAmount - Withdrawal;
        }
        else
        {
            Console.WriteLine("insufficient funds");
        }
    }

        
    }

    
}