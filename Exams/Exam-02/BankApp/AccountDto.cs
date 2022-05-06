//->NSZ<-\\
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

        public void Withdrawal(int balanceWithdrawal){
            if(Balanceaccount>=balanceWithdrawal){
                Balanceaccount = Balanceaccount-balanceWithdrawal;
            }else{
                Console.WriteLine("Balance Insuficiente");
            }
        }
    }

    
}
//->NSZ<-\\