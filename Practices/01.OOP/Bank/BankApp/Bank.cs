using System;

namespace BankApp
{
    public class Bank
    {
        public List<BankAccount> listBankAccounts { get; set; }

        public Bank()
        {
            
        }

        public void CreateAccount(int accountNumber,
                                string placeHolder,
                                decimal balanceAmount,
                                int accountType, 
                                bool overdrafAmount)
        {
            BankAccount newAccount;
            switch (accountType)
            {
                case 1:
                    newAccount = new SavingAccount( accountNumber, placeHolder, balanceAmount, accountType, overdrafAmount);
                break;

                case 2:
                    newAccount = new CheckingAccount( accountNumber, placeHolder, balanceAmount, accountType, overdrafAmount);
                break;

                default:
            }
        }

    }
}