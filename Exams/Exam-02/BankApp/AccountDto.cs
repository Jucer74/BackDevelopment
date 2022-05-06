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

            if(Accountype=="Checking"){
               if(Balanceaccount>=-1000000 && balanceWithdrawal<=1000000 && (Balanceaccount-balanceWithdrawal>=-1000000)){
                    Balanceaccount = Balanceaccount-balanceWithdrawal;
                }
                else{
                    Console.WriteLine("Insufficient balance");
                }
            }

            if(Accountype=="Saving"){
               if(Balanceaccount>=balanceWithdrawal){
                    Balanceaccount = Balanceaccount-balanceWithdrawal;
                }
                else{
                    Console.WriteLine("Insufficient balance");
                } 
            }
            
        }
    }

    
}