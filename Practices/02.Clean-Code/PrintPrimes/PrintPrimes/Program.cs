using System;

namespace PrintPrimes
{
  internal class Program
  {
    static void Main(string[] args)
    {
      PrintPrimes(13);
      // 2,3,5,7,11,13
      Console.WriteLine ("-13-");
      PrintPrimes(10);
      // 2,3,5,7
      Console.WriteLine ("-10-");
      PrintPrimes(0);
      // Error: Invalid Number
      Console.WriteLine ("-0-");
      PrintPrimes(1);
      // Error: 1 Is not Prime
      Console.WriteLine ("-1-");

    }

    private static void PrintPrimes(int number)
    {
      int cont = 0;
        for (int i = 2; i <= number; i++){  
  for (int j = 1; j <= i; j++){  
 
               if (i % j == 0){ 
                  cont = cont + 1;
               }
            }
    
            if (cont <= 2){ 
               Console.WriteLine(i);
            }
            cont = 0;
    
         }
         Console.ReadKey();
    }
  }
}
