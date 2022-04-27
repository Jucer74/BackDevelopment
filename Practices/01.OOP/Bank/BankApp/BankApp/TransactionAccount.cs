using System;
using System.Collections.Generic;

namespace BankApp
{
    public class TransactionAccount: ITransactionAccount
    {
        private UtilityAccountValidation utilityAccountValidation = new UtilityAccountValidation();
        public TransactionAccount()
        {
        }

        public void Deposit(List<BankAccount> accountList)
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            Console.Write("Enter amount to deposit           : ");
            double amountDeposit = double.Parse(Console.ReadLine());
            double sumDepositAndBalance = bankAccount.BalanceAmount + amountDeposit;
            bankAccount.BalanceAmount = sumDepositAndBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }

        public void GetBalance(List<BankAccount> accountList)
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            double balanceAmount = bankAccount.BalanceAmount;
            Console.WriteLine("The balance amount is = " + "$" + balanceAmount); ;
        }

        public void Withdrawal(List<BankAccount> accountList)
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            Console.Write("Enter amount to withdraw           : ");
            double amountWithdrawal = double.Parse(Console.ReadLine());
            double subtractionBalance = bankAccount.BalanceAmount - amountWithdrawal;
            bankAccount.BalanceAmount = subtractionBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }
    }
}
