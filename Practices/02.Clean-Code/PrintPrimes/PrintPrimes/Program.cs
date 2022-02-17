using System;

namespace PrintPrimes
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine ("~~~~~~~~~~~~~~~");
      Console.WriteLine ("Primos hasta 13");
      PrintPrimes(13);
      // 2,3,5,7,11,13
      Console.WriteLine ("~~~~~~~~~~~~~~~");
      Console.WriteLine ("Primos hasta 10");
      PrintPrimes(10);
      // 2,3,5,7
      Console.WriteLine ("~~~~~~~~~~~~~~~");
      Console.WriteLine ("Primos hasta 1");
      PrintPrimes(1);
      // Error: 1 Is not Prime
      Console.WriteLine ("~~~~~~~~~~~~~~~");
      Console.WriteLine ("Primos hasta 0");
      PrintPrimes(0);
      Console.WriteLine ("~~~~~~~~~~~~~~~");
      // Error: Invalid Number
    }
    private static void PrintPrimes(int number){
      if (number==0){
        Console.WriteLine ("Invalid Number");
      }
      else if (number==1){
        Console.WriteLine ("1 Is not Prime");
      }
      else{
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
}
