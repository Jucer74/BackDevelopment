using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Transactions: ITransactions
    {
        private AccountValidation accountValidation;
        private Overdraft overdraft;
        public Transactios()
        {
        }

        public void Deposit(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number   : ");
            string accountNumber = Console.ReadLine();
            accountValidation = new AccountValidation();
            BankAccount bankAccount = accountValidation.SearchAccount(accountNumber, accountList);
            Console.Write("Enter amount to deposit           : ");
            double amountDeposit = double.Parse(Console.ReadLine());
            double sumDepositAndBalance = bankAccount.BalanceAmount + amountDeposit;
            bankAccount.BalanceAmount = sumDepositAndBalance;
            Console.Write("new saldo of account es: $" + bankAccount.BalanceAmount);
        }

        public void GetBalance(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number    : ");
            string accountNumber = Console.ReadLine();
            accountValidation = new AccountValidation();
            BankAccount bankAccount = accountValidation.SearchAccount(accountNumber, accountList);
            double balanceAmount = bankAccount.BalanceAmount; Console.Write("new saldo of account es: $" + bankAccount.BalanceAmount);
        }

        public void Withdrawal(List<BankAccount> accountList)
        {
            Console.Write("Enter The Account Number : ");
            string accountNumber = Console.ReadLine();
            accountValidation = new AccountValidation();
            BankAccount bankAccount = accountValidation.SearchAccount(accountNumber, accountList);
            double amountWithdrawal = double.Parse(Console.ReadLine());
            overdraft = new Overdraft();
            overdraft.ValidateOverdraftValue(amountWithdrawal);
            double subtractionBalance = bankAccount.BalanceAmount - amountWithdrawal;
            bankAccount.BalanceAmount = subtractionBalance;
             Console.Write("new saldo of account es: $" + bankAccount.BalanceAmount);
        }
    }
}