namespace Bank
{

    using System;
    using System.Globalization;
 

    internal class ProgramAccount 
    {
        //private static readonly ApplicationData applicationData = new ApplicationData();
         
        private static readonly AccountData accountData = new AccountData(); 

        private static string typeAccount = "";

        public ProgramAccount(){
 
        }

        public void ProcessAccount(){
               
     
            Console.WriteLine("- Enter number account ");
            string? accountNumber=  Console.ReadLine();
            Console.WriteLine("- Enter placeholder ");
            string? placeHolder = Console.ReadLine(); // por alguna raz[o]n me indica warning -> nullable object instead
            Console.WriteLine("- Enter balance amount");
            string? balanceAmount= Console.ReadLine();

            showMenuAccountTypes();

             AccountDto  accountDto = new AccountDto();
           
            accountDto.AccountNumber = (long)Convert.ToDouble(accountNumber);
            accountDto.PlaceHolder   = placeHolder;
            accountDto.AccountType =  typeAccount;
            accountDto.OverdraftAmount = 0.0;
            accountDto.BalanceAmount = (long)Convert.ToDouble(balanceAmount);
        
            accountData.CreateAccount(accountDto);

        }

        public static void showMenuAccountTypes(){
            var option = ' ';
            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("  **AccountType**  ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Saving , 2) Checking");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '0':
                        Console.WriteLine("Exit");
                        break;
                    case '1':
                        Console.WriteLine("1. SavingAccount");
                        typeAccount = "saving";
                        return;
                    case '2':
                        Console.WriteLine("2. Checking");
                        typeAccount = "Checking";
                        return;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

              ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }   
        }

        public void ProcessGetBalance(){
            Console.WriteLine("Enter search account number :");
            string? accountNumber = Console.ReadLine();
            AccountDto account = accountData.GetAccount( (long)Convert.ToDouble(accountNumber));
            accountData.GetBalance(account);
        }

        public void validateConsoleInfo(){

        }

    }
}