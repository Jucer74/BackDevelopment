using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankApp
{
    class Program
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
            var option =' ';


            while(option !='0')
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("|       BANK APLICATION       |");
                Console.WriteLine("------------------------------\n");

                Console.WriteLine("------------------------------");
                Console.WriteLine("|      1. CreateAccount      |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("|   2. Get Balance Account   |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("|     3. Deposit Account     |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("|    4. Withdrawal Account   |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("|          0. Exit           |");
                Console.WriteLine("------------------------------\n");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':
                        Console.Clear();
                        Console.WriteLine("You are leaving the application...\n");
                        break;
                    case '1':
                        Console.Clear();
                        InsertAccount();
                        break;
                    case '2':
                        Console.Clear();
                        GetBalanceAccount();
                        break;
                    case '3':
                        Console.Clear();
                        DepositAccount();
                        break;
                    case '4':
                        Console.Clear();
                        WithdrawalAccount();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                ;

                Console.WriteLine("\n---------------------------------------------------");
                Console.WriteLine("|            Press any key to continue            |");
                Console.WriteLine("---------------------------------------------------");
                Console.ReadKey();
            }
        }
        private static void InsertAccount()
        {
            
            var option = ' ';
            var accountType = " ";
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|                            CreateAccount                           |");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("You are creating an account, please enter the following information...\n");

            Console.Write("Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Place Holder: ");
            var placeHolder = Console.ReadLine();
            Console.WriteLine("\nAccount Type");
            Console.WriteLine("1. Saving");
            Console.WriteLine("2. Checking\n");
            option = Console.ReadKey().KeyChar;
            switch (option)
            {
                case '1':
                    accountType = "Saving";
                    break;
                case '2':
                    accountType = "Checking";
                    break;
                default:
                    Console.WriteLine("Account type not found");
                    Console.WriteLine("Select an account type");
                    break;
            }

            Console.Write("\n\nInsert overdraft Amount: \n");
            int overdraftAccount = int.Parse(Console.ReadLine());
            int balanceAccount = 0;
            balanceAccount = balanceAccount + overdraftAccount;

            AccountDto newAccount = new AccountDto();
            newAccount = CreateAccount(accountNumber, placeHolder, balanceAccount, accountType);

            listAccount.Add(newAccount);
        }
        private static AccountDto CreateAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType)
        {
           
            AccountDto accountDto = new AccountDto();
            accountDto.Accountnumber = accountNumber;
            accountDto.Placeholder = placeHolder;
            accountDto.Accountype = accountType;
            accountDto.Balanceaccount = balanceAccount;

        return accountDto;
        }

        private static void GetBalanceAccount()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("|                    BalanceAccount                     |");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("To check your balance, first enter your account number...\n");

            Console.Write("Account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.Write("\nPlace holder: ");
                    Console.WriteLine(searchAccount.Placeholder);
                    Console.Write("Balance account: ");
                    Console.WriteLine(searchAccount.Balanceaccount);
                }

            }

        }

        private static void DepositAccount()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("|                 DepositeAccount                 |");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Enter your account details to make the deposit....\n");

            Console.Write("\nAccount number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.Write("\nMr. ");
                    Console.Write(searchAccount.Placeholder);
                    Console.Write("\nYour current balance is: ");
                    Console.Write(searchAccount.Balanceaccount);

                    Console.Write("\nWhat balance do you want to deposit: ");
                    int balanceAccount = int.Parse(Console.ReadLine());

                    searchAccount.Deposit(balanceAccount);
                }

            }
        }

        private static void WithdrawalAccount()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("|                           WithdrawalAccount                           |");
            Console.WriteLine("-------------------------------------------------------------------------");
             Console.WriteLine("To make a transaction you must enter the following data step by step....\n");

            Console.Write("Account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.Write("\nBalance account: ");
                    Console.Write(searchAccount.Balanceaccount);

                    Console.Write("Enter the balance to withdraw: ");
                    int balanceAccount = int.Parse(Console.ReadLine());

                    searchAccount.Withdrawal(balanceAccount);
                }

            }

        }
    }
}
