using System;
using System.Collections.Generic;

namespace BankApp
{
    class BankingApp
    {
        static List<IBankAccount> accountList = new List<IBankAccount>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1- Create Account");
                Console.WriteLine("2- Get Balance");
                Console.WriteLine("3- Deposit Amount");
                Console.WriteLine("4- Withdrawal Amount");
                Console.WriteLine("0- Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        GetBalance();
                        break;
                    case "3":
                        DepositAmount();
                        break;
                    case "4":
                        WithdrawalAmount();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.WriteLine("Create Account");
            Console.WriteLine("--------------");

            Console.WriteLine("Account Type (1-Saving , 2-Checking):");
            string accountTypeInput = Console.ReadLine();

            if (!Enum.TryParse(accountTypeInput, out AccountType accountType))
            {
                Console.WriteLine("Invalid account type.");
                return;
            }

            Console.WriteLine("Account Number:");
            string accountNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(accountNumber) || accountNumber.Length != 10 || !IsDigitsOnly(accountNumber))
            {
                Console.WriteLine("Account number must have 10 digits.");
                return;
            }

            if (ExistsAccount(accountNumber))
            {
                Console.WriteLine($"Account {accountNumber} already exists.");
                return;
            }

            Console.WriteLine("Account Owner:");
            string accountOwner = Console.ReadLine();

            if (string.IsNullOrEmpty(accountOwner) || accountOwner.Length > 50)
            {
                Console.WriteLine("Account owner is required and max length is 50 characters.");
                return;
            }

            IBankAccount account;

            if (accountType == AccountType.Saving)
            {
                account = new SavingAccount
                {
                    AccountNumber = accountNumber,
                    AccountOwner = accountOwner
                };
            }
            else if (accountType == AccountType.Checking)
            {
                decimal overdraftAmount = CheckingAccount.MIN_OVERDRAFT_AMOUNT;
                decimal balanceAmount;

                Console.WriteLine("Balance Amount:");
                if (!decimal.TryParse(Console.ReadLine(), out balanceAmount) || balanceAmount <= 0)
                {
                    Console.WriteLine("Invalid balance amount.");
                    return;
                }

                account = new CheckingAccount
                {
                    AccountNumber = accountNumber,
                    AccountOwner = accountOwner,
                    BalanceAmount = balanceAmount + overdraftAmount,
                    OverdraftAmount = overdraftAmount
                };
            }
            else
            {
                Console.WriteLine("Invalid account type.");
                return;
            }

            accountList.Add(account);
            Console.WriteLine("\nAccount Created");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void GetBalance()
        {
            Console.WriteLine("Get Balance");
            Console.WriteLine("-----------");

            Console.WriteLine("Account Number:");
            string accountNumber = Console.ReadLine();

            IBankAccount account = FindAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine($"Account {accountNumber} not found.");
                return;
            }

            Console.WriteLine($"Account Type = {account.AccountType}");
            Console.WriteLine($"Account Owner = {account.AccountOwner}");
            Console.WriteLine($"Balance Amount = {account.BalanceAmount}");
            if (account.AccountType == AccountType.Checking)
            {
                Console.WriteLine($"Overdraft Amount = {((CheckingAccount)account).OverdraftAmount}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DepositAmount()
        {
            Console.WriteLine("Deposit Amount");
            Console.WriteLine("--------------");

            Console.WriteLine("Account Number:");
            string accountNumber = Console.ReadLine();

            IBankAccount account = FindAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine($"Account {accountNumber} not found.");
                return;
            }

            Console.WriteLine("Amount:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Amount is required and must be numeric and greater than zero.");
                return;
            }

            account.BalanceAmount += amount;

            Console.WriteLine("\nDeposit Success");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void WithdrawalAmount()
        {
            Console.WriteLine("Withdrawal Amount");
            Console.WriteLine("-----------------");

            Console.WriteLine("Account Number:");
            string accountNumber = Console.ReadLine();

            IBankAccount account = FindAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine($"Account {accountNumber} not found.");
                return;
            }

            Console.WriteLine("Amount:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Amount is required and must be numeric and greater than zero.");
                return;
            }

            if (account.AccountType == AccountType.Saving)
            {
                if (account.BalanceAmount < amount)
                {
                    Console.WriteLine("Insufficient balance.");
                    return;
                }
            }
            else if (account.AccountType == AccountType.Checking)
            {
                if (account.BalanceAmount + ((CheckingAccount)account).OverdraftAmount < amount)
                {
                    Console.WriteLine("Insufficient balance.");
                    return;
                }
            }

            account.BalanceAmount -= amount;

            Console.WriteLine("\nWithdrawal Success");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static bool ExistsAccount(string accountNumber)
        {
            foreach (var account in accountList)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return true;
                }
            }
            return false;
        }

        static IBankAccount FindAccount(string accountNumber)
        {
            foreach (var account in accountList)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
