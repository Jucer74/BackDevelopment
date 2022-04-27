using System;


namespace BankApp
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string PlaceHolder { get; set; }
        public int BalanceAmount { get; set; }
        public string AccountType { get; set; }

        public BankAccount(){
           
        }
        public BankAccount(int accountNumber, string placeHolder, int balanceAmount, string accountType){
            this.AccountNumber = accountNumber;
            this.PlaceHolder = placeHolder;
            this.BalanceAmount = balanceAmount;
            this.AccountType = accountType;
        }
    }
}