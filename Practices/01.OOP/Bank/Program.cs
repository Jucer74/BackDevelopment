using System;

namespace Bank
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

    List <BankAccount> BankAccounts = new List<BankAccount>();

    private static void Menu()
    {
      var option = ' ';

      while (option != '0')
      {
        Console.Clear();
        Console.WriteLine("             B.A.N.K          ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Get Balance Account");
        Console.WriteLine("3. Deposit Account");
        Console.WriteLine("4. Withdraw Account");
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
            CreateAccount();
            break;
          case '2':
            GetBalanceAccount();
            break;
          case '3':
            DepositAccount();
            break;
            case '4':
            WithdrawAccount();
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

                BankAccounts.Add(bankAccount);
                
            }
              
        }
    }



