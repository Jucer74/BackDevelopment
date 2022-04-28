using System;
using System.Collections.Generic;

namespace BankApp

{
     public class Bank
    {
    

         public List<BankAccount> listBankAccount { get; set; }

         public Bank()
        {
            this.listBankAccount = new List<BankAccount>();
        }

         public void CreateAccount(string accountNumber, string placeHolder, double balanceAmount, int accountType) {

            BankAccount newAccount;
            switch (accountType)
            {
                case 1:
                newAccount = new SavingAccount( accountNumber, placeHolder, balanceAmount, accountType);
                break;

                case 2:
                newAccount = new CheckingAccount( accountNumber, placeHolder, balanceAmount, accountType);
                break;

                default:
                throw new ArgumentException("ERROR Cuenta no encontrada");
                break;
            }
            this.listBankAccount.Add(newAccount);
        } 

         public double GetBalanceAccount(string accountNumber) {
            
            BankAccount userAccount = GetAccount(accountNumber);
            return userAccount.Balance(); 
      
        } 

        public BankAccount GetAccount(string accountNumber)
        {

            foreach (BankAccount Account in listBankAccount)
            {
                if(Account.AccountNumber == accountNumber)
                {
                    return Account;
                } 
            } 
            return null;
        } 

        public void Deposit(string accountNumber, double amount)
        {
            
            BankAccount userAccount = GetAccount(accountNumber);
            userAccount.Deposit(amount); 
        }

        

        public void Withdrawal(string accountNumber, double amount)
        {
            
            BankAccount userAccount = GetAccount(accountNumber);
            userAccount.Deposit(amount); 
        }

    }
}