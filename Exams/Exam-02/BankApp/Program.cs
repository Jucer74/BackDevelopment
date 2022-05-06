using System;
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
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Menu()
        {
            BankAccount bankAccount = new BankAccount();
            var option = ' ';

            while (option != '5')
            {
                Console.WriteLine("\n----------------------------------------------------");
                Console.WriteLine("Welcome to Bancolombia");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Whitdrawal");
                Console.WriteLine("5. Exit");


                Console.WriteLine("Select a opcion: ");
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':

                        bankAccount.CreateAccount();

                        break;

                    case '2':
                        bankAccount.ShowInfoGetBalanceAccount();
                        break;

                    case '3':
                        bankAccount.DepositAccount();
                        break;

                    case '4':
                        bankAccount.Withdrawal();
                        break;

                    case '5':
                        Console.WriteLine("\nExit");
                        break;
                    default:
                        Console.WriteLine("\nInvalid Value");
                        break;
                }
            }
        }
    }
}
