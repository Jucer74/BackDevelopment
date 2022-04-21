namespace BankApp
{

    using System;
    class Program
    {
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

        List <BankAccount> ListAccounts = new List<BankAccount>(); 

        private static void Menu()
        {

            var option = ' ';

            while (option != '0')
            {

            Console.Clear();
            Console.WriteLine("     B.A.N.K A.P.P    ");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Get Balance Account");
            Console.WriteLine("3. Deposit Account");
            Console.WriteLine("4. Withdrawal Account");
            Console.WriteLine("0. Exit");
            option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
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
                break;

                case '4':
                break;

            }

            Console.WriteLine("\nPress any key to continue... ");
            Console.ReadKey();
        }
        }

        private static BankAccount CreateAccount(){
            Console.Write("Account Number         :");
            var accountNumber = Console.ReadLine();
            Console.Write("Place Molder         :");
            var placeMolder = Console.ReadLine();
            Console.Write("Balance Amount         :");
            var balanceAmount = Console.ReadLine();
            Console.Write("Account Type        :");
            var accountType = Console.ReadLine();

            var bankAccount = new BankAccount 
            {
                AccountNumber = accountNumber,
                PlaceMolder = placeMolder,
                BalanceAmount = balanceAmount,
                AccountType = accountType
            };

            if (ListAccounts.Contains<BankAccount>(bankAccount) == false){
                ListAccounts.Add(bankAccount);
                Console.WriteLine("Successful account creation");
            }
            else{
                Console.WriteLine("Account creation error");
            }
        }

        private static bool SearchAccount(BankAccount accountNumberSearch){
            if (ListAccounts.Contains<BankAccount>(accountNumberSearch)== false){
                return false;
            }
            else{
                return true;
            }
        }

        private static double GetBalanceAccount(){
            Console.WriteLine("Enter account number");
            var accountNumberSearch = Console.ReadLine();
            accountNumberSearch = new BankAccount();
            if(SearchAccount(accountNumberSearch)==true){
                Console.WriteLine("error looking for the account");
            }
            else{
                Console.WriteLine("Found account");
                Console.WriteLine("Your Balance is:      ");
                Console.WriteLine(accountNumberSearch.BalanceAmount());
            }
        }

    }

}
