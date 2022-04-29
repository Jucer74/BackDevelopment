using System;
using System.Text.RegularExpressions;

namespace BankApp
{
   public class Program
   {
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
         int accountType = GetValidAccoountType();
         string accountNumber = GetValidAccountNumber();
         string placeHolder = GetValidPlaceHolder();
         decimal initialBalanceAmount = GetValidAmount("Balance Amount");

         BankAccount bankAccount = CreateBankAccount(accountType, accountNumber, placeHolder, initialBalanceAmount);

         Bank.CreateAccount(bankAccount);
      }

      private static void DepositAmount()
      {
         Console.Clear();
         Console.WriteLine("Deposit Amount");
         Console.WriteLine("--------------");
         string accountNumber = GetValidAccountNumber();
         decimal depositAmount = GetValidAmount("Amount");

         Bank.DepositAmount(accountNumber, depositAmount);
      }

      private static void GetBalance()
      {
         Console.Clear();
         Console.WriteLine("Get Balance");
         Console.WriteLine("-----------");
         string accountNumber = GetValidAccountNumber();

         Bank.GetBalanceAccount(accountNumber);
      }

      private static void WithdrawalAmount()
      {
         Console.Clear();
         Console.WriteLine("Withdrawal Amount");
         Console.WriteLine("----------------");
         string accountNumber = GetValidAccountNumber();
         decimal depositAmount = GetValidAmount("Amount");

         Bank.WithdrawalAmount(accountNumber, depositAmount);
      }

      #endregion Options

      #region Validations

      private static bool IsValidAccountNumber(string accountNumber)
      {
         string validregEx = @"^\d{10}$";
         Regex regex = new Regex(validregEx);
         return regex.IsMatch(accountNumber);
      }

      private static bool IsValidAmount(string inputAmount)
      {
         decimal valueAmount;
         return decimal.TryParse(inputAmount, out valueAmount) && valueAmount > 0;
      }

      private static bool IsValidPlaceHolder(string placeHolder)
      {
         return (!string.IsNullOrEmpty(placeHolder) && placeHolder.Length <= 50);
      }

      #endregion Validations

      #region Get-Values

      private static void ClearKeyBuffer()
      {
         while (Console.KeyAvailable)
         {
            Console.ReadKey(true);
         }
      }

      private static int GetValidAccoountType()
      {
         ConsoleKeyInfo inputKey;
         var accountType = ' ';

         Console.Write("AccounTypepe (1-Saving , 2-Checking):  ");

         while (accountType != '1' && accountType != '2')
         {
            inputKey = Console.ReadKey(true);

            if (inputKey.Key != ConsoleKey.Enter)
            {
               accountType = inputKey.KeyChar;
            }
            ClearKeyBuffer();
         }

         Console.WriteLine(accountType);

         return Convert.ToInt32(accountType.ToString());
      }

      private static string GetValidAccountNumber()
      {
         bool isValidAccountNumber;
         string acountNumber;
         do
         {
            Console.Write("Account Number: ");
            acountNumber = Console.ReadLine();
            isValidAccountNumber = IsValidAccountNumber(acountNumber);
            if (!isValidAccountNumber)
            {
               Console.WriteLine("Account number must have 10 digits");
            }
         } while (!isValidAccountNumber);

         return acountNumber;
      }

      private static decimal GetValidAmount(string titleAmount)
      {
         bool isValidAmount;
         string inputAmount;

         do
         {
            Console.Write($"{titleAmount} : ");
            inputAmount = Console.ReadLine();
            isValidAmount = IsValidAmount(inputAmount);
            if (!isValidAmount)
            {
               Console.WriteLine("Amount is required and must be numeric");
            }
         } while (!isValidAmount);

         return Decimal.Parse(inputAmount);
      }

      private static string GetValidPlaceHolder()
      {
         bool isValidPlaceHolder;
         string placeHolder;
         do
         {
            Console.Write("Place Holder: ");
            placeHolder = Console.ReadLine();
            isValidPlaceHolder = IsValidPlaceHolder(placeHolder);
            if (!isValidPlaceHolder)
            {
               Console.WriteLine("Placeholder is required and max length is 50 characters");
            }
         } while (!isValidPlaceHolder);

         return placeHolder;
      }

      #endregion Get-Values

      #region Factory

      private static BankAccount CreateBankAccount(int accountType, string accountNumber, string placeHolder, decimal initialBalanceAmount)
      {
         if (accountType == 1)
         {
            return new SavingAccount(accountType, accountNumber, placeHolder, initialBalanceAmount);
         }

         return new CheckingAccount(accountType, accountNumber, placeHolder, initialBalanceAmount);
      }

      #endregion Factory
   }
}