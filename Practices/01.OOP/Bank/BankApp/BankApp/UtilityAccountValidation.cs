using System;
using System.Collections.Generic;

namespace BankApp
{
    public class UtilityAccountValidation: IUtilityAccountValidation
    {
        private CreateAccount createAccount = new CreateAccount();
        public UtilityAccountValidation()
        {
        }

        public BankAccount SelectAccountType(List<BankAccount> accountList)
        {
            bool validateAccountNumberNotExist = false;
            BankAccount bankAccount = null;
                Console.Write("Account Type                  : ");
                int accountType = int.Parse(Console.ReadLine());
                if (accountType == 1)
                {
                    Console.Write("Account Number             : ");
                    var accountNumber = Console.ReadLine();
                     validateAccountNumberNotExist = validateAccountIsNull(accountList, accountNumber,
                        bankAccount);
                    if(validateAccountNumberNotExist == true)
                {
                    Console.Write("Place holder             : ");
                    var placeHolder = Console.ReadLine();
                    Console.Write("Balance amount : ");
                    double balanceAmount = double.Parse(Console.ReadLine());
                    bankAccount = createAccount.FillSavingAccountData(accountNumber, placeHolder, balanceAmount, accountType);
                }

            }
                else if (accountType == 2)
                {
                Console.Write("Account Number             : ");
                var accountNumber = Console.ReadLine();
                validateAccountNumberNotExist = validateAccountIsNull(accountList, accountNumber,
                       bankAccount);
                if (validateAccountNumberNotExist == true)
                {
                  
                    Console.Write("Place holder             : ");
                    var placeHolder = Console.ReadLine();
                    Console.Write("Balance amount : ");
                    double balanceAmount = double.Parse(Console.ReadLine());
                    Console.Write("Overdraft amount : ");
                    double overdraftAmount = double.Parse(Console.ReadLine());
                    balanceAmount = overdraftAmount + balanceAmount;
                    bankAccount = createAccount.FillChekingAccountData(accountNumber, placeHolder, balanceAmount,
                        accountType, overdraftAmount);
                }     
                }
            return bankAccount;
        }

        private bool validateAccountIsNull(List<BankAccount> accountList, string accountNumber,
            BankAccount bankAccount)
        {
            try
            {
                if (accountList != null)
                {
                    bankAccount = SearchAccount(accountNumber, accountList);
                    if (bankAccount != null)
                    {
                        throw new Exception("****The Account Number Already Exists****");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public BankAccount SearchAccount(string textAccount, List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].AccountNumber.Contains(textAccount))
                {
                    bankAccount = accountList[i];
                }
            }
            return bankAccount;
        }
    }
}
