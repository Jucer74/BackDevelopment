using System;
//using BankApp.BankAccount;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;

            bool isExit = false;
            List<BankAccount> accountList = new List<BankAccount>();

            while(isExit == false)
            {
                //Menu
                Console.Clear();
                Console.WriteLine("\n BANK MENU");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("5. Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateAccount(accountList);
                    break;

                    case "2":
                        GetBalanceAccount(accountList);
                    break;

                    case "3":
                        DepositAccount(accountList);
                    break;

                    case "4":
                        WithdrawalAccount(accountList);
                    break;

                    case "5":
                        isExit = true;
                    break;
                } // Switch 
                 
            }
        } // 
        
        public static void CreateAccount(List<BankAccount> accountList)
        {
            Console.Clear();
            Console.WriteLine("\n Select the type of bank account: ");
            Console.WriteLine("   1. Saving Account");
            Console.WriteLine("   2. Checking Account");
            int accountType = int.Parse(Console.ReadLine());
            
            accountList.Add(CreateAccountType(accountType));

            Console.WriteLine("\n **** The account was created successfully ***");
        }

        public static void GetBalanceAccount(List<BankAccount> accountList)
        {
            Console.Clear();
            Console.WriteLine("\n Enter the number account: ");
            int accountNumber = int.Parse(Console.ReadLine());

            foreach (BankAccount account in accountList)
            {
                if(account.AccountNumber == accountNumber)
                {
                    Console.WriteLine(account.PlaceHolder + "     #" + account.AccountNumber);
                    Console.WriteLine("********** Balance Account = " + account.BalanceAmount + "**********");
                } else
                {
                    Console.WriteLine("Error: Account not found, please try again.");
                }
            }
        }

        public static void DepositAccount(List<BankAccount> accountList)
        {
            Console.Clear();
            Console.WriteLine("\n Enter the number account: ");
            int accountNumber = int.Parse(Console.ReadLine());

            foreach (BankAccount account in accountList)
            {
                if(account.AccountNumber == accountNumber)
                {
                    Console.WriteLine("   - Enter the amount: ");
                    int amount = int.Parse(Console.ReadLine());
                    account.Deposit(amount);

                    Console.WriteLine("   ********** Your new balance is: " + account.BalanceAmount);
                } else
                {
                    Console.WriteLine("Error: Account not found, please try again.");
                }
            }
        }

        public static void WithdrawalAccount(List<BankAccount> accountList)
        {
            Console.Clear();
            Console.WriteLine("\n Enter the number account: ");
            int accountNumber = int.Parse(Console.ReadLine());

            foreach (BankAccount account in accountList)
            {
                if(account.AccountNumber == accountNumber)
                {
                    Console.WriteLine("   - Enter the amount: ");
                    int amount = int.Parse(Console.ReadLine());
                    
                    if(amount > account.BalanceAmount)
                    {
                        Console.WriteLine("Error: The amount exceeds the balance.");
                    } else {
                        account.Withdrawal(amount);
                        Console.WriteLine("   ********** Your new balance is: " + account.BalanceAmount);
                    }
                } else
                {
                    Console.WriteLine("Error: Account not found, please try again.");
                }
            }
        }

        public static BankAccount CreateAccountType(int accountType)
        {
            if(accountType == 1)
            {
                SavingAccount savingAccount = new SavingAccount();

                Console.WriteLine("   - Enter the name of the account holder: ");
                savingAccount.PlaceHolder = Console.ReadLine();

                Console.WriteLine("   - Enter the bank account number: ");
                savingAccount.AccountNumber = int.Parse(Console.ReadLine());

                savingAccount.BalanceAmount = 0;

                return savingAccount;
            }else 
            {
                CheckingAccount checkingAccount = new CheckingAccount();

                Console.WriteLine("   - Enter the name of the account holder: ");
                checkingAccount.PlaceHolder = Console.ReadLine();

                Console.WriteLine("   - Enter the bank account number: ");
                checkingAccount.AccountNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("   - Select the value of the amount for credit: ");
                checkingAccount.BalanceAmount = int.Parse(Console.ReadLine());
        
                return checkingAccount;
            }
        }
    } // Class Program
}
