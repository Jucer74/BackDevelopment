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
      // Erorrrrr
    }

    private static void PrintPrimes(int number)
    {   
      /*   if(number > 0 && number < 1 ){
          Console.Write("Numero invalido");
        }
        else if(number%2 == 0 ){
          Console.Write("No es primo");
        } */
        
        for(int i = 0 ; i <= number ; i++){
            if(number >= 0 && number <= 1 ){
              Console.Write("Numero invalido");
                
            }else{
              
              if(i % 2 != 0 ){
              //Console.Write("No es primo");
              Console.Write(i + "   ");
            
            }
      
            }

             
          
        }

       
    }
  }
}

