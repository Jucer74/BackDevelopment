using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Bank
    {
        private static List<BankAccount> accountList;

        private static TransactionAccount transactionAccount;

        private static UtilityAccountValidation utilityAccountValidation;

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
            utilityAccountValidation = new UtilityAccountValidation();
            Console.Clear();
            Console.WriteLine("Insert new Account");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            var account = utilityAccountValidation.SelectAccountType(accountList);
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
                transactionAccount = new TransactionAccount();
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
