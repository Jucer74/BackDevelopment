using System;
using System.Collections.Generic;

namespace BankApp
{
    public class UtilityAccountValidation: IUtilityAccountValidation
    {
        private FillAccount fillAccount = new FillAccount();
        public UtilityAccountValidation()
        {
        }

        public BankAccount SelectAccountType(List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            Console.Write("Account Type  = 1) Saving , 2) Checking   : ");
            int accountType = int.Parse(Console.ReadLine());
            if (accountType == 1)
            {
                bankAccount = CreateSavingAccount(accountList, bankAccount, accountType);

            }
            else if (accountType == 2)
            {
                bankAccount = CreateChekingAccount(accountList, bankAccount, accountType);
            }
            return bankAccount;
        }

        public bool ValidateAccountIsNull(List<BankAccount> accountList, string accountNumber,
            BankAccount bankAccount)
        {
            try
            {
                    bankAccount = SearchAccount(accountNumber, accountList);
                    if (bankAccount != null)
                    {
                        throw new Exception("****The Account Number Already Exists****");
                    }
             
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public BankAccount SearchAccount(string accountNumber, List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            if (accountList != null)
            {
                for (int i = 0; i < accountList.Count; i++)
                {
                    if (accountList[i].AccountNumber.Contains(accountNumber))
                    {
                        bankAccount = accountList[i];
                    }
                }
            }
           
            return bankAccount;
        }

        public BankAccount CreateSavingAccount(List<BankAccount> accountList,
            BankAccount bankAccount, int accountType)
        {
            bool validateAccountNumberNotExist = false;
            Console.WriteLine("\nCreation of selected saving account\n");
            Console.Write("Enter The Account Number              : ");
            var accountNumber = Console.ReadLine();
            validateAccountNumberNotExist = ValidateAccountIsNull(accountList, accountNumber,
               bankAccount);
            if (validateAccountNumberNotExist == true)
            {
                Console.Write("Place holder             : ");
                var placeHolder = Console.ReadLine();
                Console.Write("Balance amount : ");
                double balanceAmount = double.Parse(Console.ReadLine());
                bankAccount = fillAccount.FillSavingAccountData(accountNumber, placeHolder, balanceAmount, accountType);
            }
            return bankAccount;
        }

        public BankAccount CreateChekingAccount(List<BankAccount> accountList,
           BankAccount bankAccount, int accountType)
        {
            Console.WriteLine("\nCreation of selected checking account\n");
            Console.Write("Enter The Account Number              : ");
            var accountNumber = Console.ReadLine();
           bool validateAccountNumberNotExist = ValidateAccountIsNull(accountList, accountNumber,
                   bankAccount);
            if (validateAccountNumberNotExist == true)
            {

                Console.Write("Enter The Place holder             : ");
                var placeHolder = Console.ReadLine();
                Console.Write("Enter The Balance amount : ");
                double balanceAmount = double.Parse(Console.ReadLine());
                Console.Write("Enter The Overdraft amount : ");
                double overdraftAmountValue = double.Parse(Console.ReadLine());
                balanceAmount = overdraftAmountValue + balanceAmount;
                bankAccount = fillAccount.FillChekingAccountData(accountNumber, placeHolder, balanceAmount,
                    accountType, overdraftAmountValue);
            }
            return bankAccount;
        }
    }
}
