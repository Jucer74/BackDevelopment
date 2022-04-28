using System;
using System.Collections.Generic;

namespace BankApp
{
    public class TransactionAccount: ITransactionAccount
    {
        private UtilityAccountValidation utilityAccountValidation;
        private Overdraft overdraft;
        public TransactionAccount()
        {
        }

        public void Deposit(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number            : ");
            string accountNumber = Console.ReadLine();
            utilityAccountValidation = new UtilityAccountValidation();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            Console.Write("Enter amount to deposit           : ");
            double amountDeposit = double.Parse(Console.ReadLine());
            double sumDepositAndBalance = bankAccount.BalanceAmount + amountDeposit;
            bankAccount.BalanceAmount = sumDepositAndBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }

        public void GetBalance(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number             : ");
            string accountNumber = Console.ReadLine();
            utilityAccountValidation = new UtilityAccountValidation();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            double balanceAmount = bankAccount.BalanceAmount;
            Console.WriteLine("The balance amount is = " + "$" + balanceAmount); ;
        }

        public void Withdrawal(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number           : ");
            string accountNumber = Console.ReadLine();
            utilityAccountValidation = new UtilityAccountValidation();
            BankAccount bankAccount = utilityAccountValidation.SearchAccount(accountNumber, accountList);
            Console.Write("Enter amount to withdraw           : ");
            double amountWithdrawal = double.Parse(Console.ReadLine());
            overdraft = new Overdraft();
            overdraft.ValidateOverdraftValue(amountWithdrawal);
            double subtractionBalance = bankAccount.BalanceAmount - amountWithdrawal;
            bankAccount.BalanceAmount = subtractionBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }
    }
}
