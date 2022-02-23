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
     
      // Loop to iterate until the number
      for (int i = 2; i <= number; i++)
      {
          // Validate is the index is Prime
          bool flag=false;
          // loop from 2 to number 
          for (int j = 2; j <= i; j++)
          {
            // validate if multipleOf
            if (i % j == 0)
            {
              // return True =>> Not Prime
              flag = true;
              break;
            }
          }

            // If IsPrime
          if(flag == false)
          {
            // Write Number
            Console.WriteLine(i);
          }
      }
    }
  }
}
