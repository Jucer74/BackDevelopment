using System;

namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
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
            var option = ' ';

            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("     Banking Operation    ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Amount");
                Console.WriteLine("3. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                case '0':
                    Console.WriteLine("Exit");
                    break;
                case '1':
                    Console.WriteLine("CreateAccount");
                    break;
                case '2':
                    Console.WriteLine("DepositAccount");
                    break;
                case '3':
                    Console.WriteLine("WithdrawalAccount");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
                }

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }

    }
}
