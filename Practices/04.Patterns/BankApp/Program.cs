using System;

namespace BankApp
{
   public static class Program
   {
      #region Main

      public static void Main(string[] args)
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

      #endregion Main

      #region Menu

      private static void Menu()
      {
         var option = ' ';

         while (option != '0')
         {
            Console.Clear();
            Console.WriteLine("     Banking Operation    ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Get Balance");
            Console.WriteLine("3. Deposit Amount");
            Console.WriteLine("4. Withdrawal Amount");
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
                  GetBalance();
                  break;

               case '3':
                  DepositAmount();
                  break;

               case '4':
                  WithdrawalAmount();
                  break;

               default:
                  Console.WriteLine("Invalid Option");
                  break;
            }

            Console.WriteLine("\nPress any key to continue... ");
            Console.ReadKey();
         }
      }

      #endregion Menu

      #region Options

      private static void CreateAccount()
      {
         Console.Clear();
         Console.WriteLine("Create Account");
         Console.WriteLine("--------------");
         // TODO: Implement Here the Logic
      }

      private static void DepositAmount()
      {
         Console.Clear();
         Console.WriteLine("Deposit Amount");
         Console.WriteLine("--------------");
         // TODO: Implement Here the Logic
      }

      private static void GetBalance()
      {
         Console.Clear();
         Console.WriteLine("Get Balance");
         Console.WriteLine("-----------");
         // TODO: Implement Here the Logic
      }

      private static void WithdrawalAmount()
      {
         Console.Clear();
         Console.WriteLine("Withdrawal Amount");
         Console.WriteLine("----------------");
         // TODO: Implement Here the Logic
      }

      #endregion Options
   }
}