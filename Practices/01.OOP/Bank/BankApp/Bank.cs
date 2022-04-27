using System;
using System.Collections.Generic;

namespace BankApp

{
     public class Bank : BankAccount
    {
    

         public List<BankAccount> listBankAccount { get; set; }

         public Bank()
        {
            this.listBankAccount = new List<BankAccount>();
        }

         public void CreateAccount(string accountNumber, string placeHolder, int balanceAmount, int accountType) {

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

       /*  public static void GetBalanceAccount(string accountNumber) {

            BankAccount userAccount = GetThisAccount(accountNumber);
            return userAccount.Balance();
        } */
/* 
         public void DepositAccount(int accountNumber, decimal amount) { 

            BankAccount userAccount = GetThisAccount(accountNumber);
            userAccount.Deposit(amount);
        }


        public bool WithdrawalAccount(int accountNumber, decimal amount)  {

             BankAccount userAccount = GetThisAccount(accountNumber);
              if(userAccount.AccountNumber == 1 && userAccount.Balance() >= amount)
                {
                    userAccount.WithDrawal(amount);
                    return true;
                }
                else
                {
                    return false;
                }
        } */



       /*  private static void GetBalance()
        {
            Console.Clear();
            Console.WriteLine("Balance Account");
            Console.WriteLine("---------------");

            Console.WriteLine("Enter the account number");
            int accountNumber = int.Parse(Console.ReadLine());
            List<newAccount> list = new List<newAccount>();
            
            int numberAccount = list.IndexOf(accountNumber);
            Console.WriteLine(numberAccount);
            
        } */
       
      /*  private static void DepositAccount()
        {
            Console.Clear();
            Console.WriteLine("Deposit");
            Console.WriteLine("---------------");

            Console.WriteLine("Enter the account number");
            int accountNumber = Console.ReadLine();

            Console.WriteLine("Enter the balance to deposit");
            int balanceAmount = Console.ReadLine();
           
        } */




    }
}