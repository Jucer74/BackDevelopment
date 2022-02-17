using System;

namespace PrintPrimes
{
  internal class Program
  {
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
        try
        {
          for (int i = 0; i <= number; i++)
          {
            for (int j = 1; j < i; j++)
            {
              if (i%j==0)
              {
                Console.WriteLine(number);
              }
            }
          }
        }
        catch (System.Exception)
        {
          Console.WriteLine("no funca");
          throw;
        }
        
      }
    }
  }
}
