using System;

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
            var option = ' ';
            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("    BANK CONSOLE APPLICATION   ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("   1. Create Account");
                Console.WriteLine("   2. Get Balance Account");
                Console.WriteLine("   3. Deposit Account");
                Console.WriteLine("   4. Withdrawal Account");
                Console.WriteLine("   0. Exit");
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '0':
                        Console.WriteLine("\nSaliendo");
                        //createAccount();
                        break;
                    case '1':
                        Console.WriteLine("\ncreando cuenta pai");
                        //createAccount();
                        break;
                    case '2':
                        Console.WriteLine("\nViending balance pai");
                        //createAccount();
                        break;
                    case '3':
                        Console.WriteLine("\nDepositar En La Cuenta Pai");
                        //createAccount();
                        break;
                    case '4':
                        Console.WriteLine("\nwithDrawal Account");
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option");
                        break;
                }
                ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }
    }
}
