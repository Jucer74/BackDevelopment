using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        private static List<BankAccount> listBankAccounts = new List<BankAccount>();
        private static Bank bank = new Bank();
        static void Main(string[] args)
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
        private static void showBalanceAccount(int numberInput)
        {
            for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
            {
                if (bank.listBankAccounts[currentAccount].NumberAccount == numberInput)
                {
                    Console.WriteLine("Balance For: "+ bank.listBankAccounts[currentAccount].NumberAccount + " Is: "+ bank.listBankAccounts[currentAccount].BalanceAmount);
                }
            }
        }
        private static void createBankAccount()
        {
            bool validType = false;

            Console.WriteLine("\n Please Digit Your Account ID ");
            int numberAccount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Please Digit Your Name ");
            string username = Console.ReadLine();
            Console.WriteLine("\n Please Enter Your Current Balance ");
            double balanceAmount = Convert.ToDouble(Console.ReadLine());
            while (!validType)
            {
                Console.WriteLine("\n What Type of Client Are you:\n1. SavingAccount\n2. CheckingAccount");
                int accountType = int.Parse(Console.ReadLine());

                if (accountType == 1 || accountType == 2)
                {
                    balanceAmount = 0;
                    bank.CreateAccount(numberAccount, username, balanceAmount, accountType);
                    validType = true;
                }
                else
                {
                    Console.WriteLine("This Account is invalid");
                }
            }
        }

        private static void AccountDeposit()
        {
            Console.WriteLine("Identify With your Account ID ");
            int numberAccount = Convert.ToInt32(Console.ReadLine());

            for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
            {
                
                if (numberAccount == bank.listBankAccounts[currentAccount].NumberAccount)
                {
                    Console.WriteLine("Digit the Ammount to Deposit");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    // Intento De Manejo de Clases Fallido
                    // listBankAccounts[currentAccount].Deposit(amount);
                    bank.listBankAccounts[currentAccount].BalanceAmount = bank.listBankAccounts[currentAccount].BalanceAmount+amount;
                }
            }
        }
        private static void AccountWithdraw()
        {
            Console.WriteLine("Identify With your Account ID ");
            int numberAccount = Convert.ToInt32(Console.ReadLine());

            for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
            {
                
                if (numberAccount == bank.listBankAccounts[currentAccount].NumberAccount)
                {
                    Console.WriteLine("Digit the Ammount to Withdraw");
                    double amount = double.Parse(Console.ReadLine());
                     // Intento De Manejo de Clases Fallido #2
                    // listBankAccounts[currentAccount].Withdraw(amount);
                    bank.listBankAccounts[currentAccount].BalanceAmount = bank.listBankAccounts[currentAccount].BalanceAmount-amount;
                }
            }
        }
        private static void Menu()
        {
            var useroption = ' ';
            while (useroption != '0')
            {
                Console.WriteLine("Welcome to ZothBank");
                Console.WriteLine("----------------------------------------");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("-Please Choose One of These Options-");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("----------------------------------------");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("1-Create Account-------------------------");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("2-Get Account Balance--------------------");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("3-Deposit--------------------------------");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("4-Withdraw-------------------------------");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("5-Check All Accounts---------------------"); 
                System.Threading.Thread.Sleep(500); 
                Console.WriteLine("0-Exit-----------------------------------");
                Console.WriteLine("-----------------------------------------"); 
                useroption = Console.ReadKey().KeyChar;

                switch (useroption)
                {
                 case '0':
                        Console.WriteLine("\n------Thanks For Using ZothBank------");

                        break;
                 case '1':
                        createBankAccount();
                        break;
                 case '2':
                        Console.WriteLine("Write the Account ID...");
                        int userIDinput = Convert.ToInt32(Console.ReadLine());
                        showBalanceAccount(userIDinput);
                        break;
                 case '3':
                        AccountDeposit();
                        break;
                 case '4':
                        AccountWithdraw();
                        break;
                 case '5':
                        for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
                        {
                            Console.WriteLine("\nAccount ID: "
                                            + bank.listBankAccounts[currentAccount].NumberAccount
                                            + "\n PlaceHolder Name: " + bank.listBankAccounts[currentAccount].PlaceHolder
                                            + "\n Balance: " + bank.listBankAccounts[currentAccount].BalanceAmount);
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option.");
                        break;
                }
                ;

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}