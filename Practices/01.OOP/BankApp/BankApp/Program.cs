//Juan Camilo Mayorca Puerto - 65059
using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        public static List<CreateAccount> listAccount = new List<CreateAccount>();
        static void Main(string[] args)
        {
             Menu();
        }
        private static void Menu()
    {
      var option = ' ';

      while (option != '0')
      {
        Console.Clear();
        Console.WriteLine("------------------------------");
        Console.WriteLine("           Welcome    ");
        Console.WriteLine("     Equisde Bank App    ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Create Acount");
        Console.WriteLine("2. Get Balance Account");
        Console.WriteLine("3. Deposit Account");
        Console.WriteLine("4. Withdrawal Account");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Select Option:");
        Console.WriteLine("------------------------------");
        option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (option)
        {
          case '0':
            Console.WriteLine("Exit");
            break;
          case '1':
            Create();
            break;
          case '2':
            GetBalanceAccount();
            break;
          case '3':
            DepositAccount();
            break;
          case '4':
            WithdrawalAccount();
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


    private static void Create()
    {
      Console.Clear();
      int atype=0;
      var accountType = " ";
      Console.WriteLine("Enter account number");
      int accountNumber = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter Place Holder");
      string placeHolder = Console.ReadLine();
                
      Console.WriteLine("Enter Balance Amount");
      double balanceAmount = double.Parse(Console.ReadLine());

      Console.WriteLine("Enter account type");
      Console.WriteLine("Savings accounts Or Express accounts");
      Console.WriteLine("1/Savings accounts \n 2/Express accounts");
      atype = Console.ReadKey().KeyChar;
      switch (atype){
        case 1:
        accountType = "Saving";
        break;
        case 2:
        accountType = "Express";
        break;
        default:
        Console.WriteLine("");
        break;
      }

    CreateAccount newAccount = new CreateAccount();
    newAccount = CreateAcc(accountNumber,placeHolder,accountType,balanceAmount);

    listAccount.Add(newAccount);
    }

  private static CreateAccount CreateAcc(int accountNumber, string placeHolder, string accountType, double balanceAmount)
        {
           
            CreateAccount createAccount = new CreateAccount();
            createAccount.AccountNumber = accountNumber;
            createAccount.PlaceHolder = placeHolder;
            createAccount.AccountType = accountType;
            createAccount.BalanceAmount = balanceAmount;

        return createAccount;
        }


  private static void DepositAccount()
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT ACCOUNT");

            Console.WriteLine("Enter Account Number");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (CreateAccount searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAmount);

                    Console.WriteLine("Digite el saldo a depositar");
                    int balanceAmount = int.Parse(Console.ReadLine());

                    searchAccount.Deposit(balanceAmount);
                }

            }
        }

  private static void GetBalanceAccount()
        {
            Console.Clear();
            Console.WriteLine("Balance Account");
            Console.WriteLine("---------------");
            Console.WriteLine("ENTER ACCOUNT NUMBER");
            int accountNumber = int.Parse(Console.ReadLine());
            
            foreach (CreateAccount searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAmount);
                }

            }
        }

  private static void WithdrawalAccount()
        {
            Console.Clear();
            Console.WriteLine("Withdraw Account");
            Console.WriteLine("ENTER ACCOUNT NUMBER");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (CreateAccount searchAccount in listAccount)
            {
                if(searchAccount.AccountNumber == accountNumber){
                    Console.WriteLine("BALANCE ACCOUNT:");
                    Console.WriteLine(searchAccount.BalanceAmount);

                    Console.WriteLine("Digite el saldo a retirar");
                    int balanceAmount = int.Parse(Console.ReadLine());

                    searchAccount.Withdrawal(balanceAmount);
                }

            }

        }

  }
}
