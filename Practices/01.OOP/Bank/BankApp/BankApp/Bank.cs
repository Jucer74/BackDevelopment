using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Bank
    {
        private static List<BankAccount> accountList;
        
        private static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void InsertAccount()
        {
            Console.Clear();
            Console.WriteLine("Insert new Account");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            var account = SelectAccountType();
            accountList = new List<BankAccount>();
            accountList.Add(account);

            if (accountList != null)
            {
                Console.WriteLine("\nAccount Created successfully\n");
            }
            else
            {
                Console.WriteLine("\nError created account\n");
            }
        }


        public static CheckingAccount CreateCheckingAccount(string accountNumber, string placeHolder,
       double balanceAmount, int accountType, double overdraftAmount)
        {
            var checkingAccount = new CheckingAccount
            {
                AccountNumber = accountNumber,
                PlaceHolder = placeHolder,
                BalanceAmount = balanceAmount,
                AccountType = accountType,
                OverDraftAmount = overdraftAmount
            };

            return checkingAccount;
        }


        private static SavingAccount CreateSavingAccount(string accountNumber, string placeHolder,
            double balanceAmount, int accountType)
        {
            var savingAccount = new SavingAccount
            {
                AccountNumber = accountNumber,
                PlaceHolder = placeHolder,
                BalanceAmount = balanceAmount,
                AccountType = accountType
            };

            return savingAccount;
        }

        private static BankAccount SelectAccountType()
        {
            BankAccount bankAccount = null;
            Console.Write("Account Type                  : ");
            int accountType = int.Parse(Console.ReadLine());
            if (accountType == 1)
            {
                Console.Write("Account Number             : ");
                var accountNumber = Console.ReadLine();
                Console.Write("Place holder             : ");
                var placeHolder = Console.ReadLine();
                Console.Write("Balance amount : ");
                double balanceAmount = double.Parse(Console.ReadLine());
                bankAccount = CreateSavingAccount(accountNumber, placeHolder, balanceAmount, accountType);
            }
            else if (accountType == 2)
            {
                Console.Write("Account Number             : ");
                var accountNumber = Console.ReadLine();
                Console.Write("Place holder             : ");
                var placeHolder = Console.ReadLine();
                Console.Write("Balance amount : ");
                double balanceAmount = double.Parse(Console.ReadLine());
                Console.Write("Overdraft amount : ");
                double overdraftAmount = double.Parse(Console.ReadLine());
                bankAccount = CreateCheckingAccount(accountNumber, placeHolder, balanceAmount,
                    accountType, overdraftAmount);
            }

            return bankAccount;
        }

        private static void Menu()
        {
        var option = ' ';
            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("    Select an Operation to Perform    ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                TransactionAccount transactionAccount = new TransactionAccount();
                switch (option)
                {
                    case '0':
                        Console.WriteLine("Exit");
                        break;

                    case '1':
                        InsertAccount();
                        break;

                    case '2':
                        transactionAccount.GetBalance(accountList);
                        break;

                    case '3':
                        transactionAccount.Deposit(accountList);
                        break;

                    case '4':
                        transactionAccount.Withdrawal(accountList);
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

              ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }
        public Bank()
        {
        }
    }
}
