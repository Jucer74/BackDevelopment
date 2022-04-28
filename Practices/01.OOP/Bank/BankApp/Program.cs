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
                Console.WriteLine("      BANK     ");
                Console.WriteLine("---------------");
                Console.WriteLine("1. CreateAccount");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':
                        Console.WriteLine("Exit to bank");
                        break;
                    case '1':
                        InsertAccount();
                        break;
                    case '2':
                        GetBalanceAccount();
                        break;
                    case '3':
                        DepositAccount();
                        break;
                    case '4':
                        WithdrawalAccount();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                ;

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private static void InsertAccount()
        {
            
            var option = ' ';
            var accountType = " ";
            Console.WriteLine("Account Number   :");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Place Holder     :");
            var placeHolder = Console.ReadLine();
            Console.WriteLine("Account Type");
            Console.WriteLine("1. Saving");
            Console.WriteLine("2. Checking");
            option = Console.ReadKey().KeyChar;
            switch (option)
            {
                case '1':
                    accountType = "Saving Account";
                    break;
                case '2':
                    Console.WriteLine("\nOverdraft Amount = 10000000");
                    accountType = "Checking Account";
                    break;
                default:
                    Console.WriteLine("Account type not found");
                    Console.WriteLine("Select an account type");
                    break;
            }

            Console.WriteLine("Insert Balance Account");
            int balanceAccount = int.Parse(Console.ReadLine());
            
            AccountDto newAccount = new AccountDto();
            newAccount = CreateAccount(accountNumber, placeHolder, balanceAccount, accountType);

            listAccount.Add(newAccount);
        }
        private static AccountDto CreateAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType)
        {
           
            AccountDto accountDto = new AccountDto();
            accountDto.AccountNumber= accountNumber;
            accountDto.PlaceHolder = placeHolder;
            accountDto.AccounType = accountType;
            accountDto.BalanceAccount = balanceAccount;

        return accountDto;
        }

        private static void DepositAccount()
        {
            Console.Clear();
            Console.WriteLine("----------------");
            Console.WriteLine("DEPOSIT ACCOUNT");
            Console.WriteLine("----------------");
            Console.WriteLine("ENTER ACCOUNT NUMBER");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAccount);

                    Console.WriteLine("Enter the balance to deposit");
                    int balanceAccount = int.Parse(Console.ReadLine());
                    
                    searchAccount.Deposit(balanceAccount);
                }

            }
        }

        private static void GetBalanceAccount()
        {
            Console.Clear();
            Console.WriteLine("----------------");
            Console.WriteLine("Balance Account");
            Console.WriteLine("---------------");
            Console.WriteLine("ENTER ACCOUNT NUMBER");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAccount);
                }

            }

            //se debe retornar el balance de la cuenta
        }

        private static void WithdrawalAccount()
        {
            Console.Clear();
            Console.WriteLine("----------------");
            Console.WriteLine("Withdraw Account");
            Console.WriteLine("----------------");
            //se verifica el numero de cuenta
            Console.WriteLine("ENTER ACCOUNT NUMBER");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAccount);

                    Console.WriteLine("Enter the balance to withdraw");
                    int balanceAccount = int.Parse(Console.ReadLine());
                    var typeAccount = searchAccount.AccounType;
                    searchAccount.Withdrawal(balanceAccount, typeAccount);
                }

            }

        }
    }
}
