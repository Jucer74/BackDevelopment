namespace Bank
{

    using System;
    using System.Globalization;
 

    internal class Program
    {
        private static readonly AccountData accountData = new AccountData();

        static ProgramAccount  programAccount = new ProgramAccount();
    

        private static void Main(string[] args)
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
                Console.WriteLine("     BankApp    ");
                Console.WriteLine("---------------------");
                Console.WriteLine("1. Create Account ");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("---------------------");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '0':
                        Console.WriteLine("Exit");
                        break;
                    case '1':
                        Program.programAccount.ProcessAccount();
                        break;
                    case '2':
                         Program.programAccount.ProcessGetBalance();
                        break;
                    case '3':
                        Console.WriteLine("3. Deposit Account");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

              ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }


    

 

 
    }
}