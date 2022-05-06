using System;
using System.Globalization;
using System.Collections.Generic;
namespace BankApp
{
    
    class Program
    {

        public static List<BankAccount> AccountList = new List<BankAccount>();
        BankAccount account = new BankAccount();
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
            Console.WriteLine("*****************************");
            Console.WriteLine("*         B.A.N.K APP       *");
            Console.WriteLine("*****************************");
            Console.WriteLine("*    1. Create Account      *");
            Console.WriteLine("*    2. Get Balance Account *");
            Console.WriteLine("*    3. Deposit Account     *");
            Console.WriteLine("*    4. Withdrawal Account  *");
            Console.WriteLine("*    0. Exit                *");
            Console.WriteLine("*****************************");
            
            option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                case '0':
                Console.WriteLine("( Exit )");
                break;

                case '1':

                Console.Clear();

                Console.WriteLine("*****************************");
                Console.WriteLine("*       CREATE ACCOUNT      *");
                Console.WriteLine("*****************************");

                CreateAccount();

                break;

                case '2':

                Console.Clear();

                Console.WriteLine("*****************************");
                Console.WriteLine("*         GET BALANCE       *");
                Console.WriteLine("*****************************");

                GetBalance();

                break;

                case '3':
                Console.Clear();

                Console.WriteLine("*****************************"); 
                Console.WriteLine("*           DEPOSIT         *");
                Console.WriteLine("*****************************");

                Deposit();

                break;

                case '4':
                Console.Clear();

                Console.WriteLine("*****************************"); 
                Console.WriteLine("*         WITHDRAWAL        *");
                Console.WriteLine("*****************************");

                Withdrawal();

                break;

            }

            Console.WriteLine("\n Press any key to continue . . . ");
            Console.ReadKey();
        }
        }

        public static void CreateAccount(){
            Console.Write("- Enter account number: ");
                int AccountNumber = int.Parse(Console.ReadLine());

                Console.Write("- Enter Position Holder: ");
                string PositionHolder = Console.ReadLine();
                
                Console.Write("- Enter Balance Amount: ");
                double BalanceAmount = double.Parse(Console.ReadLine());

                Console.WriteLine("- Select account type");
                bool AccountType = false;
                Console.WriteLine("\n( 1.Saving Account - 2.Cheking Account )");
                int OptionType = int.Parse(Console.ReadLine());
                if (OptionType == 1){
                    AccountType = true;
                }
                else{
                    AccountType = false;
                }

                BankAccount CreateAccount = new BankAccount();
                CreateAccount.AccountNumber = AccountNumber;
                CreateAccount.PlaceHolder = PositionHolder;
                CreateAccount.BalanceAmount = BalanceAmount;
                CreateAccount.AccountType = AccountType;
                

                AccountList.Add(CreateAccount);

                Console.WriteLine("\n~ ~ ~ The account has been created.");
        }

        public static void GetBalance(){
            Console.Write("- Enter account number: ");
                int AccountNumberBalance = int.Parse(Console.ReadLine());
                bool flag = false;
                foreach(BankAccount SearchAccount in AccountList){
                    if(SearchAccount.AccountNumber == AccountNumberBalance){
                        flag=true;
                        Console.WriteLine("("+SearchAccount.PlaceHolder+"'s account balance is: "+SearchAccount.BalanceAmount+" )");
                        break;
                    }
                }
                if(flag == false){
                    Console.WriteLine("\n This account number does not exist. Please try again . . .");
                }
        }

        public static void Deposit(){

            Console.Write("- Enter the account number: ");
                int accountNumberDeposit = int.Parse(Console.ReadLine());
                bool flagDeposit = false;
                foreach(BankAccount SearchAccount in AccountList){
                    if(SearchAccount.AccountNumber == accountNumberDeposit){
                        flagDeposit=true;
                        Console.Write("- Enter the amount to deposit: ");
                        double amount = double.Parse(Console.ReadLine());
                        SearchAccount.Deposit(amount);
                        Console.WriteLine("\n~ ~ ~ Amount deposited");
                        break;
                    }
                }
                if(flagDeposit == false){
                    Console.WriteLine("\n This Account number does not exist");
                }
        }

        public static void Withdrawal(){
            Console.Write("- Enter account number: ");
                int accountNumberWithdraw = int.Parse(Console.ReadLine());
                bool flagWithdraw = false;
                foreach(BankAccount SearchAccount in AccountList){
                    if(SearchAccount.AccountNumber == accountNumberWithdraw){
                        flagWithdraw=true;
                        Console.Write("- Enter amount to withdraw: ");
                        double amount = double.Parse(Console.ReadLine());
                        if (SearchAccount.Withdrawal(amount)==true){
                            Console.WriteLine("\n~ ~ ~ The amount was successfully withdrawn");
                        }
                        else{
                            Console.WriteLine("\n That amount of money cannot be withdrawn . . .");
                        }
                        
                        break;
                    }
                }
                if(flagWithdraw == false){
                    Console.WriteLine("\n This account number does not exist, please try again . . .");
                }
        }
    }
}
