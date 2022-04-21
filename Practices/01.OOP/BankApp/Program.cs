using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {   
            var account = new BankAccount();
            var option = ' ';
            while(option != '0')
            {
                Console.Clear();
                Console.WriteLine("           WELCOME         ");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Create Acount");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Option");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case'0':
                        Console.WriteLine("Exit");
                        break;
                    case'1':
                        CreateAccount();
                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    case '4':

                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            }
        }

        private static void CreateAccount()
        {   
            var account = new BankAcount();
            double acount;
            string owener;
            double balance;
            int accoutType;
            double Overdaraft;
            float balance;

            
            Console.WriteLine("Account Number");
            Console.ReadLine acount;
            

            Console.WriteLine("Place Holder");
            Console.ReadLine owener;

            Console.WriteLine("Account type");
            Console.ReadLine accountType;

            Console.WriteLine("Overdraft Amount");
            Console.ReadLine Overdraft;

            Console.WriteLine("Initial Balance");
            Console.ReadLine(balance);

            account.BankAccount(acount,owener,balance,accountType,Overdaraft);


        }

        private static void GetBalance()
        {
            
        }
    }
}
