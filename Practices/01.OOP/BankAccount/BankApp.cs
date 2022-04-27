using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankAccount
{
    class BankApp
    {   
        
        public static List<AccountDto> listAccount = new List<AccountDto>();    
        private static void Main(string[] args)
        {
           try
           {
               Menu();
           }
           catch(Exception e)
           {
               Console.WriteLine(e);
           }

        }

        private static void Menu()
        {
            var menuOption =' ';

            while(menuOption !='0')
            {
                Console.Clear();
                Console.WriteLine("First World Bank App     ");
                Console.WriteLine("---------------------");
                Console.WriteLine("----Select an Option----");
                Console.WriteLine("---------------------");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Get the balance of your Account");
                Console.WriteLine("3. Deposit cash in your Account");
                Console.WriteLine("4. Cash withdrawals");
                Console.WriteLine("0. Exit");
                menuOption = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(menuOption)
                {
                    case '0':
                        Console.WriteLine("Exiting App...");
                        Console.WriteLine("App by Juan Felipe Osorio.");
                        
                        break;
                    case '1':
                        InsertAccount();
                        break;
                    case '2':
                        GetAccountBalance();
                        break;
                    case '3':
                        AccountDeposit();
                        break;
                    case '4':
                        AccountWithdrawal();
                        break;
                    default:
                        Console.WriteLine("Invalid Option, please try again.");
                        break;
                }
                ;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private static void InsertAccount()
        {
            var SideMenuOption = ' ';
            var accountType = " ";
            int accountBalance = 0;
            int accountOverdraft = 0;

            Console.Write("Set Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Set Place Holder: ");
            var accountPlaceHolder = Console.ReadLine();
            Console.WriteLine("Set the Account type: ");
            Console.WriteLine("1. Saving Account.");
            Console.WriteLine("2. Checking Account.");
            SideMenuOption = Console.ReadKey().KeyChar;
            switch (SideMenuOption)
            {
                case '1':
                    accountType = "Saving Account";
                    Console.WriteLine("\nYou selected a "+ accountType);
                    break;
                case '2':                   
                    accountType = "Checking Account";
                    Console.WriteLine("\nYou selected a "+ accountType+"\n");

                    Console.Write("\nSet the account Overdraft Amount: ");
                    int setAccountOverdraft = int.Parse(Console.ReadLine());
                    accountOverdraft = -(accountOverdraft + setAccountOverdraft);
                    break;
                default:
                    Console.WriteLine("Account type not found. Try Again...");
                    break;
            }
            //Made By Juan Felipe Osorio


            AccountDto newAccount = new AccountDto();
            newAccount = CreateAccount(accountNumber, accountPlaceHolder, accountBalance, accountType, accountOverdraft);

            listAccount.Add(newAccount);
        }
        private static AccountDto CreateAccount(int accountNumber, string accountPlaceHolder, int accountBalance, string accountType, int accountOverdraft)
        {
           
            AccountDto AccountDto = new AccountDto();
            AccountDto.AccountNumber = accountNumber;
            AccountDto.AccountPlaceHolder = accountPlaceHolder;
            AccountDto.AccountType = accountType;
            AccountDto.AccountBalance = accountBalance;
            AccountDto.AccountOverdraft = accountOverdraft;

        return AccountDto;
        }
        private static void GetAccountBalance()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Account Balance");
            Console.WriteLine("---------------");
            Console.Write("Please put your Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (AccountDto searchInAccount in listAccount)
            {
                if(searchInAccount.AccountNumber == accountNumber){
                    Console.Write("Account Place Holder: ");
                    Console.WriteLine(searchInAccount.AccountPlaceHolder);
                    Console.Write("Your Account Balance: ");
                    Console.WriteLine(searchInAccount.AccountBalance);
                    Console.Write("Account Type: ");
                    Console.WriteLine(searchInAccount.AccountType);
                    Console.Write("Account Overdraft: ");
                    Console.WriteLine(searchInAccount.AccountOverdraft);
                }
            }
        }
        private static void AccountDeposit()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Account Deposit");
            Console.WriteLine("----------------");
            Console.Write("Please put your Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (AccountDto searchInAccount in listAccount)
            {
                if(searchInAccount.AccountNumber == accountNumber){
                    Console.Write("Your Account Balance: ");
                    Console.WriteLine(searchInAccount.AccountBalance);
                    Console.Write("Please enter the balance to deposit: ");
                    int accountBalance = int.Parse(Console.ReadLine());
                    searchInAccount.Deposit(accountBalance);
                    Console.Write("Current Account Balance: ");
                    Console.WriteLine(searchInAccount.AccountBalance);
                }
            }
        }

        private static void AccountWithdrawal()
        {
            Console.Clear();
            Console.WriteLine("Account Withdraw");
            Console.Write("Please put your Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (AccountDto searchInAccount in listAccount)
            {
                if(searchInAccount.AccountNumber == accountNumber){
                    Console.Write("Your Account Balance: ");
                    Console.WriteLine(searchInAccount.AccountBalance);

                    Console.Write("Enter the balance to be withdrawn: ");
                    int accountBalance = int.Parse(Console.ReadLine());
                    searchInAccount.Withdrawal(accountBalance);

                    Console.Write("Current Account Balance: ");
                    Console.WriteLine(searchInAccount.AccountBalance);
                }
            }
        }
    }
}

