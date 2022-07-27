using System;
using System.Text;

namespace PrintPrimes
{
  internal class Program
  {
    private const int INITIAL_PRIME = 2;
    static void Main(string[] args)
    {
      PrintPrimes(13);
      // 2,3,5,7,11,13
      PrintPrimes(10);
      // 2,3,5,7
      PrintPrimes(0);
      // Error: Invalid Number
      PrintPrimes(1);
      // Error: 1 Is not Prime

    }

    private static void PrintPrimes(int number)
    {

      if(number==0)
      {
        Console.WriteLine("Error: Invalid Number");
        return;
      }

      if(number==1)
      {
        Console.WriteLine("Error: 1 Is not Prime");
        return;
      }

      Console.WriteLine(GetPrimes(number));
    }
    private static bool IsMultipleOf(int currentNumber, int baseMultiple)
    {
      return currentNumber % baseMultiple == 0 && currentNumber != baseMultiple;
    }

    private static bool IsPrime(int currentNumber)
    {
        for (int baseMultiple = INITIAL_PRIME; baseMultiple <= currentNumber; baseMultiple++)
        {
          if (IsMultipleOf(currentNumber, baseMultiple))
          {
            return false;
          }
        }
        return true;
    }

    private static string GetPrimes(int number)
    {
      StringBuilder sbPrimes= new StringBuilder();

      for (int currentNumber = INITIAL_PRIME; currentNumber <= number; currentNumber++)
      {
          if(IsPrime(currentNumber))
          {
            sbPrimes.Append(currentNumber);
            if(currentNumber < number)
            {
              sbPrimes.Append(",");
            }
          }
      }

      return sbPrimes.ToString();
    }
  }
}

