using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CreditBank.Api.Utilities
{
   public static class CreditCardValidator
   {
      private const int MAX_ADDEND = 9;
      private const int MAX_CREDIT_CARD_LENGTH = 19;
      private const int MIN_CREDIT_CARD_LENGTH = 13;
      private const int MOD_10 = 10;
      private const int MULTIPLY_NUMBER = 2;
      private const string REGEX_NUMERIC_VALUE = "^[0-9]*$";

      public static bool IsValid(string creditCardNumber)
      {
         var digitsOnly = GetDigits(creditCardNumber);

         if (digitsOnly.Length > MAX_CREDIT_CARD_LENGTH || digitsOnly.Length < MIN_CREDIT_CARD_LENGTH) return false;

         int sum = 0;
         int digit = 0;
         int addend = 0;
         bool timesTwo = false;

         for (var i = digitsOnly.Length - 1; i >= 0; i--)
         {
            digit = int.Parse(digitsOnly.ToString(i, 1));
            if (timesTwo)
            {
               addend = digit * MULTIPLY_NUMBER;
               if (addend > MAX_ADDEND)
                  addend -= MAX_ADDEND;
            }
            else
               addend = digit;

            sum += addend;

            timesTwo = !timesTwo;
         }
         return (sum % MOD_10) == 0;
      }

      public static bool IsNumericCard(string creditCardNumber)
      {
         Regex regEx = new Regex(REGEX_NUMERIC_VALUE);

         return !string.IsNullOrEmpty(creditCardNumber) && regEx.IsMatch(creditCardNumber);

      }

      private static StringBuilder GetDigits(string creditCardNumber)
      {
         var digitsOnly = new StringBuilder();
         foreach (char c in creditCardNumber.Where(c => char.IsDigit(c)))
         {
            digitsOnly.Append(c);
         }

         return digitsOnly;
      }
   }
}
