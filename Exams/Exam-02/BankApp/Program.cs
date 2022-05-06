using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {

        
        public static List<Account> Accountlist = new List<Account>();
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
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

            while(option!='0')
            {
                
                Console.WriteLine("       BANK           ");
                Console.WriteLine("----------------------");
                Console.WriteLine(" welcome to the bank  ");
                Console.WriteLine("1. Create Acount");
                Console.WriteLine("2. Get balance acount");
                Console.WriteLine("3. Desposit account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':
                        Console.WriteLine("closed session");
                        break;
                    case '1':
                        InsertAccount();
                        break;
                    case '2':
                        BalanceAccount();
                        break;
                    case '3':
                        DespositAccount();
                        break;
                    case '4':
                        Withdrawal();
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                };
                Console.WriteLine("press sapce bar to continue");
                Console.ReadKey();

            }

        }

        private static Account CreateAccount(int accountNumber, bool accountType, string placeHolder, double balanceAmount)
        {
            Account account = new Account();
            account.accountNumber = accountNumber;
            account.accountType = accountType;
            account.placeHolder = placeHolder;
            account.balanceAmount = balanceAmount;

            return account;
            
        }

        private static void InsertAccount()
        {   
            bool accountType = false;

            Console.WriteLine("------------------------------");
            Console.WriteLine("Eneter Account number\n");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Place holder\n");
            var placeHolder = Console.ReadLine();
            Console.WriteLine("Select account type");
            Console.WriteLine("-------------------");
            Console.WriteLine("|   1. Saving     |");
            Console.WriteLine("|   2. Checking   |");
            Console.WriteLine("-------------------");
            int option = int.Parse(Console.ReadLine());
            
            if (option == 1)
            {
                accountType = true;
            }
            else
            {
                accountType = false;
            }
            
            if(option != 1 || option != 0)
            {
                Console.WriteLine("Select a valid option");
            }

            Console.WriteLine("Balance amount");
            double balanceAmount = double.Parse(Console.ReadLine());
            
            Account account = new Account();
            
            account = CreateAccount(accountNumber, accountType, placeHolder, balanceAmount);

            Accountlist.Add(account);

        }

        private static void BalanceAccount()
        {
            Console.Clear();
            Console.WriteLine("BALANCE");
            Console.WriteLine("");
            Console.WriteLine("Acount number: \n");
            int AccountNumber = int.Parse(Console.ReadLine());

            foreach(Account find in Accountlist)
            {
                if(find.accountNumber == AccountNumber)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|       BALANCE       |");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("");
                    Console.WriteLine(find.balanceAmount);
                }
            }

        }

        private static void DespositAccount()
        {
            Console.WriteLine("|        Make a deposit     |");
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("Account number:\n");
            int accountNumber = int.Parse(Console.ReadLine());

            foreach(Account find in Accountlist)
            {
                if(find.accountNumber == accountNumber)
                {
                    Console.WriteLine("Balance: "+find.balanceAmount);
                    Console.WriteLine("");
                    Console.WriteLine("Enter deposit amount: ");
                    int balanceAmount = int.Parse(Console.ReadLine());

                    find.MakeDeposit(balanceAmount);

                    


                }
            }
            

        }

        private static void Withdrawal()
        {
           Console.WriteLine("|        Make a deposit     |");
           Console.WriteLine(" ---------------------------");
           Console.WriteLine("Account number: \n");
           int AccountNumber = int.Parse(Console.ReadLine());

           foreach(Account find in Accountlist)
           {
               if(find.accountNumber == AccountNumber)
               {
                   Console.WriteLine("available balance: "+find.balanceAmount+"");
                   Console.WriteLine("balance to withdraw: ");
                   int BalanceAccount = int.Parse(Console.ReadLine());

                   find.MakeWithdrawal(BalanceAccount);
               }
           }
        }

    }
}
