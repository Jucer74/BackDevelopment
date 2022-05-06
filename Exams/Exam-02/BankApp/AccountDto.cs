namespace BankApp
{
    using System;

    public class AccountDto
    {
        public int AccountNumber { get; set;}

        public string PlaceHolder { get; set;}

        public string AccounType { get; set;}

        public int BalanceAccount { get; set;}

        public void Deposit(int balanceDeposit){
            BalanceAccount = BalanceAccount+balanceDeposit;
        }

        public void Withdrawal(int balanceWithdrawal, string accountType){
            
            if(accountType == "Saving Account")
            {
                if(BalanceAccount>=balanceWithdrawal){
                    BalanceAccount = BalanceAccount-balanceWithdrawal;
                }else{
                    Console.WriteLine("Insufficient balance");
                }
            }else{
                   
                if(BalanceAccount<=-1000001){
                    Console.WriteLine("Can't withdraw more, full overdraft");
                }else{
                    BalanceAccount = BalanceAccount-balanceWithdrawal;
                }
            }
                
        }
    }

    
}