using System.Linq;
using System;

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
                                decimal balanceAmount,
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

        public decimal GetBalance(int accountType)
        {
            try
            {
                BankAccount Account = GetThisAccount(accountType);
                return Account.BalanceAmount;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }


        public void DepositAccount(int accountType, decimal amount)
        { 
            try
            {
                BankAccount Account = GetThisAccount(accountType);
                Account.BalanceAmount;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public void WithdrawalAccount()
        {

        }

        public BankAccount GetThisAccount(int accountType)
        {
            foreach (BankAccount Account in listBankAccounts)
            {
                if(Account.AccountType == accountType)
                {
                    return Account;
                }
            }
            throw new ArgumentException("ERROR: No se escontró la cuenta.");
            return null;
        }


    }
}