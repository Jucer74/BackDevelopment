using System;

namespace PrintPrimes{
  internal class Program{
    static void Main(string[] args){
      Console.WriteLine("---------");
      PrintPrimes(13);
      // 2,3,5,7,11,13
      Console.WriteLine("");
      PrintPrimes(10);
      // 2,3,5,7
      Console.WriteLine("");
      PrintPrimes(0);
      // Error: Invalid Number
      Console.WriteLine(" ");
      PrintPrimes(1);
      // Error: 1 Is not Prime

    }

    private static void PrintPrimes(int number){
      int cont = 0;
      try{
        if (number==0){
          Console.Write("Error: Invalid Number");
        }else if (number==1){
          Console.Write("Error: 1 is not Prime");
        }else{
          for (int i = 2; i <= number; i++){
            for (int j = 1; j <= i; j++){ 
              if (i % j == 0){ 
                cont += 1;
              }
            }
            if (cont <= 2){ 
              Console.Write(i+",");
            }      
            cont = 0;
          } //asdasdas
        }
      }
      catch (System.Exception){
        Console.WriteLine("Error mi broder");
        throw;
      }
      
    }
  }
}
