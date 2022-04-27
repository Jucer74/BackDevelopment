using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {     
        public static List<SavingAccount> listAccount = new List<SavingAccount>();    
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
                Console.Clear();
                Console.WriteLine("     Welcone    ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Account");
                Console.WriteLine("3. withdrawal Account");
                Console.WriteLine("4. Balance Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':

                        Console.WriteLine("Exit");
                        break;

                    case '1':
                       
                        CreateAccount();
                        break;

                    case '2':

                        GetBalanceAccount();
                        break;

                    case '3':
                       
                        DepositAccount();
                        break;

                    case '4':
                        
                        WithdrawalAccount();
                        
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            }
        }
        private static void  CreateAccount()
        {
            
            var option = ' ';
            var accountType = " ";
            
            Console.WriteLine("option 1 --------> CreateAccount");

            Console.WriteLine("Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Place Holder: ");
            var placeHolder = Console.ReadLine();

            Console.WriteLine("\n\n Account Type");
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
                    break;
            }
        }
        private static SavingAccount CreateAccount(int accountNumber, 
                                                string placeHolder, 
                                                int balanceAccount, 
                                                string accountType)
        {
           
            SavingAccount accountDto = new SavingAccount();

            accountDto.Accountnumber = accountNumber;
            accountDto.Placeholder = placeHolder;
            accountDto.Balanceaccount = balanceAccount;
            accountDto.Accountype = accountType;

        return accountDto;
        }
        private static void GetBalanceAccount()
        {
            Console.WriteLine("option 4 --------> Balance");

            Console.WriteLine("Account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (SavingAccount Ac in listAccount)
            {
                if(Ac.Accountnumber == accountNumber){

                    Console.Write($"place Holder {Ac.Placeholder} ");

                    Console.Write($"Balance account:{ Ac.Balanceaccount}");
                   
                }

            }

        }

        private static void WithdrawalAccount()
        {
              Console.WriteLine("option 3 --------> Withdrawal");

            Console.Write("Account number: ");
            int NumberA = int.Parse(Console.ReadLine());
            
            foreach (SavingAccount Ac in listAccount)
            {
                if(Ac.NumberA == NumberA){
                    Console.Write($"Balance account:{Ac.Balanceaccount} ");
                
                    Console.Write("Enter the balance to withdraw: ");
                    int balance = int.Parse(Console.ReadLine());

                    Ac.Withdrawal(balance);
                }

            }

        }
        private static void DepositAccount()
        {
             Console.WriteLine("option 2 --------> Deposit");

            Console.Write("\nAccount number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (SavingAccount Ac in listAccount)
            {
                if (Ac.Accountnumber == accountNumber){
                  
                    Console.WriteLine(Ac.Placeholder);
                    Console.Write($"Your  balance is: {Ac.Balanceaccount}");
                

                    Console.Write("\nWhat balance do you want to deposit: ");
                    int balanceAccount = int.Parse(Console.ReadLine());

                    Ac.Deposit(balanceAccount);
                }

            }
        }
    }
}
