using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Bank : BankAccount
    {
        public List<BankAccount> listBankAccounts { get; set; }

        public Bank()
        {
            this.listBankAccounts = new List<BankAccount>();
        }

        public void CreateAccount(string numberAccount, string placeHolder, double balanceAmount, int accountType)
        {

            BankAccount AccountToCreate;
            switch (accountType)
            {
                case 1:
                    AccountToCreate = new SavingAccount(numberAccount, placeHolder, balanceAmount, accountType);
                    break;

                case 2:
                    AccountToCreate = new CheckingAccount(numberAccount, placeHolder, balanceAmount, accountType);
                    break;

                default:
                    throw new ArgumentException("ERROR: Account not found");
            }
            this.listBankAccounts.Add(AccountToCreate);
        }

    }
}