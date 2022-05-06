// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
namespace BankApp
{
  using System;
  using System.Globalization;
  using Dto;

  public class BankAccount
  {
    private static List<BankAccount> accountList;

    //se utiliza para validación de cuenta
    private static AccountValidation accountValidation;
    private static void Main(string[] args)
    {

        Integer AccountNumber;
        String placeHolder;
        double balanceAmount;
        Integer accountType;
      try
      {
        Menu();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    private static void CreateAccount(){

      accountValidation = new AccountValidation();
            
            var account = accountValidation.ElegirAccountType(accountList);
            accountList = new List<BankAccount>();
            accountList.Add(account);

            if (accountList != null)
            {
                Console.WriteLine("Account created sactisfactoriamente");
            }
            else
            {
                Console.WriteLine("error al crear cuenta");
            }
        }

    private static void Menu()
    {
      var option = ' ';

      while (option != '0')
      {
        Console.Clear();
        Console.WriteLine("     BankAccount    ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Get Balance Account");
        Console.WriteLine("3. Deposit Account");
        Console.WriteLine("4. Withdrawal Account");
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



     //Método Depositar dinero 
    private static void PostDeposit(long AcountNumber, double Amount)
    {
   
BankAccount deposito = new BankAccount();
   deposito = BankAccount.PostDeposit(AcountNumber, Amount);

      Console.WriteLine();
    }
  }
}
