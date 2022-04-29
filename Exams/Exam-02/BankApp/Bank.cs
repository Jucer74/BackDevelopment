using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
   public static class Bank
   {
      private static List<BankAccount> accountsList = new List<BankAccount>();

      private static bool ExistsAccount(string accountNumber)
      {
         return accountsList.Exists(a => a.AccountNumber.Equals(accountNumber));
      }

      public static void CreateAccount(BankAccount bankAccount)
      {
         if (!ExistsAccount(bankAccount.AccountNumber))
         {
            accountsList.Add(bankAccount);
            Console.WriteLine("\nAccount Created");
         }
         else
         {
            Console.WriteLine($"Account : {bankAccount.AccountNumber} already exists");
         }
      }

      public static void GetBalanceAccount(string accountNumber)
      {
         if (!ExistsAccount(accountNumber))
         {
            Console.WriteLine($"Account : {accountNumber} doesn't exist");
         }
         else
         {
            var bankAccount = accountsList.FirstOrDefault(ba => ba.AccountNumber.Equals(accountNumber));
            Console.WriteLine("Acount Type = {0}", bankAccount.AccountType == 1 ? "Saving" : "Checking");
            Console.WriteLine($"Placeholder= {bankAccount.PlaceHolder}");
            Console.WriteLine($"Balance Amount= {bankAccount.BalanceAmount}");
            if (bankAccount.AccountType == 2)
            {
               Console.WriteLine($"Overdraft Amount= {(bankAccount as CheckingAccount).OverdraftAmount}");
            }
         }
      }

      public static void DepositAmount(string accountNumber, decimal amountValue)
      {
         if (!ExistsAccount(accountNumber))
         {
            Console.WriteLine($"Account : {accountNumber} doesn't exist");
         }
         else
         {
            var bankAccount = accountsList.FirstOrDefault(ba => ba.AccountNumber.Equals(accountNumber));

            bankAccount.Deposit(amountValue);
            Console.WriteLine("\nDeposit Success");
         }
      }

      public static void WithdrawalAmount(string accountNumber, decimal amountValue)
      {
         if (!ExistsAccount(accountNumber))
         {
            Console.WriteLine($"Account : {accountNumber} doesn't exist");
         }
         else
         {
            var bankAccount = accountsList.FirstOrDefault(ba => ba.AccountNumber.Equals(accountNumber));

            if (bankAccount.BalanceAmount < amountValue)
            {
               Console.WriteLine("\nInsufficient funds");
            }
            else
            {
               bankAccount.Withdrawal(amountValue);
               Console.WriteLine("\nWithdrawal Success");
            }
         }
      }
   }
}