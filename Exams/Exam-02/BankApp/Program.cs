using System;
using System.Collections.Generic;

namespace BankApp
{
    
    class Program
    {

        BankAccount account = new BankAccount();
        public static List<BankAccount> ListAccounts = new List<BankAccount>();
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
            
            Console.WriteLine("|       B.A.N.K A.P.P       |");
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("|    1. Create Account      |");
            Console.WriteLine("|    2. Get Balance Account |");
            Console.WriteLine("|    3. Deposit Account     |");
            Console.WriteLine("|    4. Withdrawal Account  |");
            Console.WriteLine("|    0. Exit                |");
            Console.WriteLine("|---------------------------|");
            
            option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                case '0':
                Console.Clear();
                Console.WriteLine("[ Exit ]");
                break;

                case '1':
                Console.Clear();
                
                Console.WriteLine("| C.R.E.A.T.E A.C.C.O.U.N.T |");
                Console.WriteLine("|---------------------------|");
                CreateAccount();
                
                break;

                case '2':

                Console.Clear();
                Console.WriteLine("|    G.E.T B.A.L.A.N.C.E    |");
                Console.WriteLine("|---------------------------|");
                GetBalance();
                break;

                case '3':
                Console.Clear();
                
                Console.WriteLine("|        D.E.P.O.S.I.T      |");
                Console.WriteLine("|---------------------------|");
                DepositAccount();
                break;
                case '4':
                Console.Clear();

                
                Console.WriteLine("|    W.I.T.H.D.R.A.W.A.L    |");
                Console.WriteLine("|---------------------------|");
                WithdrawalAccount();
                break;

                default:
                Console.WriteLine("...Unanswered choice. Try again");
                break;
            }

            Console.WriteLine("\nPress any key to continue... ");
            Console.ReadKey();
        }
        }

        public static void CreateAccount(){
            BankAccount newAccount = new BankAccount();

            Console.WriteLine("- Enter account number:");
            int accountNumber = int.Parse(Console.ReadLine());
            newAccount.AccountNumber = accountNumber;
            Console.WriteLine("- Enter Position Molder:");
            string positionMolder = Console.ReadLine();
            newAccount.PlaceMolder = positionMolder;
            Console.WriteLine("- Enter Balance Amount:");
            double balanceAmount = double.Parse(Console.ReadLine());
            newAccount.BalanceAmount = balanceAmount;
            Console.WriteLine("- Enter account type:");
            Console.WriteLine("  1. Savings Account.");
            Console.WriteLine("  2. Checking Account.");
            int type = int.Parse(Console.ReadLine());
            if (type == 1){
                newAccount.AccountType = true;
            }
            else{
                newAccount.AccountType = false;
            }
            
            ListAccounts.Add(newAccount);
            Console.WriteLine("\n.... The account has been created.");
        }

        public static void GetBalance(){
            Console.WriteLine("- Enter account number:");
                int accountNumber = int.Parse(Console.ReadLine());
                bool flag = false;
                foreach(BankAccount accountSearch in ListAccounts){
                if(accountSearch.AccountNumber == accountNumber){
                    flag=true;
                    Console.WriteLine("[ Your account balance is: "+accountSearch.BalanceAmount+" ]");
                    break;
                }
            }
            if(flag == false){
                Console.WriteLine("\n...Account number does not exist");
            }
        }

        public static void DepositAccount(){
            Console.WriteLine("- Enter account number:");
                int accountNumber = int.Parse(Console.ReadLine());
                bool flag = false;
                foreach(BankAccount accountSearch in ListAccounts){
                if(accountSearch.AccountNumber == accountNumber){
                    flag=true;
                    Console.WriteLine("- Enter amount to deposit:");
                    double amount = double.Parse(Console.ReadLine());
                    accountSearch.Deposit(amount);
                    Console.WriteLine("\n...Amount deposited");
                    break;
                }
            }
            if(flag == false){
                Console.WriteLine("\n...Account number does not exist");
            }
        }

        public static void WithdrawalAccount(){
            Console.WriteLine("- Enter account number:");
            int accountNumber = int.Parse(Console.ReadLine());
            bool flag = false;
            foreach(BankAccount accountSearch in ListAccounts){
                if(accountSearch.AccountNumber == accountNumber){
                    flag=true;
                    Console.WriteLine("- Enter amount to withdraw:");
                    double amount = double.Parse(Console.ReadLine());
                    if (accountSearch.Withdrawal(amount)==true){
                        Console.WriteLine("\n...the amount was withdrawn");
                    }
                    else{
                        Console.WriteLine("\n...The money could not be withdrawn");
                    }
                    break;
                }
            }
            if(flag == false){
                Console.WriteLine("\n...Account number does not exist");
            }
        }

    }
}
