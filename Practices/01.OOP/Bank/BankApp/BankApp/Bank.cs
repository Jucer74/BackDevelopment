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

            var account = CreateAccount();
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

        private static void Withdrawal()
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = searchAccount(accountNumber);
            Console.Write("Enter amount to withdraw           : ");
            double amountWithdrawal = double.Parse(Console.ReadLine());
            double subtractionBalance = bankAccount.BalanceAmount - amountWithdrawal;
            bankAccount.BalanceAmount = subtractionBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }

        private static void Deposit()
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = searchAccount(accountNumber);
            Console.Write("Enter amount to deposit           : ");
            double amountDeposit = double.Parse(Console.ReadLine());
            double sumDepositAndBalance = bankAccount.BalanceAmount + amountDeposit;
            bankAccount.BalanceAmount = sumDepositAndBalance;
            Console.Write("New Balance Amount: " + "$" + bankAccount.BalanceAmount);
        }

        private static void GetBalance()
        {
            Console.Write("Account Number             : ");
            string accountNumber = Console.ReadLine();
            BankAccount bankAccount = searchAccount(accountNumber);
            double balanceAmount = bankAccount.BalanceAmount;
            Console.WriteLine("The balance amount is = " + "$" + balanceAmount); ;
        }

        private static BankAccount searchAccount(string textAccount)
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

        private static BankAccount CreateAccount()
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
                bankAccount = new SavingAccount
                {
                    AccountNumber = accountNumber,
                    PlaceHolder = placeHolder,
                    BalanceAmount = balanceAmount,
                    AccountType = accountType
                };
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
                bankAccount = new CheckingAccount
                {
                    AccountNumber = accountNumber,
                    PlaceHolder = placeHolder,
                    BalanceAmount = balanceAmount,
                    AccountType = accountType,
                    OverDraftAmount = overdraftAmount
                };
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

                switch (option)
                {
                    case '0':
                        Console.WriteLine("Exit");
                        break;

                    case '1':
                        InsertAccount();
                        break;

                    case '2':
                        GetBalance();
                        break;

                    case '3':
                        Deposit();
                        break;

                    case '4':
                        Withdrawal();
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
