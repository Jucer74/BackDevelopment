namespace BankApp
{
    using System;

    public class AccountDto
    {
        public int Accountnumber { get; set;}

        public string Placeholder { get; set;}

        public string Accountype { get; set;}

        public int Balanceaccount { get; set;}

        public void Deposit(int balanceDeposit){
            Balanceaccount = Balanceaccount+balanceDeposit;
        }

        public void Withdrawal(int balanceWithdrawal, string accountType){
            
            if(accountType == "Saving Account")
            {
                if(Balanceaccount>=balanceWithdrawal){
                    Balanceaccount = Balanceaccount-balanceWithdrawal;
                }else{
                    Console.WriteLine("Insufficient balance");
                }
            }else{
                   
                if(Balanceaccount<=-1000001){
                    Console.WriteLine("Can't withdraw more, full overdraft");
                }else{
                    Balanceaccount = Balanceaccount-balanceWithdrawal;
                }
            }
                
        }
    }

    
}