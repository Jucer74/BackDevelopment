namespace BankAccount
{
    using System;

    public class AccountDto
    {
        public int AccountNumber { get; set;}

        public string AccountPlaceHolder { get; set;}

        public string AccountType { get; set;}

        public int AccountBalance { get; set;}

        public void Deposit(int balanceDeposit){
            AccountBalance = AccountBalance+balanceDeposit;
        }

        public void Withdrawal(int balanceWithdrawal){
            if(AccountBalance>=balanceWithdrawal){
                AccountBalance = AccountBalance-balanceWithdrawal;
            }else{
                Console.WriteLine("Error. Not Enough Balance in your Account...");
            }
        }
    }

    
}