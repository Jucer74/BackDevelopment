using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Bank
    {
        public List<BankAccount> listBankAccounts { get; set; }

        public Bank()
        {
            this.listBankAccounts = new List<BankAccount>();
        }

        public void CreateAccount(int accountNumber,
                                string placeHolder,
                                double balanceAmount,
                                int accountType)
        {
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
                    throw new ArgumentException("ERROR: No existe ese tipo de cuenta.");
                break;
            }
            this.listBankAccounts.Add(newAccount);
            
        }

        public double GetBalance(int accountNumber)
        {
            try
            {
                BankAccount userAccount = GetThisAccount(accountNumber);
                return userAccount.Balance();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }


        public void DepositAccount(int accountNumber, double amount)
        { 
            try
            {
                BankAccount userAccount = GetThisAccount(accountNumber);
                userAccount.Deposit(amount);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public bool WithdrawalAccount(int accountNumber, double amount)
        {
            try
            {
                BankAccount userAccount = GetThisAccount(accountNumber);
                if(userAccount.AccountType == 1 && userAccount.Balance() < amount)//-----
                {
                    return false;
                }
                else
                {
                    userAccount.WithDrawal(amount);
                    return true;
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public BankAccount GetThisAccount(int accountNumber)
        {
            foreach (BankAccount Account in listBankAccounts)
            {
                if(Account.AccountNumber == accountNumber)
                {
                    return Account;
                }
            }
            throw new ArgumentException("ERROR: No se escontró la cuenta.");
            return null;
        }


    }
}