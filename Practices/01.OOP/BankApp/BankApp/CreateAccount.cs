//Juan Camilo Mayorca Puerto - 65059
namespace BankApp{
    using System;
    public class CreateAccount{

        public int AccountNumber {get; set;}
        public string PlaceHolder {get; set;}
        public string AccountType {get; set;}
        public double BalanceAmount {get; set;}

       public void Deposit(int balanceDeposit){
            BalanceAmount = BalanceAmount+balanceDeposit;
        }

        public void Withdrawal(int balanceWithdrawal){
            if(BalanceAmount>=balanceWithdrawal){
                BalanceAmount = BalanceAmount-balanceWithdrawal;
            }else{
                Console.WriteLine("insufient balance");
            }
        }

    }

}