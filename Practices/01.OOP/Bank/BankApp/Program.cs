using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        private static Bank bank = new Bank();
        static void Main(string[] args)
        {

            List<BankAccount> listBankAccounts = new List<BankAccount>();
            BankAccount bAccount = new BankAccount();

            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        private static void showBalanceAccount(string numberInput)
        {
            for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
            {
                if (bank.listBankAccounts[currentAccount].NumberAccount == numberInput)
                {
                    Console.WriteLine("Account of number "+ bank.listBankAccounts[currentAccount].NumberAccount
                                    + "the Balance is: "+ bank.listBankAccounts[currentAccount].BalanceAmount);
                }
            }
        }
        private static void createBankAccount()
        {
            bool validType = false;
            double balanceAmount = 0;

            Console.WriteLine("\n write the numberAccount of new Account ");
            string numberAccount = Console.ReadLine();
            Console.WriteLine("\n write the name of Account Owner ");
            string placeHolder = Console.ReadLine();
            while (!validType)
            {
                Console.WriteLine("\n Select the type of bank account:\n1. SavingAccount\n2. CheckingAccount");
                int accountType = int.Parse(Console.ReadLine());

                if (accountType == 1 || accountType == 2)
                {
                    balanceAmount = 0;
                    bank.CreateAccount(numberAccount, placeHolder, balanceAmount, accountType);
                    validType = true;
                }
                else
                {
                    Console.WriteLine("this AccountType is invalid");
                }
            }
        }
        private static void Menu()
        {
            var option = ' ';
            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.WriteLine("    BANK CONSOLE APPLICATION   ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("   1. Create Account");
                Console.WriteLine("   2. Get Balance Account");
                Console.WriteLine("   3. Deposit Account");
                Console.WriteLine("   4. Withdrawal Account");
                Console.WriteLine("   5. ver cuentas");
                Console.WriteLine("   0. Exit");
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '0':
                        Console.WriteLine("\n------Thanks for use AppBank------");

                        break;
                    case '1':
                        createBankAccount();
                        break;
                    case '2':
                        Console.WriteLine("write the numberAccount to consult Balance...");
                        string consult = Console.ReadLine();
                        showBalanceAccount(consult);
                        break;
                    case '3':
                        Console.WriteLine("\ndeposit in ");
                        //createAccount();
                        break;
                    case '4':
                        Console.WriteLine("\nwithDrawal Account");
                        break;
                    case '5':
                        for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
                        {
                            Console.WriteLine("\ntitular de cuenta de numero "
                                            + bank.listBankAccounts[currentAccount].NumberAccount
                                            + ": " + bank.listBankAccounts[currentAccount].PlaceHolder);
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option, try again");
                        break;
                }
                ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }
    }
}
