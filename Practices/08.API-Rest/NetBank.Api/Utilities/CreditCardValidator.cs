using System;
using System.Text;
namespace NetBank.Api.Utilities
{
   public class CreditCardValidator
   {
      private const int MAX_VALUE_DIGIT = 9;
      private const int MIN_LENGTH = 13;
      private const int MAX_LENGTH = 19;
      private static int sum = 0;
      private static int digit = 0;
      private static int addend = 0;
      private static bool timesTwo = false;

      public static bool IsValid(string creditCardNumber)
      {
         var digitsOnly = GetDigits(creditCardNumber);

         if (digitsOnly.Length > MAX_LENGTH || digitsOnly.Length < MIN_LENGTH) return false;

         for (var i = digitsOnly.Length - 1; i >= 0; i--)
         {
            digit = int.Parse(digitsOnly.ToString(i, 1));
            if (timesTwo)
            {
               addend = digit * 2;
               if (addend > MAX_VALUE_DIGIT)
                  addend -= MAX_VALUE_DIGIT;
            }
            else
               addend = digit;

            sum += addend;

            timesTwo = !timesTwo;
         }
         return (sum % 10) == 0;
      }

      private static StringBuilder GetDigits(string creditCardNumber)
      {
         var digitsOnly = new StringBuilder();
         foreach (var character in creditCardNumber)
         {
            if (char.IsDigit(character))
               digitsOnly.Append(character);
         }
         return digitsOnly;
      }      
   }
}