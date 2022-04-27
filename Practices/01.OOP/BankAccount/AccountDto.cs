namespace BankAccount
{
    using System;

    public class AccountDto
    {
        public int AccountNumber { get; set;}
        public string AccountPlaceHolder { get; set;}
        public string AccountType { get; set;}
        public int AccountOverdraft { get; set;}
        public int AccountBalance { get; set;}
        public void Deposit(int balanceDeposit){
            AccountBalance = AccountBalance+balanceDeposit;
        }

        public void Withdrawal(int balanceWithdrawal){
            if(AccountType == "Saving Account")
            {
                if(AccountBalance>=balanceWithdrawal)
                {
                    AccountBalance = AccountBalance-balanceWithdrawal;
                }else
                {
                    Console.WriteLine("Error. Not Enough Balance in your Account...");
                }
            }
            else if(AccountType == "Checking Account")
            {
                if(AccountOverdraft<=balanceWithdrawal)
                {   
                    if (AccountBalance>=AccountOverdraft)
                    {
                     Console.WriteLine(AccountBalance);
                     AccountBalance = AccountBalance-balanceWithdrawal;
                    }
                    else if (AccountBalance<AccountOverdraft)
                    {
                     Console.WriteLine("Error. Not Enough Balance in your Account...");
                    }

                }
            }
        }
    }
}